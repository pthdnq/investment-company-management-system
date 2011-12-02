using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TZMS.Web
{
    public partial class MySalary : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 私有方法

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGrid()
        { }

        #endregion

        #region 页面事件

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridSalary_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {

        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridSalary_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {

        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridSalary_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {

        }

        #endregion
    }
}