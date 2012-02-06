using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    /// <summary>
    /// 用户管理 逻辑层
    /// </summary>
    public class UserManage : ParentManage
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public UserManage()
        {
            //todo
        }

        /// <summary>
        ///  添加用户到数据库
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="user">用户userinfo 实体</param>
        /// <returns>返回执行结果</returns>
        public int AddUser( UserInfo user,string boName=BoName)
        {
            UserCtrl uc = new UserCtrl();
            return uc.Insert(boName, user);
        }

        /// <summary>
        /// 根据用户唯一ID删除该用户(假删除，改变 state=2)
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="objectID">用户唯一ID（GUID）</param>
        public void Delete(string objectID, string boName = BoName)
        {
            UserCtrl uc = new UserCtrl();
            uc.Delete(boName, " ObjectID ='" + objectID + "' ");
        }

        /// <summary>
        /// 通过ObjectID获得员工
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="objectID">ObjectID</param>
        /// <returns>用户唯一ID（GUID）</returns>
        public UserInfo GetUserByObjectID(string objectID,string boName=BoName)
        {
            UserCtrl uc = new UserCtrl();
            List<UserInfo> users = uc.SelectAsList(boName, " state <> 2 and ObjectID ='" + objectID + "' ");
            if (users.Count == 0)
            {
                return null;
            }
            return users[0];
        }

        /// <summary>
        /// 通过帐号获得员工
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="accountNo">帐号</param>
        /// <returns>用户实体</returns>
        public UserInfo GetUserByAccountNo( string accountNo,string boName=BoName)
        {
            UserCtrl uc = new UserCtrl();
            List<UserInfo> users = uc.SelectAsList(boName, " state <> 2 and  AccountNo ='" + accountNo + "' ");
            if (users.Count == 0)
            {
                return null;
            }
            return users[0];
        }

        /// <summary>
        /// 根据姓名和工号获取用户
        /// </summary>
        /// <param name="strName">姓名</param>
        /// <param name="strJobNo">工号</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>用户实例</returns>
        public UserInfo GetUserByNameAndJobNo(string strName, string strJobNo, string boName = BoName)
        {
            UserCtrl uc = new UserCtrl();
            List<UserInfo> users = uc.SelectAsList(boName, " state <> 2 and  Name ='" + strName + "' and JobNo ='" + strJobNo + "'");
            if (users.Count == 0)
            {
                return null;
            }
            return users[0];
        }

        /// <summary>
        /// 获得所有员工
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>用户集合</returns>
        public List<UserInfo> GetAllUsers(string boName=BoName)
        {
            UserCtrl uc = new UserCtrl();
            return uc.SelectAsList(boName, " state <> 2 ");
        }

        /// <summary>
        /// 获得公司所有在职员工
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>用户集合</returns>
        public List<UserInfo> GetAllWorkUsers(string boName=BoName)
        {
            UserCtrl uc = new UserCtrl();
            return uc.SelectAsList(boName, " state = 1 ");
        }

        /// <summary>
        /// 根据部门获得其所有在职员工
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="dept">部门</param>
        /// <returns>用户集合</returns>
        public List<UserInfo> GetAllWorkUsersByDept(string dept,string boName=BoName)
        {
            UserCtrl uc = new UserCtrl();
            return uc.SelectAsList(boName, " state = 1 and dept='" + dept + "' ");
        }

        /// <summary>
        /// 根据部门获得其所有离职员工
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="dept">部门</param>
        /// <returns>用户集合</returns>
        public List<UserInfo> GetAllOutWorkUsersByDept(string dept,string boName=BoName)
        {
            UserCtrl uc = new UserCtrl();
            return uc.SelectAsList(boName, " state = 0 and dept='" + dept + "' ");
        }

        /// <summary>
        /// 根据条件获得员工信息
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="condtion">条件</param>
        /// <returns>用户集合</returns>
        public List<UserInfo> GetUsersByCondtion(string condtion, string boName = BoName)
        {
            UserCtrl uc = new UserCtrl();

            return uc.SelectAsList(boName, condtion);
        }

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="user">用户实体</param>
        /// <returns>执行结果</returns>
        public int UpdateUser( UserInfo user,string boName=BoName)
        {
            UserCtrl uc = new UserCtrl();
            return uc.UpDate(boName, user);
        }

        /// <summary>
        /// 获得一个未使用工号（当前最大工号+1）
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>返回“0000”表示获得失败</returns>
        public string GetNextJobNo(string boName = BoName)
        {
            string currentJobNo = string.Empty;
            UserCtrl uc = new UserCtrl();
            //List<UserInfo> users = uc.SelectAsList(boName, " state<> 2 ");
            List<UserInfo> users = uc.SelectAsList(boName, " 1=1 ");
            //if (users.Count == 0)
            //{
            //    return "1000";
            //}
            //UserInfo user = users[users.Count - 1];
            //currentJobNo = user.JobNo;
            //int re = 0;
            //if (int.TryParse(currentJobNo, out re))
            //{
            //    re++;
            //}
            //else
            //{
            //    return "0000";
            //}

            //return re.ToString();

            if (users.Count > 0)
            {
                users.Sort(delegate(UserInfo x, UserInfo y) { return Convert.ToInt32(y.JobNo) - Convert.ToInt32(x.JobNo); });
                return (Convert.ToInt32(users[0].JobNo) + 1).ToString();
            }

            return "1000";
        }

        //public bool 

    }
}
