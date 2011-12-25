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
    public partial class RecruitmentApplyList : BasePage
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
                    ViewState["VisitLevel"] = GetCurrentLevel("zpsqd");
                }
                return (VisitLevel)ViewState["VisitLevel"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //判断页面是否可编辑（可查看不用考虑）
                if (PageModel != VisitLevel.Edit && PageModel != VisitLevel.Both)
                {
                    btnNewApply.Enabled = false;
                }
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndNewApply.OnClientCloseButtonClick = wndNewApply.GetHidePostBackReference();
                btnNewApply.OnClientClick = wndNewApply.GetShowReference("RecruitmentApply.aspx?Type=Add") + "return false;";

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
            strCondition.Append(" UserID ='" + CurrentUser.ObjectId.ToString() + "'");
            strCondition.Append(" and State = " + Convert.ToInt32(ddlstAproveState.SelectedValue));
            strCondition.Append(" and (ApplyTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "')");

            #endregion

            List<RecruitmentApplyInfo> lstApply = new RecruitmentManage().GetApplyByCondition(strCondition.ToString());
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
                wndNewApply.IFrameUrl = "RecruitmentApply.aspx?Type=View&ID=" + strApplyID;
                wndNewApply.Hidden = false;
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
                e.Values[3] = DateTime.Parse(e.Values[3].ToString()).ToString("yyyy-MM-dd HH:mm");

                // 当前审批人.
                UserInfo _userInfo = new UserManage().GetUserByObjectID(e.Values[4].ToString());
                if (_userInfo != null)
                {
                    e.Values[4] = _userInfo.Name;
                }

                // 审批状态.
                switch (e.Values[5].ToString())
                {
                    case "0":
                        e.Values[5] = "审批中";
                        break;
                    case "1":
                        e.Values[5] = "归档-未通过";
                        break;
                    case "2":
                        e.Values[5] = "归档-已通过";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 申请窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewApply_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}