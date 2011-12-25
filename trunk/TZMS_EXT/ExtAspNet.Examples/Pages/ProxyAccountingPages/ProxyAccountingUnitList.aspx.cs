using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class ProxyAccountingUnitList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("paal");

                wndUnit.Title = "新增单位";
                btnNewUnit.OnClientClick = wndUnit.GetShowReference("ProxyAccountingUnitNew.aspx?Type=Add") + "return false;";
                wndUnit.OnClientCloseButtonClick = wndUnit.GetHidePostBackReference();

                BindGrid();

                if (CurrentLevel == VisitLevel.View)
                {
                    btnNewUnit.Enabled = false;
                }
            }
        }

        #region 私有方法

        private void BindGrid()
        {
            #region 查询条件

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" IsDelete<>1 ");
            if(!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and UnitName LIKE '%" + tbxSearch.Text.Trim() + "%'");
            }

            #endregion

            // 获取
            ProxyAccountingManage _manage = new ProxyAccountingManage();
            List<ProxyAccountingUnitInfo> lstUnitInfo = _manage.GetUnitByCondition(strCondition.ToString());
            gridUnit.RecordCount = lstUnitInfo.Count;
            gridUnit.PageSize = PageCounts;
            int currentIndex = gridUnit.PageIndex;

            // 计算当前页面显示行数据
            if (lstUnitInfo.Count > gridUnit.PageSize)
            {
                if (lstUnitInfo.Count > (currentIndex + 1) * gridUnit.PageSize)
                {
                    lstUnitInfo.RemoveRange((currentIndex + 1) * gridUnit.PageSize, lstUnitInfo.Count - (currentIndex + 1) * gridUnit.PageSize);
                }
                lstUnitInfo.RemoveRange(0, currentIndex * gridUnit.PageSize);
            }
            this.gridUnit.DataSource = lstUnitInfo;
            this.gridUnit.DataBind();
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
        protected void gridUnit_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridUnit.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUnit_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strUnitID = ((GridRow)gridUnit.Rows[e.RowIndex]).Values[0];

            if (e.CommandName == "View")
            {
                wndUnit.Title = "查看单位";
                wndUnit.IFrameUrl = "ProxyAccountingUnitNew.aspx?Type=View&ID=" + strUnitID;
                wndUnit.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndUnit.Title = "编辑单位";
                wndUnit.IFrameUrl = "ProxyAccountingUnitNew.aspx?Type=Edit&ID=" + strUnitID;
                wndUnit.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                ProxyAccountingManage _manage = new ProxyAccountingManage();
                ProxyAccountingUnitInfo _info = _manage.GetUnitByObjectID(strUnitID);
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
        protected void gridUnit_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            { 
                
            }
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndUnit_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}