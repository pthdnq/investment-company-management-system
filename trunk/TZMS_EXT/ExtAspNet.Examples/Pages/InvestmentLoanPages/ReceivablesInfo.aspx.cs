using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.InvestmentLoanPages
{
    /// <summary>
    /// ReceivablesInfo
    /// </summary>
    public partial class ReceivablesInfo : BasePage
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
                // 绑定审批历史.
                BindHistory();

            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
        }

        /// <summary>
        /// 绑定指定用户ID的数据到界面.
        /// </summary>
        /// <param name="strUserID">用户ID</param>
        private void bindUserInterface(string strUserID)
        {
            //if (string.IsNullOrEmpty(strUserID))
            //{
            //    return;
            //} 
            // 通过 ID获取 信息实例.
            com.TZMS.Model.ReceivablesInfo info = new InvestmentLoanManage().GetReceivableByObjectID(strUserID);

            tbxName.Text = info.ProjectName;
            dpDueDateForReceivables.SelectedDate = info.DueDateForReceivables;
            dpDateForReceivables.SelectedDate = info.DateForReceivables;
            tbAmountofpaidUp.Text = info.AmountofpaidUpFlag + info.AmountofpaidUp.ToString();
            tbReceivablesAccount.Text = info.ReceivablesAccount;
            taRemark.Text = info.Remark;
            taAuditOpinionRemark.Text = info.AuditOpinion;
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
            List<ReceivablesAuditHistoryInfo> lstInfo = new InvestmentLoanManage().GetProcessHistoryByCondtion(strCondition.ToString());
            //lstInfo.Sort(delegate(BaoxiaoCheckInfo x, BaoxiaoCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            gridHistory.RecordCount = lstInfo.Count;
            this.gridHistory.DataSource = lstInfo;
            this.gridHistory.DataBind();
        }
        #endregion

        #region 页面及控件事件

        #endregion

        #region 自定义方法

        #endregion
    }
}