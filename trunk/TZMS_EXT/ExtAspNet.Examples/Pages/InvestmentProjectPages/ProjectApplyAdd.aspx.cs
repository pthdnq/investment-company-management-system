using System;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.InvestmentProjectPages
{
    /// <summary>
    /// ProjectApplyAdd
    /// </summary>
    public partial class ProjectApplyAdd : BasePage
    {
        #region 属性 
        /// <summary>
        /// ID
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
                // 绑定下一步.
                BindNext();
                // 绑定审批人.
                ApproveUser();
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
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
            saveInfo();

        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存信息.
        /// </summary>
        private void saveInfo()
        {
            InvestmentProjectInfo _Info = new InvestmentProjectInfo();
            InvestmentProjectManage manage = new InvestmentProjectManage();
             
            _Info.ObjectId = Guid.NewGuid();
            _Info.ProjectName = this.tbProjectName.Text.Trim();
            _Info.ProjectOverview = this.tbProjectOverview.Text.Trim();
            _Info.CustomerName = this.tbCustomerName.Text.Trim();
        
            _Info.Contact = this.tbContact.Text.Trim();
            _Info.ContactPhone = this.tbContactPhone.Text.Trim();
            _Info.ContractAmount =decimal.Parse( this.tbContractAmount.Text.Trim());
            _Info.DownPayment =decimal.Parse( this.tbDownPayment.Text.Trim());
            _Info.SignDate = this.dpSignDate.SelectedDate.Value;
            _Info.Remark = this.tbRemark.Text.Trim();
            _Info.Status = 1;
            //补充申请人及下一步审核人信息
            _Info.SubmitTime = DateTime.Now;
            _Info.CreateTime = DateTime.Now;
            _Info.CreaterId = this.CurrentUser.ObjectId;
            _Info.CreaterName = this.CurrentUser.Name;
            _Info.CreaterAccount = this.CurrentUser.AccountNo;
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            
            //会计审核

            _Info.NextBAOperaterName = this.ddlstApproveUserBA.SelectedText;
            _Info.NextBAOperaterId = new Guid(this.ddlstApproveUserBA.SelectedValue);
            _Info.SubmitBATime = DateTime.Now;
            _Info.BAStatus = 1;  
            // 执行操作.
            int result = 3;
            result = manage.Add(_Info);
            if (result == -1)
            {
                manage.AddHistory(_Info.ObjectId, "申请", "项目申请", this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, "");
                new CashFlowManage().AddHistory(_Info.ObjectId, "申请", "投资部实施项目申请", this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.Remark,"InvestmentProject");
           
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

            ddlstNextBA.Items.Add(new ExtAspNet.ListItem("会计核算", "0"));
            ddlstNextBA.SelectedIndex = 0;

        }

        /// <summary>
        /// 绑定审批人
        /// </summary>
        private void ApproveUser()
        {
            foreach (UserInfo user in CurrentChecker)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
                ddlstApproveUserBA.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
        
            }

            ddlstApproveUser.SelectedIndex = 0;
            ddlstApproveUserBA.SelectedIndex = 0;
     
        }
        #endregion
    }
}