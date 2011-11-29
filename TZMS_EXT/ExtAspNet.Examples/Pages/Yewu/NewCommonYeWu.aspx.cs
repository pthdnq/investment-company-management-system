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
    public partial class NewCommonYeWu : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

                drpCheck1.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
                drpCheck2.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
                drpCheck3.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
                drpCheck4.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
                drpCheck5.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
                drpCheck6.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
                drpCheck7.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
                drpCheck8.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
                drpCheck9.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
            }
            ddlstApproveUser.SelectedIndex = listInfo.Count - 1;
            drpSigner.SelectedIndex = listInfo.Count - 1;
            drpCheck1.SelectedIndex = listInfo.Count - 1;
            drpCheck2.SelectedIndex = listInfo.Count - 1;
            drpCheck3.SelectedIndex = listInfo.Count - 1;
            drpCheck4.SelectedIndex = listInfo.Count - 1;
            drpCheck5.SelectedIndex = listInfo.Count - 1;
            drpCheck6.SelectedIndex = listInfo.Count - 1;
            drpCheck7.SelectedIndex = listInfo.Count - 1;
            drpCheck8.SelectedIndex = listInfo.Count - 1;
            drpCheck9.SelectedIndex = listInfo.Count - 1;

            dpkSign.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
            foreach(UserInfo user in listInfo)
            {
                if(user.ObjectId.ToString()==this.drpSigner.SelectedValue.Trim())
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
            yewu.Type = 0;
            yewu.Sument = this.taaSument.Text.Trim();
            yewu.Title = this.tbxTitle.Text.Trim();
            yewu.Other = this.taaOther.Text.Trim();
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
            short index = 1;
            //新增记录表
            List<YeWuGudingDoingInfo> list = new List<YeWuGudingDoingInfo>();
            foreach (UserInfo user in listInfo)
            {
                if (user.ObjectId.ToString() == this.drpCheck1.SelectedValue.Trim())
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
            ywInfo.OrderIndex = index++;
            ywInfo.CheckOp = "业务转交";
            ywInfo.ObjectId = Guid.NewGuid();
            
            list.Add(ywInfo);
            //
            foreach (UserInfo user in listInfo)
            {
                if (user.ObjectId.ToString() == this.drpCheck2.SelectedValue.Trim())
                {
                    checker = user;
                    break;
                }
            }
            YeWuGudingDoingInfo ywInfo2 = new YeWuGudingDoingInfo();
            ywInfo2.CheckerId = checker.ObjectId;
            ywInfo2.CheckerName = checker.Name;
            ywInfo2.CheckrDept = checker.Dept;
            ywInfo2.Checkstate = 0;
            ywInfo2.ApplyId = yewu.ObjectId;
            ywInfo2.OrderIndex = index++;
            ywInfo2.CheckOp = "核名";
            ywInfo2.ObjectId = Guid.NewGuid();
            list.Add(ywInfo2);
            //
            foreach (UserInfo user in listInfo)
            {
                if (user.ObjectId.ToString() == this.drpCheck3.SelectedValue.Trim())
                {
                    checker = user;
                    break;
                }
            }
            YeWuGudingDoingInfo ywInfo3 = new YeWuGudingDoingInfo();
            ywInfo3.CheckerId = checker.ObjectId;
            ywInfo3.CheckerName = checker.Name;
            ywInfo3.CheckrDept = checker.Dept;
            ywInfo3.Checkstate = 0;
            ywInfo3.ApplyId = yewu.ObjectId;
            ywInfo3.OrderIndex = index++;
            ywInfo3.CheckOp = "刻章";
            ywInfo3.ObjectId = Guid.NewGuid();
   
            list.Add(ywInfo3);
            //
            foreach (UserInfo user in listInfo)
            {
                if (user.ObjectId.ToString() == this.drpCheck4.SelectedValue.Trim())
                {
                    checker = user;
                    break;
                }
            }
            YeWuGudingDoingInfo ywInfo4 = new YeWuGudingDoingInfo();
            ywInfo4.CheckerId = checker.ObjectId;
            ywInfo4.CheckerName = checker.Name;
            ywInfo4.CheckrDept = checker.Dept;
            ywInfo4.Checkstate = 0;
            ywInfo4.ApplyId = yewu.ObjectId;
            ywInfo4.OrderIndex = index++;
            ywInfo4.CheckOp = "开户";
            ywInfo4.ObjectId = Guid.NewGuid();

            list.Add(ywInfo4);
            //
            foreach (UserInfo user in listInfo)
            {
                if (user.ObjectId.ToString() == this.drpCheck5.SelectedValue.Trim())
                {
                    checker = user;
                    break;
                }
            }
            YeWuGudingDoingInfo ywInfo5 = new YeWuGudingDoingInfo();
            ywInfo5.CheckerId = checker.ObjectId;
            ywInfo5.CheckerName = checker.Name;
            ywInfo5.CheckrDept = checker.Dept;
            ywInfo5.Checkstate = 0;
            ywInfo5.ApplyId = yewu.ObjectId;
            ywInfo5.OrderIndex = index++;
            ywInfo5.CheckOp = "验资报告";
            ywInfo5.ObjectId = Guid.NewGuid();
          
            list.Add(ywInfo5);
            //
            foreach (UserInfo user in listInfo)
            {
                if (user.ObjectId.ToString() == this.drpCheck6.SelectedValue.Trim())
                {
                    checker = user;
                    break;
                }
            }
            YeWuGudingDoingInfo ywInfo6 = new YeWuGudingDoingInfo();
            ywInfo6.CheckerId = checker.ObjectId;
            ywInfo6.CheckerName = checker.Name;
            ywInfo6.CheckrDept = checker.Dept;
            ywInfo6.Checkstate = 0;
            ywInfo6.ApplyId = yewu.ObjectId;
            ywInfo6.OrderIndex = index++;
            ywInfo6.CheckOp = "营业执照";
            ywInfo6.ObjectId = Guid.NewGuid();
            
            list.Add(ywInfo6);
            //
            foreach (UserInfo user in listInfo)
            {
                if (user.ObjectId.ToString() == this.drpCheck7.SelectedValue.Trim())
                {
                    checker = user;
                    break;
                }
            }
            YeWuGudingDoingInfo ywInfo7 = new YeWuGudingDoingInfo();
            ywInfo7.CheckerId = checker.ObjectId;
            ywInfo7.CheckerName = checker.Name;
            ywInfo7.CheckrDept = checker.Dept;
            ywInfo7.Checkstate = 0;
            ywInfo7.ApplyId = yewu.ObjectId;
            ywInfo7.OrderIndex = index++;
            ywInfo7.CheckOp = "办代码证";
            ywInfo7.ObjectId = Guid.NewGuid();
   
            list.Add(ywInfo7);
            //
            foreach (UserInfo user in listInfo)
            {
                if (user.ObjectId.ToString() == this.drpCheck8.SelectedValue.Trim())
                {
                    checker = user;
                    break;
                }
            }
            YeWuGudingDoingInfo ywInfo8 = new YeWuGudingDoingInfo();
            ywInfo8.CheckerId = checker.ObjectId;
            ywInfo8.CheckerName = checker.Name;
            ywInfo8.CheckrDept = checker.Dept;
            ywInfo8.Checkstate = 0;
            ywInfo8.ApplyId = yewu.ObjectId;
            ywInfo8.OrderIndex = index++;
            ywInfo8.CheckOp = "办国地税";
            ywInfo8.ObjectId = Guid.NewGuid();
            list.Add(ywInfo8);
            //
            foreach (UserInfo user in listInfo)
            {
                if (user.ObjectId.ToString() == this.drpCheck9.SelectedValue.Trim())
                {
                    checker = user;
                    break;
                }
            }
            YeWuGudingDoingInfo ywInfo9 = new YeWuGudingDoingInfo();
            ywInfo9.CheckerId = checker.ObjectId;
            ywInfo9.CheckerName = checker.Name;
            ywInfo9.CheckrDept = checker.Dept;
            ywInfo9.Checkstate = 0;
            ywInfo9.ApplyId = yewu.ObjectId;
            ywInfo9.OrderIndex = index++;
            ywInfo9.CheckOp = "转基本户";
            ywInfo9.ObjectId = Guid.NewGuid();
            list.Add(ywInfo9);

            yewuManage.AddRecord(list);
            btnClose_Click(null, null);

        }
    }
}