using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TZMS.Web
{
    public partial class ProxyAmountTemplateApplyList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNewProxy.OnClientClick = wndProxyAmountTemplateApply.GetShowReference("ProxyAmountTemplateApply.aspx?Type=Add") + "return false;";
                wndProxyAmountTemplateApply.OnClientCloseButtonClick = wndProxyAmountTemplateApply.GetHidePostBackReference();
            }
        }

        #region 私有方法
        
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
        protected void gridProxyAmountTemplateApply_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {

        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProxyAmountTemplateApply_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {

        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProxyAmountTemplateApply_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {

        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndProxyAmountTemplateApply_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {

        }

        #endregion
    }
}