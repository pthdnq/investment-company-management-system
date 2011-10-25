using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    /// <summary>
    /// 角色管理 逻辑层
    /// </summary>
    public class RolesManage : ParentManage
    {
        /// <summary>
        /// 默认构造函数.
        /// </summary>
        public RolesManage()
        {
        }

        /// <summary>
        /// 添加新角色到UserRoles.
        /// </summary>
        /// <param name="role">角色实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>返回执行结果</returns>
        public int AddRoles(UserRoles role, string boName = BoName)
        {
            UserRolesCtrl roleCtrl = new UserRolesCtrl();
            return roleCtrl.Insert(boName, role);
        }

        /// <summary>
        /// 删除UserRoles中指定ID的记录.
        /// </summary>
        /// <param name="objectID">用户ID</param>
        /// <param name="boName">连接字符串Key</param>
        public void Delete(string objectID, string boName = BoName)
        {
            UserRolesCtrl roleCtrl = new UserRolesCtrl();
            roleCtrl.Delete(boName, "UserObjectID='" + objectID + "'");
        }

        /// <summary>
        /// 获取指定用户ID对应的角色实体.
        /// </summary>
        /// <param name="objectID">用户ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>角色实例</returns>
        public UserRoles GetRolesByObjectID(string objectID, string boName = BoName)
        {
            UserRolesCtrl roleCtrl = new UserRolesCtrl();
            List<UserRoles> lstRoles = roleCtrl.SelectAsList(boName, "UserObjectID='" + objectID + "'");
            if (lstRoles.Count == 0)
            {
                return null;
            }

            return lstRoles[0];
        }

        /// <summary>
        /// 根据条件获取角色集合.
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>角色集合</returns>
        public List<UserRoles> GerRolesByCondition(string condition, string boName = BoName) 
        {
            UserRolesCtrl roleCtrl = new UserRolesCtrl();
            return roleCtrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 更新用户角色.
        /// </summary>
        /// <param name="userRoles">用户角色实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int UpdateRoles(UserRoles userRoles, string boName = BoName) 
        {
            UserRolesCtrl roleCtrl = new UserRolesCtrl();
            return roleCtrl.UpDate(boName, userRoles);
        }
    }
}
