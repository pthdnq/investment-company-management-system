//----------------------------------------------------------------------------------------------------
//???:	BusinessCostApprove ???
//??:  	???? dbo.BusinessCostApprove ? ??????????
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
    /// BusinessCostApproveCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class BusinessCostApproveCtrl
    {
        #region ????

        /// <summary>
        /// BusinessCostApproveCtrl??????
        /// </summary>
        public BusinessCostApproveCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.BusinessCostApprove????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="BusinessCostApproveInfo">BusinessCostApproveInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, BusinessCostApproveInfo BusinessCostApproveInfo)
        {
            try
            {
                //??????
                string strsql = "BusinessCostApprove_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproverDept",DbType.String),
				new SqlParameter("@ApproveState",DbType.Int16),
				new SqlParameter("@ApproveTime",DbType.DateTime),
				new SqlParameter("@ApproveOp",DbType.Int16),
				new SqlParameter("@ApproverSugest",DbType.String),
				new SqlParameter("@ApplyID",DbType.Guid),
				};

                int i = 0;
                sqlparam[i++].Value = BusinessCostApproveInfo.ObjectID;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproverID;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproverName;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproverDept;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproveState;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproveTime;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproveOp;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproverSugest;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApplyID;
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
        /// dbo.BusinessCostApprove????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "BusinessCostApprove_Delete";

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
        /// BusinessCostApprove ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="BusinessCostApproveInfo">BusinessCostApproveInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, BusinessCostApproveInfo BusinessCostApproveInfo)
        {
            try
            {
                //??????
                string strsql = "BusinessCostApprove_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproverDept",DbType.String),
				new SqlParameter("@ApproveState",DbType.Int16),
				new SqlParameter("@ApproveTime",DbType.DateTime),
				new SqlParameter("@ApproveOp",DbType.Int16),
				new SqlParameter("@ApproverSugest",DbType.String),
				new SqlParameter("@ApplyID",DbType.Guid),
                };

                int i = 0;
                sqlparam[i++].Value = BusinessCostApproveInfo.ObjectID;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproverID;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproverName;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproverDept;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproveState;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproveTime;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproveOp;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApproverSugest;
                sqlparam[i++].Value = BusinessCostApproveInfo.ApplyID;
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
        /// BusinessCostApprove ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "BusinessCostApprove_Search";
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
        ///BusinessCostApprove ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<BusinessCostApproveInfo></returns>
        public List<BusinessCostApproveInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<BusinessCostApproveInfo> list = new List<BusinessCostApproveInfo>();
            BusinessCostApproveInfo accountInfo = new BusinessCostApproveInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = BusinessCostApproveInfoRowToInfo(row);
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
        /// <param name="BusinessCostApproveDataRow">BusinessCostApproveDataRow</param>
        /// <returns>BusinessCostApproveInfo</returns>
        internal BusinessCostApproveInfo BusinessCostApproveInfoRowToInfo(DataRow BusinessCostApproveInfoInfoDataRow)
        {
            BusinessCostApproveInfo BusinessCostApproveInfoInfo = new BusinessCostApproveInfo();
            if (BusinessCostApproveInfoInfoDataRow["ObjectID"] != null)
            {
                BusinessCostApproveInfoInfo.ObjectID = new Guid(DataUtil.GetStringValueOfRow(BusinessCostApproveInfoInfoDataRow, "ObjectID"));
            }
            if (BusinessCostApproveInfoInfoDataRow["ApproverID"] != null)
            {
                BusinessCostApproveInfoInfo.ApproverID = new Guid(DataUtil.GetStringValueOfRow(BusinessCostApproveInfoInfoDataRow, "ApproverID"));
            }
            if (BusinessCostApproveInfoInfoDataRow["ApproverName"] != null)
            {
                BusinessCostApproveInfoInfo.ApproverName = DataUtil.GetStringValueOfRow(BusinessCostApproveInfoInfoDataRow, "ApproverName");
            }
            if (BusinessCostApproveInfoInfoDataRow["ApproverDept"] != null)
            {
                BusinessCostApproveInfoInfo.ApproverDept = DataUtil.GetStringValueOfRow(BusinessCostApproveInfoInfoDataRow, "ApproverDept");
            }
            if (BusinessCostApproveInfoInfoDataRow["ApproveState"] != null)
            {
                BusinessCostApproveInfoInfo.ApproveState = short.Parse(DataUtil.GetStringValueOfRow(BusinessCostApproveInfoInfoDataRow, "ApproveState"));
            }
            if (BusinessCostApproveInfoInfoDataRow["ApproveTime"] != null)
            {
                BusinessCostApproveInfoInfo.ApproveTime = DateTime.Parse(DataUtil.GetStringValueOfRow(BusinessCostApproveInfoInfoDataRow, "ApproveTime"));
            }
            if (BusinessCostApproveInfoInfoDataRow["ApproveOp"] != null)
            {
                BusinessCostApproveInfoInfo.ApproveOp = short.Parse(DataUtil.GetStringValueOfRow(BusinessCostApproveInfoInfoDataRow, "ApproveOp"));
            }
            if (BusinessCostApproveInfoInfoDataRow["ApproverSugest"] != null)
            {
                BusinessCostApproveInfoInfo.ApproverSugest = DataUtil.GetStringValueOfRow(BusinessCostApproveInfoInfoDataRow, "ApproverSugest");
            }
            if (BusinessCostApproveInfoInfoDataRow["ApplyID"] != null)
            {
                BusinessCostApproveInfoInfo.ApplyID = new Guid(DataUtil.GetStringValueOfRow(BusinessCostApproveInfoInfoDataRow, "ApplyID"));
            }

            return BusinessCostApproveInfoInfo;
        }
        #endregion
    }
}
