//----------------------------------------------------------------------------------------------------
//???:	BusinessCostApply ???
//??:  	???? dbo.BusinessCostApply ? ??????????
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
    /// BusinessCostApplyCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class BusinessCostApplyCtrl
    {
        #region ????

        /// <summary>
        /// BusinessCostApplyCtrl??????
        /// </summary>
        public BusinessCostApplyCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.BusinessCostApply????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="BusinessCostApplyInfo">BusinessCostApplyInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, BusinessCostApplyInfo BusinessCostApplyInfo)
        {
            try
            {
                //??????
                string strsql = "BusinessCostApply_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@BusinessID",DbType.Guid),
                new SqlParameter("@CompanyName",DbType.String),
				new SqlParameter("@CostType",DbType.Int16),
				new SqlParameter("@ApplyMoney",DbType.Guid),
				new SqlParameter("@ActualMoney",DbType.Guid),
				new SqlParameter("@PayType",DbType.Int16),
				new SqlParameter("@PayDate",DbType.DateTime),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@IsDelete",DbType.Boolean),
				};

                int i = 0;
                sqlparam[i++].Value = BusinessCostApplyInfo.ObjectID;
                sqlparam[i++].Value = BusinessCostApplyInfo.UserID;
                sqlparam[i++].Value = BusinessCostApplyInfo.UserName;
                sqlparam[i++].Value = BusinessCostApplyInfo.UserDept;
                sqlparam[i++].Value = BusinessCostApplyInfo.UserAccountNo;
                sqlparam[i++].Value = BusinessCostApplyInfo.ApplyTime;
                sqlparam[i++].Value = BusinessCostApplyInfo.BusinessID;
                sqlparam[i++].Value = BusinessCostApplyInfo.CompanyName;
                sqlparam[i++].Value = BusinessCostApplyInfo.CostType;
                sqlparam[i++].Value = BusinessCostApplyInfo.ApplyMoney;
                sqlparam[i++].Value = BusinessCostApplyInfo.ActualMoney;
                sqlparam[i++].Value = BusinessCostApplyInfo.PayType;
                sqlparam[i++].Value = BusinessCostApplyInfo.PayDate;
                sqlparam[i++].Value = BusinessCostApplyInfo.Other;
                sqlparam[i++].Value = BusinessCostApplyInfo.State;
                sqlparam[i++].Value = BusinessCostApplyInfo.ApproverID;
                sqlparam[i++].Value = BusinessCostApplyInfo.IsDelete;
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
        /// dbo.BusinessCostApply????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "BusinessCostApply_Delete";

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
        /// BusinessCostApply ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="BusinessCostApplyInfo">BusinessCostApplyInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, BusinessCostApplyInfo BusinessCostApplyInfo)
        {
            try
            {
                //??????
                string strsql = "BusinessCostApply_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@BusinessID",DbType.Guid),
                new SqlParameter("@Companyname",DbType.String),
				new SqlParameter("@CostType",DbType.Int16),
				new SqlParameter("@ApplyMoney",DbType.Guid),
				new SqlParameter("@ActualMoney",DbType.Guid),
				new SqlParameter("@PayType",DbType.Int16),
				new SqlParameter("@PayDate",DbType.DateTime),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@IsDelete",DbType.Boolean),
                };

                int i = 0;
                sqlparam[i++].Value = BusinessCostApplyInfo.ObjectID;
                sqlparam[i++].Value = BusinessCostApplyInfo.UserID;
                sqlparam[i++].Value = BusinessCostApplyInfo.UserName;
                sqlparam[i++].Value = BusinessCostApplyInfo.UserDept;
                sqlparam[i++].Value = BusinessCostApplyInfo.UserAccountNo;
                sqlparam[i++].Value = BusinessCostApplyInfo.ApplyTime;
                sqlparam[i++].Value = BusinessCostApplyInfo.BusinessID;
                sqlparam[i++].Value = BusinessCostApplyInfo.CompanyName;
                sqlparam[i++].Value = BusinessCostApplyInfo.CostType;
                sqlparam[i++].Value = BusinessCostApplyInfo.ApplyMoney;
                sqlparam[i++].Value = BusinessCostApplyInfo.ActualMoney;
                sqlparam[i++].Value = BusinessCostApplyInfo.PayType;
                sqlparam[i++].Value = BusinessCostApplyInfo.PayDate;
                sqlparam[i++].Value = BusinessCostApplyInfo.Other;
                sqlparam[i++].Value = BusinessCostApplyInfo.State;
                sqlparam[i++].Value = BusinessCostApplyInfo.ApproverID;
                sqlparam[i++].Value = BusinessCostApplyInfo.IsDelete;
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
        /// BusinessCostApply ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "BusinessCostApply_Search";
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
        ///BusinessCostApply ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<BusinessCostApplyInfo></returns>
        public List<BusinessCostApplyInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<BusinessCostApplyInfo> list = new List<BusinessCostApplyInfo>();
            BusinessCostApplyInfo accountInfo = new BusinessCostApplyInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = BusinessCostApplyInfoRowToInfo(row);
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
        /// <param name="BusinessCostApplyDataRow">BusinessCostApplyDataRow</param>
        /// <returns>BusinessCostApplyInfo</returns>
        internal BusinessCostApplyInfo BusinessCostApplyInfoRowToInfo(DataRow BusinessCostApplyInfoInfoDataRow)
        {
            BusinessCostApplyInfo BusinessCostApplyInfoInfo = new BusinessCostApplyInfo();
            if (BusinessCostApplyInfoInfoDataRow["ObjectID"] != null)
            {
                BusinessCostApplyInfoInfo.ObjectID = new Guid( DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "ObjectID"));
            }
            if (BusinessCostApplyInfoInfoDataRow["UserID"] != null)
            {
                BusinessCostApplyInfoInfo.UserID = new Guid( DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "UserID"));
            }
            if (BusinessCostApplyInfoInfoDataRow["UserName"] != null)
            {
                BusinessCostApplyInfoInfo.UserName = DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "UserName");
            }
            if (BusinessCostApplyInfoInfoDataRow["UserDept"] != null)
            {
                BusinessCostApplyInfoInfo.UserDept = DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "UserDept");
            }
            if (BusinessCostApplyInfoInfoDataRow["UserAccountNo"] != null)
            {
                BusinessCostApplyInfoInfo.UserAccountNo = DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "UserAccountNo");
            }
            if (BusinessCostApplyInfoInfoDataRow["ApplyTime"] != null)
            {
                BusinessCostApplyInfoInfo.ApplyTime = DateTime.Parse( DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "ApplyTime"));
            }
            if (BusinessCostApplyInfoInfoDataRow["BusinessID"] != null)
            {
                BusinessCostApplyInfoInfo.BusinessID = new Guid( DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "BusinessID"));
            }
            if (BusinessCostApplyInfoInfoDataRow["CompanyName"] != null)
            {
                BusinessCostApplyInfoInfo.CompanyName = DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "CompanyName");
            }
            if (BusinessCostApplyInfoInfoDataRow["CostType"] != null)
            {
                BusinessCostApplyInfoInfo.CostType = short.Parse( DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "CostType"));
            }
            if (BusinessCostApplyInfoInfoDataRow["ApplyMoney"] != null)
            {
                BusinessCostApplyInfoInfo.ApplyMoney = Convert.ToDecimal( DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "ApplyMoney"));
            }
            if (BusinessCostApplyInfoInfoDataRow["ActualMoney"] != null)
            {
                BusinessCostApplyInfoInfo.ActualMoney = Convert.ToDecimal( DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "ActualMoney"));
            }
            if (BusinessCostApplyInfoInfoDataRow["PayType"] != null)
            {
                BusinessCostApplyInfoInfo.PayType = short.Parse( DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "PayType"));
            }
            if (BusinessCostApplyInfoInfoDataRow["PayDate"] != null)
            {
                BusinessCostApplyInfoInfo.PayDate = DateTime.Parse( DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "PayDate"));
            }
            if (BusinessCostApplyInfoInfoDataRow["Other"] != null)
            {
                BusinessCostApplyInfoInfo.Other = DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "Other");
            }
            if (BusinessCostApplyInfoInfoDataRow["State"] != null)
            {
                BusinessCostApplyInfoInfo.State = short.Parse( DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "State"));
            }
            if (BusinessCostApplyInfoInfoDataRow["ApproverID"] != null)
            {
                BusinessCostApplyInfoInfo.ApproverID = new Guid( DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "ApproverID"));
            }
            if (BusinessCostApplyInfoInfoDataRow["IsDelete"] != null)
            {
                BusinessCostApplyInfoInfo.IsDelete = bool.Parse( DataUtil.GetStringValueOfRow(BusinessCostApplyInfoInfoDataRow, "IsDelete"));
            }

            return BusinessCostApplyInfoInfo;
        }
        #endregion
    }
}
