//----------------------------------------------------------------------------------------------------
//???:	AdminPaymentHistory ???
//??:  	???? dbo.AdminPaymentHistory ? ??????????
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
    /// AdminPaymentHistoryCtrl
    /// programmer:xlli
    /// </summary>
    public class AdminPaymentHistoryCtrl
    {
        #region ????

        /// <summary>
        /// AdminPaymentHistoryCtrl??????
        /// </summary>
        public AdminPaymentHistoryCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.AdminPaymentHistory????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="AdminPaymentHistoryInfo">AdminPaymentHistoryInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, AdminPaymentHistoryInfo AdminPaymentHistoryInfo)
        {
            try
            {
                //??????
                string strsql = "AdminPaymentHistory_Add";
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
                sqlparam[i++].Value = AdminPaymentHistoryInfo.Id;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.ForId;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.OperationerName;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.OperationTime;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.OperationType;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.OperationDesc;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.Remark;
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
        /// dbo.AdminPaymentHistory????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "AdminPaymentHistory_Delete";

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
        /// AdminPaymentHistory ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="AdminPaymentHistoryInfo">AdminPaymentHistoryInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, AdminPaymentHistoryInfo AdminPaymentHistoryInfo)
        {
            try
            {
                //??????
                string strsql = "AdminPaymentHistory_Update";
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
                sqlparam[i++].Value = AdminPaymentHistoryInfo.Id;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.ForId;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.OperationerName;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.OperationTime;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.OperationType;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.OperationDesc;
                sqlparam[i++].Value = AdminPaymentHistoryInfo.Remark;
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
        /// AdminPaymentHistory ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "AdminPaymentHistory_Search";
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
        ///AdminPaymentHistory ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<AdminPaymentHistoryInfo></returns>
        public List<AdminPaymentHistoryInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<AdminPaymentHistoryInfo> list = new List<AdminPaymentHistoryInfo>();
            AdminPaymentHistoryInfo accountInfo = new AdminPaymentHistoryInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = AdminPaymentHistoryInfoRowToInfo(row);
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
        /// <param name="AdminPaymentHistoryDataRow">AdminPaymentHistoryDataRow</param>
        /// <returns>AdminPaymentHistoryInfo</returns>
        internal AdminPaymentHistoryInfo AdminPaymentHistoryInfoRowToInfo(DataRow adminPaymentHistoryInfoInfoDataRow)
        {
            AdminPaymentHistoryInfo adminPaymentHistoryInfoInfo = new AdminPaymentHistoryInfo();
            if (adminPaymentHistoryInfoInfoDataRow["Id"] != null)
            {
                adminPaymentHistoryInfoInfo.Id = new Guid(DataUtil.GetStringValueOfRow(adminPaymentHistoryInfoInfoDataRow, "Id"));
            }
            if (adminPaymentHistoryInfoInfoDataRow["ForId"] != null)
            {
                adminPaymentHistoryInfoInfo.ForId = new Guid(DataUtil.GetStringValueOfRow(adminPaymentHistoryInfoInfoDataRow, "ForId"));
            }
            if (adminPaymentHistoryInfoInfoDataRow["OperationerName"] != null)
            {
                adminPaymentHistoryInfoInfo.OperationerName = DataUtil.GetStringValueOfRow(adminPaymentHistoryInfoInfoDataRow, "OperationerName");
            }
            if (adminPaymentHistoryInfoInfoDataRow["OperationerAccount"] != null)
            {
                adminPaymentHistoryInfoInfo.OperationerAccount = DataUtil.GetStringValueOfRow(adminPaymentHistoryInfoInfoDataRow, "OperationerAccount");
            }
            if (adminPaymentHistoryInfoInfoDataRow["OperationTime"] != null)
            {
                adminPaymentHistoryInfoInfo.OperationTime = DateTime.Parse(DataUtil.GetStringValueOfRow(adminPaymentHistoryInfoInfoDataRow, "OperationTime"));
            }
            if (adminPaymentHistoryInfoInfoDataRow["OperationType"] != null)
            {
                adminPaymentHistoryInfoInfo.OperationType = DataUtil.GetStringValueOfRow(adminPaymentHistoryInfoInfoDataRow, "OperationType");
            }
            if (adminPaymentHistoryInfoInfoDataRow["OperationDesc"] != null)
            {
                adminPaymentHistoryInfoInfo.OperationDesc = DataUtil.GetStringValueOfRow(adminPaymentHistoryInfoInfoDataRow, "OperationDesc");
            }
            if (adminPaymentHistoryInfoInfoDataRow["Remark"] != null)
            {
                adminPaymentHistoryInfoInfo.Remark = DataUtil.GetStringValueOfRow(adminPaymentHistoryInfoInfoDataRow, "Remark");
            }

            return adminPaymentHistoryInfoInfo;
        }
        #endregion
    }
}
