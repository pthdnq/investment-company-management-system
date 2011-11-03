using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using ExtAspNet;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class NewBaoxiaoApply : BasePage
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
        /// 报销单ID
        /// </summary>
        public string BaoxiaoObjectID
        {
            get
            {
                if (ViewState["BaoxiaoObjectID"] == null)
                {
                    return null;
                }

                return ViewState["BaoxiaoObjectID"].ToString();
            }
            set
            {
                ViewState["BaoxiaoObjectID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strOperatorType = Request.QueryString["Type"];
                string strBaoxiaoID = Request.QueryString["ID"];

                switch (strOperatorType)
                {
                    case "Add":
                        {
                            OperatorType = strOperatorType;

                            lblName.Text = CurrentUser.Name;
                            lblAppDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm");

                            // 绑定下一步.
                            BindNext();
                            // 绑定审批人.
                            ApproveUser();
                        }
                        break;
                    case "View":
                        break;
                    case "Edit":
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
        private void ApproveUser()
        {
            foreach (UserInfo user in CurrentChecker)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
            }

            ddlstApproveUser.SelectedIndex = 0;
        }

        /// <summary>
        /// 提交报销申请单
        /// </summary>
        private void SaveBaoxiao()
        {
            if (OperatorType == null)
                return;
            BaoxiaoInfo _baoxiaoInfo = null;
            BaoxiaoManage baoxiaoManage = new BaoxiaoManage();
            if (OperatorType == "Add")
            {
                // 创建报销单实例.
                UserInfo _currentUser = CurrentUser;
                _baoxiaoInfo = new BaoxiaoInfo();
                _baoxiaoInfo.ObjectId = Guid.NewGuid();
                _baoxiaoInfo.UserId = _currentUser.ObjectId;
                _baoxiaoInfo.UserName = _currentUser.Name;
                _baoxiaoInfo.UserJobNo = _currentUser.JobNo;
                _baoxiaoInfo.UserAccountNo = _currentUser.AccountNo;
                _baoxiaoInfo.Dept = _currentUser.Dept;
                _baoxiaoInfo.Sument = taaSument.Text.Trim();
                _baoxiaoInfo.Money = Convert.ToDecimal(tbxMoney.Text.Trim());
                _baoxiaoInfo.Other = taaOther.Text.Trim();
                _baoxiaoInfo.ApplyTime = DateTime.Now;
                _baoxiaoInfo.State = 0;
                _baoxiaoInfo.Isdelete = false;

                // 插入新报销单.
                int result = baoxiaoManage.AddNewBaoxiao(_baoxiaoInfo);

                // 插入起草记录到报销审批流程表.
                BaoxiaoCheckInfo _baoxiaoCheckInfo = new BaoxiaoCheckInfo();
                _baoxiaoCheckInfo.ObjectId = Guid.NewGuid();
                _baoxiaoCheckInfo.CheckerId = _currentUser.ObjectId;
                _baoxiaoCheckInfo.CheckerName = _currentUser.Name;
                _baoxiaoCheckInfo.CheckrDept = _currentUser.Dept;
                _baoxiaoCheckInfo.CheckDateTime = _baoxiaoInfo.ApplyTime;
                _baoxiaoCheckInfo.Checkstate = 0;
                _baoxiaoCheckInfo.CheckOp = "0";
                _baoxiaoCheckInfo.ApplyId = _baoxiaoInfo.ObjectId;

                baoxiaoManage.AddNewBaoxiaoCheck(_baoxiaoCheckInfo);

                // 插入待审批记录到报销审批流程表.
                _baoxiaoCheckInfo = new BaoxiaoCheckInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                _baoxiaoCheckInfo.ObjectId = Guid.NewGuid();
                _baoxiaoCheckInfo.CheckerId = _approveUser.ObjectId;
                _baoxiaoCheckInfo.CheckerName = _approveUser.Name;
                _baoxiaoCheckInfo.CheckrDept = _approveUser.Dept;
                _baoxiaoCheckInfo.CheckDateTime = ACommonInfo.DBEmptyDate;
                _baoxiaoCheckInfo.Checkstate = 0;
                _baoxiaoCheckInfo.CheckOp = "";
                _baoxiaoCheckInfo.ApplyId = _baoxiaoInfo.ObjectId;

                baoxiaoManage.AddNewBaoxiaoCheck(_baoxiaoCheckInfo);

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
        /// 审批历史数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApproveHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {

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
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveBaoxiao();
        }
    }
}