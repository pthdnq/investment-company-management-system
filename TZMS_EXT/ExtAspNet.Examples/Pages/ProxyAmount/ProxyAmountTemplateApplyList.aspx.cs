using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business.ProxyAmount;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class ProxyAmountTemplateApplyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("dzdmbzz");

                btnNewProxy.OnClientClick = wndProxyAmountTemplateApply.GetShowReference("ProxyAmountTemplateApply.aspx?Type=Add") + "return false;";
                wndProxyAmountTemplateApply.OnClientCloseButtonClick = wndProxyAmountTemplateApply.GetHidePostBackReference();

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

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
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and ProxyAmountUnitName Like '%" + tbxSearch.Text.Trim() + "%'");
            }
            if (Convert.ToInt32(ddlstAproveState.SelectedValue) >= 2)
            {
                strCondition.Append(" and State >= 2");
            }
            else
            {
                strCondition.Append(" and State = " + ddlstAproveState.SelectedValue);
            }
            strCondition.Append(" and ApplyTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

            #endregion

            List<ProxyAmountTemplateApplyInfo> lstApply = new ProxyAmountManage().GetTemplateApplyByCondition(strCondition.ToString());
            this.gridProxyAmountTemplateApply.RecordCount = lstApply.Count;
            this.gridProxyAmountTemplateApply.PageSize = PageCounts;
            int currentIndex = this.gridProxyAmountTemplateApply.PageIndex;
            //计算当前页面显示行数据
            if (lstApply.Count > this.gridProxyAmountTemplateApply.PageSize)
            {
                if (lstApply.Count > (currentIndex + 1) * this.gridProxyAmountTemplateApply.PageSize)
                {
                    lstApply.RemoveRange((currentIndex + 1) * this.gridProxyAmountTemplateApply.PageSize, lstApply.Count - (currentIndex + 1) * this.gridProxyAmountTemplateApply.PageSize);
                }
                lstApply.RemoveRange(0, currentIndex * this.gridProxyAmountTemplateApply.PageSize);
            }
            this.gridProxyAmountTemplateApply.DataSource = lstApply;
            this.gridProxyAmountTemplateApply.DataBind();
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
        protected void gridProxyAmountTemplateApply_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridProxyAmountTemplateApply.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProxyAmountTemplateApply_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApplyID = ((GridRow)gridProxyAmountTemplateApply.Rows[e.RowIndex]).Values[0];

            if (e.CommandName == "On")
            {
                ProxyAmountManage _manage = new ProxyAmountManage();
                ProxyAmountTemplateApplyInfo _info = _manage.GetTemplateApplyByObjectID(strApplyID);
                if (_info != null)
                {
                    _info.State = 3;
                    _manage.UpdateTemplateApply(_info);

                    BindGrid();
                }
            }

            if (e.CommandName == "Off")
            {
                ProxyAmountManage _manage = new ProxyAmountManage();
                ProxyAmountTemplateApplyInfo _info = _manage.GetTemplateApplyByObjectID(strApplyID);
                if (_info != null)
                {
                    _info.State = 4;
                    _manage.UpdateTemplateApply(_info);

                    BindGrid();
                }
            }

            if (e.CommandName == "View")
            {
                wndProxyAmountTemplateApply.IFrameUrl = "ProxyAmountTemplateApply.aspx?Type=View&ID=" + strApplyID;
                wndProxyAmountTemplateApply.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndProxyAmountTemplateApply.IFrameUrl = "ProxyAmountTemplateApply.aspx?Type=Edit&ID=" + strApplyID;
                wndProxyAmountTemplateApply.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProxyAmountTemplateApply_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[2] = e.Values[2].ToString() == "0" ? "代帐费" : "年检费";

                UserInfo _approveUser = new UserManage().GetUserByObjectID(e.Values[8].ToString());
                if (_approveUser != null)
                {
                    e.Values[8] = _approveUser.Name;
                }

                switch (e.Values[9].ToString())
                {
                    case "0":
                        e.Values[9] = "待审批";
                        e.Values[10] = "<span class=\"gray\">启用</span>";
                        e.Values[11] = "<span class=\"gray\">终止</span>";
                        e.Values[13] = "<span class=\"gray\">编辑</span>";
                        break;
                    case "1":
                        e.Values[9] = "未通过";
                        e.Values[10] = "<span class=\"gray\">启用</span>";
                        e.Values[11] = "<span class=\"gray\">终止</span>";
                        break;
                    case "2":
                        e.Values[9] = "归档";
                        break;
                    case "3":
                        e.Values[9] = "归档";
                        e.Values[10] = "<span class=\"gray\">启用</span>";
                        break;
                    case "4":
                        e.Values[9] = "归档";
                        e.Values[11] = "<span class=\"gray\">终止</span>";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndProxyAmountTemplateApply_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}