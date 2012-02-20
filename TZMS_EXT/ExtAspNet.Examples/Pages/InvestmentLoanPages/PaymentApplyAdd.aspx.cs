using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.InvestmentLoanPages
{
    /// <summary>
    /// 支付申请add
    /// </summary>
    public partial class PaymentApplyAdd : BasePage
    {
        #region 属性
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
        /// ID
        /// </summary>
        public string ID
        {
            get
            {
                if (ViewState["ID"] == null)
                {
                    return null;
                }

                return ViewState["ID"].ToString();
            }
            set
            {
                ViewState["ID"] = value;
            }
        }

        private string ViewStateZJ
        {
            get
            {
                if (ViewState["ViewStateZJ"] == null)
                {
                    return null;
                }

                return ViewState["ViewStateZJ"].ToString();
            }
            set
            {
                ViewState["ViewStateZJ"] = value;
            }
        }

        /// <summary>
        /// 申请单ID
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
        #endregion

        #region 页面加载及数据初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            InitControl();

            if (!IsPostBack)
            {
                OperatorType = "Add";
                // 绑定下一步.
                BindNext();
                // 绑定审批人.
                ApproveUser();
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();

            wndChooseZJ.OnClientCloseButtonClick = wndChooseZJ.GetHidePostBackReference();
        }

        #endregion

        #region 页面及控件事件
        protected void tbCash_OnTextChanged(object sender, EventArgs e)
        {
            decimal loanAmount = 0;
            decimal cash = 0;
            decimal transfer = 0;
            if (!string.IsNullOrWhiteSpace(this.tbLoanAmount.Text))
            {
                decimal.TryParse(this.tbLoanAmount.Text.Trim(), out loanAmount);
                transfer = loanAmount;
            }
            if (!string.IsNullOrWhiteSpace(this.tbCash.Text))
            {
                decimal.TryParse(this.tbCash.Text.Trim(), out cash);
                if (loanAmount != 0)
                {
                    transfer = loanAmount - cash;
                }
            }

            this.lbTransferAccount.Text = string.Format("转账：{0} 元", transfer);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Decimal.Parse(tbLoanAmount.Text.Trim()) > Common.MaxMoney)
            {
                Alert.Show("借款金额 整数部分不能超过16位！");
                return;
            }
            if (Decimal.Parse(tbCash.Text.Trim()) > Common.MaxMoney)
            {
                Alert.Show("现金 整数部分不能超过16位！");
                return;
            }

            saveInfo();

        }

        /// <summary>
        /// 点击 TriggerBox 弹出窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbBorrowerNameA_TriggerClick(object sender, EventArgs e)
        {
            if (OperatorType == "Add")
            {
                wndChooseZJ.IFrameUrl = "ChooseJKR.aspx";
            }
            else
            {
                wndChooseZJ.IFrameUrl = "ChooseJKR.aspx?ID=" + ApplyID;
            }
            wndChooseZJ.Hidden = false;
        }


        /// <summary>
        /// 选择借款人关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndChooseZJ_Close(object sender, WindowCloseEventArgs e)
        {
            if (e.CloseArgument != "undefined")
            {
                tbBorrowerNameA.Text = e.CloseArgument.Split(',')[1];
                this.tbBorrowerPhone.Text = e.CloseArgument.Split(',')[2];
                ViewStateZJ = e.CloseArgument;

                this.tbBorrowerNameA.Enabled = false;
                this.tbBorrowerPhone.Enabled = false;
            }
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存信息.
        /// </summary>
        private void saveInfo()
        {


            InvestmentLoanInfo _Info = null;
            InvestmentLoanManage manage = new InvestmentLoanManage();
            CustomerInfo _customer = null;

            if (!string.IsNullOrEmpty(ViewStateZJ))
            {
                _customer = manage.GetCustomerByObjectID(ViewStateZJ.Split(',')[0]);
            }
            else
            {
                _customer = manage.GetCustomerByMobilePhone(this.tbBorrowerPhone.Text.Trim());

                if (_customer == null)
                {
                    _customer = new CustomerInfo()
                    {
                        ObjectId = Guid.NewGuid(),
                        MobilePhone = this.tbBorrowerPhone.Text.Trim(),
                        Name = this.tbBorrowerNameA.Text.Trim()
                    };
                    manage.AddCustomer(_customer);
                }
                if (!_customer.Name.Equals(this.tbBorrowerNameA.Text.Trim()))
                {
                    // LbTooltip.Text = "您输入手机号码的借款人姓名与已存储客户姓名不一致，请检查，谢谢！";
                    Alert.Show("您输入手机号码的借款人姓名与已存储客户姓名不一致，请检查，谢谢！!");
                    return;
                }
            }

            _Info = new InvestmentLoanInfo();

            _Info.ObjectId = Guid.NewGuid();
            _Info.ProjectName = this.tbProjectName.Text.Trim();
            _Info.ProjectOverview = this.tbProjectOverview.Text.Trim();

            _Info.BorrowerNameA = _customer.Name;
            _Info.BorrowerAId = _customer.ObjectId;

            _Info.LoanAmount = decimal.Parse(this.tbLoanAmount.Text);
            _Info.BorrowerPhone = this.tbBorrowerPhone.Text.Trim();
            _Info.PayerBName = this.tbPayerBName.Text.Trim();
            _Info.Guarantor = this.tbGuarantor.Text.Trim();
            _Info.GuarantorPhone = this.tbGuarantorPhone.Text.Trim();
            _Info.Collateral = this.tbCollateral.Text.Trim();
            _Info.DueDateForPay = int.Parse(this.dpDueDateForPay.Text.Trim());
            _Info.LoanDate = DateTime.Parse(this.dpLoanDate.Text);
            _Info.Status = 1;
            _Info.SubmitTime = DateTime.Now;
            _Info.Remark = this.tbRemark.Text.Trim();
            _Info.LoanTimeLimit = this.tbLoanTimeLimit.Text.Trim();
            _Info.RateOfReturn = this.tbRateOfReturn.Text;

            _Info.Cash = decimal.Parse(this.tbCash.Text.Trim());
            _Info.TransferAccount = _Info.LoanAmount - _Info.Cash;
            // 创建人
            _Info.CreateTime = DateTime.Now;
            _Info.CreaterId = this.CurrentUser.ObjectId;
            _Info.CreaterName = this.CurrentUser.Name;
            _Info.CreaterAccount = this.CurrentUser.AccountNo;
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            //会计审核
            _Info.NextBAOperaterName = this.ddlstApproveUserBA.SelectedText;
            _Info.NextBAOperaterId = new Guid(this.ddlstApproveUserBA.SelectedValue);
            _Info.SubmitBATime = DateTime.Now;
            _Info.BAStatus = 1;

            _Info.LoanTimeLimit = this.tbLoanTimeLimit.Text.Trim();
            _Info.LoanType = this.ddlLoanType.SelectedValue;

            // 执行操作.

            int result = 3;

            result = manage.Add(_Info);

            if (result == -1)
            {
                //更新用户借款状态
                _customer.Status = 1;
                manage.UpdateCustomer(_customer);

                manage.AddHistory(_Info.ObjectId, "新增", "新增借款申请", this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, "");
                new CashFlowManage().AddHistory(_Info.ObjectId, "新增", "投资部借款申请", this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.Remark, "InvestmentLoan");
                Alert.Show("添加成功!");
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