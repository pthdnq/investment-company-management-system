using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Data;

namespace TZMS.Web
{
    public partial class MaterialsStatistics : BasePage
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
            strCondition.Append(" ApproveOp = 4");

            // 查询文本
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append("  and (MaterialsName like '%" + tbxSearch.Text.Trim() + "%' or UserName like '%" + tbxSearch.Text.Trim() + "%')");
            }

            // 物资类型.
            if (ddlstType.SelectedValue != "all")
            {
                strCondition.Append(" and MaterialsType = " + ddlstType.SelectedValue);
            }

            // 部门.
            if (ddlstDept.SelectedIndex != 0)
            {
                strCondition.Append(" and UserDept = '" + ddlstDept.SelectedText + "'");
            }

            strCondition.Append(" and (ApproveTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '"
                + endTime.ToString("yyyy-MM-dd 23:59") + "' or ApproveTime='"
                + ACommonInfo.DBMAXDate.ToString() + "')");

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "MaterialApproveView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridComsumeHistory.PageIndex;
            _comHelp.OrderExpression = "ApproveTime desc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);

            //_comHelp.SelectList = "sum(ActualCount) as TotalNumber, count(ApplyID) as TotalCount1";
            //_comHelp.OrderExpression = "NULL";
            //DataTable dbtCount = _commSelect.ComSelect(ref _comHelp);


            //if (dbtCount.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtbLeaveApproves.Rows.Count; i++)
            //    {
            //        dtbLeaveApproves.Rows[i]["TotalNumber"] = dbtCount.Rows[0]["TotalNumber"];
            //        dtbLeaveApproves.Rows[i]["TotalCount1"] = dbtCount.Rows[0]["TotalCount1"];
            //    }
            //}

            dtbLeaveApproves.Columns.Add(new DataColumn("TotalNumber", System.Type.GetType("System.String")));
            dtbLeaveApproves.Columns.Add(new DataColumn("TotalCount", System.Type.GetType("System.String")));

            for (int i = 0; i < dtbLeaveApproves.Rows.Count; i++)
            {
                DataRow[] foundRows;
                foundRows = dtbLeaveApproves.Select("MaterialsID = '" + dtbLeaveApproves.Rows[i]["MaterialsID"] + "'");
                int nCount = 0;
                foreach (DataRow row in foundRows)
                {
                    nCount += Convert.ToInt32(row["ActualCount"]);
                }

                foreach (DataRow row in foundRows)
                {
                    row["TotalNumber"] = nCount;
                    row["TotalCount"] = foundRows.Length;
                }
            }
            
            gridComsumeHistory.RecordCount = _comHelp.TotalCount;
            gridComsumeHistory.PageSize = PageCounts;
            gridComsumeHistory.DataSource = dtbLeaveApproves.Rows;
            gridComsumeHistory.DataBind();
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
        protected void gridComsumeHistory_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridComsumeHistory.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridComsumeHistory_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {

        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridComsumeHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[2] = e.Values[2].ToString() == "0" ? "办公用品" : "固定资产";
                e.Values[9] = DateTime.Parse(e.Values[9].ToString()).ToString("yyyy-MM-dd HH:mm");
            }
        }

        #endregion
    }
}