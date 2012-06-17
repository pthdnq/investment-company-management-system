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
using System.Data.SqlClient;
using Com.iFlytek.DatabaseAccess.DAL;

namespace TZMS.Web
{
    /// <summary>
    /// 基类
    /// </summary>
    public partial class BasePage : System.Web.UI.Page
    {

        public static class ComSearchManage
        {

            public static DataTable GetSearchResult(string boName, ref  ComSearchHelp searchHelp)
            {

                DataTable table = new DataTable();
                try
                {
                    //存储过程名称
                    string strsql = "Common_Select";
                    SqlParameter[] sqlparam =
                {
					new SqlParameter("@TableName",SqlDbType.NVarChar), 
                    new SqlParameter("@SelectList",SqlDbType.NVarChar), 
                    new SqlParameter("@SearchCondition",SqlDbType.NVarChar), 
                    new SqlParameter("@OrderExpression",SqlDbType.NVarChar), 
                    new SqlParameter("@PageIndex",SqlDbType.Int), 
                    new SqlParameter("@PageSize",SqlDbType.Int), 
                    new SqlParameter("@TotalCount",SqlDbType.Int), 
                    new SqlParameter("@TotalPages",SqlDbType.Int),
                };

                    sqlparam[0].Value = searchHelp.TableName;
                    sqlparam[1].Value = searchHelp.SelectFiled;
                    sqlparam[2].Value = searchHelp.Condition;
                    sqlparam[3].Value = searchHelp.Order;
                    sqlparam[4].Value = searchHelp.PageIndex;
                    sqlparam[5].Value = searchHelp.PageSize;
                    //sqlparam[6].Value = searchHelp.TotalCount;
                    sqlparam[6].Direction = ParameterDirection.Output;
                    //sqlparam[7].Value = searchHelp.TotalPages;
                    sqlparam[7].Direction = ParameterDirection.Output;
                    SqlDBAccess dbaccess = new SqlDBAccess();
                    //执行存储过程
                    DataSet ds = (DataSet)dbaccess.ExecuteDataset(boName, CommandType.StoredProcedure, strsql, sqlparam);
                    searchHelp.TotalCount = int.Parse(sqlparam[6].Value.ToString());
                    searchHelp.TotalPages = int.Parse(sqlparam[7].Value.ToString());
                    return ds.Tables[0];
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataTable datatable = new DataTable();
                    using (SqlConnection conn = new SqlConnection("User ID=sa;Initial Catalog=TZMS;Data Source=.;Password=123456;Connection Lifetime=25;"))
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = conn;
                        try
                        {
                            conn.Open();
                            comm.CommandType = CommandType.StoredProcedure;
                            comm.CommandText = "Common_Select";
                            comm.Parameters.AddRange(sqlparam);
                            da.SelectCommand = comm;
                            da.Fill(datatable);

                            searchHelp.TotalCount = int.Parse(sqlparam[6].Value.ToString());
                            searchHelp.TotalPages = int.Parse(sqlparam[7].Value.ToString());
                            return datatable;
                        }
                        catch (Exception e)
                        { }
                    }


                    return table;
                }
                catch (Exception e)
                {
                    return table;
                }

            }
        }

        [Serializable]
        public class ComSearchHelp
        {
            /// <summary>
            /// 默认构造方法
            /// </summary>
            public ComSearchHelp()
            {
            }

            #region  私有属性

            private string tableName = string.Empty;
            private string selectFiled = "*";
            private string condition = string.Empty;
            private string order = string.Empty;
            private int pageIndex;
            private int pageSize;
            private int totalCount;
            private int totalPages;

            #endregion

            #region 属性

            /// <summary>
            /// 表(视图)名
            /// </summary>
            public string TableName
            {
                get { return tableName; }
                set { tableName = value; }
            }

            /// <summary>
            /// 欲选择字段列表
            /// </summary>
            public string SelectFiled
            {
                get { return selectFiled; }
                set { selectFiled = value; }
            }

            /// <summary>
            /// 查询条件
            /// </summary>
            public string Condition
            {
                get { return condition; }
                set { condition = value; }
            }

            /// <summary>
            /// 排序表达式
            /// </summary>
            public string Order
            {
                get { return order; }
                set { order = value; }
            }

            /// <summary>
            /// 页号,从0开始
            /// </summary>
            public int PageIndex
            {
                get { return pageIndex; }
                set { pageIndex = value; }
            }

            /// <summary>
            /// 页大小
            /// </summary>
            public int PageSize
            {
                get { return pageSize; }
                set { pageSize = value; }
            }

            /// <summary>
            /// 记录总数
            /// </summary>
            public int TotalCount
            {
                get { return totalCount; }
                set { totalCount = value; }
            }

            /// <summary>
            /// 页面总数
            /// </summary>
            public int TotalPages
            {
                get { return totalPages; }
                set { totalPages = value; }
            }

            #endregion

        }

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

        public const string BT = "-";

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
                ////新数据
                //string path = AppDomain.CurrentDomain.BaseDirectory;
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(path + "\\pages\\adminManage\\XZPerson.xml");
                ////查找<Person></Person>  
                //XmlNode root = xmlDoc.SelectSingleNode("Person");
                ////将子节点类型转换为XmlElement类型  
                //XmlElement xe = (XmlElement)root;
                //return xe.GetAttribute("id");

                SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.AppSettings["CONNECTIONSTRINGFORPROVINCE_Main"]);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Archiver");
                cmd.Connection = conn;
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    return sdr["UserID"].ToString();
                }

                conn.Close();

                return string.Empty;
            }
        }

        /// <summary>
        /// 行政归档人姓名
        /// </summary>
        public string strArchiverName
        {
            get
            {
                ////新数据
                //string path = AppDomain.CurrentDomain.BaseDirectory;
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(path + "\\pages\\adminManage\\XZPerson.xml");
                ////查找<Person></Person>  
                //XmlNode root = xmlDoc.SelectSingleNode("Person");
                ////将子节点类型转换为XmlElement类型  
                //XmlElement xe = (XmlElement)root;
                //return xe.GetAttribute("name");

                SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.AppSettings["CONNECTIONSTRINGFORPROVINCE_Main"]);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Archiver");
                cmd.Connection = conn;
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    return sdr["UserName"].ToString();
                }

                conn.Close();

                return string.Empty;
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
            /// 投资部门总监-投融资项目进展归档、民间融资申请
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
            DZKJ = 14,
            /// <summary>
            /// 核算会计-核算会计材料归档(投融资)
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
            XZBBYJGDDY1 = 37,

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
            XZBSKGD = 40,

            /// <summary>
            /// 业务费用收取出纳确认
            /// </summary>
            YWFYSQCNQR = 41,

            /// <summary>
            /// 业务费用收取确认归档>30W
            /// </summary>
            YWFYSQQRGDDY30W = 42,

            /// <summary>
            /// 业务费用收取确认归档<30W
            /// </summary>
            YWFYSQQRGDXY30W = 43,

            /// <summary>
            /// 代帐单模板归档
            /// </summary>
            DZDMBGD = 44,

            /// <summary>
            /// 代帐费收取出纳确认
            /// </summary>
            DZFSQCNQR = 45,

            /// <summary>
            /// 物资采购确认归档>30W
            /// </summary>
            WZCGQRGDDY30W = 46,

            /// <summary>
            /// 物资采购确认归档<30W
            /// </summary>
            WZCGQRGDXY30W = 47,

            /// <summary>
            /// 行政部奖惩单确认
            /// </summary>
            XZBJCDQR = 48,

            /// <summary>
            /// 财务部奖惩单确认
            /// </summary>
            CWBJCDQR = 49,

            /// <summary>
            /// 投资部奖惩单确认
            /// </summary>
            TZBJCDQR = 50,

            /// <summary>
            /// 业务部奖惩单确认
            /// </summary>
            YWBJCDQR = 51,

            /// <summary>
            /// 总经办奖惩单确认
            /// </summary>
            ZJBJCDQR = 52,

            /// <summary>
            /// 结算中心奖惩单确认
            /// </summary>
            JSZXJCDQR = 53,

            /// <summary>
            /// 总经办员工离职审批
            /// </summary>
            ZJZG = 54,

            /// <summary>
            /// 结算中心员工离职审批
            /// </summary>
            JSZXZG = 55,

            /// <summary>
            /// 业务转移
            /// </summary>
            YWZY = 56
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
                case "7":
                    StrStatusName = "终止审核中";
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

        #region 消息提醒

        /// <summary>
        /// 归档信息提醒
        /// </summary>
        /// <param name="receiverID">接收人ID</param>
        /// <param name="receiverName">接收人姓名</param>
        /// <param name="funBase">归档模块名称，如：请假归档</param>
        public void GuiDangMsg(string receiverID, string receiverName, string funBase)
        {
            MessageManage _manage = new MessageManage();
            MessageInfo _info = new MessageInfo();
            _info = new MessageInfo();
            _info.ObjectId = Guid.NewGuid();
            _info.SenderId = CurrentUser.ObjectId;
            _info.SenderName = CurrentUser.Name;
            _info.DeptName = CurrentUser.Dept;
            _info.Tile = "系统提醒";
            _info.Context = receiverName + " , 您好！\r\n" + funBase + " 中，您有一条 待归档 信息！";
            _info.ReceviceId = new Guid(receiverID);
            _info.Recevicer = receiverName;
            _info.SendDate = DateTime.Now; ;
            _info.ViewDate = ACommonInfo.DBEmptyDate;
            _info.IsView = false;
            _info.IsDelete = false;
            _info.SentMessageId = Guid.NewGuid(); ;

            _manage.AddNewMessage(_info);
        }

        /// <summary>
        /// 审批（核）信息提醒
        /// </summary>
        /// <param name="receiverID">接收人ID</param>
        /// <param name="receiverName">接收人姓名</param>
        /// <param name="funBase">审批模块名称，如：假勤审批</param>
        public void CheckMsg(string receiverID, string receiverName, string funBase)
        {
            MessageManage _manage = new MessageManage();
            MessageInfo _info = new MessageInfo();
            _info = new MessageInfo();
            _info.ObjectId = Guid.NewGuid();
            _info.SenderId = CurrentUser.ObjectId;
            _info.SenderName = CurrentUser.Name;
            _info.DeptName = CurrentUser.Dept;
            _info.Tile = "系统提醒";
            _info.Context = receiverName + " , 您好！\r\n" + funBase + " 中，您有一条 待审批 信息！";
            _info.ReceviceId = new Guid(receiverID);
            _info.Recevicer = receiverName;
            _info.SendDate = DateTime.Now; ;
            _info.ViewDate = ACommonInfo.DBEmptyDate;
            _info.IsView = false;
            _info.IsDelete = false;
            _info.SentMessageId = Guid.NewGuid(); ;

            _manage.AddNewMessage(_info);
        }

        /// <summary>
        /// 审批（核）结果信息提醒
        /// </summary>
        /// <param name="receiverID">接收人ID</param>
        /// <param name="receiverName">接收人姓名</param>
        /// <param name="funBase">模块名称，如：请假申请</param>
        /// <param name="state">审批结果，如未通过，通过，打回</param>
        public void ResultMsg(string receiverID, string receiverName, string funBase, string state)
        {
            MessageManage _manage = new MessageManage();
            MessageInfo _info = new MessageInfo();
            _info = new MessageInfo();
            _info.ObjectId = Guid.NewGuid();
            _info.SenderId = CurrentUser.ObjectId;
            _info.SenderName = CurrentUser.Name;
            _info.DeptName = CurrentUser.Dept;
            _info.Tile = "系统提醒";
            _info.Context = receiverName + " , 您好！\r\n " + funBase + " 中，您有一条 " + state + " 信息！";
            _info.ReceviceId = new Guid(receiverID);
            _info.Recevicer = receiverName;
            _info.SendDate = DateTime.Now; ;
            _info.ViewDate = ACommonInfo.DBEmptyDate;
            _info.IsView = false;
            _info.IsDelete = false;
            _info.SentMessageId = Guid.NewGuid(); ;

            _manage.AddNewMessage(_info);
        }

        /// <summary>
        /// 审批（核）结果信息提醒
        /// </summary>
        /// <param name="receiverID">接收人ID</param>
        /// <param name="receiverName">接收人姓名</param>
        /// <param name="state">自定义信息</param>
        public void ResultMsgMore(string receiverID, string receiverName, string msg)
        {
            MessageManage _manage = new MessageManage();
            MessageInfo _info = new MessageInfo();
            _info = new MessageInfo();
            _info.ObjectId = Guid.NewGuid();
            _info.SenderId = CurrentUser.ObjectId;
            _info.SenderName = CurrentUser.Name;
            _info.DeptName = CurrentUser.Dept;
            _info.Tile = "系统提醒";
            _info.Context = receiverName + " , 您好！\r\n " + msg;
            _info.ReceviceId = new Guid(receiverID);
            _info.Recevicer = receiverName;
            _info.SendDate = DateTime.Now; ;
            _info.ViewDate = ACommonInfo.DBEmptyDate;
            _info.IsView = false;
            _info.IsDelete = false;
            _info.SentMessageId = Guid.NewGuid(); ;

            _manage.AddNewMessage(_info);
        }

        #endregion
    }
}