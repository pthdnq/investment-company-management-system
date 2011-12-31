using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Text;
using System.Data;
using Com.iFlytek.OA.MUDCommon;

namespace TZMS.Web
{
    public partial class LeaveAppNew : BasePage
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
        public string LeaveAppID
        {
            get
            {
                if (ViewState["LeaveAppID"] == null)
                {
                    return null;
                }

                return ViewState["LeaveAppID"].ToString();
            }
            set
            {
                ViewState["LeaveAppID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 获取从Request传递过来的值.
                string strOperatorType = Request.QueryString["Type"];
                string strLeaveAppID = Request.QueryString["LeaveID"];

                MUDAttachment.SystemName = "病假";
                MUDAttachment.AttributeName = "病假属性";

                switch (strOperatorType)
                {
                    case "Add":
                        {
                            OperatorType = strOperatorType;
                            LeaveAppID = Guid.NewGuid().ToString();
                            MUDAttachment.RecordID = LeaveAppID;
                            lblName.Text = CurrentUser.Name;
                            lblAppDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm");

                            tabApproveHistory.Hidden = true;

                            // 绑定下一步.
                            BindNext();
                            // 绑定审批人.
                            BindApproveUser();
                            // 绑定请假类型.
                            BindApproveState();
                        }
                        break;
                    case "View":
                        {
                            OperatorType = strOperatorType;
                            LeaveAppID = strLeaveAppID;
                            MUDAttachment.RecordID = LeaveAppID;
                            MUDAttachment.ShowAddBtn = "false";
                            MUDAttachment.ShowDelBtn = "false";

                            // 绑定下一步.
                            BindNext();
                            // 绑定审批人.
                            BindApproveUser();
                            // 绑定请假类型.
                            BindApproveState();
                            // 绑定请假申请单信息.
                            BindLeaveInfo();
                            // 绑定审批历史.
                            BindHistory();
                            // 禁用所有控件.
                            DisableAllControls();
                        }
                        break;
                    case "Edit":
                        {
                            OperatorType = strOperatorType;
                            LeaveAppID = strLeaveAppID;
                            MUDAttachment.RecordID = LeaveAppID;

                            // 绑定下一步.
                            BindNext();
                            // 绑定审批人.
                            BindApproveUser();
                            // 绑定请假类型.
                            BindApproveState();
                            // 绑定请假申请单信息.
                            BindLeaveInfo();
                            // 绑定审批历史.
                            BindHistory();
                        }
                        break;

                    default:
                        break;
                }

                if (ddlstApproveUser.SelectedItem == null)
                {
                    Alert.Show("您的“执行人”为空，请在我的首页设置我的审批人！");
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
            //foreach (RoleType roleType in CurrentRoles)
            //{
            //    if (roleType == RoleType.KQGD)
            //    {
            //        ddlstNext.Items.Add(new ExtAspNet.ListItem("归档", "1"));
            //        break;
            //    }
            //}

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
        /// 绑定请假类型
        /// </summary>
        private void BindApproveState()
        {
            AttedType[] arrayAttedType = (AttedType[])Enum.GetValues(typeof(AttedType));
            foreach (AttedType item in arrayAttedType)
            {
                if (item == AttedType.TX || item == AttedType.KG)
                    continue;
                ddlstLeaveType.Items.Add(new ExtAspNet.ListItem(ConvertAttedTypeToString(item), ((int)item).ToString()));

                // 设置事假为默认类型.
                if (item == AttedType.SJ)
                {
                    ddlstLeaveType.Items[ddlstLeaveType.Items.Count - 1].Selected = true;
                }
            }
        }

        /// <summary>
        /// 绑定请假申请单信息
        /// </summary>
        private void BindLeaveInfo()
        {
            LeaveAppManage _leaveManage = new LeaveAppManage();
            LeaveInfo _leaveInfo = _leaveManage.GetLeaveInfoByObjectID(LeaveAppID);

            if (_leaveInfo != null)
            {
                lblName.Text = _leaveInfo.Name;
                lblAppDate.Text = _leaveInfo.WriteTime.ToString("yyyy-MM-dd HH:mm");
                dpkStartTime.SelectedDate = _leaveInfo.StartTime;
                ddlstStartHour.SelectedValue = _leaveInfo.StartTime.Hour.ToString();
                dpkEndTime.SelectedDate = _leaveInfo.StopTime;
                ddlstEndHour.SelectedValue = _leaveInfo.StopTime.Hour.ToString();
                int typeValue = (int)ConvertStringToAttedType(_leaveInfo.Type);
                ddlstLeaveType.SelectedValue = typeValue.ToString();
                taaLeaveReason.Text = _leaveInfo.Reason;
                if (ddlstLeaveType.SelectedText == "病假")
                {
                    ContentPanel1.Hidden = false;
                    //MUDAttachment.Visible = true;
                }

                // 查找最早的审批记录.
                List<LeaveApproveInfo> lstApprove = _leaveManage.GetLeaveApprovesByCondition(" LeaveID = '" + _leaveInfo.ObjectId.ToString() +
                                    "' and ApproverID <> '" + _leaveInfo.ObjectId.ToString() + "'");
                if (lstApprove.Count == 1)
                {
                    ddlstApproveUser.SelectedValue = lstApprove[0].ApproverId.ToString();
                }
                else
                {
                    lstApprove.Sort(delegate(LeaveApproveInfo x, LeaveApproveInfo y) { return DateTime.Compare(x.ApproveTime, y.ApproveTime); });
                    foreach (var item in lstApprove)
                    {
                        if (DateTime.Compare(item.ApproveTime, ACommonInfo.DBEmptyDate) != 0)
                        {
                            ddlstApproveUser.SelectedValue = item.ApproverId.ToString();
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 禁用所有控件
        /// </summary>
        private void DisableAllControls()
        {
            // 禁用所有控件以及所有的状态.
            ddlstNext.Required = false;
            ddlstNext.ShowRedStar = false;
            ddlstNext.Enabled = false;

            ddlstApproveUser.Required = false;
            ddlstApproveUser.ShowRedStar = false;
            ddlstApproveUser.Enabled = false;

            dpkStartTime.Required = false;
            dpkStartTime.ShowRedStar = false;
            dpkStartTime.Enabled = false;
            ddlstStartHour.Enabled = false;

            dpkEndTime.Required = false;
            dpkEndTime.ShowRedStar = false;
            dpkEndTime.Enabled = false;
            ddlstEndHour.Enabled = false;

            ddlstLeaveType.Required = false;
            ddlstLeaveType.ShowRedStar = false;
            ddlstLeaveType.Enabled = false;

            taaLeaveReason.Required = false;
            taaLeaveReason.ShowRedStar = false;
            taaLeaveReason.Enabled = false;

            btnSave.Enabled = false;
        }

        /// <summary>
        /// 将请假类型由枚举值转换为字符串.
        /// </summary>
        /// <param name="attedType">请假类型</param>
        /// <returns>类型名称</returns>
        private string ConvertAttedTypeToString(AttedType attedType)
        {
            string strAttedType = string.Empty;

            switch (attedType)
            {
                case AttedType.BJ:
                    strAttedType = "病假";
                    break;
                case AttedType.CJ:
                    strAttedType = "产假";
                    break;
                case AttedType.CJJ:
                    strAttedType = "产检假";
                    break;
                case AttedType.GJ:
                    strAttedType = "工伤假";
                    break;
                case AttedType.HJ:
                    strAttedType = "婚假";
                    break;
                case AttedType.KG:
                    strAttedType = "旷工";
                    break;
                case AttedType.NXJ:
                    strAttedType = "年休假";
                    break;
                case AttedType.SAJ:
                    strAttedType = "丧假";
                    break;
                case AttedType.SJ:
                    strAttedType = "事假";
                    break;
                case AttedType.TX:
                    strAttedType = "调休";
                    break;
                case AttedType.QT:
                    strAttedType = "其他";
                    break;
            }

            return strAttedType;
        }

        /// <summary>
        /// 将字符串转换成枚举值
        /// </summary>
        /// <param name="strType">字符串</param>
        /// <returns>枚举值</returns>
        public AttedType ConvertStringToAttedType(string strType)
        {
            if (!string.IsNullOrEmpty(strType))
            {
                switch (strType)
                {
                    case "病假":
                        return AttedType.BJ;
                    case "产假":
                        return AttedType.CJ;
                    case "产检假":
                        return AttedType.CJJ;
                    case "工伤假":
                        return AttedType.GJ;
                    case "婚假":
                        return AttedType.HJ;
                    case "旷工":
                        return AttedType.KG;
                    case "年休假":
                        return AttedType.NXJ;
                    case "丧假":
                        return AttedType.SAJ;
                    case "事假":
                        return AttedType.SJ;
                    case "调休":
                        return AttedType.TX;
                    case "其他":
                        return AttedType.QT;
                }
            }

            return AttedType.BJ;
        }

        /// <summary>
        /// 保存信息
        /// </summary>
        private void SaveLeaveInfo()
        {
            if (CurrentUser == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(OperatorType))
            {
                return;
            }


            LeaveInfo _leaveInfo = null;
            int result = 3;
            LeaveAppManage _leaveAppManage = new LeaveAppManage();

            if (OperatorType == "Add")
            {
                // 创建新的请假申请单信息.
                _leaveInfo = new LeaveInfo();
                _leaveInfo.ObjectId = new Guid(LeaveAppID);
                _leaveInfo.UserObjectId = CurrentUser.ObjectId;
                _leaveInfo.AccountNo = CurrentUser.AccountNo;
                _leaveInfo.JobNo = CurrentUser.JobNo;
                _leaveInfo.Name = CurrentUser.Name;
                _leaveInfo.Dept = CurrentUser.Dept;
                _leaveInfo.WriteTime = DateTime.Now;
                if (dpkStartTime.SelectedDate is DateTime)
                {
                    _leaveInfo.StartTime = (Convert.ToDateTime(dpkStartTime.SelectedDate)).AddHours(Convert.ToInt32(ddlstStartHour.SelectedValue));
                }
                if (dpkEndTime.SelectedDate is DateTime)
                {
                    _leaveInfo.StopTime = Convert.ToDateTime(dpkEndTime.SelectedDate).AddHours(Convert.ToInt32(ddlstEndHour.SelectedValue));
                }
                _leaveInfo.ApproverId = new Guid(ddlstApproveUser.SelectedValue);
                _leaveInfo.Type = ddlstLeaveType.SelectedText;

                //_leaveInfo.State = short.Parse(ddlstNext.SelectedValue);
                _leaveInfo.State = 1;
                _leaveInfo.Reason = taaLeaveReason.Text.Trim();
                _leaveInfo.IsDelete = false;

                result = _leaveAppManage.AddNewLeaveInfo(_leaveInfo);

                // 添加到请假流程表.
                LeaveApproveInfo _draftApproveInfo = new LeaveApproveInfo();
                _draftApproveInfo.ObjectId = Guid.NewGuid();
                _draftApproveInfo.LeaveId = _leaveInfo.ObjectId;
                _draftApproveInfo.ApproverId = _leaveInfo.ObjectId;
                _draftApproveInfo.ApproverName = _leaveInfo.Name;
                _draftApproveInfo.ApproveTime = _leaveInfo.WriteTime;
                _draftApproveInfo.ApproveResult = -1;

                _leaveAppManage.AddNewLeaveApprove(_draftApproveInfo);

                // 添加到请假流程表.
                LeaveApproveInfo _leaveApproveInfo = new LeaveApproveInfo();
                _leaveApproveInfo.ObjectId = Guid.NewGuid();
                _leaveApproveInfo.LeaveId = _leaveInfo.ObjectId;
                _leaveApproveInfo.ApproverId = _leaveInfo.ApproverId;
                _leaveApproveInfo.ApproverName = ddlstApproveUser.SelectedText;
                _leaveApproveInfo.ApproveResult = 0;

                _leaveAppManage.AddNewLeaveApprove(_leaveApproveInfo);

                if (result == -1)
                {
                    //Alert.Show("申请提交成功!");

                    this.btnClose_Click(null, null);

                    //// 设置页面各按钮的状态.
                    //LeaveAppID = _leaveInfo.ObjectId.ToString();
                    //btnSave.Enabled = false;
                    //tabApproveHistory.Hidden = false;

                    //MUDAttachment.ShowAddBtn = "false";
                    //MUDAttachment.ShowDelBtn = "false";

                    //BindHistory();
                }
                else
                {
                    Alert.Show("申请提交失败!");
                }
            }

            if (OperatorType == "Edit")
            {
                _leaveInfo = _leaveAppManage.GetLeaveInfoByObjectID(LeaveAppID);

                // 更新请假申请表.
                _leaveInfo.WriteTime = DateTime.Now;
                if (dpkStartTime.SelectedDate is DateTime)
                {
                    _leaveInfo.StartTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
                }
                if (dpkEndTime.SelectedDate is DateTime)
                {
                    _leaveInfo.StopTime = Convert.ToDateTime(dpkEndTime.SelectedDate);
                }
                _leaveInfo.ApproverId = new Guid(ddlstApproveUser.SelectedValue);
                _leaveInfo.Type = ddlstLeaveType.SelectedText;
                _leaveInfo.State = 1;
                _leaveInfo.Reason = taaLeaveReason.Text.Trim();
                _leaveInfo.IsDelete = false;

                result = _leaveAppManage.UpdateLeaveInfo(_leaveInfo);

                // 添加到请假流程表.
                LeaveApproveInfo _leaveApproveInfo = new LeaveApproveInfo();
                _leaveApproveInfo.ObjectId = Guid.NewGuid();
                _leaveApproveInfo.LeaveId = _leaveInfo.ObjectId;
                _leaveApproveInfo.ApproverId = _leaveInfo.ApproverId;
                _leaveApproveInfo.ApproverName = ddlstApproveUser.SelectedText;
                _leaveApproveInfo.ApproveResult = 0;

                _leaveAppManage.AddNewLeaveApprove(_leaveApproveInfo);

                if (result == -1)
                {
                    //Alert.Show("申请提交成功!");

                    this.btnClose_Click(null, null);

                    //// 设置页面各按钮的状态.
                    //LeaveAppID = _leaveInfo.ObjectId.ToString();
                    //btnSave.Enabled = false;
                    //tabApproveHistory.Hidden = false;

                    //MUDAttachment.ShowAddBtn = "false";
                    //MUDAttachment.ShowDelBtn = "false";

                    //BindHistory();
                }
                else
                {
                    Alert.Show("申请提交失败!");
                }
            }
        }

        /// <summary>
        /// 绑定审批历史
        /// </summary>
        private void BindHistory()
        {
            if (LeaveAppID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("LeaveID = '" + LeaveAppID + "'");
            strCondition.Append(" and ApproveResult <> 0 and ApproveResult <> 3");
            List<LeaveApproveInfo> lstLeaveApprove = new LeaveAppManage().GetLeaveApprovesByCondition(strCondition.ToString());

            lstLeaveApprove.Sort(delegate(LeaveApproveInfo x, LeaveApproveInfo y) { return DateTime.Compare(y.ApproveTime, x.ApproveTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstLeaveApprove.Count;
            this.gridApproveHistory.DataSource = lstLeaveApprove;
            this.gridApproveHistory.DataBind();
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 发送申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(Convert.ToDateTime(dpkStartTime.SelectedDate).AddHours(Convert.ToInt32(ddlstStartHour.SelectedValue)),
                Convert.ToDateTime(dpkEndTime.SelectedDate).AddHours(Convert.ToInt32(ddlstEndHour.SelectedValue))) >= 0)
            {
                Alert.Show("结束时间不可小于或等于开始时间!");
                return;
            }

            SaveLeaveInfo();
        }

        /// <summary>
        /// 页面关闭事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 下一步变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstNext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstNext.SelectedIndex == 0)
            {
                ddlstApproveUser.Hidden = false;
            }
            else
            {
                ddlstApproveUser.Hidden = true;
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
                e.Values[1] = DateTime.Parse(e.Values[1].ToString()).ToString("yyyy-MM-dd hh:mm");

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
        /// 请假类型选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstLeaveType.SelectedText == "病假")
            {
                ContentPanel1.Hidden = false;
                // MUDAttachment.Visible = true;
            }
            else
            {
                ContentPanel1.Hidden = true;
                // MUDAttachment.Visible = false;
            }
        }

        #endregion
    }
}