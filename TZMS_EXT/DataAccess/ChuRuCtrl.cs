//----------------------------------------------------------------------------------------------------
//???:	ChuRu ???
//??:  	???? dbo.ChuRu ? ??????????
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
    /// ChuRuCtrl
    /// programmer:
    /// </summary>
    public class ChuRuCtrl
    {
        #region ????

        /// <summary>
        /// ChuRuCtrl??????
        /// </summary>
        public ChuRuCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.ChuRu????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="ChuRuInfo">ChuRuInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, ChuRuInfo ChuRuInfo)
        {
            try
            {
                //??????
                string strsql = "ChuRu_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@OutTime",DbType.DateTime),
				new SqlParameter("@OutReason",DbType.String),
				new SqlParameter("@InTime",DbType.DateTime),
				new SqlParameter("@InUserID",DbType.Guid),
				new SqlParameter("@InUserName",DbType.String),
				new SqlParameter("@InUserJobNo",DbType.String),
				new SqlParameter("@InUserDept",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				};

                int i = 0;
                sqlparam[i++].Value = ChuRuInfo.ObjectID;
                sqlparam[i++].Value = ChuRuInfo.UserID;
                sqlparam[i++].Value = ChuRuInfo.UserName;
                sqlparam[i++].Value = ChuRuInfo.UserJobNo;
                sqlparam[i++].Value = ChuRuInfo.UserDept;
                sqlparam[i++].Value = ChuRuInfo.OutTime;
                sqlparam[i++].Value = ChuRuInfo.OutReason;
                sqlparam[i++].Value = ChuRuInfo.InTime;
                sqlparam[i++].Value = ChuRuInfo.InUserID;
                sqlparam[i++].Value = ChuRuInfo.InUserName;
                sqlparam[i++].Value = ChuRuInfo.InUserJobNo;
                sqlparam[i++].Value = ChuRuInfo.InUserDept;
                sqlparam[i++].Value = ChuRuInfo.State;
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
        /// dbo.ChuRu????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ChuRu_Delete";

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
        /// ChuRu ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="ChuRuInfo">ChuRuInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, ChuRuInfo ChuRuInfo)
        {
            try
            {
                //??????
                string strsql = "ChuRu_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@OutTime",DbType.DateTime),
				new SqlParameter("@OutReason",DbType.String),
				new SqlParameter("@InTime",DbType.DateTime),
				new SqlParameter("@InUserID",DbType.Guid),
				new SqlParameter("@InUserName",DbType.String),
				new SqlParameter("@InUserJobNo",DbType.String),
				new SqlParameter("@InUserDept",DbType.String),
				new SqlParameter("@State",DbType.Int16),
                };

                int i = 0;
                sqlparam[i++].Value = ChuRuInfo.ObjectID;
                sqlparam[i++].Value = ChuRuInfo.UserID;
                sqlparam[i++].Value = ChuRuInfo.UserName;
                sqlparam[i++].Value = ChuRuInfo.UserJobNo;
                sqlparam[i++].Value = ChuRuInfo.UserDept;
                sqlparam[i++].Value = ChuRuInfo.OutTime;
                sqlparam[i++].Value = ChuRuInfo.OutReason;
                sqlparam[i++].Value = ChuRuInfo.InTime;
                sqlparam[i++].Value = ChuRuInfo.InUserID;
                sqlparam[i++].Value = ChuRuInfo.InUserName;
                sqlparam[i++].Value = ChuRuInfo.InUserJobNo;
                sqlparam[i++].Value = ChuRuInfo.InUserDept;
                sqlparam[i++].Value = ChuRuInfo.State;
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
        /// ChuRu ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "ChuRu_Search";
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
        ///ChuRu ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<ChuRuInfo></returns>
        public List<ChuRuInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ChuRuInfo> list = new List<ChuRuInfo>();
            ChuRuInfo accountInfo = new ChuRuInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ChuRuInfoRowToInfo(row);
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
        /// <param name="ChuRuDataRow">ChuRuDataRow</param>
        /// <returns>ChuRuInfo</returns>
        internal ChuRuInfo ChuRuInfoRowToInfo(DataRow ChuRuInfoInfoDataRow)
        {
            ChuRuInfo ChuRuInfoInfo = new ChuRuInfo();
            if (ChuRuInfoInfoDataRow["ObjectID"] != null)
            {
                ChuRuInfoInfo.ObjectID = new Guid(DataUtil.GetStringValueOfRow(ChuRuInfoInfoDataRow, "ObjectID"));
            }
            if (ChuRuInfoInfoDataRow["UserID"] != null)
            {
                ChuRuInfoInfo.UserID = new Guid(DataUtil.GetStringValueOfRow(ChuRuInfoInfoDataRow, "UserID"));
            }
            if (ChuRuInfoInfoDataRow["UserName"] != null)
            {
                ChuRuInfoInfo.UserName = DataUtil.GetStringValueOfRow(ChuRuInfoInfoDataRow, "UserName");
            }
            if (ChuRuInfoInfoDataRow["UserJobNo"] != null)
            {
                ChuRuInfoInfo.UserJobNo = DataUtil.GetStringValueOfRow(ChuRuInfoInfoDataRow, "UserJobNo");
            }
            if (ChuRuInfoInfoDataRow["UserDept"] != null)
            {
                ChuRuInfoInfo.UserDept = DataUtil.GetStringValueOfRow(ChuRuInfoInfoDataRow, "UserDept");
            }
            if (ChuRuInfoInfoDataRow["OutTime"] != null)
            {
                ChuRuInfoInfo.OutTime = DateTime.Parse(DataUtil.GetStringValueOfRow(ChuRuInfoInfoDataRow, "OutTime"));
            }
            if (ChuRuInfoInfoDataRow["OutReason"] != null)
            {
                ChuRuInfoInfo.OutReason = DataUtil.GetStringValueOfRow(ChuRuInfoInfoDataRow, "OutReason");
            }
            if (ChuRuInfoInfoDataRow["InTime"] != null)
            {
                ChuRuInfoInfo.InTime = DateTime.Parse(DataUtil.GetStringValueOfRow(ChuRuInfoInfoDataRow, "InTime"));
            }
            if (ChuRuInfoInfoDataRow["InUserID"] != null)
            {
                ChuRuInfoInfo.InUserID = new Guid(DataUtil.GetStringValueOfRow(ChuRuInfoInfoDataRow, "InUserID"));
            }
            if (ChuRuInfoInfoDataRow["InUserName"] != null)
            {
                ChuRuInfoInfo.InUserName = DataUtil.GetStringValueOfRow(ChuRuInfoInfoDataRow, "InUserName");
            }
            if (ChuRuInfoInfoDataRow["InUserJobNo"] != null)
            {
                ChuRuInfoInfo.InUserJobNo = DataUtil.GetStringValueOfRow(ChuRuInfoInfoDataRow, "InUserJobNo");
            }
            if (ChuRuInfoInfoDataRow["InUserDept"] != null)
            {
                ChuRuInfoInfo.InUserDept = DataUtil.GetStringValueOfRow(ChuRuInfoInfoDataRow, "InUserDept");
            }
            if (ChuRuInfoInfoDataRow["State"] != null)
            {
                ChuRuInfoInfo.State = short.Parse(DataUtil.GetStringValueOfRow(ChuRuInfoInfoDataRow, "State"));
            }

            return ChuRuInfoInfo;
        }
        #endregion
    }
}
