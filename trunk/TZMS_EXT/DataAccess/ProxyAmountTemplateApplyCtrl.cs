//----------------------------------------------------------------------------------------------------
//???:	ProxyAmountTemplateApply ???
//??:  	???? dbo.ProxyAmountTemplateApply ? ??????????
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
    /// ProxyAmountTemplateApplyCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class ProxyAmountTemplateApplyCtrl
    {
        #region ????

        /// <summary>
        /// ProxyAmountTemplateApplyCtrl??????
        /// </summary>
        public ProxyAmountTemplateApplyCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.ProxyAmountTemplateApply????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="ProxyAmountTemplateApplyInfo">ProxyAmountTemplateApplyInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, ProxyAmountTemplateApplyInfo ProxyAmountTemplateApplyInfo)
        {
            try
            {
                //??????
                string strsql = "ProxyAmountTemplateApply_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ProxyAmountUnitID",DbType.Guid),
				new SqlParameter("@ProxyAmountUnitName",DbType.String),
				new SqlParameter("@ProxyAmounterID",DbType.Guid),
				new SqlParameter("@ProxyAmounterName",DbType.String),
				new SqlParameter("@CNMoney",DbType.String),
				new SqlParameter("@ENMoney",DbType.Guid),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@CollectMethod",DbType.String),
				new SqlParameter("@CollectUnitName",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@TemplateType",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
                	new SqlParameter("@ENMoneyFlag",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ObjectID;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ProxyAmountUnitID;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ProxyAmountUnitName;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ProxyAmounterID;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ProxyAmounterName;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.CNMoney;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ENMoney;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.Sument;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.CollectMethod;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.CollectUnitName;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ApplyTime;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.State;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ApproverID;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.TemplateType;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.IsDelete;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ENMoneyFlag;

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
        /// dbo.ProxyAmountTemplateApply????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ProxyAmountTemplateApply_Delete";

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
        /// ProxyAmountTemplateApply ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="ProxyAmountTemplateApplyInfo">ProxyAmountTemplateApplyInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, ProxyAmountTemplateApplyInfo ProxyAmountTemplateApplyInfo)
        {
            try
            {
                //??????
                string strsql = "ProxyAmountTemplateApply_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ProxyAmountUnitID",DbType.Guid),
				new SqlParameter("@ProxyAmountUnitName",DbType.String),
				new SqlParameter("@ProxyAmounterID",DbType.Guid),
				new SqlParameter("@ProxyAmounterName",DbType.String),
				new SqlParameter("@CNMoney",DbType.String),
				new SqlParameter("@ENMoney",DbType.Guid),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@CollectMethod",DbType.String),
				new SqlParameter("@CollectUnitName",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@TemplateType",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
                     	new SqlParameter("@ENMoneyFlag",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ObjectID;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ProxyAmountUnitID;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ProxyAmountUnitName;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ProxyAmounterID;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ProxyAmounterName;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.CNMoney;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ENMoney;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.Sument;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.CollectMethod;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.CollectUnitName;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ApplyTime;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.State;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ApproverID;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.TemplateType;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.IsDelete;
                sqlparam[i++].Value = ProxyAmountTemplateApplyInfo.ENMoneyFlag;
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
        /// ProxyAmountTemplateApply ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "ProxyAmountTemplateApply_Search";
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
        ///ProxyAmountTemplateApply ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<ProxyAmountTemplateApplyInfo></returns>
        public List<ProxyAmountTemplateApplyInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ProxyAmountTemplateApplyInfo> list = new List<ProxyAmountTemplateApplyInfo>();
            ProxyAmountTemplateApplyInfo accountInfo = new ProxyAmountTemplateApplyInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ProxyAmountTemplateApplyInfoRowToInfo(row);
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
        /// <param name="ProxyAmountTemplateApplyDataRow">ProxyAmountTemplateApplyDataRow</param>
        /// <returns>ProxyAmountTemplateApplyInfo</returns>
        internal ProxyAmountTemplateApplyInfo ProxyAmountTemplateApplyInfoRowToInfo(DataRow ProxyAmountTemplateApplyInfoInfoDataRow)
        {
            ProxyAmountTemplateApplyInfo ProxyAmountTemplateApplyInfoInfo = new ProxyAmountTemplateApplyInfo();
            if (ProxyAmountTemplateApplyInfoInfoDataRow["ObjectID"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.ObjectID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "ObjectID"));
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["ProxyAmountUnitID"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.ProxyAmountUnitID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "ProxyAmountUnitID"));
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["ProxyAmountUnitName"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.ProxyAmountUnitName = DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "ProxyAmountUnitName");
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["ProxyAmounterID"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.ProxyAmounterID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "ProxyAmounterID"));
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["ProxyAmounterName"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.ProxyAmounterName = DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "ProxyAmounterName");
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["CNMoney"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.CNMoney = DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "CNMoney");
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["ENMoney"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.ENMoney = Convert.ToDecimal(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "ENMoney"));
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["Sument"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.Sument = DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "Sument");
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["CollectMethod"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.CollectMethod = DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "CollectMethod");
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["CollectUnitName"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.CollectUnitName = DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "CollectUnitName");
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["ApplyTime"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.ApplyTime = DateTime.Parse(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "ApplyTime"));
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["State"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.State = short.Parse(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "State"));
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["ApproverID"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.ApproverID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "ApproverID"));
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["TemplateType"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.TemplateType = short.Parse(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "TemplateType"));
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["IsDelete"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.IsDelete = bool.Parse(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "IsDelete"));
            }
            if (ProxyAmountTemplateApplyInfoInfoDataRow["ENMoneyFlag"] != null)
            {
                ProxyAmountTemplateApplyInfoInfo.ENMoneyFlag = DataUtil.GetStringValueOfRow(ProxyAmountTemplateApplyInfoInfoDataRow, "ENMoneyFlag");
            }
            return ProxyAmountTemplateApplyInfoInfo;
        }
        #endregion
    }
}
