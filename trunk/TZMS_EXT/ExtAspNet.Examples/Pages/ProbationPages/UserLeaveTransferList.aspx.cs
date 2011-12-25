using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using System.Data;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class UserLeaveTransferList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("lzjj");

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndTransfer.OnClientCloseButtonClick = wndTransfer.GetHidePostBackReference();

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
            strCondition.Append(" TransferID = '" + CurrentUser.ObjectId.ToString() + "' and Expr1 <> -1 and TransferType <> 4");
            strCondition.Append(" and IsDelete = 0 and State = 1");

            // 查询文本
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append("  and UserName like '%" + tbxSearch.Text.Trim() + "%'");
            }

            // 查询部门
            if (ddlstDept.SelectedIndex != 0)
            {
                strCondition.Append(" and UserDept='" + ddlstDept.SelectedText + "'");
            }

            // 审批状态
            switch (ddlstAproveState.SelectedValue)
            {
                case "0":
                    strCondition.Append(" and IsTransfer = 0");
                    break;
                case "1":
                    strCondition.Append(" and IsTransfer = 1");
                    break;
                default:
                    break;
            }

            strCondition.Append(" and (TransferTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "' or TransferTime='" + ACommonInfo.DBMAXDate.ToString() + "')");

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "UserLeaveTransferView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridApprove.PageIndex;
            _comHelp.OrderExpression = "TransferTime desc";

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

            if (e.CommandName == "Transfer")
            {
                wndTransfer.IFrameUrl = "UserLeaveTransfer.aspx?TransferID=" + strApproveID + "&ApplyID=" + strApplyID;
                wndTransfer.Hidden = false;
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
                switch (e.Values[2].ToString())
                {
                    case "0":
                        e.Values[2] = "所属部门交接";
                        break;
                    case "1":
                        e.Values[2] = "财务部交接";
                        break;
                    case "2":
                        e.Values[2] = "行政部交接";
                        break;
                    default:
                        break;
                }

                e.Values[6] = DateTime.Parse(e.Values[6].ToString()).ToString("yyyy-MM-dd");
                e.Values[7] = DateTime.Parse(e.Values[7].ToString()).ToString("yyyy-MM-dd");
                e.Values[8] = DateTime.Parse(e.Values[8].ToString()).ToString("yyyy-MM-dd");
                e.Values[10] = DateTime.Parse(e.Values[10].ToString()).ToString("yyyy-MM-dd HH:mm");
                e.Values[12] = DateTime.Parse(e.Values[12].ToString()).ToString("yyyy-MM-dd HH:mm");
                switch (e.Values[11].ToString())
                {
                    case "False":
                        e.Values[11] = "待交接";
                        e.Values[12] = "";
                        break;
                    case "True":
                        e.Values[11] = "已交接";
                        e.Values[12] = DateTime.Parse(e.Values[12].ToString()).ToString("yyyy-MM-dd HH:mm");
                        e.Values[13] = "<span class=\"gray\">交接</span>";
                        break;
                    default:
                        break;
                }

                if (CurrentLevel == VisitLevel.View)
                {
                    e.Values[13] = "<span class=\"gray\">交接</span>";
                }
            }
        }

        /// <summary>
        /// 交接窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndTransfer_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}