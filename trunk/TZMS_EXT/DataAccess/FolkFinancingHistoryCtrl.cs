//----------------------------------------------------------------------------------------------------
//程序名:	FolkFinancingHistory 控制类
//功能:  	定义了与 dbo.FolkFinancingHistory 表 对应的数据访问控制类
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
    /// FolkFinancingHistoryCtrl
    /// programmer:shunlian
    /// </summary>
    public class FolkFinancingHistoryCtrl
    {
        #region 构造函数

        /// <summary>
        /// FolkFinancingHistoryCtrl默认构造函数
        /// </summary>
        public FolkFinancingHistoryCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.FolkFinancingHistory一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="FolkFinancingHistoryInfo">FolkFinancingHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, FolkFinancingHistoryInfo FolkFinancingHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "FolkFinancingHistory_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@Id",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@OperationerName",DbType.String),
				new SqlParameter("@OperationerAccount",DbType.String),
				new SqlParameter("@OperationTime",DbType.DateTime),
				new SqlParameter("@OperationType",DbType.String),
				new SqlParameter("@OperationDesc",DbType.String),
				new SqlParameter("@Remark",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.Id;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.ForId;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.OperationerName;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.OperationTime;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.OperationType;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.OperationDesc;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.Remark;
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
        /// dbo.FolkFinancingHistory删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "FolkFinancingHistory_Delete";

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
        /// FolkFinancingHistory 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="FolkFinancingHistoryInfo">FolkFinancingHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, FolkFinancingHistoryInfo FolkFinancingHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "FolkFinancingHistory_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@Id",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@OperationerName",DbType.String),
				new SqlParameter("@OperationerAccount",DbType.String),
				new SqlParameter("@OperationTime",DbType.DateTime),
				new SqlParameter("@OperationType",DbType.String),
				new SqlParameter("@OperationDesc",DbType.String),
				new SqlParameter("@Remark",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.Id;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.ForId;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.OperationerName;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.OperationTime;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.OperationType;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.OperationDesc;
                sqlparam[i++].Value = FolkFinancingHistoryInfo.Remark;
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
        /// FolkFinancingHistory 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "FolkFinancingHistory_Search";
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
        ///FolkFinancingHistory 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<FolkFinancingHistoryInfo></returns>
        public List<FolkFinancingHistoryInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<FolkFinancingHistoryInfo> list = new List<FolkFinancingHistoryInfo>();
            FolkFinancingHistoryInfo accountInfo = new FolkFinancingHistoryInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = FolkFinancingHistoryInfoRowToInfo(row);
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
        /// <param name="FolkFinancingHistoryDataRow">FolkFinancingHistoryDataRow</param>
        /// <returns>FolkFinancingHistoryInfo</returns>
        internal FolkFinancingHistoryInfo FolkFinancingHistoryInfoRowToInfo(DataRow FolkFinancingHistoryInfoInfoDataRow)
        {
            FolkFinancingHistoryInfo FolkFinancingHistoryInfoInfo = new FolkFinancingHistoryInfo();
            if (FolkFinancingHistoryInfoInfoDataRow["Id"] != null)
            {
                FolkFinancingHistoryInfoInfo.Id = new Guid(DataUtil.GetStringValueOfRow(FolkFinancingHistoryInfoInfoDataRow, "Id"));
            }
            if (FolkFinancingHistoryInfoInfoDataRow["ForId"] != null)
            {
                FolkFinancingHistoryInfoInfo.ForId = new Guid(DataUtil.GetStringValueOfRow(FolkFinancingHistoryInfoInfoDataRow, "ForId"));
            }
            if (FolkFinancingHistoryInfoInfoDataRow["OperationerName"] != null)
            {
                FolkFinancingHistoryInfoInfo.OperationerName = DataUtil.GetStringValueOfRow(FolkFinancingHistoryInfoInfoDataRow, "OperationerName");
            }
            if (FolkFinancingHistoryInfoInfoDataRow["OperationerAccount"] != null)
            {
                FolkFinancingHistoryInfoInfo.OperationerAccount = DataUtil.GetStringValueOfRow(FolkFinancingHistoryInfoInfoDataRow, "OperationerAccount");
            }
            if (FolkFinancingHistoryInfoInfoDataRow["OperationTime"] != null)
            {
                FolkFinancingHistoryInfoInfo.OperationTime = DateTime.Parse(DataUtil.GetStringValueOfRow(FolkFinancingHistoryInfoInfoDataRow, "OperationTime"));
            }
            if (FolkFinancingHistoryInfoInfoDataRow["OperationType"] != null)
            {
                FolkFinancingHistoryInfoInfo.OperationType = DataUtil.GetStringValueOfRow(FolkFinancingHistoryInfoInfoDataRow, "OperationType");
            }
            if (FolkFinancingHistoryInfoInfoDataRow["OperationDesc"] != null)
            {
                FolkFinancingHistoryInfoInfo.OperationDesc = DataUtil.GetStringValueOfRow(FolkFinancingHistoryInfoInfoDataRow, "OperationDesc");
            }
            if (FolkFinancingHistoryInfoInfoDataRow["Remark"] != null)
            {
                FolkFinancingHistoryInfoInfo.Remark = DataUtil.GetStringValueOfRow(FolkFinancingHistoryInfoInfoDataRow, "Remark");
            }

            return FolkFinancingHistoryInfoInfo;
        }
        #endregion
    }
}
