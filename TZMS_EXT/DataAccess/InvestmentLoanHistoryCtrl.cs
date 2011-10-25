//----------------------------------------------------------------------------------------------------
//程序名:	InvestmentLoanHistory 控制类
//功能:  	定义了与 dbo.InvestmentLoanHistory 表 对应的数据访问控制类
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
    /// InvestmentLoanHistoryCtrl
    /// programmer:shunlian
    /// </summary>
    public class InvestmentLoanHistoryCtrl
    {
        #region 构造函数

        /// <summary>
        /// InvestmentLoanHistoryCtrl默认构造函数
        /// </summary>
        public InvestmentLoanHistoryCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.InvestmentLoanHistory一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="InvestmentLoanHistoryInfo">InvestmentLoanHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, InvestmentLoanHistoryInfo InvestmentLoanHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "InvestmentLoanHistory_Add";
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
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.Id;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.ForId;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.OperationerName;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.OperationTime;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.OperationType;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.OperationDesc;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.Remark;
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
        /// dbo.InvestmentLoanHistory删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "InvestmentLoanHistory_Delete";

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
        /// InvestmentLoanHistory 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="InvestmentLoanHistoryInfo">InvestmentLoanHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, InvestmentLoanHistoryInfo InvestmentLoanHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "InvestmentLoanHistory_Update";
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
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.Id;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.ForId;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.OperationerName;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.OperationTime;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.OperationType;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.OperationDesc;
                sqlparam[i++].Value = InvestmentLoanHistoryInfo.Remark;
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
        /// InvestmentLoanHistory 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "InvestmentLoanHistory_Search";
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
        ///InvestmentLoanHistory 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<InvestmentLoanHistoryInfo></returns>
        public List<InvestmentLoanHistoryInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<InvestmentLoanHistoryInfo> list = new List<InvestmentLoanHistoryInfo>();
            InvestmentLoanHistoryInfo accountInfo = new InvestmentLoanHistoryInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = InvestmentLoanHistoryInfoRowToInfo(row);
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
        /// <param name="InvestmentLoanHistoryDataRow">InvestmentLoanHistoryDataRow</param>
        /// <returns>InvestmentLoanHistoryInfo</returns>
        internal InvestmentLoanHistoryInfo InvestmentLoanHistoryInfoRowToInfo(DataRow InvestmentLoanHistoryInfoInfoDataRow)
        {
            InvestmentLoanHistoryInfo InvestmentLoanHistoryInfoInfo = new InvestmentLoanHistoryInfo();
            if (InvestmentLoanHistoryInfoInfoDataRow["Id"] != null)
            {
                InvestmentLoanHistoryInfoInfo.Id = new Guid(DataUtil.GetStringValueOfRow(InvestmentLoanHistoryInfoInfoDataRow, "Id"));
            }
            if (InvestmentLoanHistoryInfoInfoDataRow["ForId"] != null)
            {
                InvestmentLoanHistoryInfoInfo.ForId = new Guid(DataUtil.GetStringValueOfRow(InvestmentLoanHistoryInfoInfoDataRow, "ForId"));
            }
            if (InvestmentLoanHistoryInfoInfoDataRow["OperationerName"] != null)
            {
                InvestmentLoanHistoryInfoInfo.OperationerName = DataUtil.GetStringValueOfRow(InvestmentLoanHistoryInfoInfoDataRow, "OperationerName");
            }
            if (InvestmentLoanHistoryInfoInfoDataRow["OperationerAccount"] != null)
            {
                InvestmentLoanHistoryInfoInfo.OperationerAccount = DataUtil.GetStringValueOfRow(InvestmentLoanHistoryInfoInfoDataRow, "OperationerAccount");
            }
            if (InvestmentLoanHistoryInfoInfoDataRow["OperationTime"] != null)
            {
                InvestmentLoanHistoryInfoInfo.OperationTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InvestmentLoanHistoryInfoInfoDataRow, "OperationTime"));
            }
            if (InvestmentLoanHistoryInfoInfoDataRow["OperationType"] != null)
            {
                InvestmentLoanHistoryInfoInfo.OperationType = DataUtil.GetStringValueOfRow(InvestmentLoanHistoryInfoInfoDataRow, "OperationType");
            }
            if (InvestmentLoanHistoryInfoInfoDataRow["OperationDesc"] != null)
            {
                InvestmentLoanHistoryInfoInfo.OperationDesc = DataUtil.GetStringValueOfRow(InvestmentLoanHistoryInfoInfoDataRow, "OperationDesc");
            }
            if (InvestmentLoanHistoryInfoInfoDataRow["Remark"] != null)
            {
                InvestmentLoanHistoryInfoInfo.Remark = DataUtil.GetStringValueOfRow(InvestmentLoanHistoryInfoInfoDataRow, "Remark");
            }

            return InvestmentLoanHistoryInfoInfo;
        }
        #endregion
    }
}
