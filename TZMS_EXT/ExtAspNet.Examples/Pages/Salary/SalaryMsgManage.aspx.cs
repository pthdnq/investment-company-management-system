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
using System.Diagnostics;

namespace TZMS.Web
{
    public partial class SalaryMsgManage : BasePage
    {
        /// <summary>
        /// ApplyState
        /// </summary>
        public string ApplyState
        {
            get
            {
                if (ViewState["ApplyState"] == null)
                {
                    return null;
                }
                return ViewState["ApplyState"].ToString();
            }

            set
            {
                ViewState["ApplyState"] = value;
            }
        }

        /// <summary>
        /// ApplyState
        /// </summary>
        public string ApplyID
        {
            get
            {
                if (ViewState["ApplyID"] == null)
                {
                    return null;
                }
                return ViewState["ApplyID"].ToString();
            }

            set
            {
                ViewState["ApplyID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wndNewSalaryMsg.OnClientCloseButtonClick = wndNewSalaryMsg.GetHidePostBackReference();
                wndNewWorkerSalaryMsg.OnClientCloseButtonClick = wndNewWorkerSalaryMsg.GetHidePostBackReference();

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
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.ZJB, "4"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.JSZX, "5"));

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
            ApplyState = null;

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
            _comHelp.PageIndex = gridWorkerSalaryMsg.PageIndex;
            _comHelp.OrderExpression = "Dept desc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridWorkerSalaryMsg.RecordCount = _comHelp.TotalCount;
            gridWorkerSalaryMsg.PageSize = PageCounts;

            if (_comHelp.TotalCount > 0)
            {
                ApplyID = dtbLeaveApproves.Rows[0]["SalaryMsgID"].ToString();
                ApplyState = dtbLeaveApproves.Rows[0]["state"].ToString();
            }

            gridWorkerSalaryMsg.DataSource = dtbLeaveApproves;
            gridWorkerSalaryMsg.DataBind();

            SetControlState();
        }

        /// <summary>
        /// 保存当前页面的员工薪资信息.
        /// </summary>
        private void SaveCurrentWorkerSalary()
        {
            SalaryManage _manage = new SalaryManage();

            for (int i = 0; i < gridWorkerSalaryMsg.Rows.Count; i++)
            {
                string strWorkerSalaryID = ((GridRow)gridWorkerSalaryMsg.Rows[i]).Values[0];
                string strSalaryMsgID = ((GridRow)gridWorkerSalaryMsg.Rows[i]).Values[2];

                //string strBaseSalary = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxBaseSalary"];
                //string strExamSalary = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxExamSalary"];
                //string strBackSalary = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxBackSalary"];
                //string strOtherSalary = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxOtherSalary"];
                //string strShouldSalary = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxShouldSalary"];
                //string strSalary = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxSalary"];
                //string strContext = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxContext"];
                string strJBGZ = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxJBGZ"];
                string strGLGZ = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxGLGZ"];
                string strSYQGZ = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxSYQGZ"];
                string strNZJ = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxNZJ"];
                string strJLGZ = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxJLGZ"];
                string strKHGZ = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxKHGZ"];
                string strCB = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxCB"];
                string strJTBZ = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxJTBZ"];
                string strYFGZ = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxYFGZ"];
                string strCD = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxCD"];
                string strZT = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxZT"];
                string strKG = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxKG"];
                string strSJ = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxSJ"];
                string strBJ = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxBJ"];
                string strSB = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxSB"];
                string strFK = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxFK"];
                string strCF = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxCF"];
                string strBJF = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxBJF"];
                string strLYF = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxLYF"];
                string strSFGZ = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxSFGZ"];
                string strContext = Request.Form["gridWorkerSalaryMsg_" + i + "$tbxContext"];

                WorkerSalaryMsgInfo _workerSalaryMsgInfo = _manage.GetWorkerSalaryMsgByObjectID(strWorkerSalaryID);
                if (_workerSalaryMsgInfo != null)
                {
                    //_workerSalaryMsgInfo.BaseSalary = Convert.ToDecimal(strBaseSalary);
                    //_workerSalaryMsgInfo.ExamSalary = Convert.ToDecimal(strExamSalary);
                    //_workerSalaryMsgInfo.BackSalary = Convert.ToDecimal(strBackSalary);
                    //_workerSalaryMsgInfo.OtherSalary = Convert.ToDecimal(strOtherSalary);
                    //_workerSalaryMsgInfo.ShouldSalary = Convert.ToDecimal(strShouldSalary);
                    //_workerSalaryMsgInfo.Salary = Convert.ToDecimal(strSalary);
                    //_workerSalaryMsgInfo.Context = strContext;

                    _workerSalaryMsgInfo.Jbgz = strJBGZ;
                    _workerSalaryMsgInfo.Glgz = strGLGZ;
                    _workerSalaryMsgInfo.Syqgz = strSYQGZ;
                    _workerSalaryMsgInfo.Nzj = strNZJ;
                    _workerSalaryMsgInfo.Jlgz = strJLGZ;
                    _workerSalaryMsgInfo.Khgz = strKHGZ;
                    _workerSalaryMsgInfo.Cb = strCB;
                    _workerSalaryMsgInfo.Jtbz = strJTBZ;
                    _workerSalaryMsgInfo.Yfgz = strYFGZ;
                    _workerSalaryMsgInfo.Cd = strCD;
                    _workerSalaryMsgInfo.Zt = strZT;
                    _workerSalaryMsgInfo.Kg = strKG;
                    _workerSalaryMsgInfo.Sj = strSJ;
                    _workerSalaryMsgInfo.Bj = strBJ;
                    _workerSalaryMsgInfo.Sb = strSB;
                    _workerSalaryMsgInfo.Fk = strFK;
                    _workerSalaryMsgInfo.Cf = strCF;
                    _workerSalaryMsgInfo.Bjf = strBJF;
                    _workerSalaryMsgInfo.Lyf = strLYF;
                    _workerSalaryMsgInfo.Sfgz = strSFGZ;
                    _workerSalaryMsgInfo.Context = strContext;

                    _manage.UpdateWorkerSalaryMsg(_workerSalaryMsgInfo);
                    _workerSalaryMsgInfo = null;
                }
            }
        }

        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlState()
        {
            if (!string.IsNullOrEmpty(ApplyState))
            {
                btnNewSalaryMsg.Enabled = false;
                if (ApplyState == "-1" || ApplyState == "1")
                {
                    btnSave.Enabled = true;
                    btnNewWorkerSalary.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                    btnNewWorkerSalary.Enabled = false;
                }
            }
            else
            {
                btnNewSalaryMsg.Enabled = true;
                btnSave.Enabled = false;
                btnNewWorkerSalary.Enabled = false;
            }
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
            wndNewWorkerSalaryMsg.IFrameUrl = "NewWorkerSalaryMsg.aspx?ID=" + ApplyID;
            wndNewWorkerSalaryMsg.Hidden = false;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveCurrentWorkerSalary();
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
                //string strBaseSalary = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxBaseSalary"];
                //string strExamSalary = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxExamSalary"];
                //string strBackSalary = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxBackSalary"];
                //string strOtherSalary = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxOtherSalary"];
                //string strShouldSalary = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxShouldSalary"];
                //string strSalary = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxSalary"];
                string strJBGZ = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxJBGZ"];
                string strGLGZ = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxGLGZ"];
                string strSYQGZ = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxSYQGZ"];
                string strNZJ = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxNZJ"];
                string strJLGZ = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxJLGZ"];
                string strKHGZ = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxKHGZ"];
                string strCB = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxCB"];
                string strJTBZ = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxJTBZ"];
                string strYFGZ = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxYFGZ"];
                string strCD = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxCD"];
                string strZT = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxZT"];
                string strKG = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxKG"];
                string strSJ = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxSJ"];
                string strBJ = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxBJ"];
                string strSB = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxSB"];
                string strFK = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxFK"];
                string strCF = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxCF"];
                string strBJF = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxBJF"];
                string strLYF = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxLYF"];
                string strSFGZ = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxSFGZ"];
                string strContext = Request.Form["gridWorkerSalaryMsg_" + e.RowIndex.ToString() + "$tbxContext"];

                WorkerSalaryMsgInfo _workerSalaryMsgInfo = _manage.GetWorkerSalaryMsgByObjectID(strWorkerSalaryID);
                if (_workerSalaryMsgInfo != null)
                {
                    //_workerSalaryMsgInfo.BaseSalary = Convert.ToDecimal(strBaseSalary);
                    //_workerSalaryMsgInfo.ExamSalary = Convert.ToDecimal(strExamSalary);
                    //_workerSalaryMsgInfo.BackSalary = Convert.ToDecimal(strBackSalary);
                    //_workerSalaryMsgInfo.OtherSalary = Convert.ToDecimal(strOtherSalary);
                    //_workerSalaryMsgInfo.ShouldSalary = Convert.ToDecimal(strShouldSalary);
                    //_workerSalaryMsgInfo.Salary = Convert.ToDecimal(strSalary);
                    _workerSalaryMsgInfo.Jbgz = strJBGZ;
                    _workerSalaryMsgInfo.Glgz = strGLGZ;
                    _workerSalaryMsgInfo.Syqgz = strSYQGZ;
                    _workerSalaryMsgInfo.Nzj = strNZJ;
                    _workerSalaryMsgInfo.Jlgz = strJLGZ;
                    _workerSalaryMsgInfo.Khgz = strKHGZ;
                    _workerSalaryMsgInfo.Cb = strCB;
                    _workerSalaryMsgInfo.Jtbz = strJTBZ;
                    _workerSalaryMsgInfo.Yfgz = strYFGZ;
                    _workerSalaryMsgInfo.Cd = strCD;
                    _workerSalaryMsgInfo.Zt = strZT;
                    _workerSalaryMsgInfo.Kg = strKG;
                    _workerSalaryMsgInfo.Sj = strSJ;
                    _workerSalaryMsgInfo.Bj = strBJ;
                    _workerSalaryMsgInfo.Sb = strSB;
                    _workerSalaryMsgInfo.Fk = strFK;
                    _workerSalaryMsgInfo.Cf = strCF;
                    _workerSalaryMsgInfo.Bjf = strBJF;
                    _workerSalaryMsgInfo.Lyf = strLYF;
                    _workerSalaryMsgInfo.Sfgz = strSFGZ;
                    _workerSalaryMsgInfo.Context = strContext;

                    _manage.UpdateWorkerSalaryMsg(_workerSalaryMsgInfo);
                    _workerSalaryMsgInfo = null;
                }
            }

            if (e.CommandName == "Delete")
            {
                _manage.DeleteWorkerSalaryMsg(strWorkerSalaryID);

                BindGrid();
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridWorkerSalaryMsg_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                //DataRowView _view = (DataRowView)e.DataItem;
                //int state = Convert.ToInt32(_view["state"]);
                //if (state != -1 && state != 2)
                //{
                //    e.Values[12] = "<span class=\"gray\">保存</span>";
                //    e.Values[13] = "<span class=\"gray\">删除</span>";
                //}
                if (!string.IsNullOrEmpty(ApplyState))
                {
                    if (ApplyState == "-1" || ApplyState == "1")
                    {

                    }
                    else
                    {
                        e.Values[12] = "<span class=\"gray\">保存</span>";
                        e.Values[13] = "<span class=\"gray\">删除</span>";
                    }
                }
            }
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewSalaryMsg_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 添加员工薪资信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewWorkerSalaryMsg_Close(object sender, WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}