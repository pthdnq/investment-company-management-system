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
    public partial class WuZhiApplyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndNewWuZhi.Title = "物资申请";
                btnNewWuZhi.OnClientClick = wndNewWuZhi.GetShowReference("WuZhiApplyNew.aspx?Type=Add") + "return false;";
                wndNewWuZhi.OnClientCloseButtonClick = wndNewWuZhi.GetHidePostBackReference();

                BindWuZhiType();
                BindGrid();
            }
        }

        #region 私有方法

        private void BindWuZhiType()
        {
            ddlstWuZhiType.Items.Add(new ExtAspNet.ListItem("一般物资", "0"));
            foreach (RoleType roleType in CurrentRoles)
            {
                if (roleType == RoleType.WZSQ_GD)
                {
                    ddlstWuZhiType.Items.Add(new ExtAspNet.ListItem("全部", "3"));
                    ddlstWuZhiType.Items.Add(new ExtAspNet.ListItem("一般物资", "0"));
                    ddlstWuZhiType.Items.Add(new ExtAspNet.ListItem("固定物资", "1"));
                    break;
                }
            }
            ddlstWuZhiType.SelectedIndex = 0;
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

            strCondition.Append(" Isdelete <> 1");
            strCondition.Append(" and UserID ='" + CurrentUser.ObjectId.ToString() + "'");
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and Title Like '%" + tbxSearch.Text.Trim() + "%'");
            }
            if (ddlstWuZhiType.SelectedIndex != 0)
            {
                strCondition.Append(" and type = " + ddlstWuZhiType.SelectedValue);
            }

            strCondition.Append(" and state = " + ddlstAproveState.SelectedValue);
            strCondition.Append(" and (ApplyTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "' or ApplyTime='1900-01-01 12:00:00.000')");

            #endregion

            List<WuZhiInfo> lstWuZhi = new WuZhiManage().GetWuZhiByCondition(strCondition.ToString());
            this.gridWuZhi.RecordCount = lstWuZhi.Count;
            this.gridWuZhi.PageSize = PageCounts;
            int currentIndex = this.gridWuZhi.PageIndex;
            //计算当前页面显示行数据
            if (lstWuZhi.Count > this.gridWuZhi.PageSize)
            {
                if (lstWuZhi.Count > (currentIndex + 1) * this.gridWuZhi.PageSize)
                {
                    lstWuZhi.RemoveRange((currentIndex + 1) * this.gridWuZhi.PageSize, lstWuZhi.Count - (currentIndex + 1) * this.gridWuZhi.PageSize);
                }
                lstWuZhi.RemoveRange(0, currentIndex * this.gridWuZhi.PageSize);
            }
            this.gridWuZhi.DataSource = lstWuZhi;
            this.gridWuZhi.DataBind();
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
        protected void gridWuZhi_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridWuZhi.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridWuZhi_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strWuZhiID = ((GridRow)gridWuZhi.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "View")
            {
                wndNewWuZhi.IFrameUrl = "WuZhiApplyNew.aspx?Type=View&ID=" + strWuZhiID;
                wndNewWuZhi.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndNewWuZhi.IFrameUrl = "WuZhiApplyNew.aspx?Type=Edit&ID=" + strWuZhiID;
                wndNewWuZhi.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                WuZhiManage _manage = new WuZhiManage();
                WuZhiInfo _info = _manage.GetWuZhiByObjectID(strWuZhiID);
                if (_info != null)
                {
                    _info.Isdelete = true;
                    _manage.UpdateWuZhi(_info);

                    BindGrid();
                }
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridWuZhi_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[1] = e.Values[1].ToString() == "0" ? "一般物资" : "固定资产";
                e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd HH:mm");
                // 当前审批人.
                if (e.Values[6].ToString() == SystemUser.ObjectId.ToString())
                {
                    e.Values[6] = SystemUser.Name;
                }
                else
                {
                    UserInfo _userInfo = new UserManage().GetUserByObjectID(e.Values[6].ToString());
                    if (_userInfo != null)
                    {
                        e.Values[6] = _userInfo.Name;
                    }
                }
                // 审批状态.
                switch (e.Values[7].ToString())
                {
                    case "0":
                        e.Values[7] = "审批中";
                        e.Values[9] = "<span class=\"gray\">编辑</span>";
                        e.Values[10] = "<span class=\"gray\">删除</span>";
                        break;
                    case "1":
                        e.Values[7] = "被打回";
                        break;
                    case "2":
                        e.Values[7] = "归档";
                        e.Values[9] = "<span class=\"gray\">编辑</span>";
                        e.Values[10] = "<span class=\"gray\">删除</span>";
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
        protected void wndNewWuZhi_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}