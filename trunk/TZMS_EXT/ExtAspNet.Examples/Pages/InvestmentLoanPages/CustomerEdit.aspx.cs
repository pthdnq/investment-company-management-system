using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.InvestmentLoanPages
{
    public partial class CustomerEdit : BasePage
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
            if (!IsPostBack)
            {
                string strID = Request.QueryString["ID"];
                ObjectID = strID;
                bindInterface();
            }
            InitControl();
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetHideReference();
        }



        /// <summary>
        /// 绑定指定用户ID的数据到界面.
        /// </summary>
        /// <param name="strUserID">用户ID</param>
        private void bindInterface()
        {

            // 通过 ID获取 信息实例.
            CustomerInfo _Info = new InvestmentLoanManage().GetCustomerByObjectID(ObjectID);

            // 绑定数据.
            if (_Info != null)
            {
                this.tbName.Text = _Info.Name;
                this.tbMobilePhone.Text = _Info.MobilePhone;


                int icount = Math.Abs(_Info.CreditScore) / 20;
                string strIcons = "";
                string strIconsType = (_Info.CreditScore > 0) ? "★" : "ㄣ";

                for (int i = 0; i < icount; i++)
                {
                    strIcons += strIconsType;
                }

                this.lbCreditScore.Text = _Info.CreditScore.ToString() + "  " + strIcons;
            }
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
        /// 保存信息.
        /// </summary>
        private void saveInfo()
        {
            InvestmentLoanManage manage = new InvestmentLoanManage();
            CustomerInfo _Info = manage.GetCustomerByObjectID(ObjectID);

            if (!string.IsNullOrEmpty(this.tbName.Text))
            {
                _Info.Name = this.tbName.Text.Trim();
            }
            _Info.MobilePhone = this.tbMobilePhone.Text.Trim();

            // 执行操作.
            int result = 3;

            result = manage.UpdateCustomer(_Info);

            if (result == -1)
            {
                manage.UpdateCustomerLoanInfo(_Info);

                Alert.Show("操作成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("操作失败!");
            }
        }

        #endregion
    }
}