using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class CommonYewuApp : BasePage
    {
        /// <summary>
        /// 主业务单
        /// </summary>
        private YeWuInfo YeWu
        {
            set
            {
                ViewState["YeWu%"] = value;
            }
            get
            {
                if (ViewState["YeWu%"] != null)
                {
                    return (YeWuInfo)ViewState["YeWu%"];
                }
                Response.Redirect("~/login.aspx");
                return null;
            }
        }

        /// <summary>
        /// 业务流程(待操作)
        /// </summary>
        private YeWuGudingDoingInfo YeWuDoing_wei
        {
            set
            {
                ViewState["YeWuDoing%"] = value;
            }
            get
            {
                if (ViewState["YeWuDoing%"] != null)
                {
                    return (YeWuGudingDoingInfo)ViewState["YeWuDoing%"];
                }
                Response.Redirect("~/login.aspx");
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["ID"] != null)
                {
                    string objectID = Request.QueryString["ID"].ToString();
                    YewuManage ym = new YewuManage();
                   YeWu = ym.GetYeWuForObject(objectID);
                   YeWuDoing_wei = ym.GetYeWuDoingForObject(" ApplyID='" + objectID + "' and Checkstate=0");
                   //
                   this.Title = "普通业务操作-"+YeWuDoing_wei.CheckOp;
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
                InitCurrentChecker();
            }
        }

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
            ddlstNext.Items.Add(new ExtAspNet.ListItem("完成", "10"));
            ddlstNext.SelectedIndex = 0;

            dpkSign.Text = YeWu.SignDate.ToString("yyyy-MM-dd");
            this.taaSument.Text = YeWu.Sument;
            this.taaOther.Text = YeWu.Other;
            this.tbxTitle.Text = YeWu.Title;
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            YeWuGudingDoingInfo yewuCheck = new YeWuGudingDoingInfo();
            List<UserInfo> listInfo = this.CurrentChecker;
            listInfo.Add(this.CurrentUser);
            //责任人
            UserInfo zrenCheck = new UserInfo();
            foreach (UserInfo user in listInfo)
            {
                if (user.ObjectId.ToString() == this.ddlstApproveUser.SelectedValue.Trim())
                {
                    zrenCheck = user;
                    break;
                }
            }

            //manage
            YewuManage yewuManage = new YewuManage();

            //更新
            YeWu.CurrentCheckerId = zrenCheck.ObjectId;
            yewuManage.SaveYeWu(YeWu);
            YeWuDoing_wei.Checkstate = 1;
            YeWuDoing_wei.CheckSugest = this.taaApproveSugest.Text.Trim();
            YeWuDoing_wei.CheckDateTime = DateTime.Now;
            yewuManage.SaveYeWuDoing(YeWuDoing_wei);
            #region 备用记录
            //新增记录表
            List<YeWuGudingDoingInfo> list = new List<YeWuGudingDoingInfo>();
            YeWuGudingDoingInfo ywInfo = new YeWuGudingDoingInfo();
            ywInfo.CheckerId = zrenCheck.ObjectId;
            ywInfo.CheckerName = zrenCheck.Name;
            ywInfo.CheckrDept = zrenCheck.Dept;
            ywInfo.Checkstate = 0;
            ywInfo.ApplyId = YeWu.ObjectId;
            ywInfo.OrderIndex = short.Parse(ddlstNext.SelectedValue.Trim());
            ywInfo.CheckOp = ddlstNext.SelectedText.Trim();
            ywInfo.ObjectId = Guid.NewGuid();
            list.Add(ywInfo);
            yewuManage.AddRecord(list);

            #endregion
            btnClose_Click(null, null);

        }
    }
}