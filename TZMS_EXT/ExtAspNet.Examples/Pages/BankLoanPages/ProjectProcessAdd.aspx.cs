using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.BankLoanPages
{
    /// <summary>
    /// ProjectProcessAdd
    /// </summary>
    public partial class ProjectProcessAdd : BasePage
    {
        #region 属性

        /// <summary>
        ///  ForID
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
            com.TZMS.Model.BankLoanProjectProcessInfo _Info = new com.TZMS.Model.BankLoanProjectProcessInfo();
            BankLoanManage manage = new BankLoanManage();

            //  ID.
            _Info.ObjectId = Guid.NewGuid();
            _Info.ForId = new Guid(ForID);

            var bankloan = manage.GetUserByObjectID(ForID);
            _Info.ProjectName = bankloan.ProjectName;

            _Info.ImplementationPhase = this.taImplementationPhase.Text.Trim();
           
            //  info.LoanBank= bankloan.
            if (dpExpendedTime.SelectedDate is DateTime)
            {
                _Info.ExpendedTime = this.dpExpendedTime.SelectedDate.Value;
            }

            if (!string.IsNullOrEmpty(tbAmountExpended.Text))
            {
                _Info.AmountExpended = Decimal.Parse(tbAmountExpended.Text.Trim());
            }
            if (!string.IsNullOrEmpty(tbImprestAmount.Text))
            {
                _Info.ImprestAmount = Decimal.Parse(tbImprestAmount.Text.Trim());
            }

            _Info.Remark = taRemark.Text.Trim();

            _Info.CreateTime = DateTime.Now;
            _Info.SubmitTime = DateTime.Now;
            _Info.CreaterAccount = this.CurrentUser.AccountNo;
            _Info.CreaterId = this.CurrentUser.ObjectId;
            _Info.CreaterName = this.CurrentUser.Name;
            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
            _Info.NeedImprest = (_Info.AmountExpended == 0) ? 0 : 1;
  
            _Info.Status = 1;

            // 执行操作.
            int result = 3;
            result = manage.AddProcess(_Info);
            if (result == -1)
            {
                manage.AddHistory(true, _Info.ObjectId, "新增", "新增进展", this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.Remark);
           
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
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
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