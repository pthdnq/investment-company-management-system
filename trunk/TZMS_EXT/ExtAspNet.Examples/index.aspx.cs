﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TZMS.Web
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 审批人设置注册23:14
                setChecker.OnClientClick = newSetCheckerWindow.GetShowReference(@"Pages\system\SetMyChecker.aspx") + " return false;";
                this.myMessage.OnClientClick = myMessageWindow.GetShowReference(@"Pages\system\MyMessage.aspx") + " return false;";
                this.changePsw.OnClientClick = changePswWindow.GetShowReference(@"Pages\system\ChangePsw.aspx") + " return false;";
           
            }
        }

        /// <summary>
        /// 设置审批人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Window1_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {

        }
    }
}