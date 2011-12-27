using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.InvestmentLoanPages
{
    /// <summary>
    /// PaymentConfirm
    /// </summary>
    public partial class PaymentConfirm : BasePage
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


            if (!IsPostBack)
            {
                string strID = Request.QueryString["ID"];
                ObjectID = strID;

                bindUserInterface(strID);
                // 绑定审批历史.
                BindHistory();

                // 绑定审批人.
                //  ApproveUser();
            }
            InitControl();

        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            hlPrinter.NavigateUrl = "PaymentConfirmPrinter.aspx?ID=" + ObjectID;
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
            InvestmentLoanInfo _Info = new InvestmentLoanManage().GetUserByObjectID(ObjectID);

            //if (_Info.LoanAmount >= 300000 && !CurrentRoles.Contains(RoleType.DSZ))
            //{
            //    //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
            //    BindNext(false);
            //    HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。";
            //}
            //else
            //{
            //    BindNext(true);
            //}

            this.tbProjectName.Text = _Info.ProjectName;
            this.tbProjectOverview.Text = _Info.ProjectOverview;
            this.tbBorrowerNameA.Text = _Info.BorrowerNameA;
            this.tbBorrowerPhone.Text = _Info.BorrowerPhone;
            this.tbPayerBName.Text = _Info.PayerBName;
            this.tbGuarantor.Text = _Info.Guarantor;
            this.tbGuarantorPhone.Text = _Info.GuarantorPhone;
            this.tbCollateral.Text = _Info.Collateral;
            this.dpDueDateForPay.Text = _Info.DueDateForPay.ToString();
            this.dpLoanDate.SelectedDate = _Info.LoanDate;
            this.tbLoanAmount.Text = _Info.LoanAmount.ToString();
            this.tbRemark.Text = _Info.Remark;

            this.tbRateOfReturn.Text = _Info.RateOfReturn.ToString();
            this.taAuditOpinion.Text = _Info.AuditOpinion;

            this.tbLoanTimeLimit.Text = _Info.LoanTimeLimit;
            this.ddlLoanType.SelectedValue = _Info.LoanType;
        }

        /// <summary>
        /// 绑定历史
        /// </summary>
        private void BindHistory()
        {
            if (ObjectID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("ForId = '" + ObjectID + "'");
            strCondition.Append(" ORDER BY OperationTime DESC");
            List<InvestmentLoanHistoryInfo> lstInfo = new InvestmentLoanManage().GetHistoryByCondtion(strCondition.ToString());
            //lstInfo.Sort(delegate(BaoxiaoCheckInfo x, BaoxiaoCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            gridHistory.RecordCount = lstInfo.Count;
            this.gridHistory.DataSource = lstInfo;
            this.gridHistory.DataBind();
        }
        #endregion

        #region 页面及控件事件
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnDismissed_Click(object sender, EventArgs e)
        //{
        //    //不同意，打回
        //    saveInfo(2);
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //确认5
            saveInfo(5);
            //if (this.ddlstNext.SelectedValue.Equals(0))
            //{
            //    //同意，继续审核
            //    saveInfo(3);
            //}
            //else
            //{
            //    //待会计审核/支付确认
            //    saveInfo(4);
            //}
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存信息.
        /// </summary>
        private void saveInfo(int status)
        {
            InvestmentLoanManage manage = new InvestmentLoanManage();
            InvestmentLoanInfo _Info = manage.GetUserByObjectID(ObjectID);

            _Info.Status = status;
            _Info.AccountingRemark = this.taAccountingRemark.Text.Trim();

            //下一步操作
            _Info.NextOperaterName = "";
            _Info.NextOperaterId = Guid.Empty;
            _Info.SubmitTime = DateTime.Now;

            //审批人
            if (!_Info.Adulters.Contains(this.CurrentUser.ObjectId.ToString()))
            {
                _Info.Adulters = _Info.Adulters + this.CurrentUser.ObjectId.ToString() + ";";
            }

            int result = 3;
            result = manage.Update(_Info);
            if (result == -1)
            {
                #region cashflow
                int itmp = new CashFlowManage().Add(new CashFlowStatementInfo()
                {
                    ObjectId = Guid.NewGuid(),
                    Amount = _Info.LoanAmount,
                    DateFor = DateTime.Now,
                    FlowDirection = Common.FlowDirection.Payment,
                    FlowType = "",
                    Biz = Common.Biz.InvestmentLoan,
                    ProjectName = _Info.ProjectName,
                    IsAccountingAudit = 1
                });
                if (itmp != -1)
                {
                    _Info.Status = 4;
                    manage.Update(_Info);
                    Alert.Show("操作失败!");
                    return;
                }
                #endregion

                string statusName = "借款，已确认";//(status == 2) ? "不同意" : (status == 3) ? "同意" : "待会计审核";
                manage.AddHistory(_Info.ObjectId, "会计审核", string.Format("{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.AccountingRemark);

                Alert.Show("操作成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("操作失败!");
            }
        }


        /// <summary>
        /// 绑定下一步
        /// </summary>
        //private void BindNext(bool needAccountant)
        //{
        //    ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
        //    if (needAccountant)
        //    {
        //        ddlstNext.Items.Add(new ExtAspNet.ListItem("会计审核", "1"));
        //    }
        //    ddlstNext.SelectedIndex = 0;
        //}

        /// <summary>
        /// 绑定审批人
        /// </summary>
        //private void ApproveUser()
        //{
        //    foreach (UserInfo user in CurrentChecker)
        //    {
        //        ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
        //    }

        //    ddlstApproveUser.SelectedIndex = 0;
        //}
        #endregion
    }
}