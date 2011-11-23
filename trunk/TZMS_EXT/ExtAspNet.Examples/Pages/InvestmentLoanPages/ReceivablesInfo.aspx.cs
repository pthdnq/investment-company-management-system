using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.InvestmentLoanPages
{
    /// <summary>
    /// ReceivablesInfo
    /// </summary>
    public partial class ReceivablesInfo : BasePage
    {
        #region 属性
  
        #endregion

        #region 页面加载及数据初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            InitControl();

            if (!IsPostBack)
            {
                string strID = Request.QueryString["ID"];

               // ObjectID = strID;

                bindUserInterface(strID);
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
            tbAmountofpaidUp.Text = info.AmountofpaidUp.ToString();
            tbReceivablesAccount.Text = info.ReceivablesAccount;
            taRemark.Text = info.Remark;
            taAuditOpinionRemark.Text = info.AuditOpinion;
        }
        #endregion

        #region 页面及控件事件
        
        #endregion

        #region 自定义方法
      
        #endregion
    }
}