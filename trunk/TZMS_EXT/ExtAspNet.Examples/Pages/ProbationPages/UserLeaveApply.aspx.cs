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
    public partial class UserLeaveApply : BasePage
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
        /// 申请ID
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
                UserLeaveApplyInfo _applyInfo = new UserLeaveManage().GetApplyByUserID(CurrentUser.ObjectId.ToString());
                if (_applyInfo == null)
                {
                    OperatorType = "Add";
                    lblName.Text = CurrentUser.Name;
                    lblAppDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    lblPosition.Text = CurrentUser.Position;
                    tabApproveHistory.Hidden = true;
                    tabTransferHistory.Hidden = true;
                    BindNext();
                    BindApproveUser();
                    BindLeaveType();
                }
                else
                {
                    ApplyID = _applyInfo.ObjectID.ToString();
                    switch (_applyInfo.State)
                    {
                        case 0:
                        case 1:
                            OperatorType = "View";
                            BindNext();
                            BindApproveUser();
                            BindLeaveType();
                            BindApplyInfo();
                            BindApproveHistory();
                            BindTransferHistory();
                            DisableAllControls();
                            break;
                        case 2:
                            OperatorType = "Edit";
                            BindNext();
                            BindApproveUser();
                            BindLeaveType();
                            BindApplyInfo();
                            BindApproveHistory();
                            BindTransferHistory();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定下一步
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
            foreach (UserInfo user in CurrentChecker)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
            }

            ddlstApproveUser.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定离职类型
        /// </summary>
        private void BindLeaveType()
        {
            if (CurrentUser.IsProbation)
            {
                ddlstLeaveType.Items.Add(new ExtAspNet.ListItem("合同期满，公司要求解除劳动合同", "0"));
                ddlstLeaveType.Items.Add(new ExtAspNet.ListItem("合同期满，个人要求解除劳动合同", "1"));
                ddlstLeaveType.Items.Add(new ExtAspNet.ListItem("合同未到期，公司要求解除劳动合同", "2"));
                ddlstLeaveType.Items.Add(new ExtAspNet.ListItem("合同未到期，个人要求解除劳动合同", "3"));
            }
            else
            {
                ddlstLeaveType.Items.Add(new ExtAspNet.ListItem("试用期内公司要求解除劳动合同", "4"));
                ddlstLeaveType.Items.Add(new ExtAspNet.ListItem("试用期内个人要求解除劳动合同", "5"));
            }
        }

        /// <summary>
        /// 绑定转正申请信息
        /// </summary>
        private void BindApplyInfo()
        {
            UserLeaveManage _manage = new UserLeaveManage();
            UserLeaveApplyInfo _info = _manage.GetApplyByObjectID(ApplyID);
            if (_info != null)
            {
                lblName.Text = _info.UserName;
                lblAppDate.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                lblPosition.Text = _info.UserPosition;
                dpkLeaveDate.SelectedDate = _info.LeaveDate;
                dpkContractStartDate.SelectedDate = _info.ContractStartDate;
                dpkContractEndDate.SelectedDate = _info.ContractEndDate;
                ddlstLeaveType.SelectedValue = _info.LeaveType.ToString();
                taaLeaveReason.Text = _info.LeaveSeason;

                // 查找最早的审批记录.
                List<UserLeaveApproveInfo> lstApprove = _manage.GetApproveByCondition(" ApplyID = '" + ApplyID + "' and ApproveResult <> 0");
                if (lstApprove.Count == 1)
                {
                    ddlstApproveUser.SelectedValue = lstApprove[0].ApproverID.ToString();
                }
                else
                {
                    lstApprove.Sort(delegate(UserLeaveApproveInfo x, UserLeaveApproveInfo y) { return DateTime.Compare(x.ApproveTime, y.ApproveTime); });
                    foreach (var item in lstApprove)
                    {
                        if (DateTime.Compare(item.ApproveTime, ACommonInfo.DBEmptyDate) != 0)
                        {
                            ddlstApproveUser.SelectedValue = item.ApproverID.ToString();
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 禁用所有控件.
        /// </summary>
        private void DisableAllControls()
        {
            btnSubmit.Enabled = false;
            ddlstNext.Required = false;
            ddlstNext.ShowRedStar = false;
            ddlstNext.Enabled = false;
            ddlstApproveUser.Required = false;
            ddlstApproveUser.ShowRedStar = false;
            ddlstApproveUser.Enabled = false;
            dpkLeaveDate.Required = false;
            dpkLeaveDate.ShowRedStar = false;
            dpkLeaveDate.Enabled = false;
            dpkContractStartDate.Required = false;
            dpkContractStartDate.ShowRedStar = false;
            dpkContractStartDate.Enabled = false;
            dpkContractEndDate.Required = false;
            dpkContractEndDate.ShowRedStar = false;
            dpkContractEndDate.Enabled = false;
            taaLeaveReason.Required = false;
            taaLeaveReason.ShowRedStar = false;
            taaLeaveReason.Enabled = false;
            ddlstLeaveType.Required = false;
            ddlstLeaveType.ShowRedStar = false;
            ddlstLeaveType.Enabled = false;
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
            strCondition.Append("ApplyID = '" + ApplyID + "'");
            List<UserLeaveApproveInfo> lstApprove = new UserLeaveManage().GetApproveByCondition(strCondition.ToString());

            lstApprove.Sort(delegate(UserLeaveApproveInfo x, UserLeaveApproveInfo y)
            {
                return DateTime.Compare(y.ApproveTime, x.ApproveTime);
            });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstApprove.Count;
            this.gridApproveHistory.DataSource = lstApprove;
            this.gridApproveHistory.DataBind();
        }

        /// <summary>
        /// 绑定交接历史
        /// </summary>
        private void BindTransferHistory()
        {
            if (ApplyID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("ApplyID = '" + ApplyID + "'");
            List<UserLeaveTransferInfo> lstApprove = new UserLeaveManage().GetTransferByCondition(strCondition.ToString());

            lstApprove.Sort(delegate(UserLeaveTransferInfo x, UserLeaveTransferInfo y)
            {
                return DateTime.Compare(y.TransferTime, x.TransferTime);
            });

            // 绑定列表.
            gridTransfer.RecordCount = lstApprove.Count;
            this.gridTransfer.DataSource = lstApprove;
            this.gridTransfer.DataBind();
        }

        #endregion

        #region 页面事件

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (OperatorType == null)
                return;

            UserLeaveManage _manage = new UserLeaveManage();
            UserLeaveApplyInfo _applyInfo = null;
            int result;

            if (OperatorType == "Add")
            {
                // 插入申请单信息.
                _applyInfo = new UserLeaveApplyInfo();
                _applyInfo.ObjectID = Guid.NewGuid();
                _applyInfo.UserName = CurrentUser.Name;
                _applyInfo.UserJobNo = CurrentUser.JobNo;
                _applyInfo.UserID = CurrentUser.ObjectId;
                _applyInfo.UserAccountNo = CurrentUser.AccountNo;
                _applyInfo.UserDept = CurrentUser.Dept;
                _applyInfo.UserPosition = CurrentUser.Position;
                _applyInfo.ContractStartDate = Convert.ToDateTime(dpkContractStartDate.SelectedDate);
                _applyInfo.ContractEndDate = Convert.ToDateTime(dpkContractEndDate.SelectedDate);
                _applyInfo.LeaveDate = Convert.ToDateTime(dpkLeaveDate.SelectedDate);
                _applyInfo.LeaveSeason = taaLeaveReason.Text.Trim();
                _applyInfo.LeaveType = short.Parse(ddlstLeaveType.SelectedValue);
                _applyInfo.State = 0;
                _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                _applyInfo.ApplyTime = DateTime.Now;
                _applyInfo.TransferID = Guid.Empty;
                _applyInfo.TransferState = -1;
                _applyInfo.IsDelete = false;

                result = _manage.AddNewApply(_applyInfo);

                // 插入起草信息.
                UserLeaveApproveInfo _draftInfo = new UserLeaveApproveInfo();
                _draftInfo.ObjectID = Guid.NewGuid();
                _draftInfo.ApproverID = _applyInfo.UserID;
                _draftInfo.ApproverName = _applyInfo.UserName;
                _draftInfo.ApproverDept = _applyInfo.UserDept;
                _draftInfo.ApproveTime = _applyInfo.ApplyTime;
                _draftInfo.ApproveResult = 0;
                _draftInfo.IsApprove = true;
                _draftInfo.ApplyID = _applyInfo.ObjectID;

                _manage.AddNewApprove(_draftInfo);

                // 插入审批信息.
                UserLeaveApproveInfo _approveInfo = new UserLeaveApproveInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                if (_approveUser != null)
                {
                    _approveInfo.ObjectID = Guid.NewGuid();
                    _approveInfo.ApproverID = _approveUser.ObjectId;
                    _approveInfo.ApproverName = _approveUser.Name;
                    _approveInfo.ApproverDept = _approveUser.Dept;
                    _approveInfo.IsApprove = false;
                    _approveInfo.ApplyID = _applyInfo.ObjectID;

                    _manage.AddNewApprove(_approveInfo);
                }

                if (result == -1)
                {
                    Alert.Show("离职申请单提交成功!");
                    ApplyID = _applyInfo.ObjectID.ToString();
                    tabApproveHistory.Hidden = false;
                    tabTransferHistory.Hidden = false;
                    BindApproveHistory();
                    BindTransferHistory();
                    DisableAllControls();
                }
                else
                {
                    Alert.Show("离职申请单添加失败!");
                }
            }

            if (OperatorType == "Edit")
            {
                _applyInfo = _manage.GetApplyByObjectID(ApplyID);
                if (_applyInfo != null)
                {
                    // 更新申请单信息.
                    _applyInfo.ContractStartDate = Convert.ToDateTime(dpkContractStartDate.SelectedDate);
                    _applyInfo.ContractEndDate = Convert.ToDateTime(dpkContractEndDate.SelectedDate);
                    _applyInfo.LeaveDate = Convert.ToDateTime(dpkLeaveDate.SelectedDate);
                    _applyInfo.LeaveSeason = taaLeaveReason.Text.Trim();
                    _applyInfo.State = 0;
                    _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                    _applyInfo.ApplyTime = DateTime.Now;
                    _applyInfo.TransferID = Guid.Empty;
                    _applyInfo.TransferState = -1;
                    _applyInfo.IsDelete = false;

                    result = _manage.UpdateApply(_applyInfo);

                    // 重新插入审批信息.
                    UserLeaveApproveInfo _approveInfo = new UserLeaveApproveInfo();
                    UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    if (_approveUser != null)
                    {
                        _approveInfo.ObjectID = Guid.NewGuid();
                        _approveInfo.ApproverID = _approveUser.ObjectId;
                        _approveInfo.ApproverName = _approveUser.Name;
                        _approveInfo.ApproverDept = _approveUser.Dept;
                        _approveInfo.IsApprove = false;
                        _approveInfo.ApplyID = _applyInfo.ObjectID;

                        _manage.AddNewApprove(_approveInfo);
                    }

                    if (result == -1)
                    {
                        Alert.Show("离职申请单提交成功!");
                        BindApproveHistory();
                        BindTransferHistory();
                        DisableAllControls();
                    }
                    else
                    {
                        Alert.Show("离职申请单添加失败!");
                    }
                }
            }
        }

        protected void gridApproveHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                DateTime approveDate = DateTime.Parse(e.Values[1].ToString());
                if (DateTime.Compare(approveDate, ACommonInfo.DBMAXDate) == 0)
                {
                    e.Values[1] = "";
                    e.Values[2] = "审批中...";

                }
                else
                {
                    e.Values[1] = approveDate.ToString("yyyy-MM-dd HH:mm");
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
        }

        protected void gridTransfer_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                DateTime approveDate = DateTime.Parse(e.Values[1].ToString());
                if (DateTime.Compare(approveDate, ACommonInfo.DBMAXDate) == 0)
                {
                    e.Values[1] = "";
                    e.Values[2] = "交接中...";

                }
                else
                {
                    e.Values[1] = approveDate.ToString("yyyy-MM-dd HH:mm");
                    switch (e.Values[2].ToString())
                    {
                        case "0":
                            e.Values[2] = "所属部门交接";
                            break;
                        case "1":
                            e.Values[2] = "行政部交接";
                            break;
                        case "2":
                            e.Values[2] = "项目交接";
                            break;
                        case "4":
                            e.Values[2] = "财务部交接";
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        #endregion
    }
}