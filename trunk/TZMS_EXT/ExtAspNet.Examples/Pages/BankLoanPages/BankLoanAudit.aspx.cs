using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.BankLoanPages
{
    /// <summary>
    /// BankLoanAudit
    /// </summary>
    public partial class BankLoanAudit : BasePage
    {
        #region 属性
        /// <summary>
        /// ObjectID
        /// </summary>
        public string ObjectID
        {
            get
            {
                if (ViewState["ObjectID"] == null)
                {
                    return null;
                }

                return ViewState["ObjectID"].ToString();
            }
            set
            {
                ViewState["ObjectID"] = value;
            }
        }
        #endregion

        #region 页面加载及数据初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            InitControl();

            if (!IsPostBack)
            {
                string strID = Request.QueryString["ID"];
                ObjectID = strID;

                bindUserInterface(strID);


                // 绑定审批人.
                ApproveUser();
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }

        /// <summary>
        /// 绑定指定用户ID的数据到界面.
        /// </summary>
        /// <param name="strUserID">用户ID</param>
        private void bindUserInterface(string strUserID)
        {
            if (string.IsNullOrEmpty(strUserID))
            {
                return;
            }
            BankLoanInfo _Info = new BankLoanManage().GetUserByObjectID(ObjectID);
            //UserInfo user = new UserManage().GetUserByObjectID(_Info.NextOperaterId.ToString());
            if (_Info.LoanAmount > 3000000 && !CurrentRoles.Contains(RoleType.DSZ))
            {
                //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
                BindNext(false);
             //   HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。";
            }
            else
            {
                BindNext(false);
            } 

            this.tbCollateralCompany.Text = _Info.CollateralCompany;
            this.tbCustomerName.Text = _Info.CustomerName;
            this.tbDownPayment.Text = _Info.DownPayment.ToString();
            this.tbLoanAmount.Text = _Info.LoanAmount.ToString();
            this.tbLoanCompany.Text = _Info.LoanCompany;
            this.tbLoanFee.Text = _Info.LoanFee.ToString();
            this.tbRemark.Text = _Info.Remark;
            this.taContact.Text = _Info.Contact;
         
            this.dpSignDate.SelectedDate = _Info.SignDate;
             
        }

        #endregion

        #region 页面及控件事件
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDismissed_Click(object sender, EventArgs e)
        {
            //不同意，打回
            saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ddlstNext.SelectedValue.Equals(0))
            {
                //同意，继续审核
                saveInfo(3);
            }
            else
            {
                //待会计审核/支付确认
                saveInfo(4);
            }
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存信息.
        /// </summary>
        private void saveInfo(int status)
        {
            BankLoanManage _Manage = new BankLoanManage();
            BankLoanInfo _Info = _Manage.GetUserByObjectID(ObjectID);

            _Info.Status = status;
            _Info.AuditOpinion = this.taAuditOpinion.Text.Trim();

            //下一步操作
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            _Info.SubmitTime = DateTime.Now;


            int result = 3;
            result = _Manage.Update(_Info);
            if (result == -1)
            {
                Alert.Show("更新成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("更新失败!");
            }
        }


        /// <summary>
        /// 绑定下一步
        /// </summary>
        private void BindNext(bool needAccountant)
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            if (needAccountant)
            {
                ddlstNext.Items.Add(new ExtAspNet.ListItem("会计审核", "1"));
            }
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
        #endregion
    }
}