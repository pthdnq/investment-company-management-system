using System;
using System.Collections.Generic;
using System.Web;
using com.TZMS.Business;
using System.Web.SessionState;
using com.TZMS.Model;

namespace TZMS.Pages.system
{
    /// <summary>
    /// changePsw1 的摘要说明
    /// </summary>
    public class changePsw1 : IHttpHandler,IRequiresSessionState
    {

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            if (context.Request.QueryString["op"] != null
                && context.Request.QueryString["op"].Trim().ToLower() == "changepsw")
            {
                try
                {
                    // 修改密码 ajax 处理
                    string oldPsw = context.Request.QueryString["oldpsw"].Trim();
                    string newPsw1 = context.Request.QueryString["newpsw1"].Trim();
                    string newPsw2 = context.Request.QueryString["newpsw2"].Trim();

                    UserInfo user = (UserInfo)context.Session["CurrentUser%"];

                    if (user.Password != oldPsw)
                    {
                        context.Response.Write("old");
                        //context.Response.End();
                        return;
                    }
                    user.Password = newPsw1;
                    //更新密码
                    UserManage um = new UserManage();
                    if (um.UpdateUser(user) != 0)
                    {
                        context.Session["CurrentUser%"] = user;
                        context.Response.Write("success");
                    }
                    else
                    {
                        context.Response.Write("fail");
                    }
                }
                catch (Exception)
                {
                    context.Response.Write("exception");
                }
            }
        }

        /// <summary>
        /// 是否允许
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}