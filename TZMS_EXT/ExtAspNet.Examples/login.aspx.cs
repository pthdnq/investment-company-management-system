using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using ExtAspNet;
using com.TZMS.Business;
using com.TZMS.Model;
using System.Net;

namespace TZMS.Web
{
    public partial class login : BasePage
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadData();
                if (Request.Cookies["Info"] != null)
                {
                    this.tbxUserName.Value = Request.Cookies["Info"].Values["userName"];
                }
            }
        }

        /// <summary>
        /// 产生随机数
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// 验证码
        /// </summary>
        private void LoadData()
        {
            // Create a random code and store it in the Session object.
            Session["CaptchaImageText"] = GenerateRandomCode();
        }

        /// <summary>
        /// 生成6位随机数
        /// </summary>
        /// <returns>随机数</returns>
        private string GenerateRandomCode()
        {
            string ss = "";
            for (int i = 0; i < 6; i++)
            {
                ss = String.Concat(ss, random.Next(10).ToString());
            }
            return ss;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckUserLogin(tbxUserName.Value.Trim(), tbxPassword.Value.Trim()))
            {
                //Alert.ShowInParent("Login Successful!");
                Response.Redirect("index.aspx");
            }
            else
            {
                //Alert.ShowInParent("用户名或密码有误!", "登录", MessageBoxIcon.Information);
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('帐号或密码不正确!');</script>");

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
            //HttpCookie cookie = new HttpCookie("tzmsuser");
            //cookie.Values.Add("userID", user.ObjectId.ToString());

            //HttpCookie cookie = new HttpCookie("tzmsuser");
            //HttpCookie cookie = Request.Cookies["tzmsuser"];
            //string user_id = cookie.Values["userID"];
            HttpCookie cookie = new HttpCookie("Info");//定义cookie对象以及名为Info的项   

            DateTime dt = DateTime.Now;//定义时间对象   

            TimeSpan ts = new TimeSpan(1, 0, 0, 0);//cookie有效作用时间，具体查msdn   

            cookie.Expires = dt.Add(ts);//添加作用时间   

            cookie.Values.Add("userName", user.AccountNo);//增加属性   

            //cookie.Values.Add("userid", "1203");

            Response.AppendCookie(cookie);//确定写入cookie中   



            //string str = Request.Cookies["tzmsuser"].Value.ToString();
            Session["account"] = user.ObjectId.ToString();
            return true;
        }

    }
}
