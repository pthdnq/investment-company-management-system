using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class ChuRuApproveList : BasePage
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
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.ZJB, "4"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.JSZX, "5"));

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
            strCondition.Append(" 1 = 1 ");

            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and UserName Like '%" + tbxSearch.Text.Trim() + "%'");
            }

            if (ddlstDept.SelectedIndex != 0)
            {
                strCondition.Append(" and UserDept = '" + ddlstDept.SelectedText + "'");
            }

            if (ddlstState.SelectedIndex != 0)
            {
                strCondition.Append(" and State = " + ddlstState.SelectedValue);
            }
            strCondition.Append(" and OutTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59")
                + "'");
            strCondition.Append(" order by InTime desc");

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
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridChuRu_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strObjectID = ((GridRow)gridChuRu.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "RMDJ")
            {
                ChuRuManage _manage = new ChuRuManage();
                ChuRuInfo _info = _manage.GetChuRuByObjectID(strObjectID);
                if (_info != null)
                {
                    _info.State = 1;
                    _info.InTime = DateTime.Now;
                    _info.InUserID = CurrentUser.ObjectId;
                    _info.InUserName = CurrentUser.Name;
                    _info.InUserJobNo = CurrentUser.JobNo;
                    _info.InUserDept = CurrentUser.Dept;

                    _manage.UpdateChuRu(_info);

                    BindGrid();
                }
            }
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
                e.Values[3] = DateTime.Parse(e.Values[3].ToString()).ToString("yyyy-MM-dd HH:mm");
                switch (e.Values[7].ToString())
                {
                    case "0":
                        e.Values[4] = "";
                        e.Values[5] = "";
                        break;
                    case "1":
                        e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd HH:mm");
                        e.Values[8] = "<span class=\"gray\">入门登记</span>";
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}