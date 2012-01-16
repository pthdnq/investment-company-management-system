using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Data;

namespace TZMS.Web
{
    public partial class ProxyAmountTemplateApproveList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("dzdmbsp");

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndProxyAmountTemplateApprove.OnClientCloseButtonClick = wndProxyAmountTemplateApprove.GetHidePostBackReference();

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
            strCondition.Append(" ApproverID = '" + CurrentUser.ObjectId.ToString() + "' and ApproveOp <> 0 and ApproveOp <> 3 and ApproveOp <> 4");

            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and ProxyAmountUnitName LIKE '%" + tbxSearch.Text.Trim() + "%'");
            }

            if (ddlstAproveState.SelectedIndex == 1)
            {
                strCondition.Append(" and ApproveState = 0");
            }
            else if (ddlstAproveState.SelectedIndex == 2)
            {
                strCondition.Append(" and ApproveState = 1");
            }

            strCondition.Append(" and (ApproveDate between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "' or ApproveDate='"
                + ACommonInfo.DBMAXDate.ToString() + "')");

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "ProxyAmountTemplateApproveView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridProxyAmountTemplateApprove.PageIndex;
            _comHelp.OrderExpression = "ApproveDate desc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridProxyAmountTemplateApprove.RecordCount = _comHelp.TotalCount;
            gridProxyAmountTemplateApprove.PageSize = PageCounts;

            gridProxyAmountTemplateApprove.DataSource = dtbLeaveApproves.Rows;
            gridProxyAmountTemplateApprove.DataBind();
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
        protected void gridProxyAmountTemplateApprove_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridProxyAmountTemplateApprove.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProxyAmountTemplateApprove_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApproveID = ((GridRow)gridProxyAmountTemplateApprove.Rows[e.RowIndex]).Values[0];
            string strApplyID = ((GridRow)gridProxyAmountTemplateApprove.Rows[e.RowIndex]).Values[1];

            if (e.CommandName == "Approve")
            {
                wndProxyAmountTemplateApprove.IFrameUrl = "ProxyAmountTemplateApprove.aspx?ApproveID=" + strApproveID + "&ApplyID=" + strApplyID;
                wndProxyAmountTemplateApprove.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProxyAmountTemplateApprove_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                switch (e.Values[7].ToString())
                {
                    case "0":
                        e.Values[7] = "待审批";
                        e.Values[8] = "";
                        e.Values[9] = "";
                        if (CurrentLevel == VisitLevel.View)
                        {
                            e.Values[10] = "<span class=\"gray\">审批</span>";
                        }
                        break;
                    case "1":
                        e.Values[7] = "已审批";
                        e.Values[8] = e.Values[8].ToString() == "0" ? "同意" : "不同意";
                        e.Values[9] = DateTime.Parse(e.Values[9].ToString()).ToString("yyyy-MM-dd HH:mm");
                        e.Values[10] = e.Values[10].ToString().Replace("审批", "查看");
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 关闭事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndProxyAmountTemplateApprove_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}