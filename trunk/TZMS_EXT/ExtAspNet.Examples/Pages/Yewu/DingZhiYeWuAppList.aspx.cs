using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using System.Text;
using System.Data;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class DingZhiYeWuAppList : BasePage
    {
        /// <summary>
        /// 查询Help
        /// </summary>
        public ComHelp SearchHelp
        {
            get
            {
                if (ViewState["SearchHelp%"] != null)
                {
                    return (ComHelp)ViewState["SearchHelp%"];
                }
                return new ComHelp();
            }
            set
            {
                ViewState["SearchHelp%"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wndNewYewu.OnClientCloseButtonClick = wndNewYewu.GetHidePostBackReference();
                DataBindData();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void DataBindData()
        {
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" CheckerID='" + CurrentUser.ObjectId.ToString() + "' and isdelete=0 and type = 1 and OrderIndex <> 0 and OrderIndex <> 14 and OrderIndex <> 15 ");
            strCondition.Append(" and Title like '%" + this.tbxSearch.Text.Trim() + "%' ");
            strCondition.Append(" and Checkstate = '" + this.ddlstState.SelectedValue + "' ");

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "YeWuView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridYewu.PageIndex;
            _comHelp.OrderExpression = "CheckDateTime desc";
            DataTable lstYewu = _commSelect.ComSelect(ref _comHelp);

            gridYewu.RecordCount = _comHelp.TotalCount;
            gridYewu.PageSize = PageCounts;
            this.gridYewu.DataSource = lstYewu;
            this.gridYewu.DataBind();
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
            DataBindData();
        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridYewu_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridYewu.PageIndex = e.NewPageIndex;
            DataBindData();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridYewu_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strWuZhiID = ((GridRow)gridYewu.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "CZ")
            {
                wndNewYewu.IFrameUrl = "DingZhiYeWuApp.aspx?ID=" + strWuZhiID;
                wndNewYewu.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridYewu_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                // 审批状态.
                switch (e.Values[4].ToString())
                {
                    case "0":
                        e.Values[4] = "待操作";
                        e.Values[5] = "";
                        break;
                    case "1":
                        e.Values[4] = "已操作";
                        e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd HH:mm");
                        e.Values[6] = "<span class=\"gray\">操作</span>";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 操作窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewYewu_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            DataBindData();
        }

        #endregion
    }
}