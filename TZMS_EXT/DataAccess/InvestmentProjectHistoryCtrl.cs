//----------------------------------------------------------------------------------------------------
//程序名:	InvestmentProjectHistory 控制类
//功能:  	定义了与 dbo.InvestmentProjectHistory 表 对应的数据访问控制类
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
    /// InvestmentProjectHistoryCtrl
    /// programmer:shunlian
    /// </summary>
    public class InvestmentProjectHistoryCtrl
    {
        #region 构造函数

        /// <summary>
        /// InvestmentProjectHistoryCtrl默认构造函数
        /// </summary>
        public InvestmentProjectHistoryCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.InvestmentProjectHistory一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="InvestmentProjectHistoryInfo">InvestmentProjectHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, InvestmentProjectHistoryInfo InvestmentProjectHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "InvestmentProjectHistory_Add";
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
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.Id;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.ForId;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.OperationerName;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.OperationTime;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.OperationType;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.OperationDesc;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.Remark;
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
        /// dbo.InvestmentProjectHistory删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "InvestmentProjectHistory_Delete";

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
        /// InvestmentProjectHistory 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="InvestmentProjectHistoryInfo">InvestmentProjectHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, InvestmentProjectHistoryInfo InvestmentProjectHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "InvestmentProjectHistory_Update";
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
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.Id;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.ForId;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.OperationerName;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.OperationTime;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.OperationType;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.OperationDesc;
                sqlparam[i++].Value = InvestmentProjectHistoryInfo.Remark;
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
        /// InvestmentProjectHistory 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "InvestmentProjectHistory_Search";
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
        ///InvestmentProjectHistory 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<InvestmentProjectHistoryInfo></returns>
        public List<InvestmentProjectHistoryInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<InvestmentProjectHistoryInfo> list = new List<InvestmentProjectHistoryInfo>();
            InvestmentProjectHistoryInfo accountInfo = new InvestmentProjectHistoryInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = InvestmentProjectHistoryInfoRowToInfo(row);
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
        /// <param name="InvestmentProjectHistoryDataRow">InvestmentProjectHistoryDataRow</param>
        /// <returns>InvestmentProjectHistoryInfo</returns>
        internal InvestmentProjectHistoryInfo InvestmentProjectHistoryInfoRowToInfo(DataRow InvestmentProjectHistoryInfoInfoDataRow)
        {
            InvestmentProjectHistoryInfo InvestmentProjectHistoryInfoInfo = new InvestmentProjectHistoryInfo();
            //if (InvestmentProjectHistoryInfoInfoDataRow["Id"] != null)
            //{
            //    InvestmentProjectHistoryInfoInfo.Id = DataUtil.GetStringValueOfRow(InvestmentProjectHistoryInfoInfoDataRow, "Id");
            //}
            //if (InvestmentProjectHistoryInfoInfoDataRow["ForId"] != null)
            //{
            //    InvestmentProjectHistoryInfoInfo.ForId = DataUtil.GetStringValueOfRow(InvestmentProjectHistoryInfoInfoDataRow, "ForId");
            //}
            //if (InvestmentProjectHistoryInfoInfoDataRow["OperationerName"] != null)
            //{
            //    InvestmentProjectHistoryInfoInfo.OperationerName = DataUtil.GetStringValueOfRow(InvestmentProjectHistoryInfoInfoDataRow, "OperationerName");
            //}
            //if (InvestmentProjectHistoryInfoInfoDataRow["OperationerAccount"] != null)
            //{
            //    InvestmentProjectHistoryInfoInfo.OperationerAccount = DataUtil.GetStringValueOfRow(InvestmentProjectHistoryInfoInfoDataRow, "OperationerAccount");
            //}
            //if (InvestmentProjectHistoryInfoInfoDataRow["OperationTime"] != null)
            //{
            //    InvestmentProjectHistoryInfoInfo.OperationTime = DataUtil.GetStringValueOfRow(InvestmentProjectHistoryInfoInfoDataRow, "OperationTime");
            //}
            //if (InvestmentProjectHistoryInfoInfoDataRow["OperationType"] != null)
            //{
            //    InvestmentProjectHistoryInfoInfo.OperationType = DataUtil.GetStringValueOfRow(InvestmentProjectHistoryInfoInfoDataRow, "OperationType");
            //}
            //if (InvestmentProjectHistoryInfoInfoDataRow["OperationDesc"] != null)
            //{
            //    InvestmentProjectHistoryInfoInfo.OperationDesc = DataUtil.GetStringValueOfRow(InvestmentProjectHistoryInfoInfoDataRow, "OperationDesc");
            //}
            //if (InvestmentProjectHistoryInfoInfoDataRow["Remark"] != null)
            //{
            //    InvestmentProjectHistoryInfoInfo.Remark = DataUtil.GetStringValueOfRow(InvestmentProjectHistoryInfoInfoDataRow, "Remark");
            //}

            return InvestmentProjectHistoryInfoInfo;
        }
        #endregion
    }
}
