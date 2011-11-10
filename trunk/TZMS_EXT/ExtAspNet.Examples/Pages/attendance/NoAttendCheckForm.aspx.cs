using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using System.Text;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class NoAttendCheckForm : BasePage
    {
        /// <summary>
        /// NoAttendID
        /// </summary>
        public string NoAttendID
        {
            get
            {
                if (ViewState["NoAttendID"] == null)
                {
                    return null;
                }
                return ViewState["NoAttendID"].ToString();
            }

            set
            {
                ViewState["NoAttendID"] = value;
            }
        }

        /// <summary>
        /// NoAttendCheckID
        /// </summary>
        public string NoAttendCheckID
        {
            get
            {
                if (ViewState["NoAttendCheckID"] == null)
                {
                    return null;
                }
                return ViewState["NoAttendCheckID"].ToString();
            }

            set
            {
                ViewState["NoAttendCheckID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NoAttendID = Page.Request.QueryString["NoAttendID"];
                NoAttendCheckID = Page.Request.QueryString["NoAttendCheckID"];

                BindNext();
                BindApproveUser();
                BindNoAttendInfo();
                BindApproveHistory();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定下一步
        /// </summary>
        private void BindNext()
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            foreach (RoleType roleType in CurrentRoles)
            {
                if (roleType == RoleType.KQGD)
                {
                    ddlstNext.Items.Add(new ExtAspNet.ListItem("归档", "1"));
                    break;
                }
            }
            ddlstNext.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定审批人
        /// </summary>
        private void BindApproveUser()
        {
            ddlstApproveUser.Items.Clear();
            foreach (UserInfo item in CurrentChecker)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
            }

            ddlstApproveUser.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定归档人
        /// </summary>
        private void BindArchiver()
        {
            UserInfo _user = new UserManage().GetUserByObjectID(strArchiver);
            if (_user != null)
            {
                ddlstApproveUser.Items.Clear();
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(_user.Name, _user.ObjectId.ToString()));
            }
        }

        /// <summary>
        /// 绑定申请单信息
        /// </summary>
        private void BindNoAttendInfo()
        {
            NoAttendInfo _info = new NoAttendManage().GetNoAttendInfoByObjectID(NoAttendID);
            if (_info != null)
            {
                lblName.Text = _info.UserName;
                lblAppDate.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                lblYear.Text = _info.Year.ToString();
                lblMonth.Text = _info.Month.ToString();
                taaSument.Text = _info.Comment;
                taaOther.Text = _info.Other;
            }
        }

        /// <summary>
        /// 绑定审批历史
        /// </summary>
        private void BindApproveHistory()
        {
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("ApplyID = '" + NoAttendID + "'");
            strCondition.Append(" and Checkstate <> 0");
            List<NoAttendCheckInfo> lstNoAttendCheck = new NoAttendManage().GetNoAttendCheckInfoByCondition(strCondition.ToString());

            lstNoAttendCheck.Sort(delegate(NoAttendCheckInfo x, NoAttendCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstNoAttendCheck.Count;
            this.gridApproveHistory.DataSource = lstNoAttendCheck;
            this.gridApproveHistory.DataBind();
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 关闭窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 同意事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            NoAttendManage _manage = new NoAttendManage();
            NoAttendInfo _info = _manage.GetNoAttendInfoByObjectID(NoAttendID);
            if (_info != null)
            {
                int result = 3;

                // 更新申请记录.
                _info.CurrentCheckId = new Guid(ddlstApproveUser.SelectedValue);
                result = _manage.UpdateNoAttendInfo(_info);

                // 更新审批流程表.
                NoAttendCheckInfo _checkInfo = _manage.GetNoAttendCheckInfoByObjectID(NoAttendCheckID);
                if (_checkInfo != null)
                {
                    _checkInfo.Checkstate = 1;
                    _checkInfo.Result = "0";
                    _checkInfo.CheckDateTime = DateTime.Now;
                    _checkInfo.CheckSugest = string.IsNullOrEmpty(taaCheckSugest.Text.Trim()) ? "同意" : taaCheckSugest.Text.Trim();
                    _checkInfo.CheckOp = "1";
                    _manage.UpdateNoAttendCheckInfo(_checkInfo);
                }

                #region 审批
                if (ddlstNext.SelectedText == "审批")
                {
                    // 插入下一个审批记录.
                    NoAttendCheckInfo _nextCheckInfo = new NoAttendCheckInfo();
                    UserInfo _nextCheckUserInfo = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _nextCheckInfo.ObjectId = Guid.NewGuid();
                    _nextCheckInfo.CheckerName = ddlstApproveUser.SelectedText;
                    _nextCheckInfo.CheckerId = new Guid(ddlstApproveUser.SelectedValue);
                    _nextCheckInfo.CheckrDept = _nextCheckUserInfo.Dept;
                    _nextCheckInfo.CheckDateTime = ACommonInfo.DBEmptyDate;
                    _nextCheckInfo.Checkstate = 0;
                    _nextCheckInfo.ApplyId = _info.ObjectId;
                    _manage.AddNewNoAttendCheckInfo(_nextCheckInfo);
                }
                #endregion

                #region 归档

                if (ddlstNext.SelectedText == "归档")
                {
                    // 插入待归档记录.
                    NoAttendCheckInfo _nextCheckInfo = new NoAttendCheckInfo();
                    UserInfo _nextCheckUserInfo = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _nextCheckInfo.ObjectId = Guid.NewGuid();
                    _nextCheckInfo.CheckerName = ddlstApproveUser.SelectedText;
                    _nextCheckInfo.CheckerId = new Guid(ddlstApproveUser.SelectedValue);
                    _nextCheckInfo.CheckrDept = _nextCheckUserInfo.Dept;
                    _nextCheckInfo.CheckDateTime = ACommonInfo.DBEmptyDate;
                    _nextCheckInfo.Checkstate = 0;
                    _nextCheckInfo.CheckOp = "3";
                    _nextCheckInfo.ApplyId = _info.ObjectId;
                    _manage.AddNewNoAttendCheckInfo(_nextCheckInfo);
                }

                #endregion

                if (result == -1)
                {
                    Alert.Show("审批成功!");
                    btnPass.Enabled = false;
                    btnRefuse.Enabled = false;
                    BindApproveHistory();
                }
                else
                {
                    Alert.Show(ddlstNext.SelectedText + "失败!");
                }
            }
        }

        /// <summary>
        /// 不同意事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefuse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(taaCheckSugest.Text.Trim()))
            {
                Alert.Show("审批意见不可为空!");
                return;
            }

            NoAttendManage _manage = new NoAttendManage();
            NoAttendInfo _info = _manage.GetNoAttendInfoByObjectID(NoAttendID);
            UserInfo _archiveUser = new UserManage().GetUserByObjectID(strArchiver);
            if (_info != null && _archiveUser != null)
            {
                int result = 3;

                // 更新申请记录.
                _info.CurrentCheckId = _archiveUser.ObjectId;
                result = _manage.UpdateNoAttendInfo(_info);

                // 更新审批流程表.
                NoAttendCheckInfo _checkInfo = _manage.GetNoAttendCheckInfoByObjectID(NoAttendCheckID);
                if (_checkInfo != null)
                {
                    _checkInfo.Checkstate = 1;
                    _checkInfo.Result = "1";
                    _checkInfo.CheckDateTime = DateTime.Now;
                    _checkInfo.CheckSugest = taaCheckSugest.Text.Trim();
                    _checkInfo.CheckOp = "1";
                    _manage.UpdateNoAttendCheckInfo(_checkInfo);
                }

                // 插入待归档记录.
                NoAttendCheckInfo _nextCheckInfo = new NoAttendCheckInfo();
                _nextCheckInfo.ObjectId = Guid.NewGuid();
                _nextCheckInfo.CheckerName = _archiveUser.Name;
                _nextCheckInfo.CheckerId = _archiveUser.ObjectId;
                _nextCheckInfo.CheckrDept = _archiveUser.Dept;
                _nextCheckInfo.CheckDateTime = ACommonInfo.DBEmptyDate;
                _nextCheckInfo.Checkstate = 0;
                _nextCheckInfo.CheckOp = "3";
                _nextCheckInfo.ApplyId = _info.ObjectId;
                _manage.AddNewNoAttendCheckInfo(_nextCheckInfo);


                if (result == -1)
                {
                    Alert.Show("打回成功!");
                    btnPass.Enabled = false;
                    btnRefuse.Enabled = false;
                    BindApproveHistory();
                }
                else
                {
                    Alert.Show("打回失败!");
                }
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApproveHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                NoAttendCheckInfo _checkInfo = (NoAttendCheckInfo)e.DataItem;
                e.Values[0] = _checkInfo.CheckerName;
                e.Values[1] = _checkInfo.CheckDateTime.ToString("yyyy-MM-dd HH:mm");
                switch (_checkInfo.CheckOp)
                {
                    case "0":
                        e.Values[2] = "起草";
                        break;
                    case "1":
                        e.Values[2] = "审批";
                        break;
                    case "2":
                        e.Values[2] = "打回修改";
                        break;
                    case "4":
                        e.Values[2] = "归档";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 下一步选定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstNext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstNext.SelectedIndex == 0)
            {
                btnPass.Text = "同意";
                BindApproveUser();
            }
            else if (ddlstNext.SelectedIndex == 1)
            {
                btnPass.Text = "归档";
                BindArchiver();
            }
        }

        #endregion
    }
}