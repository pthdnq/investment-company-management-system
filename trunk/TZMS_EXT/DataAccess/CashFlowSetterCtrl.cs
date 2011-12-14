//----------------------------------------------------------------------------------------------------
//???:	CashFlowSetter ???
//??:  	???? dbo.CashFlowSetter ? ??????????
//??:  	
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
    /// CashFlowSetterCtrl
    /// programmer:
    /// </summary>
    public class CashFlowSetterCtrl
    { 
        #region ????
		 
		/// <summary>
        /// CashFlowSetterCtrl??????
        /// </summary>
        public CashFlowSetterCtrl()
        {
            //ToDo
        }
		
		#endregion
        
		#region ???????
		
		/// <summary>
        /// ??dbo.CashFlowSetter????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="CashFlowSetterInfo">CashFlowSetterInfo??</param>
		/// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, CashFlowSetterInfo CashFlowSetterInfo)
        {
            try
            {
				//??????
                string strsql = "CashFlowSetter_Add"; 
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@OriginalAmount",DbType.Guid),
				new SqlParameter("@Status",SqlDbType.TinyInt),
				};
				
				int i=0;
				sqlparam[i++].Value = CashFlowSetterInfo.ObjectId; 
				sqlparam[i++].Value = CashFlowSetterInfo.OriginalAmount; 
				sqlparam[i++].Value = CashFlowSetterInfo.Status; 
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
        /// dbo.CashFlowSetter????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "CashFlowSetter_Delete";

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
        /// CashFlowSetter ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="CashFlowSetterInfo">CashFlowSetterInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, CashFlowSetterInfo CashFlowSetterInfo)
        {
            try
            {
                //??????
                string strsql = "CashFlowSetter_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@OriginalAmount",DbType.Guid),
				new SqlParameter("@Status",SqlDbType.TinyInt),
                };

                int i = 0;
				sqlparam[i++].Value = CashFlowSetterInfo.ObjectId; 
				sqlparam[i++].Value = CashFlowSetterInfo.OriginalAmount; 
				sqlparam[i++].Value = CashFlowSetterInfo.Status; 
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
        /// CashFlowSetter ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName,string condition)
        {
            try
            {
				//??????
                string strsql = "CashFlowSetter_Search";
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
        ///CashFlowSetter ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<CashFlowSetterInfo></returns>
        public List<CashFlowSetterInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<CashFlowSetterInfo> list = new List<CashFlowSetterInfo>();
            CashFlowSetterInfo accountInfo = new CashFlowSetterInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = CashFlowSetterInfoRowToInfo(row);
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
        /// <param name="CashFlowSetterDataRow">CashFlowSetterDataRow</param>
        /// <returns>CashFlowSetterInfo</returns>
        internal CashFlowSetterInfo CashFlowSetterInfoRowToInfo(DataRow CashFlowSetterInfoInfoDataRow)
        {
			CashFlowSetterInfo CashFlowSetterInfoInfo=new CashFlowSetterInfo();
			if(CashFlowSetterInfoInfoDataRow["ObjectId"]!=null)
			{
				CashFlowSetterInfoInfo.ObjectId=new Guid(DataUtil.GetStringValueOfRow(CashFlowSetterInfoInfoDataRow,"ObjectId"));
			}
			if(CashFlowSetterInfoInfoDataRow["OriginalAmount"]!=null)
			{
				CashFlowSetterInfoInfo.OriginalAmount=decimal.Parse( DataUtil.GetStringValueOfRow(CashFlowSetterInfoInfoDataRow,"OriginalAmount"));
			}
			if(CashFlowSetterInfoInfoDataRow["Status"]!=null)
			{
				CashFlowSetterInfoInfo.Status=int.Parse(DataUtil.GetStringValueOfRow(CashFlowSetterInfoInfoDataRow,"Status"));
			}

            return CashFlowSetterInfoInfo;
        }
		#endregion
    }
}
