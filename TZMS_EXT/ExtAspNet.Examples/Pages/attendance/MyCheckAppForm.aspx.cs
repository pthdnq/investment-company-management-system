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
    public partial class MyCheckAppForm : BasePage
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
        /// UserID
        /// </summary>
        public string UserID
        {
            get
            {
                if (ViewState["UserID"] == null)
                {
                    return null;
                }
                return ViewState["UserID"].ToString();
            }

            set
            {
                ViewState["UserID"] = value;
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
                UserID = Request.QueryString["UserID"];
                ApproveID = Request.QueryString["LeaveApproveID"];

                BindNext();
                BindApproveUser();
                BindLeaveInfo();
                BindApproveHistory();
            }
        }

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
        /// 绑定审批执行人
        /// </summary>
        private void BindApproveUser()
        {
            foreach (UserInfo item in CurrentChecker)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
            }

            ddlstApproveUser.SelectedIndex = 0;
        }

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
                lblAppDate.Text = _leaveInfo.WriteTime.ToString("yyyy年MM月dd日 hh:mm:ss");
                lblStartTime.Text = _leaveInfo.StartTime.ToLongDateString();
                lblStopTime.Text = _leaveInfo.StopTime.ToLongDateString();
                lblLeaveType.Text = _leaveInfo.Type;
                taaLeaveReason.Text = _leaveInfo.Reason;
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
            strCondition.Append(" and ApproveTime <> '1900-01-01 12:00:00.000'");
            List<LeaveApproveInfo> lstLeaveApprove = new LeaveAppManage().GetLeaveApprovesByCondition(strCondition.ToString());

            lstLeaveApprove.Sort(delegate(LeaveApproveInfo x, LeaveApproveInfo y) { return DateTime.Compare(y.ApproveTime, x.ApproveTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstLeaveApprove.Count;
            gridApproveHistory.PageSize = PageCounts;
            int currentIndex = gridApproveHistory.PageIndex;

            // 计算当前页面显示行数据
            if (lstLeaveApprove.Count > gridApproveHistory.PageSize)
            {
                if (lstLeaveApprove.Count > (currentIndex + 1) * gridApproveHistory.PageSize)
                {
                    lstLeaveApprove.RemoveRange((currentIndex + 1) * gridApproveHistory.PageSize, lstLeaveApprove.Count - (currentIndex + 1) * gridApproveHistory.PageSize);
                }
                lstLeaveApprove.RemoveRange(0, currentIndex * gridApproveHistory.PageSize);
            }
            this.gridApproveHistory.DataSource = lstLeaveApprove;
            this.gridApproveHistory.DataBind();
        }

        /// <summary>
        /// 审批历史翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApproveHistory_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridApproveHistory.PageIndex = e.NewPageIndex;
            BindApproveHistory();
        }

        /// <summary>
        /// 审批历史数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApproveHistory_RowDataBound(object sender, GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                switch (e.Values[2].ToString())
                {
                    case "0":
                        e.Values[2] = "待审批";
                        break;
                    case "1":
                        e.Values[2] = "通过";
                        break;
                    case "2":
                        e.Values[2] = "打回修改";
                        break;
                    case "3":
                        e.Values[2] = "归档";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 下一步下拉框变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstNext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstNext.SelectedIndex == 1)
            {
                ddlstApproveUser.Hidden = true;
            }
            else
            {
                ddlstApproveUser.Hidden = false;
            }
        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 通过审批事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            LeaveAppManage _leaveAppManage = new LeaveAppManage();

            // 更新申请表.
            LeaveInfo _leaveInfo = _leaveAppManage.GetLeaveInfoByObjectID(LeaveID);
            if (ddlstNext.SelectedText == "审批")
            {
                _leaveInfo.ApproverId = new Guid(ddlstApproveUser.SelectedValue);
            }
            else if (ddlstNext.SelectedText == "归档")
            {
                _leaveInfo.State = short.Parse("2");
            }
            int result = _leaveAppManage.UpdateLeaveInfo(_leaveInfo);

            // 更新请假申请流程表.
            LeaveApproveInfo _leaveApproveInfo = _leaveAppManage.GetLeaveApproveInfoByObjectID(ApproveID);
            _leaveApproveInfo.ApproveTime = DateTime.Now;
            if (ddlstNext.SelectedText == "审批")
            {
                _leaveApproveInfo.ApproveResult = short.Parse("1");
            }
            else if (ddlstNext.SelectedText == "归档")
            {
                _leaveApproveInfo.ApproveResult = short.Parse("3");
            }

            _leaveApproveInfo.ApproveComment = string.IsNullOrEmpty(taaApproveComment.Text.Trim()) ? "同意" : taaApproveComment.Text.Trim();
            _leaveAppManage.UpdateLeaveApprove(_leaveApproveInfo);

            // 插入新的记录到流程申请表.
            if (ddlstNext.SelectedText == "审批")
            {
                LeaveApproveInfo _newLeaveApproveInfo = new LeaveApproveInfo();
                _newLeaveApproveInfo.ObjectId = Guid.NewGuid();
                _newLeaveApproveInfo.LeaveId = _leaveInfo.ObjectId;
                _newLeaveApproveInfo.ApproverId = _leaveInfo.ApproverId;
                _newLeaveApproveInfo.ApproverName = ddlstApproveUser.SelectedText;
                _newLeaveApproveInfo.ApproveResult = short.Parse("0");
                _leaveAppManage.AddNewLeaveApprove(_newLeaveApproveInfo);
            }

            if (result == -1)
            {
                Alert.Show(ddlstNext.SelectedText + "成功!");
            }
            else
            {
                Alert.Show(ddlstNext.SelectedText + "失败!");
            }
        }

        /// <summary>
        /// 打回申请事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefuse_Click(object sender, EventArgs e)
        {
            LeaveAppManage _leaveAppManage = new LeaveAppManage();

            // 更新申请表.
            LeaveInfo _leaveInfo = _leaveAppManage.GetLeaveInfoByObjectID(LeaveID);
            _leaveInfo.State = short.Parse("3");
            int result = _leaveAppManage.UpdateLeaveInfo(_leaveInfo);

            // 更新请假申请流程表.
            LeaveApproveInfo _leaveApproveInfo = _leaveAppManage.GetLeaveApproveInfoByObjectID(ApproveID);
            _leaveApproveInfo.ApproveTime = DateTime.Now;
            _leaveApproveInfo.ApproveResult = short.Parse("2");
            _leaveApproveInfo.ApproveComment = string.IsNullOrEmpty(taaApproveComment.Text.Trim()) ? "打回" : taaApproveComment.Text.Trim();
            _leaveAppManage.UpdateLeaveApprove(_leaveApproveInfo);

            if (result == -1)
            {
                Alert.Show("打回成功!");
            }
            else
            {
                Alert.Show("打回失败!");
            }
        }
    }
}