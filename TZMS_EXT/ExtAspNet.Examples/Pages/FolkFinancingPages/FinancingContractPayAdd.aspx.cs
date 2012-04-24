using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.FolkFinancingPages
{
    /// <summary>
    /// FinancingContractPayAdd
    /// </summary>
    public partial class FinancingContractPayAdd : BasePage
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
        /// ForOrObjectID
        /// </summary>
        public string ForOrObjectID
        {
            get
            {
                if (ViewState["ForOrObjectID"] == null)
                {
                    return null;
                }

                return ViewState["ForOrObjectID"].ToString();
            }
            set
            {
                ViewState["ForOrObjectID"] = value;
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
                ForOrObjectID = strID;

                OperateType = Request.QueryString["Type"];
                tabHistory.Hidden = true;
                if (!string.IsNullOrEmpty(OperateType) && !OperateType.Equals("Add"))
                {
                    bindInterface(strID);
                    tabHistory.Hidden = false;
                }
                // 绑定下一步.
                BindNext();
                // 绑定审批人.
                ApproveUser();
                // 绑定审批历史.
                BindHistory();
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
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

            // 通过 ID获取 信息实例.
            com.TZMS.Model.FinancingFeePaymentInfo _info = new FolkFinancingManage().GetProcessByObjectID(strID);

            // 绑定数据.
            if (_info != null)
            {
                if (OperateType.Equals("View"))
                {
                    SetContrl(true);
                    this.btnSave.Hidden = true;


                    this.ddlstApproveUser.Items.Add(new ListItem() { Text = _info.NextOperaterName, Value = "0", Selected = true });

                    this.ddlstApproveUser.Enabled = false;
                    this.ddlstNext.Enabled = false;
                }
                else if (OperateType.Equals("Edit"))
                {
                    SetContrl(false);
                }
                #region 下一步方式
                //if (CurrentRoles.Contains(RoleType.DSZ))
                //{
                //    BindNext(true);
                //}
                //else if (CurrentRoles.Contains(RoleType.ZJL))
                //{      //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
                //    if (_info.AmountOfPayment >= 300000)
                //    { BindNext(false); HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。"; }
                //    else
                //    { BindNext(true); }
                //}
                //else
                //{
                //    BindNext(false);
                //}
                #endregion

                this.tbPaymentAccount.Text = _info.PaymentAccount;
                this.tbReceivablesAccount.Text = _info.ReceivablesAccount;
                this.tbAmountOfPayment.Text = _info.AmountOfPaymentFlag + _info.AmountOfPayment.ToString();

                this.tbRemark.Text = _info.Remark;

                if (DateTime.Compare(_info.DueDateForPay, DateTime.Parse("1900-1-1 12:00")) != 0)
                {
                    this.dpDueDateForPay.SelectedDate = _info.DueDateForPay;
                }

                if (DateTime.Compare(_info.DateForPay, DateTime.Parse("1900-1-1 12:00")) != 0)
                {
                    this.dpDateForPay.SelectedDate = _info.DateForPay;
                }
            }
        }

        private void SetContrl(bool IsDisable)
        {
            if (IsDisable)
            {
                this.tbPaymentAccount.Enabled = false;
                this.tbReceivablesAccount.Enabled = false;
                this.tbAmountOfPayment.Enabled = false;

                this.dpDueDateForPay.Enabled = false;
                this.dpDateForPay.Enabled = false;
                this.tbRemark.Enabled = false;
            }
        }

        /// <summary>
        /// 绑定历史
        /// </summary>
        private void BindHistory()
        {
            if (ForOrObjectID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("ForId = '" + ForOrObjectID + "'");
            strCondition.Append(" ORDER BY OperationTime DESC");
            List<FinancingFeePaymentHistoryInfo> lstInfo = new FolkFinancingManage().GetProcessHistoryByCondtion(strCondition.ToString());
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveInfo();
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存信息.
        /// </summary>
        private void saveInfo()
        {
            FolkFinancingManage manage = new FolkFinancingManage();
            FinancingFeePaymentInfo _Info = null;
            if (OperateType.Equals("Edit"))
            {
                _Info = manage.GetProcessByObjectID(ForOrObjectID);
            }
            else
            {
                _Info = new FinancingFeePaymentInfo();
                _Info.ForId = new Guid(ForOrObjectID);
                _Info.ObjectId = Guid.NewGuid();
                //申请人及
                _Info.CreateTime = DateTime.Now;
                _Info.CreaterId = this.CurrentUser.ObjectId;
                _Info.CreaterName = this.CurrentUser.Name;
                _Info.CreaterAccount = this.CurrentUser.AccountNo;
            }

            _Info.PaymentAccount = this.tbPaymentAccount.Text.Trim();
            _Info.ReceivablesAccount = this.tbReceivablesAccount.Text.Trim();
            if (!string.IsNullOrEmpty(this.tbAmountOfPayment.Text))
            {
                _Info.AmountOfPayment = decimal.Parse(this.tbAmountOfPayment.Text.Replace(BT, "").Trim());
                if (tbAmountOfPayment.Text.Contains(BT))
                {
                    _Info.AmountOfPaymentFlag = BT;
                }
            }

            _Info.DateForPay = this.dpDateForPay.SelectedDate.Value;
            _Info.DueDateForPay = this.dpDueDateForPay.SelectedDate.Value;

            _Info.Remark = this.tbRemark.Text.Trim();
            _Info.Status = 1;
            //补充下一步审核人信息
            _Info.SubmitTime = DateTime.Now;
            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;

            int result = 3;
            if (OperateType.Equals("Edit"))
            {
                result = manage.UpdateProcess(_Info);
            }
            else
            {
                result = manage.AddProcess(_Info);
            }

            if (result == -1)
            {
                string strOpertationType = OperateType.Equals("Edit") ? "编辑" : "新增";
                string strDesc = string.Format(" {0} 费用支付", strOpertationType);
                string strRemark = _Info.Remark;// OperateType.Equals("Edit") ? "" : _Info.Remark;
                manage.AddHistory(true, _Info.ObjectId, strOpertationType, strDesc, this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, strRemark);

                CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "支付审核列表（财务部融资）");

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
        private void BindNext()
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            //      ddlstNext.Items.Add(new ExtAspNet.ListItem("会计审核", "1"));
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