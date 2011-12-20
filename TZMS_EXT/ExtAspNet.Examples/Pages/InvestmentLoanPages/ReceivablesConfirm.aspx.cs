﻿using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.InvestmentLoanPages
{
    /// <summary>
    /// ReceivablesConfirm
    /// </summary>
    public partial class ReceivablesConfirm : BasePage
    {
        #region 属性


        /// <summary>
        ///   ObjectID
        /// </summary>
        public string ObjectID
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
                // 绑定审批历史.
                BindHistory();
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            hlPrinter.NavigateUrl = "ReceivablesConfirmPrinter.aspx?ID='" + ObjectID + "'";
        }


        /// <summary>
        /// 绑定指定用户ID的数据到界面.
        /// </summary>
        /// <param name="strUserID">用户ID</param>
        private void bindUserInterface(string strUserID)
        {
            //if (string.IsNullOrEmpty(strUserID))
            //{
            //    return;
            //} 
            // 通过 ID获取 信息实例.
            com.TZMS.Model.ReceivablesInfo info = new InvestmentLoanManage().GetReceivableByObjectID(strUserID);

            tbProjectName.Text = info.ProjectName;
            dpDueDateForReceivables.SelectedDate = info.DueDateForReceivables;
            dpDateForReceivables.SelectedDate = info.DateForReceivables;
            tbAmountofpaidUp.Text = info.AmountofpaidUp.ToString();
            tbReceivablesAccount.Text = info.ReceivablesAccount;
            taRemark.Text = info.Remark;
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
            List<ReceivablesAuditHistoryInfo> lstInfo = new InvestmentLoanManage().GetProcessHistoryByCondtion(strCondition.ToString());
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //确认5
            saveInfo(5);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存 信息.
        /// </summary>
        private void saveInfo(int status)
        {
            com.TZMS.Model.ReceivablesInfo _Info = new InvestmentLoanManage().GetReceivableByObjectID(ObjectID);

            InvestmentLoanManage manage = new InvestmentLoanManage();

            //  ID.
            //info.ObjectId = Guid.NewGuid();
            //info.ForId = new Guid(ForID);  

            _Info.AuditOpinion = taAuditOpinionRemark.Text.Trim();
            _Info.Status = status;
            _Info.IsAccountingAudit = true;

            #region 积分
            var loan = manage.GetUserByObjectID(_Info.ForId.ToString());
            var customer = manage.GetCustomerByObjectID(loan.BorrowerAId.ToString());
            int iPoints = 5;
            if (_Info.DateForReceivables > _Info.DueDateForReceivables)
            {
                //推后交
                int idelaydays = (_Info.DateForReceivables - _Info.DueDateForReceivables).Days;
                iPoints -= idelaydays;
            }
            else if (_Info.DateForReceivables <= _Info.DueDateForReceivables)
            {
                //提前交
                int idays = (_Info.DueDateForReceivables - _Info.DateForReceivables).Days;
                iPoints += idays;
            }
            //更新积分
            customer.CreditScore += iPoints;
            manage.UpdateCustomer(customer);


            #endregion
            // 执行操作.
            int result = 3;

            result = manage.UpdateReceivable(_Info);
            if (result == -1)
            {
                #region cashflow
                int itmp = new CashFlowManage().Add(new CashFlowStatementInfo()
                {
                    ObjectId = Guid.NewGuid(),
                    Amount = _Info.AmountofpaidUp,
                    DateFor = DateTime.Now,
                    FlowDirection = "Receive",
                    FlowType = "",
                    Biz = "InvestmentLoan",
                    ProjectName = _Info.ProjectName,
                    IsAccountingAudit = 1,
                    Status = 1
                    //   CreateTime = DateTime.Now,

                });
                if (itmp != -1)
                {
                    _Info.Status = 4;
                    manage.UpdateReceivable(_Info);
                    Alert.Show("操作失败!");
                    return;
                }
                #endregion

                string statusName = "已确认";//(status == 2) ? "不同意" : (status == 3) ? "同意" : "待会计审核";
                manage.AddHistory(true, _Info.ObjectId, "会计审核", string.Format("审核:{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.AuditOpinion);

                Alert.Show("添加成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("添加失败!");
            }

        }

        #endregion
    }
}