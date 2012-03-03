using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.FolkFinancingPages
{
    /// <summary>
    /// FinancingApplyAdd
    /// </summary>
    public partial class FinancingApplyAdd : BasePage
    {
        #region 属性

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

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存信息.
        /// </summary>
        private void saveInfo()
        {
            FolkFinancingManage manage = new FolkFinancingManage();
            FolkFinancingInfo _Info = new FolkFinancingInfo();

            _Info.ObjectId = Guid.NewGuid();
            _Info.BorrowerNameA = this.tbBorrowerNameA.Text.Trim();
            if (!string.IsNullOrEmpty(this.tbBorrowingCost.Text))
            {
                _Info.BorrowingCost = decimal.Parse(this.tbBorrowingCost.Text.Trim());
            }
            _Info.Collateral = this.tbCollateral.Text.Trim();
            _Info.ContactPhone = this.tbContactPhone.Text.Trim();
            _Info.DueDateForPay = int.Parse(this.dpDueDateForPay.Text.Trim());
            _Info.Guarantee = this.tbGuarantee.Text;
            _Info.Lenders = this.tbLenders.Text;
            if (!string.IsNullOrEmpty(this.tbLoanAmount.Text))
            {
                _Info.LoanAmount = decimal.Parse(this.tbLoanAmount.Text.Trim());
            } 
            _Info.Cash = decimal.Parse(this.tbCash.Text.Trim());
            _Info.TransferAccount = _Info.LoanAmount - _Info.Cash;

            _Info.LoanDate = this.dpLoanDate.SelectedDate.Value;
            _Info.LoanType = this.ddlLoanType.SelectedValue;
            _Info.InterestType = this.ddlInterestType.SelectedValue;

            _Info.Remark = this.tbRemark.Text.Trim();
            //待会计审核
            _Info.Status = 4;

            _Info.LoanTimeLimit = this.tbLoanTimeLimit.Text.Trim();
            //补充申请人及下一步审核人信息
            _Info.SubmitTime = DateTime.Now;
            _Info.CreateTime = DateTime.Now;
            _Info.CreaterId = this.CurrentUser.ObjectId;
            _Info.CreaterName = this.CurrentUser.Name;
            _Info.CreaterAccount = this.CurrentUser.AccountNo;

            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;

            //会计审核
            _Info.NextBAOperaterName = this.ddlstApproveUserBA.SelectedText;
            _Info.NextBAOperaterId = new Guid(this.ddlstApproveUserBA.SelectedValue);
            _Info.SubmitBATime = DateTime.Now;
            _Info.BAStatus = 1; 

            int result = 3;
            result = manage.Add(_Info);

            if (result == -1)
            {
                manage.AddHistory(_Info.ObjectId, "新增", "新增民间融资申请", this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, "");
                new CashFlowManage().AddHistory(_Info.ObjectId, "新增", "新增民间融资申请", this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.Remark, "FolkFinancing");
                CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "会计审核列表（财务部融资）");
                CheckMsg(ddlstApproveUserBA.SelectedValue.ToString(), ddlstApproveUserBA.SelectedText, "民间融资会计核算");

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
            //  ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("会计审核", "1"));
            ddlstNext.SelectedIndex = 1;

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