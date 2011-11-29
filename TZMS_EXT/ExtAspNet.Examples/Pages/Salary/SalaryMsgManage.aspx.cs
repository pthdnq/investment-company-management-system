using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.TZMS.Business;
using com.TZMS.Model;
using System.Data;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class SalaryMsgManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wndNewSalaryMsg.OnClientCloseButtonClick = wndNewSalaryMsg.GetHidePostBackReference();

                // 绑定页面元素.
                BindDept();
                BindYear();

                ddlstYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlstMonth.SelectedValue = DateTime.Now.Month.ToString();

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
            strCondition.Append(" Year =" + ddlstYear.SelectedValue + " and Month =" + ddlstMonth.SelectedValue);
            if (ddlstDept.SelectedIndex != 0)
            {
                strCondition.Append(" and Dept = '" + ddlstDept.SelectedText + "'");
            }

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "WorkerSalaryView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridWorkerSalaryMsg.PageIndex + 1;
            _comHelp.OrderExpression = "Dept desc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridWorkerSalaryMsg.RecordCount = _comHelp.TotalCount;
            gridWorkerSalaryMsg.PageSize = PageCounts;

            //if (_comHelp.TotalCount > 0)
            //{
            //    btnNewSalaryMsg.Hidden = true;
            //    btnSave.Hidden = false;
            //}
            //else
            //{
            //    btnNewSalaryMsg.Hidden = false;
            //    btnSave.Hidden = true;
            //}

            gridWorkerSalaryMsg.DataSource = dtbLeaveApproves;
            gridWorkerSalaryMsg.DataBind();
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
        /// 新增薪资事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNewSalaryMsg_Click(object sender, EventArgs e)
        {
            wndNewSalaryMsg.IFrameUrl = "NewSalaryMsg.aspx";
            wndNewSalaryMsg.Hidden = false;
        }

        /// <summary>
        /// 新增员工薪资信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNewWorkerSalary_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridWorkerSalaryMsg_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridWorkerSalaryMsg.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridWorkerSalaryMsg_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strWorkerSalaryID = ((GridRow)gridWorkerSalaryMsg.Rows[e.RowIndex]).Values[0];
            string strSalaryMsgID = ((GridRow)gridWorkerSalaryMsg.Rows[e.RowIndex]).Values[2];

            SalaryManage _manage = new SalaryManage();
            if (e.CommandName == "Save")
            {
                string strBaseSalary =  Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxBaseSalary"];
                string strExamSalary = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxExamSalary"];
                string strBackSalary = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxBackSalary"];
                string strOtherSalary = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxOtherSalary"];
                string strShouldSalary = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxShouldSalary"];
                string strSalary = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxSalary"];
                string strContext = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxContext"];

                WorkerSalaryMsgInfo _workerSalaryMsgInfo = _manage.GetWorkerSalaryMsgByObjectID(strWorkerSalaryID);
                if (_workerSalaryMsgInfo != null)
                {
                    _workerSalaryMsgInfo.BaseSalary = Convert.ToDecimal(strBaseSalary);
                    _workerSalaryMsgInfo.ExamSalary = Convert.ToDecimal(strExamSalary);
                    _workerSalaryMsgInfo.BackSalary = Convert.ToDecimal(strBackSalary);
                    _workerSalaryMsgInfo.OtherSalary = Convert.ToDecimal(strOtherSalary);
                    _workerSalaryMsgInfo.ShouldSalary = Convert.ToDecimal(strShouldSalary);
                    _workerSalaryMsgInfo.Salary = Convert.ToDecimal(strContext);

                    _manage.UpdateWorkerSalaryMsg(_workerSalaryMsgInfo);
                    _workerSalaryMsgInfo = null;
                }
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridWorkerSalaryMsg_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewSalaryMsg_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            //BindGrid();
        }

        #endregion
    }
}