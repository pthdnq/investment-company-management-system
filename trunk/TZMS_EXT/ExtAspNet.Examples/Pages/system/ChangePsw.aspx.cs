using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class ChangePsw : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.tbxOldPsw.Text.Trim() != CurrentUser.Password)
            {
                Alert.Show("您输入的密码有误！");
                return;
            }
            if (this.tbxOldPsw2.Text.Trim() != this.tbxOldPsw1.Text.Trim())
            {
                Alert.Show("您两次输入的密码不一致！");
                return;
            }
            UserInfo user = CurrentUser;
            user.Password = this.tbxOldPsw1.Text.Trim();
            UserManage um = new UserManage();
            if (um.UpdateUser(user) != 0)
            {
                CurrentUser = user;
                //Alert.Show("修改密码成功！");
                PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("服务器忙，请重试！");
            }
        }
    }
}