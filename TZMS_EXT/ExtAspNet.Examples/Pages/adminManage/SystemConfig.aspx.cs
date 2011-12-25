using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TZMS.Web
{
    public partial class SystemConfig : BasePage
    {
        /// <summary>
        /// 页面权限模式（可查看，可编辑）
        /// </summary>
        private VisitLevel PageModel
        {
            get
            {
                if (ViewState["VisitLevel"] == null)
                {
                    ViewState["VisitLevel"] = GetCurrentLevel("xtpz");
                }
                return (VisitLevel)ViewState["VisitLevel"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //判断页面是否可编辑（可查看不用考虑）
                if (PageModel != VisitLevel.Edit && PageModel != VisitLevel.Both)
                {
                    btnNewUser.Enabled = false;
                }

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