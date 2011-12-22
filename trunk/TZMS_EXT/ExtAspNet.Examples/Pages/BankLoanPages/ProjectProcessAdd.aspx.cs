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
            saveInfo();
        }

        protected void cbIsAmountExpended_OnCheckedChanged(object sender, EventArgs e)
        {
            if (cbIsAmountExpended.Checked)
            {
                //    gpAmount.Hidden = false;
                tbImprestAmount.Hidden = false;
                tbAmountExpended.Hidden = false;
                tbExpendedTime.Hidden = false;
                tbUse.Hidden = false;
                tbImprestRemark.Hidden = false;
            }
            else
            {
                //   gpAmount.Hidden = true;
                tbImprestAmount.Hidden = true;
                tbAmountExpended.Hidden = true;
                tbExpendedTime.Hidden = true;
                tbUse.Hidden = true;
                tbImprestRemark.Hidden = true;
            }
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存用户信息.
        /// </summary>
        private void saveInfo()
        {
            com.TZMS.Model.BankLoanProjectProcessInfo _Info = new com.TZMS.Model.BankLoanProjectProcessInfo();
            BankLoanManage manage = new BankLoanManage();
            //  ID.
            _Info.ObjectId = Guid.NewGuid();
            _Info.ForId = new Guid(ForID);

            var bankloan = manage.GetUserByObjectID(ForID);
            _Info.ProjectName = bankloan.ProjectName;
            _Info.GuaranteeCompany = bankloan.CollateralCompany;

            _Info.ImplementationPhase = this.taImplementationPhase.Text.Trim();
            _Info.Remark = taRemark.Text.Trim();

            //备用金部分
            if (!string.IsNullOrEmpty(tbImprestAmount.Text))
            {
                _Info.ImprestAmount = Decimal.Parse(tbImprestAmount.Text.Trim());
            }

            if (!string.IsNullOrEmpty(tbAmountExpended.Text))
            {
                _Info.AmountExpended = Decimal.Parse(tbAmountExpended.Text.Trim());
            }

            //if (dpExpendedTime.SelectedDate is DateTime)
            //{
            _Info.ExpendedTime = this.tbExpendedTime.Text;
            //  }
            _Info.Use = this.tbUse.Text.Trim();
            _Info.ImprestRemark = this.tbImprestRemark.Text.Trim();

            //创建人
            _Info.CreateTime = DateTime.Now;
            _Info.CreaterAccount = this.CurrentUser.AccountNo;
            _Info.CreaterId = this.CurrentUser.ObjectId;
            _Info.CreaterName = this.CurrentUser.Name;

            _Info.SubmitTime = DateTime.Now;
            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
            //是否需备用金审核
            //  _Info.NeedImprest = (cbIsAmountExpended.Checked) ? 0 : 1;

            if (cbIsAmountExpended.Checked)
            {
                _Info.Status = 1;
                _Info.NeedImprest = 1;
            }
            else
            {
                _Info.Status = 5;
                _Info.NeedImprest = 0;
            }

            // 执行操作.
            int result = 3;
            result = manage.AddProcess(_Info);
            if (result == -1)
            {
                string strDesc = string.Format("进展新增-{0}备用金", (_Info.NeedImprest == 1) ? "申请" : "无");
                manage.AddHistory(true, _Info.ObjectId, "新增", strDesc, this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.Remark);

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