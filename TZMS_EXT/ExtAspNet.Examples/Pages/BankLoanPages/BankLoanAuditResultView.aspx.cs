﻿using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.BankLoanPages
{
    /// <summary>
    /// BankLoanAuditResultView
    /// </summary>
    public partial class BankLoanAuditResultView : BasePage
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

                bindInterface(strID);

                BindHistory();
                // 绑定审批人.
                //   ApproveUser();
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }

        /// <summary>
        /// 绑定指定 ID的数据到界面.
        /// </summary>
        /// <param name="strID"> ID</param>
        private void bindInterface(string strID)
        {
            if (string.IsNullOrEmpty(strID))
            {
                return;
            }
            BankLoanInfo _Info = new BankLoanManage().GetUserByObjectID(ObjectID);
            //UserInfo user = new UserManage().GetUserByObjectID(_Info.NextOperaterId.ToString());
            //if (_Info.LoanAmount >= 300000 && !CurrentRoles.Contains(RoleType.DSZ))
            //{
            //    //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
            //    BindNext(false);
            //    //   HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。";
            //}
            //else
            //{
            //    BindNext(false);
            //}

            tbProjectName.Text = _Info.ProjectName;
            this.tbCollateralCompany.Text = _Info.CollateralCompany;
            this.tbCustomerName.Text = _Info.CustomerName;
            this.tbDownPayment.Text = _Info.DownPaymentFlag + _Info.DownPayment.ToString();
            this.tbLoanAmount.Text = _Info.LoanAmountFlag + _Info.LoanAmount.ToString();
            this.tbLoanCompany.Text = _Info.LoanCompany;
            this.tbLoanFee.Text = _Info.LoanFeeFlag + _Info.LoanFee.ToString();
            this.tbRemark.Text = _Info.Remark;
            this.taContact.Text = _Info.Contact;

            this.dpSignDate.SelectedDate = _Info.SignDate;
            this.taAuditOpinion.Text = _Info.AuditOpinion;
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
            List<BankLoanHistoryInfo> lstInfo = new BankLoanManage().GetHistoryByCondtion(strCondition.ToString());
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
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDismissed_Click(object sender, EventArgs e)
        {
            //不同意，打回
            // saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (this.ddlstNext.SelectedValue.Equals(0))
            //{
            //    //同意，继续审核
            //  //  saveInfo(3);
            //}
            //else
            //{
            //    //待会计审核/支付确认
            // //   saveInfo(4);
            //}
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存信息.
        /// </summary>
        //private void saveInfo(int status)
        //{
        //    BankLoanManage _Manage = new BankLoanManage();
        //    BankLoanInfo _Info = _Manage.GetUserByObjectID(ObjectID);

        //    _Info.Status = status;
        //    _Info.AuditOpinion = this.taAuditOpinion.Text.Trim();

        //    //下一步操作
        //    _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
        //    _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
        //    _Info.SubmitTime = DateTime.Now;


        //    int result = 3;
        //    result = _Manage.Update(_Info);
        //    if (result == -1)
        //    {
        //        Alert.Show("更新成功!");
        //        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        //    }
        //    else
        //    {
        //        Alert.Show("更新失败!");
        //    }
        //}


        #endregion
    }
}