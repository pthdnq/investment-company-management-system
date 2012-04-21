using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.BankLoanPages
{
    public partial class BankLoanAuditTransfer : BasePage
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


            BindNext(false);
            //if (CurrentRoles.Contains(RoleType.DSZ))
            //{
            //    BindNext(true);
            //}
            //else if (_Info.LoanAmount < 300000 && CurrentRoles.Contains(RoleType.ZJL))
            //{
            //    //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
            //    BindNext(true);
            //    //   HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。";
            //}
            //else
            //{
            //    BindNext(false);
            //}


            this.tbCollateralCompany.Text = _Info.CollateralCompany;
            this.tbCustomerName.Text = _Info.CustomerName;
            this.tbDownPayment.Text = _Info.DownPaymentFlag + _Info.DownPayment.ToString();
            this.tbLoanAmount.Text = _Info.LoanAmountFlag + _Info.LoanAmount.ToString();
            this.tbLoanCompany.Text = _Info.LoanCompany;
            this.tbLoanFee.Text = _Info.LoanFeeFlag + _Info.LoanFee.ToString();
            this.tbRemark.Text = _Info.Remark;
            this.taContact.Text = _Info.Contact;

            this.dpSignDate.SelectedDate = _Info.SignDate;
            this.tbProjectName.Text = _Info.ProjectName;
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
            if (Decimal.Parse(tbLoanAmount.Text.Replace(BT, "").Trim()) > Common.MaxMoney)
            {
                Alert.Show("贷款金额 整数部分不能超过16位！");
                return;
            }
            if (Decimal.Parse(tbLoanFee.Text.Replace(BT, "").Trim()) > Common.MaxMoney)
            {
                Alert.Show("贷款手续费 整数部分不能超过16位！");
                return;
            }
            //不同意，打回
            saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Decimal.Parse(tbLoanAmount.Text.Replace(BT, "").Trim()) > Common.MaxMoney)
            {
                Alert.Show("贷款金额 整数部分不能超过16位！");
                return;
            }
            if (Decimal.Parse(tbLoanFee.Text.Replace(BT, "").Trim()) > Common.MaxMoney)
            {
                Alert.Show("贷款手续费 整数部分不能超过16位！");
                return;
            }
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

            // _Info.Status = status;
            // _Info.AuditOpinion = this.taAuditOpinion.Text.Trim();

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
                //下一步操作
                _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
                _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            }
            _Info.SubmitTime = DateTime.Now;


            int result = 3;
            result = manage.Update(_Info);
            if (result == -1)
            {
                string statusName = string.Format("转移从 {0} 至 {1}", strLastNextOperaterName, this.ddlstApproveUser.SelectedText);//  (status == 2) ? "不同意" : (status == 3) ? "同意" : "待会计审核";
                manage.AddHistory(_Info.ObjectId, strOperationType, string.Format("{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, this.taAuditOpinion.Text.Trim());
                if (!string.IsNullOrEmpty(OperateType) && OperateType.Equals("Owner"))
                {
                    //提醒 新的审批人 业务转移
                    ResultMsgMore(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "您有1条 贷款申请列表（来自集团内项目，通过业务移交方式）！");
                }
                else
                {
                    if (_Info.Status == 7)
                    {
                        //提醒 新的审批人 终止审核
                        ResultMsgMore(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "您的终止审核列表，有1条 待审批 信息（来自集团内项目，通过审批人转移方式）！");

                    }
                    else
                    {
                        //提醒 新的审批人
                        ResultMsgMore(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "您的审核列表，有1条 待审批 信息（来自集团内项目，通过审批人转移方式）！");
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
            ddlstNext.Items.Add(new ExtAspNet.ListItem("移交至", "0"));
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