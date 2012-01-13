//----------------------------------------------------------------------------------------------------
//???:	ProxyAmountTemplateApprove ???
//??:  	???? dbo.ProxyAmountTemplateApprove ? ??????????
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
    /// ProxyAmountTemplateApproveCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class ProxyAmountTemplateApproveCtrl
    {
        #region ????

        /// <summary>
        /// ProxyAmountTemplateApproveCtrl??????
        /// </summary>
        public ProxyAmountTemplateApproveCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.ProxyAmountTemplateApprove????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="ProxyAmountTemplateApproveInfo">ProxyAmountTemplateApproveInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, ProxyAmountTemplateApproveInfo ProxyAmountTemplateApproveInfo)
        {
            try
            {
                //??????
                string strsql = "ProxyAmountTemplateApprove_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproverDept",DbType.String),
				new SqlParameter("@ApproveDate",DbType.DateTime),
				new SqlParameter("@ApproveState",DbType.Int16),
				new SqlParameter("@Result",DbType.Int16),
				new SqlParameter("@Sugest",DbType.String),
				new SqlParameter("@ApproveOp",DbType.Int16),
				new SqlParameter("@ApplyID",DbType.Guid),
				};

                int i = 0;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ObjectID;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApproverID;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApproverName;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApproverDept;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApproveDate;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApproveState;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.Result;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.Sugest;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApproveOp;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApplyID;
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
        /// dbo.ProxyAmountTemplateApprove????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ProxyAmountTemplateApprove_Delete";

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
        /// ProxyAmountTemplateApprove ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="ProxyAmountTemplateApproveInfo">ProxyAmountTemplateApproveInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, ProxyAmountTemplateApproveInfo ProxyAmountTemplateApproveInfo)
        {
            try
            {
                //??????
                string strsql = "ProxyAmountTemplateApprove_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproverDept",DbType.String),
				new SqlParameter("@ApproveDate",DbType.DateTime),
				new SqlParameter("@ApproveState",DbType.Int16),
				new SqlParameter("@Result",DbType.Int16),
				new SqlParameter("@Sugest",DbType.String),
				new SqlParameter("@ApproveOp",DbType.Int16),
				new SqlParameter("@ApplyID",DbType.Guid),
                };

                int i = 0;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ObjectID;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApproverID;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApproverName;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApproverDept;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApproveDate;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApproveState;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.Result;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.Sugest;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApproveOp;
                sqlparam[i++].Value = ProxyAmountTemplateApproveInfo.ApplyID;
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
        /// ProxyAmountTemplateApprove ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "ProxyAmountTemplateApprove_Search";
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
        ///ProxyAmountTemplateApprove ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<ProxyAmountTemplateApproveInfo></returns>
        public List<ProxyAmountTemplateApproveInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ProxyAmountTemplateApproveInfo> list = new List<ProxyAmountTemplateApproveInfo>();
            ProxyAmountTemplateApproveInfo accountInfo = new ProxyAmountTemplateApproveInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ProxyAmountTemplateApproveInfoRowToInfo(row);
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
        /// <param name="ProxyAmountTemplateApproveDataRow">ProxyAmountTemplateApproveDataRow</param>
        /// <returns>ProxyAmountTemplateApproveInfo</returns>
        internal ProxyAmountTemplateApproveInfo ProxyAmountTemplateApproveInfoRowToInfo(DataRow ProxyAmountTemplateApproveInfoInfoDataRow)
        {
            ProxyAmountTemplateApproveInfo ProxyAmountTemplateApproveInfoInfo = new ProxyAmountTemplateApproveInfo();
            if (ProxyAmountTemplateApproveInfoInfoDataRow["ObjectID"] != null)
            {
                ProxyAmountTemplateApproveInfoInfo.ObjectID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApproveInfoInfoDataRow, "ObjectID"));
            }
            if (ProxyAmountTemplateApproveInfoInfoDataRow["ApproverID"] != null)
            {
                ProxyAmountTemplateApproveInfoInfo.ApproverID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApproveInfoInfoDataRow, "ApproverID"));
            }
            if (ProxyAmountTemplateApproveInfoInfoDataRow["ApproverName"] != null)
            {
                ProxyAmountTemplateApproveInfoInfo.ApproverName = DataUtil.GetStringValueOfRow(ProxyAmountTemplateApproveInfoInfoDataRow, "ApproverName");
            }
            if (ProxyAmountTemplateApproveInfoInfoDataRow["ApproverDept"] != null)
            {
                ProxyAmountTemplateApproveInfoInfo.ApproverDept = DataUtil.GetStringValueOfRow(ProxyAmountTemplateApproveInfoInfoDataRow, "ApproverDept");
            }
            if (ProxyAmountTemplateApproveInfoInfoDataRow["ApproveDate"] != null)
            {
                ProxyAmountTemplateApproveInfoInfo.ApproveDate = DateTime.Parse(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApproveInfoInfoDataRow, "ApproveDate"));
            }
            if (ProxyAmountTemplateApproveInfoInfoDataRow["ApproveState"] != null)
            {
                ProxyAmountTemplateApproveInfoInfo.ApproveState = short.Parse(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApproveInfoInfoDataRow, "ApproveState"));
            }
            if (ProxyAmountTemplateApproveInfoInfoDataRow["Result"] != null)
            {
                ProxyAmountTemplateApproveInfoInfo.Result = short.Parse(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApproveInfoInfoDataRow, "Result"));
            }
            if (ProxyAmountTemplateApproveInfoInfoDataRow["Sugest"] != null)
            {
                ProxyAmountTemplateApproveInfoInfo.Sugest = DataUtil.GetStringValueOfRow(ProxyAmountTemplateApproveInfoInfoDataRow, "Sugest");
            }
            if (ProxyAmountTemplateApproveInfoInfoDataRow["ApproveOp"] != null)
            {
                ProxyAmountTemplateApproveInfoInfo.ApproveOp = short.Parse(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApproveInfoInfoDataRow, "ApproveOp"));
            }
            if (ProxyAmountTemplateApproveInfoInfoDataRow["ApplyID"] != null)
            {
                ProxyAmountTemplateApproveInfoInfo.ApplyID = new Guid(DataUtil.GetStringValueOfRow(ProxyAmountTemplateApproveInfoInfoDataRow, "ApplyID"));
            }

            return ProxyAmountTemplateApproveInfoInfo;
        }
        #endregion
    }
}
