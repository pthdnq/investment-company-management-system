//----------------------------------------------------------------------------------------------------
//程序名:	CashFlowStatement  控制类
//功能:  	定义了与 dbo.CashFlowStatement  表 对应的数据访问控制类
//作者:  	 
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
    /// CashFlowStatementCtrl
    /// programmer:shunlian
    /// </summary>
    public class CashFlowStatementCtrl
    {
        #region 构造函数

        /// <summary>
        /// CashFlowStatementCtrl默认构造函数
        /// </summary>
        public CashFlowStatementCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.CashFlowStatement一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="CashFlowStatementInfo">CashFlowStatementInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, CashFlowStatementInfo CashFlowStatementInfo)
        {
            try
            {
               

                //存储过程名称
                string strsql = "CashFlowStatement_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
                new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@DateFor",DbType.DateTime),
				new SqlParameter("@Amount",DbType.Decimal),
                new SqlParameter("@RemainingAmount",DbType.Decimal),
				new SqlParameter("@FlowDirection",DbType.String),
				new SqlParameter("@FlowType",DbType.String),
				new SqlParameter("@Receivables",DbType.String),
				new SqlParameter("@Payment",DbType.String),
				new SqlParameter("@IsAccountingAudit",SqlDbType.TinyInt),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@AccountingName",DbType.String),
				new SqlParameter("@AccountingAccount",DbType.String),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@Status",SqlDbType.TinyInt),
				new SqlParameter("@Biz",DbType.String),
				new SqlParameter("@Summary",DbType.String),
				new SqlParameter("@Matter",DbType.String),
				new SqlParameter("@Remark",DbType.String),

                				new SqlParameter("@AmountFlag",DbType.String),
				new SqlParameter("@RemainingAmountFlag",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = CashFlowStatementInfo.ObjectId;
                sqlparam[i++].Value = CashFlowStatementInfo.ProjectName;
                sqlparam[i++].Value = CashFlowStatementInfo.DateFor;
                sqlparam[i++].Value = CashFlowStatementInfo.Amount;
                sqlparam[i++].Value = CashFlowStatementInfo.RemainingAmount;
                sqlparam[i++].Value = CashFlowStatementInfo.FlowDirection;
                sqlparam[i++].Value = CashFlowStatementInfo.FlowType;
                sqlparam[i++].Value = CashFlowStatementInfo.Receivables;
                sqlparam[i++].Value = CashFlowStatementInfo.Payment;
                sqlparam[i++].Value = CashFlowStatementInfo.IsAccountingAudit;
                sqlparam[i++].Value = CashFlowStatementInfo.AuditOpinion;
                sqlparam[i++].Value = CashFlowStatementInfo.AccountingName;
                sqlparam[i++].Value = CashFlowStatementInfo.AccountingAccount;
                sqlparam[i++].Value = CashFlowStatementInfo.CreaterId;
                sqlparam[i++].Value = CashFlowStatementInfo.CreaterName;
                sqlparam[i++].Value = CashFlowStatementInfo.CreateTime;
                sqlparam[i++].Value = CashFlowStatementInfo.Status;
                sqlparam[i++].Value = CashFlowStatementInfo.Biz;
                sqlparam[i++].Value = CashFlowStatementInfo.Summary;
                sqlparam[i++].Value = CashFlowStatementInfo.Matter;
                sqlparam[i++].Value = CashFlowStatementInfo.Remark;

                sqlparam[i++].Value = CashFlowStatementInfo.AmountFlag;
                sqlparam[i++].Value = CashFlowStatementInfo.RemainingAmountFlag;
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
        /// dbo.CashFlowStatement删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "CashFlowStatement_Delete";

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
        /// CashFlowStatement 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="CashFlowStatementInfo">CashFlowStatementInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, CashFlowStatementInfo CashFlowStatementInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "CashFlowStatement_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
                new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@DateFor",DbType.DateTime),
				new SqlParameter("@Amount",DbType.Guid),
                	new SqlParameter("@RemainingAmount",DbType.Guid), 
				new SqlParameter("@FlowDirection",DbType.String),
				new SqlParameter("@FlowType",DbType.String),
				new SqlParameter("@Receivables",DbType.String),
				new SqlParameter("@Payment",DbType.String),
				new SqlParameter("@IsAccountingAudit",SqlDbType.TinyInt),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@AccountingName",DbType.String),
				new SqlParameter("@AccountingAccount",DbType.String),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@Status",SqlDbType.TinyInt),
				new SqlParameter("@Biz",DbType.String),
				new SqlParameter("@Summary",DbType.String),
				new SqlParameter("@Matter",DbType.String),
				new SqlParameter("@Remark",DbType.String),
                new SqlParameter("@AmountFlag",DbType.String),
				new SqlParameter("@RemainingAmountFlag",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = CashFlowStatementInfo.ObjectId;
                sqlparam[i++].Value = CashFlowStatementInfo.ProjectName;
                sqlparam[i++].Value = CashFlowStatementInfo.DateFor;
                sqlparam[i++].Value = CashFlowStatementInfo.Amount;
                sqlparam[i++].Value = CashFlowStatementInfo.RemainingAmount;
                sqlparam[i++].Value = CashFlowStatementInfo.FlowDirection;
                sqlparam[i++].Value = CashFlowStatementInfo.FlowType;
                sqlparam[i++].Value = CashFlowStatementInfo.Receivables;
                sqlparam[i++].Value = CashFlowStatementInfo.Payment;
                sqlparam[i++].Value = CashFlowStatementInfo.IsAccountingAudit;
                sqlparam[i++].Value = CashFlowStatementInfo.AuditOpinion;
                sqlparam[i++].Value = CashFlowStatementInfo.AccountingName;
                sqlparam[i++].Value = CashFlowStatementInfo.AccountingAccount;
                sqlparam[i++].Value = CashFlowStatementInfo.CreaterId;
                sqlparam[i++].Value = CashFlowStatementInfo.CreaterName;
                sqlparam[i++].Value = CashFlowStatementInfo.CreateTime;
                sqlparam[i++].Value = CashFlowStatementInfo.Status;
                sqlparam[i++].Value = CashFlowStatementInfo.Biz;
                sqlparam[i++].Value = CashFlowStatementInfo.Summary;
                sqlparam[i++].Value = CashFlowStatementInfo.Matter;
                sqlparam[i++].Value = CashFlowStatementInfo.Remark;
                sqlparam[i++].Value = CashFlowStatementInfo.AmountFlag;
                sqlparam[i++].Value = CashFlowStatementInfo.RemainingAmountFlag;
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
        /// CashFlowStatement查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "CashFlowStatement_Search";
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
        ///CashFlowStatement 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<CashFlowStatementInfo></returns>
        public List<CashFlowStatementInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<CashFlowStatementInfo> list = new List<CashFlowStatementInfo>();
            CashFlowStatementInfo accountInfo = new CashFlowStatementInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = CashFlowStatementInfoRowToInfo(row);
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
        /// <param name="CashFlowStatementDataRow">CashFlowStatementDataRow</param>
        /// <returns>CashFlowStatementInfo</returns>
        internal CashFlowStatementInfo CashFlowStatementInfoRowToInfo(DataRow CashFlowStatementInfoInfoDataRow)
        {
            CashFlowStatementInfo CashFlowStatementInfoInfo = new CashFlowStatementInfo();
            if (CashFlowStatementInfoInfoDataRow["ObjectId"] != null)
            {
                CashFlowStatementInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "ObjectId"));
            }
            if (CashFlowStatementInfoInfoDataRow["ProjectName"] != null)
            {
                CashFlowStatementInfoInfo.ProjectName = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "ProjectName");
            }
            if (CashFlowStatementInfoInfoDataRow["DateFor"] != null)
            {
                CashFlowStatementInfoInfo.DateFor = DateTime.Parse(DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "DateFor"));
            }
            if (CashFlowStatementInfoInfoDataRow["Amount"] != null)
            {
                CashFlowStatementInfoInfo.Amount = Decimal.Parse(DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "Amount"));
            }
            if (CashFlowStatementInfoInfoDataRow["RemainingAmount"] != null)
            {
                CashFlowStatementInfoInfo.RemainingAmount = Decimal.Parse(DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "RemainingAmount"));
            }
            if (CashFlowStatementInfoInfoDataRow["FlowDirection"] != null)
            {
                CashFlowStatementInfoInfo.FlowDirection = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "FlowDirection");
            }
            if (CashFlowStatementInfoInfoDataRow["FlowType"] != null)
            {
                CashFlowStatementInfoInfo.FlowType = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "FlowType");
            }
            if (CashFlowStatementInfoInfoDataRow["Receivables"] != null)
            {
                CashFlowStatementInfoInfo.Receivables = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "Receivables");
            }
            if (CashFlowStatementInfoInfoDataRow["Payment"] != null)
            {
                CashFlowStatementInfoInfo.Payment = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "Payment");
            }
            if (CashFlowStatementInfoInfoDataRow["IsAccountingAudit"] != null)
            {
                CashFlowStatementInfoInfo.IsAccountingAudit = int.Parse(DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "IsAccountingAudit"));
            }
            if (CashFlowStatementInfoInfoDataRow["AuditOpinion"] != null)
            {
                CashFlowStatementInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "AuditOpinion");
            }
            if (CashFlowStatementInfoInfoDataRow["AccountingName"] != null)
            {
                CashFlowStatementInfoInfo.AccountingName = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "AccountingName");
            }
            if (CashFlowStatementInfoInfoDataRow["AccountingAccount"] != null)
            {
                CashFlowStatementInfoInfo.AccountingAccount = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "AccountingAccount");
            }
            if (CashFlowStatementInfoInfoDataRow["CreaterId"] != null)
            {
                CashFlowStatementInfoInfo.CreaterId = new Guid(DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "CreaterId"));
            }
            if (CashFlowStatementInfoInfoDataRow["CreaterName"] != null)
            {
                CashFlowStatementInfoInfo.CreaterName = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "CreaterName");
            }
            if (CashFlowStatementInfoInfoDataRow["CreateTime"] != null)
            {
                CashFlowStatementInfoInfo.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "CreateTime"));
            }
            if (CashFlowStatementInfoInfoDataRow["Status"] != null)
            {
                CashFlowStatementInfoInfo.Status = int.Parse(DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "Status"));
            }
            if (CashFlowStatementInfoInfoDataRow["Biz"] != null)
            {
                CashFlowStatementInfoInfo.Biz = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "Biz");
            }
            if (CashFlowStatementInfoInfoDataRow["Summary"] != null)
            {
                CashFlowStatementInfoInfo.Summary = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "Summary");
            }
            if (CashFlowStatementInfoInfoDataRow["Matter"] != null)
            {
                CashFlowStatementInfoInfo.Matter = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "Matter");
            }
            if (CashFlowStatementInfoInfoDataRow["Remark"] != null)
            {
                CashFlowStatementInfoInfo.Remark = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "Remark");
            }

            if (CashFlowStatementInfoInfoDataRow["AmountFlag"] != null)
            {
                CashFlowStatementInfoInfo.AmountFlag = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "AmountFlag");
            }
            if (CashFlowStatementInfoInfoDataRow["RemainingAmountFlag"] != null)
            {
                CashFlowStatementInfoInfo.RemainingAmountFlag = DataUtil.GetStringValueOfRow(CashFlowStatementInfoInfoDataRow, "RemainingAmountFlag");
            }

            return CashFlowStatementInfoInfo;
        }
        #endregion
    }
}
