using System;
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

        /// <summary>
        /// 根据角色类型来获取用户
        /// </summary>
        /// <param name="roleType">角色类型</param>
        /// <returns>用户集合</returns>
        private List<UserRoles> GetUsersByRole(RoleType roleType, string strCondition)
        {
            List<UserRoles> lstUserRoles = new List<UserRoles>();
            List<UserRoles> lstRoles = new RolesManage().GerRolesByCondition(strCondition);
            if (lstRoles.Count > 0)
            {
                string[] arrayRoles = { };
                bool isContain = false;
                foreach (UserRoles role in lstRoles)
                {
                    isContain = false;
                    arrayRoles = role.Roles.Split(',');
                    foreach (string strRole in arrayRoles)
                    {
                        if ((int)roleType == Convert.ToInt32(strRole))
                        {
                            isContain = true;
                            break;
                        }
                    }

                    if (isContain)
                    {
                        lstUserRoles.Add(role);
                    }
                }
            }

            return lstUserRoles;
        }

        /// <summary>
        /// 绑定交接人
        /// </summary>
        private void BindTransfer()
        {
            ddlstTransferCWDept.Hidden = false;
            ddlstTransferCWDept.Enabled = true;
            ddlstTransferSSDept.Hidden = false;
            ddlstTransferSSDept.Enabled = true;
            ddlstTransferXZDept.Hidden = false;
            ddlstTransferXZDept.Enabled = true;
            UserManage _userManage = new UserManage();
            UserLeaveApplyInfo _applyInfo = new UserLeaveManage().GetApplyByObjectID(ApplyID);
            UserInfo _applyUser = _userManage.GetUserByObjectID(_applyInfo.UserID.ToString());
            if (_applyInfo == null || _applyUser == null)
                return;

            #region 绑定所属部门

            {
                List<UserRoles> lstUserRoles = null;
                switch (_applyUser.Dept)
                {
                    case "行政部":
                        lstUserRoles = GetUsersByRole(RoleType.XZZG, "1 = 1");
                        break;
                    case "财务部":
                        lstUserRoles = GetUsersByRole(RoleType.CWZG, "1 = 1");
                        break;
                    case "投资部":
                        lstUserRoles = GetUsersByRole(RoleType.TZZG, "1 = 1");
                        break;
                    case "业务部":
                        lstUserRoles = GetUsersByRole(RoleType.YWZG, "1 = 1");
                        break;
                    default:
                        break;
                }
                UserInfo _tempUser = null;
                foreach (UserRoles role in lstUserRoles)
                {
                    _tempUser = _userManage.GetUserByObjectID(role.UserObjectId.ToString());
                    if (_tempUser != null)
                    {
                        if (_tempUser.State != 2 && _tempUser.Dept == _applyUser.Dept)
                        {
                            ddlstTransferSSDept.Items.Add(new ExtAspNet.ListItem(_tempUser.Name, _tempUser.ObjectId.ToString()));
                            _tempUser = null;
                        }
                    }
                }
            }

            #endregion

            #region 绑定财务部

            {
                List<UserRoles> lstUserRoles = null;
                lstUserRoles = GetUsersByRole(RoleType.CWZG, "1 = 1");

                UserInfo _tempUser = null;
                foreach (UserRoles role in lstUserRoles)
                {
                    _tempUser = _userManage.GetUserByObjectID(role.UserObjectId.ToString());
                    if (_tempUser != null)
                    {
                        if (_tempUser.State != 2)
                        {
                            ddlstTransferCWDept.Items.Add(new ExtAspNet.ListItem(_tempUser.Name, _tempUser.ObjectId.ToString()));
                        }
                    }
                }
            }

            #endregion

            #region 绑定行政部

            {
                List<UserRoles> lstUserRoles = null;
                lstUserRoles = GetUsersByRole(RoleType.XZZG, "1 = 1");

                UserInfo _tempUser = null;
                foreach (UserRoles role in lstUserRoles)
                {
                    _tempUser = _userManage.GetUserByObjectID(role.UserObjectId.ToString());
                    if (_tempUser != null)
                    {
                        if (_tempUser.State != 2)
                        {
                            ddlstTransferXZDept.Items.Add(new ExtAspNet.ListItem(_tempUser.Name, _tempUser.ObjectId.ToString()));
                        }
                    }
                }
            }

            #endregion
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
            UserManage _userManage = new UserManage();

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
                UserInfo _approveUser = _userManage.GetUserByObjectID(ddlstApproveUser.SelectedValue);
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
                UserInfo _approveUser = _userManage.GetUserByObjectID(ddlstApproveUser.SelectedValue);
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

                // 插入交接信息.
                // 所属部门.
                UserLeaveTransferInfo _transferInfo = new UserLeaveTransferInfo();
                UserInfo _ssUser = _userManage.GetUserByObjectID(ddlstTransferSSDept.SelectedValue);
                if (_ssUser != null)
                {
                    _transferInfo.ObjectID = Guid.NewGuid();
                    _transferInfo.TransferID = _ssUser.ObjectId;
                    _transferInfo.TransferName = _ssUser.Name;
                    _transferInfo.TransferDept = _ssUser.Dept;
                    _transferInfo.IsTransfer = false;
                    _transferInfo.TransferType = 0;
                    _transferInfo.TransferState = -1;
                    _transferInfo.ApplyID = _applyInfo.ObjectID;

                    _manage.AddNewTransfer(_transferInfo);
                }

                // 财务交接人.
                _transferInfo = new UserLeaveTransferInfo();
                UserInfo _cwUser = _userManage.GetUserByObjectID(ddlstTransferCWDept.SelectedValue);
                if (_cwUser != null)
                {
                    _transferInfo.ObjectID = Guid.NewGuid();
                    _transferInfo.TransferID = _cwUser.ObjectId;
                    _transferInfo.TransferName = _cwUser.Name;
                    _transferInfo.TransferDept = _cwUser.Dept;
                    _transferInfo.IsTransfer = false;
                    _transferInfo.TransferType = 1;
                    _transferInfo.TransferState = -1;
                    _transferInfo.ApplyID = _applyInfo.ObjectID;

                    _manage.AddNewTransfer(_transferInfo);
                }

                // 行政交接人.
                _transferInfo = new UserLeaveTransferInfo();
                UserInfo _xzUser = _userManage.GetUserByObjectID(ddlstTransferXZDept.SelectedValue);
                if (_xzUser != null)
                {
                    _transferInfo.ObjectID = Guid.NewGuid();
                    _transferInfo.TransferID = _xzUser.ObjectId;
                    _transferInfo.TransferName = _xzUser.Name;
                    _transferInfo.TransferDept = _xzUser.Dept;
                    _transferInfo.IsTransfer = false;
                    _transferInfo.TransferType = 2;
                    _transferInfo.TransferState = -1;
                    _transferInfo.ApplyID = _applyInfo.ObjectID;

                    _manage.AddNewTransfer(_transferInfo);
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
                ddlstTransferCWDept.Hidden = true;
                ddlstTransferCWDept.Enabled = false;
                ddlstTransferSSDept.Hidden = true;
                ddlstTransferSSDept.Enabled = false;
                ddlstTransferXZDept.Hidden = true;
                ddlstTransferXZDept.Enabled = false;
            }
            else if (ddlstNext.SelectedIndex == 1)
            {
                BindArchiver();
                BindTransfer();
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