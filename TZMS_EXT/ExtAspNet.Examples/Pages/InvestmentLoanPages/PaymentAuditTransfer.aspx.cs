﻿using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.InvestmentLoanPages
{
    public partial class PaymentAuditTransfer : BasePage
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

                if (!string.IsNullOrEmpty(OperateType) && OperateType.Equals("Owner"))
                {
                    btnSave.Hidden = true;
                    btnDismissed.Hidden = false;

                }

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
        /// <param name="strUserID">用户ID</param>
        private void bindUserInterface(string strUserID)
        {
            if (string.IsNullOrEmpty(strUserID))
            {
                return;
            }
            InvestmentLoanInfo _Info = new InvestmentLoanManage().GetUserByObjectID(ObjectID);

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
            this.tbLoanAmount.Text =_Info.LoanAmountFlag+ _Info.LoanAmount.ToString();
            this.tbRemark.Text = _Info.Remark;

            this.tbRateOfReturn.Text = _Info.RateOfReturn.ToString();

            this.tbLoanTimeLimit.Text = _Info.LoanTimeLimit;
            this.ddlLoanType.SelectedValue = _Info.LoanType;

            this.tbCash.Text =_Info.CashFlag+ _Info.Cash.ToString();
            this.lbTransferAccount.Text = _Info.TransferAccount.ToString();
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
            saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ddlstNext.SelectedValue.Equals("0"))
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
            InvestmentLoanManage manage = new InvestmentLoanManage();
            InvestmentLoanInfo _Info = manage.GetUserByObjectID(ObjectID);

            //_Info.Status = status;
            //_Info.AuditOpinion = this.taAuditOpinion.Text.Trim();

            string strLastNextOperaterName = _Info.NextOperaterName;
            string strOperationType = "审批转移";
            if (!string.IsNullOrEmpty(OperateType) && OperateType.Equals("Owner"))
            {
                strOperationType = "业务转移";
                strLastNextOperaterName = _Info.CreaterName;
                //下一步操作
                _Info.CreaterName = this.ddlstApproveUser.SelectedText;
                _Info.CreaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            }
            else
            {
                _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
                _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);

            }
            _Info.SubmitTime = DateTime.Now;
            int result = 3;
            result = manage.Update(_Info);
            if (result == -1)
            {
                string statusName = string.Format("从 {0} 转移至 {1}", strLastNextOperaterName, this.ddlstApproveUser.SelectedText);// (status == 2) ? "不同意" : (status == 3) ? "同意" : "同意，待会计审核";
                manage.AddHistory(_Info.ObjectId, strOperationType, string.Format("{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, this.taAuditOpinion.Text.Trim());

                if (!string.IsNullOrEmpty(OperateType) && OperateType.Equals("Owner"))
                {
                    //提醒 新的审批人  业务转移
                    ResultMsgMore(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "您有1条 借款申请列表（来自风险控制部，通过业务移交方式）！");
                }
                else
                {
                    if (_Info.Status == 7)
                    {
                        //提醒 新的审批人 终止审批转移
                        ResultMsgMore(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "您有1条 待审批 终止审核列表（来自风险控制部，通过审批人转移方式）！");
                  
                    }
                    else
                    {
                        //提醒 新的审批人 审批转移
                        ResultMsgMore(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "您有1条 待审批 借款审核列表（来自风险控制部，通过审批人转移方式）！");
                    }
                }
                //Alert.Show("操作成功!");
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
            ddlstNext.Items.Add(new ExtAspNet.ListItem("转移至", "0"));
            if (needAccountant)
            {
                //ddlstNext.Items.Add(new ExtAspNet.ListItem("会计审核", "1"));
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