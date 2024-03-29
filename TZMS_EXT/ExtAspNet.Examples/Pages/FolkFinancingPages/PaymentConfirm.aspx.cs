﻿using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.FolkFinancingPages
{
    /// <summary>
    /// PaymentConfirm
    /// </summary>
    public partial class PaymentConfirm : BasePage
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


            if (!IsPostBack)
            {
                string strID = Request.QueryString["ID"];
                ObjectID = strID;
                OperateType = Request.QueryString["Type"];

                bindUserInterface(strID);
                // 绑定审批人.
                //     ApproveUser();
                // 绑定审批历史.
                BindHistory();
            }
            InitControl();
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            hlPrinter.NavigateUrl = "PaymentConfirmPrinter.aspx?ID=" + ObjectID;
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
            com.TZMS.Model.FinancingFeePaymentInfo _info = new FolkFinancingManage().GetProcessByObjectID(strID);

            // 绑定数据.
            if (_info != null)
            {
                if (!string.IsNullOrEmpty(OperateType) && OperateType.Equals("View"))
                {
                    // this.btnDismissed.Hidden = true;
                    this.btnSave.Hidden = true;
                    taAccountingRemark.Text = _info.AccountingRemark;
                    this.taAccountingRemark.Enabled = false;

                    //    this.ddlstApproveUser.Items.Add(new ListItem() { Text = _Info.NextOperaterName, Value = "0", Selected = true });
                    //   this.ddlstNext.Enabled = false;
                    //   this.ddlstApproveUser.Enabled = false;
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
                this.taAuditOpinion.Text = _info.AuditOpinion;
                this.taRemark.Text = _info.Remark;

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
        protected void btnDismissed_Click(object sender, EventArgs e)
        {
            //打回
            //saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //会计确认通过5
            saveInfo(5);
            //if (this.ddlstNext.SelectedValue.Equals(0))
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
        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存 信息.
        /// </summary>
        private void saveInfo(int status)
        {
            FolkFinancingManage manage = new FolkFinancingManage();

            com.TZMS.Model.FinancingFeePaymentInfo _Info = manage.GetProcessByObjectID(ObjectID);
            _Info.AccountingRemark = this.taAccountingRemark.Text.Trim();
            _Info.Status = status;

            //确认无下一操作人
            _Info.NextOperaterName = "";
            _Info.NextOperaterId = Guid.Empty;
            _Info.SubmitTime = DateTime.Now;

            //审批人
            if (!_Info.Adulters.Contains(this.CurrentUser.ObjectId.ToString()))
            {
                _Info.Adulters = _Info.Adulters + this.CurrentUser.ObjectId.ToString() + ";";
            }
            // 执行操作.
            int result = 3;

            result = manage.UpdateProcess(_Info);
            if (result == -1)
            {
                #region cashflow
                int itmp = new CashFlowManage().Add(new CashFlowStatementInfo()
                {
                    ObjectId = Guid.NewGuid(),
                    Amount = _Info.AmountOfPayment,
                    DateFor = DateTime.Now,
                    FlowDirection = Common.FlowDirection.Payment,
                    FlowType = "",
                    Biz = Common.Biz.FolkFinancing,
                    ProjectName = _Info.ReceivablesAccount,
                    IsAccountingAudit = 1
                });
                if (itmp != -1)
                {
                    _Info.Status = 4;
                    manage.UpdateProcess(_Info);
                    Alert.Show("操作失败!");
                    return;
                }
                #endregion

                string statusName = "已确认";//(status == 2) ? "不同意" : (status == 3) ? "同意" : "待会计审核";
                manage.AddHistory(true, _Info.ObjectId, "会计审核", string.Format("审核:{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.AccountingRemark);

                ResultMsgMore(_Info.CreaterId.ToString(), _Info.CreaterName, "您有1条支付申请，出纳会计已确认（来自财务部融资）！");

                //Alert.Show("操作成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("操作成功"));
            }
            else
            {
                Alert.Show("操作失败!");
            }
        }

        #endregion
    }
}