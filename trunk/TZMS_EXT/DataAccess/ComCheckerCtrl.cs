//----------------------------------------------------------------------------------------------------
//程序名:	ComChecker 控制类
//功能:  	定义了与 dbo.ComChecker 表 对应的数据访问控制类
//作者:  	shunlian
//时间:	2011-10-26 
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
using Com.iFlytek.Utility;
using com.TZMS.Model;

namespace com.TZMS.DataAccess
{
    /// <summary>
    /// ComCheckerCtrl
    /// programmer:shunlian
    /// </summary>
    public class ComCheckerCtrl
    {
        #region 构造函数

        /// <summary>
        /// ComCheckerCtrl默认构造函数
        /// </summary>
        public ComCheckerCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.ComChecker一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ComCheckerInfo">ComCheckerInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, ComCheckerInfo comCheckerInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ComChecker_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@UserObjectId",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@CheckerObjectId",DbType.Guid),
				new SqlParameter("@CheckerName",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = comCheckerInfo.UserObjectId;
                sqlparam[i++].Value = comCheckerInfo.UserName;
                sqlparam[i++].Value = comCheckerInfo.CheckerObjectId;
                sqlparam[i++].Value = comCheckerInfo.CheckerName;
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
        /// dbo.ComChecker删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ComChecker_Delete";

                SqlParameter[] sqlparam =
				{
					new SqlParameter ( "@Condition", SqlDbType.NVarChar )
				};
                int i = 0;
                sqlparam[i++].Value = objectID;

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
        /// ComChecker 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ComCheckerInfo">ComCheckerInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, ComCheckerInfo comCheckerInfo)
        {                              
            try
            {
                //存储过程名称
                string strsql = "ComChecker_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@UserObjectId",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@CheckerObjectId",DbType.Guid),
				new SqlParameter("@CheckerName",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = comCheckerInfo.UserObjectId;
                sqlparam[i++].Value = comCheckerInfo.UserName;
                sqlparam[i++].Value = comCheckerInfo.CheckerObjectId;
                sqlparam[i++].Value = comCheckerInfo.CheckerName;
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
        /// ComChecker 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "ComChecker_Search";
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
        ///ComChecker 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<ComCheckerInfo></returns>
        public List<ComCheckerInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ComCheckerInfo> list = new List<ComCheckerInfo>();
            ComCheckerInfo accountInfo = new ComCheckerInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ComCheckerInfoRowToInfo(row);
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
        /// <param name="ComCheckerDataRow">ComCheckerDataRow</param>
        /// <returns>ComCheckerInfo</returns>
        internal ComCheckerInfo ComCheckerInfoRowToInfo(DataRow ComCheckerInfoInfoDataRow)
        {
            ComCheckerInfo ComCheckerInfoInfo = new ComCheckerInfo();
            if (ComCheckerInfoInfoDataRow["UserObjectId"] != null)
            {
                ComCheckerInfoInfo.UserObjectId =new Guid( DataUtil.GetStringValueOfRow(ComCheckerInfoInfoDataRow, "UserObjectId"));
            }
            if (ComCheckerInfoInfoDataRow["UserName"] != null)
            {
                ComCheckerInfoInfo.UserName = DataUtil.GetStringValueOfRow(ComCheckerInfoInfoDataRow, "UserName");
            }
            if (ComCheckerInfoInfoDataRow["CheckerObjectId"] != null)
            {
                ComCheckerInfoInfo.CheckerObjectId = new Guid(DataUtil.GetStringValueOfRow(ComCheckerInfoInfoDataRow, "CheckerObjectId"));
            }
            if (ComCheckerInfoInfoDataRow["CheckerName"] != null)
            {
                ComCheckerInfoInfo.CheckerName = DataUtil.GetStringValueOfRow(ComCheckerInfoInfoDataRow, "CheckerName");
            }

            return ComCheckerInfoInfo;
        }
        #endregion
    }
}
