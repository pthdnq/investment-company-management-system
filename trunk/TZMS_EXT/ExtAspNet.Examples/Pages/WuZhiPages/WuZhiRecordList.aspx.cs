using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Business;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class WuZhiRecordList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                BindDept();
                BindGrid();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定部门.
        /// </summary>
        private void BindDept()
        {
            // 设置部门下拉框的值.
            ddlstDept.Items.Add(new ExtAspNet.ListItem("全部", "-1"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.XINGZHENG, "0"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.CAIWU, "1"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.TOUZI, "2"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.YEWU, "3"));

            // 设置默认值.
            ddlstDept.SelectedIndex = 0;
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
            strCondition.Append(" Isdelete = 0 and state = 2");
            //strCondition.Append(" and UserID <> '" + CurrentUser.ObjectId.ToString() + "'");

            // 查询文本
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append("  and (Title like '%" + tbxSearch.Text.Trim() + "%' or UserName like '%" + tbxSearch.Text.Trim() + "%')");
            }

            // 物资类型.
            if (ddlstWuZhiType.SelectedIndex == 1)
            {
                strCondition.Append(" and type = 0");
            }
            else if (ddlstWuZhiType.SelectedIndex == 2)
            {
                strCondition.Append(" and type = 1");
            }

            // 部门.
            if (ddlstDept.SelectedIndex != 0)
            {
                strCondition.Append(" and Dept = '" + ddlstDept.SelectedText + "'");
            }

            strCondition.Append(" and ApplyTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

            #endregion

            List<WuZhiInfo> lstWuZhi = new WuZhiManage().GetWuZhiByCondition(strCondition.ToString());
            this.gridApprove.RecordCount = lstWuZhi.Count;
            this.gridApprove.PageSize = PageCounts;
            int currentIndex = this.gridApprove.PageIndex;
            //计算当前页面显示行数据
            if (lstWuZhi.Count > this.gridApprove.PageSize)
            {
                if (lstWuZhi.Count > (currentIndex + 1) * this.gridApprove.PageSize)
                {
                    lstWuZhi.RemoveRange((currentIndex + 1) * this.gridApprove.PageSize, lstWuZhi.Count - (currentIndex + 1) * this.gridApprove.PageSize);
                }
                lstWuZhi.RemoveRange(0, currentIndex * this.gridApprove.PageSize);
            }
            this.gridApprove.DataSource = lstWuZhi;
            this.gridApprove.DataBind();

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
        protected void gridApprove_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridApprove.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApprove_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strWuZhiID = ((GridRow)gridApprove.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "Record")
            {
                wndApprove.IFrameUrl = "WuZhiRecord.aspx?Type=Record&ID=" + strWuZhiID;
                wndApprove.Hidden = false;
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
        protected void gridApprove_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {

            if (e.DataItem != null)
            {
                e.Values[3] = e.Values[3].ToString() == "0" ? "一般物资" : "固定资产";
                e.Values[7] = DateTime.Parse(e.Values[7].ToString()).ToString("yyyy-MM-dd HH:mm");
            }
        }

        /// <summary>
        /// 领用窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndApprove_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}