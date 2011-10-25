//----------------------------------------------------------------------------------------------------
//程序名:	BankLoanHistory 控制类
//功能:  	定义了与 dbo.BankLoanHistory 表 对应的数据访问控制类
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
    /// BankLoanHistoryCtrl
    /// programmer:shunlian
    /// </summary>
    public class BankLoanHistoryCtrl
    {
        #region 构造函数

        /// <summary>
        /// BankLoanHistoryCtrl默认构造函数
        /// </summary>
        public BankLoanHistoryCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.BankLoanHistory一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BankLoanHistoryInfo">BankLoanHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, BankLoanHistoryInfo BankLoanHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BankLoanHistory_Add";
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
                sqlparam[i++].Value = BankLoanHistoryInfo.Id;
                sqlparam[i++].Value = BankLoanHistoryInfo.ForId;
                sqlparam[i++].Value = BankLoanHistoryInfo.OperationerName;
                sqlparam[i++].Value = BankLoanHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = BankLoanHistoryInfo.OperationTime;
                sqlparam[i++].Value = BankLoanHistoryInfo.OperationType;
                sqlparam[i++].Value = BankLoanHistoryInfo.OperationDesc;
                sqlparam[i++].Value = BankLoanHistoryInfo.Remark;
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
        /// dbo.BankLoanHistory删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "BankLoanHistory_Delete";

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
        /// BankLoanHistory 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BankLoanHistoryInfo">BankLoanHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, BankLoanHistoryInfo BankLoanHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BankLoanHistory_Update";
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
                sqlparam[i++].Value = BankLoanHistoryInfo.Id;
                sqlparam[i++].Value = BankLoanHistoryInfo.ForId;
                sqlparam[i++].Value = BankLoanHistoryInfo.OperationerName;
                sqlparam[i++].Value = BankLoanHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = BankLoanHistoryInfo.OperationTime;
                sqlparam[i++].Value = BankLoanHistoryInfo.OperationType;
                sqlparam[i++].Value = BankLoanHistoryInfo.OperationDesc;
                sqlparam[i++].Value = BankLoanHistoryInfo.Remark;
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
        /// BankLoanHistory 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "BankLoanHistory_Search";
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
        ///BankLoanHistory 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<BankLoanHistoryInfo></returns>
        public List<BankLoanHistoryInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<BankLoanHistoryInfo> list = new List<BankLoanHistoryInfo>();
            BankLoanHistoryInfo accountInfo = new BankLoanHistoryInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = BankLoanHistoryInfoRowToInfo(row);
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
        /// <param name="BankLoanHistoryDataRow">BankLoanHistoryDataRow</param>
        /// <returns>BankLoanHistoryInfo</returns>
        internal BankLoanHistoryInfo BankLoanHistoryInfoRowToInfo(DataRow BankLoanHistoryInfoInfoDataRow)
        {
            BankLoanHistoryInfo BankLoanHistoryInfoInfo = new BankLoanHistoryInfo();
            if (BankLoanHistoryInfoInfoDataRow["Id"] != null)
            {
                BankLoanHistoryInfoInfo.Id =new Guid( DataUtil.GetStringValueOfRow(BankLoanHistoryInfoInfoDataRow, "Id"));
            }
            if (BankLoanHistoryInfoInfoDataRow["ForId"] != null)
            {
                BankLoanHistoryInfoInfo.ForId = new Guid(DataUtil.GetStringValueOfRow(BankLoanHistoryInfoInfoDataRow, "ForId"));
            }
            if (BankLoanHistoryInfoInfoDataRow["OperationerName"] != null)
            {
                BankLoanHistoryInfoInfo.OperationerName = DataUtil.GetStringValueOfRow(BankLoanHistoryInfoInfoDataRow, "OperationerName");
            }
            if (BankLoanHistoryInfoInfoDataRow["OperationerAccount"] != null)
            {
                BankLoanHistoryInfoInfo.OperationerAccount = DataUtil.GetStringValueOfRow(BankLoanHistoryInfoInfoDataRow, "OperationerAccount");
            }
            if (BankLoanHistoryInfoInfoDataRow["OperationTime"] != null)
            {
                BankLoanHistoryInfoInfo.OperationTime =DateTime.Parse( DataUtil.GetStringValueOfRow(BankLoanHistoryInfoInfoDataRow, "OperationTime"));
            }
            if (BankLoanHistoryInfoInfoDataRow["OperationType"] != null)
            {
                BankLoanHistoryInfoInfo.OperationType = DataUtil.GetStringValueOfRow(BankLoanHistoryInfoInfoDataRow, "OperationType");
            }
            if (BankLoanHistoryInfoInfoDataRow["OperationDesc"] != null)
            {
                BankLoanHistoryInfoInfo.OperationDesc = DataUtil.GetStringValueOfRow(BankLoanHistoryInfoInfoDataRow, "OperationDesc");
            }
            if (BankLoanHistoryInfoInfoDataRow["Remark"] != null)
            {
                BankLoanHistoryInfoInfo.Remark = DataUtil.GetStringValueOfRow(BankLoanHistoryInfoInfoDataRow, "Remark");
            }

            return BankLoanHistoryInfoInfo;
        }
        #endregion
    }
}
