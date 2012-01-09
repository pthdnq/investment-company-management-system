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

namespace TZMS.Web
{
    public partial class CostApplyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCostApply_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {

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