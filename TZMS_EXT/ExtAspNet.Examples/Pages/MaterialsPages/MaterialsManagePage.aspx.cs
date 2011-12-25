using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class MaterialsManagePage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("wzgl");

                wndNewMaterials.OnClientCloseButtonClick = wndNewMaterials.GetHidePostBackReference();
                wndMaterialComsume.OnClientCloseButtonClick = wndMaterialComsume.GetHidePostBackReference();

                BindType();
                BindGrid();

                if (CurrentLevel == VisitLevel.View)
                {
                    btnNewMaterials.Enabled = false;
                }
            }
        }

        #region 私有方法

        private void BindType()
        {
            ddlstType.Items.Add(new ExtAspNet.ListItem("办公用品", "0"));
            //if (CurrentRoles.Contains(RoleType.WZSQ_GD))
            //{
            ddlstType.Items.Add(new ExtAspNet.ListItem("固定资产", "1"));
            //}

            ddlstType.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGrid()
        {
            #region 查询条件

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" IsDelete <> 1");

            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and MaterialsName Like '%" + tbxSearch.Text.Trim() + "%'");
            }

            strCondition.Append(" and MaterialsType = " + ddlstType.SelectedValue);
            strCondition.Append(" order by CurrentNumbers desc");

            #endregion

            List<MaterialsManageInfo> lstMaterialsManage = new MaterialsManage().GetMaterialsByCondition(strCondition.ToString());
            this.gridMaterials.RecordCount = lstMaterialsManage.Count;
            this.gridMaterials.PageSize = PageCounts;
            int currentIndex = this.gridMaterials.PageIndex;
            //计算当前页面显示行数据
            if (lstMaterialsManage.Count > this.gridMaterials.PageSize)
            {
                if (lstMaterialsManage.Count > (currentIndex + 1) * this.gridMaterials.PageSize)
                {
                    lstMaterialsManage.RemoveRange((currentIndex + 1) * this.gridMaterials.PageSize, lstMaterialsManage.Count - (currentIndex + 1) * this.gridMaterials.PageSize);
                }
                lstMaterialsManage.RemoveRange(0, currentIndex * this.gridMaterials.PageSize);
            }
            this.gridMaterials.DataSource = lstMaterialsManage;
            this.gridMaterials.DataBind();
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
        protected void gridMaterials_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridMaterials.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridMaterials_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strObjectID = ((GridRow)gridMaterials.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "View")
            {
                wndNewMaterials.Title = "查看物资";
                wndNewMaterials.IFrameUrl = "NewMaterials.aspx?Type=View&ID=" + strObjectID;
                wndNewMaterials.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndNewMaterials.Title = "编辑物资";
                wndNewMaterials.IFrameUrl = "NewMaterials.aspx?Type=Edit&ID=" + strObjectID;
                wndNewMaterials.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                MaterialsManage _manage = new MaterialsManage();
                MaterialsManageInfo _manageInfo = _manage.GetMaterialByObjectID(strObjectID);
                if (_manageInfo != null)
                {
                    _manageInfo.IsDelete = true;
                    _manage.UpdateMaterial(_manageInfo);

                    BindGrid();
                }
            }

            if (e.CommandName == "Comsume")
            {
                wndMaterialComsume.IFrameUrl = "MaterialsComsume.aspx?ID=" + strObjectID;
                wndMaterialComsume.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridMaterials_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                switch (e.Values[1].ToString())
                {
                    case "0":
                        e.Values[1] = "办公用品";
                        break;
                    case "1":
                        e.Values[1] = "固定资产";
                        break;
                    default:
                        break;
                }

                if (Convert.ToInt32(e.Values[4].ToString()) == 0)
                {
                    e.Values[5] = e.Values[5].ToString().Replace("领用", "领用历史");
                    //e.Values[5] = "<span class=\"gray\">领用</span>";
                }

                if (CurrentLevel == VisitLevel.View)
                {
                    if (Convert.ToInt32(e.Values[4].ToString()) != 0)
                    { 
                        e.Values[5] = "<span class=\"gray\">领用</span>";
                    }

                    e.Values[7] = "<span class=\"gray\">编辑</span>";
                    e.Values[8] = "<span class=\"gray\">删除</span>";
                }
            }
        }

        /// <summary>
        /// 申请事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNewMaterials_Click(object sender, EventArgs e)
        {
            wndNewMaterials.Title = "新增物资";
            wndNewMaterials.IFrameUrl = "NewMaterials.aspx?Type=Add";
            wndNewMaterials.Hidden = false;
        }

        /// <summary>
        /// 物资窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewMaterials_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 领用窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndMaterialComsume_Close(object sender, WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}