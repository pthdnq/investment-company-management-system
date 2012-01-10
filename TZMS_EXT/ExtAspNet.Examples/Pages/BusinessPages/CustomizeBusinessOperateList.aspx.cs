using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Business;
using System.Data;
using com.TZMS.Model;
using System.Text;
using com.TZMS.Business.BusinessManage;

namespace TZMS.Web
{
    public partial class CustomizeBusinessOperateList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("dzywcz");

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndNewCustomizeBusiness.OnClientCloseButtonClick = wndNewCustomizeBusiness.GetHidePostBackReference();
                wndCustomizeBusinessTransfer.OnClientCloseButtonClick = wndCustomizeBusinessTransfer.GetHidePostBackReference();

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
            strCondition.Append(" CheckerID = '" + CurrentUser.ObjectId.ToString() + "' and CurrentBusiness <> 0 and CurrentBusiness <> 17 and CurrentBusiness <> 18 and BusinessType = 1");

            // 查询文本
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append("  and CompanyName like '%" + tbxSearch.Text.Trim() + "%'");
            }

            // 审批状态.
            strCondition.Append(" and State = " + ddlstAproveState.SelectedValue);
            strCondition.Append(" and (CheckDateTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '"
                + endTime.ToString("yyyy-MM-dd 23:59") + "' or CheckDateTime='"
                + ACommonInfo.DBMAXDate.ToString() + "')");

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "BusinessOperateView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridCustomizeBusiness.PageIndex;
            _comHelp.OrderExpression = "CheckDateTime desc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridCustomizeBusiness.RecordCount = _comHelp.TotalCount;
            gridCustomizeBusiness.PageSize = PageCounts;

            gridCustomizeBusiness.DataSource = dtbLeaveApproves.Rows;
            gridCustomizeBusiness.DataBind();
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
        protected void gridCustomizeBusiness_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridCustomizeBusiness.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCustomizeBusiness_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strRecordID = ((GridRow)gridCustomizeBusiness.Rows[e.RowIndex]).Values[0];
            string strBusinessID = ((GridRow)gridCustomizeBusiness.Rows[e.RowIndex]).Values[1];
            if (e.CommandName == "View")
            {
                wndNewCustomizeBusiness.IFrameUrl = "OperatorCustomizeBusiness.aspx?RecordID=" + strRecordID + "&BusinessID=" + strBusinessID;
                wndNewCustomizeBusiness.Hidden = false;
            }

            if (e.CommandName == "Transfer")
            {
                wndCustomizeBusinessTransfer.IFrameUrl = "CustomizeBusinessTransfer.aspx?RecordID=" + strRecordID + "&BusinessID=" + strBusinessID;
                wndCustomizeBusinessTransfer.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCustomizeBusiness_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                BusinessManage _manage = new BusinessManage();
                e.Values[3] = _manage.ConvertBusinessTypeToString(false, Convert.ToInt32(e.Values[3].ToString()));

                switch (e.Values[4].ToString())
                {
                    case "0":
                        e.Values[4] = "待办理";
                        e.Values[5] = "";
                        if (CurrentLevel == VisitLevel.View)
                        {
                            e.Values[6] = "<span class=\"gray\">办理</span>";
                            e.Values[7] = "<span class=\"gray\">业务转移</span>";
                        }
                        break;
                    case "1":
                        e.Values[4] = "已办理";
                        e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd");
                        e.Values[6] = e.Values[6].ToString().Replace("办理", "查看");
                        e.Values[7] = "<span class=\"gray\">业务转移</span>";
                        break;
                    case "2":
                        e.Values[4] = "已转移";
                        e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd");
                        e.Values[6] = e.Values[6].ToString().Replace("办理", "查看");
                        e.Values[7] = "<span class=\"gray\">业务转移</span>";
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
        protected void wndNewCustomizeBusiness_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 业务转移关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndCustomizeBusinessTransfer_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}