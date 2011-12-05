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
    public partial class JiangChengList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndNewJiangCheng.OnClientCloseButtonClick = wndNewJiangCheng.GetHidePostBackReference();
                btnNewApply.OnClientClick = wndNewJiangCheng.GetShowReference("SentJiangCheng.aspx?Type=Add") + "return false;";

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
            strCondition.Append(" CreateUserID ='" + CurrentUser.ObjectId.ToString() + "'");

            if (ddlstAproveState.SelectedIndex != 0)
            {
                strCondition.Append(" and Type = " + ddlstAproveState.SelectedValue);
            }

            strCondition.Append(" and (CreateTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "')");

            #endregion

            List<JiangChengInfo> lstApply = new JiangChengManage().GetJiangChengByCondition(strCondition.ToString());
            this.gridApply.RecordCount = lstApply.Count;
            this.gridApply.PageSize = PageCounts;
            int currentIndex = this.gridApply.PageIndex;
            //计算当前页面显示行数据
            if (lstApply.Count > this.gridApply.PageSize)
            {
                if (lstApply.Count > (currentIndex + 1) * this.gridApply.PageSize)
                {
                    lstApply.RemoveRange((currentIndex + 1) * this.gridApply.PageSize, lstApply.Count - (currentIndex + 1) * this.gridApply.PageSize);
                }
                lstApply.RemoveRange(0, currentIndex * this.gridApply.PageSize);
            }
            this.gridApply.DataSource = lstApply;
            this.gridApply.DataBind();
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
        protected void gridApply_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridApply.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApplyID = ((GridRow)gridApply.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "View")
            {
                wndNewJiangCheng.IFrameUrl = "SentJiangCheng.aspx?Type=View&ID=" + strApplyID;
                wndNewJiangCheng.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndNewJiangCheng.IFrameUrl = "SentJiangCheng.aspx?Type=Edit&ID=" + strApplyID;
                wndNewJiangCheng.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[3] = e.Values[3].ToString() == "0" ? "奖励" : "惩罚";
                e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd HH:mm");
                switch (e.Values[7].ToString())
                {
                    case "0":
                        e.Values[7] = "待个人确认";
                        break;
                    case "1":
                        e.Values[7] = "待部门总监确认";
                        e.Values[9] = "<span class=\"gray\">编辑</span>";
                        break;
                    case "2":
                        e.Values[7] = "部门总监已确认";
                        e.Values[9] = "<span class=\"gray\">编辑</span>";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 下发窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewJiangCheng_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
            wndNewJiangCheng.Title = "下发奖惩单";
        }

        #endregion
    }
}