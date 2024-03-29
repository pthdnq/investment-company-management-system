﻿using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class CheckMange : ParentManage
    {
        /// <summary>
        /// 默认构造方法
        /// </summary>
        public CheckMange()
        {
            //to do 
        }

        /// <summary>
        /// 根据用户ID 删除用户的所有审批人
        /// </summary>
        /// <param name="userList">关系集</param>
        /// <param name="boName">数据库连接字符串Key</param>
        public void Delete(string userObjectID, string boName = BoName)
        {
            ComCheckerCtrl ccc = new ComCheckerCtrl();
            ccc.Delete(boName, " userObjectID='" + userObjectID + "'");
        }

        /// <summary>
        /// 添加审核人
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="checks">审核人集合</param>
        /// <param name="boName">数据库连接字符串Key</param>
        public void Add(UserInfo user, List<UserInfo> checks, string boName = BoName)
        {
            //删除关系
            Delete(user.ObjectId.ToString(), boName);
            //添加关系
            ComCheckerCtrl ccc = new ComCheckerCtrl();
            foreach (UserInfo temp in checks)
            {
                ComCheckerInfo cci = new ComCheckerInfo();
                cci.UserObjectId = user.ObjectId;
                cci.UserName = user.Name;
                cci.CheckerObjectId = temp.ObjectId;
                cci.CheckerName = temp.Name;
                ccc.Insert(boName, cci);
            }
        }
        /// <summary>
        /// 根据用户ID获得其审批人
        /// </summary>
        /// <param name="userObjectID">用户ID</param>
        /// <param name="boName">数据库连接字符串Key</param>
        /// <returns>ComCheckerInfo 集合(离职人员不在范围内)</returns>
        public List<ComCheckerInfo> GetComCheckersByUserID(string userObjectID, string boName = BoName)
        {
            ComCheckerCtrl ccc = new ComCheckerCtrl();
            UserManage um = new UserManage();
            List<ComCheckerInfo> lstChecker = ccc.SelectAsList(boName, " userObjectID='" + userObjectID + "'");
            List<ComCheckerInfo> Checkers = new List<ComCheckerInfo>();
            //过滤离职人员
            foreach (ComCheckerInfo check in lstChecker)
            {
                UserInfo user = um.GetUserByObjectID(check.CheckerObjectId.ToString());
                if (user != null )
                {
                    Checkers.Add(check);
                }
            }
            return Checkers;
        }

        /// <summary>
        /// 根据用户ID获得其审批人
        /// </summary>
        /// <param name="userObjectID">用户ID</param>
        /// <param name="boName">数据库连接字符串Key</param>
        /// <returns>UserInfo 集合(离职人员不在范围内)</returns>
        public List<UserInfo> GetCheckersByUserID(string userObjectID, string boName = BoName)
        {
            List<UserInfo> users = new List<UserInfo>();
            ComCheckerCtrl ccc = new ComCheckerCtrl();
            List<ComCheckerInfo> lstChecker = ccc.SelectAsList(boName, " userObjectID='" + userObjectID + "'");
            UserManage um = new UserManage();

            foreach (ComCheckerInfo check in lstChecker)
            {
                UserInfo user = um.GetUserByObjectID(check.CheckerObjectId.ToString());
                if (user != null)
                {
                    users.Add(user);
                }
            }
            return users;
        }
    }
}
