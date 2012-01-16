using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business.ProxyAmount;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class ProxyAmountUnit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("dzdwgl");

                btnNewUnit.OnClientClick = wndProxyAmountUnit.GetShowReference("NewProxyAmountUnit.aspx?Type=Add") + "return false;";
                wndProxyAmountUnit.OnClientCloseButtonClick = wndProxyAmountUnit.GetHidePostBackReference();

                if (CurrentLevel == VisitLevel.View)
                {
                    btnNewUnit.Enabled = false;
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGrid()
        {
            #region 查询条件

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" IsDelete <> 1 ");
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and UnitName LIKE '%" + tbxSearch.Text.Trim() + "%'");
            }

            #endregion

            // 获取
            ProxyAmountManage _manage = new ProxyAmountManage();
            List<ProxyAmountUnitInfo> lstUnitInfo = _manage.GetUnitByCondition(strCondition.ToString());
            gridProxyAmountUnit.RecordCount = lstUnitInfo.Count;
            gridProxyAmountUnit.PageSize = PageCounts;
            int currentIndex = gridProxyAmountUnit.PageIndex;

            // 计算当前页面显示行数据
            if (lstUnitInfo.Count > gridProxyAmountUnit.PageSize)
            {
                if (lstUnitInfo.Count > (currentIndex + 1) * gridProxyAmountUnit.PageSize)
                {
                    lstUnitInfo.RemoveRange((currentIndex + 1) * gridProxyAmountUnit.PageSize, lstUnitInfo.Count - (currentIndex + 1) * gridProxyAmountUnit.PageSize);
                }
                lstUnitInfo.RemoveRange(0, currentIndex * gridProxyAmountUnit.PageSize);
            }
            this.gridProxyAmountUnit.DataSource = lstUnitInfo;
            this.gridProxyAmountUnit.DataBind();
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProxyAmountUnit_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridProxyAmountUnit.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProxyAmountUnit_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strUnitID = ((GridRow)gridProxyAmountUnit.Rows[e.RowIndex]).Values[0];

            if (e.CommandName == "View")
            {
                wndProxyAmountUnit.IFrameUrl = "NewProxyAmountUnit.aspx?Type=View&ID=" + strUnitID;
                wndProxyAmountUnit.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndProxyAmountUnit.IFrameUrl = "NewProxyAmountUnit.aspx?Type=Edit&ID=" + strUnitID;
                wndProxyAmountUnit.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                ProxyAmountManage _manage = new ProxyAmountManage();
                ProxyAmountUnitInfo _info = _manage.GetUnitByObjectID(strUnitID);
                if (_info != null)
                {
                    _info.IsDelete = true;
                    int result = _manage.UpdateUnit(_info);

                    BindGrid();
                }
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProxyAmountUnit_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                if (CurrentLevel == VisitLevel.View)
                {
                    e.Values[7] = "<span class=\"gray\">编辑</span>";
                    e.Values[8] = "<span class=\"gray\">删除</span>";
                }
            }
        }

        /// <summary>
        /// 新增窗口挂关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndProxyAmountUnit_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}