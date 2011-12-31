using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using System.Text;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class AttendToFileView : BasePage
    {
        /// <summary>
        /// LeaveID
        /// </summary>
        public string LeaveID
        {
            get
            {
                if (ViewState["LeaveID"] == null)
                {
                    return null;
                }
                return ViewState["LeaveID"].ToString();
            }

            set
            {
                ViewState["LeaveID"] = value;
            }
        }

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LeaveID = Request.QueryString["LeaveID"];
                ApproveID = Request.QueryString["LeaveApproveID"];

                MUDAttachment.ShowAddBtn = "false";
                MUDAttachment.ShowDelBtn = "false";

                BindLeaveInfo();
                BindApproveHistory();
                SetPanelState();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定请假单信息
        /// </summary>
        private void BindLeaveInfo()
        {
            if (LeaveID == null)
                return;
            LeaveInfo _leaveInfo = new LeaveAppManage().GetLeaveInfoByObjectID(LeaveID);
            if (_leaveInfo != null)
            {
                lblName.Text = _leaveInfo.Name;
                lblAppDate.Text = _leaveInfo.WriteTime.ToString("yyyy-MM-dd HH:mm");
                lblStartTime.Text = _leaveInfo.StartTime.ToString("yyyy-MM-dd HH:00");
                lblStopTime.Text = _leaveInfo.StopTime.ToString("yyyy-MM-dd HH:00");
                lblHours.Text = ((TimeSpan)(_leaveInfo.StopTime - _leaveInfo.StartTime)).TotalHours.ToString() + "小时";
                lblLeaveType.Text = _leaveInfo.Type;
                taaLeaveReason.Text = _leaveInfo.Reason;
                if (_leaveInfo.Type == "病假")
                {
                    ContentPanel1.Hidden = false;
                    MUDAttachment.RecordID = _leaveInfo.ObjectId.ToString();
                }
            }
        }

        /// <summary>
        /// 绑定审批历史列表
        /// </summary>
        private void BindApproveHistory()
        {
            if (LeaveID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("LeaveID = '" + LeaveID + "'");
            strCondition.Append(" and ApproveResult <> 0 and ApproveResult <> 3");
            List<LeaveApproveInfo> lstLeaveApprove = new LeaveAppManage().GetLeaveApprovesByCondition(strCondition.ToString());

            lstLeaveApprove.Sort(delegate(LeaveApproveInfo x, LeaveApproveInfo y) { return DateTime.Compare(y.ApproveTime, x.ApproveTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstLeaveApprove.Count;
            this.gridApproveHistory.DataSource = lstLeaveApprove;
            this.gridApproveHistory.DataBind();
        }

        /// <summary>
        /// 设置面板状态
        /// </summary>
        private void SetPanelState()
        {
            if (string.IsNullOrEmpty(ApproveID))
                return;

            LeaveAppManage _leaveAppManage = new LeaveAppManage();
            LeaveApproveInfo _leaveApproveInfo = _leaveAppManage.GetLeaveApproveInfoByObjectID(ApproveID);
            if (_leaveApproveInfo != null)
            {
                if (_leaveApproveInfo.ApproveResult == 4)
                {
                    btnPass.Enabled = false;
                }
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
                LeaveAppManage leaveAppManage = new LeaveAppManage();
                LeaveApproveInfo _approveInfo = leaveAppManage.GetLeaveApproveInfoByObjectID(ApproveID);
                int result = 3;
                if (_approveInfo != null)
                {
                    LeaveInfo _leaveInfo = leaveAppManage.GetLeaveInfoByObjectID(_approveInfo.LeaveId.ToString());

                    // 设置归档信息.
                    _approveInfo.ApproveResult = 4;
                    _approveInfo.ApproveTime = DateTime.Now;
                    leaveAppManage.UpdateLeaveApprove(_approveInfo);

                    List<LeaveApproveInfo> lstLeaveApproveInfo = leaveAppManage.GetLeaveApprovesByCondition("LeaveID='" + _leaveInfo.ObjectId.ToString()
                        + "' and (ApproveResult = 1 or ApproveResult = 2) order by ApproveTime desc");
                    if (lstLeaveApproveInfo.Count > 0)
                    {
                        // 设置申请单信息.
                        if (lstLeaveApproveInfo[0].ApproveResult == 1)
                        {
                            _leaveInfo.State = 2;
                        }
                        else
                        {
                            _leaveInfo.State = 3;
                        }

                        result = leaveAppManage.UpdateLeaveInfo(_leaveInfo);
                    }
                }

                if (result == -1)
                {
                    this.btnClose_Click(null, null);
                }
                else
                {
                    Alert.Show("确认归档失败!");
                }
            }
        }

        /// <summary>
        /// 确认归档
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
                    case "-1":
                        e.Values[2] = "起草";
                        break;
                    case "0":
                        e.Values[2] = "待审批";
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