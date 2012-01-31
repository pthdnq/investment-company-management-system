//----------------------------------------------------------------------------------------------------
//???:	 MaterialsPurchaseApply ???
//??:  	???? dbo.MaterialsPurchaseApply ? ??????????
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
    /// MaterialsPurchaseApplyCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class MaterialsPurchaseApplyCtrl
    {
        #region ????

        /// <summary>
        /// MaterialsPurchaseApplyCtrl??????
        /// </summary>
        public MaterialsPurchaseApplyCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.MaterialsPurchaseApply????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="MaterialsPurchaseApplyInfo">MaterialsPurchaseApplyInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, MaterialsPurchaseApplyInfo MaterialsPurchaseApplyInfo)
        {
            try
            {
                //??????
                string strsql = " MaterialsPurchaseApply_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@MaterialsID",DbType.Guid),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@Count",DbType.Int32),
				new SqlParameter("@Money",DbType.Guid),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@IsDelete",DbType.Boolean),
				};

                int i = 0;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.ObjectID;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.UserID;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.UserName;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.UserJobNo;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.UserAccountNo;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.UserDept;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.MaterialsID;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.ApplyTime;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.Count;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.Money;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.Sument;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.Other;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.State;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.ApproverID;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.IsDelete;
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
        /// dbo.MaterialsPurchaseApply????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = " MaterialsPurchaseApply_Delete";

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
        ///  MaterialsPurchaseApply ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="MaterialsPurchaseApplyInfo">MaterialsPurchaseApplyInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, MaterialsPurchaseApplyInfo MaterialsPurchaseApplyInfo)
        {
            try
            {
                //??????
                string strsql = " MaterialsPurchaseApply_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@MaterialsID",DbType.Guid),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@Count",DbType.Int32),
				new SqlParameter("@Money",DbType.Guid),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@IsDelete",DbType.Boolean),
                };

                int i = 0;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.ObjectID;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.UserID;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.UserName;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.UserJobNo;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.UserAccountNo;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.UserDept;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.MaterialsID;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.ApplyTime;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.Count;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.Money;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.Sument;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.Other;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.State;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.ApproverID;
                sqlparam[i++].Value = MaterialsPurchaseApplyInfo.IsDelete;
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
        ///  MaterialsPurchaseApply ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = " MaterialsPurchaseApply_Search";
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
        /// MaterialsPurchaseApply ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<MaterialsPurchaseApplyInfo></returns>
        public List<MaterialsPurchaseApplyInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<MaterialsPurchaseApplyInfo> list = new List<MaterialsPurchaseApplyInfo>();
            MaterialsPurchaseApplyInfo accountInfo = new MaterialsPurchaseApplyInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = MaterialsPurchaseApplyInfoRowToInfo(row);
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
        /// <param name=" MaterialsPurchaseApplyDataRow"> MaterialsPurchaseApplyDataRow</param>
        /// <returns>MaterialsPurchaseApplyInfo</returns>
        internal MaterialsPurchaseApplyInfo MaterialsPurchaseApplyInfoRowToInfo(DataRow MaterialsPurchaseApplyInfoInfoDataRow)
        {
            MaterialsPurchaseApplyInfo MaterialsPurchaseApplyInfoInfo = new MaterialsPurchaseApplyInfo();
            if (MaterialsPurchaseApplyInfoInfoDataRow["ObjectID"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.ObjectID = new Guid(DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "ObjectID"));
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["UserID"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.UserID = new Guid(DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "UserID"));
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["UserName"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.UserName = DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "UserName");
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["UserJobNo"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.UserJobNo = DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "UserJobNo");
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["UserAccountNo"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.UserAccountNo = DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "UserAccountNo");
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["UserDept"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.UserDept = DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "UserDept");
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["MaterialsID"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.MaterialsID = new Guid(DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "MaterialsID"));
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["ApplyTime"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.ApplyTime = DateTime.Parse(DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "ApplyTime"));
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["Count"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.Count = Convert.ToInt32(DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "Count"));
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["Money"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.Money = Convert.ToDecimal(DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "Money"));
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["Sument"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.Sument = DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "Sument");
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["Other"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.Other = DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "Other");
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["State"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.State = short.Parse(DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "State"));
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["ApproverID"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.ApproverID = new Guid(DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "ApproverID"));
            }
            if (MaterialsPurchaseApplyInfoInfoDataRow["IsDelete"] != null)
            {
                MaterialsPurchaseApplyInfoInfo.IsDelete = bool.Parse(DataUtil.GetStringValueOfRow(MaterialsPurchaseApplyInfoInfoDataRow, "IsDelete"));
            }

            return MaterialsPurchaseApplyInfoInfo;
        }
        #endregion
    }
}
