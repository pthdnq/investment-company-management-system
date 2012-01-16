using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using com.TZMS.Model;
using com.TZMS.Business;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class RolesOfUser : BasePage
    {
        /// <summary>
        /// 用于存储用户ID的ViewState.
        /// </summary>
        public string UserObjectID
        {
            get
            {
                if (ViewState["UserObjectID"] == null)
                {
                    return null;
                }

                return ViewState["UserObjectID"].ToString();
            }
            set
            {
                ViewState["UserObjectID"] = value;
            }
        }

        /// <summary>
        /// 用于存储已分配角色链表的ViewState.
        /// </summary>
        public List<RoleType> SelectedRoles
        {
            get
            {
                if (ViewState["SelectedRoles"] == null)
                {
                    return new List<RoleType>();
                }

                return (List<RoleType>)ViewState["SelectedRoles"];
            }
            set
            {
                ViewState["SelectedRoles"] = value;
            }
        }

        /// <summary>
        /// 用于存储未分配角色的ViewState.
        /// </summary>
        public List<RoleType> UnselectRoles
        {
            get
            {
                if (ViewState["UnselectRoles"] == null)
                {
                    return new List<RoleType>();
                }

                return (List<RoleType>)ViewState["UnselectRoles"];
            }
            set
            {
                ViewState["UnselectRoles"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 获取User ID.
                string strUserID = Page.Request.QueryString["ID"].ToString();

                if (!string.IsNullOrEmpty(strUserID))
                {
                    // 获取角色实例.
                    UserRoles _userRoles = new RolesManage().GetRolesByObjectID(strUserID);
                    if (_userRoles == null)
                    {
                        rolesFilter(null);

                    }
                    else
                    {
                        rolesFilter(_userRoles.Roles);
                    }

                    // 保存用户ID
                    UserObjectID = strUserID;
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 筛选出已分配以及未分配的角色，并绑定到相应的GridView.
        /// </summary>
        /// <param name="strSelectedRoles">已分配角色字符串</param>
        private void rolesFilter(string strSelectedRoles)
        {
            // 获取已分配的角色字符串数组.
            string[] selectedRolesStringArray = null;
            if (!string.IsNullOrEmpty(strSelectedRoles))
            {
                selectedRolesStringArray = strSelectedRoles.Split(',');
            }

            // 获取所有的角色.
            List<RoleType> lstAllRoles = convertEnumToList(typeof(RoleType));

            // 未分配的角色数组.
            List<RoleType> lstUnselectRoles = new List<RoleType>();
            List<RoleType> lstSelectedRoles = new List<RoleType>();

            bool isEqual = false;

            // 将已分配角色和未分配角色分别填充到相应的数组中.
            foreach (RoleType item in lstAllRoles)
            {
                if (selectedRolesStringArray != null)
                {
                    foreach (string strRole in selectedRolesStringArray)
                    {
                        // 判断枚举与字符串是否相等.
                        if ((RoleType)Enum.Parse(typeof(RoleType), strRole, true) == item)
                        {
                            isEqual = true;
                            break;
                        }
                    }
                }

                if (isEqual)
                {
                    lstSelectedRoles.Add(item);
                }
                else
                {
                    lstUnselectRoles.Add(item);
                }

                isEqual = false;
            }

            // 绑定列表.
            lstUnselectRoles.Sort();
            lstSelectedRoles.Sort();
            bindUnselectGridView(lstUnselectRoles);
            bindSelectedGridView(lstSelectedRoles);

            // 保存列表.
            SelectedRoles = lstSelectedRoles;
            UnselectRoles = lstUnselectRoles;
        }

        /// <summary>
        /// 绑定未分配角色列表.
        /// </summary>
        /// <param name="unselectList">未分配角色链表</param>
        private void bindUnselectGridView(List<RoleType> unselectList)
        {
            if (unselectList != null)
            {
                gridUnSelectRoles.DataSource = generateDataSource(unselectList);
                gridUnSelectRoles.DataBind();
            }
        }

        /// <summary>
        /// 绑定已分配角色列表.
        /// </summary>
        /// <param name="selectedList">已分配角色链表</param>
        private void bindSelectedGridView(List<RoleType> selectedList)
        {
            if (selectedList != null)
            {
                gridSelectdRoles.DataSource = generateDataSource(selectedList);
                gridSelectdRoles.DataBind();
            }
        }

        /// <summary>
        /// 将枚举中的所有值存放到List中.
        /// </summary>
        /// <param name="inputEnum">枚举类型</param>
        /// <returns>枚举值链表</returns>
        private List<RoleType> convertEnumToList(Type typeOfEnum)
        {
            List<RoleType> lstRoles = new List<RoleType>();
            RoleType[] roleArray = (RoleType[])Enum.GetValues(typeOfEnum);
            foreach (RoleType item in roleArray)
            {
                lstRoles.Add(item);
            }

            return lstRoles;
        }

        /// <summary>
        /// 根据角色数组生成数据表
        /// </summary>
        /// <param name="roleArray">角色数组</param>
        /// <returns>数据表</returns>
        private DataTable generateDataSource(List<RoleType> roleList)
        {

            // 创建数据表.
            DataTable table = new DataTable();
            DataColumn roleColumn = new DataColumn("RoleName", typeof(string));
            table.Columns.Add(roleColumn);

            // 创建数据行.
            if (roleList != null)
            {
                DataRow row = null;
                foreach (RoleType item in roleList)
                {
                    row = table.NewRow();

                    row["RoleName"] = convertRoleTypeToString(item);
                    table.Rows.Add(row);
                }
            }

            return table;
        }

        /// <summary>
        /// 将枚举中的值转换成中文名称
        /// </summary>
        /// <param name="role">枚举值</param>
        /// <returns>枚举值对应的中文名称</returns>
        private string convertRoleTypeToString(RoleType role)
        {
            string strRole = string.Empty;

            switch (role)
            {
                case RoleType.CJGL:
                    strRole = "投融资业务移交";
                    break;
                case RoleType.CNKJ:
                    strRole = "财务报销归档-报销";
                    break;
                case RoleType.CWZG:
                    strRole = "财务部员工离职审批";
                    break;
                case RoleType.CWZJ:
                    //strRole = "财务部门总监";
                    strRole = "民间融资费用支付申请";
                    break;
                case RoleType.YWZJ:
                    strRole = "业务成本变更";
                    break;
                case RoleType.DSZ:
                    //strRole = "董事长";
                    strRole = "投融资业务款(备用金)>30w归档";
                    break;
                case RoleType.DZKJ:
                    strRole = "交款单位代帐会计";
                    break;
                //case RoleType.FZJL:
                //    strRole = "副总经理";
                //    break;
                case RoleType.HSKJ:
                    //strRole = "核算会计";
                    strRole = "核算会计材料归档";
                    break;
                case RoleType.KQGD:
                    strRole = "提交行政归档员归档-考勤";
                    break;
                //case RoleType.KQY:
                //    strRole = "考勤员";
                //    break;
                //case RoleType.PTYG:
                //    strRole = "普通员工";
                //    break;
                case RoleType.TZZG:
                    strRole = "投融资部员工离职审批";
                    break;
                case RoleType.TZZJ:
                    //strRole = "投资部门总监";
                    strRole = "投融资项目进展归档、民间融资申请";
                    break;
                case RoleType.XZZG:
                    strRole = "行政部员工离职审批";
                    break;
                //case RoleType.XZZJ:
                //    strRole = "行政部门总监";
                //    break;
                case RoleType.YWZG:
                    strRole = "业务部员工离职审批";
                    break;
                //case RoleType.YWZJ:
                //    strRole = "业务部门总监";
                //    break;
                //case RoleType.ZBKJ:
                //    strRole = "主办会计";
                //    break;
                case RoleType.ZJL:
                    //strRole = "总经理";
                    strRole = "投融资业务款(备用金)<30w归档";
                    break;
                //case RoleType.WUSQ_PT:
                //    strRole = "一般物资申请";
                //    break;
                case RoleType.WZSQ_GD:
                    strRole = "固定资产申请";
                    break;
                case RoleType.DZFGD:
                    strRole = "代账费归档";
                    break;
                case RoleType.WZSPGD:
                    strRole = "物资审批归档-领取";
                    break;
                //case RoleType.JKSQ:
                //    strRole = "借款申请归档";
                //    break;
                //case RoleType.MJRZ:
                //    strRole = "民间融资申请归档";
                //    break;
                //case RoleType.YHDK:
                //    strRole = "银行贷款申请归档";
                //    break;
                case RoleType.XZGLGD:
                    strRole = "薪资管理归档-发放";
                    break;
                case RoleType.GXGD:
                    strRole = "薪资管理归档-加薪";
                    break;
                case RoleType.PZGD:
                    strRole = "财务报销归档-凭证";
                    break;
                //case RoleType.YGGL:
                //    strRole = "员工管理员";
                //    break;
                //case RoleType.JCGL:
                //    strRole = "奖惩管理员";
                //    break;
                //case RoleType.XXGL:
                //    strRole = "消息管理员";
                //    break;
                //case RoleType.WZGL:
                //    strRole = "物资管理员";
                //    break;
                //case RoleType.BXPZCJ:
                //    strRole = "报销凭证创建";
                //    break;
                //case RoleType.YWY:
                //    strRole = "业务员";
                //    break;
                case RoleType.YWBBYJGD:
                    strRole = "业务部备用金归档";
                    break;
                //case RoleType.QT:
                //    strRole = "前台";
                //    break;
                case RoleType.XZBBYJGDDY1:
                    strRole = "行政部备用金>1w归档";
                    break;
                case RoleType.XZBBYJGDXY1:
                    strRole = "行政部备用金<1w归档";
                    break;
                case RoleType.XZBFKJGD:
                    strRole = "行政部付款归档";
                    break;
                case RoleType.XZBSKGD:
                    strRole = "行政部收款上交归档";
                    break;
                case RoleType.YWFYSQCNQR:
                    strRole = "业务费用收取出纳确认";
                    break;
                case RoleType.YWFYSQQRGDDY30W:
                    strRole = "业务费用收取确认归档>30W";
                    break;
                case RoleType.YWFYSQQRGDXY30W:
                    strRole = "业务费用收取确认归档<30W";
                    break;
                case RoleType.DZDMBGD:
                    strRole = "代帐单模板归档";
                    break;
            }

            return strRole;
        }

        #endregion

        #region 按钮事件

        /// <summary>
        /// 分配角色事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            // 获取选中一行.
            if (gridUnSelectRoles.SelectedRowIndexArray.Length == 0)
            {
                return;
            }

            int index = gridUnSelectRoles.SelectedRowIndexArray[0];

            List<RoleType> lstUnselectRoles = UnselectRoles;
            List<RoleType> lstSelectedRoles = SelectedRoles;

            // 修改列表.
            RoleType roleType = lstUnselectRoles[index];
            lstSelectedRoles.Add(roleType);
            lstUnselectRoles.RemoveAt(index);

            // 重新绑定Grid.
            lstUnselectRoles.Sort();
            lstSelectedRoles.Sort();
            bindUnselectGridView(lstUnselectRoles);
            bindSelectedGridView(lstSelectedRoles);

            // 保存列表.
            SelectedRoles = lstSelectedRoles;
            UnselectRoles = lstUnselectRoles;
        }

        /// <summary>
        /// 取消分配角色事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUnselect_Click(object sender, EventArgs e)
        {
            // 获取选中一行.
            if (gridSelectdRoles.SelectedRowIndexArray.Length == 0)
            {
                return;
            }

            int index = gridSelectdRoles.SelectedRowIndexArray[0];

            List<RoleType> lstUnselectRoles = UnselectRoles;
            List<RoleType> lstSelectedRoles = SelectedRoles;

            // 修改列表.
            RoleType roleType = lstSelectedRoles[index];
            lstUnselectRoles.Add(roleType);
            lstSelectedRoles.RemoveAt(index);

            // 重新绑定Grid.
            lstUnselectRoles.Sort();
            lstSelectedRoles.Sort();
            bindUnselectGridView(lstUnselectRoles);
            bindSelectedGridView(lstSelectedRoles);

            // 保存列表.
            SelectedRoles = lstSelectedRoles;
            UnselectRoles = lstUnselectRoles;
        }

        /// <summary>
        /// 保存事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            // 将选中的角色添加或更新到角色表中.
            if (ViewState["SelectedRoles"] != null)
            {
                // 获取用户ID.
                string strUserObjectID = UserObjectID;

                // 获取角色实例,如果没有获取到，则表明是一条新记录，即从用户表中获取相应的信息.
                RolesManage _rolesManage = new RolesManage();
                UserRoles _userRoles = _rolesManage.GetRolesByObjectID(strUserObjectID);
                bool isNew = false;
                if (_userRoles == null)
                {
                    isNew = true;
                    _userRoles = new UserRoles();
                    // 获取用户信息.
                    UserInfo _userInfo = new UserManage().GetUserByObjectID(strUserObjectID);
                    _userRoles.UserObjectId = new Guid(strUserObjectID);
                    _userRoles.AccountNo = _userInfo.AccountNo;
                    _userRoles.JobNo = _userInfo.JobNo;
                    _userRoles.Name = _userInfo.Name;
                }

                // 设置实例中的角色值.
                List<RoleType> lstSelectedRoles = SelectedRoles;
                _userRoles.Roles = string.Empty;
                foreach (RoleType item in lstSelectedRoles)
                {
                    if (lstSelectedRoles.Count > 0 && item != lstSelectedRoles[0])
                    {
                        _userRoles.Roles += ",";
                    }
                    _userRoles.Roles += (int)item;
                }

                // 根据标示IsNew来进行不同的操作.
                int result;
                if (isNew)
                {
                    result = _rolesManage.AddRoles(_userRoles);
                }
                else
                {
                    result = _rolesManage.UpdateRoles(_userRoles);
                }

                if (result == -1)
                {
                    PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
                }
                else
                {
                    Alert.Show((isNew ? "添加权限" : "更新权限") + (result == -1 ? "成功" : "失败"));
                }
            }
        }

        #endregion
    }
}