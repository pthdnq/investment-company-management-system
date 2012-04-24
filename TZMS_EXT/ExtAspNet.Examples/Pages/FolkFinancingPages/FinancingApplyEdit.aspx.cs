﻿using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.FolkFinancingPages
{
    /// <summary>
    /// FinancingApplyEdit
    /// </summary>
    public partial class FinancingApplyEdit : BasePage
    {
        #region 属性
        /// <summary>
        ///  ObjectID
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
                // 绑定审批历史.
                BindHistory();
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }

        /// <summary>
        /// 绑定指定用户ID的数据到界面.
        /// </summary>
        /// <param name="strID">用户ID</param>
        private void bindUserInterface(string strID)
        {
            if (string.IsNullOrEmpty(strID))
            {
                return;
            }

            // 通过 ID获取 信息实例.
            com.TZMS.Model.FolkFinancingInfo _Info = new FolkFinancingManage().GetUserByObjectID(strID);

            // 绑定数据.
            if (_Info != null)
            {

                #region 下一步方式
                if (CurrentRoles.Contains(RoleType.DSZ))
                {
                    BindNext(true);
                }
                else if (CurrentRoles.Contains(RoleType.ZJL))
                {      //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
                    if (_Info.LoanAmount >= 300000)
                    { BindNext(false); HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。"; }
                    else
                    { BindNext(true); }
                }
                else
                {
                    BindNext(false);
                }
                #endregion
                this.tbBorrowerNameA.Text = _Info.BorrowerNameA;
                this.tbBorrowingCost.Text = _Info.BorrowingCost.ToString();
                this.tbCollateral.Text = _Info.Collateral;
                this.tbContactPhone.Text = _Info.ContactPhone;
                this.dpDueDateForPay.Text = _Info.DueDateForPay.ToString();
                this.tbGuarantee.Text = _Info.Guarantee;
                this.tbLenders.Text = _Info.Lenders;
                this.dpLoanDate.SelectedDate = _Info.LoanDate;
                this.ddlLoanType.SelectedValue = _Info.LoanType;
                this.tbRemark.Text = _Info.Remark;
                this.tbLoanAmount.Text = _Info.LoanAmountFlag + _Info.LoanAmount.ToString();

                this.tbLoanTimeLimit.Text = _Info.LoanTimeLimit;
                this.ddlInterestType.SelectedValue = _Info.InterestType;
                this.taAuditOpinion.Text = _Info.AuditOpinion;

                this.tbCash.Text = _Info.CashFlag + _Info.Cash.ToString();
                this.lbTransferAccount.Text = _Info.TransferAccount.ToString();
            }
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
            List<FolkFinancingHistoryInfo> lstInfo = new FolkFinancingManage().GetHistoryByCondtion(strCondition.ToString());
            //lstInfo.Sort(delegate(BaoxiaoCheckInfo x, BaoxiaoCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });
            for (int i = 0; i < lstInfo.Count; i++)
            {
                if (lstInfo[i].OperationType == "编辑")
                {
                    lstInfo[i].Remark = "";
                }
            }
            gridHistory.RecordCount = lstInfo.Count;
            this.gridHistory.DataSource = lstInfo;
            this.gridHistory.DataBind();
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
                decimal.TryParse(this.tbLoanAmount.Text.Replace(BT, "").Trim(), out loanAmount);
                transfer = loanAmount;
            }
            if (!string.IsNullOrWhiteSpace(this.tbCash.Text))
            {
                decimal.TryParse(this.tbCash.Text.Replace(BT, "").Trim(), out cash);
                if (loanAmount != 0)
                {
                    transfer = loanAmount - cash;
                }
            }

            this.lbTransferAccount.Text = string.Format("转账：{0} 元", transfer);
        }



        protected void btnDismissed_Click(object sender, EventArgs e)
        {
            //打回
            saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveInfo(1);
            //if (this.ddlstNext.SelectedValue.Equals("0"))
            //{
            //    //同意，继续审核
            //    saveInfo(3);
            //}
            //else
            //{
            //    //审核结束，待执行
            //    saveInfo(5);
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
        /// 保存 信息.
        /// </summary>
        private void saveInfo(int status)
        {
            FolkFinancingManage manage = new FolkFinancingManage();

            com.TZMS.Model.FolkFinancingInfo _Info = manage.GetUserByObjectID(ObjectID);
            //  _Info.AuditOpinion = this.taAuditOpinion.Text.Trim();
            _Info.Status = status;

            #region content
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
                _Info.LoanAmount = decimal.Parse(this.tbLoanAmount.Text.Replace(BT, "").Trim());

                if (tbLoanAmount.Text.Contains(BT))
                {
                    _Info.LoanAmountFlag = BT;
                }

            }
            _Info.LoanDate = this.dpLoanDate.SelectedDate.Value;
            _Info.LoanType = this.ddlLoanType.SelectedValue;
            _Info.LoanTimeLimit = this.tbLoanTimeLimit.Text.Trim();
            #endregion
            _Info.Cash = decimal.Parse(this.tbCash.Text.Replace(BT, "").Trim());

            if (tbCash.Text.Contains(BT))
            {
                _Info.CashFlag = BT;
            }
            _Info.TransferAccount = _Info.LoanAmount - _Info.Cash;


            if (status == 5)
            {
                _Info.NextOperaterName = "";
                _Info.NextOperaterId = Guid.Empty;
            }
            else
            {
                _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
                _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            }
            _Info.SubmitTime = DateTime.Now;

            //审批人
            //if (!_Info.Adulters.Contains(this.CurrentUser.ObjectId.ToString()))
            //{
            //    _Info.Adulters = _Info.Adulters + this.CurrentUser.ObjectId.ToString() + ";";
            //}
            // 执行操作.
            int result = 3;
            result = manage.Update(_Info);
            if (result == -1)
            {
                string statusName = "修改后重新提交"; // (status == 2) ? "不同意" : (status == 5) ? "同意，继续审批" : "同意，归档";
                manage.AddHistory(_Info.ObjectId, "编辑", string.Format("{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, "");

                CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "会计审核列表（财务部融资）");

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