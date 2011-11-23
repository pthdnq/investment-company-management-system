using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.InvestmentLoanPages
{
    /// <summary>
    /// ReceivablesConfirm
    /// </summary>
    public partial class ReceivablesConfirm : BasePage
    {
        #region 属性

        
        /// <summary>
        ///   ObjectID
        /// </summary>
        public string ObjectID
        {
            get
            {
                if (ViewState["ID"] == null)
                {
                    return null;
                }

                return ViewState["ID"].ToString();
            }
            set
            {
                ViewState["ID"] = value;
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
        }
        #endregion

        #region 页面及控件事件
        /// <summary>
        /// 保存员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveUserInfo();
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存用户信息.
        /// </summary>
        private void saveUserInfo()
        {
            com.TZMS.Model.ReceivablesInfo info = new InvestmentLoanManage().GetReceivableByObjectID(ObjectID);
          
            InvestmentLoanManage manage = new InvestmentLoanManage();

            // 用户ID.
            //info.ObjetctId = Guid.NewGuid();
            //info.ForId = new Guid(ForID);  

            info.AuditOpinion = taAuditOpinionRemark.Text.Trim();
            info.Status = 2;
            info.IsAccountingAudit = true;
        //    info.AccountingAccount =  ;
            info.AccountingName = "xxx";
           

            // 执行操作.
            int result = 3;

            result = manage.UpdateReceivable(info);
            if (result == -1)
            {
                Alert.Show("添加成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("添加失败!");
            }

        }

        #endregion
    }
}