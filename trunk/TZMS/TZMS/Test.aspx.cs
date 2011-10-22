using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;

namespace TZMS
{
    public partial class Test : System.Web.UI.Page
    {
        /// <summary>
        /// TZMS数据库链接字符串
        /// </summary>
        public string BoName
        {
            get { return "CONNECTIONSTRINGFORPROVINCE"; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserManage um = new UserManage();
            UserInfo user = new UserInfo();

            for (int i = 0; i < 1; i++)
            {
                //user.ObjectId = Guid.NewGuid();
                //user.Name = "孙副总" ;
                //user.AccountNo = "sfz" ;
                //user.JobNo = "1102" ;
                //user.Dept = "行政部";
                //user.Password = "1";
                //um.AddUser(user);
            }

            //user = um.GetUserByObjectID(BoName, "5EDAC591-E54A-4EAA-868C-E24BB5FB73B5");
            //if (user != null)
            //{
            //    user.Name = "连号";
            //    um.UpdateUser(user);
            //}
            //um.Delete(BoName, "5EDAC591-E54A-4EAA-868C-E24BB5FB73B5");

        }
    }
}