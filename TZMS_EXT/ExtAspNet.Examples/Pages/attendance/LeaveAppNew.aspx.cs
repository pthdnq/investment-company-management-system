﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Text;
using System.Data;

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

                switch (strOperatorType)
                {
                    case "Add":
                        {
                            OperatorType = strOperatorType;
                            lblName.Text = CurrentUser.Name;
                            lblAppDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss");

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
                lblAppDate.Text = _leaveInfo.WriteTime.ToString("yyyy年MM月dd日 hh:mm:ss");
                dpkStartTime.SelectedDate = _leaveInfo.StartTime;
                dpkEndTime.SelectedDate = _leaveInfo.StopTime;
                int typeValue = (int)ConvertStringToAttedType(_leaveInfo.Type);
                ddlstLeaveType.SelectedValue = typeValue.ToString();
                taaLeaveReason.Text = _leaveInfo.Reason;

                // 查找最早的审批记录.
                CommSelect _commSelect = new CommSelect();
                ComHelp _comHelp = new ComHelp();
                _comHelp.TableName = "LeaveApprove";
                _comHelp.SelectList = "top 1 ApproverID, ApproverName";
                _comHelp.SearchCondition = "LeaveID = '" + _leaveInfo.ObjectId.ToString() + "'";
                _comHelp.PageSize = PageCounts;
                _comHelp.PageIndex = 0;
                _comHelp.OrderExpression = "ApproveTime desc";

                DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
                if (dtbLeaveApproves.Rows.Count > 0)
                {
                    ddlstApproveUser.SelectedValue = dtbLeaveApproves.Rows[0]["ApproverID"].ToString();
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

            dpkEndTime.Required = false;
            dpkEndTime.ShowRedStar = false;
            dpkEndTime.Enabled = false;

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
                _leaveInfo.ObjectId = Guid.NewGuid();
                _leaveInfo.UserObjectId = CurrentUser.ObjectId;
                _leaveInfo.AccountNo = CurrentUser.AccountNo;
                _leaveInfo.JobNo = CurrentUser.JobNo;
                _leaveInfo.Name = CurrentUser.Name;
                _leaveInfo.Dept = CurrentUser.Dept;
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
                //_leaveInfo.State = short.Parse(ddlstNext.SelectedValue);
                _leaveInfo.State = 1;
                _leaveInfo.Reason = taaLeaveReason.Text.Trim();
                _leaveInfo.IsDelete = false;

                result = _leaveAppManage.AddNewLeaveInfo(_leaveInfo);

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
                    Alert.Show("申请提交成功!");
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
                    Alert.Show("申请提交成功!");
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

        #endregion


        /// <summary>
        /// 发送申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveLeaveInfo();
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
        /// 审批历史翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApproveHistory_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridApproveHistory.PageIndex = e.NewPageIndex;
            BindHistory();
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
    }
}