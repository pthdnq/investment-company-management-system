using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TZMS.Web
{
    public partial class SystemConfig : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                newSetCheckerWindow.OnClientCloseButtonClick = newSetCheckerWindow.GetHidePostBackReference();
                btnNewUser.OnClientClick = newSetCheckerWindow.GetShowReference(@"SetPersonOfXZ.aspx") + " return false;";
                this.txtXzgd.Text = strArchiverName;
            }
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void newSetCheckerWindow_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            this.txtXzgd.Text = strArchiverName;
        }
    }
}