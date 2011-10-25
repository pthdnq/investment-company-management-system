//----------------------------------------------------------------------------------------------------
//程序名:	ReceivablesAuditHistory 控制类
//功能:  	定义了与 dbo.ReceivablesAuditHistory 表 对应的数据访问控制类
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
    /// ReceivablesAuditHistoryCtrl
    /// programmer:shunlian
    /// </summary>
    public class ReceivablesAuditHistoryCtrl
    {
        #region 构造函数

        /// <summary>
        /// ReceivablesAuditHistoryCtrl默认构造函数
        /// </summary>
        public ReceivablesAuditHistoryCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.ReceivablesAuditHistory一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ReceivablesAuditHistoryInfo">ReceivablesAuditHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, ReceivablesAuditHistoryInfo ReceivablesAuditHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ReceivablesAuditHistory_Add";
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
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.Id;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.ForId;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.OperationerName;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.OperationTime;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.OperationType;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.OperationDesc;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.Remark;
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
        /// dbo.ReceivablesAuditHistory删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ReceivablesAuditHistory_Delete";

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
        /// ReceivablesAuditHistory 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ReceivablesAuditHistoryInfo">ReceivablesAuditHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, ReceivablesAuditHistoryInfo ReceivablesAuditHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ReceivablesAuditHistory_Update";
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
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.Id;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.ForId;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.OperationerName;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.OperationTime;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.OperationType;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.OperationDesc;
                sqlparam[i++].Value = ReceivablesAuditHistoryInfo.Remark;
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
        /// ReceivablesAuditHistory 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "ReceivablesAuditHistory_Search";
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
        ///ReceivablesAuditHistory 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<ReceivablesAuditHistoryInfo></returns>
        public List<ReceivablesAuditHistoryInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ReceivablesAuditHistoryInfo> list = new List<ReceivablesAuditHistoryInfo>();
            ReceivablesAuditHistoryInfo accountInfo = new ReceivablesAuditHistoryInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ReceivablesAuditHistoryInfoRowToInfo(row);
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
        /// <param name="ReceivablesAuditHistoryDataRow">ReceivablesAuditHistoryDataRow</param>
        /// <returns>ReceivablesAuditHistoryInfo</returns>
        internal ReceivablesAuditHistoryInfo ReceivablesAuditHistoryInfoRowToInfo(DataRow ReceivablesAuditHistoryInfoInfoDataRow)
        {
            ReceivablesAuditHistoryInfo ReceivablesAuditHistoryInfoInfo = new ReceivablesAuditHistoryInfo();
            if (ReceivablesAuditHistoryInfoInfoDataRow["Id"] != null)
            {
                ReceivablesAuditHistoryInfoInfo.Id = new Guid(DataUtil.GetStringValueOfRow(ReceivablesAuditHistoryInfoInfoDataRow, "Id"));
            }
            if (ReceivablesAuditHistoryInfoInfoDataRow["ForId"] != null)
            {
                ReceivablesAuditHistoryInfoInfo.ForId = new Guid(DataUtil.GetStringValueOfRow(ReceivablesAuditHistoryInfoInfoDataRow, "ForId"));
            }
            if (ReceivablesAuditHistoryInfoInfoDataRow["OperationerName"] != null)
            {
                ReceivablesAuditHistoryInfoInfo.OperationerName = DataUtil.GetStringValueOfRow(ReceivablesAuditHistoryInfoInfoDataRow, "OperationerName");
            }
            if (ReceivablesAuditHistoryInfoInfoDataRow["OperationerAccount"] != null)
            {
                ReceivablesAuditHistoryInfoInfo.OperationerAccount = DataUtil.GetStringValueOfRow(ReceivablesAuditHistoryInfoInfoDataRow, "OperationerAccount");
            }
            if (ReceivablesAuditHistoryInfoInfoDataRow["OperationTime"] != null)
            {
                ReceivablesAuditHistoryInfoInfo.OperationTime = DateTime.Parse(DataUtil.GetStringValueOfRow(ReceivablesAuditHistoryInfoInfoDataRow, "OperationTime"));
            }
            if (ReceivablesAuditHistoryInfoInfoDataRow["OperationType"] != null)
            {
                ReceivablesAuditHistoryInfoInfo.OperationType = DataUtil.GetStringValueOfRow(ReceivablesAuditHistoryInfoInfoDataRow, "OperationType");
            }
            if (ReceivablesAuditHistoryInfoInfoDataRow["OperationDesc"] != null)
            {
                ReceivablesAuditHistoryInfoInfo.OperationDesc = DataUtil.GetStringValueOfRow(ReceivablesAuditHistoryInfoInfoDataRow, "OperationDesc");
            }
            if (ReceivablesAuditHistoryInfoInfoDataRow["Remark"] != null)
            {
                ReceivablesAuditHistoryInfoInfo.Remark = DataUtil.GetStringValueOfRow(ReceivablesAuditHistoryInfoInfoDataRow, "Remark");
            }

            return ReceivablesAuditHistoryInfoInfo;
        }
        #endregion
    }
}
