using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ExtAspNet;
using com.TZMS.Business;
using System.Data;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class NoAttendCheck : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 设置时间控件的默认值.
                dpkStartTime.SelectedDate = DateTime.Now;
                dpkEndTime.SelectedDate = DateTime.Now;

                // 处理审批窗口关闭事件.
                wndNoAttendCheck.OnClientCloseButtonClick = wndNoAttendCheck.GetHidePostBackReference();

                // 绑定部门列表.
                BindDept();

                // 绑定列表.
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

            // 设置默认值.
            ddlstDept.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGrid()
        {
            #region 查询事件

            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

            if (DateTime.Compare(startTime, endTime) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" CheckerID='" + CurrentUser.ObjectId.ToString() + "'");


            // 查询文本
            if (!string.IsNullOrEmpty(ttbSearch.Text.Trim()))
            {
                strCondition.Append("  and UserName like '%" + ttbSearch.Text.Trim() + "%'");
            }

            // 查询部门
            if (ddlstDept.SelectedText != "全部")
            {
                strCondition.Append(" and Dept='" + ddlstDept.SelectedText + "'");
            }

            // 审批状态
            switch (Convert.ToInt32(ddlstAproveState.SelectedValue))
            {
                case 1:
                    strCondition.Append(" and Checkstate = 0");
                    break;
                case 2:
                    strCondition.Append(" and Checkstate = 1");
                    break;
                default:
                    break;
            }

            // 审批时间.
            strCondition.Append(" and (CheckDateTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "' or CheckDateTime = '1900-01-01 12:00:00.000')");


            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "NoAttendView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridNoAttendCheck.PageIndex;
            _comHelp.OrderExpression = "CheckDateTime asc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridNoAttendCheck.RecordCount = _comHelp.TotalCount;
            //gridAttend.PageIndex = _comHelp.PageIndex;
            gridNoAttendCheck.PageSize = PageCounts;

            gridNoAttendCheck.DataSource = dtbLeaveApproves.Rows;
            gridNoAttendCheck.DataBind();
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridNoAttendCheck_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridNoAttendCheck.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridNoAttendCheck_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strNoAttendID = ((GridRow)gridNoAttendCheck.Rows[e.RowIndex]).Values[1];
            string strNoAttendCheckID = ((GridRow)gridNoAttendCheck.Rows[e.RowIndex]).Values[0];

            if (e.CommandName == "Approve")
            {
                wndNoAttendCheck.IFrameUrl = "NoAttendCheckForm.aspx?NoAttendID=" + strNoAttendID + "&NoAttendCheckID=" + strNoAttendCheckID;
                wndNoAttendCheck.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridNoAttendCheck_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                // 设定各列的值.
                e.Values[4] = DateTime.Parse(e.Values[4].ToString()).ToString("yyyy-MM-dd HH:mm");
                e.Values[5] = e.Values[5].ToString() + "-" + e.Values[6].ToString();
                switch (e.Values[9].ToString())
                {
                    case "0":
                        e.Values[9] = "待审批";

                        break;
                    case "1":
                        e.Values[9] = "已审批";
                        e.Values[12] = "<span class=\"gray\">审批</span>";
                        break;
                    default:
                        break;
                }

                switch (e.Values[10].ToString())
                {
                    case "0":
                        e.Values[10] = "通过";
                        break;
                    case "1":
                        e.Values[10] = "不通过";
                        break;
                    default:
                        break;
                }

                DateTime checkTime = DateTime.Parse(e.Values[11].ToString());
                if (DateTime.Compare(checkTime, ACommonInfo.DBEmptyDate) == 0)
                {
                    e.Values[11] = "";
                }
                else
                {
                    e.Values[11] = checkTime.ToString("yyyy-MM-dd HH:mm");
                }

            }
        }

        /// <summary>
        /// 审批窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNoAttendCheck_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}