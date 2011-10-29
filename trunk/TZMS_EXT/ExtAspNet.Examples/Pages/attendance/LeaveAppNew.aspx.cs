using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;

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
                            lblAppDate.Text = DateTime.Now.ToLongDateString();

                            // 绑定下一步.
                            BindNext();
                            // 绑定审批人.
                            BindApproveUser();
                            // 绑定请假类型.
                            BindApproveState();
                        }
                        break;
                    case "View":
                        break;
                    case "Edit":
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
            ddlstNext.Items.Add(new ExtAspNet.ListItem("归档", "1"));

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
                _leaveInfo.AccountNo = CurrentUser.AccountNo;
                _leaveInfo.JobNo = CurrentUser.JobNo;
                _leaveInfo.Name = CurrentUser.Name;
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
                _leaveInfo.State = short.Parse(ddlstNext.SelectedValue);

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
            }
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

            //if (DatePicker2.SelectedDate is DateTime)
            //{
            //    DateTime dt = DateTime.Parse(DatePicker2.SelectedDate.ToString());
            //    Alert.Show(dt.ToShortDateString());
            //}

        }
    }
}