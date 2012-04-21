//----------------------------------------------------------------------------------------------------
//???:	AdminPayment ???
//??:  	???? dbo.AdminPayment ? ??????????
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
    /// AdminPaymentCtrl
    /// programmer:xlli
    /// </summary>
    public class AdminPaymentCtrl
    {
        #region ????

        /// <summary>
        /// AdminPaymentCtrl??????
        /// </summary>
        public AdminPaymentCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.AdminPayment????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="AdminPaymentInfo">AdminPaymentInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, AdminPaymentInfo AdminPaymentInfo)
        {
            try
            {
                //??????
                string strsql = "AdminPayment_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@Company",DbType.String),
				new SqlParameter("@DateFor",DbType.DateTime),
				new SqlParameter("@Cause",DbType.String),
				new SqlParameter("@PaymentType",DbType.String),
				new SqlParameter("@AmountOfPayment",DbType.Guid),
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
                new SqlParameter("@AmountOfPaymentFlag",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = AdminPaymentInfo.ObjectId;
                sqlparam[i++].Value = AdminPaymentInfo.ProjectName;
                sqlparam[i++].Value = AdminPaymentInfo.Company;
                sqlparam[i++].Value = AdminPaymentInfo.DateFor;
                sqlparam[i++].Value = AdminPaymentInfo.Cause;
                sqlparam[i++].Value = AdminPaymentInfo.PaymentType;
                sqlparam[i++].Value = AdminPaymentInfo.AmountOfPayment;
                sqlparam[i++].Value = AdminPaymentInfo.Remark;
                sqlparam[i++].Value = AdminPaymentInfo.AuditOpinion;
                sqlparam[i++].Value = AdminPaymentInfo.AccountingName;
                sqlparam[i++].Value = AdminPaymentInfo.AccountingId;
                sqlparam[i++].Value = AdminPaymentInfo.CreaterId;
                sqlparam[i++].Value = AdminPaymentInfo.CreaterName;
                sqlparam[i++].Value = AdminPaymentInfo.CreateTime;
                sqlparam[i++].Value = AdminPaymentInfo.Status;
                sqlparam[i++].Value = AdminPaymentInfo.NextOperaterId;
                sqlparam[i++].Value = AdminPaymentInfo.NextOperaterName;
                sqlparam[i++].Value = AdminPaymentInfo.NextOperateDesc;
                sqlparam[i++].Value = AdminPaymentInfo.SubmitTime;
                sqlparam[i++].Value = AdminPaymentInfo.Adulters;
                sqlparam[i++].Value = AdminPaymentInfo.AmountOfPaymentFlag;
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
        /// dbo.AdminPayment????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "AdminPayment_Delete";

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
        /// AdminPayment ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="AdminPaymentInfo">AdminPaymentInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, AdminPaymentInfo AdminPaymentInfo)
        {
            try
            {
                //??????
                string strsql = "AdminPayment_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@Company",DbType.String),
				new SqlParameter("@DateFor",DbType.DateTime),
				new SqlParameter("@Cause",DbType.String),
				new SqlParameter("@PaymentType",DbType.String),
				new SqlParameter("@AmountOfPayment",DbType.Guid),
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
                new SqlParameter("@AmountOfPaymentFlag",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = AdminPaymentInfo.ObjectId;
                sqlparam[i++].Value = AdminPaymentInfo.ProjectName;
                sqlparam[i++].Value = AdminPaymentInfo.Company;
                sqlparam[i++].Value = AdminPaymentInfo.DateFor;
                sqlparam[i++].Value = AdminPaymentInfo.Cause;
                sqlparam[i++].Value = AdminPaymentInfo.PaymentType;
                sqlparam[i++].Value = AdminPaymentInfo.AmountOfPayment;
                sqlparam[i++].Value = AdminPaymentInfo.Remark;
                sqlparam[i++].Value = AdminPaymentInfo.AuditOpinion;
                sqlparam[i++].Value = AdminPaymentInfo.AccountingName;
                sqlparam[i++].Value = AdminPaymentInfo.AccountingId;
                sqlparam[i++].Value = AdminPaymentInfo.CreaterId;
                sqlparam[i++].Value = AdminPaymentInfo.CreaterName;
                sqlparam[i++].Value = AdminPaymentInfo.CreateTime;
                sqlparam[i++].Value = AdminPaymentInfo.Status;
                sqlparam[i++].Value = AdminPaymentInfo.NextOperaterId;
                sqlparam[i++].Value = AdminPaymentInfo.NextOperaterName;
                sqlparam[i++].Value = AdminPaymentInfo.NextOperateDesc;
                sqlparam[i++].Value = AdminPaymentInfo.SubmitTime;
                sqlparam[i++].Value = AdminPaymentInfo.Adulters;
                sqlparam[i++].Value = AdminPaymentInfo.AmountOfPaymentFlag;
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
        /// AdminPayment ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "AdminPayment_Search";
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
        ///AdminPayment ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<AdminPaymentInfo></returns>
        public List<AdminPaymentInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<AdminPaymentInfo> list = new List<AdminPaymentInfo>();
            AdminPaymentInfo accountInfo = new AdminPaymentInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = AdminPaymentInfoRowToInfo(row);
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
        /// <param name="AdminPaymentDataRow">AdminPaymentDataRow</param>
        /// <returns>AdminPaymentInfo</returns>
        internal AdminPaymentInfo AdminPaymentInfoRowToInfo(DataRow adminPaymentInfoInfoDataRow)
        {
            AdminPaymentInfo adminPaymentInfoInfo = new AdminPaymentInfo();
            if (adminPaymentInfoInfoDataRow["ObjectId"] != null)
            {
                adminPaymentInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "ObjectId"));
            }
            if (adminPaymentInfoInfoDataRow["ProjectName"] != null)
            {
                adminPaymentInfoInfo.ProjectName = DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "ProjectName");
            }
            if (adminPaymentInfoInfoDataRow["Company"] != null)
            {
                adminPaymentInfoInfo.Company = DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "Company");
            }
            if (adminPaymentInfoInfoDataRow["DateFor"] != null)
            {
                adminPaymentInfoInfo.DateFor = DateTime.Parse(DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "DateFor"));
            }
            if (adminPaymentInfoInfoDataRow["Cause"] != null)
            {
                adminPaymentInfoInfo.Cause = DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "Cause");
            }
            if (adminPaymentInfoInfoDataRow["PaymentType"] != null)
            {
                adminPaymentInfoInfo.PaymentType = DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "PaymentType");
            }
            if (adminPaymentInfoInfoDataRow["AmountOfPayment"] != null)
            {
                adminPaymentInfoInfo.AmountOfPayment = decimal.Parse(DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "AmountOfPayment"));
            }
            if (adminPaymentInfoInfoDataRow["Remark"] != null)
            {
                adminPaymentInfoInfo.Remark = DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "Remark");
            }
            if (adminPaymentInfoInfoDataRow["AuditOpinion"] != null)
            {
                adminPaymentInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "AuditOpinion");
            }
            if (adminPaymentInfoInfoDataRow["AccountingName"] != null)
            {
                adminPaymentInfoInfo.AccountingName = DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "AccountingName");
            }
            if (adminPaymentInfoInfoDataRow["AccountingId"] != null)
            {
                adminPaymentInfoInfo.AccountingId = new Guid(DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "AccountingId"));
            }
            if (adminPaymentInfoInfoDataRow["CreaterId"] != null)
            {
                adminPaymentInfoInfo.CreaterId = new Guid(DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "CreaterId"));
            }
            if (adminPaymentInfoInfoDataRow["CreaterName"] != null)
            {
                adminPaymentInfoInfo.CreaterName = DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "CreaterName");
            }
            if (adminPaymentInfoInfoDataRow["CreateTime"] != null)
            {
                adminPaymentInfoInfo.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "CreateTime"));
            }
            if (adminPaymentInfoInfoDataRow["Status"] != null)
            {
                adminPaymentInfoInfo.Status = int.Parse(DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "Status"));
            }
            if (adminPaymentInfoInfoDataRow["NextOperaterId"] != null)
            {
                adminPaymentInfoInfo.NextOperaterId = new Guid(DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "NextOperaterId"));
            }
            if (adminPaymentInfoInfoDataRow["NextOperaterName"] != null)
            {
                adminPaymentInfoInfo.NextOperaterName = DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "NextOperaterName");
            }
            if (adminPaymentInfoInfoDataRow["NextOperateDesc"] != null)
            {
                adminPaymentInfoInfo.NextOperateDesc = DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "NextOperateDesc");
            }
            if (adminPaymentInfoInfoDataRow["SubmitTime"] != null)
            {
                adminPaymentInfoInfo.SubmitTime = DateTime.Parse(DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "SubmitTime"));
            }
            if (adminPaymentInfoInfoDataRow["Adulters"] != null)
            {
                adminPaymentInfoInfo.Adulters = DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "Adulters");
            }

            if (adminPaymentInfoInfoDataRow["AmountOfPaymentFlag"] != null)
            {
                adminPaymentInfoInfo.AmountOfPaymentFlag = DataUtil.GetStringValueOfRow(adminPaymentInfoInfoDataRow, "AmountOfPaymentFlag");
            }

            return adminPaymentInfoInfo;
        }
        #endregion
    }
}
