﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Text;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class UserLeaveApprove : BasePage
    {
        /// <summary>
        /// ApproveID
        /// </summary>
        public string ApproveID
        {
            get
            {
                if (ViewState["ApproveID"] == null)
                {
                    return null;
                }
                return ViewState["ApproveID"].ToString();
            }

            set
            {
                ViewState["ApproveID"] = value;
            }
        }

        /// <summary>
        /// ApplyID
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
                ApproveID = Request.QueryString["ApproveID"];
                ApplyID = Request.QueryString["ApplyID"];

                BindNext();
                BindApproveUser();
                BindApplyInfo();
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
        /// 绑定报销申请单信息
        /// </summary>
        private void BindApplyInfo()
        {
            if (!string.IsNullOrEmpty(ApplyID))
            {
                UserLeaveApplyInfo _info = new UserLeaveManage().GetApplyByObjectID(ApplyID);
                if (_info != null)
                {
                    lblName.Text = _info.UserName;
                    lblAppDate.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                    lblPosition.Text = _info.UserPosition;
                    lblLeaveDate.Text = _info.LeaveDate.ToString("yyyy-MM-dd");
                    lblContractStartDate.Text = _info.ContractStartDate.ToString("yyyy-MM-dd");
                    lblContractEndDate.Text = _info.ContractEndDate.ToString("yyyy-MM-dd");
                    switch (_info.LeaveType)
                    {
                        case 0:
                            lblLeaveType.Text = "合同期满，公司要求解除劳动合同";
                            break;
                        case 1:
                            lblLeaveType.Text = "合同期满，个人要求解除劳动合同";
                            break;
                        case 2:
                            lblLeaveType.Text = "合同未到期，公司要求解除劳动合同";
                            break;
                        case 3:
                            lblLeaveType.Text = "合同未到期，个人要求解除劳动合同";
                            break;
                        case 4:
                            lblLeaveType.Text = "试用期内公司要求解除劳动合同";
                            break;
                        case 5:
                            lblLeaveType.Text = "试用期内个人要求解除劳动合同";
                            break;
                    }
                    taaLeaveReason.Text = _info.LeaveSeason;
                }
            }
        }

        /// <summary>
        /// 绑定审批历史
        /// </summary>
        private void BindApproveHistory()
        {
            if (ApplyID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" ApplyID = '" + ApplyID + "'");
            strCondition.Append(" and IsApprove = 1 and ApproveResult <> 3");
            List<UserLeaveApproveInfo> lstApprove = new UserLeaveManage().GetApproveByCondition(strCondition.ToString());
            lstApprove.Sort(delegate(UserLeaveApproveInfo x, UserLeaveApproveInfo y) { return DateTime.Compare(y.ApproveTime, x.ApproveTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstApprove.Count;
            this.gridApproveHistory.DataSource = lstApprove;
            this.gridApproveHistory.DataBind();
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
        /// 通过事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            UserLeaveManage _manage = new UserLeaveManage();

            // 更新申请表.
            UserLeaveApplyInfo _applyInfo = _manage.GetApplyByObjectID(ApplyID);
            _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
            int result = _manage.UpdateApply(_applyInfo);

            // 更新请假申请流程表.
            UserLeaveApproveInfo _approveInfo = _manage.GetApproveByObjectID(ApproveID);
            _approveInfo.ApproveTime = DateTime.Now;
            _approveInfo.IsApprove = true;
            _approveInfo.ApproveResult = 1;
            _approveInfo.ApproverSugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
            _manage.UpdateApprove(_approveInfo);

            // 插入新的记录到流程申请表.
            if (ddlstNext.SelectedText == "审批")
            {
                UserLeaveApproveInfo _nextApproveInfo = new UserLeaveApproveInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                if (_approveUser != null)
                {
                    _nextApproveInfo.ObjectID = Guid.NewGuid();
                    _nextApproveInfo.ApproverID = _approveUser.ObjectId;
                    _nextApproveInfo.ApproverName = _approveUser.Name;
                    _nextApproveInfo.ApproverDept = _approveUser.Dept;
                    _nextApproveInfo.IsApprove = false;
                    _nextApproveInfo.ApplyID = _applyInfo.ObjectID;

                    _manage.AddNewApprove(_nextApproveInfo);
                }
            }
            else if (ddlstNext.SelectedText == "归档")
            {
                UserLeaveApproveInfo _archiverApproveInfo = new UserLeaveApproveInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                if (_approveUser != null)
                {
                    _archiverApproveInfo.ObjectID = Guid.NewGuid();
                    _archiverApproveInfo.ApproverID = _approveUser.ObjectId;
                    _archiverApproveInfo.ApproverName = _approveUser.Name;
                    _archiverApproveInfo.ApproverDept = _approveUser.Dept;
                    _archiverApproveInfo.IsApprove = false;
                    _archiverApproveInfo.ApproveResult = 3;
                    _archiverApproveInfo.ApplyID = _applyInfo.ObjectID;

                    _manage.AddNewApprove(_archiverApproveInfo);
                }
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("审批失败(同意)!");
            }
        }

        /// <summary>
        /// 不通过事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefuse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(taaApproveSugest.Text.Trim()))
            {
                Alert.Show("审批意见不可为空!");
                return;
            }

            UserLeaveManage _manage = new UserLeaveManage();

            // 更新申请表.
            UserLeaveApplyInfo _applyInfo = _manage.GetApplyByObjectID(ApplyID);
            UserInfo _archiveUser = new UserManage().GetUserByObjectID(strArchiver);
            _applyInfo.ApproverID = _archiveUser.ObjectId;
            int result = _manage.UpdateApply(_applyInfo);

            // 更新请假申请流程表.
            UserLeaveApproveInfo _approveInfo = _manage.GetApproveByObjectID(ApproveID);
            _approveInfo.ApproveTime = DateTime.Now;
            _approveInfo.IsApprove = true;
            _approveInfo.ApproveResult = 2;
            _approveInfo.ApproverSugest = taaApproveSugest.Text.Trim();
            _manage.UpdateApprove(_approveInfo);

            // 插入归档信息.
            UserLeaveApproveInfo _archiverApproveInfo = new UserLeaveApproveInfo();
            _archiverApproveInfo.ObjectID = Guid.NewGuid();
            _archiverApproveInfo.ApproverID = _archiveUser.ObjectId;
            _archiverApproveInfo.ApproverName = _archiveUser.Name;
            _archiverApproveInfo.ApproverDept = _archiveUser.Dept;
            _archiverApproveInfo.IsApprove = false;
            _archiverApproveInfo.ApproveResult = 3;
            _archiverApproveInfo.ApplyID = _applyInfo.ObjectID;
            _manage.AddNewApprove(_archiverApproveInfo);

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("审批失败(不同意)!");
            }
        }

        /// <summary>
        /// 下一步选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstNext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstNext.SelectedIndex == 0)
            {
                BindApproveUser();
            }
            else if (ddlstNext.SelectedIndex == 1)
            {
                BindArchiver();
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
                e.Values[1] = DateTime.Parse(e.Values[1].ToString()).ToString("yyyy-MM-dd HH:mm");
                switch (e.Values[2].ToString())
                {
                    case "0":
                        e.Values[2] = "起草";
                        break;
                    case "1":
                        e.Values[2] = "审批-通过";
                        break;
                    case "2":
                        e.Values[2] = "审批-不通过";
                        break;
                    case "4":
                        e.Values[2] = "归档";
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}