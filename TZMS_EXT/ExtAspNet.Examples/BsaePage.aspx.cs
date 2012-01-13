using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using ExtAspNet.Examples;
using System.Data;
using System.Web.Configuration;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Xml;

namespace TZMS.Web
{
    /// <summary>
    /// 基类
    /// </summary>
    public partial class BasePage : System.Web.UI.Page
    {

        #region 配置信息

        /// <summary>
        /// TZMS数据库链接字符串
        /// </summary>
        public string BoName
        {
            get { return "CONNECTIONSTRINGFORPROVINCE_Main"; }
        }

        /// <summary>
        /// 一般页面页大小
        /// </summary>
        protected int PageCounts
        {
            get { return int.Parse(WebConfigurationManager.AppSettings["PAGECOUNTS"].ToString()); }
        }

        /// <summary>
        /// 系统名称
        /// </summary>
        protected string SystemName
        {
            get { return WebConfigurationManager.AppSettings["SYSTEMNAME"].ToString(); }
        }

        /// <summary>
        /// 一级站点（和日历共享数据）
        /// </summary>
        protected string WebSite
        {
            get { return WebConfigurationManager.AppSettings["WebSite"].ToString(); }
        }
        #endregion

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public UserInfo CurrentUser
        {
            get
            {
                if (Session["CurrentUser%"] == null)
                {
                    Session.RemoveAll();
                    Response.Redirect("~/login.aspx");
                    return null;
                }
                return (UserInfo)Session["CurrentUser%"];
            }
            set
            {
                Session["CurrentUser%"] = value;
            }
        }

        /// <summary>
        /// 当前用户的审批人
        /// </summary>
        public List<UserInfo> CurrentChecker
        {
            get
            {
                CheckMange cm = new CheckMange();
                return cm.GetCheckersByUserID(CurrentUser.ObjectId.ToString());
            }
        }

        /// <summary>
        /// 当前用户所拥有的角色
        /// </summary>
        public List<RoleType> CurrentRoles
        {
            get
            {
                if (Session["_RoleHaves"] == null)
                {
                    RolesManage rm = new RolesManage();
                    List<RoleType> lstRoleType = new List<RoleType>();
                    List<UserRoles> lstRoles = rm.GerRolesByCondition(" [UserObjectID]='" + CurrentUser.ObjectId.ToString() + "'");

                    //添加超级管理员角色
                    if (SystemUser.ObjectId == CurrentUser.ObjectId)
                    {
                        UserRoles ur = new UserRoles();
                        ur.Roles = "0";
                        lstRoles.Add(ur);
                    }
                    if (lstRoles.Count == 0)
                    {
                        UserRoles ur = new UserRoles();
                        ur.Roles = "12";
                        lstRoles.Add(ur);
                    }
                    string roles = lstRoles[0].Roles;
                    string[] role = roles.Split(',');
                    foreach (string ro in role)
                    {
                        if (!string.IsNullOrEmpty(ro))
                        {
                            int type = int.Parse(ro);
                            lstRoleType.Add((RoleType)type);
                        }
                    }

                    Session["_RoleHaves"] = lstRoleType;
                    return lstRoleType;
                }
                return (List<RoleType>)Session["_RoleHaves"];
            }
        }

        /// <summary>
        /// 当前访问级别
        /// </summary>
        public VisitLevel CurrentLevel
        {
            get
            {
                if (ViewState["VisitLevel"] == null)
                {
                    return VisitLevel.Both;
                }
                return (VisitLevel)ViewState["VisitLevel"];
            }
            set
            {
                ViewState["VisitLevel"] = value;
            }
        }

        /// <summary>
        /// 系统用户
        /// </summary>
        public UserInfo SystemUser
        {
            get
            {
                if (Session["SystemUser"] == null)
                {
                    UserInfo systemUser = new UserInfo();
                    systemUser.ObjectId = new Guid("00000000-0000-0000-0000-000000000000");
                    systemUser.Name = "系统";
                    Session["SystemUser"] = systemUser;
                }

                return (UserInfo)Session["SystemUser"];
            }
        }

        /// <summary>
        /// 行政归档人ObjectID
        /// </summary>
        public string strArchiver
        {
            get
            {
                //新数据
                string path = AppDomain.CurrentDomain.BaseDirectory;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path + "\\pages\\adminManage\\XZPerson.xml");
                //查找<Person></Person>  
                XmlNode root = xmlDoc.SelectSingleNode("Person");
                //将子节点类型转换为XmlElement类型  
                XmlElement xe = (XmlElement)root;
                return xe.GetAttribute("id");
            }
        }

        /// <summary>
        /// 行政归档人姓名
        /// </summary>
        public string strArchiverName
        {
            get
            {
                //新数据
                string path = AppDomain.CurrentDomain.BaseDirectory;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path + "\\pages\\adminManage\\XZPerson.xml");
                //查找<Person></Person>  
                XmlNode root = xmlDoc.SelectSingleNode("Person");
                //将子节点类型转换为XmlElement类型  
                XmlElement xe = (XmlElement)root;
                return xe.GetAttribute("name");
            }
        }

        /// <summary>
        /// 带帐费公司
        /// </summary>
        public string Company = "合肥吉信财务管理有限公司";

        /// <summary>
        /// 本系统角色 枚举
        /// </summary>
        public enum RoleType
        {
            /// <summary>
            /// 超级管理员
            /// </summary>
            CJGL = 0,

            /// <summary>
            /// 董事长
            /// </summary>
            DSZ = 1,
            /// <summary>
            /// 总经理
            /// </summary>
            ZJL = 2,

            /// <summary>
            /// 副总经理
            /// </summary>
            //FZJL = 3,
            /// <summary>
            /// 行政部门总监
            /// </summary>
          //  XZZJ = 4,
            /// <summary>
            /// 财务部门总监
            /// </summary>
            CWZJ = 5,
            /// <summary>
            /// 投资部门总监
            /// </summary>
            TZZJ = 6,
            /// <summary>
            /// 业务部门总监
            /// </summary>
            YWZJ = 7,
            /// <summary>
            /// 行政部门主管
            /// </summary>
            XZZG = 8,
            /// <summary>
            /// 财务部门主管
            /// </summary>
            CWZG = 9,
            /// <summary>
            /// 投资部门主管
            /// </summary>
            TZZG = 10,
            /// <summary>
            /// 业务部门主管
            /// </summary>
            YWZG = 11,
            ///// <summary>
            ///// 普通员工
            ///// </summary>
            //PTYG = 12,
            ///// <summary>
            ///// 考勤员
            ///// </summary>
            //KQY = 13,
            /// <summary>
            /// 代账会计
            /// </summary>
            //DZKJ = 14,
            /// <summary>
            /// 核算会计
            /// </summary>
            HSKJ = 15,
            /// <summary>
            /// 主办会计
            /// </summary>
            //ZBKJ = 16,
            /// <summary>
            /// 出纳会计
            /// </summary>
            CNKJ = 17,

            /// <summary>
            /// 考勤归档（需要行政人员归档）
            /// </summary>
            KQGD = 18,

            ///// <summary>
            ///// 物质申请（普通）
            ///// </summary>
            //WUSQ_PT = 19,

            /// <summary>
            /// 物质申请（固定资产）
            /// </summary>
            WZSQ_GD = 20,

            /// <summary>
            /// 代账费归档（具有归档权）
            /// </summary>
            DZFGD = 21,

            /// <summary>
            /// 物质审批归档（具有归档权）
            /// </summary>
            WZSPGD = 22,

            ///// <summary>
            ///// 借款申请归档（具有归档权）
            ///// </summary>
            //JKSQ = 23,

            ///// <summary>
            ///// 民间融资申请归档（具有归档权）
            ///// </summary>
            //MJRZ = 24,

            ///// <summary>
            ///// 银行贷款申请归档（具有归档权）
            ///// </summary>
            //YHDK = 25,

            /// <summary>
            /// 薪资管理归档
            /// </summary>
            XZGLGD = 26,

            /// <summary>
            /// 加薪归档
            /// </summary>
            GXGD = 27,

            /// <summary>
            /// 报销凭证归档
            /// </summary>
            PZGD = 28,

            ///// <summary>
            ///// 员工管理 以下角色未管理其他页面
            ///// </summary>
            //YGGL = 29,

            ///// <summary>
            ///// 奖惩管理员 以下角色未管理其他页面
            ///// </summary>
            //JCGL = 30,

            ///// <summary>
            ///// 消息管理员 以下角色未管理其他页面
            ///// </summary>
            //XXGL = 31,

            ///// <summary>
            ///// 物资管理员 以下角色未管理其他页面
            ///// </summary>
            //WZGL = 32,

            ///// <summary>
            ///// 报销凭证创建 以下角色未管理其他页面
            ///// </summary>
            //BXPZCJ = 33,

            ///// <summary>
            ///// 业务员 以下角色未管理其他页面
            ///// </summary>
            //YWY = 34,

            /// <summary>
            /// 业务部备用金归档
            /// </summary>
            YWBBYJGD = 35,

            ///// <summary>
            ///// 前台（入门登记）
            ///// </summary>
            //QT = 36,
             
            /// <summary>
            /// 行政部备用金大于1w归档
            /// </summary>
            XZBBYJGDDY1=37,

            /// <summary>
            /// 行政部备用金小于1w归档
            /// </summary>
            XZBBYJGDXY1 = 38,

            /// <summary>
            /// 行政部付款归档 
            /// </summary>
            XZBFKJGD = 39,

            /// <summary>
            /// 行政部收款上交归档 
            /// </summary>
            XZBSKGD = 40
        }

        /// <summary>
        /// 系统假勤枚举
        /// 事假，病假，婚假，产假，丧假，工伤假，产检假，年休假，矿工，调休
        /// </summary>
        public enum AttedType
        {
            /// <summary>
            /// 事假
            /// </summary>
            SJ = 0,

            /// <summary>
            /// 病假
            /// </summary>
            BJ = 1,

            /// <summary>
            /// 婚假
            /// </summary>
            HJ = 2,

            /// <summary>
            /// 产假
            /// </summary>
            CJ = 3,

            /// <summary>
            /// 丧假
            /// </summary>
            SAJ = 4,

            /// <summary>
            /// 工伤假
            /// </summary>
            GJ = 5,

            /// <summary>
            /// 产检假
            /// </summary>
            CJJ = 6,

            /// <summary>
            /// 年休假
            /// </summary>
            NXJ = 7,

            /// <summary>
            /// 矿工
            /// </summary>
            KG = 8,

            /// <summary>
            /// 调休
            /// </summary>
            TX = 9,

            /// <summary>
            /// 其他
            /// </summary>
            QT = 10 
        }

        /// <summary>
        /// 页面访问基本
        /// </summary>
        public enum VisitLevel
        {
            /// <summary>
            /// 无权限查看或编辑
            /// </summary>
            None = 0,

            /// <summary>
            /// 只查看
            /// </summary>
            View = 1,

            /// <summary>
            /// 可编辑
            /// </summary>
            Edit = 2,

            /// <summary>
            /// 全部
            /// </summary>
            Both = 3
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="e">参数</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!IsPostBack)
            {
                if (PageManager.Instance != null)
                {
                    HttpCookie themeCookie = Request.Cookies["Theme"];
                    if (themeCookie != null)
                    {
                        string themeValue = themeCookie.Value;
                        PageManager.Instance.Theme = (Theme)Enum.Parse(typeof(Theme), themeValue, true);
                    }

                    HttpCookie langCookie = Request.Cookies["Language"];
                    if (langCookie != null)
                    {
                        string langValue = langCookie.Value;
                        PageManager.Instance.Language = (Language)Enum.Parse(typeof(Language), langValue, true);
                    }
                }
            }

        }

        /// <summary>
        /// 判断当前用户是否拥有 这个角色
        /// </summary>
        /// <param name="roleType">角色枚举</param>
        /// <returns>true：拥有，false：不拥有</returns>
        public bool IsRole(RoleType roleType)
        {
            if (CurrentRoles.Contains(roleType))
            {
                return true;
            }
            return false;
        }

      


        #region 自定义状态方法

        /// <summary>
        /// 获取状态名字
        /// </summary>
        /// <param name="strStatus"></param>
        /// <returns></returns>
        protected string GetStatusName(string strStatus)
        {
            string StrStatusName = string.Empty;
            switch (strStatus)
            {
                case "0":
                    //  strCondtion.Append(" AND Status = 1 ");
                    break;
                case "1":
                    StrStatusName = "待审核";
                    break;
                case "2":
                    StrStatusName = "未通过";
                    break;
                case "3":
                    StrStatusName = "审核中";
                    break;
                case "4":
                    StrStatusName = "待确认";
                    break;
                case "5":
                    StrStatusName = "已确认";
                    break;
                case "9":
                    StrStatusName = "已删除";
                    break;
                case "8":
                    StrStatusName = "已终止";
                    break;
                case "11":
                    StrStatusName = "终止未通过";
                    break;
                default:
                    break;
            }
            return StrStatusName;
        }

        /// <summary>
        /// 通过节点ID
        /// </summary>
        /// <param name="nodeID"></param>
        /// <returns></returns>
        protected VisitLevel GetCurrentLevel(string nodeID)
        {
            //超级管理员
            if (CurrentUser.State == 3)
            {
                return VisitLevel.Both;
            }

            if (string.IsNullOrEmpty(nodeID))
                return VisitLevel.Both;

            string menus = CurrentUser.Menu;
            if (!string.IsNullOrEmpty(menus))
            {
                string[] arrayParentNodes = menus.Split(';');
                foreach (string parentItem in arrayParentNodes)
                {
                    if (!string.IsNullOrEmpty(parentItem))
                    {
                        string[] arrayNodes = (parentItem.Split('$')[1]).Split(',');
                        foreach (string item in arrayNodes)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                if (item.Split(':')[0] == nodeID)
                                {
                                    switch (item.Split(':')[1])
                                    {
                                        case "0":
                                            return VisitLevel.None;
                                        case "1":
                                            return VisitLevel.View;
                                        case "2":
                                            return VisitLevel.Edit;
                                        case "3":
                                            return VisitLevel.Both;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return VisitLevel.Both;
        }

        #endregion
    }
}