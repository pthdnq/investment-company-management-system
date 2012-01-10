using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.TZMS.Business;
using System.Data;

namespace TZMS.Web
{
    public partial class MySalary : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindYear();

                ddlstYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlstMonth.SelectedValue = DateTime.Now.Month.ToString();

                BindGrid();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定年
        /// </summary>
        private void BindYear()
        {
            int year = DateTime.Now.Year;
            string tempString = string.Empty;
            for (int i = -3; i < 2; i++)
            {
                tempString = (year + i).ToString();
                ddlstYear.Items.Add(new ExtAspNet.ListItem(tempString, tempString));
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGrid()
        {

            #region 查询条件

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" UserID='" + CurrentUser.ObjectId.ToString() + "'");
            strCondition.Append(" and state = 3");
            strCondition.Append(" and Year =" + ddlstYear.SelectedValue + " and Month =" + ddlstMonth.SelectedValue);

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "WorkerSalaryView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.OrderExpression = " Dept desc";
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridSalary.PageIndex;

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridSalary.RecordCount = _comHelp.TotalCount;
            gridSalary.PageSize = PageCounts;
            gridSalary.DataSource = dtbLeaveApproves;
            gridSalary.DataBind();
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
        protected void gridSalary_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridSalary.PageIndex = e.NewPageIndex;
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridSalary_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {

        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridSalary_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {

        }

        #endregion
    }
}