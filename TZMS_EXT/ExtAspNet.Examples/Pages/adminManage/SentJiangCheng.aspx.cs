using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Business;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class SentJiangCheng : BasePage
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperatorType
        {
            get
            {
                if (ViewState["OperatorType"] == null)
                {
                    return null;
                }

                return ViewState["OperatorType"].ToString();
            }
            set
            {
                ViewState["OperatorType"] = value;
            }
        }

        /// <summary>
        /// 申请单ID
        /// </summary>
        public string ApplyID
        {
            get
            {
                if (ViewState["ApplyID"] == null)
                {
                    return null;
                }

                return ViewState["ApplyID"].ToString();
            }
            set
            {
                ViewState["ApplyID"] = value;
            }
        }

        private string ViewStateJC
        {
            get
            {
                if (ViewState["ViewStateJC"] == null)
                {
                    return null;
                }

                return ViewState["ViewStateJC"].ToString();
            }
            set
            {
                ViewState["ViewStateJC"] = value;
            }
        }

        private string ViewStateZJ
        {
            get
            {
                if (ViewState["ViewStateZJ"] == null)
                {
                    return null;
                }

                return ViewState["ViewStateZJ"].ToString();
            }
            set
            {
                ViewState["ViewStateZJ"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wndChooseJC.OnClientCloseButtonClick = wndChooseJC.GetHidePostBackReference();
                wndChooseZJ.OnClientCloseButtonClick = wndChooseZJ.GetHidePostBackReference();

                string strOperatorType = Request.QueryString["Type"];
                string strApplyID = Request.QueryString["ID"];

                switch (strOperatorType)
                {
                    case "Add":
                        OperatorType = strOperatorType;
                        ApplyID = strApplyID;
                        lblName.Text = CurrentUser.Name;
                        lblApplyTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        break;
                    case "View":
                        OperatorType = strOperatorType;
                        ApplyID = strApplyID;
                        BindApplyInfo();
                        DisableAllControls();
                        break;
                    case "Edit":
                        OperatorType = strOperatorType;
                        ApplyID = strApplyID;
                        BindApplyInfo();
                        break;
                    default:
                        break;
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 提交报销申请单
        /// </summary>
        private void SaveApply()
        {
            if (string.IsNullOrEmpty(OperatorType))
                return;

            if (string.IsNullOrEmpty(ViewStateJC))
            {
                Alert.Show("奖惩人尚未设置!");
                return;
            }

            if (string.IsNullOrEmpty(ViewStateZJ))
            {
                Alert.Show("部门领导尚未设置!");
                return;
            }

            if (ViewStateZJ == ViewStateJC)
            {
                Alert.Show("奖惩人与部门领导不可为同一人!");
                return;
            }

            UserManage _userManage = new UserManage();
            JiangChengManage _manage = new JiangChengManage();
            JiangChengInfo _info = null;
            int result = 3;

            UserInfo _JCUser = _userManage.GetUserByObjectID(ViewStateJC.Split(',')[0]);
            UserInfo _ZJUser = _userManage.GetUserByObjectID(ViewStateZJ.Split(',')[0]);

            if (OperatorType == "Add")
            {
                if (_JCUser != null && _ZJUser != null)
                {
                    _info = new JiangChengInfo();
                    _info.ObjectID = Guid.NewGuid();
                    _info.CreateUserID = CurrentUser.ObjectId;
                    _info.CreateName = CurrentUser.Name;
                    _info.CreateTime = DateTime.Now;
                    _info.UserID = _JCUser.ObjectId;
                    _info.UserName = _JCUser.Name;
                    _info.UserDept = _JCUser.Dept;
                    _info.ZjID = _ZJUser.ObjectId;
                    _info.ZJName = _ZJUser.Name;
                    _info.Type = Convert.ToInt16(ddlstType.SelectedValue);
                    _info.Reason = taaReason.Text.Trim();
                    _info.State = 0;

                    result = _manage.AddNewJiangCheng(_info);
                }
            }

            if (OperatorType == "Edit")
            {
                _info = _manage.GetJiangChengByObjectID(ApplyID);
                if (_info != null && _JCUser != null && _ZJUser != null)
                {
                    _info.UserID = _JCUser.ObjectId;
                    _info.UserName = _JCUser.Name;
                    _info.UserDept = _JCUser.Dept;
                    _info.ZjID = _ZJUser.ObjectId;
                    _info.ZJName = _ZJUser.Name;
                    _info.Type = Convert.ToInt16(ddlstType.SelectedValue);
                    _info.Reason = taaReason.Text.Trim();
                    _info.State = 0;

                    result = _manage.UpdateJiangCheng(_info);
                }
            }

            if (result == -1)
            {

                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("申请提交失败!");
            }

        }

        /// <summary>
        /// 绑定报销单申请信息
        /// </summary>
        private void BindApplyInfo()
        {
            JiangChengManage _manage = new JiangChengManage();
            JiangChengInfo _info = _manage.GetJiangChengByObjectID(ApplyID);
            if (_info != null)
            {
                ViewStateJC = _info.UserID.ToString() + ',' + _info.UserName;
                ViewStateZJ = _info.ZjID.ToString() + "," + _info.ZJName;
                lblName.Text = _info.CreateName;
                lblApplyTime.Text = _info.CreateTime.ToString("yyyy-MM-dd HH:mm");
                tbxJCName.Text = _info.UserName;
                tbxZJ.Text = _info.ZJName;
                ddlstType.SelectedValue = _info.Type.ToString();
                taaReason.Text = _info.Reason;
            }
        }

        /// <summary>
        /// 禁用所有控件.
        /// </summary>
        private void DisableAllControls()
        {
            btnSubmit.Enabled = false;
            ddlstType.Required = false;
            ddlstType.ShowRedStar = false;
            ddlstType.Enabled = false;
            taaReason.Required = false;
            taaReason.ShowRedStar = false;
            taaReason.Enabled = false;
            btnSetJC.Hidden = true;
            btnSetJC.Enabled = false;
            btnSetZJ.Hidden = true;
            btnSetZJ.Enabled = false;
            tbxJCName.Required = false;
            tbxJCName.ShowRedStar = false;
            tbxZJ.Required = false;
            tbxZJ.ShowRedStar = false;
        }
        #endregion

        #region 页面事件

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 下发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveApply();
        }

        /// <summary>
        /// 设置奖惩人关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSetJC_Click(object sender, EventArgs e)
        {
            if (OperatorType == "Add")
            {
                wndChooseJC.IFrameUrl = "ChooseJiangCheng.aspx";
            }
            else
            {
                wndChooseJC.IFrameUrl = "ChooseJiangCheng.aspx?ID=" + ApplyID;
            }
            wndChooseJC.Hidden = false;
        }

        /// <summary>
        /// 设置部门总监关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSetZJ_Click(object sender, EventArgs e)
        {
            if (OperatorType == "Add")
            {
                wndChooseZJ.IFrameUrl = "ChooseZJ.aspx";
            }
            else
            {
                wndChooseZJ.IFrameUrl = "ChooseZJ.aspx?ID=" + ApplyID;
            }
            wndChooseZJ.Hidden = false;
        }

        /// <summary>
        /// 选择奖惩人关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndChooseJC_Close(object sender, WindowCloseEventArgs e)
        {
            if (e.CloseArgument != "undefined")
            {
                tbxJCName.Text = e.CloseArgument.Split(',')[1];
                ViewStateJC = e.CloseArgument;
            }
        }

        /// <summary>
        /// 选择部门总监关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndChooseZJ_Close(object sender, WindowCloseEventArgs e)
        {
            if (e.CloseArgument != "undefined")
            {
                tbxZJ.Text = e.CloseArgument.Split(',')[1];
                ViewStateZJ = e.CloseArgument;
            }
        }
        #endregion
    }
}