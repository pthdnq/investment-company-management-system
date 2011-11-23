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
            saveUserInfo();
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存用户信息.
        /// </summary>
        private void saveUserInfo()
        {
            com.TZMS.Model.ReceivablesInfo info = new com.TZMS.Model.ReceivablesInfo();
            InvestmentLoanManage manage = new InvestmentLoanManage();
            
            // 用户ID.
            info.ObjetctId = Guid.NewGuid();
            info.ForId = new Guid(ForID);


            info.ProjectName = manage.GetUserByObjectID(ForID).ProjectName;

            // 入职时间.
            if (dpDueDateForReceivables.SelectedDate is DateTime)
            {
                info.DueDateForReceivables = Convert.ToDateTime(dpDueDateForReceivables.SelectedDate);
            }
            // 出生日期.
            if (dpDateForReceivables.SelectedDate is DateTime)
            {
                info.DateForReceivables = Convert.ToDateTime(dpDateForReceivables.SelectedDate);
            }
            if (!string.IsNullOrEmpty(tbAmountofpaidUp.Text))
            {
                info.AmountofpaidUp = Decimal.Parse(tbAmountofpaidUp.Text.Trim());
            }
            info.ReceivablesAccount = tbReceivablesAccount.Text.Trim();


            info.Remark = taRemark.Text.Trim();
            info.Status = 1;


            // 执行操作.
            int result = 3;

            result = manage.AddReceivable(info);
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