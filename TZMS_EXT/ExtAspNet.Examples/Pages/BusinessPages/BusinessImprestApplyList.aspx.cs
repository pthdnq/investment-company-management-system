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
    public partial class BusinessImprestApplyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("byjsq");

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                btnNewBusinessImprestApply.OnClientClick = wndNewBusinessImprestApply.GetShowReference("NewBusinessImprestApply.aspx?Type=Add") + "return false;";
                wndNewBusinessImprestApply.OnClientCloseButtonClick = wndNewBusinessImprestApply.GetHidePostBackReference();

                BindGrid();

                if (CurrentLevel == VisitLevel.View)
                {
                    btnNewBusinessImprestApply.Enabled = false;
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
            strCondition.Append(" and UserID ='" + CurrentUser.ObjectId.ToString() + "'");
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and BusinessName Like '%" + tbxSearch.Text.Trim() + "%'");
            }

            strCondition.Append(" and State = " + Convert.ToInt32(ddlstAproveState.SelectedValue));
            strCondition.Append(" and ApplyTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

            #endregion

            List<BusinessImprestApplyInfo> lstApply = new BusinessManage().GetImprestApplyByCondition(strCondition.ToString());
            this.gridBusinessImprestApply.RecordCount = lstApply.Count;
            this.gridBusinessImprestApply.PageSize = PageCounts;
            int currentIndex = this.gridBusinessImprestApply.PageIndex;
            //计算当前页面显示行数据
            if (lstApply.Count > this.gridBusinessImprestApply.PageSize)
            {
                if (lstApply.Count > (currentIndex + 1) * this.gridBusinessImprestApply.PageSize)
                {
                    lstApply.RemoveRange((currentIndex + 1) * this.gridBusinessImprestApply.PageSize, lstApply.Count - (currentIndex + 1) * this.gridBusinessImprestApply.PageSize);
                }
                lstApply.RemoveRange(0, currentIndex * this.gridBusinessImprestApply.PageSize);
            }
            this.gridBusinessImprestApply.DataSource = lstApply;
            this.gridBusinessImprestApply.DataBind();
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
        protected void gridBusinessImprestApply_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridBusinessImprestApply.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBusinessImprestApply_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApplyID = ((GridRow)gridBusinessImprestApply.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "View")
            {
                wndNewBusinessImprestApply.IFrameUrl = "NewBusinessImprestApply.aspx?Type=View&ID=" + strApplyID;
                wndNewBusinessImprestApply.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndNewBusinessImprestApply.IFrameUrl = "NewBusinessImprestApply.aspx?Type=Edit&ID=" + strApplyID;
                wndNewBusinessImprestApply.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                BusinessManage _manage = new BusinessManage();
                BusinessImprestApplyInfo _info = _manage.GetImprestApplyByObjectID(strApplyID);
                if (_info != null)
                {
                    _info.IsDelete = true;
                    _manage.UpdateImprestApply(_info);

                    BindGrid();
                }
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBusinessImprestApply_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[2] = DateTime.Parse(e.Values[2].ToString()).ToString("yyyy-MM-dd HH:mm");
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
                        e.Values[7] = "未通过";
                        break;
                    case "2":
                        e.Values[7] = "归档";
                        e.Values[9] = "<span class=\"gray\">编辑</span>";
                        e.Values[10] = "<span class=\"gray\">删除</span>";
                        break;
                    default:
                        break;
                }

                if (CurrentLevel == VisitLevel.View)
                {
                    e.Values[9] = "<span class=\"gray\">编辑</span>";
                    e.Values[10] = "<span class=\"gray\">删除</span>";
                }
            }
        }

        /// <summary>
        /// 新增窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewBusinessImprestApply_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}