using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Data;

namespace TZMS.Web
{
    public partial class BusinessImprestApproveList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("byjsp");

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndBusinessImprestApprove.OnClientCloseButtonClick = wndBusinessImprestApprove.GetHidePostBackReference();

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

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" ApproverID = '" + CurrentUser.ObjectId.ToString() + "' and ApproveOp <> 0");

            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

            if (DateTime.Compare(startTime, endTime) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }

            // 查询文本
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append("  and UserName like '%" + tbxSearch.Text.Trim() + "%'");
            }

            // 查询部门
            if (ddlstDept.SelectedText != "全部")
            {
                strCondition.Append(" and UserDept='" + ddlstDept.SelectedText + "'");
            }

            // 审批状态
            switch (Convert.ToInt32(ddlstAproveState.SelectedValue))
            {
                case 1:
                    strCondition.Append(" and ApproveState = 0");
                    break;
                case 2:
                    strCondition.Append(" and ApproveState = 1");
                    break;
                default:
                    break;
            }

            // 审批时间.
            strCondition.Append(" and (ApproveTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59")
                + "' or ApproveTime = '" + ACommonInfo.DBMAXDate.ToString() + "')");
            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "BusinessImprestApproveView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridBusinessImprestApprove.PageIndex;
            _comHelp.OrderExpression = "ApproveTime asc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridBusinessImprestApprove.RecordCount = _comHelp.TotalCount;
            gridBusinessImprestApprove.PageSize = PageCounts;
            gridBusinessImprestApprove.DataSource = dtbLeaveApproves.Rows;
            gridBusinessImprestApprove.DataBind();
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
        protected void gridBusinessImprestApprove_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridBusinessImprestApprove.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBusinessImprestApprove_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApproveID = ((GridRow)gridBusinessImprestApprove.Rows[e.RowIndex]).Values[0];
            string strApplyID = ((GridRow)gridBusinessImprestApprove.Rows[e.RowIndex]).Values[1];

            if (e.CommandName == "Approve")
            {
                wndBusinessImprestApprove.IFrameUrl = "NewBusinessImprestApprove.aspx?ApproveID=" + strApproveID + "&ApplyID=" + strApplyID;
                wndBusinessImprestApprove.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBusinessImprestApprove_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[4] = DateTime.Parse(e.Values[4].ToString()).ToString("yyyy-MM-dd");
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
                        e.Values[9] = e.Values[9].ToString() == "0" ? "同意" : "不同意";
                        e.Values[10] = DateTime.Parse(e.Values[10].ToString()).ToString("yyyy-MM-dd HH:mm");
                        //e.Values[11] = "<span class=\"gray\">审批</span>";
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
        protected void wndBusinessImprestApprove_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}