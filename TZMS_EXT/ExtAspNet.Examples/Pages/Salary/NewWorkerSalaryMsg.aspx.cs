using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class NewWorkerSalaryMsg : BasePage
    {
        /// <summary>
        /// ApplyID
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
                ApplyID = Request.QueryString["ID"];

                BindWorkerMsgInfo();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定事件
        /// </summary>
        private void BindWorkerMsgInfo()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;

            SalaryManage _manage = new SalaryManage();
            SalaryMsgInfo _info = _manage.GetSalaryMsgByObjectID(ApplyID);
            if (_info != null)
            {
                lblYear.Text = _info.Year.ToString();
                lblMonth.Text = _info.Month.ToString();
            }
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;
            if (Session["ChooseWorkerSalaryMsg" + CurrentUser.ObjectId.ToString()] == null)
            {
                Alert.Show("请选择员工!");
                tbxName.Text = "";
                return;
            }

            string strUserID = Session["ChooseWorkerSalaryMsg" + CurrentUser.ObjectId.ToString()].ToString().Split(',')[0];

            SalaryManage _manage = new SalaryManage();
            UserInfo _userInfo = new UserManage().GetUserByObjectID(strUserID);
            if (_userInfo != null)
            {
                WorkerSalaryMsgInfo _info = new WorkerSalaryMsgInfo();
                _info.ObjectId = Guid.NewGuid();
                _info.UserId = _userInfo.ObjectId;
                _info.Name = _userInfo.Name;
                _info.Dept = _userInfo.Dept;
                //_info.BaseSalary = Convert.ToDecimal(tbxBaseSalary.Text.Trim());
                //_info.ExamSalary = Convert.ToDecimal(tbxExamSalary.Text.Trim());
                //_info.BackSalary = Convert.ToDecimal(tbxBackSalary.Text.Trim());
                //_info.OtherSalary = Convert.ToDecimal(tbxOtherSalary.Text.Trim());
                //_info.ShouldSalary = Convert.ToDecimal(tbxShouldSalary.Text.Trim());
                //_info.Salary = Convert.ToDecimal(tbxSalary.Text.Trim());
                _info.Jbgz = tbxJBGZ.Text.Trim();
                _info.Glgz = tbxGLGZ.Text.Trim();
                _info.Syqgz = tbxSYQGZ.Text.Trim();
                _info.Nzj = tbxNZJ.Text.Trim();
                _info.Jlgz = tbxJLGZ.Text.Trim();
                _info.Khgz = tbxJLGZ.Text.Trim();
                _info.Cb = tbxCB.Text.Trim();
                _info.Jtbz = tbxJTBZ.Text.Trim();
                _info.Yfgz = tbxYFGZ.Text.Trim();
                _info.Cd = tbxCD.Text.Trim();
                _info.Zt = tbxZT.Text.Trim();
                _info.Kg = tbxKG.Text.Trim();
                _info.Sj = tbxSJ.Text.Trim();
                _info.Bj = tbxBJ.Text.Trim();
                _info.Sb = tbxSB.Text.Trim();
                _info.Fk = tbxFK.Text.Trim();
                _info.Cf = tbxCF.Text.Trim();
                _info.Bjf = tbxBJF.Text.Trim();
                _info.Lyf = tbxLYF.Text.Trim();
                _info.Sfgz = tbxSFGZ.Text.Trim();
                _info.Context = taaContext.Text.Trim();
                _info.SalaryMsgId = new Guid(ApplyID);

                int reslut = _manage.AddNewWorkerSalaryMsg(_info);
                if (reslut == -1)
                {
                    Session["ChooseWorkerSalaryMsg" + CurrentUser.ObjectId.ToString()] = null;
                    this.btnClose_Click(null, null);
                }
                else
                {
                    Alert.Show("添加员工薪资信息失败!");
                }
            }
        }

        /// <summary>
        /// 选择员工窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndSelectWorker_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            if (Session["ChooseWorkerSalaryMsg" + CurrentUser.ObjectId.ToString()] != null)
            {
                tbxName.Text = Session["ChooseWorkerSalaryMsg" + CurrentUser.ObjectId.ToString()].ToString().Split(',')[1];
                UserManage _userManage = new UserManage();
                UserInfo _userInfo = _userManage.GetUserByObjectID(Session["ChooseWorkerSalaryMsg" + CurrentUser.ObjectId.ToString()].ToString().Split(',')[0]);
                if (_userInfo != null)
                {
                    tbxJBGZ.Text = _userInfo.BaseSalary.ToString();
                    //tbxBaseSalary.Text = _userInfo.BaseSalary.ToString();
                }
            }
        }

        /// <summary>
        /// 选取员工事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChooseUser_Click(object sender, EventArgs e)
        {
            wndSelectWorker.IFrameUrl = "SelectWorker.aspx?ID=" + ApplyID;
            wndSelectWorker.Hidden = false;
        }

        #endregion
    }
}