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
    public partial class ProbationYear : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            #region 条件

            if (!string.IsNullOrEmpty(tbxMinYear.Text.Trim()) && !string.IsNullOrEmpty(tbxMaxYear.Text.Trim()))
            {
                int nMinYear = Convert.ToInt32(tbxMinYear.Text.Trim());
                int nMaxYear = Convert.ToInt32(tbxMaxYear.Text.Trim());

                if (nMaxYear <= nMinYear)
                {
                    Alert.Show("最大年数不可小于等于最小年数");
                    return;
                }
            }

            StringBuilder strCondtion = new StringBuilder();
            strCondtion.Append(" 1 =1 ");
            if (ddlstDept.SelectedIndex != 0)
            {
                strCondtion.Append(" and Dept='" + ddlstDept.SelectedText + "'");
            }
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondtion.Append(" and (Name like '%" + tbxSearch.Text.Trim() + "%' or AccountNo like '%" + tbxSearch.Text.Trim() + "%')");
            }

            if (!string.IsNullOrEmpty(tbxMinYear.Text.Trim()))
            {
                int nMinYear = Convert.ToInt32(tbxMinYear.Text.Trim());
                strCondtion.Append(" and DATEDIFF(DAY, ProbationTime, GETDATE())/365 >= " + nMinYear);
            }

            if (!string.IsNullOrEmpty(tbxMaxYear.Text.Trim()))
            {
                int nMaxYear = Convert.ToInt32(tbxMaxYear.Text.Trim());
                strCondtion.Append(" and DATEDIFF(DAY, ProbationTime, GETDATE())/365 <= " + nMaxYear);
            }

            //未删除
            strCondtion.Append(" and state = 1 and IsProbation = 1 ");

            #endregion

            //获得员工
            List<UserInfo> lstUserInfo = new UserManage().GetUsersByCondtion(strCondtion.ToString());
            this.gridUser.RecordCount = lstUserInfo.Count;
            this.gridUser.PageSize = PageCounts;
            int currentIndex = this.gridUser.PageIndex;
            //计算当前页面显示行数据
            if (lstUserInfo.Count > this.gridUser.PageSize)
            {
                if (lstUserInfo.Count > (currentIndex + 1) * this.gridUser.PageSize)
                {
                    lstUserInfo.RemoveRange((currentIndex + 1) * this.gridUser.PageSize, lstUserInfo.Count - (currentIndex + 1) * this.gridUser.PageSize);
                }
                lstUserInfo.RemoveRange(0, currentIndex * this.gridUser.PageSize);
            }
            this.gridUser.DataSource = lstUserInfo;
            this.gridUser.DataBind();
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
        protected void gridUser_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridUser.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {

        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                DateTime probationTime = DateTime.Parse(e.Values[6].ToString());
                e.Values[6] = probationTime.ToString("yyyy-MM-dd");
                int i = Convert.ToInt32(((TimeSpan)(DateTime.Now - probationTime)).TotalDays / 365);
                if (i >= 1)
                {
                    e.Values[7] = i + "年";
                }
                else
                {
                    e.Values[7] = "不到1年";
                }
                if (e.Values[6].ToString().Contains("9999-"))
                {
                    e.Values[6] = "";
                }
            }
        }

        #endregion
    }
}