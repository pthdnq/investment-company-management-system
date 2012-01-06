using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.InvestmentLoanPages
{
    public partial class EndingContractApply : BasePage
    {
        #region 属性
        public string OperateType
        {
            get
            {
                if (ViewState["OperateType"] == null)
                {
                    return null;
                }

                return ViewState["OperateType"].ToString();
            }
            set
            {
                ViewState["OperateType"] = value;
            }
        }

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

                OperateType = Request.QueryString["Type"];


                bindInterface(strID);

                // 绑定审批历史.
                BindHistory();
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }

        /// <summary>
        /// 绑定指定ID的数据到界面.
        /// </summary>
        /// <param name="strID">ID</param>
        private void bindInterface(string strID)
        {
            if (string.IsNullOrEmpty(strID))
            {
                return;
            }
            InvestmentLoanInfo _Info = new InvestmentLoanManage().GetUserByObjectID(ObjectID);

            #region View
            //if (!string.IsNullOrEmpty(OperateType) && OperateType.Equals("Apply"))
            //{
            if (_Info.Status > 7 && _Info.Status != 11)
            {
                // this.btnDismissed.Hidden = true;
                this.btnSave.Hidden = true;
                //   this.taAuditOpinion.Text = _Info.AuditOpinion;
                //    this.taAuditOpinion.Enabled = false;
                this.tbImprest.Text = _Info.Imprest;
                this.tbPenalbond.Text = _Info.Penalbond;
                this.taOpationRemark.Text = _Info.OpationRemark;

                this.tbImprest.Enabled = false;
                this.tbPenalbond.Enabled = false;
                this.taOpationRemark.Enabled = false;

                this.ddlstApproveUser.Items.Add(new ListItem() { Text = _Info.NextOperaterName, Value = "0", Selected = true });
                this.ddlstNext.ShowRedStar = false;
                this.ddlstApproveUser.ShowRedStar = false;
                this.taOpationRemark.ShowRedStar = false;
                this.tbPenalbond.ShowRedStar = false;
                this.tbImprest.ShowRedStar = false;
                this.ddlstNext.Enabled = false;
                this.ddlstApproveUser.Enabled = false;
            }
            else
            {
                // 绑定审批人.
                ApproveUser();
            }
            #endregion

            #region 下一步方式
            //if (CurrentRoles.Contains(RoleType.DSZ))
            //{
            //    BindNext(true);
            //}
            //else if (CurrentRoles.Contains(RoleType.ZJL))
            //{      //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
            //    if (_Info.LoanAmount >= 300000)
            //    { BindNext(false); HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。"; }
            //    else
            //    { BindNext(true); }
            //}
            //else
            //{
            BindNext(false);
            //  }
            #endregion
            this.taOpationRemark.Text = _Info.OpationRemark;
            this.tbImprest.Text = _Info.Imprest;
            this.tbPenalbond.Text = _Info.Penalbond;

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
        protected void btnDismissed_Click(object sender, EventArgs e)
        {
            //不同意，打回
            saveInfo(11);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveInfo(7);
            //if (this.ddlstNext.SelectedValue.Equals("0"))
            //{
            //    //同意，继续审核
            //    saveInfo(7);
            //}
            //else
            //{
            //    //待会计审核/支付确认/归档
            //    saveInfo(8);
            //}
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
                ddlstApproveUser.Hidden = true;
                ddlstApproveUser.Required = false;
                ddlstApproveUser.ShowRedStar = false;
                ddlstApproveUser.Enabled = false;
                btnSave.Text = "同意并归档";
                btnSave.ConfirmText = "您确定同意并归档吗?";
            }
            else
            {
                ddlstApproveUser.Hidden = false;
                ddlstApproveUser.Required = true;
                ddlstApproveUser.ShowRedStar = true;
                ddlstApproveUser.Enabled = true;
                btnSave.Text = "同意";
                btnSave.ConfirmText = "您确定同意吗?";
            }
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
            _Info.AuditOpinion = string.Empty;
            _Info.OpationRemark = this.taOpationRemark.Text.Trim();
            _Info.Penalbond = this.tbPenalbond.Text.Trim();
            _Info.Imprest = this.tbImprest.Text.Trim();

            //下一步操作
            //if (status != 7)
            //{
            //    _Info.NextOperaterName = "";
            //    _Info.NextOperaterId = Guid.Empty;
            //}
            //else
            //{
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            // }

            _Info.SubmitTime = DateTime.Now;

            //审批人
            //if (!_Info.Adulters.Contains(this.CurrentUser.ObjectId.ToString()))
            //{
            //    _Info.Adulters = _Info.Adulters + this.CurrentUser.ObjectId.ToString() + ";";
            //}

            int result = 3;
            result = manage.Update(_Info);
            if (result == -1)
            {
                string statusName = "合同终止申请";// (status == 11) ? "不同意" : (status == 7) ? "同意，继续审批" : "同意，归档";
                manage.AddHistory(_Info.ObjectId, "合同终止", string.Format("{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.OpationRemark);

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
        private void BindNext(bool needAccountant)
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            if (needAccountant)
            {
                //    ddlstNext.Items.Add(new ExtAspNet.ListItem("归档", "1"));
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