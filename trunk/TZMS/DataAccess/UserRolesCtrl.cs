//----------------------------------------------------------------------------------------------------
//程序名:	UserRoles 控制类
//功能:  	定义了与 dbo.	UserRoles 表 对应的数据访问控制类
//作者:  	xiguazerg
//时间:	2011-10-21 
//----------------------------------------------------------------------------------------------------
//更改历史:
// 日期		            更改人		     更改内容
//---------------------------------------------------------------------------------------------------- 
//----------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Com.iFlytek.DatabaseAccess.DAL;
using Com.iFlytek.BaseService;
using com.TZMS.Model;
using Com.iFlytek.Utility;

namespace com.TZMS.DataAccess
{
    /// <summary>
    /// UserRolesCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class UserRolesCtrl
    {
        #region 构造函数

        /// <summary>
        /// UserRolesCtrl默认构造函数
        /// </summary>
        public UserRolesCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.UserRoles一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="UserRoles">UserRoles??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, UserRoles UserRoles)
        {
            try
            {
                //存储过程名称
                string strsql = "UserRoles_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@UserObjectID",DbType.Guid),
				new SqlParameter("@AccountNo",DbType.String),
				new SqlParameter("@JobNo",DbType.String),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Roles",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = UserRoles.UserObjectId;
                sqlparam[i++].Value = UserRoles.AccountNo;
                sqlparam[i++].Value = UserRoles.JobNo;
                sqlparam[i++].Value = UserRoles.Name;
                sqlparam[i++].Value = UserRoles.Roles;
                SqlDBAccess dbaccess = new SqlDBAccess();
                //执行存储过程
                i = dbaccess.ExecuteNonQuery(boName, CommandType.StoredProcedure, strsql, sqlparam);
                return i;
            }
            catch (Exception e)
            {
                Tracing.Error(this, e);
                throw e;
            }
        }

        /// <summary>
        /// dbo.UserRoles删除记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">条件</param>
        public void Delete(string boName, string condition)
        {
            try
            {
                string strsql = "UserRoles_Delete";

                SqlParameter[] sqlparam =
				{
					new SqlParameter ( "@Condition", SqlDbType.NVarChar )
				};
                int i = 0;
                sqlparam[i++].Value = condition;

                SqlDBAccess dbaccess = new SqlDBAccess();
                dbaccess.ExecuteNonQuery(boName, CommandType.StoredProcedure, strsql, sqlparam);
            }
            catch (Exception e)
            {
                Tracing.Error(this, e);
                throw e;
            }
        }

        /// <summary>
        ///  UserRoles更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="UserRoles">UserRoles??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, UserRoles UserRoles)
        {
            try
            {
                //存储过程名称
                string strsql = "UserRoles_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@UserObjectID",DbType.Guid),
				new SqlParameter("@AccountNo",DbType.String),
				new SqlParameter("@JobNo",DbType.String),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Roles",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = UserRoles.UserObjectId;
                sqlparam[i++].Value = UserRoles.AccountNo;
                sqlparam[i++].Value = UserRoles.JobNo;
                sqlparam[i++].Value = UserRoles.Name;
                sqlparam[i++].Value = UserRoles.Roles;
                SqlDBAccess dbaccess = new SqlDBAccess();
                //执行存储过程
                i = dbaccess.ExecuteNonQuery(boName, CommandType.StoredProcedure, strsql, sqlparam);
                return i;
            }
            catch (Exception e)
            {
                Tracing.Error(this, e);
                throw e;
            }
        }

        /// <summary>
        ///  UserRoles查询，返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "UserRoles_Search";
                SqlParameter[] sqlparam =
                {
					new SqlParameter("@Condition",SqlDbType.NVarChar), 
                };

                int i = 0;
                sqlparam[i++].Value = condition;
                SqlDBAccess dbaccess = new SqlDBAccess();
                //执行存储过程
                DataSet ds = (DataSet)dbaccess.ExecuteDataset(boName, CommandType.StoredProcedure, strsql, sqlparam);

                return ds.Tables[0];
            }
            catch (Exception e)
            {
                Tracing.Error(this, e);
                throw e;
            }
        }

        ///<summary>
        ///  UserRoles查询，返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">条件</param>
        /// <returns>List<UserRoles></returns>
        public List<UserRoles> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<UserRoles> list = new List<UserRoles>();
            UserRoles accountInfo = new UserRoles();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = UserRolesRowToInfo(row);
                    list.Add(accountInfo);
                }

                return list;
            }
            catch (Exception e)
            {
                Tracing.Error(this, e);
                throw e;
            }
        }

        /// <summary>
        /// DataRow To Object
        /// </summary>
        /// <param name="DataRow">DataRow</param>
        /// <returns>UserRoles</returns>
        internal UserRoles UserRolesRowToInfo(DataRow InfoDataRow)
        {
            UserRoles Info = new UserRoles();
            if (InfoDataRow["UserObjectID"] != null)
            {
                Info.UserObjectId = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "UserObjectID"));
            }
            if (InfoDataRow["AccountNo"] != null)
            {
                Info.AccountNo = DataUtil.GetStringValueOfRow(InfoDataRow, "AccountNo");
            }
            if (InfoDataRow["JobNo"] != null)
            {
                Info.JobNo = DataUtil.GetStringValueOfRow(InfoDataRow, "JobNo");
            }
            if (InfoDataRow["Name"] != null)
            {
                Info.Name = DataUtil.GetStringValueOfRow(InfoDataRow, "Name");
            }
            if (InfoDataRow["Roles"] != null)
            {
                Info.Roles = DataUtil.GetStringValueOfRow(InfoDataRow, "Roles");
            }

            return Info;
        }
        #endregion
    }
}
