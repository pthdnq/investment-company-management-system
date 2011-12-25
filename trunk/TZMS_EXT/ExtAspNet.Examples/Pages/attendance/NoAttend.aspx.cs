using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.iFlytek.OA.MUDCommon;
using ExtAspNet;
using System.Text;
using com.TZMS.Business;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class NoAttend : BasePage
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
                    ViewState["VisitLevel"] = GetCurrentLevel("wdksm");
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
                    btnNewApp.Enabled = false;
                }


                // 设定默认开始时间和结束时间.
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                //请假申请 新增按钮
                wndNewNoAttend.Title = "未打卡申请";
                btnNewApp.OnClientClick = wndNewNoAttend.GetShowReference("NoAttendNew.aspx?Type=Add") + "return false;";
                wndNewNoAttend.OnClientCloseButtonClick = wndNewNoAttend.GetHidePostBackReference();

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
            strCondition.Append(" Isdelete<>1");
            strCondition.Append(" and UserID ='" + CurrentUser.ObjectId.ToString() + "'");
            strCondition.Append(" and state =" + Convert.ToInt32(ddlappState.SelectedValue));

            // 日期范围.
            strCondition.Append(" and ApplyTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

            #endregion

            // 获取
            NoAttendManage noAttendManage = new NoAttendManage();
            List<NoAttendInfo> lstNoAttendInfo = noAttendManage.GetNoAttendInfoByCondition(strCondition.ToString());
            gridNoAttend.RecordCount = lstNoAttendInfo.Count;
            gridNoAttend.PageSize = PageCounts;
            int currentIndex = gridNoAttend.PageIndex;

            // 计算当前页面显示行数据
            if (lstNoAttendInfo.Count > gridNoAttend.PageSize)
            {
                if (lstNoAttendInfo.Count > (currentIndex + 1) * gridNoAttend.PageSize)
                {
                    lstNoAttendInfo.RemoveRange((currentIndex + 1) * gridNoAttend.PageSize, lstNoAttendInfo.Count - (currentIndex + 1) * gridNoAttend.PageSize);
                }
                lstNoAttendInfo.RemoveRange(0, currentIndex * gridNoAttend.PageSize);
            }
            this.gridNoAttend.DataSource = lstNoAttendInfo;
            this.gridNoAttend.DataBind();

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
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridNoAttend_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strNoAttendID = ((GridRow)gridNoAttend.Rows[e.RowIndex]).Values[0];

            if (e.CommandName == "View")
            {
                wndNewNoAttend.IFrameUrl = "NoAttendNew.aspx?Type=View&NoAttendID=" + strNoAttendID;
                wndNewNoAttend.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridNoAttend_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                NoAttendInfo _info = (NoAttendInfo)e.DataItem;
                e.Values[1] = _info.Year + "-" + _info.Month;
                e.Values[2] = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                UserInfo _checkUserInfo = new UserManage().GetUserByObjectID(_info.CurrentCheckId.ToString());
                if (_checkUserInfo != null)
                {
                    e.Values[5] = _checkUserInfo.Name;
                }

                switch (e.Values[6].ToString())
                {
                    case "0":
                        e.Values[6] = "审批中";
                        break;
                    case "1":
                        e.Values[6] = "归档-未通过";
                        break;
                    case "2":
                        e.Values[6] = "归档-已通过";
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridNoAttend_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridNoAttend.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 打卡申请窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewNoAttend_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}