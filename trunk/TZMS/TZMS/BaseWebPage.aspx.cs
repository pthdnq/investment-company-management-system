using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;

namespace TZMS
{
    public partial class BaseWebPage : System.Web.UI.Page
    {
        #region 配置信息

        /// <summary>
        /// TZMS数据库链接字符串
        /// </summary>
        public string BoName
        {
            get { return "CONNECTIONSTRINGFORPROVINCE"; }
        }
        #endregion

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public UserInfo CurrentUser
        {
            get
            {
                if (Session["CurrentUser%"] == null)
                {
                    return null;
                }
                return (UserInfo)Session["CurrentUser%"];
            }
            set
            {
                Session["CurrentUser%"] = value;
            }
        }


    }
}