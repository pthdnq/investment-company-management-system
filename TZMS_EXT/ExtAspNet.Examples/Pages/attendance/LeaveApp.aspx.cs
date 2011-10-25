using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TZMS.Web
{
    public partial class LeaveApp : BasePage
    {
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //请假申请 新增按钮注册23:14
                btnNewApp.OnClientClick = newWindow.GetShowReference("LeaveAppNew.aspx") + "return false;";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DataBind()
        { 
            
        
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