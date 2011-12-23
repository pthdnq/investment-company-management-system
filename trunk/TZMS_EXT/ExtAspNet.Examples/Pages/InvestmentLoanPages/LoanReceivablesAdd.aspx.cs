using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.InvestmentLoanPages
{
    /// <summary>
    /// LoanReceivablesAdd
    /// </summary>
    public partial class LoanReceivablesAdd : BasePage
    {
        #region 属性

        /// <summary>
        ///  ID
        /// </summary>
        public string ForID
        {
            get
            {
                if (ViewState["ForID"] == null)
                {
                    return null;
                }

                return ViewState["ForID"].ToString();
            }
            set
            {
                ViewState["ForID"] = value;
            }
        }
        #endregion

        #region 页面加载及数据初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            InitControl();

            if (!IsPostBack)
            {
                BindDept();

                string strID = Request.QueryString["ID"]; 
                ForID = strID; 
                bindUserInterface(strID);
                // 绑定下一步.
                BindNext();
                // 绑定审批人.
                ApproveUser();
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }

        /// <summary>
        /// 绑定部门.
        /// </summary>
        private void BindDept()
        {
            // 设置部门下拉框的值.
            //ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.XINGZHENG, "行政部"));
            //ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.CAIWU, "财务部"));
            //ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.TOUZI, "投资部"));
            //ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.YEWU, "业务部"));

            //// 设置默认值.
            //ddlstDept.SelectedIndex = 0;
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
            // 通过用户ID获取用户信息实例.
            //   com.TZMS.Model.ReceivablesInfo Info _userInfo = new  InvestmentLoanManage ().GetReceivableByObjectID(strUserID);


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
            saveInfo();
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存用户信息.
        /// </summary>
        private void saveInfo()
        {
            com.TZMS.Model.ReceivablesInfo _Info = new com.TZMS.Model.ReceivablesInfo();
       
            InvestmentLoanManage manage = new InvestmentLoanManage();
             
            _Info.ObjectId = Guid.NewGuid();
            _Info.ForId = new Guid(ForID); 

            _Info.ProjectName = manage.GetUserByObjectID(ForID).ProjectName;
 
            if (dpDueDateForReceivables.SelectedDate is DateTime)
            {
                _Info.DueDateForReceivables = Convert.ToDateTime(dpDueDateForReceivables.SelectedDate);
            }
         
            if (dpDateForReceivables.SelectedDate is DateTime)
            {
                _Info.DateForReceivables = Convert.ToDateTime(dpDateForReceivables.SelectedDate);
            }
            if (!string.IsNullOrEmpty(tbAmountofpaidUp.Text))
            {
                _Info.AmountofpaidUp = Decimal.Parse(tbAmountofpaidUp.Text.Trim());
            }
            _Info.ReceivablesAccount = tbReceivablesAccount.Text.Trim();


            _Info.Remark = taRemark.Text.Trim();
            //等待会计收款确认
            _Info.Status = 4;
        
            //  创建人
            _Info.CreateTime = DateTime.Now;
            _Info.CreaterId = this.CurrentUser.ObjectId;
            _Info.CreaterName = this.CurrentUser.Name;
            _Info.AccountingName = this.ddlstApproveUser.SelectedText;
         //   暂用AccountingAccount存储，待修改
            _Info.AccountingAccount = this.ddlstApproveUser.SelectedValue;
        
          //下一步操作人 

            // 执行操作.
            int result = 3;

            result = manage.AddReceivable(_Info);
            if (result == -1)
            {
                manage.AddHistory(true,_Info.ObjectId, "新增", "新增收款信息", this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, string.Empty);
           
                Alert.Show("添加成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("添加失败!");
            }

        }

        /// <summary>
        /// 绑定下一步
        /// </summary>
        private void BindNext()
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("收款确认", "0"));
            //   ddlstNext.Items.Add(new ExtAspNet.ListItem("会计审核", "1"));
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