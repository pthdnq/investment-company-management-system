using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TZMS.Web
{
    public partial class LeaveApp : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnNewApp.OnClientClick = newWindow.GetShowReference("MyCheckApp.aspx") + "return false;";
            }
        }

        /// <summary>
        /// 我要请假 页面关闭时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Window1_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            
        }
    }
}