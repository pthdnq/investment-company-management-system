//----------------------------------------------------------------------------------------------------
//???:	AdminImprestHistory ???
//??:  	???? dbo.AdminImprestHistory ? ??????????
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
    /// AdminImprestHistoryCtrl
    /// programmer:xlli
    /// </summary>
    public class AdminImprestHistoryCtrl
    { 
        #region ????
		 
		/// <summary>
        /// AdminImprestHistoryCtrl??????
        /// </summary>
        public AdminImprestHistoryCtrl()
        {
            //ToDo
        }
		
		#endregion
        
		#region ???????
		
		/// <summary>
        /// ??dbo.AdminImprestHistory????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="AdminImprestHistoryInfo">AdminImprestHistoryInfo??</param>
		/// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, AdminImprestHistoryInfo AdminImprestHistoryInfo)
        {
            try
            {
				//??????
                string strsql = "AdminImprestHistory_Add"; 
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
				
				int i=0;
				sqlparam[i++].Value = AdminImprestHistoryInfo.Id; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.ForId; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.OperationerName; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.OperationerAccount; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.OperationTime; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.OperationType; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.OperationDesc; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.Remark; 
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
        /// dbo.AdminImprestHistory????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "AdminImprestHistory_Delete";

                SqlParameter[] sqlparam =
				{
					new SqlParameter ( "@ObjectID", SqlDbType.NVarChar )
				};
                int i = 0; 
                sqlparam[i++].Value =  objectID ; 

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
        /// AdminImprestHistory ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="AdminImprestHistoryInfo">AdminImprestHistoryInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, AdminImprestHistoryInfo AdminImprestHistoryInfo)
        {
            try
            {
                //??????
                string strsql = "AdminImprestHistory_Update";
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
				sqlparam[i++].Value = AdminImprestHistoryInfo.Id; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.ForId; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.OperationerName; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.OperationerAccount; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.OperationTime; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.OperationType; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.OperationDesc; 
				sqlparam[i++].Value = AdminImprestHistoryInfo.Remark; 
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
        /// AdminImprestHistory ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName,string condition)
        {
            try
            {
				//??????
                string strsql = "AdminImprestHistory_Search";
				SqlParameter[] sqlparam =
                {
					new SqlParameter("@Condition",SqlDbType.NVarChar), 
                };

                int i = 0;
				sqlparam[i++].Value =condition;
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
        ///AdminImprestHistory ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<AdminImprestHistoryInfo></returns>
        public List<AdminImprestHistoryInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<AdminImprestHistoryInfo> list = new List<AdminImprestHistoryInfo>();
            AdminImprestHistoryInfo accountInfo = new AdminImprestHistoryInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = AdminImprestHistoryInfoRowToInfo(row);
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
        /// <param name="AdminImprestHistoryDataRow">AdminImprestHistoryDataRow</param>
        /// <returns>AdminImprestHistoryInfo</returns>
        internal AdminImprestHistoryInfo AdminImprestHistoryInfoRowToInfo(DataRow adminImprestHistoryInfoInfoDataRow)
        {
			AdminImprestHistoryInfo adminImprestHistoryInfoInfo=new AdminImprestHistoryInfo();
			if(adminImprestHistoryInfoInfoDataRow["Id"]!=null)
			{
				adminImprestHistoryInfoInfo.Id=new Guid(DataUtil.GetStringValueOfRow(adminImprestHistoryInfoInfoDataRow,"Id"));
			}
			if(adminImprestHistoryInfoInfoDataRow["ForId"]!=null)
			{
                adminImprestHistoryInfoInfo.ForId = new Guid(DataUtil.GetStringValueOfRow(adminImprestHistoryInfoInfoDataRow, "ForId"));
			}
			if(adminImprestHistoryInfoInfoDataRow["OperationerName"]!=null)
			{
				adminImprestHistoryInfoInfo.OperationerName=DataUtil.GetStringValueOfRow(adminImprestHistoryInfoInfoDataRow,"OperationerName");
			}
			if(adminImprestHistoryInfoInfoDataRow["OperationerAccount"]!=null)
			{
				adminImprestHistoryInfoInfo.OperationerAccount=DataUtil.GetStringValueOfRow(adminImprestHistoryInfoInfoDataRow,"OperationerAccount");
			}
			if(adminImprestHistoryInfoInfoDataRow["OperationTime"]!=null)
			{
				adminImprestHistoryInfoInfo.OperationTime=DateTime.Parse( DataUtil.GetStringValueOfRow(adminImprestHistoryInfoInfoDataRow,"OperationTime"));
			}
			if(adminImprestHistoryInfoInfoDataRow["OperationType"]!=null)
			{
				adminImprestHistoryInfoInfo.OperationType=DataUtil.GetStringValueOfRow(adminImprestHistoryInfoInfoDataRow,"OperationType");
			}
			if(adminImprestHistoryInfoInfoDataRow["OperationDesc"]!=null)
			{
				adminImprestHistoryInfoInfo.OperationDesc=DataUtil.GetStringValueOfRow(adminImprestHistoryInfoInfoDataRow,"OperationDesc");
			}
			if(adminImprestHistoryInfoInfoDataRow["Remark"]!=null)
			{
				adminImprestHistoryInfoInfo.Remark=DataUtil.GetStringValueOfRow(adminImprestHistoryInfoInfoDataRow,"Remark");
			}

            return adminImprestHistoryInfoInfo;
        }
		#endregion
    }
}
