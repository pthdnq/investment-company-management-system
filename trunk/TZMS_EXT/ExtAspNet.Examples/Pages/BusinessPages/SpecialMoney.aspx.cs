using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class SpecialMoney : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 页面事件

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference("undefined"));
        }

        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference(tbxSpcialMoney.Text.Trim() + "@" + taaSpcialMoney.Text.Trim()));
        }

        #endregion

    }
}