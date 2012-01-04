using System;
using System.Collections.Generic;

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
    public partial class SalaryMsgApproveList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("xzsp");

                wndApprove.OnClientCloseButtonClick = wndApprove.GetHidePostBackReference();

                BindYear();

                DateTime now = DateTime.Now;
                ddlstYear.SelectedValue = now.Year.ToString();
                ddlstMonth.SelectedValue = now.Month.ToString();
                dpkEndTime.SelectedDate = now;
                dpkStartTime.SelectedDate = now.AddMonths(-1);

                BindGrid();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定年
        /// </summary>
        private void BindYear()
        {
            int year = DateTime.Now.Year;
            string tempString = string.Empty;
            for (int i = -3; i < 2; i++)
            {
                tempString = (year + i).ToString();
                ddlstYear.Items.Add(new ExtAspNet.ListItem(tempString, tempString));
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGrid()
        {
            #region 查询条件

            //DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            //DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

            //if (DateTime.Compare(startTime, endTime) == 1)
            //{
            //    Alert.Show("结束日期不可小于开始日期!");
            //    return;
            //}

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" CheckerID = '" + CurrentUser.ObjectId.ToString() + "' and CheckOp <> '0'");

            strCondition.Append(" and Year = " + ddlstYear.SelectedValue);
            strCondition.Append(" and Month = " + ddlstMonth.SelectedValue);

            if (ddlstAproveState.SelectedIndex == 1)
            {
                strCondition.Append(" and Checkstate = 0");
            }
            else if (ddlstAproveState.SelectedIndex == 2)
            {
                strCondition.Append(" and Checkstate = 1");
            }

            //strCondition.Append(" and (CheckDateTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59")
            //    + "' or CheckDateTime='" + ACommonInfo.DBMAXDate + "')");

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "SalaryApproveView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridApprove.PageIndex;
            _comHelp.OrderExpression = "CheckDateTime desc";

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
                wndApprove.IFrameUrl = "SalaryMsgApprove.aspx?ApproveID=" + strApproveID + "&ApplyID=" + strApplyID;
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
                e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd HH:mm");
                switch (e.Values[6].ToString())
                {
                    case "0":
                        e.Values[6] = "待审批";
                        e.Values[7] = "";
                        e.Values[8] = "";
                        if (CurrentLevel == VisitLevel.View)
                        {
                            e.Values[9] = "<span class=\"gray\">审批</span>";
                        }
                        break;
                    case "1":
                        e.Values[6] = "已审批";
                        e.Values[7] = e.Values[7].ToString() == "0" ? "同意" : "不同意";
                        e.Values[8] = DateTime.Parse(e.Values[8].ToString()).ToString("yyyy-MM-dd HH:mm");
                        //e.Values[9] = "<span class=\"gray\">审批</span>";
                        e.Values[9] = e.Values[9].ToString().Replace("审批", "查看");
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
        protected void wndApprove_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}