using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.CashFlow
{
    /// <summary>
    /// CashFlowSetterInit
    /// </summary>
    public partial class CashFlowSetterInit : BasePage
    {
        #region 属性
  
        #endregion

        #region 页面加载及数据初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            InitControl();

            if (!IsPostBack)
            { 
                bindInterface();
            }
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
            CashFlowSetterInfo _Info = new CashFlowManage().GetCashFlowSettersByCondtion(" Status = 1 ")[0];

            // 绑定数据.
            if (_Info != null)
            {
                this.tbOriginalAmount.Text = _Info.OriginalAmount.ToString();

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
            CashFlowSetterInfo _Info = new CashFlowManage().GetCashFlowSettersByCondtion(" Status = 1 ")[0];

            if (!string.IsNullOrEmpty(this.tbOriginalAmount.Text))
            {
                _Info.OriginalAmount = decimal.Parse(this.tbOriginalAmount.Text);
            }

            // 执行操作.
            int result = 3;

            result = new CashFlowManage().UpdateCashFlowSetter(_Info);

            if (result == -1)
            {
                Alert.Show("操作成功!");
            }
            else
            {
                Alert.Show("操作失败!");
            } 
        }

        #endregion
    }
}