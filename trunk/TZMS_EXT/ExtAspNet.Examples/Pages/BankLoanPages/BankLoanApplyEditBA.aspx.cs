using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.BankLoanPages
{
    public partial class BankLoanApplyEditBA : BasePage
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


                // 绑定审批人.
                ApproveUser();
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
            BankLoanInfo _Info = new BankLoanManage().GetUserByObjectID(ObjectID);
            MUDAttachment.RecordID = _Info.ObjectId.ToString();

            if (_Info.Status == 2 || _Info.BAStatus != 2)
            {
                this.btnSave.Hidden = true;
            }

            if (CurrentRoles.Contains(RoleType.HSKJ))
            {
                BindNext(true);
            }
            //if (_Info.LoanAmount >= 300000 && !CurrentRoles.Contains(RoleType.DSZ))
            //{
            //    //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
            //    BindNext(false);
            //    //   HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。";
            //}
            else
            {
                BindNext(false);
            }

            this.tbCollateralCompany.Text = _Info.CollateralCompany;
            this.tbCustomerName.Text = _Info.CustomerName;
            this.tbDownPayment.Text = _Info.DownPayment.ToString();
            this.tbLoanAmount.Text = _Info.LoanAmount.ToString();
            this.tbLoanCompany.Text = _Info.LoanCompany;
            this.tbLoanFee.Text = _Info.LoanFee.ToString();
            // this.tbRemark.Text = _Info.Remark;
            this.taRemark.Text = _Info.Remark;
            this.taContact.Text = _Info.Contact;
            this.tbProjectName.Text = _Info.ProjectName;
            this.dpSignDate.SelectedDate = _Info.SignDate;

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
            List<AccountantAuditHistoryInfo> lstInfo = new CashFlowManage().GetHistoryByCondtion(strCondition.ToString());
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
            BankLoanManage manage = new BankLoanManage();
            BankLoanInfo _Info = manage.GetUserByObjectID(ObjectID);

            _Info.BAStatus = status;
            // _Info.AuditOpinion = this.taAuditOpinion.Text.Trim();
            _Info.Remark = this.taRemark.Text.Trim();

            //下一步操作
            _Info.NextBAOperaterName = this.ddlstApproveUser.SelectedText;
            _Info.NextBAOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            _Info.SubmitBATime = DateTime.Now;
            //BA审批人组
            if (!_Info.BAAdulters.Contains(this.CurrentUser.ObjectId.ToString()))
            {
                _Info.BAAdulters = _Info.BAAdulters + this.CurrentUser.ObjectId.ToString() + ";";
            }

            int result = 3;
            result = manage.Update(_Info);
            if (result == -1)
            {
                string statusName = "重新修改后提交";//(status == 2) ? "不同意" : (status == 3) ? "同意，继续审核" : "同意,归档";
                new CashFlowManage().AddHistory(_Info.ObjectId, "编辑", string.Format("{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.Remark, "BankLoan");

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
                //  ddlstNext.Items.Add(new ExtAspNet.ListItem("归档", "1"));
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