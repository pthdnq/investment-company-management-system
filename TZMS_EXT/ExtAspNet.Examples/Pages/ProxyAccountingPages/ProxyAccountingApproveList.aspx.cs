using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Business;
using System.Data;

namespace TZMS.Web
{
    public partial class ProxyAccountingApproveList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndApprove.OnClientCloseButtonClick = wndApprove.GetHidePostBackReference();

                BindGrid();
            }
        }

        #region 私有方法

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
            strCondition.Append(" ApproverID = '" + CurrentUser.ObjectId.ToString() + "'");

            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and PayUnitName LIKE '%" + tbxSearch.Text.Trim() + "%'");
            }

            if (ddlstAproveState.SelectedIndex == 1)
            {
                strCondition.Append(" and ApproveState = 0");
            }
            else if (ddlstAproveState.SelectedIndex == 2)
            {
                strCondition.Append(" and ApproveState = 1");
            }

            strCondition.Append(" and (ApproveDate between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "' or ApproveDate='1900-01-01 12:00:00.000')");

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "ProxyAccountingView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridApprove.PageIndex;
            _comHelp.OrderExpression = "ApproveDate desc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridApprove.RecordCount = _comHelp.TotalCount;
            gridApprove.PageSize = PageCounts;

            gridApprove.DataSource = dtbLeaveApproves.Rows;
            gridApprove.DataBind();
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
        protected void gridApprove_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridApprove.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApprove_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApproveID = ((GridRow)gridApprove.Rows[e.RowIndex]).Values[0];
            string strApplyID = ((GridRow)gridApprove.Rows[e.RowIndex]).Values[1];

            if (e.CommandName == "Approve")
            {
                wndApprove.IFrameUrl = "ProxyAccountingApprove.aspx?ApproveID=" + strApproveID + "&ApplyID=" + strApplyID;
                wndApprove.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApprove_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[8] = DateTime.Parse(e.Values[8].ToString()).ToString("yyyy-MM-dd");
                e.Values[9] = Company;
                switch (e.Values[10].ToString())
                {
                    case "0":
                        e.Values[10] = "待审批";
                        e.Values[11] = "";
                        e.Values[12] = "";
                        break;
                    case "1":
                        e.Values[10] = "已审批";
                        e.Values[11] = e.Values[11].ToString() == "0" ? "同意" : "不同意";
                        e.Values[12] = DateTime.Parse(e.Values[12].ToString()).ToString("yyyy-MM-dd HH:mm");
                        e.Values[13] = "<span class=\"gray\">审批</span>";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 审评窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndApprove_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}