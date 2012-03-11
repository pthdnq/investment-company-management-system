using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class UserLeaveApproveToFileView : BasePage
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

                BindApplyInfo();
                BindApproveHistory();
                SetPanelState();
            }
        }

        #region 私有方法

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
        /// 设置面板状态
        /// </summary>
        private void SetPanelState()
        {
            if (string.IsNullOrEmpty(ApproveID))
                return;
            UserLeaveManage _manage = new UserLeaveManage();
            UserLeaveApproveInfo _approveInfo = _manage.GetApproveByObjectID(ApproveID);
            if (_approveInfo != null)
            {
                if (_approveInfo.ApproveResult == 4)
                    btnPass.Enabled = false;
            }
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
        /// 确认归档事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ApproveID))
            {
                UserLeaveManage _manage = new UserLeaveManage();
                UserLeaveApproveInfo _approveInfo = _manage.GetApproveByObjectID(ApproveID);
                int result = 3;
                if (_approveInfo != null)
                {
                    UserLeaveApplyInfo _applyInfo = _manage.GetApplyByObjectID(_approveInfo.ApplyID.ToString());

                    // 设置归档信息.
                    _approveInfo.IsApprove = true;
                    _approveInfo.ApproveResult = 4;
                    _approveInfo.ApproveTime = DateTime.Now;
                    _manage.UpdateApprove(_approveInfo);

                    List<UserLeaveApproveInfo> lstApprove = _manage.GetApproveByCondition(" ApplyID='" + _applyInfo.ObjectID.ToString()
                        + "' and (ApproveResult = 1 or ApproveResult = 2) and ApproveTime < '" + _approveInfo.ApproveTime
                        + "' order by ApproveTime desc");
                    if (lstApprove.Count > 0)
                    {

                        // 设置申请单信息.
                        if (lstApprove[0].ApproveResult == 1)
                        {
                            _applyInfo.State = 1;

                            List<UserLeaveTransferInfo> lstTransfer = _manage.GetTransferByCondition(" ApplyID = '" + _applyInfo.ObjectID.ToString() + "'");
                            foreach (var item in lstTransfer)
                            {
                                item.TransferState = 0;
                                _manage.UpdateTransfer(item);
                                ResultMsgMore(item.TransferID.ToString(), item.TransferName, "您有1条离职交接信息（来自转正离职）！");
                            }
                        }
                        else
                        {
                            _applyInfo.State = 2;
                        }

                        result = _manage.UpdateApply(_applyInfo);
                        ResultMsgMore(_applyInfo.UserID.ToString(), _applyInfo.UserName, "您有1条离职申请（来自转正离职），已归档， 待交接！");
                    }
                }

                if (result == -1)
                {
                    this.btnClose_Click(null, null);
                }
                else
                {
                    Alert.Show("离职归档失败!");
                }
            }
        }

        /// <summary>
        /// 审批历史数据行绑定事件
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