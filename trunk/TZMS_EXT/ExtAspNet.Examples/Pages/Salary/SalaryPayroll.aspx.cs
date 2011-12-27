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
    public partial class SalaryPayroll : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("xzff");

                wndApply.OnClientCloseButtonClick = wndApply.GetHidePostBackReference();

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
        /// 绑定报销申请单列表
        /// </summary>
        private void BindGrid()
        {
            #region 查询条件

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" state = " + ddlState.SelectedValue);
            strCondition.Append(" and Year = " + ddlstYear.SelectedValue);
            strCondition.Append(" and Month = " + ddlstMonth.SelectedValue);

            #endregion

            //获得员工
            List<SalaryMsgInfo> lstSalaryMsgInfo = new SalaryManage().GetSalaryMsgByCondition(strCondition.ToString());
            this.gridApply.RecordCount = lstSalaryMsgInfo.Count;
            this.gridApply.PageSize = PageCounts;
            int currentIndex = this.gridApply.PageIndex;
            //计算当前页面显示行数据
            if (lstSalaryMsgInfo.Count > this.gridApply.PageSize)
            {
                if (lstSalaryMsgInfo.Count > (currentIndex + 1) * this.gridApply.PageSize)
                {
                    lstSalaryMsgInfo.RemoveRange((currentIndex + 1) * this.gridApply.PageSize, lstSalaryMsgInfo.Count - (currentIndex + 1) * this.gridApply.PageSize);
                }
                lstSalaryMsgInfo.RemoveRange(0, currentIndex * this.gridApply.PageSize);
            }
            this.gridApply.DataSource = lstSalaryMsgInfo;
            this.gridApply.DataBind();
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
        /// 申请窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndApply_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridApply.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApplyID = ((GridRow)gridApply.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "Payroll")
            {
                wndApply.IFrameUrl = "SalaryPayrollConfirm.aspx?ID=" + strApplyID;
                wndApply.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                switch (e.Values[4].ToString())
                {
                    case "2":
                        e.Values[4] = "待发放";
                        break;
                    case "3":
                        e.Values[4] = "已发放";
                        e.Values[5] = "<span class=\"gray\">发放</span>";
                        break;
                    default:
                        break;
                }

                if (CurrentLevel == VisitLevel.View)
                {
                    e.Values[5] = "<span class=\"gray\">发放</span>";
                }
            }
        }

        #endregion
    }
}