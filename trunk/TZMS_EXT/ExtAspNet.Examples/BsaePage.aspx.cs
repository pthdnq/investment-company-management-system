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
            get { return "CONNECTIONSTRINGFORPROVINCE"; }
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

                    if (lstRoles.Count == 0)
                    {
                        return new List<RoleType>();
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
            FZJL = 3,
            /// <summary>
            /// 行政部门总监
            /// </summary>
            XZZJ = 4,
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
            /// <summary>
            /// 普通员工
            /// </summary>
            PTYG = 12,
            /// <summary>
            /// 考勤员
            /// </summary>
            KQY = 13,
            /// <summary>
            /// 代账会计
            /// </summary>
            DZKJ = 14,
            /// <summary>
            /// 核算会计
            /// </summary>
            HSKJ = 15,
            /// <summary>
            /// 主办会计
            /// </summary>
            ZBKJ = 16,
            /// <summary>
            /// 出纳会计
            /// </summary>
            CNKJ = 17,

            /// <summary>
            /// 考勤归档
            /// </summary>
            KQGD = 18,
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
            TX = 9
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

    }
}