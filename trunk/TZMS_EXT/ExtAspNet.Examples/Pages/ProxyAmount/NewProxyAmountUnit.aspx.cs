using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class NewProxyAmountUnit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wndAccountancy.OnClientCloseButtonClick = wndAccountancy.GetHidePostBackReference();
            }
        }

        #region 私有方法

        #endregion

        #region 页面事件

        #endregion

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 设置代帐人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSetAccountancy_Click(object sender, EventArgs e)
        {
            wndAccountancy.IFrameUrl = "SelectProxyAmounter.aspx";
            wndAccountancy.Hidden = false;
        }

        /// <summary>
        /// 代帐人窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndAccountancy_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            if (e.CloseArgument != "undefined")
            {

            }
        }
    }
}