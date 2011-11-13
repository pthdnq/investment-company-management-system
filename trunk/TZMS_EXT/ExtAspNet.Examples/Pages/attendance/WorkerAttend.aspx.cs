using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TZMS.Web
{
    public partial class WorkerAttend : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 点击导入按钮触发事件.
                btnImport.OnClientClick = wndImportAttend.GetShowReference("ImportWorkerAttend.aspx") + "return false;";
                wndImportAttend.OnClientCloseButtonClick = wndImportAttend.GetHidePostBackReference();


            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定Grid
        /// </summary>
        private void BindGrid()
        {
            #region 查询事件

            #endregion
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridAttend_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {

        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridAttend_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {

        }

        /// <summary>
        /// 导入窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndImportAttend_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {

        }

        #endregion
    }
}