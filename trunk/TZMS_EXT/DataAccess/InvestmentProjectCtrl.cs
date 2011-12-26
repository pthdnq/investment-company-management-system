//----------------------------------------------------------------------------------------------------
//???:	InvestmentProject ???
//??:  	???? dbo.InvestmentProject ? ??????????
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
    /// InvestmentProjectCtrl
    /// programmer:
    /// </summary>
    public class InvestmentProjectCtrl
    {
        #region ????

        /// <summary>
        /// InvestmentProjectCtrl??????
        /// </summary>
        public InvestmentProjectCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.InvestmentProject????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="InvestmentProjectInfo">InvestmentProjectInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, InvestmentProjectInfo InvestmentProjectInfo)
        {
            try
            {
                //??????
                string strsql = "InvestmentProject_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@CustomerName",DbType.String),
				new SqlParameter("@CustomerId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@ProjectOverview",DbType.String),
				new SqlParameter("@SignDate",DbType.DateTime),
				new SqlParameter("@Contact",DbType.String),
				new SqlParameter("@ContactPhone",DbType.String),
				new SqlParameter("@ContractAmount",DbType.Guid),
				new SqlParameter("@DownPayment",DbType.Guid),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@Status",SqlDbType.TinyInt),
				new SqlParameter("@NextOperaterId",DbType.Guid),
				new SqlParameter("@NextOperaterAccount",DbType.String),
				new SqlParameter("@NextOperaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreaterAccount",DbType.String),
				new SqlParameter("@SubmitTime",DbType.DateTime),
				new SqlParameter("@AuditOpinion",DbType.String),
                	new SqlParameter("@NextBAOperaterId",DbType.Guid),
				new SqlParameter("@NextBAOperaterAccount",DbType.String),
				new SqlParameter("@NextBAOperaterName",DbType.String),
				new SqlParameter("@BAStatus",SqlDbType.TinyInt),
				new SqlParameter("@SubmitBATime",DbType.DateTime),
				new SqlParameter("@Adulters",DbType.String),
				new SqlParameter("@BAAdulters",DbType.String),
         
				};

                int i = 0;
                sqlparam[i++].Value = InvestmentProjectInfo.ObjectId;
                sqlparam[i++].Value = InvestmentProjectInfo.CustomerName;
                sqlparam[i++].Value = InvestmentProjectInfo.CustomerId;
                sqlparam[i++].Value = InvestmentProjectInfo.ProjectName;
                sqlparam[i++].Value = InvestmentProjectInfo.ProjectOverview;
                sqlparam[i++].Value = InvestmentProjectInfo.SignDate;
                sqlparam[i++].Value = InvestmentProjectInfo.Contact;
                sqlparam[i++].Value = InvestmentProjectInfo.ContactPhone;
                sqlparam[i++].Value = InvestmentProjectInfo.ContractAmount;
                sqlparam[i++].Value = InvestmentProjectInfo.DownPayment;
                sqlparam[i++].Value = InvestmentProjectInfo.Remark;
                sqlparam[i++].Value = InvestmentProjectInfo.Status;
                sqlparam[i++].Value = InvestmentProjectInfo.NextOperaterId;
                sqlparam[i++].Value = InvestmentProjectInfo.NextOperaterAccount;
                sqlparam[i++].Value = InvestmentProjectInfo.NextOperaterName;
                sqlparam[i++].Value = InvestmentProjectInfo.CreateTime;
                sqlparam[i++].Value = InvestmentProjectInfo.CreaterId;
                sqlparam[i++].Value = InvestmentProjectInfo.CreaterName;
                sqlparam[i++].Value = InvestmentProjectInfo.CreaterAccount;
                sqlparam[i++].Value = InvestmentProjectInfo.SubmitTime;
                sqlparam[i++].Value = InvestmentProjectInfo.AuditOpinion;
                sqlparam[i++].Value = InvestmentProjectInfo.NextBAOperaterId;
                sqlparam[i++].Value = InvestmentProjectInfo.NextBAOperaterAccount;
                sqlparam[i++].Value = InvestmentProjectInfo.NextBAOperaterName;
                sqlparam[i++].Value = InvestmentProjectInfo.BAStatus;
                sqlparam[i++].Value = InvestmentProjectInfo.SubmitBATime;
                sqlparam[i++].Value = InvestmentProjectInfo.Adulters;
                sqlparam[i++].Value = InvestmentProjectInfo.BAAdulters;
           
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
        /// dbo.InvestmentProject????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "InvestmentProject_Delete";

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
        /// InvestmentProject ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="InvestmentProjectInfo">InvestmentProjectInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, InvestmentProjectInfo InvestmentProjectInfo)
        {
            try
            {
                //??????
                string strsql = "InvestmentProject_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@CustomerName",DbType.String),
				new SqlParameter("@CustomerId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@ProjectOverview",DbType.String),
				new SqlParameter("@SignDate",DbType.DateTime),
				new SqlParameter("@Contact",DbType.String),
				new SqlParameter("@ContactPhone",DbType.String),
				new SqlParameter("@ContractAmount",DbType.Guid),
				new SqlParameter("@DownPayment",DbType.Guid),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@Status",SqlDbType.TinyInt),
				new SqlParameter("@NextOperaterId",DbType.Guid),
				new SqlParameter("@NextOperaterAccount",DbType.String),
				new SqlParameter("@NextOperaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreaterAccount",DbType.String),
				new SqlParameter("@SubmitTime",DbType.DateTime),
				new SqlParameter("@AuditOpinion",DbType.String),
                		new SqlParameter("@NextBAOperaterId",DbType.Guid),
				new SqlParameter("@NextBAOperaterAccount",DbType.String),
				new SqlParameter("@NextBAOperaterName",DbType.String),
				new SqlParameter("@BAStatus",SqlDbType.TinyInt),
				new SqlParameter("@SubmitBATime",DbType.DateTime),
				new SqlParameter("@Adulters",DbType.String),
				new SqlParameter("@BAAdulters",DbType.String),
                
                };

                int i = 0;
                sqlparam[i++].Value = InvestmentProjectInfo.ObjectId;
                sqlparam[i++].Value = InvestmentProjectInfo.CustomerName;
                sqlparam[i++].Value = InvestmentProjectInfo.CustomerId;
                sqlparam[i++].Value = InvestmentProjectInfo.ProjectName;
                sqlparam[i++].Value = InvestmentProjectInfo.ProjectOverview;
                sqlparam[i++].Value = InvestmentProjectInfo.SignDate;
                sqlparam[i++].Value = InvestmentProjectInfo.Contact;
                sqlparam[i++].Value = InvestmentProjectInfo.ContactPhone;
                sqlparam[i++].Value = InvestmentProjectInfo.ContractAmount;
                sqlparam[i++].Value = InvestmentProjectInfo.DownPayment;
                sqlparam[i++].Value = InvestmentProjectInfo.Remark;
                sqlparam[i++].Value = InvestmentProjectInfo.Status;
                sqlparam[i++].Value = InvestmentProjectInfo.NextOperaterId;
                sqlparam[i++].Value = InvestmentProjectInfo.NextOperaterAccount;
                sqlparam[i++].Value = InvestmentProjectInfo.NextOperaterName;
                sqlparam[i++].Value = InvestmentProjectInfo.CreateTime;
                sqlparam[i++].Value = InvestmentProjectInfo.CreaterId;
                sqlparam[i++].Value = InvestmentProjectInfo.CreaterName;
                sqlparam[i++].Value = InvestmentProjectInfo.CreaterAccount;
                sqlparam[i++].Value = InvestmentProjectInfo.SubmitTime;
                sqlparam[i++].Value = InvestmentProjectInfo.AuditOpinion;
                sqlparam[i++].Value = InvestmentProjectInfo.NextBAOperaterId;
                sqlparam[i++].Value = InvestmentProjectInfo.NextBAOperaterAccount;
                sqlparam[i++].Value = InvestmentProjectInfo.NextBAOperaterName;
                sqlparam[i++].Value = InvestmentProjectInfo.BAStatus;
                sqlparam[i++].Value = InvestmentProjectInfo.SubmitBATime;
                sqlparam[i++].Value = InvestmentProjectInfo.Adulters;
                sqlparam[i++].Value = InvestmentProjectInfo.BAAdulters;
        
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
        /// InvestmentProject ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "InvestmentProject_Search";
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
        ///InvestmentProject ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<InvestmentProjectInfo></returns>
        public List<InvestmentProjectInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<InvestmentProjectInfo> list = new List<InvestmentProjectInfo>();
            InvestmentProjectInfo accountInfo = new InvestmentProjectInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = InvestmentProjectInfoRowToInfo(row);
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
        /// <param name="InvestmentProjectDataRow">InvestmentProjectDataRow</param>
        /// <returns>InvestmentProjectInfo</returns>
        internal InvestmentProjectInfo InvestmentProjectInfoRowToInfo(DataRow InvestmentProjectInfoInfoDataRow)
        {
            InvestmentProjectInfo InvestmentProjectInfoInfo = new InvestmentProjectInfo();
            if (InvestmentProjectInfoInfoDataRow["ObjectId"] != null)
            {
                InvestmentProjectInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "ObjectId"));
            }
            if (InvestmentProjectInfoInfoDataRow["CustomerName"] != null)
            {
                InvestmentProjectInfoInfo.CustomerName = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "CustomerName");
            }
            if (InvestmentProjectInfoInfoDataRow["CustomerId"] != null)
            {
                InvestmentProjectInfoInfo.CustomerId = new Guid(DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "CustomerId"));
            }
            if (InvestmentProjectInfoInfoDataRow["ProjectName"] != null)
            {
                InvestmentProjectInfoInfo.ProjectName = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "ProjectName");
            }
            if (InvestmentProjectInfoInfoDataRow["ProjectOverview"] != null)
            {
                InvestmentProjectInfoInfo.ProjectOverview = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "ProjectOverview");
            }
            if (InvestmentProjectInfoInfoDataRow["SignDate"] != null)
            {
                InvestmentProjectInfoInfo.SignDate = DateTime.Parse(DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "SignDate"));
            }
            if (InvestmentProjectInfoInfoDataRow["Contact"] != null)
            {
                InvestmentProjectInfoInfo.Contact = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "Contact");
            }
            if (InvestmentProjectInfoInfoDataRow["ContactPhone"] != null)
            {
                InvestmentProjectInfoInfo.ContactPhone = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "ContactPhone");
            }
            if (InvestmentProjectInfoInfoDataRow["ContractAmount"] != null)
            {
                InvestmentProjectInfoInfo.ContractAmount = decimal.Parse(DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "ContractAmount"));
            }
            if (InvestmentProjectInfoInfoDataRow["DownPayment"] != null)
            {
                InvestmentProjectInfoInfo.DownPayment = decimal.Parse(DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "DownPayment"));
            }
            if (InvestmentProjectInfoInfoDataRow["Remark"] != null)
            {
                InvestmentProjectInfoInfo.Remark = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "Remark");
            }
            if (InvestmentProjectInfoInfoDataRow["Status"] != null)
            {
                InvestmentProjectInfoInfo.Status = int.Parse(DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "Status"));
            }
            if (InvestmentProjectInfoInfoDataRow["NextOperaterId"] != null)
            {
                InvestmentProjectInfoInfo.NextOperaterId = new Guid(DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "NextOperaterId"));
            }
            if (InvestmentProjectInfoInfoDataRow["NextOperaterAccount"] != null)
            {
                InvestmentProjectInfoInfo.NextOperaterAccount = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "NextOperaterAccount");
            }
            if (InvestmentProjectInfoInfoDataRow["NextOperaterName"] != null)
            {
                InvestmentProjectInfoInfo.NextOperaterName = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "NextOperaterName");
            }
            if (InvestmentProjectInfoInfoDataRow["CreateTime"] != null)
            {
                InvestmentProjectInfoInfo.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "CreateTime"));
            }
            if (InvestmentProjectInfoInfoDataRow["CreaterId"] != null)
            {
                InvestmentProjectInfoInfo.CreaterId = new Guid(DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "CreaterId"));
            }
            if (InvestmentProjectInfoInfoDataRow["CreaterName"] != null)
            {
                InvestmentProjectInfoInfo.CreaterName = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "CreaterName");
            }
            if (InvestmentProjectInfoInfoDataRow["CreaterAccount"] != null)
            {
                InvestmentProjectInfoInfo.CreaterAccount = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "CreaterAccount");
            }
            if (InvestmentProjectInfoInfoDataRow["SubmitTime"] != null)
            {
                InvestmentProjectInfoInfo.SubmitTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "SubmitTime"));
            }
            if (InvestmentProjectInfoInfoDataRow["AuditOpinion"] != null)
            {
                InvestmentProjectInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "AuditOpinion");
            }
            if (InvestmentProjectInfoInfoDataRow["NextBAOperaterId"] != null)
            {
                InvestmentProjectInfoInfo.NextBAOperaterId = new Guid(DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "NextBAOperaterId"));
            }
            if (InvestmentProjectInfoInfoDataRow["NextBAOperaterAccount"] != null)
            {
                InvestmentProjectInfoInfo.NextBAOperaterAccount = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "NextBAOperaterAccount");
            }
            if (InvestmentProjectInfoInfoDataRow["NextBAOperaterName"] != null)
            {
                InvestmentProjectInfoInfo.NextBAOperaterName = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "NextBAOperaterName");
            }
            if (InvestmentProjectInfoInfoDataRow["BAStatus"] != null)
            {
                InvestmentProjectInfoInfo.BAStatus = int.Parse(DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "BAStatus"));
            }
            if (InvestmentProjectInfoInfoDataRow["SubmitBATime"] != null)
            {
                InvestmentProjectInfoInfo.SubmitBATime = DateTime.Parse(DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "SubmitBATime"));
            }
            if (InvestmentProjectInfoInfoDataRow["Adulters"] != null)
            {
                InvestmentProjectInfoInfo.Adulters = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "Adulters");
            }
            if (InvestmentProjectInfoInfoDataRow["BAAdulters"] != null)
            {
                InvestmentProjectInfoInfo.BAAdulters = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "BAAdulters");
            }
         
            return InvestmentProjectInfoInfo;
        }
        #endregion
    }
}
