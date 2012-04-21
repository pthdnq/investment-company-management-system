//----------------------------------------------------------------------------------------------------
//???:	AdminReceivables ???
//??:  	???? dbo.AdminReceivables ? ??????????
//??:  	xlli
//??:	2011-10-26 
//----------------------------------------------------------------------------------------------------
//????:
// ??		            ???		     ????
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
    /// AdminReceivablesCtrl
    /// programmer:xlli
    /// </summary>
    public class AdminReceivablesCtrl
    {
        #region ????

        /// <summary>
        /// AdminReceivablesCtrl??????
        /// </summary>
        public AdminReceivablesCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.AdminReceivables????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="AdminReceivablesInfo">AdminReceivablesInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, AdminReceivablesInfo AdminReceivablesInfo)
        {
            try
            {
                //??????
                string strsql = "AdminReceivables_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@Company",DbType.String),
				new SqlParameter("@DateFor",DbType.DateTime),
				new SqlParameter("@Cause",DbType.String),
				new SqlParameter("@AmountOfReceivables",DbType.Guid),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@AccountingName",DbType.String),
				new SqlParameter("@AccountingId",DbType.Guid),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@Status",SqlDbType.TinyInt),
				new SqlParameter("@NextOperaterId",DbType.Guid),
				new SqlParameter("@NextOperaterName",DbType.String),
				new SqlParameter("@NextOperateDesc",DbType.String),
				new SqlParameter("@SubmitTime",DbType.DateTime),
				new SqlParameter("@Adulters",DbType.String),
                new SqlParameter("@AmountOfReceivablesFlag",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = AdminReceivablesInfo.ObjectId;
                sqlparam[i++].Value = AdminReceivablesInfo.ProjectName;
                sqlparam[i++].Value = AdminReceivablesInfo.Company;
                sqlparam[i++].Value = AdminReceivablesInfo.DateFor;
                sqlparam[i++].Value = AdminReceivablesInfo.Cause;
                sqlparam[i++].Value = AdminReceivablesInfo.AmountOfReceivables;
                sqlparam[i++].Value = AdminReceivablesInfo.Remark;
                sqlparam[i++].Value = AdminReceivablesInfo.AuditOpinion;
                sqlparam[i++].Value = AdminReceivablesInfo.AccountingName;
                sqlparam[i++].Value = AdminReceivablesInfo.AccountingId;
                sqlparam[i++].Value = AdminReceivablesInfo.CreaterId;
                sqlparam[i++].Value = AdminReceivablesInfo.CreaterName;
                sqlparam[i++].Value = AdminReceivablesInfo.CreateTime;
                sqlparam[i++].Value = AdminReceivablesInfo.Status;
                sqlparam[i++].Value = AdminReceivablesInfo.NextOperaterId;
                sqlparam[i++].Value = AdminReceivablesInfo.NextOperaterName;
                sqlparam[i++].Value = AdminReceivablesInfo.NextOperateDesc;
                sqlparam[i++].Value = AdminReceivablesInfo.SubmitTime;
                sqlparam[i++].Value = AdminReceivablesInfo.Adulters;
                sqlparam[i++].Value = AdminReceivablesInfo.AmountOfReceivablesFlag;
                SqlDBAccess dbaccess = new SqlDBAccess();
                //??????
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
        /// dbo.AdminReceivables????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "AdminReceivables_Delete";

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
        /// AdminReceivables ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="AdminReceivablesInfo">AdminReceivablesInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, AdminReceivablesInfo AdminReceivablesInfo)
        {
            try
            {
                //??????
                string strsql = "AdminReceivables_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@Company",DbType.String),
				new SqlParameter("@DateFor",DbType.DateTime),
				new SqlParameter("@Cause",DbType.String),
				new SqlParameter("@AmountOfReceivables",DbType.Guid),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@AccountingName",DbType.String),
				new SqlParameter("@AccountingId",DbType.Guid),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@Status",SqlDbType.TinyInt),
				new SqlParameter("@NextOperaterId",DbType.Guid),
				new SqlParameter("@NextOperaterName",DbType.String),
				new SqlParameter("@NextOperateDesc",DbType.String),
				new SqlParameter("@SubmitTime",DbType.DateTime),
				new SqlParameter("@Adulters",DbType.String),
                new SqlParameter("@AmountOfReceivablesFlag",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = AdminReceivablesInfo.ObjectId;
                sqlparam[i++].Value = AdminReceivablesInfo.ProjectName;
                sqlparam[i++].Value = AdminReceivablesInfo.Company;
                sqlparam[i++].Value = AdminReceivablesInfo.DateFor;
                sqlparam[i++].Value = AdminReceivablesInfo.Cause;
                sqlparam[i++].Value = AdminReceivablesInfo.AmountOfReceivables;
                sqlparam[i++].Value = AdminReceivablesInfo.Remark;
                sqlparam[i++].Value = AdminReceivablesInfo.AuditOpinion;
                sqlparam[i++].Value = AdminReceivablesInfo.AccountingName;
                sqlparam[i++].Value = AdminReceivablesInfo.AccountingId;
                sqlparam[i++].Value = AdminReceivablesInfo.CreaterId;
                sqlparam[i++].Value = AdminReceivablesInfo.CreaterName;
                sqlparam[i++].Value = AdminReceivablesInfo.CreateTime;
                sqlparam[i++].Value = AdminReceivablesInfo.Status;
                sqlparam[i++].Value = AdminReceivablesInfo.NextOperaterId;
                sqlparam[i++].Value = AdminReceivablesInfo.NextOperaterName;
                sqlparam[i++].Value = AdminReceivablesInfo.NextOperateDesc;
                sqlparam[i++].Value = AdminReceivablesInfo.SubmitTime;
                sqlparam[i++].Value = AdminReceivablesInfo.Adulters;
                sqlparam[i++].Value = AdminReceivablesInfo.AmountOfReceivablesFlag;
                SqlDBAccess dbaccess = new SqlDBAccess();
                //??????
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
        /// AdminReceivables ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "AdminReceivables_Search";
                SqlParameter[] sqlparam =
                {
					new SqlParameter("@Condition",SqlDbType.NVarChar), 
                };

                int i = 0;
                sqlparam[i++].Value = condition;
                SqlDBAccess dbaccess = new SqlDBAccess();
                //??????
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
        ///AdminReceivables ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<AdminReceivablesInfo></returns>
        public List<AdminReceivablesInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<AdminReceivablesInfo> list = new List<AdminReceivablesInfo>();
            AdminReceivablesInfo accountInfo = new AdminReceivablesInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = AdminReceivablesInfoRowToInfo(row);
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
        /// <param name="AdminReceivablesDataRow">AdminReceivablesDataRow</param>
        /// <returns>AdminReceivablesInfo</returns>
        internal AdminReceivablesInfo AdminReceivablesInfoRowToInfo(DataRow adminReceivablesInfoInfoDataRow)
        {
            AdminReceivablesInfo adminReceivablesInfoInfo = new AdminReceivablesInfo();
            if (adminReceivablesInfoInfoDataRow["ObjectId"] != null)
            {
                adminReceivablesInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "ObjectId"));
            }
            if (adminReceivablesInfoInfoDataRow["ProjectName"] != null)
            {
                adminReceivablesInfoInfo.ProjectName = DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "ProjectName");
            }
            if (adminReceivablesInfoInfoDataRow["Company"] != null)
            {
                adminReceivablesInfoInfo.Company = DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "Company");
            }
            if (adminReceivablesInfoInfoDataRow["DateFor"] != null)
            {
                adminReceivablesInfoInfo.DateFor = DateTime.Parse(DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "DateFor"));
            }
            if (adminReceivablesInfoInfoDataRow["Cause"] != null)
            {
                adminReceivablesInfoInfo.Cause = DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "Cause");
            }
            if (adminReceivablesInfoInfoDataRow["AmountOfReceivables"] != null)
            {
                adminReceivablesInfoInfo.AmountOfReceivables = decimal.Parse(DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "AmountOfReceivables"));
            }
            if (adminReceivablesInfoInfoDataRow["Remark"] != null)
            {
                adminReceivablesInfoInfo.Remark = DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "Remark");
            }
            if (adminReceivablesInfoInfoDataRow["AuditOpinion"] != null)
            {
                adminReceivablesInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "AuditOpinion");
            }
            if (adminReceivablesInfoInfoDataRow["AccountingName"] != null)
            {
                adminReceivablesInfoInfo.AccountingName = DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "AccountingName");
            }
            if (adminReceivablesInfoInfoDataRow["AccountingId"] != null)
            {
                adminReceivablesInfoInfo.AccountingId = new Guid(DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "AccountingId"));
            }
            if (adminReceivablesInfoInfoDataRow["CreaterId"] != null)
            {
                adminReceivablesInfoInfo.CreaterId = new Guid(DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "CreaterId"));
            }
            if (adminReceivablesInfoInfoDataRow["CreaterName"] != null)
            {
                adminReceivablesInfoInfo.CreaterName = DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "CreaterName");
            }
            if (adminReceivablesInfoInfoDataRow["CreateTime"] != null)
            {
                adminReceivablesInfoInfo.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "CreateTime"));
            }
            if (adminReceivablesInfoInfoDataRow["Status"] != null)
            {
                adminReceivablesInfoInfo.Status = int.Parse(DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "Status"));
            }
            if (adminReceivablesInfoInfoDataRow["NextOperaterId"] != null)
            {
                adminReceivablesInfoInfo.NextOperaterId = new Guid(DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "NextOperaterId"));
            }
            if (adminReceivablesInfoInfoDataRow["NextOperaterName"] != null)
            {
                adminReceivablesInfoInfo.NextOperaterName = DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "NextOperaterName");
            }
            if (adminReceivablesInfoInfoDataRow["NextOperateDesc"] != null)
            {
                adminReceivablesInfoInfo.NextOperateDesc = DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "NextOperateDesc");
            }
            if (adminReceivablesInfoInfoDataRow["SubmitTime"] != null)
            {
                adminReceivablesInfoInfo.SubmitTime = DateTime.Parse(DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "SubmitTime"));
            }
            if (adminReceivablesInfoInfoDataRow["Adulters"] != null)
            {
                adminReceivablesInfoInfo.Adulters = DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "Adulters");
            }

            if (adminReceivablesInfoInfoDataRow["AmountOfReceivablesFlag"] != null)
            {
                adminReceivablesInfoInfo.AmountOfReceivablesFlag = DataUtil.GetStringValueOfRow(adminReceivablesInfoInfoDataRow, "AmountOfReceivablesFlag");
            }
            return adminReceivablesInfoInfo;
        }
        #endregion
    }
}
