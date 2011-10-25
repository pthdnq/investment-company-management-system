//----------------------------------------------------------------------------------------------------
//程序名:	FinancingFeePaymentHistory 控制类
//功能:  	定义了与 dbo.FinancingFeePaymentHistory 表 对应的数据访问控制类
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
    /// FinancingFeePaymentHistoryCtrl
    /// programmer:shunlian
    /// </summary>
    public class FinancingFeePaymentHistoryCtrl
    {
        #region 构造函数

        /// <summary>
        /// FinancingFeePaymentHistoryCtrl默认构造函数
        /// </summary>
        public FinancingFeePaymentHistoryCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.FinancingFeePaymentHistory一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="FinancingFeePaymentHistoryInfo">FinancingFeePaymentHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, FinancingFeePaymentHistoryInfo FinancingFeePaymentHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "FinancingFeePaymentHistory_Add";
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
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.Id;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.ForId;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.OperationerName;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.OperationTime;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.OperationType;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.OperationDesc;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.Remark;
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
        /// dbo.FinancingFeePaymentHistory删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "FinancingFeePaymentHistory_Delete";

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
        /// FinancingFeePaymentHistory 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="FinancingFeePaymentHistoryInfo">FinancingFeePaymentHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, FinancingFeePaymentHistoryInfo FinancingFeePaymentHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "FinancingFeePaymentHistory_Update";
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
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.Id;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.ForId;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.OperationerName;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.OperationTime;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.OperationType;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.OperationDesc;
                sqlparam[i++].Value = FinancingFeePaymentHistoryInfo.Remark;
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
        /// FinancingFeePaymentHistory 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "FinancingFeePaymentHistory_Search";
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
        ///FinancingFeePaymentHistory 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<FinancingFeePaymentHistoryInfo></returns>
        public List<FinancingFeePaymentHistoryInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<FinancingFeePaymentHistoryInfo> list = new List<FinancingFeePaymentHistoryInfo>();
            FinancingFeePaymentHistoryInfo accountInfo = new FinancingFeePaymentHistoryInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = FinancingFeePaymentHistoryInfoRowToInfo(row);
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
        /// <param name="FinancingFeePaymentHistoryDataRow">FinancingFeePaymentHistoryDataRow</param>
        /// <returns>FinancingFeePaymentHistoryInfo</returns>
        internal FinancingFeePaymentHistoryInfo FinancingFeePaymentHistoryInfoRowToInfo(DataRow FinancingFeePaymentHistoryInfoInfoDataRow)
        {
            FinancingFeePaymentHistoryInfo FinancingFeePaymentHistoryInfoInfo = new FinancingFeePaymentHistoryInfo();
            //if (FinancingFeePaymentHistoryInfoInfoDataRow["Id"] != null)
            //{
            //    FinancingFeePaymentHistoryInfoInfo.Id = DataUtil.GetStringValueOfRow(FinancingFeePaymentHistoryInfoInfoDataRow, "Id");
            //}
            //if (FinancingFeePaymentHistoryInfoInfoDataRow["ForId"] != null)
            //{
            //    FinancingFeePaymentHistoryInfoInfo.ForId = DataUtil.GetStringValueOfRow(FinancingFeePaymentHistoryInfoInfoDataRow, "ForId");
            //}
            //if (FinancingFeePaymentHistoryInfoInfoDataRow["OperationerName"] != null)
            //{
            //    FinancingFeePaymentHistoryInfoInfo.OperationerName = DataUtil.GetStringValueOfRow(FinancingFeePaymentHistoryInfoInfoDataRow, "OperationerName");
            //}
            //if (FinancingFeePaymentHistoryInfoInfoDataRow["OperationerAccount"] != null)
            //{
            //    FinancingFeePaymentHistoryInfoInfo.OperationerAccount = DataUtil.GetStringValueOfRow(FinancingFeePaymentHistoryInfoInfoDataRow, "OperationerAccount");
            //}
            //if (FinancingFeePaymentHistoryInfoInfoDataRow["OperationTime"] != null)
            //{
            //    FinancingFeePaymentHistoryInfoInfo.OperationTime = DataUtil.GetStringValueOfRow(FinancingFeePaymentHistoryInfoInfoDataRow, "OperationTime");
            //}
            //if (FinancingFeePaymentHistoryInfoInfoDataRow["OperationType"] != null)
            //{
            //    FinancingFeePaymentHistoryInfoInfo.OperationType = DataUtil.GetStringValueOfRow(FinancingFeePaymentHistoryInfoInfoDataRow, "OperationType");
            //}
            //if (FinancingFeePaymentHistoryInfoInfoDataRow["OperationDesc"] != null)
            //{
            //    FinancingFeePaymentHistoryInfoInfo.OperationDesc = DataUtil.GetStringValueOfRow(FinancingFeePaymentHistoryInfoInfoDataRow, "OperationDesc");
            //}
            //if (FinancingFeePaymentHistoryInfoInfoDataRow["Remark"] != null)
            //{
            //    FinancingFeePaymentHistoryInfoInfo.Remark = DataUtil.GetStringValueOfRow(FinancingFeePaymentHistoryInfoInfoDataRow, "Remark");
            //}

            return FinancingFeePaymentHistoryInfoInfo;
        }
        #endregion
    }
}
