//----------------------------------------------------------------------------------------------------
//???:	ProxyAmountUnit ???
//??:  	???? dbo.ProxyAmountUnit ? ??????????
//??:  	xiguazerg
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
    /// ProxyAmountUnitCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class ProxyAmountUnitCtrl
    {
        #region ????

        /// <summary>
        /// ProxyAmountUnitCtrl??????
        /// </summary>
        public ProxyAmountUnitCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.ProxyAmountUnit????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="ProxyAmountUnitInfo">ProxyAmountUnitInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, ProxyAmountUnitInfo ProxyAmountUnitInfo)
        {
            try
            {
                //??????
                string strsql = "ProxyAmountUnit_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UnitName",DbType.String),
				new SqlParameter("@UnitAddress",DbType.String),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@SMDJNumber",DbType.String),
				new SqlParameter("@DSNumber",DbType.String),
				new SqlParameter("@FRSFZNumber",DbType.String),
				new SqlParameter("@KHHJAccountNo",DbType.String),
				new SqlParameter("@ContactPhoneNumber",DbType.String),
				new SqlParameter("@GSManager",DbType.String),
				new SqlParameter("@DSManager",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@IsDelete",DbType.Boolean),
				};

                int i = 0;
                sqlparam[i++].Value = ProxyAmountUnitInfo.ObjectID;
                sqlparam[i++].Value = ProxyAmountUnitInfo.UnitName;
                sqlparam[i++].Value = ProxyAmountUnitInfo.UnitAddress;
                sqlparam[i++].Value = ProxyAmountUnitInfo.UserID;
                sqlparam[i++].Value = ProxyAmountUnitInfo.UserName;
                sqlparam[i++].Value = ProxyAmountUnitInfo.UserDept;
                sqlparam[i++].Value = ProxyAmountUnitInfo.SMDJNumber;
                sqlparam[i++].Value = ProxyAmountUnitInfo.DSNumber;
                sqlparam[i++].Value = ProxyAmountUnitInfo.FRSFZNumber;
                sqlparam[i++].Value = ProxyAmountUnitInfo.KHHJAccountNo;
                sqlparam[i++].Value = ProxyAmountUnitInfo.ContactPhoneNumber;
                sqlparam[i++].Value = ProxyAmountUnitInfo.GSManager;
                sqlparam[i++].Value = ProxyAmountUnitInfo.DSManager;
                sqlparam[i++].Value = ProxyAmountUnitInfo.Other;
                sqlparam[i++].Value = ProxyAmountUnitInfo.IsDelete;
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
        /// dbo.ProxyAmountUnit????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ProxyAmountUnit_Delete";

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
        /// ProxyAmountUnit ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="ProxyAmountUnitInfo">ProxyAmountUnitInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, ProxyAmountUnitInfo ProxyAmountUnitInfo)
        {
            try
            {
                //??????
                string strsql = "ProxyAmountUnit_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UnitName",DbType.String),
				new SqlParameter("@UnitAddress",DbType.String),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@SMDJNumber",DbType.String),
				new SqlParameter("@DSNumber",DbType.String),
				new SqlParameter("@FRSFZNumber",DbType.String),
				new SqlParameter("@KHHJAccountNo",DbType.String),
				new SqlParameter("@ContactPhoneNumber",DbType.String),
				new SqlParameter("@GSManager",DbType.String),
				new SqlParameter("@DSManager",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@IsDelete",DbType.Boolean),
                };

                int i = 0;
                sqlparam[i++].Value = ProxyAmountUnitInfo.ObjectID;
                sqlparam[i++].Value = ProxyAmountUnitInfo.UnitName;
                sqlparam[i++].Value = ProxyAmountUnitInfo.UnitAddress;
                sqlparam[i++].Value = ProxyAmountUnitInfo.UserID;
                sqlparam[i++].Value = ProxyAmountUnitInfo.UserName;
                sqlparam[i++].Value = ProxyAmountUnitInfo.UserDept;
                sqlparam[i++].Value = ProxyAmountUnitInfo.SMDJNumber;
                sqlparam[i++].Value = ProxyAmountUnitInfo.DSNumber;
                sqlparam[i++].Value = ProxyAmountUnitInfo.FRSFZNumber;
                sqlparam[i++].Value = ProxyAmountUnitInfo.KHHJAccountNo;
                sqlparam[i++].Value = ProxyAmountUnitInfo.ContactPhoneNumber;
                sqlparam[i++].Value = ProxyAmountUnitInfo.GSManager;
                sqlparam[i++].Value = ProxyAmountUnitInfo.DSManager;
                sqlparam[i++].Value = ProxyAmountUnitInfo.Other;
                sqlparam[i++].Value = ProxyAmountUnitInfo.IsDelete;
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
        /// ProxyAmountUnit ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "ProxyAmountUnit_Search";
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
        ///ProxyAmountUnit ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<ProxyAmountUnitInfo></returns>
        public List<ProxyAmountUnitInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ProxyAmountUnitInfo> list = new List<ProxyAmountUnitInfo>();
            ProxyAmountUnitInfo accountInfo = new ProxyAmountUnitInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ProxyAmountUnitInfoRowToInfo(row);
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
        /// <param name="ProxyAmountUnitDataRow">ProxyAmountUnitDataRow</param>
        /// <returns>ProxyAmountUnitInfo</returns>
        internal ProxyAmountUnitInfo ProxyAmountUnitInfoRowToInfo(DataRow ProxyAmountUnitnfoInfoDataRow)
        {
            ProxyAmountUnitInfo ProxyAmountUnitnfoInfo = new ProxyAmountUnitInfo();
            if (ProxyAmountUnitnfoInfoDataRow["ObjectID"] != null)
            {
                ProxyAmountUnitnfoInfo.ObjectID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "ObjectID"));
            }
            if (ProxyAmountUnitnfoInfoDataRow["UnitName"] != null)
            {
                ProxyAmountUnitnfoInfo.UnitName = DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "UnitName");
            }
            if (ProxyAmountUnitnfoInfoDataRow["UnitAddress"] != null)
            {
                ProxyAmountUnitnfoInfo.UnitAddress = DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "UnitAddress");
            }
            if (ProxyAmountUnitnfoInfoDataRow["UserID"] != null)
            {
                ProxyAmountUnitnfoInfo.UserID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "UserID"));
            }
            if (ProxyAmountUnitnfoInfoDataRow["UserName"] != null)
            {
                ProxyAmountUnitnfoInfo.UserName = DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "UserName");
            }
            if (ProxyAmountUnitnfoInfoDataRow["UserDept"] != null)
            {
                ProxyAmountUnitnfoInfo.UserDept = DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "UserDept");
            }
            if (ProxyAmountUnitnfoInfoDataRow["SMDJNumber"] != null)
            {
                ProxyAmountUnitnfoInfo.SMDJNumber = DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "SMDJNumber");
            }
            if (ProxyAmountUnitnfoInfoDataRow["DSNumber"] != null)
            {
                ProxyAmountUnitnfoInfo.DSNumber = DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "DSNumber");
            }
            if (ProxyAmountUnitnfoInfoDataRow["FRSFZNumber"] != null)
            {
                ProxyAmountUnitnfoInfo.FRSFZNumber = DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "FRSFZNumber");
            }
            if (ProxyAmountUnitnfoInfoDataRow["KHHJAccountNo"] != null)
            {
                ProxyAmountUnitnfoInfo.KHHJAccountNo = DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "KHHJAccountNo");
            }
            if (ProxyAmountUnitnfoInfoDataRow["ContactPhoneNumber"] != null)
            {
                ProxyAmountUnitnfoInfo.ContactPhoneNumber = DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "ContactPhoneNumber");
            }
            if (ProxyAmountUnitnfoInfoDataRow["GSManager"] != null)
            {
                ProxyAmountUnitnfoInfo.GSManager = DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "GSManager");
            }
            if (ProxyAmountUnitnfoInfoDataRow["DSManager"] != null)
            {
                ProxyAmountUnitnfoInfo.DSManager = DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "DSManager");
            }
            if (ProxyAmountUnitnfoInfoDataRow["Other"] != null)
            {
                ProxyAmountUnitnfoInfo.Other = DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "Other");
            }
            if (ProxyAmountUnitnfoInfoDataRow["IsDelete"] != null)
            {
                ProxyAmountUnitnfoInfo.IsDelete = bool.Parse(DataUtil.GetStringValueOfRow(ProxyAmountUnitnfoInfoDataRow, "IsDelete"));
            }

            return ProxyAmountUnitnfoInfo;
        }
        #endregion
    }
}
