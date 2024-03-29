﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class ProxyAccountingApplyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("dzfsq");

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndNewProxy.Title = "代账费申请";
                btnNewProxy.OnClientClick = wndNewProxy.GetShowReference("ProxyAccountApplyNew.aspx?Type=Add") + "return false;";
                wndNewProxy.OnClientCloseButtonClick = wndNewProxy.GetHidePostBackReference();

                BindGrid();

                if (CurrentLevel == VisitLevel.View)
                {
                    btnNewProxy.Enabled = false;
                }
            }
        }

        #region 私有方法

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

            strCondition.Append(" IsDelete <> 1");
            strCondition.Append(" and ProxyAccountingID ='" + CurrentUser.ObjectId.ToString() + "'");
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and PayUnitName Like '%" + tbxSearch.Text.Trim() + "%'");
            }

            strCondition.Append(" and State = " + Convert.ToInt32(ddlstAproveState.SelectedValue));
            strCondition.Append(" and OpeningDate between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

            #endregion

            List<ProxyAccountingApplyInfo> lstApply = new ProxyAccountingManage().GetApplyByCondition(strCondition.ToString());
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
                wndNewProxy.IFrameUrl = "ProxyAccountApplyNew.aspx?Type=View&ID=" + strApplyID;
                wndNewProxy.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndNewProxy.IFrameUrl = "ProxyAccountApplyNew.aspx?Type=Edit&ID=" + strApplyID;
                wndNewProxy.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                ProxyAccountingManage _manage = new ProxyAccountingManage();
                ProxyAccountingApplyInfo _info = _manage.GetApplyByObjectID(strApplyID);
                if (_info != null)
                {
                    _info.IsDelete = true;
                    _manage.UpdateApply(_info);

                    BindGrid();
                }

            }
        }

        /// <summary>
        /// 数据绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[8] = DateTime.Parse(e.Values[8].ToString()).ToString("yyyy-MM-dd");
                e.Values[9] = Company;
                // 当前审批人.
                if (e.Values[10].ToString() == SystemUser.ObjectId.ToString())
                {
                    e.Values[10] = SystemUser.Name;
                }
                else
                {
                    UserInfo _userInfo = new UserManage().GetUserByObjectID(e.Values[10].ToString());
                    if (_userInfo != null)
                    {
                        e.Values[10] = _userInfo.Name;
                    }
                }

                // 审批状态.
                switch (e.Values[11].ToString())
                {
                    case "0":
                        e.Values[11] = "审批中";
                        e.Values[13] = "<span class=\"gray\">编辑</span>";
                        e.Values[14] = "<span class=\"gray\">删除</span>";
                        break;
                    case "1":
                        e.Values[11] = "未通过";
                        break;
                    case "2":
                        e.Values[11] = "归档";
                        e.Values[13] = "<span class=\"gray\">编辑</span>";
                        e.Values[14] = "<span class=\"gray\">删除</span>";
                        break;
                    default:
                        break;
                }

                if (CurrentLevel == VisitLevel.View)
                {
                    e.Values[13] = "<span class=\"gray\">编辑</span>";
                    e.Values[14] = "<span class=\"gray\">删除</span>";
                }
            }
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewProxy_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }
        #endregion
    }
}