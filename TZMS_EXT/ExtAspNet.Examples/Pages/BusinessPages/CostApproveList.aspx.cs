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
    public partial class CostApproveList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("ywfysp");

                wndCostApprove.OnClientCloseButtonClick = wndCostApprove.GetHidePostBackReference();

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
            strCondition.Append(" ApproverID = '" + CurrentUser.ObjectId.ToString() + "' and ApproveOp <> 0 and ApproveOp <> 3 and ApproveOp <> 4");

            // 查询文本
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append("  and CompanyName like '%" + tbxSearch.Text.Trim() + "%'");
            }

            // 物资类型.
            if (ddlstCostType.SelectedIndex != 0)
                strCondition.Append(" and CostType = " + ddlstCostType.SelectedValue);

            // 审批状态.
            if (ddlstAproveState.SelectedIndex == 1)
            {
                strCondition.Append(" and ApproveState = 0");
            }
            else if (ddlstAproveState.SelectedIndex == 2)
            {
                strCondition.Append(" and ApproveState = 1");
            }

            // 部门.
            if (ddlstDept.SelectedIndex != 0)
            {
                strCondition.Append(" and UserDept = '" + ddlstDept.SelectedText + "'");
            }

            strCondition.Append(" and (ApproveTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '"
                + endTime.ToString("yyyy-MM-dd 23:59") + "' or ApproveTime='"
                + ACommonInfo.DBMAXDate.ToString() + "')");

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "BusinessCostApproveView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridCostApprove.PageIndex;
            _comHelp.OrderExpression = "ApproveTime desc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridCostApprove.RecordCount = _comHelp.TotalCount;
            gridCostApprove.PageSize = PageCounts;
            gridCostApprove.DataSource = dtbLeaveApproves.Rows;
            gridCostApprove.DataBind();
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
        protected void gridCostApprove_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridCostApprove.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCostApprove_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApproveID = ((GridRow)gridCostApprove.Rows[e.RowIndex]).Values[0];
            string strApplyID = ((GridRow)gridCostApprove.Rows[e.RowIndex]).Values[1];

            if (e.CommandName == "Approve")
            {
                wndCostApprove.IFrameUrl = "CostApprove.aspx?ApproveID=" + strApproveID + "&ApplyID=" + strApplyID;
                wndCostApprove.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCostApprove_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[4] = DateTime.Parse(e.Values[4].ToString()).ToString("yyyy-MM-dd HH:mm");
                e.Values[6] = e.Values[6].ToString() == "0" ? "预收定金" : "业务余款";
                switch (e.Values[8].ToString())
                {
                    case "0":
                        e.Values[8] = "待审批";
                        e.Values[9] = "";
                        e.Values[10] = "";

                        if (CurrentLevel == VisitLevel.View)
                        {
                            e.Values[11] = "<span class=\"gray\">审批</span>";
                        }

                        break;
                    case "1":
                        e.Values[8] = "已审批";
                        e.Values[9] = e.Values[9].ToString() == "1" ? "同意" : "不同意";
                        e.Values[10] = DateTime.Parse(e.Values[10].ToString()).ToString("yyyy-MM-dd HH:mm");
                        e.Values[11] = e.Values[11].ToString().Replace("审批", "查看");
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 审批窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndCostApprove_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}