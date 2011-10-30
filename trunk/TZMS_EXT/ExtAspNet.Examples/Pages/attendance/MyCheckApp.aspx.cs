using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Data;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class MyCheckApp : BasePage
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
                // 处理审批窗口关闭事件.
                wndApprove.OnClientCloseButtonClick = wndApprove.GetHidePostBackReference();

                // 绑定部门和列表.
                BindDept();
                BindGrid(SearchText, SearchDept, SearchApproveState, SearchDateRange);
            }
        }

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

            SearchText = string.Empty;
            SearchDept = ddlstDept.SelectedText;
            SearchApproveState = Convert.ToInt32(ddlstAproveState.SelectedValue);
            SearchDateRange = Convert.ToInt32(ddldateRange.SelectedValue);
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGrid(string strSearchText, string strSearchDept, int nApproveState, int nDateRange)
        {
            #region 查询条件

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" ApproverID = '" + CurrentUser.ObjectId.ToString() + "'");

            // 查询文本
            if (!string.IsNullOrEmpty(strSearchText))
            {
                strCondition.Append("  and (name like '%" + SearchText + "%' or AccountNo like '%" + SearchText + "%')");
            }

            // 查询部门
            if (!string.IsNullOrEmpty(SearchDept) && SearchDept != "全部")
            {
                strCondition.Append(" and dept='" + SearchDept + "'");
            }

            // 审批状态
            switch (nApproveState)
            {
                case 1:
                    strCondition.Append(" and ApproveTime = '1900-01-01 12:00:00.000'");
                    break;
                case 2:
                    strCondition.Append(" and ApproveTime <> '1900-01-01 12:00:00.000'");
                    break;
                default:
                    break;
            }

            //// 审批时间
            //DateTime dateTimeNow = DateTime.Now;
            //switch (nDateRange)
            //{
            //    case 1:
            //        strCondition.Append(" and ApproveTime >= '" + dateTimeNow.AddMonths(-1).ToString("yyyy-MM-dd") + "'");
            //        break;
            //    case 2:
            //        strCondition.Append(" and ApproveTime >= '" + dateTimeNow.AddMonths(-3).ToString("yyyy-MM-dd") + "'");
            //        break;
            //    case 3:
            //        strCondition.Append(" and ApproveTime >= '" + dateTimeNow.AddMonths(-6).ToString("yyyy-MM-dd") + "'");
            //        break;
            //    case 4:
            //        strCondition.Append(" and ApproveTime >= '" + dateTimeNow.AddMonths(-12).ToString("yyyy-MM-dd") + "'");
            //        break;
            //    default:
            //        break;
            //}

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "LeaveApproveView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridAttend.PageIndex;
            _comHelp.OrderExpression = "WriteTime desc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridAttend.RecordCount = _comHelp.TotalCount;
            //gridAttend.PageIndex = _comHelp.PageIndex;
            gridAttend.PageSize = PageCounts;

            gridAttend.DataSource = dtbLeaveApproves.Rows;
            gridAttend.DataBind();

            //LeaveAppManage leaveAppManage = new LeaveAppManage();
            //List<LeaveApproveInfo> lstApproveInfo = leaveAppManage.GetLeaveApprovesByCondition(strCondition.ToString());
            //gridAttend.RecordCount = lstApproveInfo.Count;
            //gridAttend.PageSize = PageCounts;
            //int currentIndex = gridAttend.PageIndex;

            //// 计算当前页面显示行数据
            //if (lstApproveInfo.Count > gridAttend.PageSize)
            //{
            //    if (lstApproveInfo.Count > (currentIndex + 1) * gridAttend.PageSize)
            //    {
            //        lstApproveInfo.RemoveRange((currentIndex + 1) * gridAttend.PageSize, lstApproveInfo.Count - (currentIndex + 1) * gridAttend.PageSize);
            //    }
            //    lstApproveInfo.RemoveRange(0, currentIndex * gridAttend.PageSize);
            //}
            //this.gridAttend.DataSource = lstApproveInfo;
            //this.gridAttend.DataBind();
        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridAttend_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridAttend.PageIndex = e.NewPageIndex;
            BindGrid(SearchText, SearchDept, SearchApproveState, SearchDateRange);
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridAttend_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strLeaveID = ((GridRow)gridAttend.Rows[e.RowIndex]).Values[0];
            string strUserID = ((GridRow)gridAttend.Rows[e.RowIndex]).Values[1];
            string strLeaveApproveID = ((GridRow)gridAttend.Rows[e.RowIndex]).Values[2];
            if (e.CommandName == "Approve")
            {
                wndApprove.IFrameUrl = "MyCheckAppForm.aspx?LeaveID=" + strLeaveID + "&UserID=" + strUserID + "&LeaveApproveID=" + strLeaveApproveID;
                wndApprove.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridAttend_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[7] = DateTime.Parse(e.Values[7].ToString()).ToString("yyyy年MM年dd日 hh:mm:ss");
                e.Values[10] = DateTime.Parse(e.Values[10].ToString()).ToLongDateString();
                e.Values[11] = DateTime.Parse(e.Values[11].ToString()).ToLongDateString();
                if (DateTime.Compare(DateTime.Parse(e.Values[12].ToString()), ACommonInfo.DBEmptyDate) == 0)
                {
                    e.Values[12] = "待审批";
                }
                else
                {
                    e.Values[12] = "审批中";
                }

                switch (e.Values[13].ToString())
                {
                    case "0":
                        e.Values[13] = "待审批";
                        break;
                    case "1":
                        e.Values[13] = "通过";
                        e.Values[14] = "<span class=\"gray\">审批</span>";
                        break;
                    case "2":
                        e.Values[13] = "打回修改";
                        e.Values[14] = "<span class=\"gray\">审批</span>";
                        break;
                    case "3":
                        e.Values[13] = "归档";
                        e.Values[14] = "<span class=\"gray\">审批</span>";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 部门下拉框变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchDept = ddlstDept.SelectedText;
            BindGrid(SearchText, SearchDept, SearchApproveState, SearchDateRange);
        }

        /// <summary>
        /// 审批状态下拉框变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstAproveState_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchApproveState = Convert.ToInt32(ddlstAproveState.SelectedValue);
            BindGrid(SearchText, SearchDept, SearchApproveState, SearchDateRange);
        }

        /// <summary>
        /// 时间范围变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddldateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchDateRange = Convert.ToInt32(ddldateRange.SelectedValue);
            BindGrid(SearchText, SearchDept, SearchApproveState, SearchDateRange);
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {
            SearchText = ttbSearch.Text.Trim();
            BindGrid(SearchText, SearchDept, SearchApproveState, SearchDateRange);
        }

        /// <summary>
        /// 审批窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndApprove_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid(SearchText, SearchDept, SearchApproveState, SearchDateRange);
        }
    }
}