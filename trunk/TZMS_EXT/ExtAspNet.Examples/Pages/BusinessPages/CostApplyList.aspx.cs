using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Business.BusinessManage;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class CostApplyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("ywfysq");

                wndCostApply.OnClientCloseButtonClick = wndCostApply.GetHidePostBackReference();
                btnNewCostApply.OnClientClick = wndCostApply.GetShowReference("CostApply.aspx?Type=Add") + "return false;";

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                BindGrid();

                if (CurrentLevel == VisitLevel.View)
                {
                    btnNewCostApply.Enabled = false;
                }
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
            strCondition.Append(" IsDelete <> 1");
            strCondition.Append(" and UserID ='" + CurrentUser.ObjectId.ToString() + "'");
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and CompanyName Like '%" + tbxSearch.Text.Trim() + "%'");
            }

            strCondition.Append(" and State = " + Convert.ToInt32(ddlstAproveState.SelectedValue));
            strCondition.Append(" and ApplyTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

            #endregion

            List<BusinessCostApplyInfo> lstApply = new BusinessManage().GetCostApplyByCondition(strCondition.ToString());
            this.gridCostApply.RecordCount = lstApply.Count;
            this.gridCostApply.PageSize = PageCounts;
            int currentIndex = this.gridCostApply.PageIndex;
            //计算当前页面显示行数据
            if (lstApply.Count > this.gridCostApply.PageSize)
            {
                if (lstApply.Count > (currentIndex + 1) * this.gridCostApply.PageSize)
                {
                    lstApply.RemoveRange((currentIndex + 1) * this.gridCostApply.PageSize, lstApply.Count - (currentIndex + 1) * this.gridCostApply.PageSize);
                }
                lstApply.RemoveRange(0, currentIndex * this.gridCostApply.PageSize);
            }
            this.gridCostApply.DataSource = lstApply;
            this.gridCostApply.DataBind();
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
        protected void gridCostApply_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridCostApply.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCostApply_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApplyID = ((GridRow)gridCostApply.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "View")
            {
                wndCostApply.IFrameUrl = "CostApply.aspx?Type=View&ID=" + strApplyID;
                wndCostApply.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndCostApply.IFrameUrl = "CostApply.aspx?Type=Edit&ID=" + strApplyID;
                wndCostApply.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                BusinessManage _manage = new BusinessManage();
                BusinessCostApplyInfo _applyInfo = _manage.GetCostApplyByObjectID(strApplyID);
                if (_applyInfo != null)
                {
                    _applyInfo.IsDelete = true;
                    _manage.UpdateCostApply(_applyInfo);

                    BindGrid();
                }
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCostApply_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[2] = e.Values[2].ToString() == "0" ? "预收定金" : "业务尾款";
                e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd");
                UserInfo _approveUser = new UserManage().GetUserByObjectID(e.Values[6].ToString());
                if (_approveUser != null)
                {
                    e.Values[6] = _approveUser.Name;
                }

                switch (e.Values[7].ToString())
                {
                    case "0":
                        e.Values[7] = "待出纳确认";
                        e.Values[4] = "";
                        //e.Values[9] = "<span class=\"gray\">编辑</span>";
                        e.Values[10] = "<span class=\"gray\">删除</span>";
                        break;
                    case "1":
                        e.Values[7] = "出纳已确认";
                        //e.Values[9] = "<span class=\"gray\">编辑</span>";
                        if (CurrentLevel == VisitLevel.View)
                        {
                            e.Values[10] = "<span class=\"gray\">删除</span>";
                        }
                        break;
                    case "2":
                        e.Values[7] = "已归档";
                        if (CurrentLevel == VisitLevel.View)
                        {
                            //e.Values[9] = "<span class=\"gray\">编辑</span>";
                            e.Values[10] = "<span class=\"gray\">删除</span>";
                        }

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
        protected void wndCostApply_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}