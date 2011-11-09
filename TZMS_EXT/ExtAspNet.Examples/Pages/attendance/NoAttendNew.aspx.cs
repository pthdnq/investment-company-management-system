using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using ExtAspNet;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class NoAttendNew : BasePage
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strOperatorType = Page.Request.QueryString["Type"];
                string strNoAttendID = Page.Request.QueryString["NoAttendID"];

                switch (strOperatorType)
                {
                    case "Add":
                        {
                            OperatorType = strOperatorType;

                            BindNext();
                            BindApproveUser();
                            BindYear();
                        }
                        break;
                    case "View":
                        {
                            OperatorType = strOperatorType;
                            NoAttendID = strNoAttendID;

                            BindNext();
                            BindApproveUser();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定下一步下拉框
        /// </summary>
        private void BindNext()
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            ddlstNext.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定审批人
        /// </summary>
        private void BindApproveUser()
        {
            List<UserInfo> lstApproveUser = CurrentChecker;
            if (lstApproveUser != null)
            {
                foreach (UserInfo approveUser in lstApproveUser)
                {
                    ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(approveUser.Name, approveUser.ObjectId.ToString()));
                }

                ddlstApproveUser.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 绑定年份
        /// </summary>
        private void BindYear()
        {
            int year = DateTime.Now.Year;
            string tempString = string.Empty;
            for (int i = -3; i < 2; i++)
            {
                tempString = (year + i).ToString();
                ddlstYear.Items.Add(new ExtAspNet.ListItem(tempString, tempString));
            }
            ddlstYear.SelectedValue = year.ToString();

            ddlstMonth.SelectedValue = DateTime.Now.Month.ToString();
        }

        /// <summary>
        /// 绑定申请单信息
        /// </summary>
        private void BindNoAttendInfo()
        {

        }

        /// <summary>
        /// 绑定审批历史
        /// </summary>
        private void BindApproveHistory()
        {

        }

        /// <summary>
        /// 禁用所用控件
        /// </summary>
        private void DisableAllControls()
        { 
            
        }

        /// <summary>
        /// 提交申请单
        /// </summary>
        private void SaveInfo()
        {
            if (CurrentUser == null)
            {
                return;
            }

            // 创建未打卡申请单实例,并从页面上获取值.
            NoAttendManage _manage = new NoAttendManage();
            NoAttendInfo _info = new NoAttendInfo();
            _info.ObjectId = Guid.NewGuid();
            _info.UserId = CurrentUser.ObjectId;
            _info.UserName = CurrentUser.Name;
            _info.UserAccountNo = CurrentUser.AccountNo;
            _info.UserJobNo = CurrentUser.JobNo;
            _info.Dept = CurrentUser.Dept;
            _info.TellPhone = CurrentUser.PhoneNumber;
            _info.Year = short.Parse(ddlstYear.SelectedValue);
            _info.Month = short.Parse(ddlstMonth.SelectedValue);
            _info.ApplyTime = DateTime.Now;
            _info.Comment = taaSument.Text.Trim();
            _info.Other = taaOther.Text.Trim();
            _info.State = 0;
            _info.Isdelete = false;
            _info.CurrentCheckId = new Guid(ddlstApproveUser.SelectedValue);

            int result = _manage.AddNewNoAttendInfo(_info);

            // 插入起草记录到数据库.

            NoAttendCheckInfo _startupCheckInfo = new NoAttendCheckInfo();
            _startupCheckInfo.ObjectId = Guid.NewGuid();
            _startupCheckInfo.CheckerId = _info.UserId;
            _startupCheckInfo.CheckerName = _info.UserName;
            _startupCheckInfo.CheckrDept = _info.Dept;
            _startupCheckInfo.CheckDateTime = _info.ApplyTime;
            _startupCheckInfo.CheckOp = "0";
            _startupCheckInfo.ApplyId = _info.ObjectId;

            _manage.AddNewNoAttendCheckInfo(_startupCheckInfo);

            // 插入新的审批记录到数据库.
            NoAttendCheckInfo _checkInfo = new NoAttendCheckInfo();
            UserInfo _checkUserInfo = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
            if (_checkUserInfo != null)
            {
                _checkInfo.ObjectId = Guid.NewGuid();
                _checkInfo.CheckerId = _checkUserInfo.ObjectId;
                _checkInfo.CheckerName = _checkUserInfo.Name;
                _checkInfo.CheckrDept = _checkUserInfo.Dept;
                _checkInfo.CheckDateTime = ACommonInfo.DBEmptyDate;
                _checkInfo.Checkstate = 0;
                _checkInfo.ApplyId = _info.ObjectId;

                _manage.AddNewNoAttendCheckInfo(_checkInfo);
            }

            if (result == -1)
            {
                Alert.Show("申请提交成功!");

                // 当提交成功时，禁用提交按钮以及刷新审批历史.
                btnSave.Enabled = false;
                BindApproveHistory();
            }
            else
            {
                Alert.Show("申请提交失败!");
            }
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 审批历史数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApproveHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {

        }

        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 提交按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }

        #endregion
    }
}