using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business;
using ExtAspNet;
using System.Text;

namespace TZMS.Web
{
    public partial class NewCommonYeWu : BasePage
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperatorType
        {
            get
            {
                if (ViewState["OperatorType"] == null)
                {
                    return null;
                }

                return ViewState["OperatorType"].ToString();
            }
            set
            {
                ViewState["OperatorType"] = value;
            }
        }

        /// <summary>
        /// 报销单ID
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
                OperatorType = Request.QueryString["Type"];
                ApplyID = Request.QueryString["ID"];
                switch (OperatorType)
                {
                    case "Add":
                        tabApproveHistory.Hidden = true;
                        InitCurrentChecker();
                        break;
                    case "View":
                        if (!string.IsNullOrEmpty(ApplyID))
                        {
                            BindYeWuInfo();
                            BindHistory();
                            DisabledAllControls();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 初始化当前责任人、签单人、签单时间
        /// </summary>
        private void InitCurrentChecker()
        {
            List<UserInfo> listInfo = this.CurrentChecker;
            listInfo.Add(this.CurrentUser);
            ddlstApproveUser.Items.Clear();
            drpSigner.Items.Clear();
            foreach (UserInfo item in listInfo)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
                drpSigner.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
            }
            ddlstApproveUser.SelectedIndex = listInfo.Count - 1;
            drpSigner.SelectedIndex = listInfo.Count - 1;
            //ddlstNext.Items.Add(new ExtAspNet.ListItem("谈业务、签合同", "0"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("业务转交", "1"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("核名", "2"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("刻章", "3"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("开户", "4"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("验资报告", "5"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("营业执照", "6"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("办代码证", "7"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("办国地税", "8"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("转基本户", "9"));
            ddlstNext.SelectedIndex = 0;

            dpkSign.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 绑定业务信息
        /// </summary>
        private void BindYeWuInfo()
        {
           YewuManage _manage =  new YewuManage();
            // 绑定第一步操作的人员.
            List<YeWuGudingDoingInfo> lstYeWuGuding = new YewuManage().GetYeWuDoingForList(" ApplyID='" + ApplyID + "' and OrderIndex = 1");
            if (lstYeWuGuding.Count > 0)
            {
                ddlstNext.Items.Add(new ExtAspNet.ListItem("业务转交", "1"));
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(lstYeWuGuding[0].CheckerName, lstYeWuGuding[0].CheckerId.ToString()));
            }
            // 绑定申请单信息.
            // 绑定签单人.
            lstYeWuGuding = new YewuManage().GetYeWuDoingForList(" ApplyID='" + ApplyID + "' and OrderIndex = 0");
            if (lstYeWuGuding.Count > 0)
            {
                drpSigner.Items.Add(new ExtAspNet.ListItem(lstYeWuGuding[0].CheckerName, lstYeWuGuding[0].CheckerId.ToString()));
            }
            YeWuInfo _applyInfo = _manage.GetYeWuForObject(ApplyID);
            if (_applyInfo != null)
            {
                dpkSign.SelectedDate = _applyInfo.SignDate;
                tbxTitle.Text = _applyInfo.Title;
                taaSument.Text = _applyInfo.Sument;
                taaOther.Text = _applyInfo.Other;
            }
        }

        /// <summary>
        /// 禁用所有控件
        /// </summary>
        private void DisabledAllControls()
        {
            btnSubmit.Enabled = false;
            ddlstNext.Required = false;
            ddlstNext.ShowRedStar = false;
            ddlstNext.Enabled = false;
            ddlstApproveUser.Required = false;
            ddlstApproveUser.ShowRedStar = false;
            ddlstApproveUser.Enabled = false;
            drpSigner.Required = false;
            drpSigner.ShowRedStar = false;
            drpSigner.Enabled = false;
            dpkSign.Required = false;
            dpkSign.ShowRedStar = false;
            dpkSign.Enabled = false;
            tbxTitle.Required = false;
            tbxTitle.ShowRedStar = false;
            tbxTitle.Enabled = false;
            taaSument.Required = false;
            taaSument.ShowRedStar = false;
            taaSument.Enabled = false;
            taaOther.Enabled = false;
        }

        /// <summary>
        /// 绑定历史
        /// </summary>
        private void BindHistory()
        {
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" ApplyID = '" + ApplyID + "'");
            strCondition.Append(" and  Checkstate = 1 ");
            List<YeWuGudingDoingInfo> lstBaoxiaoCheckInfo = new YewuManage().GetYeWuDoingForList(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(YeWuGudingDoingInfo x, YeWuGudingDoingInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridApproveHistory.DataBind();
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 保存表单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            YeWuInfo yewu = new YeWuInfo();
            YeWuGudingDoingInfo yewuCheck = new YeWuGudingDoingInfo();

            List<UserInfo> listInfo = this.CurrentChecker;
            listInfo.Add(this.CurrentUser);

            //签单人
            UserInfo checker = new UserInfo();
            //责任人
            UserInfo zrenCheck = new UserInfo();
            foreach (UserInfo user in listInfo)
            {
                if (user.ObjectId.ToString() == this.drpSigner.SelectedValue.Trim())
                {
                    checker = user;
                }
                if (user.ObjectId.ToString() == this.ddlstApproveUser.SelectedValue.Trim())
                {
                    zrenCheck = user;
                }
            }

            //业务表单
            yewu.UserName = checker.Name;
            yewu.UserId = checker.ObjectId;
            yewu.UserJobNo = checker.JobNo;
            yewu.UserAccountNo = checker.AccountNo;
            yewu.Dept = checker.Dept;
            yewu.CurrentCheckerId = new Guid(this.ddlstApproveUser.SelectedValue);
            //未完成，普通业务
            yewu.State = 0;
            yewu.Type = 1;
            yewu.Sument = this.taaSument.Text.Trim();
            yewu.Title = this.tbxTitle.Text.Trim();
            yewu.Other = this.taaOther.Text.Trim();
            yewu.SignDate = DateTime.Parse(dpkSign.Text.Trim());
            //流程单
            yewuCheck.CheckerId = checker.ObjectId;
            yewuCheck.CheckerName = checker.Name;
            yewuCheck.CheckrDept = checker.Dept;
            yewuCheck.CheckDateTime = DateTime.Now;
            yewuCheck.Checkstate = 1;
            yewuCheck.CheckSugest = string.Empty;
            yewuCheck.CheckDateTime = DateTime.Now;
            yewuCheck.OrderIndex = 0;
            yewuCheck.Result = "起草";
            yewuCheck.CheckOp = "谈业务、签合同";
            yewu.ObjectId = Guid.NewGuid();
            yewuCheck.ObjectId = Guid.NewGuid();
            yewuCheck.ApplyId = yewu.ObjectId;

            //新增
            YewuManage yewuManage = new YewuManage();
            yewuManage.AddYeWu(yewu, yewuCheck);
            #region 备用记录
            //新增记录表
            List<YeWuGudingDoingInfo> list = new List<YeWuGudingDoingInfo>();
            foreach (UserInfo user in listInfo)
            {
                if (user.ObjectId.ToString() == this.ddlstApproveUser.SelectedValue.Trim())
                {
                    checker = user;
                    break;
                }
            }
            YeWuGudingDoingInfo ywInfo = new YeWuGudingDoingInfo();
            ywInfo.CheckerId = checker.ObjectId;
            ywInfo.CheckerName = checker.Name;
            ywInfo.CheckrDept = checker.Dept;
            ywInfo.Checkstate = 0;
            ywInfo.ApplyId = yewu.ObjectId;
            ywInfo.OrderIndex = short.Parse(ddlstNext.SelectedValue.Trim());
            ywInfo.CheckOp = ddlstNext.SelectedText.Trim();
            ywInfo.ObjectId = Guid.NewGuid();
            list.Add(ywInfo);
            yewuManage.AddRecord(list);

            #endregion
            btnClose_Click(null, null);

        }

        /// <summary>
        /// 操作历史数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApproveHistory_RowDataBound(object sender, GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[1] = DateTime.Parse(e.Values[1].ToString()).ToString("yyyy-MM-dd HH:mm");
            }
        }

        #endregion
    }
}