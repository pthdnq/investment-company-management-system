using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.FolkFinancingPages
{
    /// <summary>
    /// PaymentConfirm
    /// </summary>
    public partial class PaymentConfirm : BasePage
    {
        #region 属性
        /// <summary>
        ///  ID
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
           //     ApproveUser();
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
            com.TZMS.Model.FinancingFeePaymentInfo _info = new FolkFinancingManage().GetProcessByObjectID(strID);

            // 绑定数据.
            if (_info != null)
            {
                //#region 下一步方式
                //if (CurrentRoles.Contains(RoleType.DSZ))
                //{
                //    BindNext(true);
                //}
                //else if (CurrentRoles.Contains(RoleType.ZJL))
                //{      //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
                //    if (_info.AmountOfPayment > 3000000)
                //    { BindNext(false); HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。"; }
                //    else
                //    { BindNext(true); }
                //}
                //else
                //{
                //    BindNext(false);
                //}
                //#endregion

                this.tbPaymentAccount.Text = _info.PaymentAccount;
                this.tbReceivablesAccount.Text = _info.ReceivablesAccount;
                this.tbAmountOfPayment.Text = _info.AmountOfPayment.ToString();
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

            com.TZMS.Model.FinancingFeePaymentInfo _info = manage.GetProcessByObjectID(ObjectID);
            _info.AccountingRemark = this.taAccountingRemark.Text.Trim();
            _info.Status = status;

            // 执行操作.
            int result = 3;

            result = manage.UpdateProcess(_info);
            if (result == -1)
            {
                Alert.Show("操作成功!");
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