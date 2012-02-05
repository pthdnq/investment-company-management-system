using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class JiangChengConfirmList : BasePage
    {
        /// <summary>
        /// 页面权限模式（可查看，可编辑）
        /// </summary>
        private VisitLevel PageModel
        {
            get
            {
                if (ViewState["VisitLevel"] == null)
                {
                    ViewState["VisitLevel"] = GetCurrentLevel("jcdqr");
                }
                return (VisitLevel)ViewState["VisitLevel"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wndConfirm.OnClientCloseButtonClick = wndConfirm.GetHidePostBackReference();

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                BindGrid();
            }
        }

        #region 私有方法

        /// <summary>
        /// 查询事件
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
            strCondition.Append("((UserID = '" + CurrentUser.ObjectId.ToString()+ "' and ((State = 0 and UserConfirmTime >= '"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm")+"') "
                + " or (State = 1 and ConfirmType = 0))) or (ZJID = '" + CurrentUser.ObjectId.ToString() + "' and (( State = 0 and UserConfirmTime < '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "') or (State = 1 and ConfirmType = 1)) ))");

            if (ddlstAproveState.SelectedIndex != 0)
            {
                strCondition.Append(" and Type = " + ddlstAproveState.SelectedValue);
            }

            strCondition.Append(" and (CreateTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "')");
            strCondition.Append(" Order by CreateTime desc");
            #endregion

            List<JiangChengInfo> lstApply = new JiangChengManage().GetJiangChengByCondition(strCondition.ToString());
            this.gridConfirm.RecordCount = lstApply.Count;
            this.gridConfirm.PageSize = PageCounts;
            int currentIndex = this.gridConfirm.PageIndex;
            //计算当前页面显示行数据
            if (lstApply.Count > this.gridConfirm.PageSize)
            {
                if (lstApply.Count > (currentIndex + 1) * this.gridConfirm.PageSize)
                {
                    lstApply.RemoveRange((currentIndex + 1) * this.gridConfirm.PageSize, lstApply.Count - (currentIndex + 1) * this.gridConfirm.PageSize);
                }
                lstApply.RemoveRange(0, currentIndex * this.gridConfirm.PageSize);
            }
            this.gridConfirm.DataSource = lstApply;
            this.gridConfirm.DataBind();
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
        protected void gridConfirm_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridConfirm.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridConfirm_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApplyID = ((GridRow)gridConfirm.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "Confirm")
            {
                wndConfirm.IFrameUrl = "JiangChengConfirm.aspx?ID=" + strApplyID;
                wndConfirm.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridConfirm_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[5] = e.Values[5].ToString() == "0" ? "奖励" : "惩罚";
                e.Values[7] = DateTime.Parse(e.Values[7].ToString()).ToString("yyyy-MM-dd HH:mm");
                //if (CurrentUser.ObjectId.ToString() == e.Values[1].ToString())
                //{
                    switch (e.Values[9].ToString())
                    {
                        case "0":
                            e.Values[9] = "待确认";
                            //判断页面是否可编辑（可查看不用考虑）
                            if (PageModel != VisitLevel.Edit && PageModel != VisitLevel.Both)
                            {
                                e.Values[10] = "<span class=\"gray\">确认</span>";
                            }
                            break;
                        case "1":
                            e.Values[9] = "已确认";
                            //e.Values[10] = "<span class=\"gray\">确认</span>";
                            e.Values[10] = e.Values[10].ToString().Replace("确认", "查看");
                            break;
                        case "2":
                            e.Values[9] = "部门领导已确认";
                            //e.Values[10] = "<span class=\"gray\">确认</span>";
                            e.Values[10] = e.Values[10].ToString().Replace("确认", "查看");
                            break;
                        default:
                            break;
                    }
                //}
                //else if (CurrentUser.ObjectId.ToString() == e.Values[2].ToString())
                //{
                //    switch (e.Values[9].ToString())
                //    {
                //        case "0":
                //            e.Values[9] = "待个人确认";
                //            e.Values[10] = "<span class=\"gray\">确认</span>";
                //            break;
                //        case "1":
                //            e.Values[9] = "待确认";
                //            //判断页面是否可编辑（可查看不用考虑）
                //            if (PageModel != VisitLevel.Edit && PageModel != VisitLevel.Both)
                //            {
                //                e.Values[10] = "<span class=\"gray\">确认</span>";
                //            }
                //            break;
                //        case "2":
                //            e.Values[9] = "已确认";
                //            //e.Values[10] = "<span class=\"gray\">确认</span>";
                //            e.Values[10] = e.Values[10].ToString().Replace("确认", "查看");
                //            break;
                //        default:
                //            break;
                //    }
                //}
            }
        }

        /// <summary>
        /// 确认窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndConfirm_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}