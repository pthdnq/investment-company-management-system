using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.InvestmentLoanPages
{
    /// <summary>
    /// 支付申请add
    /// </summary>
    public partial class PaymentApplyAdd : BasePage
    {
        #region 属性
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperatorType
        {
            get
            {
                if (ViewState["OperatorType"] == null)
                {
                    return null;
                }

                return ViewState["OperatorType"].ToString();
            }
            set
            {
                ViewState["OperatorType"] = value;
            }
        }

        /// <summary>
        /// ID
        /// </summary>
        public string ID
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

            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
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
            InvestmentLoanInfo _Info = null;
            InvestmentLoanManage _Manage = new InvestmentLoanManage();

            _Info = new InvestmentLoanInfo(); 
            
            _Info.ObjectId = Guid.NewGuid();
            _Info.ProjectName = this.tbProjectName.Text.Trim();
            _Info.ProjectOverview = this.tbProjectOverview.Text.Trim();
            _Info.BorrowerNameA = this.tbBorrowerNameA.Text.Trim();
            _Info.BorrowerPhone = this.tbBorrowerPhone.Text.Trim();
            _Info.PayerBName = this.tbPayerBName.Text.Trim();
            _Info.Guarantor = this.tbGuarantor.Text.Trim();
            _Info.GuarantorPhone = this.tbGuarantorPhone.Text.Trim();
            _Info.Collateral = this.tbCollateral.Text.Trim();
            _Info.DueDateForPay = DateTime.Parse(this.dpDueDateForPay.Text);
            _Info.LoanDate = DateTime.Parse(this.dpLoanDate.Text);
            _Info.Status = 1;
            _Info.SubmitTime = DateTime.Now;
            _Info.Remark = this.tbRateOfReturn.Text.Trim();

            _Info.RateOfReturn = this.tbRateOfReturn.Text[0];
             
            // 出生日期.
            //if (dpkBirthday.SelectedDate is DateTime)
            //{
            //    _userInfo.Birthday = Convert.ToDateTime(dpkBirthday.SelectedDate);
            //}

            // 联系电话.
            // _userInfo.PhoneNumber = tbxPhoneNumber.Text.Trim();
                // 执行操作.

            int result = 3;

            result = _Manage.Add(_Info);

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