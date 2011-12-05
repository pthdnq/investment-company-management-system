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

            int result = 3;

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
                wndChooseJC.IFrameUrl ="ChooseJiangCheng.aspx";
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
            if (Session["JC:" + CurrentUser.ObjectId.ToString()] != null)
            {
                tbxJCName.Text = Session["JC:" + CurrentUser.ObjectId.ToString()].ToString().Split(',')[1];
            }
        }

        /// <summary>
        /// 选择部门总监关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndChooseZJ_Close(object sender, WindowCloseEventArgs e)
        {
            if (Session["ZJ:" + CurrentUser.ObjectId.ToString()] != null)
            {
                tbxZJ.Text = Session["ZJ:" + CurrentUser.ObjectId.ToString()].ToString().Split(',')[1];
            }
        }
        #endregion
    }
}