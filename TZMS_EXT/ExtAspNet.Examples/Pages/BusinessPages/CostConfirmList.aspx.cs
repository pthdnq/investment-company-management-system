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
using com.TZMS.Business.BusinessManage;

namespace TZMS.Web
{
    public partial class CostConfirmList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("ywfyqr");

                wndCostConfirm.OnClientCloseButtonClick = wndCostConfirm.GetHidePostBackReference();

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

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
            strCondition.Append(" ApproverID = '" + CurrentUser.ObjectId.ToString() + "' and ApproveOp >= 3");

            // 审批状态.
            if (ddlstAproveState.SelectedIndex == 1)
            {
                strCondition.Append(" and ApproveOp = 3");
            }
            else if (ddlstAproveState.SelectedIndex == 2)
            {
                strCondition.Append(" and ApproveOp = 4");
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
            _comHelp.PageIndex = gridCostConfirm.PageIndex;
            _comHelp.OrderExpression = "ApproveTime desc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridCostConfirm.RecordCount = _comHelp.TotalCount;
            gridCostConfirm.PageSize = PageCounts;
            gridCostConfirm.DataSource = dtbLeaveApproves.Rows;
            gridCostConfirm.DataBind();
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
        protected void gridCostConfirm_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridCostConfirm.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCostConfirm_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApproveID = ((GridRow)gridCostConfirm.Rows[e.RowIndex]).Values[0];
            string strApplyID = ((GridRow)gridCostConfirm.Rows[e.RowIndex]).Values[1];

            if (e.CommandName == "Confirm")
            {
                wndCostConfirm.IFrameUrl = "CostConfirm.aspx?ApproveID=" + strApproveID + "&ApplyID=" + strApplyID;
                wndCostConfirm.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCostConfirm_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                BusinessManage _manage = new BusinessManage();
                e.Values[4] = DateTime.Parse(e.Values[4].ToString()).ToString("yyyy-MM-dd HH:mm");
                e.Values[6] = e.Values[6].ToString() == "0" ? "预收定金" : "业务余款";
                List<BusinessCostApproveInfo> lstApprove = _manage.GetCostApproveByCondition("ApplyID='" + e.Values[1].ToString() + "'" +
                        " and (ApproveOp = 1 or ApproveOp = 2) order by ApproveTime desc");

                if (lstApprove.Count > 0)
                {
                    e.Values[8] = lstApprove[0].ApproverName;
                    e.Values[9] = lstApprove[0].ApproveOp == 1 ? "同意" : "不同意";
                }
                switch (e.Values[10].ToString())
                {
                    case "0":
                        e.Values[10] = "待确认";
                        e.Values[11] = "";
                        if (CurrentLevel == VisitLevel.View)
                        {
                            e.Values[12] = "<span class=\"gray\">确认</span>";
                        }

                        break;
                    case "1":
                        e.Values[10] = "已确认";
                        e.Values[11] = DateTime.Parse(e.Values[11].ToString()).ToString("yyyy-MM-dd HH:mm");
                        e.Values[12] = e.Values[12].ToString().Replace("确认", "查看");
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 确认窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndCostConfirm_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}