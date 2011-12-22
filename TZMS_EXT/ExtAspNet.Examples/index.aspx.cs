using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using System.Text;

namespace TZMS.Web
{
    public partial class index : BasePage
    {

        public string Account
        {
            get
            {
                return CurrentUser.ObjectId.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetMenu();
                timeMsg.Enabled = true;
                StringBuilder strCondition = new StringBuilder();
                strCondition.Append(" IsView =0 and IsDelete <> 1 and ReceviceID = '" + CurrentUser.ObjectId.ToString() + "'");
                strCondition.Append(" order by SendDate desc");

                MessageManage _manage = new MessageManage();
                List<MessageInfo> lstMessage = _manage.GetMessageByCondition(strCondition.ToString());
                if (lstMessage.Count > 0)
                {
                    ExtAspNet.Alert.Show("您有新的消息！", "消息提示");
                    AccordionPane8.Title = "消息管理 <a onclick='test();return false;'> 新消息(" + lstMessage.Count.ToString() + ")</a>";
                    //AccordionPane8.IconUrl = "images/16/消息管理_动态.gif";
                }
                else
                {
                    AccordionPane8.Title = "消息管理";
                    //AccordionPane8.IconUrl = "images/16/消息管理.png";
                }

                if (!string.IsNullOrEmpty(CurrentUser.Position))
                {
                    labuserName.Text = "当前登录用户：" + CurrentUser.Name +"   职位："+  CurrentUser.Position ;
                }
                else
                {
                    labuserName.Text = "当前登录用户：" + CurrentUser.Name + "   职位：" + CurrentUser.Position;

                }
                // 审批人设置注册23:14
                setChecker.OnClientClick = newSetCheckerWindow.GetShowReference(@"Pages\system\SetMyChecker.aspx") + " return false;";
                newSetCheckerWindow.OnClientCloseButtonClick = newSetCheckerWindow.GetHidePostBackReference();
                this.myMessage.OnClientClick = myMessageWindow.GetShowReference(@"Pages\system\MyMessage.aspx") + " return false;";
                //this.myMessage.OnClientClick = myMessageWindow.GetShowReference(@"http://211.86.153.66:57682/Default.aspx?account=" + Account) + " return false;";
                this.changePsw.OnClientClick = changePswWindow.GetShowReference(@"Pages\system\ChangePsw.aspx") + " return false;";

            }

        }

        /// <summary>
        /// 定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void timeMsg_Tick(object sender, EventArgs e)
        {
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" IsView =0 and IsDelete <> 1 and ReceviceID = '" + CurrentUser.ObjectId.ToString() + "'");
            strCondition.Append(" order by SendDate desc");

            MessageManage _manage = new MessageManage();
            List<MessageInfo> lstMessage = _manage.GetMessageByCondition(strCondition.ToString());
            if (lstMessage.Count > 0)
            {
                AccordionPane8.Title = "消息管理(您有新的消息)";
                AccordionPane8.IconUrl = "images/16/消息管理_动态.gif";
            }
            else
            {
                AccordionPane8.Title = "消息管理";
                AccordionPane8.IconUrl = "images/16/消息管理.gif";
            }
        }

        /// <summary>
        /// 设置审批人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Window1_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {

        }

        /// <summary>
        /// 设置
        /// </summary>
        private void SetMenu()
        {
            bool flag = false;

            #region 行政管理

            for (int i = treeXZGL.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (treeXZGL.Nodes[i].Text)
                {
                    case "员工管理":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.ZJL)
                            && !CurrentRoles.Contains(RoleType.YGGL) && !CurrentRoles.Contains(RoleType.XZZJ))
                            flag = true;
                        break;
                    case "转正年数":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.ZJL)
                           && !CurrentRoles.Contains(RoleType.YGGL) && !CurrentRoles.Contains(RoleType.XZZJ))
                            flag = true;
                        break;
                    case "系统配置":
                        if (!CurrentRoles.Contains(RoleType.CJGL))
                            flag = true;
                        break;
                    case "晋升调岗申请":
                        if (CurrentRoles.Contains(RoleType.CJGL) || CurrentRoles.Contains(RoleType.DSZ)
                            || CurrentRoles.Contains(RoleType.ZJL))
                            flag = true;
                        break;
                    case "晋升调岗审批":

                        break;
                    case "晋升调岗归档":

                        break;
                    case "下发奖惩单":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.JCGL))
                            flag = true;
                        break;
                    case "奖惩单确认":

                        break;
                    case "招聘申请":
                        //只有部门总监有权申请
                        if (!CurrentRoles.Contains(RoleType.CWZJ) && !CurrentRoles.Contains(RoleType.XZZG)
                         && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.YWZJ))
                            flag = true;
                        break;
                    case "招聘审批":

                        break;
                    case "招聘归档":

                        break;
                    case "测试":
                        if (!CurrentRoles.Contains(RoleType.CJGL))
                            flag = true;
                        break;
                    case "出门登记":
                        //if (!CurrentRoles.Contains(RoleType.CJGL))
                        //    flag = true;
                        break;
                    case "入门登记":
                        if (!CurrentRoles.Contains(RoleType.CWZJ) && !CurrentRoles.Contains(RoleType.XZZG)
                          && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.YWZJ)
                          && !CurrentRoles.Contains(RoleType.YWZG) && !CurrentRoles.Contains(RoleType.XZZJ) && !CurrentRoles.Contains(RoleType.QT))
                            flag = true;
                        break;
                }
                if (flag)
                {
                    treeXZGL.Nodes.RemoveAt(i);
                }
            }
            #endregion

            #region 假勤管理

            for (int i = treeJQGL.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (treeJQGL.Nodes[i].Text)
                {
                    case "员工考勤":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.ZJL)
                            && !CurrentRoles.Contains(RoleType.YGGL) && !CurrentRoles.Contains(RoleType.XZZJ))
                            flag = true;
                        break;
                    case "我的考勤":

                        break;
                    case "请假申请":

                        break;
                    case "调休申请":

                        break;
                    case "我的审批":

                        break;
                    case "请假归档":
                        //非行政归档员或行政总监
                        if (!CurrentUser.ObjectId.ToString().Equals(strArchiver) && !CurrentRoles.Contains(RoleType.XZZJ))
                            flag = true;
                        break;
                    case "未打卡申请":

                        break;
                    case "未打卡审批":

                        break;
                    case "未打卡归档":
                        //非行政归档员或行政总监
                        if (!CurrentUser.ObjectId.ToString().Equals(strArchiver) && !CurrentRoles.Contains(RoleType.XZZJ))
                            flag = true;
                        break;
                }
                if (flag)
                {
                    treeJQGL.Nodes.RemoveAt(i);
                }
            }
            #endregion

            #region 薪资管理

            for (int i = treeXZGL1.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (treeXZGL1.Nodes[i].Text)
                {
                    case "我的薪资":

                        break;
                    case "薪资信息管理":
                        //行政总监
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.XZZJ))
                            flag = true;
                        break;

                    case "薪资信息申请":
                        //行政总监
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.XZZJ))
                            flag = true;
                        break;
                    case "薪资信息审批":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.ZJL)
                          && !CurrentRoles.Contains(RoleType.CWZJ)
                           && !CurrentRoles.Contains(RoleType.DSZ)
                            && !CurrentRoles.Contains(RoleType.XZGLGD)
                             && !CurrentRoles.Contains(RoleType.XZZJ))
                            flag = true;
                        break;
                    case "加薪申请":

                        break;
                    case "加薪审批":

                        break;
                }
                if (flag)
                {
                    treeXZGL1.Nodes.RemoveAt(i);
                }
            }
            #endregion

            #region 消息管理

            for (int i = treeXXGL.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (treeXXGL.Nodes[i].Text)
                {
                    case "我的消息":

                        break;
                    case "已发消息":

                        break;
                    case "发送消息":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ) && !CurrentRoles.Contains(RoleType.ZJL)
                            && !CurrentRoles.Contains(RoleType.FZJL) && !CurrentRoles.Contains(RoleType.CWZJ) && !CurrentRoles.Contains(RoleType.CWZG)
                           && !CurrentRoles.Contains(RoleType.XZZG) && !CurrentRoles.Contains(RoleType.XZZJ)
                            && !CurrentRoles.Contains(RoleType.YWZJ) && !CurrentRoles.Contains(RoleType.YWZG)
                           && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.TZZG)
                            && !CurrentRoles.Contains(RoleType.XXGL))
                            flag = true;
                        break;
                }
                if (flag)
                {
                    treeXXGL.Nodes.RemoveAt(i);
                }
            }
            #endregion

            #region 转正离职

            for (int i = treeZZLZ.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (treeZZLZ.Nodes[i].Text)
                {
                    case "转正申请":

                        break;
                    case "转正审批":


                    case "转正归档":

                        break;
                    case "离职申请":

                        break;
                    case "离职审批":

                        break;
                    case "离职审批归档":

                        break;
                    case "离职交接":

                        break;
                    case "离职交接归档":

                        break;
                }
                if (flag)
                {
                    treeZZLZ.Nodes.RemoveAt(i);
                }
            }
            #endregion

            #region 物资管理

            for (int i = treeWZGL.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (treeWZGL.Nodes[i].Text)
                {
                    case "物资申请":

                        break;
                    case "物资审批":

                        break;
                    case "物资管理":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.WZGL))
                        {
                            flag = true;
                        }
                        break;
                }
                if (flag)
                {
                    treeWZGL.Nodes.RemoveAt(i);
                }
            }
            #endregion

            #region 代账管理

            for (int i = treeDZFGL.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (treeDZFGL.Nodes[i].Text)
                {
                    case "代账单位":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                            && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                            && !CurrentRoles.Contains(RoleType.CWZG) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "代账费申请":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                           && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                           && !CurrentRoles.Contains(RoleType.CWZG) && !CurrentRoles.Contains(RoleType.CWZJ)
                          && !CurrentRoles.Contains(RoleType.DZKJ) && !CurrentRoles.Contains(RoleType.DZFGD))
                        {
                            flag = true;
                        }
                        break;

                    case "代账费审批":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                             && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                             && !CurrentRoles.Contains(RoleType.CWZG) && !CurrentRoles.Contains(RoleType.CWZJ)
                            && !CurrentRoles.Contains(RoleType.DZKJ) && !CurrentRoles.Contains(RoleType.DZFGD))
                        {
                            flag = true;
                        }
                        break;
                    case "代账单导出":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                             && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                            && !CurrentRoles.Contains(RoleType.DZKJ) && !CurrentRoles.Contains(RoleType.DZFGD))
                        {
                            flag = true;
                        }
                        break;
                }
                if (flag)
                {
                    treeDZFGL.Nodes.RemoveAt(i);
                }
            }
            if (treeDZFGL.Nodes.Count == 0)
            {
                AccordionPane9.Hidden = true;
            }
            #endregion

            #region 财务报销

            for (int i = treeCWBX.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (treeCWBX.Nodes[i].Text)
                {
                    case "报销申请":

                        break;
                    case "报销审批":


                    case "报销凭证":
                        //管理员和报销凭证创建 有权看见页面
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.BXPZCJ))
                        {
                            flag = true;
                        }
                        break;
                    case "报销凭证审批":

                        break;

                }
                if (flag)
                {
                    treeCWBX.Nodes.RemoveAt(i);
                }
            }
            #endregion

            #region 业务管理

            for (int i = treeYWGL.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (treeYWGL.Nodes[i].Text)
                {
                    case "普通业务创建":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.YWZJ)
                        && !CurrentRoles.Contains(RoleType.YWY) && !CurrentRoles.Contains(RoleType.YWZG))
                        {
                            flag = true;
                        }
                        break;
                    case "普通业务操作":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.YWZJ)
                       && !CurrentRoles.Contains(RoleType.YWY) && !CurrentRoles.Contains(RoleType.YWZG))
                        {
                            flag = true;
                        }
                        break;
                    case "定制业务创建":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.YWZJ)
                       && !CurrentRoles.Contains(RoleType.YWY) && !CurrentRoles.Contains(RoleType.YWZG))
                        {
                            flag = true;
                        }
                        break;
                    case "定制业务操作":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.YWZJ)
                       && !CurrentRoles.Contains(RoleType.YWY) && !CurrentRoles.Contains(RoleType.YWZG))
                        {
                            flag = true;
                        }
                        break;
                    case "备用金申请":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.YWZJ)
                       && !CurrentRoles.Contains(RoleType.YWY) && !CurrentRoles.Contains(RoleType.YWZG))
                        {
                            flag = true;
                        }
                        break;
                    case "备用金审批":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.YWZJ)
                       && !CurrentRoles.Contains(RoleType.YWY) && !CurrentRoles.Contains(RoleType.YWZG))
                        {
                            flag = true;
                        }
                        break;

                }
                if (flag)
                {
                    treeYWGL.Nodes.RemoveAt(i);
                }
            }
            if (treeYWGL.Nodes.Count == 0)
            {
                AccordionPane12.Hidden = true;
            }
            #endregion

            #region 投资部借款

            for (int i = TreeInvestmentLoan.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (TreeInvestmentLoan.Nodes[i].Text)
                {
                    case "借款申请列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "借款审核列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "借款确认列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "借款信息列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "收款确认列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "收款信息列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "终止合同列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "待转移申请审批列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "客户一览表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;

                }
                if (flag)
                {
                    TreeInvestmentLoan.Nodes.RemoveAt(i);
                }
            }
            if (TreeInvestmentLoan.Nodes.Count == 0)
            {
                AccordionPane1.Hidden = true;
            }
            #endregion

            #region 投资部项目实施

            for (int i = TreeInvestmentProject.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (TreeInvestmentProject.Nodes[i].Text)
                {
                    case "项目申请列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "项目审核列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "审核结果列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "项目信息列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "备用金审核列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "备用金支付确认":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "进展审核列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "所有项目列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "待转移申请审批列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "待转移过程审批列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;

                }
                if (flag)
                {
                    TreeInvestmentProject.Nodes.RemoveAt(i);
                }
            }
            if (TreeInvestmentProject.Nodes.Count == 0)
            {
                AccordionPane4.Hidden = true;
            }
            #endregion

            #region 银行贷款

            for (int i = TreeBankLoan.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (TreeBankLoan.Nodes[i].Text)
                {
                    case "贷款申请列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "申请审核列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "审核结果列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "项目情况列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "备用金审核列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "费用支付确认":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "进展审核列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "所有费用支出":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "待转移申请审批列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "待转移过程审批列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;

                }
                if (flag)
                {
                    TreeBankLoan.Nodes.RemoveAt(i);
                }
            }
            if (TreeBankLoan.Nodes.Count == 0)
            {
                AccordionPane5.Hidden = true;
            }
            #endregion

            #region 民间融资

            for (int i = TreeFolkFinancing.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (TreeFolkFinancing.Nodes[i].Text)
                {
                    case "融资申请列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "会计审核列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "领导审核列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "融资合同列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "支付审核列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "支付确认列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "支付记录列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "待转移申请审批列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "待转移过程审批列表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                         && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;


                }
                if (flag)
                {
                    TreeFolkFinancing.Nodes.RemoveAt(i);
                }
            }
            if (TreeFolkFinancing.Nodes.Count == 0)
            {
                AccordionPane6.Hidden = true;
            }
            #endregion

            #region 资金审核

            for (int i = Tree10.Nodes.Count - 1; i > -1; i--)
            {
                flag = false;
                switch (Tree10.Nodes[i].Text)
                {
                    case "资金流量表":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                        && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "投资借款会计核算":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.HSKJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "项目实施会计核算":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.HSKJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "银行贷款会计核算":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.HSKJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                    case "民间融资会计核算":
                        if (!CurrentRoles.Contains(RoleType.CJGL) && !CurrentRoles.Contains(RoleType.DSZ)
                       && !CurrentRoles.Contains(RoleType.ZJL) && !CurrentRoles.Contains(RoleType.FZJL)
                        && !CurrentRoles.Contains(RoleType.TZZJ) && !CurrentRoles.Contains(RoleType.CWZJ)
                            && !CurrentRoles.Contains(RoleType.HSKJ) && !CurrentRoles.Contains(RoleType.CWZJ))
                        {
                            flag = true;
                        }
                        break;
                }
                if (flag)
                {
                    Tree10.Nodes.RemoveAt(i);
                }
            }
            if (Tree10.Nodes.Count == 0)
            {
                AccordionPane14.Hidden = true;
            }
            #endregion
        }
    }
}