using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class login : BasePage
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
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
        /// <returns></returns>
        private string GenerateRandomCode()
        {
            string s = "";
            for (int i = 0; i < 6; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbxCaptcha.Text != Session["CaptchaImageText"].ToString())
            {
                Alert.ShowInParent("验证码输入有误!","提示",MessageBoxIcon.Information);
                return;
            }

            if (tbxUserName.Text == "admin" && tbxPassword.Text == "admin")
            {
                Alert.ShowInParent("Login Successful!");
            }
            else
            {
                Alert.ShowInParent("Login Failed!");
            }
        }

    }
}
