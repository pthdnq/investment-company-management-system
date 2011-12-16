using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.FolkFinancingPages
{
    /// <summary>
    /// AccountingAudit
    /// </summary>
    public partial class AccountingAudit : BasePage
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
                BindNext(false);
                #region 下一步方式

                //if (CurrentRoles.Contains(RoleType.DSZ))
                //{
                //    BindNext(true);
                //}
                //else if (CurrentRoles.Contains(RoleType.ZJL))
                //{      //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
                //    if (_info.AmountExpended >= 300000)
                //    { BindNext(false); HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。"; }
                //    else
                //    { BindNext(true); }
                //}
                //else
                //{
                //    BindNext(false);
                //}
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

                this.tbLoanTimeLimit.Text = _Info.LoanTimeLimit;
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

            gridHistory.RecordCount = lstInfo.Count;
            this.gridHistory.DataSource = lstInfo;
            this.gridHistory.DataBind();
        }
        #endregion

        #region 页面及控件事件
        protected void btnDismissed_Click(object sender, EventArgs e)
        {
            //打回
            saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //（会计）审核通过
            saveInfo(3);
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
            _Info.AuditOpinion = this.taAuditOpinion.Text.Trim();
            _Info.Status = status;

            // 执行操作.
            int result = 3;

            result = manage.Update(_Info);
            if (result == -1)
            {
                #region cashflow
                int itmp = new CashFlowManage().Add(new CashFlowStatementInfo()
                {
                    ObjectId = Guid.NewGuid(),
                    Amount = _Info.LoanAmount,
                    DateFor = DateTime.Now,
                    FlowDirection = "Receive",
                    FlowType = "",
                    Biz = "FolkFinancing",
                    ProjectName =  _Info.Lenders+"出借"+_Info.BorrowerNameA,
                    IsAccountingAudit = 1
                });
                if (itmp != -1)
                {
                    _Info.Status = 1;
                    manage.Update(_Info);
                    Alert.Show("操作失败!");
                    return;
                }
                #endregion

                string statusName = (status == 2) ? "不同意" : (status == 3) ? "同意" : "同意，待领导审批";
                manage.AddHistory(_Info.ObjectId, "会计审核", string.Format("审核:{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.AuditOpinion);

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
                ddlstNext.Items.Add(new ExtAspNet.ListItem("会计审核", "1"));
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