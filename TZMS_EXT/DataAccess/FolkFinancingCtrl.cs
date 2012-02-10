//----------------------------------------------------------------------------------------------------
//???:	FolkFinancing ???
//??:  	???? dbo.FolkFinancing ? ??????????
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
    /// FolkFinancingCtrl
    /// programmer:
    /// </summary>
    public class FolkFinancingCtrl
    { 
        #region ????
		 
		/// <summary>
        /// FolkFinancingCtrl??????
        /// </summary>
        public FolkFinancingCtrl()
        {
            //ToDo
        }
		
		#endregion
        
		#region ???????
		
		/// <summary>
        /// ??dbo.FolkFinancing????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="FolkFinancingInfo">FolkFinancingInfo??</param>
		/// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, FolkFinancingInfo FolkFinancingInfo)
        {
            try
            {
				//??????
                string strsql = "FolkFinancing_Add"; 
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@BorrowerNameA",DbType.String),
				new SqlParameter("@BorrowerAId",DbType.Guid),
				new SqlParameter("@Lenders",DbType.String),
				new SqlParameter("@Guarantee",DbType.String),
				new SqlParameter("@LoanAmount",DbType.Guid),
				new SqlParameter("@LoanDate",DbType.DateTime),
				new SqlParameter("@DueDateForPay",DbType.Int32),
				new SqlParameter("@Collateral",DbType.String),
				new SqlParameter("@BorrowingCost",DbType.Guid),
				new SqlParameter("@ContactPhone",DbType.String),
				new SqlParameter("@LoanType",DbType.String),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@NextOperaterId",DbType.Guid),
				new SqlParameter("@NextOperaterAccount",DbType.String),
				new SqlParameter("@NextOperaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreaterAccount",DbType.String),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@SubmitTime",DbType.DateTime),
				new SqlParameter("@Status",SqlDbType.TinyInt),
				new SqlParameter("@NextBAOperaterId",DbType.Guid),
				new SqlParameter("@NextBAOperaterAccount",DbType.String),
				new SqlParameter("@NextBAOperaterName",DbType.String),
				new SqlParameter("@BAStatus",SqlDbType.TinyInt),
				new SqlParameter("@SubmitBATime",DbType.DateTime),
				new SqlParameter("@Adulters",DbType.String),
				new SqlParameter("@BAAdulters",DbType.String),
                   	new SqlParameter("@LoanTimeLimit",DbType.String),
                            	new SqlParameter("@InterestType",DbType.String),
                                   	new SqlParameter("@Cash",DbType.Decimal),
                                	new SqlParameter("@TransferAccount",DbType.Decimal),
				};
				
				int i=0;
				sqlparam[i++].Value = FolkFinancingInfo.ObjectId; 
				sqlparam[i++].Value = FolkFinancingInfo.BorrowerNameA; 
				sqlparam[i++].Value = FolkFinancingInfo.BorrowerAId; 
				sqlparam[i++].Value = FolkFinancingInfo.Lenders; 
				sqlparam[i++].Value = FolkFinancingInfo.Guarantee; 
				sqlparam[i++].Value = FolkFinancingInfo.LoanAmount; 
				sqlparam[i++].Value = FolkFinancingInfo.LoanDate; 
				sqlparam[i++].Value = FolkFinancingInfo.DueDateForPay; 
				sqlparam[i++].Value = FolkFinancingInfo.Collateral; 
				sqlparam[i++].Value = FolkFinancingInfo.BorrowingCost; 
				sqlparam[i++].Value = FolkFinancingInfo.ContactPhone; 
				sqlparam[i++].Value = FolkFinancingInfo.LoanType; 
				sqlparam[i++].Value = FolkFinancingInfo.Remark; 
				sqlparam[i++].Value = FolkFinancingInfo.NextOperaterId; 
				sqlparam[i++].Value = FolkFinancingInfo.NextOperaterAccount; 
				sqlparam[i++].Value = FolkFinancingInfo.NextOperaterName; 
				sqlparam[i++].Value = FolkFinancingInfo.CreateTime; 
				sqlparam[i++].Value = FolkFinancingInfo.CreaterId; 
				sqlparam[i++].Value = FolkFinancingInfo.CreaterName; 
				sqlparam[i++].Value = FolkFinancingInfo.CreaterAccount; 
				sqlparam[i++].Value = FolkFinancingInfo.AuditOpinion; 
				sqlparam[i++].Value = FolkFinancingInfo.SubmitTime; 
				sqlparam[i++].Value = FolkFinancingInfo.Status; 
				sqlparam[i++].Value = FolkFinancingInfo.NextBAOperaterId; 
				sqlparam[i++].Value = FolkFinancingInfo.NextBAOperaterAccount; 
				sqlparam[i++].Value = FolkFinancingInfo.NextBAOperaterName; 
				sqlparam[i++].Value = FolkFinancingInfo.BAStatus; 
				sqlparam[i++].Value = FolkFinancingInfo.SubmitBATime; 
				sqlparam[i++].Value = FolkFinancingInfo.Adulters; 
				sqlparam[i++].Value = FolkFinancingInfo.BAAdulters;
                sqlparam[i++].Value = FolkFinancingInfo.LoanTimeLimit;
                sqlparam[i++].Value = FolkFinancingInfo.InterestType;
                sqlparam[i++].Value = FolkFinancingInfo.Cash;
                sqlparam[i++].Value = FolkFinancingInfo.TransferAccount;
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
        /// dbo.FolkFinancing????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "FolkFinancing_Delete";

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
        /// FolkFinancing ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="FolkFinancingInfo">FolkFinancingInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, FolkFinancingInfo FolkFinancingInfo)
        {
            try
            {
                //??????
                string strsql = "FolkFinancing_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@BorrowerNameA",DbType.String),
				new SqlParameter("@BorrowerAId",DbType.Guid),
				new SqlParameter("@Lenders",DbType.String),
				new SqlParameter("@Guarantee",DbType.String),
				new SqlParameter("@LoanAmount",DbType.Guid),
				new SqlParameter("@LoanDate",DbType.DateTime),
				new SqlParameter("@DueDateForPay",DbType.Int32),
				new SqlParameter("@Collateral",DbType.String),
				new SqlParameter("@BorrowingCost",DbType.Guid),
				new SqlParameter("@ContactPhone",DbType.String),
				new SqlParameter("@LoanType",DbType.String),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@NextOperaterId",DbType.Guid),
				new SqlParameter("@NextOperaterAccount",DbType.String),
				new SqlParameter("@NextOperaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreaterAccount",DbType.String),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@SubmitTime",DbType.DateTime),
				new SqlParameter("@Status",SqlDbType.TinyInt),
				new SqlParameter("@NextBAOperaterId",DbType.Guid),
				new SqlParameter("@NextBAOperaterAccount",DbType.String),
				new SqlParameter("@NextBAOperaterName",DbType.String),
				new SqlParameter("@BAStatus",SqlDbType.TinyInt),
				new SqlParameter("@SubmitBATime",DbType.DateTime),
				new SqlParameter("@Adulters",DbType.String),
				new SqlParameter("@BAAdulters",DbType.String),
                   	new SqlParameter("@LoanTimeLimit",DbType.String),
                         	new SqlParameter("@InterestType",DbType.String),
                               	new SqlParameter("@Cash",DbType.Decimal),
                                	new SqlParameter("@TransferAccount",DbType.Decimal),
                };

                int i = 0;
				sqlparam[i++].Value = FolkFinancingInfo.ObjectId; 
				sqlparam[i++].Value = FolkFinancingInfo.BorrowerNameA; 
				sqlparam[i++].Value = FolkFinancingInfo.BorrowerAId; 
				sqlparam[i++].Value = FolkFinancingInfo.Lenders; 
				sqlparam[i++].Value = FolkFinancingInfo.Guarantee; 
				sqlparam[i++].Value = FolkFinancingInfo.LoanAmount; 
				sqlparam[i++].Value = FolkFinancingInfo.LoanDate; 
				sqlparam[i++].Value = FolkFinancingInfo.DueDateForPay; 
				sqlparam[i++].Value = FolkFinancingInfo.Collateral; 
				sqlparam[i++].Value = FolkFinancingInfo.BorrowingCost; 
				sqlparam[i++].Value = FolkFinancingInfo.ContactPhone; 
				sqlparam[i++].Value = FolkFinancingInfo.LoanType; 
				sqlparam[i++].Value = FolkFinancingInfo.Remark; 
				sqlparam[i++].Value = FolkFinancingInfo.NextOperaterId; 
				sqlparam[i++].Value = FolkFinancingInfo.NextOperaterAccount; 
				sqlparam[i++].Value = FolkFinancingInfo.NextOperaterName; 
				sqlparam[i++].Value = FolkFinancingInfo.CreateTime; 
				sqlparam[i++].Value = FolkFinancingInfo.CreaterId; 
				sqlparam[i++].Value = FolkFinancingInfo.CreaterName; 
				sqlparam[i++].Value = FolkFinancingInfo.CreaterAccount; 
				sqlparam[i++].Value = FolkFinancingInfo.AuditOpinion; 
				sqlparam[i++].Value = FolkFinancingInfo.SubmitTime; 
				sqlparam[i++].Value = FolkFinancingInfo.Status; 
				sqlparam[i++].Value = FolkFinancingInfo.NextBAOperaterId; 
				sqlparam[i++].Value = FolkFinancingInfo.NextBAOperaterAccount; 
				sqlparam[i++].Value = FolkFinancingInfo.NextBAOperaterName; 
				sqlparam[i++].Value = FolkFinancingInfo.BAStatus; 
				sqlparam[i++].Value = FolkFinancingInfo.SubmitBATime; 
				sqlparam[i++].Value = FolkFinancingInfo.Adulters; 
				sqlparam[i++].Value = FolkFinancingInfo.BAAdulters;
                sqlparam[i++].Value = FolkFinancingInfo.LoanTimeLimit;
                sqlparam[i++].Value = FolkFinancingInfo.InterestType;
                sqlparam[i++].Value = FolkFinancingInfo.Cash;
                sqlparam[i++].Value = FolkFinancingInfo.TransferAccount;
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
        /// FolkFinancing ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName,string condition)
        {
            try
            {
				//??????
                string strsql = "FolkFinancing_Search";
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
        ///FolkFinancing ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<FolkFinancingInfo></returns>
        public List<FolkFinancingInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<FolkFinancingInfo> list = new List<FolkFinancingInfo>();
            FolkFinancingInfo accountInfo = new FolkFinancingInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = FolkFinancingInfoRowToInfo(row);
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
        /// <param name="FolkFinancingDataRow">FolkFinancingDataRow</param>
        /// <returns>FolkFinancingInfo</returns>
        internal FolkFinancingInfo FolkFinancingInfoRowToInfo(DataRow FolkFinancingInfoInfoDataRow)
        {
			FolkFinancingInfo FolkFinancingInfoInfo=new FolkFinancingInfo();
			if(FolkFinancingInfoInfoDataRow["ObjectId"]!=null)
			{
				FolkFinancingInfoInfo.ObjectId=new Guid(DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"ObjectId"));
			}
			if(FolkFinancingInfoInfoDataRow["BorrowerNameA"]!=null)
			{
				FolkFinancingInfoInfo.BorrowerNameA=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"BorrowerNameA");
			}
			if(FolkFinancingInfoInfoDataRow["BorrowerAId"]!=null)
			{
				FolkFinancingInfoInfo.BorrowerAId=new Guid(DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"BorrowerAId"));
			}
			if(FolkFinancingInfoInfoDataRow["Lenders"]!=null)
			{
				FolkFinancingInfoInfo.Lenders=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"Lenders");
			}
			if(FolkFinancingInfoInfoDataRow["Guarantee"]!=null)
			{
				FolkFinancingInfoInfo.Guarantee=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"Guarantee");
			}
			if(FolkFinancingInfoInfoDataRow["LoanAmount"]!=null)
			{
				FolkFinancingInfoInfo.LoanAmount= decimal.Parse( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"LoanAmount"));
			}
			if(FolkFinancingInfoInfoDataRow["LoanDate"]!=null)
			{
				FolkFinancingInfoInfo.LoanDate=DateTime.Parse( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"LoanDate"));
			}
			if(FolkFinancingInfoInfoDataRow["DueDateForPay"]!=null)
			{
				FolkFinancingInfoInfo.DueDateForPay=int.Parse(DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"DueDateForPay"));
			}
			if(FolkFinancingInfoInfoDataRow["Collateral"]!=null)
			{
				FolkFinancingInfoInfo.Collateral=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"Collateral");
			}
			if(FolkFinancingInfoInfoDataRow["BorrowingCost"]!=null)
			{
				FolkFinancingInfoInfo.BorrowingCost= decimal.Parse( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"BorrowingCost"));
			}
			if(FolkFinancingInfoInfoDataRow["ContactPhone"]!=null)
			{
				FolkFinancingInfoInfo.ContactPhone=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"ContactPhone");
			}
			if(FolkFinancingInfoInfoDataRow["LoanType"]!=null)
			{
				FolkFinancingInfoInfo.LoanType=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"LoanType");
			}
			if(FolkFinancingInfoInfoDataRow["Remark"]!=null)
			{
				FolkFinancingInfoInfo.Remark=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"Remark");
			}
			if(FolkFinancingInfoInfoDataRow["NextOperaterId"]!=null)
			{
				FolkFinancingInfoInfo.NextOperaterId=new Guid(DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"NextOperaterId"));
			}
			if(FolkFinancingInfoInfoDataRow["NextOperaterAccount"]!=null)
			{
				FolkFinancingInfoInfo.NextOperaterAccount=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"NextOperaterAccount");
			}
			if(FolkFinancingInfoInfoDataRow["NextOperaterName"]!=null)
			{
				FolkFinancingInfoInfo.NextOperaterName=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"NextOperaterName");
			}
			if(FolkFinancingInfoInfoDataRow["CreateTime"]!=null)
			{
				FolkFinancingInfoInfo.CreateTime=DateTime.Parse( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"CreateTime"));
			}
			if(FolkFinancingInfoInfoDataRow["CreaterId"]!=null)
			{
				FolkFinancingInfoInfo.CreaterId=new Guid(DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"CreaterId"));
			}
			if(FolkFinancingInfoInfoDataRow["CreaterName"]!=null)
			{
				FolkFinancingInfoInfo.CreaterName=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"CreaterName");
			}
			if(FolkFinancingInfoInfoDataRow["CreaterAccount"]!=null)
			{
				FolkFinancingInfoInfo.CreaterAccount=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"CreaterAccount");
			}
			if(FolkFinancingInfoInfoDataRow["AuditOpinion"]!=null)
			{
				FolkFinancingInfoInfo.AuditOpinion=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"AuditOpinion");
			}
			if(FolkFinancingInfoInfoDataRow["SubmitTime"]!=null)
			{
				FolkFinancingInfoInfo.SubmitTime=DateTime.Parse(DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"SubmitTime"));
			}
			if(FolkFinancingInfoInfoDataRow["Status"]!=null)
			{
				FolkFinancingInfoInfo.Status=int.Parse(DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"Status"));
			}
			if(FolkFinancingInfoInfoDataRow["NextBAOperaterId"]!=null)
			{
				FolkFinancingInfoInfo.NextBAOperaterId=new Guid(DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"NextBAOperaterId"));
			}
			if(FolkFinancingInfoInfoDataRow["NextBAOperaterAccount"]!=null)
			{
				FolkFinancingInfoInfo.NextBAOperaterAccount=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"NextBAOperaterAccount");
			}
			if(FolkFinancingInfoInfoDataRow["NextBAOperaterName"]!=null)
			{
				FolkFinancingInfoInfo.NextBAOperaterName=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"NextBAOperaterName");
			}
			if(FolkFinancingInfoInfoDataRow["BAStatus"]!=null)
			{
				FolkFinancingInfoInfo.BAStatus=int.Parse(DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"BAStatus"));
			}
			if(FolkFinancingInfoInfoDataRow["SubmitBATime"]!=null)
			{
				FolkFinancingInfoInfo.SubmitBATime=DateTime.Parse( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"SubmitBATime"));
			}
			if(FolkFinancingInfoInfoDataRow["Adulters"]!=null)
			{
				FolkFinancingInfoInfo.Adulters=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"Adulters");
			}
			if(FolkFinancingInfoInfoDataRow["BAAdulters"]!=null)
			{
				FolkFinancingInfoInfo.BAAdulters=DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow,"BAAdulters");
			}
            if (FolkFinancingInfoInfoDataRow["LoanTimeLimit"] != null)
            {
                FolkFinancingInfoInfo.LoanTimeLimit = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "LoanTimeLimit");
            }
            if (FolkFinancingInfoInfoDataRow["InterestType"] != null)
            {
                FolkFinancingInfoInfo.InterestType = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "InterestType");
            }
            FolkFinancingInfoInfo.Cash = 0;
            if (FolkFinancingInfoInfoDataRow["Cash"] != null && DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "Cash")!="")
            {
                FolkFinancingInfoInfo.Cash = Decimal.Parse(DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "Cash"));
            }
            FolkFinancingInfoInfo.TransferAccount = 0;
            if (FolkFinancingInfoInfoDataRow["TransferAccount"] != null && DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "TransferAccount")!="")
            {
                FolkFinancingInfoInfo.TransferAccount = Decimal.Parse(DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "TransferAccount"));
            }
            return FolkFinancingInfoInfo;
        }
		#endregion
    }
}
