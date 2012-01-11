//----------------------------------------------------------------------------------------------------
//???:	AdminReceivablesHistory ???
//??:  	???? dbo.AdminReceivablesHistory ? ??????????
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
    /// AdminReceivablesHistoryCtrl
    /// programmer:xlli
    /// </summary>
    public class AdminReceivablesHistoryCtrl
    {
        #region ????

        /// <summary>
        /// AdminReceivablesHistoryCtrl??????
        /// </summary>
        public AdminReceivablesHistoryCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.AdminReceivablesHistory????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="AdminReceivablesHistoryInfo">AdminReceivablesHistoryInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, AdminReceivablesHistoryInfo AdminReceivablesHistoryInfo)
        {
            try
            {
                //??????
                string strsql = "AdminReceivablesHistory_Add";
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
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.Id;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.ForId;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.OperationerName;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.OperationTime;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.OperationType;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.OperationDesc;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.Remark;
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
        /// dbo.AdminReceivablesHistory????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "AdminReceivablesHistory_Delete";

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
        /// AdminReceivablesHistory ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="AdminReceivablesHistoryInfo">AdminReceivablesHistoryInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, AdminReceivablesHistoryInfo AdminReceivablesHistoryInfo)
        {
            try
            {
                //??????
                string strsql = "AdminReceivablesHistory_Update";
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
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.Id;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.ForId;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.OperationerName;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.OperationTime;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.OperationType;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.OperationDesc;
                sqlparam[i++].Value = AdminReceivablesHistoryInfo.Remark;
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
        /// AdminReceivablesHistory ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "AdminReceivablesHistory_Search";
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
        ///AdminReceivablesHistory ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<AdminReceivablesHistoryInfo></returns>
        public List<AdminReceivablesHistoryInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<AdminReceivablesHistoryInfo> list = new List<AdminReceivablesHistoryInfo>();
            AdminReceivablesHistoryInfo accountInfo = new AdminReceivablesHistoryInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = AdminReceivablesHistoryInfoRowToInfo(row);
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
        /// <param name="AdminReceivablesHistoryDataRow">AdminReceivablesHistoryDataRow</param>
        /// <returns>AdminReceivablesHistoryInfo</returns>
        internal AdminReceivablesHistoryInfo AdminReceivablesHistoryInfoRowToInfo(DataRow adminReceivablesHistoryInfoInfoDataRow)
        {
            AdminReceivablesHistoryInfo adminReceivablesHistoryInfoInfo = new AdminReceivablesHistoryInfo();
            if (adminReceivablesHistoryInfoInfoDataRow["Id"] != null)
            {
                adminReceivablesHistoryInfoInfo.Id = new Guid(DataUtil.GetStringValueOfRow(adminReceivablesHistoryInfoInfoDataRow, "Id"));
            }
            if (adminReceivablesHistoryInfoInfoDataRow["ForId"] != null)
            {
                adminReceivablesHistoryInfoInfo.ForId = new Guid(DataUtil.GetStringValueOfRow(adminReceivablesHistoryInfoInfoDataRow, "ForId"));
            }
            if (adminReceivablesHistoryInfoInfoDataRow["OperationerName"] != null)
            {
                adminReceivablesHistoryInfoInfo.OperationerName = DataUtil.GetStringValueOfRow(adminReceivablesHistoryInfoInfoDataRow, "OperationerName");
            }
            if (adminReceivablesHistoryInfoInfoDataRow["OperationerAccount"] != null)
            {
                adminReceivablesHistoryInfoInfo.OperationerAccount = DataUtil.GetStringValueOfRow(adminReceivablesHistoryInfoInfoDataRow, "OperationerAccount");
            }
            if (adminReceivablesHistoryInfoInfoDataRow["OperationTime"] != null)
            {
                adminReceivablesHistoryInfoInfo.OperationTime = DateTime.Parse(DataUtil.GetStringValueOfRow(adminReceivablesHistoryInfoInfoDataRow, "OperationTime"));
            }
            if (adminReceivablesHistoryInfoInfoDataRow["OperationType"] != null)
            {
                adminReceivablesHistoryInfoInfo.OperationType = DataUtil.GetStringValueOfRow(adminReceivablesHistoryInfoInfoDataRow, "OperationType");
            }
            if (adminReceivablesHistoryInfoInfoDataRow["OperationDesc"] != null)
            {
                adminReceivablesHistoryInfoInfo.OperationDesc = DataUtil.GetStringValueOfRow(adminReceivablesHistoryInfoInfoDataRow, "OperationDesc");
            }
            if (adminReceivablesHistoryInfoInfoDataRow["Remark"] != null)
            {
                adminReceivablesHistoryInfoInfo.Remark = DataUtil.GetStringValueOfRow(adminReceivablesHistoryInfoInfoDataRow, "Remark");
            }

            return adminReceivablesHistoryInfoInfo;
        }
        #endregion
    }
}
