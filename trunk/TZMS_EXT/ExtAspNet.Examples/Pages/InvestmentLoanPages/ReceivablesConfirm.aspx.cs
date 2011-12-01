using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

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
        /// <param name="strUserID">用户ID</param>
        private void bindUserInterface(string strUserID)
        {
            //if (string.IsNullOrEmpty(strUserID))
            //{
            //    return;
            //} 
            // 通过 ID获取 信息实例.
            com.TZMS.Model.ReceivablesInfo info = new InvestmentLoanManage().GetReceivableByObjectID(strUserID);
           
            tbProjectName.Text = info.ProjectName;
            dpDueDateForReceivables.SelectedDate = info.DueDateForReceivables;
            dpDateForReceivables.SelectedDate = info.DateForReceivables;
            tbAmountofpaidUp.Text = info.AmountofpaidUp.ToString(); 
            tbReceivablesAccount.Text = info.ReceivablesAccount;   
            taRemark.Text = info.Remark;
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
        /// <summary>
        /// 保存 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //确认5
            saveInfo(5);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存 信息.
        /// </summary>
        private void saveInfo(int status)
        {
            com.TZMS.Model.ReceivablesInfo _Info = new InvestmentLoanManage().GetReceivableByObjectID(ObjectID);
          
            InvestmentLoanManage manage = new InvestmentLoanManage();

            //  ID.
            //info.ObjetctId = Guid.NewGuid();
            //info.ForId = new Guid(ForID);  

            _Info.AuditOpinion = taAuditOpinionRemark.Text.Trim();
            _Info.Status = status;
            _Info.IsAccountingAudit = true;
     
            // 执行操作.
            int result = 3;

            result = manage.UpdateReceivable(_Info);
            if (result == -1)
            {
                string statusName = "已确认";//(status == 2) ? "不同意" : (status == 3) ? "同意" : "待会计审核";
                manage.AddHistory(true, _Info.ObjetctId, "会计审核", string.Format("审核:{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.AuditOpinion);

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