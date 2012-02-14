//----------------------------------------------------------------------------------------------------
//程序名:	AttendInfo 控制类
//功能:  	定义了与 dbo.AttendInfo 表 对应的数据访问控制类
//作者:  	shunlian
//时间:	2011-10-16 
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

namespace com.TZMS.DataAccess
{
    /// <summary>
    /// AttendInfoCtrl
    /// programmer:shunlian
    /// </summary>
    public class AttendInfoCtrl
    {
        #region 构造函数

        /// <summary>
        /// AttendInfoCtrl默认构造函数
        /// </summary>
        public AttendInfoCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.AttendInfo一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="AttendInfo">AttendInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, AttendInfo AttendInfo)
        {
            try
            {
				//存储过程名称
                string strsql = "AttendInfo_Add"; 
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@JobNo",DbType.String),
				new SqlParameter("@AccountNo",DbType.String),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@PushTime1",DbType.DateTime),
				new SqlParameter("@PushTime2",DbType.DateTime),
				new SqlParameter("@StartWorkTime",DbType.DateTime),
				new SqlParameter("@StopWorkTime",DbType.DateTime),
                new SqlParameter("@Other",DbType.String),
				};
				
				int i=0;
				sqlparam[i++].Value = AttendInfo.ObjectId; 
				sqlparam[i++].Value = AttendInfo.JobNo; 
				sqlparam[i++].Value = AttendInfo.AccountNo; 
				sqlparam[i++].Value = AttendInfo.Name; 
				sqlparam[i++].Value = AttendInfo.Dept; 
				sqlparam[i++].Value = AttendInfo.PushTime1; 
				sqlparam[i++].Value = AttendInfo.PushTime2; 
				sqlparam[i++].Value = AttendInfo.StartWorkTime; 
				sqlparam[i++].Value = AttendInfo.StopWorkTime;
                sqlparam[i++].Value = AttendInfo.Other;
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
        /// dbo.AttendInfo删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "AttendInfo_Delete";

                SqlParameter[] sqlparam =
				{
					new SqlParameter ( "@ObjectID", SqlDbType.NVarChar )
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
        /// AttendInfo 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="AttendInfo">AttendInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, AttendInfo AttendInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "AttendInfo_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@JobNo",DbType.String),
				new SqlParameter("@AccountNo",DbType.String),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@PushTime1",DbType.DateTime),
				new SqlParameter("@PushTime2",DbType.DateTime),
				new SqlParameter("@StartWorkTime",DbType.DateTime),
				new SqlParameter("@StopWorkTime",DbType.DateTime),
                 new SqlParameter("@Other",DbType.String),
                };

                int i = 0;
				sqlparam[i++].Value = AttendInfo.ObjectId; 
				sqlparam[i++].Value = AttendInfo.JobNo; 
				sqlparam[i++].Value = AttendInfo.AccountNo; 
				sqlparam[i++].Value = AttendInfo.Name; 
				sqlparam[i++].Value = AttendInfo.Dept; 
				sqlparam[i++].Value = AttendInfo.PushTime1; 
				sqlparam[i++].Value = AttendInfo.PushTime2; 
				sqlparam[i++].Value = AttendInfo.StartWorkTime; 
				sqlparam[i++].Value = AttendInfo.StopWorkTime;
                sqlparam[i++].Value = AttendInfo.Other;
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
        /// AttendInfo 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "AttendInfo_Search";
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
        ///AttendInfo 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<AttendInfo></returns>
        public List<AttendInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<AttendInfo> list = new List<AttendInfo>();
            AttendInfo accountInfo = new AttendInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = AttendInfoRowToInfo(row);
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
        /// <param name="AttendInfoDataRow">AttendInfoDataRow</param>
        /// <returns>AttendInfo</returns>
        internal AttendInfo AttendInfoRowToInfo(DataRow AttendInfoInfoDataRow)
        {
            AttendInfo AttendInfoInfo = new AttendInfo();
            if (AttendInfoInfoDataRow["ObjectID"] != null)
            {
                AttendInfoInfo.ObjectId = new Guid(AttendInfoInfoDataRow["ObjectID"].ToString());
            }
            if (AttendInfoInfoDataRow["JobNo"] != null)
            {
                AttendInfoInfo.JobNo = AttendInfoInfoDataRow["JobNo"].ToString();
            }
            if (AttendInfoInfoDataRow["AccountNo"] != null)
            {
                AttendInfoInfo.AccountNo = AttendInfoInfoDataRow["AccountNo"].ToString();
            }
            if (AttendInfoInfoDataRow["Name"] != null)
            {
                AttendInfoInfo.Name = AttendInfoInfoDataRow["Name"].ToString();
            }
            if (AttendInfoInfoDataRow["Dept"] != null)
            {
                AttendInfoInfo.Dept = AttendInfoInfoDataRow["Dept"].ToString();
            }
            if (AttendInfoInfoDataRow["PushTime1"] != null)
            {
                AttendInfoInfo.PushTime1 = DateTime.Parse(AttendInfoInfoDataRow["PushTime1"].ToString());
            }
            if (AttendInfoInfoDataRow["PushTime2"] != null)
            {
                AttendInfoInfo.PushTime2 = DateTime.Parse(AttendInfoInfoDataRow["PushTime2"].ToString());
            }
            if (AttendInfoInfoDataRow["StartWorkTime"] != null)
            {
                AttendInfoInfo.StartWorkTime = DateTime.Parse(AttendInfoInfoDataRow["StartWorkTime"].ToString());
            }
            if (AttendInfoInfoDataRow["StopWorkTime"] != null)
            {
                AttendInfoInfo.StopWorkTime = DateTime.Parse(AttendInfoInfoDataRow["StopWorkTime"].ToString());
            }

            if (AttendInfoInfoDataRow["Other"] != null)
            {
                AttendInfoInfo.Other = AttendInfoInfoDataRow["Other"].ToString();
            }

            return AttendInfoInfo;
        }
        #endregion
    }
}
