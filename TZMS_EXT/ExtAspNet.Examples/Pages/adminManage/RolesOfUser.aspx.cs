using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TZMS.Web.Pages.adminManage
{
    public partial class RolesOfUser : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 获取User ID.
                string strUserID = Page.Request.QueryString["ID"].ToString();

                if (!string.IsNullOrEmpty(strUserID))
                {
                    rolesFilter(null);
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
            bindUnselectGridView(lstUnselectRoles);
            bindSelectedGridView(lstSelectedRoles);
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
            DataColumn roleColumn = new DataColumn("Role", typeof(string));
            table.Columns.Add(roleColumn);

            // 创建数据行.
            if (roleList != null)
            {
                DataRow row = null;
                foreach (RoleType item in roleList)
                {
                    row = table.NewRow();
                    row["Role"] = convertRoleTypeToString(item);
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
                    strRole = "超级管理员";
                    break;
                case RoleType.CNKJ:
                    strRole = "出纳会计";
                    break;
                case RoleType.CWZG:
                    strRole = "财务部门主管";
                    break;
                case RoleType.CWZJ:
                    strRole = "财务部门总监";
                    break;
                case RoleType.DSZ:
                    strRole = "董事长";
                    break;
                case RoleType.DZKJ:
                    strRole = "代帐会计";
                    break;
                case RoleType.FZJL:
                    strRole = "副总经理";
                    break;
                case RoleType.HSKJ:
                    strRole = "核算会计";
                    break;
                case RoleType.KQGD:
                    strRole = "考勤归档";
                    break;
                case RoleType.KQY:
                    strRole = "考勤员";
                    break;
                case RoleType.PTYG:
                    strRole = "普通员工";
                    break;
                case RoleType.TZZG:
                    strRole = "投资部门总管";
                    break;
                case RoleType.TZZJ:
                    strRole = "投资部门总监";
                    break;
                case RoleType.XZZG:
                    strRole = "行政部门总管";
                    break;
                case RoleType.XZZJ:
                    strRole = "行政部门总监";
                    break;
                case RoleType.YWZG:
                    strRole = "业务部门总管";
                    break;
                case RoleType.YWZJ:
                    strRole = "业务部门总监";
                    break;
                case RoleType.ZBKJ:
                    strRole = "主办会计";
                    break;
                case RoleType.ZJL:
                    strRole = "总经理";
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

        }

        /// <summary>
        /// 取消分配角色事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUnselect_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}