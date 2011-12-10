//----------------------------------------------------------------------------------------------------
//???:	BankLoan ???
//??:  	???? dbo.BankLoan ? ??????????
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
    /// BankLoanCtrl
    /// programmer:
    /// </summary>
    public class BankLoanCtrl
    { 
        #region ????
		 
		/// <summary>
        /// BankLoanCtrl??????
        /// </summary>
        public BankLoanCtrl()
        {
            //ToDo
        }
		
		#endregion
        
		#region ???????
		
		/// <summary>
        /// ??dbo.BankLoan????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="BankLoanInfo">BankLoanInfo??</param>
		/// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, BankLoanInfo BankLoanInfo)
        {
            try
            {
				//??????
                string strsql = "BankLoan_Add"; 
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@CustomerName",DbType.String),
				new SqlParameter("@CustomerId",DbType.Guid),
				new SqlParameter("@LoanCompany",DbType.String),
				new SqlParameter("@LoanAmount",DbType.Guid),
				new SqlParameter("@LoanFee",DbType.Guid),
				new SqlParameter("@CollateralCompany",DbType.String),
				new SqlParameter("@SignDate",DbType.DateTime),
				new SqlParameter("@DownPayment",DbType.Guid),
				new SqlParameter("@Contact",DbType.String),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@NextOperaterId",DbType.Guid),
				new SqlParameter("@NextOperaterAccount",DbType.String),
				new SqlParameter("@NextOperaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreaterAccount",DbType.String),
				new SqlParameter("@SubmitTime",DbType.DateTime),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@Status",SqlDbType.TinyInt),
				new SqlParameter("@NextBAOperaterId",DbType.Guid),
				new SqlParameter("@NextBAOperaterAccount",DbType.String),
				new SqlParameter("@NextBAOperaterName",DbType.String),
				new SqlParameter("@BAStatus",SqlDbType.TinyInt),
				new SqlParameter("@SubmitBATime",DbType.DateTime),
				new SqlParameter("@Adulters",DbType.String),
				new SqlParameter("@BAAdulters",DbType.String),
				};
				
				int i=0;
				sqlparam[i++].Value = BankLoanInfo.ObjectId; 
				sqlparam[i++].Value = BankLoanInfo.CustomerName; 
				sqlparam[i++].Value = BankLoanInfo.CustomerId; 
				sqlparam[i++].Value = BankLoanInfo.LoanCompany; 
				sqlparam[i++].Value = BankLoanInfo.LoanAmount; 
				sqlparam[i++].Value = BankLoanInfo.LoanFee; 
				sqlparam[i++].Value = BankLoanInfo.CollateralCompany; 
				sqlparam[i++].Value = BankLoanInfo.SignDate; 
				sqlparam[i++].Value = BankLoanInfo.DownPayment; 
				sqlparam[i++].Value = BankLoanInfo.Contact; 
				sqlparam[i++].Value = BankLoanInfo.Remark; 
				sqlparam[i++].Value = BankLoanInfo.NextOperaterId; 
				sqlparam[i++].Value = BankLoanInfo.NextOperaterAccount; 
				sqlparam[i++].Value = BankLoanInfo.NextOperaterName; 
				sqlparam[i++].Value = BankLoanInfo.CreateTime; 
				sqlparam[i++].Value = BankLoanInfo.CreaterId; 
				sqlparam[i++].Value = BankLoanInfo.CreaterName; 
				sqlparam[i++].Value = BankLoanInfo.CreaterAccount; 
				sqlparam[i++].Value = BankLoanInfo.SubmitTime; 
				sqlparam[i++].Value = BankLoanInfo.AuditOpinion; 
				sqlparam[i++].Value = BankLoanInfo.Status; 
				sqlparam[i++].Value = BankLoanInfo.NextBAOperaterId; 
				sqlparam[i++].Value = BankLoanInfo.NextBAOperaterAccount; 
				sqlparam[i++].Value = BankLoanInfo.NextBAOperaterName; 
				sqlparam[i++].Value = BankLoanInfo.BAStatus; 
				sqlparam[i++].Value = BankLoanInfo.SubmitBATime; 
				sqlparam[i++].Value = BankLoanInfo.Adulters; 
				sqlparam[i++].Value = BankLoanInfo.BAAdulters; 
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
        /// dbo.BankLoan????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "BankLoan_Delete";

                SqlParameter[] sqlparam =
				{
					new SqlParameter ( "@ObjectID", SqlDbType.NVarChar )
				};
                int i = 0; 
                sqlparam[i++].Value =  objectID ; 

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
        /// BankLoan ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="BankLoanInfo">BankLoanInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, BankLoanInfo BankLoanInfo)
        {
            try
            {
                //??????
                string strsql = "BankLoan_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@CustomerName",DbType.String),
				new SqlParameter("@CustomerId",DbType.Guid),
				new SqlParameter("@LoanCompany",DbType.String),
				new SqlParameter("@LoanAmount",DbType.Guid),
				new SqlParameter("@LoanFee",DbType.Guid),
				new SqlParameter("@CollateralCompany",DbType.String),
				new SqlParameter("@SignDate",DbType.DateTime),
				new SqlParameter("@DownPayment",DbType.Guid),
				new SqlParameter("@Contact",DbType.String),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@NextOperaterId",DbType.Guid),
				new SqlParameter("@NextOperaterAccount",DbType.String),
				new SqlParameter("@NextOperaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreaterAccount",DbType.String),
				new SqlParameter("@SubmitTime",DbType.DateTime),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@Status",SqlDbType.TinyInt),
				new SqlParameter("@NextBAOperaterId",DbType.Guid),
				new SqlParameter("@NextBAOperaterAccount",DbType.String),
				new SqlParameter("@NextBAOperaterName",DbType.String),
				new SqlParameter("@BAStatus",SqlDbType.TinyInt),
				new SqlParameter("@SubmitBATime",DbType.DateTime),
				new SqlParameter("@Adulters",DbType.String),
				new SqlParameter("@BAAdulters",DbType.String),
                };

                int i = 0;
				sqlparam[i++].Value = BankLoanInfo.ObjectId; 
				sqlparam[i++].Value = BankLoanInfo.CustomerName; 
				sqlparam[i++].Value = BankLoanInfo.CustomerId; 
				sqlparam[i++].Value = BankLoanInfo.LoanCompany; 
				sqlparam[i++].Value = BankLoanInfo.LoanAmount; 
				sqlparam[i++].Value = BankLoanInfo.LoanFee; 
				sqlparam[i++].Value = BankLoanInfo.CollateralCompany; 
				sqlparam[i++].Value = BankLoanInfo.SignDate; 
				sqlparam[i++].Value = BankLoanInfo.DownPayment; 
				sqlparam[i++].Value = BankLoanInfo.Contact; 
				sqlparam[i++].Value = BankLoanInfo.Remark; 
				sqlparam[i++].Value = BankLoanInfo.NextOperaterId; 
				sqlparam[i++].Value = BankLoanInfo.NextOperaterAccount; 
				sqlparam[i++].Value = BankLoanInfo.NextOperaterName; 
				sqlparam[i++].Value = BankLoanInfo.CreateTime; 
				sqlparam[i++].Value = BankLoanInfo.CreaterId; 
				sqlparam[i++].Value = BankLoanInfo.CreaterName; 
				sqlparam[i++].Value = BankLoanInfo.CreaterAccount; 
				sqlparam[i++].Value = BankLoanInfo.SubmitTime; 
				sqlparam[i++].Value = BankLoanInfo.AuditOpinion; 
				sqlparam[i++].Value = BankLoanInfo.Status; 
				sqlparam[i++].Value = BankLoanInfo.NextBAOperaterId; 
				sqlparam[i++].Value = BankLoanInfo.NextBAOperaterAccount; 
				sqlparam[i++].Value = BankLoanInfo.NextBAOperaterName; 
				sqlparam[i++].Value = BankLoanInfo.BAStatus; 
				sqlparam[i++].Value = BankLoanInfo.SubmitBATime; 
				sqlparam[i++].Value = BankLoanInfo.Adulters; 
				sqlparam[i++].Value = BankLoanInfo.BAAdulters; 
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
        /// BankLoan ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName,string condition)
        {
            try
            {
				//??????
                string strsql = "BankLoan_Search";
				SqlParameter[] sqlparam =
                {
					new SqlParameter("@Condition",SqlDbType.NVarChar), 
                };

                int i = 0;
				sqlparam[i++].Value =condition;
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
        ///BankLoan ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<BankLoanInfo></returns>
        public List<BankLoanInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<BankLoanInfo> list = new List<BankLoanInfo>();
            BankLoanInfo accountInfo = new BankLoanInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = BankLoanInfoRowToInfo(row);
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
        /// <param name="BankLoanDataRow">BankLoanDataRow</param>
        /// <returns>BankLoanInfo</returns>
        internal BankLoanInfo BankLoanInfoRowToInfo(DataRow BankLoanInfoInfoDataRow)
        {
			BankLoanInfo BankLoanInfoInfo=new BankLoanInfo();
			if(BankLoanInfoInfoDataRow["ObjectId"]!=null)
			{
				BankLoanInfoInfo.ObjectId=new Guid(DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"ObjectId"));
			}
			if(BankLoanInfoInfoDataRow["CustomerName"]!=null)
			{
				BankLoanInfoInfo.CustomerName=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"CustomerName");
			}
			if(BankLoanInfoInfoDataRow["CustomerId"]!=null)
			{
				BankLoanInfoInfo.CustomerId=new Guid(DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"CustomerId"));
			}
			if(BankLoanInfoInfoDataRow["LoanCompany"]!=null)
			{
				BankLoanInfoInfo.LoanCompany=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"LoanCompany");
			}
			if(BankLoanInfoInfoDataRow["LoanAmount"]!=null)
			{
				BankLoanInfoInfo.LoanAmount=decimal.Parse( DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"LoanAmount"));
			}
			if(BankLoanInfoInfoDataRow["LoanFee"]!=null)
			{
				BankLoanInfoInfo.LoanFee=decimal.Parse( DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"LoanFee"));
			}
			if(BankLoanInfoInfoDataRow["CollateralCompany"]!=null)
			{
				BankLoanInfoInfo.CollateralCompany=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"CollateralCompany");
			}
			if(BankLoanInfoInfoDataRow["SignDate"]!=null)
			{
				BankLoanInfoInfo.SignDate=DateTime.Parse( DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"SignDate"));
			}
			if(BankLoanInfoInfoDataRow["DownPayment"]!=null)
			{
				BankLoanInfoInfo.DownPayment=decimal.Parse( DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"DownPayment"));
			}
			if(BankLoanInfoInfoDataRow["Contact"]!=null)
			{
				BankLoanInfoInfo.Contact=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"Contact");
			}
			if(BankLoanInfoInfoDataRow["Remark"]!=null)
			{
				BankLoanInfoInfo.Remark=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"Remark");
			}
			if(BankLoanInfoInfoDataRow["NextOperaterId"]!=null)
			{
				BankLoanInfoInfo.NextOperaterId=new Guid(DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"NextOperaterId"));
			}
			if(BankLoanInfoInfoDataRow["NextOperaterAccount"]!=null)
			{
				BankLoanInfoInfo.NextOperaterAccount=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"NextOperaterAccount");
			}
			if(BankLoanInfoInfoDataRow["NextOperaterName"]!=null)
			{
				BankLoanInfoInfo.NextOperaterName=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"NextOperaterName");
			}
			if(BankLoanInfoInfoDataRow["CreateTime"]!=null)
			{
				BankLoanInfoInfo.CreateTime=DateTime.Parse( DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"CreateTime"));
			}
			if(BankLoanInfoInfoDataRow["CreaterId"]!=null)
			{
				BankLoanInfoInfo.CreaterId=new Guid(DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"CreaterId"));
			}
			if(BankLoanInfoInfoDataRow["CreaterName"]!=null)
			{
				BankLoanInfoInfo.CreaterName=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"CreaterName");
			}
			if(BankLoanInfoInfoDataRow["CreaterAccount"]!=null)
			{
				BankLoanInfoInfo.CreaterAccount=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"CreaterAccount");
			}
			if(BankLoanInfoInfoDataRow["SubmitTime"]!=null)
			{
				BankLoanInfoInfo.SubmitTime=DateTime.Parse( DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"SubmitTime"));
			}
			if(BankLoanInfoInfoDataRow["AuditOpinion"]!=null)
			{
				BankLoanInfoInfo.AuditOpinion=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"AuditOpinion");
			}
			if(BankLoanInfoInfoDataRow["Status"]!=null)
			{
				BankLoanInfoInfo.Status=int.Parse(DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"Status"));
			}
			if(BankLoanInfoInfoDataRow["NextBAOperaterId"]!=null)
			{
				BankLoanInfoInfo.NextBAOperaterId=new Guid(DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"NextBAOperaterId"));
			}
			if(BankLoanInfoInfoDataRow["NextBAOperaterAccount"]!=null)
			{
				BankLoanInfoInfo.NextBAOperaterAccount=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"NextBAOperaterAccount");
			}
			if(BankLoanInfoInfoDataRow["NextBAOperaterName"]!=null)
			{
				BankLoanInfoInfo.NextBAOperaterName=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"NextBAOperaterName");
			}
			if(BankLoanInfoInfoDataRow["BAStatus"]!=null)
			{
				BankLoanInfoInfo.BAStatus=int.Parse(DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"BAStatus"));
			}
			if(BankLoanInfoInfoDataRow["SubmitBATime"]!=null)
			{
				BankLoanInfoInfo.SubmitBATime=DateTime.Parse( DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"SubmitBATime"));
			}
			if(BankLoanInfoInfoDataRow["Adulters"]!=null)
			{
				BankLoanInfoInfo.Adulters=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"Adulters");
			}
			if(BankLoanInfoInfoDataRow["BAAdulters"]!=null)
			{
				BankLoanInfoInfo.BAAdulters=DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow,"BAAdulters");
			}

            return BankLoanInfoInfo;
        }
		#endregion
    }
}
