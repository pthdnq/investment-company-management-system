using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ExtAspNet;
using com.TZMS.Business;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class NoAttendToFile : BasePage
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
                    ViewState["VisitLevel"] = GetCurrentLevel("wdkgd");
                }
                return (VisitLevel)ViewState["VisitLevel"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wndNoAttendCheck.OnClientCloseButtonClick = wndNoAttendCheck.GetHidePostBackReference();

                // 设定时间控件的默认时间.
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
            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

            if (DateTime.Compare(startTime, endTime) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }

            #region 查询出条件

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" CheckerID = '" + CurrentUser.ObjectId.ToString() + "'");

            // 归档状态.
            if (ddlstArchiveState.SelectedIndex == 0)
            {
                strCondition.Append(" and CheckOp = '3'");
            }
            else
            {
                strCondition.Append(" and CheckOp = '4'");
            }

            // 时间范围.

            strCondition.Append(" and (CheckDateTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "' or CheckDateTime = '1900-01-01 12:00:00.000')");

            #endregion

            NoAttendManage _manage = new NoAttendManage();
            List<NoAttendCheckInfo> lstNoAttendCheck = _manage.GetNoAttendCheckInfoByCondition(strCondition.ToString());
            gridNoAttendToFile.RecordCount = lstNoAttendCheck.Count;
            gridNoAttendToFile.PageSize = PageCounts;
            int currentIndex = gridNoAttendToFile.PageIndex;

            // 计算当前页面显示行数据
            if (lstNoAttendCheck.Count > gridNoAttendToFile.PageSize)
            {
                if (lstNoAttendCheck.Count > (currentIndex + 1) * gridNoAttendToFile.PageSize)
                {
                    lstNoAttendCheck.RemoveRange((currentIndex + 1) * gridNoAttendToFile.PageSize, lstNoAttendCheck.Count - (currentIndex + 1) * gridNoAttendToFile.PageSize);
                }
                lstNoAttendCheck.RemoveRange(0, currentIndex * gridNoAttendToFile.PageSize);
            }
            this.gridNoAttendToFile.DataSource = lstNoAttendCheck;
            this.gridNoAttendToFile.DataBind();
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
        protected void gridNoAttendToFile_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridNoAttendToFile.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridNoAttendToFile_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strNoAttendID = ((GridRow)gridNoAttendToFile.Rows[e.RowIndex]).Values[1];
            string strNoAttendCheckID = ((GridRow)gridNoAttendToFile.Rows[e.RowIndex]).Values[0];
            //string strLastApproveResult = ((GridRow)gridNoAttendToFile.Rows[e.RowIndex]).Values[9];
            if (e.CommandName == "Archive")
            {
                wndNoAttendCheck.IFrameUrl = "NoAttendToFileView.aspx?NoAttendID=" + strNoAttendID + "&NoAttendCheckID=" + strNoAttendCheckID;
                wndNoAttendCheck.Hidden = false;

                //NoAttendManage _manage = new NoAttendManage();
                //NoAttendInfo _info = _manage.GetNoAttendInfoByObjectID(strNoAttendID);
                //NoAttendCheckInfo _checkInfo = _manage.GetNoAttendCheckInfoByObjectID(strNoAttendCheckID);
                //if (_info != null && _checkInfo != null)
                //{
                //    _info.State = strLastApproveResult == "同意" ? short.Parse("2") : short.Parse("1");
                //    _manage.UpdateNoAttendInfo(_info);

                //    _checkInfo.CheckOp = "4";
                //    _checkInfo.Checkstate = 1;
                //    _checkInfo.CheckDateTime = DateTime.Now;
                //    _manage.UpdateNoAttendCheckInfo(_checkInfo);

                //    BindGrid();
                //}
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridNoAttendToFile_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                NoAttendCheckInfo _checkInfo = (NoAttendCheckInfo)e.DataItem;
                NoAttendManage _manage = new NoAttendManage();
                NoAttendInfo _info = _manage.GetNoAttendInfoByObjectID(_checkInfo.ApplyId.ToString());
                if (_info != null)
                {
                    e.Values[0] = _checkInfo.ObjectId.ToString();
                    e.Values[1] = _info.ObjectId.ToString();
                    e.Values[2] = _info.UserName;
                    e.Values[3] = _info.Dept;
                    e.Values[4] = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                    e.Values[5] = _info.Year + "-" + _info.Month;
                    e.Values[6] = _info.Comment;
                    e.Values[7] = _info.Other;

                    // 查找最早的记录.
                    NoAttendCheckInfo _lastCheckInfo = _manage.GetNoAttendCheckInfoByCondition("ApplyID='" + _info.ObjectId.ToString() + "'" +
                        " and (CheckOp = '1' or CheckOp = '2') order by CheckDateTime desc")[0];
                    e.Values[8] = _lastCheckInfo.CheckerName;
                    e.Values[9] = _lastCheckInfo.CheckOp == "1" ? "同意" : "不同意";
                    e.Values[10] = _checkInfo.CheckOp == "3" ? "待归档" : "已归档";
                    if (_checkInfo.CheckOp == "4")
                    {
                        e.Values[11] = _checkInfo.CheckDateTime.ToString("yyyy-MM-dd HH:mm");
                        //e.Values[12] = "<span class=\"gray\">归档</span>";
                        e.Values[12] = e.Values[12].ToString().Replace("归档", "查看");
                    }
                    else
                    {
                        e.Values[11] = "";
                        //判断页面是否可编辑（可查看不用考虑）
                        if (PageModel != VisitLevel.Edit && PageModel != VisitLevel.Both)
                        {
                            e.Values[12] = "<span class=\"gray\">归档</span>";
                        }
                    }
                }


            }
        }


        /// <summary>
        /// 归档窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNoAttendCheck_Close(object sender, WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion

    }
}