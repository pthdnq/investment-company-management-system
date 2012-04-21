//----------------------------------------------------------------------------------------------------
//???:	AdminImprest ???
//??:  	???? dbo.AdminImprest ? ??????????
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
    /// AdminImprestCtrl
    /// programmer:xlli
    /// </summary>
    public class AdminImprestCtrl
    {
        #region ????

        /// <summary>
        /// AdminImprestCtrl??????
        /// </summary>
        public AdminImprestCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.AdminImprest????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="AdminImprestInfo">AdminImprestInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, AdminImprestInfo AdminImprestInfo)
        {
            try
            {
                //??????
                string strsql = "AdminImprest_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@PrepaidAmount",DbType.Guid),
				new SqlParameter("@Use",DbType.String),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@AccountingName",DbType.String),
				new SqlParameter("@AccountingId",DbType.Guid),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@Status",SqlDbType.TinyInt),
				new SqlParameter("@NextOperaterId",DbType.Guid),
				new SqlParameter("@NextOperaterName",DbType.String),
				new SqlParameter("@NextOperateDesc",DbType.String),
				new SqlParameter("@SubmitTime",DbType.DateTime),
				new SqlParameter("@Adulters",DbType.String),
                new SqlParameter("@PrepaidAmountFlag",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = AdminImprestInfo.ObjectId;
                sqlparam[i++].Value = AdminImprestInfo.ProjectName;
                sqlparam[i++].Value = AdminImprestInfo.PrepaidAmount;
                sqlparam[i++].Value = AdminImprestInfo.Use;
                sqlparam[i++].Value = AdminImprestInfo.Remark;
                sqlparam[i++].Value = AdminImprestInfo.AuditOpinion;
                sqlparam[i++].Value = AdminImprestInfo.AccountingName;
                sqlparam[i++].Value = AdminImprestInfo.AccountingId;
                sqlparam[i++].Value = AdminImprestInfo.CreaterId;
                sqlparam[i++].Value = AdminImprestInfo.CreaterName;
                sqlparam[i++].Value = AdminImprestInfo.CreateTime;
                sqlparam[i++].Value = AdminImprestInfo.Status;
                sqlparam[i++].Value = AdminImprestInfo.NextOperaterId;
                sqlparam[i++].Value = AdminImprestInfo.NextOperaterName;
                sqlparam[i++].Value = AdminImprestInfo.NextOperateDesc;
                sqlparam[i++].Value = AdminImprestInfo.SubmitTime;
                sqlparam[i++].Value = AdminImprestInfo.Adulters;
                sqlparam[i++].Value = AdminImprestInfo.PrepaidAmountFlag;
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
        /// dbo.AdminImprest????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "AdminImprest_Delete";

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
        /// AdminImprest ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="AdminImprestInfo">AdminImprestInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, AdminImprestInfo AdminImprestInfo)
        {
            try
            {
                //??????
                string strsql = "AdminImprest_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@PrepaidAmount",DbType.Guid),
				new SqlParameter("@Use",DbType.String),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@AccountingName",DbType.String),
				new SqlParameter("@AccountingId",DbType.Guid),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@Status",SqlDbType.TinyInt),
				new SqlParameter("@NextOperaterId",DbType.Guid),
				new SqlParameter("@NextOperaterName",DbType.String),
				new SqlParameter("@NextOperateDesc",DbType.String),
				new SqlParameter("@SubmitTime",DbType.DateTime),
				new SqlParameter("@Adulters",DbType.String),
                 new SqlParameter("@PrepaidAmountFlag",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = AdminImprestInfo.ObjectId;
                sqlparam[i++].Value = AdminImprestInfo.ProjectName;
                sqlparam[i++].Value = AdminImprestInfo.PrepaidAmount;
                sqlparam[i++].Value = AdminImprestInfo.Use;
                sqlparam[i++].Value = AdminImprestInfo.Remark;
                sqlparam[i++].Value = AdminImprestInfo.AuditOpinion;
                sqlparam[i++].Value = AdminImprestInfo.AccountingName;
                sqlparam[i++].Value = AdminImprestInfo.AccountingId;
                sqlparam[i++].Value = AdminImprestInfo.CreaterId;
                sqlparam[i++].Value = AdminImprestInfo.CreaterName;
                sqlparam[i++].Value = AdminImprestInfo.CreateTime;
                sqlparam[i++].Value = AdminImprestInfo.Status;
                sqlparam[i++].Value = AdminImprestInfo.NextOperaterId;
                sqlparam[i++].Value = AdminImprestInfo.NextOperaterName;
                sqlparam[i++].Value = AdminImprestInfo.NextOperateDesc;
                sqlparam[i++].Value = AdminImprestInfo.SubmitTime;
                sqlparam[i++].Value = AdminImprestInfo.Adulters;
                sqlparam[i++].Value = AdminImprestInfo.PrepaidAmountFlag;
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
        /// AdminImprest ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "AdminImprest_Search";
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
        ///AdminImprest ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<AdminImprestInfo></returns>
        public List<AdminImprestInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<AdminImprestInfo> list = new List<AdminImprestInfo>();
            AdminImprestInfo accountInfo = new AdminImprestInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = AdminImprestInfoRowToInfo(row);
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
        /// <param name="AdminImprestDataRow">AdminImprestDataRow</param>
        /// <returns>AdminImprestInfo</returns>
        internal AdminImprestInfo AdminImprestInfoRowToInfo(DataRow adminImprestInfoInfoDataRow)
        {
            AdminImprestInfo adminImprestInfoInfo = new AdminImprestInfo();
            if (adminImprestInfoInfoDataRow["ObjectId"] != null)
            {
                adminImprestInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "ObjectId"));
            }
            if (adminImprestInfoInfoDataRow["ProjectName"] != null)
            {
                adminImprestInfoInfo.ProjectName = DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "ProjectName");
            }
            if (adminImprestInfoInfoDataRow["PrepaidAmount"] != null)
            {
                adminImprestInfoInfo.PrepaidAmount = decimal.Parse(DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "PrepaidAmount"));
            }
            if (adminImprestInfoInfoDataRow["Use"] != null)
            {
                adminImprestInfoInfo.Use = DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "Use");
            }
            if (adminImprestInfoInfoDataRow["Remark"] != null)
            {
                adminImprestInfoInfo.Remark = DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "Remark");
            }
            if (adminImprestInfoInfoDataRow["AuditOpinion"] != null)
            {
                adminImprestInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "AuditOpinion");
            }
            if (adminImprestInfoInfoDataRow["AccountingName"] != null)
            {
                adminImprestInfoInfo.AccountingName = DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "AccountingName");
            }
            if (adminImprestInfoInfoDataRow["AccountingId"] != null)
            {
                adminImprestInfoInfo.AccountingId = new Guid(DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "AccountingId"));
            }
            if (adminImprestInfoInfoDataRow["CreaterId"] != null)
            {
                adminImprestInfoInfo.CreaterId = new Guid(DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "CreaterId"));
            }
            if (adminImprestInfoInfoDataRow["CreaterName"] != null)
            {
                adminImprestInfoInfo.CreaterName = DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "CreaterName");
            }
            if (adminImprestInfoInfoDataRow["CreateTime"] != null)
            {
                adminImprestInfoInfo.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "CreateTime"));
            }
            if (adminImprestInfoInfoDataRow["Status"] != null)
            {
                adminImprestInfoInfo.Status = int.Parse(DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "Status"));
            }
            if (adminImprestInfoInfoDataRow["NextOperaterId"] != null)
            {
                adminImprestInfoInfo.NextOperaterId = new Guid(DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "NextOperaterId"));
            }
            if (adminImprestInfoInfoDataRow["NextOperaterName"] != null)
            {
                adminImprestInfoInfo.NextOperaterName = DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "NextOperaterName");
            }
            if (adminImprestInfoInfoDataRow["NextOperateDesc"] != null)
            {
                adminImprestInfoInfo.NextOperateDesc = DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "NextOperateDesc");
            }
            if (adminImprestInfoInfoDataRow["SubmitTime"] != null)
            {
                adminImprestInfoInfo.SubmitTime = DateTime.Parse(DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "SubmitTime"));
            }
            if (adminImprestInfoInfoDataRow["Adulters"] != null)
            {
                adminImprestInfoInfo.Adulters = DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "Adulters");
            }
            if (adminImprestInfoInfoDataRow["PrepaidAmountFlag"] != null)
            {
                adminImprestInfoInfo.PrepaidAmountFlag = DataUtil.GetStringValueOfRow(adminImprestInfoInfoDataRow, "PrepaidAmountFlag");
            }

            return adminImprestInfoInfo;
        }
        #endregion
    }
}
