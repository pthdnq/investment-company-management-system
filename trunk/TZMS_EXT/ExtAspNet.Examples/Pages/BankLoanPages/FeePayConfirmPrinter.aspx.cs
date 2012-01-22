using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;

namespace TZMS.Web.Pages.BankLoanPages
{
    public partial class FeePayConfirmPrinter : System.Web.UI.Page
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
        /// 绑定指定用户ID的数据到界面.
        /// </summary>
        /// <param name="strID">用户ID</param>
        private void bindInterface(string strID)
        {
            if (string.IsNullOrEmpty(strID))
            {
                return;
            }

            // 通过 ID获取 信息实例.
            com.TZMS.Model.BankLoanProjectProcessInfo _info = new BankLoanManage().GetProcessByObjectID(strID);

            // 绑定数据.
            if (_info != null)
            {
                this.tbProjectName.Text = _info.ProjectName; 

                this.taImplementationPhase.Text = _info.Use;

                string uper = Common.GetUperNumNames((int)_info.AmountExpended, string.Empty);
                lbLoanAmountUper.Text = uper;
                this.tbAmountExpended.Text = _info.AmountExpended.ToString();
              //  this.tbImprestAmount.Text = _info.ImprestAmount.ToString();

                lbApplier.Text = _info.CreaterName;
                lbPaymenter.Text = _info.NextOperaterName;

                this.tbDate.Text = _info.CreateTime.ToString("yyyy年MM月dd日");
      
            }
        }
    }
}