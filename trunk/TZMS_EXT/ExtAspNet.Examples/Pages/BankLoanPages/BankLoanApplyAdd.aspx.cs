using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.BankLoanPages
{
    /// <summary>
    /// bankloanapplyadd
    /// </summary>
    public partial class BankLoanApplyAdd : BasePage
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
                // 绑定下一步.
                BindNext();
                // 绑定审批人.
                ApproveUser();
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
        }

        #endregion

        #region 页面及控件事件
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Decimal.Parse(tbLoanAmount.Text.Replace(BT, "").Trim()) > Common.MaxMoney)
            {
                Alert.Show("贷款金额 整数部分不能超过16位！");
                return;
            }
            if (Decimal.Parse(tbLoanFee.Text.Replace(BT, "").Trim()) > Common.MaxMoney)
            {
                Alert.Show("贷款手续费 整数部分不能超过16位！");
                return;
            }
            saveInfo();
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存信息.
        /// </summary>
        private void saveInfo()
        {
            BankLoanManage manage = new BankLoanManage();
            BankLoanInfo _Info = new BankLoanInfo();

            _Info.ObjectId = Guid.NewGuid();

            _Info.ProjectName = this.tbProjectName.Text.Trim();

            _Info.CustomerName = this.tbCustomerName.Text.Trim();
            _Info.CollateralCompany = this.tbCollateralCompany.Text.Trim();
            _Info.Contact = this.taContact.Text.Trim();

            _Info.LoanAmount = decimal.Parse(this.tbLoanAmount.Text.Replace(BT, "").Trim());
            _Info.DownPayment = decimal.Parse(this.tbDownPayment.Text.Replace(BT, "").Trim());
            _Info.LoanFee = decimal.Parse(this.tbLoanFee.Text.Replace(BT, "").Trim());
            _Info.LoanAmountFlag = "";
            if (tbLoanAmount.Text.Contains(BT))
            {
                _Info.LoanAmountFlag = BT;
            }
            _Info.DownPaymentFlag = "";
            if (tbDownPayment.Text.Contains(BT))
            {
                _Info.DownPaymentFlag = BT;
            }
            _Info.LoanFeeFlag = "";
            if (tbLoanFee.Text.Contains(BT))
            {
                _Info.LoanFeeFlag = BT;
            }

            _Info.SignDate = this.dpSignDate.SelectedDate.Value;
            _Info.LoanCompany = this.tbLoanCompany.Text;

            _Info.Remark = this.tbRemark.Text.Trim();
            _Info.Status = 1;
            //补充申请人及下一步审核人信息

            _Info.CreateTime = DateTime.Now;
            _Info.CreaterId = this.CurrentUser.ObjectId;
            _Info.CreaterName = this.CurrentUser.Name;
            _Info.CreaterAccount = this.CurrentUser.AccountNo;

            _Info.SubmitTime = DateTime.Now;
            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;

            //会计核算
            _Info.NextBAOperaterName = this.ddlstApproveUserBA.SelectedText;
            _Info.NextBAOperaterId = new Guid(this.ddlstApproveUserBA.SelectedValue);
            _Info.SubmitBATime = DateTime.Now;
            _Info.BAStatus = 1;

            int result = 3;
            result = manage.Add(_Info);

            if (result == -1)
            {
                manage.AddHistory(_Info.ObjectId, "申请", "银行贷款申请", this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, "");
                new CashFlowManage().AddHistory(_Info.ObjectId, "申请", "银行贷款申请", this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.Remark, "BankLoan");

                CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "贷款申请审核列表");
                CheckMsg(ddlstApproveUserBA.SelectedValue.ToString(), ddlstApproveUserBA.SelectedText, "银行贷款会计核算");

                //Alert.Show("添加成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("添加失败!");
            }
        }

        /// <summary>
        /// 绑定下一步
        /// </summary>
        private void BindNext()
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            //   ddlstNext.Items.Add(new ExtAspNet.ListItem("会计审核", "1"));
            ddlstNext.SelectedIndex = 0;

            //ddlstNextBA.Items.Add(new ExtAspNet.ListItem("会计核算", "0"));
            //ddlstNextBA.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定审批人
        /// </summary>
        private void ApproveUser()
        {
            foreach (UserInfo user in CurrentChecker)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
                ddlstApproveUserBA.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
            }
            ddlstApproveUser.SelectedIndex = 0;
            ddlstApproveUserBA.SelectedIndex = 0;
        }
        #endregion
    }
}