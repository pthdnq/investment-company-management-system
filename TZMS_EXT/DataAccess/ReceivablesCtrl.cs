﻿//----------------------------------------------------------------------------------------------------
//程序名:	Receivables 控制类
//功能:  	定义了与 dbo.Receivables 表 对应的数据访问控制类
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
    /// ReceivablesCtrl
    /// programmer:shunlian
    /// </summary>
    public class ReceivablesCtrl
    {
        #region 构造函数

        /// <summary>
        /// ReceivablesCtrl默认构造函数
        /// </summary>
        public ReceivablesCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.Receivables一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ReceivablesInfo">ReceivablesInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, ReceivablesInfo ReceivablesInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "Receivables_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@DueDateForReceivables",DbType.DateTime),
				new SqlParameter("@DateForReceivables",DbType.DateTime),
				new SqlParameter("@AmountofpaidUp",DbType.Guid),
				new SqlParameter("@ReceivablesAccount",DbType.String),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@IsAccountingAudit",DbType.Boolean),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@AccountingName",DbType.String),
				new SqlParameter("@AccountingAccount",DbType.String),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@Status",DbType.Byte),
                        	new SqlParameter("@Cash",DbType.Decimal),
                                	new SqlParameter("@TransferAccount",DbType.Decimal),
				};

                int i = 0;
                sqlparam[i++].Value = ReceivablesInfo.ObjectId;
                sqlparam[i++].Value = ReceivablesInfo.ForId;
                sqlparam[i++].Value = ReceivablesInfo.ProjectName;
                sqlparam[i++].Value = ReceivablesInfo.DueDateForReceivables;
                sqlparam[i++].Value = ReceivablesInfo.DateForReceivables;
                sqlparam[i++].Value = ReceivablesInfo.AmountofpaidUp;
                sqlparam[i++].Value = ReceivablesInfo.ReceivablesAccount;
                sqlparam[i++].Value = ReceivablesInfo.Remark;
                sqlparam[i++].Value = ReceivablesInfo.IsAccountingAudit;
                sqlparam[i++].Value = ReceivablesInfo.AuditOpinion;
                sqlparam[i++].Value = ReceivablesInfo.AccountingName;
                sqlparam[i++].Value = ReceivablesInfo.AccountingAccount;
                sqlparam[i++].Value = ReceivablesInfo.CreaterId;
                sqlparam[i++].Value = ReceivablesInfo.CreaterName;
                sqlparam[i++].Value = ReceivablesInfo.CreateTime;
                sqlparam[i++].Value = ReceivablesInfo.Status;
                sqlparam[i++].Value = ReceivablesInfo.Cash;
                sqlparam[i++].Value = ReceivablesInfo.TransferAccount;
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
        /// dbo.Receivables删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "Receivables_Delete";

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
        /// Receivables 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ReceivablesInfo">ReceivablesInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, ReceivablesInfo ReceivablesInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "Receivables_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@DueDateForReceivables",DbType.DateTime),
				new SqlParameter("@DateForReceivables",DbType.DateTime),
				new SqlParameter("@AmountofpaidUp",DbType.Guid),
				new SqlParameter("@ReceivablesAccount",DbType.String),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@IsAccountingAudit",DbType.Boolean),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@AccountingName",DbType.String),
				new SqlParameter("@AccountingAccount",DbType.String),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@Status",DbType.Byte),
                        	new SqlParameter("@Cash",DbType.Decimal),
                                	new SqlParameter("@TransferAccount",DbType.Decimal),
                };

                int i = 0;
                sqlparam[i++].Value = ReceivablesInfo.ObjectId;
                sqlparam[i++].Value = ReceivablesInfo.ForId;
                sqlparam[i++].Value = ReceivablesInfo.ProjectName;
                sqlparam[i++].Value = ReceivablesInfo.DueDateForReceivables;
                sqlparam[i++].Value = ReceivablesInfo.DateForReceivables;
                sqlparam[i++].Value = ReceivablesInfo.AmountofpaidUp;
                sqlparam[i++].Value = ReceivablesInfo.ReceivablesAccount;
                sqlparam[i++].Value = ReceivablesInfo.Remark;
                sqlparam[i++].Value = ReceivablesInfo.IsAccountingAudit;
                sqlparam[i++].Value = ReceivablesInfo.AuditOpinion;
                sqlparam[i++].Value = ReceivablesInfo.AccountingName;
                sqlparam[i++].Value = ReceivablesInfo.AccountingAccount;
                sqlparam[i++].Value = ReceivablesInfo.CreaterId;
                sqlparam[i++].Value = ReceivablesInfo.CreaterName;
                sqlparam[i++].Value = ReceivablesInfo.CreateTime;
                sqlparam[i++].Value = ReceivablesInfo.Status;
                sqlparam[i++].Value = ReceivablesInfo.Cash;
                sqlparam[i++].Value = ReceivablesInfo.TransferAccount;
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
        /// Receivables 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "Receivables_Search";
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
        ///Receivables 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<ReceivablesInfo></returns>
        public List<ReceivablesInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ReceivablesInfo> list = new List<ReceivablesInfo>();
            ReceivablesInfo accountInfo = new ReceivablesInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ReceivablesInfoRowToInfo(row);
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
        /// <param name="ReceivablesDataRow">ReceivablesDataRow</param>
        /// <returns>ReceivablesInfo</returns>
        internal ReceivablesInfo ReceivablesInfoRowToInfo(DataRow ReceivablesInfoInfoDataRow)
        {
            ReceivablesInfo ReceivablesInfoInfo = new ReceivablesInfo();
            if (ReceivablesInfoInfoDataRow["ObjectId"] != null)
            {
                ReceivablesInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "ObjectId"));
            }
            if (ReceivablesInfoInfoDataRow["ForId"] != null)
            {
                ReceivablesInfoInfo.ForId = new Guid(DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "ForId"));
            }
            if (ReceivablesInfoInfoDataRow["ProjectName"] != null)
            {
                ReceivablesInfoInfo.ProjectName = DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "ProjectName");
            }
            if (ReceivablesInfoInfoDataRow["DueDateForReceivables"] != null)
            {
                ReceivablesInfoInfo.DueDateForReceivables = DateTime.Parse(DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "DueDateForReceivables"));
            }
            if (ReceivablesInfoInfoDataRow["DateForReceivables"] != null)
            {
                ReceivablesInfoInfo.DateForReceivables = DateTime.Parse(DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "DateForReceivables"));
            }
            if (ReceivablesInfoInfoDataRow["AmountofpaidUp"] != null)
            {
                ReceivablesInfoInfo.AmountofpaidUp = Decimal.Parse(DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "AmountofpaidUp"));
            }
            if (ReceivablesInfoInfoDataRow["ReceivablesAccount"] != null)
            {
                ReceivablesInfoInfo.ReceivablesAccount = DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "ReceivablesAccount");
            }
            if (ReceivablesInfoInfoDataRow["Remark"] != null)
            {
                ReceivablesInfoInfo.Remark = DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "Remark");
            }
            if (ReceivablesInfoInfoDataRow["IsAccountingAudit"] != null)
            {
                ReceivablesInfoInfo.IsAccountingAudit = bool.Parse(ReceivablesInfoInfoDataRow["IsAccountingAudit"].ToString());
            }
            if (ReceivablesInfoInfoDataRow["AuditOpinion"] != null)
            {
                ReceivablesInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "AuditOpinion");
            }
            if (ReceivablesInfoInfoDataRow["AccountingName"] != null)
            {
                ReceivablesInfoInfo.AccountingName = DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "AccountingName");
            }
            if (ReceivablesInfoInfoDataRow["AccountingAccount"] != null)
            {
                ReceivablesInfoInfo.AccountingAccount = DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "AccountingAccount");
            }
            if (ReceivablesInfoInfoDataRow["CreaterId"] != null)
            {
                ReceivablesInfoInfo.CreaterId = new Guid(DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "CreaterId"));
            }
            if (ReceivablesInfoInfoDataRow["CreaterName"] != null)
            {
                ReceivablesInfoInfo.CreaterName = DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "CreaterName");
            }
            if (ReceivablesInfoInfoDataRow["CreateTime"] != null)
            {
                ReceivablesInfoInfo.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "CreateTime"));
            }
            if (ReceivablesInfoInfoDataRow["Status"] != null)
            {
                ReceivablesInfoInfo.Status = int.Parse(DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "Status"));
            }
            if (ReceivablesInfoInfoDataRow["Cash"] != null)
            {
                ReceivablesInfoInfo.Cash = Decimal.Parse(DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "Cash"));
            }
            if (ReceivablesInfoInfoDataRow["TransferAccount"] != null)
            {
                ReceivablesInfoInfo.TransferAccount = Decimal.Parse(DataUtil.GetStringValueOfRow(ReceivablesInfoInfoDataRow, "TransferAccount"));
            }
            return ReceivablesInfoInfo;
        }
        #endregion
    }
}
