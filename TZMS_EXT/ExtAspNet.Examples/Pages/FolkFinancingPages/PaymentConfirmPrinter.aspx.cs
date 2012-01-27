using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using System.Text;

namespace TZMS.Web.Pages.FolkFinancingPages
{
    public partial class PaymentConfirmPrinter : BasePage
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

        #region 初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strID = Request.QueryString["ID"];
                ObjectID = strID;

                bindInterface(strID);
                //BindHistory();
            }
        }

        /// <summary>
        /// 绑定指定 ID的数据到界面.
        /// </summary>
        /// <param name="strID">用户ID</param>
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
                this.tbProjectName.Text = "民间融资支付确认";
                this.lbLenders.Text = _info.PaymentAccount;
                this.lbBorrowerNameA.Text = _info.ReceivablesAccount;
                string uper = Common.GetUperNumNames((int)_info.AmountOfPayment, string.Empty);
                lbLoanAmountUper.Text = uper;
                this.lbLoanAmount.Text = _info.AmountOfPayment.ToString();
                this.lbLoanDate.Text = _info.DateForPay.ToString("yyyy年MM月dd日");
                lbApplier.Text = _info.CreaterName;
                lbPaymenter.Text = this.CurrentUser.Name;
                //     this.taRemark.Text = _info.Remark;
                //     this.taAuditOpinion.Text = _info.AuditOpinion;
                //if (DateTime.Compare(_info.ExpendedTime, DateTime.Parse("1900-1-1 12:00")) != 0)
                //{
                //this.tbDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
                //    }
                string strCondition = string.Format("ForId = '{0}'  ORDER BY OperationTime ASC", _info.ObjectId);
                List<com.TZMS.Model.FinancingFeePaymentHistoryInfo> lstInfo = new FolkFinancingManage().GetProcessHistoryByCondtion(strCondition.ToString());
                StringBuilder strHistory = new StringBuilder();
                foreach (var info in lstInfo)
                {
                    strHistory.Append(string.Format("<br/>{1}于{0:yyyy年MM月dd日}{2}", info.OperationTime, info.OperationerName, info.OperationDesc));
                }
                lbHistory.Text = strHistory.ToString();
            }
        }
        #endregion
    }
}