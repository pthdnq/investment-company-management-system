using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;
using TZMS;
using com.TZMS.Business;
using com.TZMS.Model;


namespace TZMS
{
    public partial class Login : BaseWebPage
    {
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //登录ajax请求
            if (Request.QueryString["name"] != null && Request.QueryString["psw"] != null)
            {
                if (CheckUserLogin(Request.QueryString["name"].ToString()
                    , Request.QueryString["psw"].ToString()))
                {
                    Response.Write("success");
                    Response.End();
                }
                else
                {
                    Response.Write("fail");
                    Response.End();
                }
                return;
            }

            if (!IsPostBack)
            {
                Session.RemoveAll();
                this.txtUserName.Focus();
            }
        }
        /// <summary>
        /// 用户验证
        /// </summary>
        /// <returns>true:验证通过 false:验证不通过</returns>
        protected bool CheckUserLogin(string name, string psw)
        {
            UserManage um = new UserManage();
            UserInfo user = um.GetUserByAccountNo(name);
            if (user == null)
            {
                return false;
            }
            if (user.Password != psw)
            {
                return false;
            }
            CurrentUser = user;
            return true;
        }


    }
}
