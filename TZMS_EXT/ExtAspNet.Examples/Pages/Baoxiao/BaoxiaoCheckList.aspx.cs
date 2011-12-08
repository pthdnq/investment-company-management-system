using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using com.TZMS.Business;
using System.Text;
using ExtAspNet;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class BaoxiaoCheckList : BasePage
    {
        /// <summary>
        /// 查询文本
        /// </summary>
        public string SearchText
        {
            get
            {
                if (ViewState["SearchText"] == null)
                {
                    return null;
                }
                return ViewState["SearchText"].ToString();
            }

            set
            {
                ViewState["SearchText"] = value;
            }
        }

        /// <summary>
        /// 查询部门
        /// </summary>
        public string SearchDept
        {
            get
            {
                if (ViewState["SearchDept"] == null)
                {
                    return null;
                }

                return ViewState["SearchDept"].ToString();
            }

            set
            {
                ViewState["SearchDept"] = value;
            }
        }

        /// <summary>
        /// 查询审批状态
        /// 0表示未审批，1表示已审批.
        /// </summary>
        public int SearchApproveState
        {
            get
            {
                if (ViewState["ApproveState"] == null)
                {
                    return 0;
                }

                return Convert.ToInt32(ViewState["ApproveState"].ToString());
            }

            set
            {
                ViewState["ApproveState"] = value;
            }
        }

        /// <summary>
        /// 查询时间范围
        /// </summary>
        public int SearchDateRange
        {
            get
            {
                if (ViewState["DateRange"] == null)
                {
                    return 0;
                }

                return Convert.ToInt32(ViewState["DateRange"].ToString());
            }

            set
            {
                ViewState["DateRange"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 设置默认时间.
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                // 处理审批窗口关闭事件.
                wndBaoxiaoCheck.OnClientCloseButtonClick = wndBaoxiaoCheck.GetHidePostBackReference();

                // 绑定部门和列表.
                BindDept();
                BindGrid(SearchText, SearchDept, SearchApproveState, SearchDateRange);
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

            SearchText = string.Empty;
            SearchDept = ddlstDept.SelectedText;
            SearchApproveState = Convert.ToInt32(ddlstAproveState.SelectedValue);
            //SearchDateRange = Convert.ToInt32(ddldateRange.SelectedValue);
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGrid(string strSearchText, string strSearchDept, int nApproveState, int nDateRange)
        {
            #region 查询条件

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" CheckerID = '" + CurrentUser.ObjectId.ToString() + "' and CheckOp <> '0'");
            strCondition.Append(" and Isdelete = 0");

            // 查询文本
            if (!string.IsNullOrEmpty(strSearchText))
            {
                strCondition.Append("  and UserName like '%" + strSearchText + "%'");
            }

            // 查询部门
            if (!string.IsNullOrEmpty(strSearchDept) && strSearchDept != "全部")
            {
                strCondition.Append(" and Dept='" + strSearchDept + "'");
            }

            // 审批状态
            switch (nApproveState)
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

            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);
            strCondition.Append(" and (CheckDateTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "' or CheckDateTime='1900-01-01 12:00:00.000')");
            //// 审批时间
            //DateTime dateTimeNow = DateTime.Now;
            //switch (nDateRange)
            //{
            //    case 1:
            //        strCondition.Append(" and (CheckDateTime >= '" + dateTimeNow.AddMonths(-1).ToString("yyyy-MM-dd") + "' or CheckDateTime='1900-01-01 12:00:00.000')");
            //        break;
            //    case 2:
            //        strCondition.Append(" and (CheckDateTime >= '" + dateTimeNow.AddMonths(-3).ToString("yyyy-MM-dd") + "' or CheckDateTime='1900-01-01 12:00:00.000')");
            //        break;
            //    case 3:
            //        strCondition.Append(" and (CheckDateTime >= '" + dateTimeNow.AddMonths(-6).ToString("yyyy-MM-dd") + "' or CheckDateTime='1900-01-01 12:00:00.000')");
            //        break;
            //    case 4:
            //        strCondition.Append(" and (CheckDateTime >= '" + dateTimeNow.AddMonths(-12).ToString("yyyy-MM-dd") + "' or CheckDateTime='1900-01-01 12:00:00.000')");
            //        break;
            //    default:
            //        break;
            //}

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "BaoXiaoView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridBaoxiaoCheck.PageIndex;
            _comHelp.OrderExpression = "CheckDateTime desc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridBaoxiaoCheck.RecordCount = _comHelp.TotalCount;
            //gridAttend.PageIndex = _comHelp.PageIndex;
            gridBaoxiaoCheck.PageSize = PageCounts;

            gridBaoxiaoCheck.DataSource = dtbLeaveApproves.Rows;
            gridBaoxiaoCheck.DataBind();

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
            if (DateTime.Compare(Convert.ToDateTime(dpkStartTime.SelectedDate), Convert.ToDateTime(dpkEndTime.SelectedDate)) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }

            BindGrid(tbxSearch.Text.Trim(), ddlstDept.SelectedText, Convert.ToInt32(ddlstAproveState.SelectedValue), 0);
        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBaoxiaoCheck_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridBaoxiaoCheck.PageIndex = e.NewPageIndex;
            BindGrid(tbxSearch.Text.Trim(), ddlstDept.SelectedText, Convert.ToInt32(ddlstAproveState.SelectedValue), 0);
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBaoxiaoCheck_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strBaoxiaoID = ((GridRow)gridBaoxiaoCheck.Rows[e.RowIndex]).Values[0];
            string strBaoxiaoCheckID = ((GridRow)gridBaoxiaoCheck.Rows[e.RowIndex]).Values[1];
            if (e.CommandName == "Approve")
            {
                wndBaoxiaoCheck.IFrameUrl = "CheckBaoxiaoApp.aspx?BaoxiaoID=" + strBaoxiaoID + "&BaoxiaoCheckID=" + strBaoxiaoCheckID;
                wndBaoxiaoCheck.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBaoxiaoCheck_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                // 设置时间格式.
                e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd HH:mm");
                e.Values[6] = DateTime.Parse(e.Values[6].ToString()).ToString("yyyy-MM-dd");
                e.Values[7] = DateTime.Parse(e.Values[7].ToString()).ToString("yyyy-MM-dd");
                DateTime approveTime = DateTime.Parse(e.Values[13].ToString());
                if (DateTime.Compare(approveTime, ACommonInfo.DBEmptyDate) == 0)
                {
                    e.Values[13] = "";
                }
                else
                {
                    e.Values[13] = approveTime.ToString("yyyy-MM-dd HH:mm");
                }

                // 设置审批状态.
                if (e.Values[11].ToString() == "0")
                {
                    e.Values[11] = "待审批";
                }
                else if (e.Values[11].ToString() == "1")
                {
                    e.Values[11] = "已审批";
                    e.Values[14] = "<span class=\"gray\">审批</span>";
                }

                // 设置审批结果.
                if (e.Values[12].ToString() == "0")
                {
                    e.Values[12] = "同意";
                }
                else if (e.Values[12].ToString() == "1")
                {
                    e.Values[12] = "打回修改";
                }
            }
        }

        /// <summary>
        /// 弹出窗口变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndBaoxiaoCheck_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid(tbxSearch.Text.Trim(), ddlstDept.SelectedText, Convert.ToInt32(ddlstAproveState.SelectedValue), 0);
        }


        #endregion
    }
}