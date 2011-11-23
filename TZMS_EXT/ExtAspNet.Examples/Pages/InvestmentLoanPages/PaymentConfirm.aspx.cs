﻿using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

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
            InitControl();

            if (!IsPostBack)
            {
                string strID = Request.QueryString["ID"];
                ObjectID = strID;

                bindUserInterface(strID);
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
            this.tbProjectName.Text = _Info.ProjectName;
            this.tbProjectOverview.Text = _Info.ProjectOverview;
            this.tbBorrowerNameA.Text = _Info.BorrowerNameA;
            this.tbBorrowerPhone.Text = _Info.BorrowerPhone;
            this.tbPayerBName.Text = _Info.PayerBName;
            this.tbGuarantor.Text = _Info.Guarantor;
            this.tbGuarantorPhone.Text = _Info.GuarantorPhone;
            this.tbCollateral.Text = _Info.Collateral;
            this.dpDueDateForPay.SelectedDate = _Info.DueDateForPay;
            this.dpLoanDate.SelectedDate = _Info.LoanDate;

            this.tbRemark.Text = _Info.Remark;

            this.tbRateOfReturn.Text = _Info.RateOfReturn.ToString();

             this.taAuditOpinion.Text  = _Info.AuditOpinion;
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
            //打回状态2
            saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //支付确认4
            saveInfo(4);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存信息.
        /// </summary>
        private void saveInfo(int status)
        {
            InvestmentLoanManage _Manage = new InvestmentLoanManage();
            InvestmentLoanInfo _Info = _Manage.GetUserByObjectID(ObjectID);

            _Info.Status = status;
            _Info.AccountingRemark = this.taAccountingRemark.Text.Trim();
              
            int result = 3;

            result = _Manage.Update(_Info);

            if (result == -1)
            {
                Alert.Show("确认成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("确认失败!");
            }
        }


        #endregion
    }
}