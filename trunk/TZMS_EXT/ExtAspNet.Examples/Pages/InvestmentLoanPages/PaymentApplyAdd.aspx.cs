﻿using System;
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
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
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
                ViewStateZJ = e.CloseArgument;
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

            CustomerInfo _customer = manage.GetCustomerByObjectID(ViewStateZJ.Split(',')[0]);
           
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
            _Info.DueDateForPay = DateTime.Parse(this.dpDueDateForPay.Text);
            _Info.LoanDate = DateTime.Parse(this.dpLoanDate.Text);
            _Info.Status = 1;
            _Info.SubmitTime = DateTime.Now;
            _Info.Remark = this.tbRateOfReturn.Text.Trim();

            _Info.RateOfReturn = this.tbRateOfReturn.Text[0];

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

            // 执行操作.

            int result = 3;

            result = manage.Add(_Info);

            if (result == -1)
            {
                manage.AddHistory(_Info.ObjectId, "申请", "借款申请", this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, "");
                new CashFlowManage().AddHistory(_Info.ObjectId, "申请", "投资部借款申请", this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.Remark,"InvestmentLoan");
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

            ddlstNextBA.Items.Add(new ExtAspNet.ListItem("会计核算", "0"));
            ddlstNextBA.SelectedIndex = 0;

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