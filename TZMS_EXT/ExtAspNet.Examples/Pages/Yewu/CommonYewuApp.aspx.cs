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
                    BindHistory(objectID);
                    //
                    this.Title = "普通业务操作-" + YeWuDoing_wei.CheckOp;
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
                InitCurrentChecker();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定历史
        /// </summary>
        private void BindHistory(string objectID)
        {
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" ApplyID = '" + objectID + "'");
            strCondition.Append(" and  Checkstate = 1 ");
            List<YeWuGudingDoingInfo> lstBaoxiaoCheckInfo = new YewuManage().GetYeWuDoingForList(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(YeWuGudingDoingInfo x, YeWuGudingDoingInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridApproveHistory.DataBind();
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
            ddlstNext.Items.Add(new ExtAspNet.ListItem("各类许可证", "4"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("开户", "5"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("验资报告", "6"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("营业执照", "7"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("办代码证", "8"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("办国地税", "9"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("转基本户", "10"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("增资(开户、验资报告、营业执照)", "11"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("完成", "12"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("异常终止", "13"));
            ddlstNext.SelectedIndex = 0;

            dpkSign.Text = YeWu.SignDate.ToString("yyyy-MM-dd");
            this.taaSument.Text = YeWu.Sument;
            this.taaOther.Text = YeWu.Other;
            this.tbxTitle.Text = YeWu.Title;
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
        /// 提交表单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            YeWuGudingDoingInfo yewuCheck = new YeWuGudingDoingInfo();
            YewuManage yewuManage = new YewuManage();

            if (ddlstNext.SelectedValue == "12")
            {
                // 更新状态.
                YeWu.State = 1;
                YeWu.CurrentOp = 14;
                yewuManage.SaveYeWu(YeWu);

                YeWuDoing_wei.Checkstate = 1;
                YeWuDoing_wei.CheckSugest = this.taaApproveSugest.Text.Trim();
                YeWuDoing_wei.CheckDateTime = DateTime.Now;
                yewuManage.SaveYeWuDoing(YeWuDoing_wei);

                List<YeWuGudingDoingInfo> _list = new List<YeWuGudingDoingInfo>();
                YeWuGudingDoingInfo _ywInfo = new YeWuGudingDoingInfo();
                _ywInfo.ObjectId = Guid.NewGuid();
                _ywInfo.CheckerId = CurrentUser.ObjectId;
                _ywInfo.CheckerName = CurrentUser.Name;
                _ywInfo.CheckrDept = CurrentUser.Dept;
                _ywInfo.Checkstate = 1;
                _ywInfo.ApplyId = YeWu.ObjectId;
                _ywInfo.OrderIndex = short.Parse(ddlstNext.SelectedValue.Trim());
                _ywInfo.CheckOp = ddlstNext.SelectedText.Trim();
                _ywInfo.CheckDateTime = YeWuDoing_wei.CheckDateTime.AddSeconds(1);

                _list.Add(_ywInfo);
                yewuManage.AddRecord(_list);

                this.btnClose_Click(null, null);
                return;
            }

            if (ddlstNext.SelectedValue == "13")
            {
                // 更新状态.
                YeWu.State = 2;
                YeWu.CurrentOp = 15;

                yewuManage.SaveYeWu(YeWu);

                YeWuDoing_wei.Checkstate = 1;
                YeWuDoing_wei.CheckSugest = this.taaApproveSugest.Text.Trim();
                YeWuDoing_wei.CheckDateTime = DateTime.Now;
                yewuManage.SaveYeWuDoing(YeWuDoing_wei);

                List<YeWuGudingDoingInfo> _list = new List<YeWuGudingDoingInfo>();
                YeWuGudingDoingInfo _ywInfo = new YeWuGudingDoingInfo();
                _ywInfo.ObjectId = Guid.NewGuid();
                _ywInfo.CheckerId = CurrentUser.ObjectId;
                _ywInfo.CheckerName = CurrentUser.Name;
                _ywInfo.CheckrDept = CurrentUser.Dept;
                _ywInfo.Checkstate = 1;
                _ywInfo.ApplyId = YeWu.ObjectId;
                _ywInfo.OrderIndex = short.Parse(ddlstNext.SelectedValue.Trim());
                _ywInfo.CheckOp = ddlstNext.SelectedText.Trim();
                _ywInfo.CheckDateTime = YeWuDoing_wei.CheckDateTime.AddSeconds(1);

                _list.Add(_ywInfo);
                yewuManage.AddRecord(_list);

                this.btnClose_Click(null, null);
                return;
            }

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

            // 更新
            YeWu.CurrentOp = short.Parse(ddlstNext.SelectedValue);
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

            //YeWuGudingDoingInfo yewuCheck = new YeWuGudingDoingInfo();
            //List<UserInfo> listInfo = this.CurrentChecker;
            //listInfo.Add(this.CurrentUser);
            ////责任人
            //UserInfo zrenCheck = new UserInfo();
            //foreach (UserInfo user in listInfo)
            //{
            //    if (user.ObjectId.ToString() == this.ddlstApproveUser.SelectedValue.Trim())
            //    {
            //        zrenCheck = user;
            //        break;
            //    }
            //}

            ////manage
            //YewuManage yewuManage = new YewuManage();

            ////更新
            //YeWu.CurrentOp = short.Parse(ddlstNext.SelectedValue);
            //YeWu.CurrentCheckerId = zrenCheck.ObjectId;
            //yewuManage.SaveYeWu(YeWu);
            //YeWuDoing_wei.Checkstate = 1;
            //YeWuDoing_wei.CheckSugest = this.taaApproveSugest.Text.Trim();
            //YeWuDoing_wei.CheckDateTime = DateTime.Now;
            //yewuManage.SaveYeWuDoing(YeWuDoing_wei);

            //#region 备用记录
            ////新增记录表
            //List<YeWuGudingDoingInfo> list = new List<YeWuGudingDoingInfo>();
            //YeWuGudingDoingInfo ywInfo = new YeWuGudingDoingInfo();
            //ywInfo.CheckerId = zrenCheck.ObjectId;
            //ywInfo.CheckerName = zrenCheck.Name;
            //ywInfo.CheckrDept = zrenCheck.Dept;
            //ywInfo.Checkstate = 0;
            //ywInfo.ApplyId = YeWu.ObjectId;
            //ywInfo.OrderIndex = short.Parse(ddlstNext.SelectedValue.Trim());
            //ywInfo.CheckOp = ddlstNext.SelectedText.Trim();
            //ywInfo.ObjectId = Guid.NewGuid();
            //list.Add(ywInfo);
            //yewuManage.AddRecord(list);

            //#endregion

            //btnClose_Click(null, null);

        }

        /// <summary>
        /// 数据行绑定事件
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