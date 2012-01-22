using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using System.Text;

namespace TZMS.Web.Pages.AdminExpensesManage
{
    public partial class AdminPaymentConfirmPrinter : System.Web.UI.Page
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
            com.TZMS.Model.AdminPaymentInfo _info = new AdminPaymentManage().GetUserByObjectID(strID);

            // 绑定数据.
            if (_info != null)
            {
                this.tbProjectName.Text = _info.ProjectName;
                this.lbCause.Text = _info.Cause;


                string uper = Common.GetUperNumNames((int)_info.AmountOfPayment, string.Empty);
                lbLoanAmountUper.Text = uper;
                this.lbLoanAmount.Text = _info.AmountOfPayment.ToString();
                this.lbLoanDate.Text = _info.DateFor.ToString("yyyy年MM月dd日");

                lbApplier.Text = _info.CreaterName;
                lbPaymenter.Text = _info.AccountingName;
            
              //  this.tbDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
         
            }
        }
        #endregion
    }
}