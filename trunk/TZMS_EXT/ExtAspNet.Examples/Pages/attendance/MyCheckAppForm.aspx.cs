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

                MUDAttachment.ShowAddBtn = "false";
                MUDAttachment.ShowDelBtn = "false";

                BindNext();
                BindApproveUser();
                BindLeaveInfo();
                BindApproveHistory();
                SetPanelState();
                if (string.IsNullOrEmpty(strArchiver))
                {
                    this.btnPass.Enabled = false;
                    this.btnRefuse.Enabled = false;
                    this.ddlstNext.Enabled = false;
                    this.ddlstApproveUser.Enabled = false;
                    Alert.Show("请管理员配置行政归档员!");
                }
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
                //lblHours.Text = ((TimeSpan)(_leaveInfo.StopTime - _leaveInfo.StartTime)).TotalHours.ToString() + "小时";
                lblHours.Text = _leaveInfo.LeaveHours + "小时";
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
                if (_leaveApproveInfo.ApproveResult != 0)
                {
                    btnPass.Hidden = true;
                    btnRefuse.Hidden = true;
                    mainForm2.Hidden = true;
                }
            }
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

        /// <summary>
        /// 下一步下拉框变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstNext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstNext.SelectedIndex == 1)
            {
                BindArchiver();
            }
            else
            {
                BindApproveUser();
            }
        }

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
        /// 通过审批事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            LeaveAppManage _leaveAppManage = new LeaveAppManage();

            // 更新申请表.
            LeaveInfo _leaveInfo = _leaveAppManage.GetLeaveInfoByObjectID(LeaveID);
            //if (ddlstNext.SelectedText == "审批")
            //{
            _leaveInfo.ApproverId = new Guid(ddlstApproveUser.SelectedValue);
            //}
            //else if (ddlstNext.SelectedText == "归档")
            //{
            //    _leaveInfo.State = short.Parse("2");
            //}
            int result = _leaveAppManage.UpdateLeaveInfo(_leaveInfo);

            // 更新请假申请流程表.
            LeaveApproveInfo _leaveApproveInfo = _leaveAppManage.GetLeaveApproveInfoByObjectID(ApproveID);
            _leaveApproveInfo.ApproveTime = DateTime.Now;
            //if (ddlstNext.SelectedText == "审批")
            //{
            _leaveApproveInfo.ApproveResult = short.Parse("1");
            //}
            //else if (ddlstNext.SelectedText == "归档")
            //{
            //    _leaveApproveInfo.ApproveResult = short.Parse("3");
            //}

            _leaveApproveInfo.ApproveComment = string.IsNullOrEmpty(taaApproveComment.Text.Trim()) ? "同意" : taaApproveComment.Text.Trim();
            _leaveAppManage.UpdateLeaveApprove(_leaveApproveInfo);
            LeaveApproveInfo _newLeaveApproveInfo = new LeaveApproveInfo();
            // 插入新的记录到流程申请表.
            if (ddlstNext.SelectedText == "审批")
            {
                //LeaveApproveInfo _newLeaveApproveInfo = new LeaveApproveInfo();
                _newLeaveApproveInfo.ObjectId = Guid.NewGuid();
                _newLeaveApproveInfo.LeaveId = _leaveInfo.ObjectId;
                _newLeaveApproveInfo.ApproverId = _leaveInfo.ApproverId;
                _newLeaveApproveInfo.ApproverName = ddlstApproveUser.SelectedText;
                _newLeaveApproveInfo.ApproveResult = short.Parse("0");
                _leaveAppManage.AddNewLeaveApprove(_newLeaveApproveInfo);
            }
            else if (ddlstNext.SelectedText == "归档")
            {
                //LeaveApproveInfo _newLeaveApproveInfo = new LeaveApproveInfo();
                _newLeaveApproveInfo.ObjectId = Guid.NewGuid();
                _newLeaveApproveInfo.LeaveId = _leaveInfo.ObjectId;
                _newLeaveApproveInfo.ApproverId = _leaveInfo.ApproverId;
                _newLeaveApproveInfo.ApproverName = ddlstApproveUser.SelectedText;
                _newLeaveApproveInfo.ApproveResult = short.Parse("3");
                _leaveAppManage.AddNewLeaveApprove(_newLeaveApproveInfo);
            }

            if (result == -1)
            {
                //Alert.Show( "审批成功(同意)!");
                //btnPass.Enabled = false;
                //btnRefuse.Enabled = false;
                //BindApproveHistory();

                if (ddlstNext.SelectedText == "审批")
                {
                    CheckMsg(ddlstApproveUser.SelectedValue.Trim(), ddlstApproveUser.SelectedText, "假勤审批");
                }
                if (ddlstNext.SelectedText == "归档")
                {
                    string funBase = string.Empty;
                    if (_leaveInfo.Type == "调休")
                    {
                        funBase = "调休申请";
                    }
                    else
                    {
                        funBase = "请假申请";
                    }
                    GuiDangMsg(ddlstApproveUser.SelectedValue.Trim(), ddlstApproveUser.SelectedText, "请假归档");

                    //ResultMsg(string receiverID, string receiverName, funBase,"");
                }
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("审批失败(同意)!");
            }
        }

        /// <summary>
        /// 打回申请事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefuse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(taaApproveComment.Text.Trim()))
            {
                Alert.Show("审批意见不可为空!");
                return;
            }
            if (string.IsNullOrEmpty(strArchiver))
            {
                Alert.Show("请管理员配置行政归档员!");
                return;
            }
            LeaveAppManage _leaveAppManage = new LeaveAppManage();

            // 更新申请表.
            LeaveInfo _leaveInfo = _leaveAppManage.GetLeaveInfoByObjectID(LeaveID);
            UserInfo _archiveUser = new UserManage().GetUserByObjectID(strArchiver);
            if (_archiveUser == null)
            {
                Alert.Show("请管理员检查行政归档员是否存在!");
                return;
            }
            // _leaveInfo.State = short.Parse("3");
            _leaveInfo.ApproverId = _archiveUser.ObjectId;
            int result = _leaveAppManage.UpdateLeaveInfo(_leaveInfo);

            // 更新请假申请流程表.
            LeaveApproveInfo _leaveApproveInfo = _leaveAppManage.GetLeaveApproveInfoByObjectID(ApproveID);
            _leaveApproveInfo.ApproveTime = DateTime.Now;
            _leaveApproveInfo.ApproveResult = short.Parse("2");
            _leaveApproveInfo.ApproveComment = string.IsNullOrEmpty(taaApproveComment.Text.Trim()) ? "不同意" : taaApproveComment.Text.Trim();
            _leaveAppManage.UpdateLeaveApprove(_leaveApproveInfo);

            LeaveApproveInfo _newLeaveApproveInfo = new LeaveApproveInfo();
            _newLeaveApproveInfo.ObjectId = Guid.NewGuid();
            _newLeaveApproveInfo.LeaveId = _leaveInfo.ObjectId;
            _newLeaveApproveInfo.ApproverId = _archiveUser.ObjectId;
            _newLeaveApproveInfo.ApproverName = _archiveUser.Name;
            _newLeaveApproveInfo.ApproveResult = short.Parse("3");
            _leaveAppManage.AddNewLeaveApprove(_newLeaveApproveInfo);

            if (result == -1)
            {
                //Alert.Show("审批成功(不同意)!");
                //btnPass.Enabled = false;
                //btnRefuse.Enabled = false;
                //BindApproveHistory();
                string funBase = string.Empty;
                if (_leaveInfo.Type == "调休")
                {
                    funBase = "调休申请";
                }
                else
                {
                    funBase = "请假申请";
                }
                ResultMsg(_leaveInfo.UserObjectId.ToString(), _leaveInfo.Name, funBase, "打回");
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("审批失败(不同意)!");
            }
        }
    }
}