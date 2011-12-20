using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class ChuRuApplyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                btnNewChuRu.OnClientClick = wndNewProxy.GetShowReference("ChuRuApply.aspx") + "return false;";
                wndNewProxy.OnClientCloseButtonClick = wndNewProxy.GetHidePostBackReference();

                BindGrid();
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

            strCondition.Append(" UserID ='" + CurrentUser.ObjectId.ToString() + "'");

            strCondition.Append(" and State = " + Convert.ToInt32(ddlstState.SelectedValue));
            strCondition.Append(" and OutTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

            #endregion

            List<ChuRuInfo> lstChuRu = new ChuRuManage().GetUnitByCondition(strCondition.ToString());
            this.gridChuRu.RecordCount = lstChuRu.Count;
            this.gridChuRu.PageSize = PageCounts;
            int currentIndex = this.gridChuRu.PageIndex;
            //计算当前页面显示行数据
            if (lstChuRu.Count > this.gridChuRu.PageSize)
            {
                if (lstChuRu.Count > (currentIndex + 1) * this.gridChuRu.PageSize)
                {
                    lstChuRu.RemoveRange((currentIndex + 1) * this.gridChuRu.PageSize, lstChuRu.Count - (currentIndex + 1) * this.gridChuRu.PageSize);
                }
                lstChuRu.RemoveRange(0, currentIndex * this.gridChuRu.PageSize);
            }
            this.gridChuRu.DataSource = lstChuRu;
            this.gridChuRu.DataBind();
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
        protected void gridChuRu_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridChuRu.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridChuRu_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[1] = DateTime.Parse(e.Values[1].ToString()).ToString("yyyy-MM-dd HH:mm");
                switch (e.Values[4].ToString())
                {
                    case "0":
                        e.Values[4] = "已出门登记";
                        e.Values[3] = "";
                        break;
                    case "1":
                        e.Values[3] = DateTime.Parse(e.Values[3].ToString()).ToString("yyyy-MM-dd HH:mm");
                        e.Values[4] = "已入门登记";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 出门登记窗口关闭事件
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