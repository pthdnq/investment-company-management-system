using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.InvestmentProjectPages
{
    /// <summary>
    /// ProjectApplyEdit
    /// </summary>
    public partial class ProjectApplyEdit : BasePage
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
                string strID = Request.QueryString["ID"];
                bindInterface(strID);
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
        }


        /// <summary>
        /// 绑定指定用户ID的数据到界面.
        /// </summary>
        /// <param name="strID">用户ID</param>
        private void bindInterface(string strID)
        {
            if (string.IsNullOrEmpty(strID))
            {
                return;
            }
            ObjectID = strID;

            InvestmentProjectInfo _Info = new InvestmentProjectManage().GetUserByObjectID(strID);
           
            this.tbProjectName.Text = _Info.ProjectName;
            this.tbProjectOverview.Text = _Info.ProjectOverview;
            this.tbCustomerName.Text = _Info.CustomerName;

            this.tbContact.Text = _Info.Contact;
            this.tbContactPhone.Text = _Info.ContactPhone;
            this.tbContractAmount.Text = _Info.ContractAmount.ToString();
            this.tbDownPayment.Text = _Info.DownPayment.ToString();
            this.dpSignDate.SelectedDate = _Info.SignDate;
            this.tbRemark.Text = _Info.Remark;
             
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
            InvestmentProjectManage _Manage = new InvestmentProjectManage();
            InvestmentProjectInfo _Info = _Manage.GetUserByObjectID(ObjectID);

            _Info.ProjectName = this.tbProjectName.Text.Trim();
            _Info.ProjectOverview = this.tbProjectOverview.Text.Trim();
            _Info.CustomerName = this.tbCustomerName.Text.Trim();

            _Info.Contact = this.tbContact.Text.Trim();
            _Info.ContactPhone = this.tbContactPhone.Text.Trim();
            _Info.ContractAmount = decimal.Parse(this.tbContractAmount.Text.Trim());
            _Info.DownPayment = decimal.Parse(this.tbDownPayment.Text.Trim());
            _Info.SignDate = this.dpSignDate.SelectedDate.Value;
            _Info.Remark = this.tbRemark.Text.Trim();
            _Info.Status = 1;
            //补充申请人及下一步审核人信息
            _Info.SubmitTime = DateTime.Now;

            // 出生日期.
            //if (dpkBirthday.SelectedDate is DateTime)
            //{
            //    _userInfo.Birthday = Convert.ToDateTime(dpkBirthday.SelectedDate);
            //} 

            int result = 3;

            result = _Manage.Update(_Info);

            if (result == -1)
            {
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