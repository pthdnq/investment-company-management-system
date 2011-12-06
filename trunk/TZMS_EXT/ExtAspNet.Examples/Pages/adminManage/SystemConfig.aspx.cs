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
                btnNewUser.OnClientClick = newSetCheckerWindow.GetShowReference(@"SetPersonOfXZ.aspx") + " return false;";
            }
        }
    }
}