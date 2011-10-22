using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TZMS
{
    public partial class index : BaseWebPage
    {
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                if (CurrentUser == null)
                {
                    // 返回登录页面
                    Session.RemoveAll();
                    Response.Redirect("Login.aspx");
                }
                //返回ajax数据
                if (Request.QueryString["op"] != null
                    && Request.QueryString["op"].ToLower() == "initdata")
                {
                    Response.Write(CurrentUser.Name);
                    Response.End();
                }
            }
        }
    }
}