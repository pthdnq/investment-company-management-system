using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TZMS.Web.Pages
{
    public partial class MyMessageList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                BindGrid();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGrid()
        { 
            
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridMessage_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {

        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridMessage_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {

        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridMessage_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {

        }

        /// <summary>
        /// 查看窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndViewMessage_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {

        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}