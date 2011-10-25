//----------------------------------------------------------------------------------------------------
//程序名:	BankLoanProjectProcessHistory 控制类
//功能:  	定义了与 dbo.BankLoanProjectProcessHistory 表 对应的数据访问控制类
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
    /// BankLoanProjectProcessHistoryCtrl
    /// programmer:shunlian
    /// </summary>
    public class BankLoanProjectProcessHistoryCtrl
    {
        #region 构造函数

        /// <summary>
        /// BankLoanProjectProcessHistoryCtrl默认构造函数
        /// </summary>
        public BankLoanProjectProcessHistoryCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.BankLoanProjectProcessHistory一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BankLoanProjectProcessHistoryInfo">BankLoanProjectProcessHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, BankLoanProjectProcessHistoryInfo BankLoanProjectProcessHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BankLoanProjectProcessHistory_Add";
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
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.Id;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.ForId;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.OperationerName;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.OperationTime;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.OperationType;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.OperationDesc;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.Remark;
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
        /// dbo.BankLoanProjectProcessHistory删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "BankLoanProjectProcessHistory_Delete";

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
        /// BankLoanProjectProcessHistory 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BankLoanProjectProcessHistoryInfo">BankLoanProjectProcessHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, BankLoanProjectProcessHistoryInfo BankLoanProjectProcessHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BankLoanProjectProcessHistory_Update";
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
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.Id;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.ForId;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.OperationerName;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.OperationTime;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.OperationType;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.OperationDesc;
                sqlparam[i++].Value = BankLoanProjectProcessHistoryInfo.Remark;
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
        /// BankLoanProjectProcessHistory 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "BankLoanProjectProcessHistory_Search";
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
        ///BankLoanProjectProcessHistory 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<BankLoanProjectProcessHistoryInfo></returns>
        public List<BankLoanProjectProcessHistoryInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<BankLoanProjectProcessHistoryInfo> list = new List<BankLoanProjectProcessHistoryInfo>();
            BankLoanProjectProcessHistoryInfo accountInfo = new BankLoanProjectProcessHistoryInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = BankLoanProjectProcessHistoryInfoRowToInfo(row);
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
        /// <param name="BankLoanProjectProcessHistoryDataRow">BankLoanProjectProcessHistoryDataRow</param>
        /// <returns>BankLoanProjectProcessHistoryInfo</returns>
        internal BankLoanProjectProcessHistoryInfo BankLoanProjectProcessHistoryInfoRowToInfo(DataRow BankLoanProjectProcessHistoryInfoInfoDataRow)
        {
            BankLoanProjectProcessHistoryInfo BankLoanProjectProcessHistoryInfoInfo = new BankLoanProjectProcessHistoryInfo();
            //if (BankLoanProjectProcessHistoryInfoInfoDataRow["Id"] != null)
            //{
            //    BankLoanProjectProcessHistoryInfoInfo.Id = DataUtil.GetStringValueOfRow(BankLoanProjectProcessHistoryInfoInfoDataRow, "Id");
            //}
            //if (BankLoanProjectProcessHistoryInfoInfoDataRow["ForId"] != null)
            //{
            //    BankLoanProjectProcessHistoryInfoInfo.ForId = DataUtil.GetStringValueOfRow(BankLoanProjectProcessHistoryInfoInfoDataRow, "ForId");
            //}
            //if (BankLoanProjectProcessHistoryInfoInfoDataRow["OperationerName"] != null)
            //{
            //    BankLoanProjectProcessHistoryInfoInfo.OperationerName = DataUtil.GetStringValueOfRow(BankLoanProjectProcessHistoryInfoInfoDataRow, "OperationerName");
            //}
            //if (BankLoanProjectProcessHistoryInfoInfoDataRow["OperationerAccount"] != null)
            //{
            //    BankLoanProjectProcessHistoryInfoInfo.OperationerAccount = DataUtil.GetStringValueOfRow(BankLoanProjectProcessHistoryInfoInfoDataRow, "OperationerAccount");
            //}
            //if (BankLoanProjectProcessHistoryInfoInfoDataRow["OperationTime"] != null)
            //{
            //    BankLoanProjectProcessHistoryInfoInfo.OperationTime = DataUtil.GetStringValueOfRow(BankLoanProjectProcessHistoryInfoInfoDataRow, "OperationTime");
            //}
            //if (BankLoanProjectProcessHistoryInfoInfoDataRow["OperationType"] != null)
            //{
            //    BankLoanProjectProcessHistoryInfoInfo.OperationType = DataUtil.GetStringValueOfRow(BankLoanProjectProcessHistoryInfoInfoDataRow, "OperationType");
            //}
            //if (BankLoanProjectProcessHistoryInfoInfoDataRow["OperationDesc"] != null)
            //{
            //    BankLoanProjectProcessHistoryInfoInfo.OperationDesc = DataUtil.GetStringValueOfRow(BankLoanProjectProcessHistoryInfoInfoDataRow, "OperationDesc");
            //}
            //if (BankLoanProjectProcessHistoryInfoInfoDataRow["Remark"] != null)
            //{
            //    BankLoanProjectProcessHistoryInfoInfo.Remark = DataUtil.GetStringValueOfRow(BankLoanProjectProcessHistoryInfoInfoDataRow, "Remark");
            //}

            return BankLoanProjectProcessHistoryInfoInfo;
        }
        #endregion
    }
}
