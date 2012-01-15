using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class SelectProxyAmounter : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSelect_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 取消选中事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUnselect_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 未选中数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUnSelectUser_RowDataBound(object sender, GridRowEventArgs e)
        {

        }

        /// <summary>
        /// 选中数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridSelectdUsers_RowDataBound(object sender, GridRowEventArgs e)
        {

        }
    }
}