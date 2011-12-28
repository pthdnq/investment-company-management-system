using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.InvestmentLoanPages
{
    /// <summary>
    /// PaymentApplyEdit
    /// </summary>
    public partial class PaymentApplyEdit : BasePage
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
                OperatorType = "Add";
                bindInterface(strID);
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
            this.tbLoanAmount.Text = _Info.LoanAmount.ToString();
            this.tbRemark.Text = _Info.Remark;

            this.tbRateOfReturn.Text = _Info.RateOfReturn.ToString();

            this.tbLoanTimeLimit.Text = _Info.LoanTimeLimit;
            this.ddlLoanType.SelectedValue = _Info.LoanType;

            this.taAuditOpinion.Text = _Info.AuditOpinion;

            this.tbBorrowerNameA.Enabled = false;
            this.tbBorrowerPhone.Enabled = false;
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
            saveInfo(1);
            //if (this.ddlstNext.SelectedValue.Equals("0"))
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
            }
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
            _Info.LoanTimeLimit = this.tbLoanTimeLimit.Text.Trim();
            _Info.RateOfReturn = this.tbRateOfReturn.Text;

            _Info.Status = status;
            //    _Info.AuditOpinion = this.taAuditOpinion.Text.Trim();

            //下一步操作
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
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
                string statusName = "修改后重新提交";//  (status == 2) ? "不同意" : (status == 3) ? "同意" : "同意，待会计审核";
                manage.AddHistory(_Info.ObjectId, "编辑", string.Format("{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.AuditOpinion);

                Alert.Show("更新成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("更新失败!");
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
                //  ddlstNext.Items.Add(new ExtAspNet.ListItem("会计审核", "1"));
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