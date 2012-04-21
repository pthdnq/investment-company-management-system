//----------------------------------------------------------------------------------------------------
//???:	ProxyAmount ???
//??:  	???? dbo.ProxyAmount ? ??????????
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
    /// ProxyAmountCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class ProxyAmountCtrl
    {
        #region ????

        /// <summary>
        /// ProxyAmountCtrl??????
        /// </summary>
        public ProxyAmountCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.ProxyAmount????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="ProxyAmountInfo">ProxyAmountInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, ProxyAmountInfo ProxyAmountInfo)
        {
            try
            {
                //??????
                string strsql = "ProxyAmount_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@CreaterID",DbType.Guid),
				new SqlParameter("@CreateName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@ProxyAmountID",DbType.Guid),
				new SqlParameter("@ProxyAmountUnitName",DbType.String),
				new SqlParameter("@ProxyAmounterID",DbType.Guid),
				new SqlParameter("@ProxyAmounterName",DbType.String),
				new SqlParameter("@CNMoney",DbType.String),
				new SqlParameter("@ENMoney",DbType.Guid),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@OpeningDate",DbType.DateTime),
				new SqlParameter("@CollectMethod",DbType.String),
				new SqlParameter("@CollectUnitID",DbType.Guid),
				new SqlParameter("@CollecterID",DbType.Guid),
				new SqlParameter("@CollecterName",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
                new SqlParameter("@ProxyAmountType",DbType.Int16),
                      new SqlParameter("@ENMoneyFlag",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = ProxyAmountInfo.ObjectID;
                sqlparam[i++].Value = ProxyAmountInfo.CreaterID;
                sqlparam[i++].Value = ProxyAmountInfo.CreateName;
                sqlparam[i++].Value = ProxyAmountInfo.CreateTime;
                sqlparam[i++].Value = ProxyAmountInfo.ProxyAmountID;
                sqlparam[i++].Value = ProxyAmountInfo.ProxyAmountUnitName;
                sqlparam[i++].Value = ProxyAmountInfo.ProxyAmounterID;
                sqlparam[i++].Value = ProxyAmountInfo.ProxyAmounterName;
                sqlparam[i++].Value = ProxyAmountInfo.CNMoney;
                sqlparam[i++].Value = ProxyAmountInfo.ENMoney;
                sqlparam[i++].Value = ProxyAmountInfo.Sument;
                sqlparam[i++].Value = ProxyAmountInfo.OpeningDate;
                sqlparam[i++].Value = ProxyAmountInfo.CollectMethod;
                sqlparam[i++].Value = ProxyAmountInfo.CollectUnitID;
                sqlparam[i++].Value = ProxyAmountInfo.CollecterID;
                sqlparam[i++].Value = ProxyAmountInfo.CollecterName;
                sqlparam[i++].Value = ProxyAmountInfo.State;
                sqlparam[i++].Value = ProxyAmountInfo.IsDelete;
                sqlparam[i++].Value = ProxyAmountInfo.ProxyAmountType;
                sqlparam[i++].Value = ProxyAmountInfo.ENMoneyFlag;
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
        /// dbo.ProxyAmount????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ProxyAmount_Delete";

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
        /// ProxyAmount ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="ProxyAmountInfo">ProxyAmountInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, ProxyAmountInfo ProxyAmountInfo)
        {
            try
            {
                //??????
                string strsql = "ProxyAmount_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@CreaterID",DbType.Guid),
				new SqlParameter("@CreateName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@ProxyAmountID",DbType.Guid),
				new SqlParameter("@ProxyAmountUnitName",DbType.String),
				new SqlParameter("@ProxyAmounterID",DbType.Guid),
				new SqlParameter("@ProxyAmounterName",DbType.String),
				new SqlParameter("@CNMoney",DbType.String),
				new SqlParameter("@ENMoney",DbType.Guid),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@OpeningDate",DbType.DateTime),
				new SqlParameter("@CollectMethod",DbType.String),
				new SqlParameter("@CollectUnitID",DbType.Guid),
				new SqlParameter("@CollecterID",DbType.Guid),
				new SqlParameter("@CollecterName",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
                new SqlParameter("@ProxyAmountType",DbType.Int16),
                      new SqlParameter("@ENMoneyFlag",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = ProxyAmountInfo.ObjectID;
                sqlparam[i++].Value = ProxyAmountInfo.CreaterID;
                sqlparam[i++].Value = ProxyAmountInfo.CreateName;
                sqlparam[i++].Value = ProxyAmountInfo.CreateTime;
                sqlparam[i++].Value = ProxyAmountInfo.ProxyAmountID;
                sqlparam[i++].Value = ProxyAmountInfo.ProxyAmountUnitName;
                sqlparam[i++].Value = ProxyAmountInfo.ProxyAmounterID;
                sqlparam[i++].Value = ProxyAmountInfo.ProxyAmounterName;
                sqlparam[i++].Value = ProxyAmountInfo.CNMoney;
                sqlparam[i++].Value = ProxyAmountInfo.ENMoney;
                sqlparam[i++].Value = ProxyAmountInfo.Sument;
                sqlparam[i++].Value = ProxyAmountInfo.OpeningDate;
                sqlparam[i++].Value = ProxyAmountInfo.CollectMethod;
                sqlparam[i++].Value = ProxyAmountInfo.CollectUnitID;
                sqlparam[i++].Value = ProxyAmountInfo.CollecterID;
                sqlparam[i++].Value = ProxyAmountInfo.CollecterName;
                sqlparam[i++].Value = ProxyAmountInfo.State;
                sqlparam[i++].Value = ProxyAmountInfo.IsDelete;
                sqlparam[i++].Value = ProxyAmountInfo.ProxyAmountType;
                sqlparam[i++].Value = ProxyAmountInfo.ENMoneyFlag;
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
        /// ProxyAmount ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "ProxyAmount_Search";
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
        ///ProxyAmount ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<ProxyAmountInfo></returns>
        public List<ProxyAmountInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ProxyAmountInfo> list = new List<ProxyAmountInfo>();
            ProxyAmountInfo accountInfo = new ProxyAmountInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ProxyAmountInfoRowToInfo(row);
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
        /// <param name="ProxyAmountDataRow">ProxyAmountDataRow</param>
        /// <returns>ProxyAmountInfo</returns>
        internal ProxyAmountInfo ProxyAmountInfoRowToInfo(DataRow ProxyAmountInfoInfoDataRow)
        {
            ProxyAmountInfo ProxyAmountInfoInfo = new ProxyAmountInfo();
            if (ProxyAmountInfoInfoDataRow["ObjectID"] != null)
            {
                ProxyAmountInfoInfo.ObjectID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "ObjectID"));
            }
            if (ProxyAmountInfoInfoDataRow["CreaterID"] != null)
            {
                ProxyAmountInfoInfo.CreaterID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "CreaterID"));
            }
            if (ProxyAmountInfoInfoDataRow["CreateName"] != null)
            {
                ProxyAmountInfoInfo.CreateName = DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "CreateName");
            }
            if (ProxyAmountInfoInfoDataRow["CreateTime"] != null)
            {
                ProxyAmountInfoInfo.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "CreateTime"));
            }
            if (ProxyAmountInfoInfoDataRow["ProxyAmountID"] != null)
            {
                ProxyAmountInfoInfo.ProxyAmountID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "ProxyAmountID"));
            }
            if (ProxyAmountInfoInfoDataRow["ProxyAmountUnitName"] != null)
            {
                ProxyAmountInfoInfo.ProxyAmountUnitName = DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "ProxyAmountUnitName");
            }
            if (ProxyAmountInfoInfoDataRow["ProxyAmounterID"] != null)
            {
                ProxyAmountInfoInfo.ProxyAmounterID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "ProxyAmounterID"));
            }
            if (ProxyAmountInfoInfoDataRow["ProxyAmounterName"] != null)
            {
                ProxyAmountInfoInfo.ProxyAmounterName = DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "ProxyAmounterName");
            }
            if (ProxyAmountInfoInfoDataRow["CNMoney"] != null)
            {
                ProxyAmountInfoInfo.CNMoney = DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "CNMoney");
            }
            if (ProxyAmountInfoInfoDataRow["ENMoney"] != null)
            {
                ProxyAmountInfoInfo.ENMoney = Convert.ToDecimal(DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "ENMoney"));
            }
            if (ProxyAmountInfoInfoDataRow["Sument"] != null)
            {
                ProxyAmountInfoInfo.Sument = DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "Sument");
            }
            if (ProxyAmountInfoInfoDataRow["OpeningDate"] != null)
            {
                ProxyAmountInfoInfo.OpeningDate = DateTime.Parse(DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "OpeningDate"));
            }
            if (ProxyAmountInfoInfoDataRow["CollectMethod"] != null)
            {
                ProxyAmountInfoInfo.CollectMethod = DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "CollectMethod");
            }
            if (ProxyAmountInfoInfoDataRow["CollectUnitID"] != null)
            {
                ProxyAmountInfoInfo.CollectUnitID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "CollectUnitID"));
            }
            if (ProxyAmountInfoInfoDataRow["CollecterID"] != null)
            {
                ProxyAmountInfoInfo.CollecterID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "CollecterID"));
            }
            if (ProxyAmountInfoInfoDataRow["CollecterName"] != null)
            {
                ProxyAmountInfoInfo.CollecterName = DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "CollecterName");
            }
            if (ProxyAmountInfoInfoDataRow["State"] != null)
            {
                ProxyAmountInfoInfo.State = short.Parse(DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "State"));
            }
            if (ProxyAmountInfoInfoDataRow["IsDelete"] != null)
            {
                ProxyAmountInfoInfo.IsDelete = bool.Parse(DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "IsDelete"));
            }
            if (ProxyAmountInfoInfoDataRow["ProxyAmountType"] != null)
            {
                ProxyAmountInfoInfo.ProxyAmountType = short.Parse(DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "ProxyAmountType"));
            }
            if (ProxyAmountInfoInfoDataRow["ENMoneyFlag"] != null)
            {
                ProxyAmountInfoInfo.ENMoneyFlag = DataUtil.GetStringValueOfRow(ProxyAmountInfoInfoDataRow, "ENMoneyFlag");
            }
            return ProxyAmountInfoInfo;
        }
        #endregion
    }
}
