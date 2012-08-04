using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Business;
using System.Data;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class MaterialsPurchaseImportList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("wzcgrk");

                wndNewPurchaseImport.OnClientCloseButtonClick = wndNewPurchaseImport.GetHidePostBackReference();

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                BindDept();
                BindGrid();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定部门.
        /// </summary>
        private void BindDept()
        {
            // 设置部门下拉框的值.
            ddlstDept.Items.Add(new ExtAspNet.ListItem("全部", "-1"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.XINGZHENG, "0"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.CAIWU, "1"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.TOUZI, "2"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.YEWU, "3"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.ZJB, "4"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.JSZX, "5"));

            // 设置默认值.
            ddlstDept.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGrid()
        {
            #region 查询条件

            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

            if (DateTime.Compare(startTime, endTime) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" IsDelete <> 1 and  State = 2");

            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and MaterialsName LIKE '%" + tbxSearch.Text.Trim() + "%'");
            }
            if (ddlstWuZhiType.SelectedValue != "all")
            {
                strCondition.Append(" and MaterialsType = " + ddlstWuZhiType.SelectedValue);
            }
            if (ddlstAproveState.SelectedValue != "-1")
            {
                strCondition.Append(" and HasImport = " + ddlstAproveState.SelectedValue);
            }
            strCondition.Append(" and (ImportTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59")
                + "' or ImportTime = '" + ACommonInfo.DBMAXDate.ToString() + "')");

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "MaterialsPurchaseApplyView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridApply.PageIndex;
            _comHelp.OrderExpression = "ImportTime desc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridApply.RecordCount = _comHelp.TotalCount;
            gridApply.PageSize = PageCounts;

            gridApply.DataSource = dtbLeaveApproves.Rows;
            gridApply.DataBind();
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
        protected void gridApply_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridApply.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApproveID = ((GridRow)gridApply.Rows[e.RowIndex]).Values[0];

            if (e.CommandName == "View")
            {
                wndNewPurchaseImport.IFrameUrl = "MaterialsPurchaseImport.aspx?ID=" + strApproveID;
                wndNewPurchaseImport.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[4] = DateTime.Parse(e.Values[4].ToString()).ToString("yyyy-MM-dd HH:mm");
                e.Values[5] = e.Values[5].ToString() == "0" ? "办公用品" : "固定资产";
                e.Values[9] = DateTime.Parse(e.Values[9].ToString()).ToString("yyyy-MM-dd");
                switch (Convert.ToBoolean(e.Values[11].ToString()))
                {
                    case true:
                        e.Values[11] = "已入库";
                        e.Values[12] = DateTime.Parse(e.Values[12].ToString()).ToString("yyyy-MM-dd HH:mm");
                        e.Values[13] = e.Values[13].ToString().Replace("入库", "查看");
                        break;
                    case false:
                        e.Values[11] = "待入库";
                        e.Values[12] = "";
                        if (CurrentLevel == VisitLevel.View)
                        {
                            e.Values[13] = "<span class=\"gray\">入库</span>";
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 入库窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewPurchaseImport_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}