//----------------------------------------------------------------------------------------------------
//???:	InvestmentLoan ???
//??:  	???? dbo.InvestmentLoan ? ??????????
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
    /// InvestmentLoanCtrl
    /// programmer:
    /// </summary>
    public class InvestmentLoanCtrl
    {
        #region ????

        /// <summary>
        /// InvestmentLoanCtrl??????
        /// </summary>
        public InvestmentLoanCtrl()
        {
            //ToDo
        }

        #endregion

        #region ???????

        /// <summary>
        /// ??dbo.InvestmentLoan????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="InvestmentLoanInfo">InvestmentLoanInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int Insert(string boName, InvestmentLoanInfo InvestmentLoanInfo)
        {
            try
            {
                //??????
                string strsql = "InvestmentLoan_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@ProjectOverview",DbType.String),
				new SqlParameter("@BorrowerNameA",DbType.String),
				new SqlParameter("@BorrowerAId",DbType.Guid),
				new SqlParameter("@PayerBName",DbType.String),
				new SqlParameter("@BorrowerPhone",DbType.String),
				new SqlParameter("@LoanAmount",DbType.Guid),
				new SqlParameter("@LoanDate",DbType.DateTime),
				new SqlParameter("@Collateral",DbType.String),
				new SqlParameter("@Guarantor",DbType.String),
				new SqlParameter("@GuarantorPhone",DbType.String),
				new SqlParameter("@RateOfReturn",DbType.String),
				new SqlParameter("@DueDateForPay",DbType.Int32),
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
				new SqlParameter("@AccountingRemark",DbType.String),
				new SqlParameter("@DueDateForReceivables",DbType.Int32),
				new SqlParameter("@ReceivablesRemindInfo",DbType.String),
				new SqlParameter("@NextBAOperaterId",DbType.Guid),
				new SqlParameter("@NextBAOperaterAccount",DbType.String),
				new SqlParameter("@NextBAOperaterName",DbType.String),
				new SqlParameter("@BAStatus",SqlDbType.TinyInt),
				new SqlParameter("@SubmitBATime",DbType.DateTime),
				new SqlParameter("@Adulters",DbType.String),
				new SqlParameter("@BAAdulters",DbType.String),
                	new SqlParameter("@LoanTimeLimit",DbType.String),
                    new SqlParameter("@LoanType",DbType.String),
                       new SqlParameter("@Imprest",DbType.String),
                          new SqlParameter("@Penalbond",DbType.String),
                             new SqlParameter("@OpationRemark",DbType.String),
                             	new SqlParameter("@Cash",DbType.Decimal),
                                	new SqlParameter("@TransferAccount",DbType.Decimal),
				};

                int i = 0;
                sqlparam[i++].Value = InvestmentLoanInfo.ObjectId;
                sqlparam[i++].Value = InvestmentLoanInfo.ProjectName;
                sqlparam[i++].Value = InvestmentLoanInfo.ProjectOverview;
                sqlparam[i++].Value = InvestmentLoanInfo.BorrowerNameA;
                sqlparam[i++].Value = InvestmentLoanInfo.BorrowerAId;
                sqlparam[i++].Value = InvestmentLoanInfo.PayerBName;
                sqlparam[i++].Value = InvestmentLoanInfo.BorrowerPhone;
                sqlparam[i++].Value = InvestmentLoanInfo.LoanAmount;
                sqlparam[i++].Value = InvestmentLoanInfo.LoanDate;
                sqlparam[i++].Value = InvestmentLoanInfo.Collateral;
                sqlparam[i++].Value = InvestmentLoanInfo.Guarantor;
                sqlparam[i++].Value = InvestmentLoanInfo.GuarantorPhone;
                sqlparam[i++].Value = InvestmentLoanInfo.RateOfReturn;
                sqlparam[i++].Value = InvestmentLoanInfo.DueDateForPay;
                sqlparam[i++].Value = InvestmentLoanInfo.Remark;
                sqlparam[i++].Value = InvestmentLoanInfo.Status;
                sqlparam[i++].Value = InvestmentLoanInfo.NextOperaterId;
                sqlparam[i++].Value = InvestmentLoanInfo.NextOperaterAccount;
                sqlparam[i++].Value = InvestmentLoanInfo.NextOperaterName;
                sqlparam[i++].Value = InvestmentLoanInfo.CreateTime;
                sqlparam[i++].Value = InvestmentLoanInfo.CreaterId;
                sqlparam[i++].Value = InvestmentLoanInfo.CreaterName;
                sqlparam[i++].Value = InvestmentLoanInfo.CreaterAccount;
                sqlparam[i++].Value = InvestmentLoanInfo.SubmitTime;
                sqlparam[i++].Value = InvestmentLoanInfo.AuditOpinion;
                sqlparam[i++].Value = InvestmentLoanInfo.AccountingRemark;
                sqlparam[i++].Value = InvestmentLoanInfo.DueDateForReceivables;
                sqlparam[i++].Value = InvestmentLoanInfo.ReceivablesRemindInfo;
                sqlparam[i++].Value = InvestmentLoanInfo.NextBAOperaterId;
                sqlparam[i++].Value = InvestmentLoanInfo.NextBAOperaterAccount;
                sqlparam[i++].Value = InvestmentLoanInfo.NextBAOperaterName;
                sqlparam[i++].Value = InvestmentLoanInfo.BAStatus;
                sqlparam[i++].Value = InvestmentLoanInfo.SubmitBATime;
                sqlparam[i++].Value = InvestmentLoanInfo.Adulters;
                sqlparam[i++].Value = InvestmentLoanInfo.BAAdulters;
                sqlparam[i++].Value = InvestmentLoanInfo.LoanTimeLimit;
                sqlparam[i++].Value = InvestmentLoanInfo.LoanType;
                sqlparam[i++].Value = InvestmentLoanInfo.Imprest;
                sqlparam[i++].Value = InvestmentLoanInfo.Penalbond;
                sqlparam[i++].Value = InvestmentLoanInfo.OpationRemark;
                sqlparam[i++].Value = InvestmentLoanInfo.Cash;
                sqlparam[i++].Value = InvestmentLoanInfo.TransferAccount;
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
        /// dbo.InvestmentLoan????(????ID ObjectID)
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="objectID">ObjectID(??ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "InvestmentLoan_Delete";

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
        /// InvestmentLoan ????
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="InvestmentLoanInfo">InvestmentLoanInfo??</param>
        /// <returns>????,0:??,1:??</returns>
        public int UpDate(string boName, InvestmentLoanInfo InvestmentLoanInfo)
        {
            try
            {
                //??????
                string strsql = "InvestmentLoan_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@ProjectOverview",DbType.String),
				new SqlParameter("@BorrowerNameA",DbType.String),
				new SqlParameter("@BorrowerAId",DbType.Guid),
				new SqlParameter("@PayerBName",DbType.String),
				new SqlParameter("@BorrowerPhone",DbType.String),
				new SqlParameter("@LoanAmount",DbType.Guid),
				new SqlParameter("@LoanDate",DbType.DateTime),
				new SqlParameter("@Collateral",DbType.String),
				new SqlParameter("@Guarantor",DbType.String),
				new SqlParameter("@GuarantorPhone",DbType.String),
				new SqlParameter("@RateOfReturn",DbType.String),
				new SqlParameter("@DueDateForPay",DbType.Int32),
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
				new SqlParameter("@AccountingRemark",DbType.String),
				new SqlParameter("@DueDateForReceivables",DbType.Int32),
				new SqlParameter("@ReceivablesRemindInfo",DbType.String),
				new SqlParameter("@NextBAOperaterId",DbType.Guid),
				new SqlParameter("@NextBAOperaterAccount",DbType.String),
				new SqlParameter("@NextBAOperaterName",DbType.String),
				new SqlParameter("@BAStatus",SqlDbType.TinyInt),
				new SqlParameter("@SubmitBATime",DbType.DateTime),
				new SqlParameter("@Adulters",DbType.String),
				new SqlParameter("@BAAdulters",DbType.String),
                	new SqlParameter("@LoanTimeLimit",DbType.String),
                    	new SqlParameter("@LoanType",DbType.String),
                      new SqlParameter("@Imprest",DbType.String),
                          new SqlParameter("@Penalbond",DbType.String),
                             new SqlParameter("@OpationRemark",DbType.String),
                                     	new SqlParameter("@Cash",DbType.Decimal),
                                	new SqlParameter("@TransferAccount",DbType.Decimal),
                };

                int i = 0;
                sqlparam[i++].Value = InvestmentLoanInfo.ObjectId;
                sqlparam[i++].Value = InvestmentLoanInfo.ProjectName;
                sqlparam[i++].Value = InvestmentLoanInfo.ProjectOverview;
                sqlparam[i++].Value = InvestmentLoanInfo.BorrowerNameA;
                sqlparam[i++].Value = InvestmentLoanInfo.BorrowerAId;
                sqlparam[i++].Value = InvestmentLoanInfo.PayerBName;
                sqlparam[i++].Value = InvestmentLoanInfo.BorrowerPhone;
                sqlparam[i++].Value = InvestmentLoanInfo.LoanAmount;
                sqlparam[i++].Value = InvestmentLoanInfo.LoanDate;
                sqlparam[i++].Value = InvestmentLoanInfo.Collateral;
                sqlparam[i++].Value = InvestmentLoanInfo.Guarantor;
                sqlparam[i++].Value = InvestmentLoanInfo.GuarantorPhone;
                sqlparam[i++].Value = InvestmentLoanInfo.RateOfReturn;
                sqlparam[i++].Value = InvestmentLoanInfo.DueDateForPay;
                sqlparam[i++].Value = InvestmentLoanInfo.Remark;
                sqlparam[i++].Value = InvestmentLoanInfo.Status;
                sqlparam[i++].Value = InvestmentLoanInfo.NextOperaterId;
                sqlparam[i++].Value = InvestmentLoanInfo.NextOperaterAccount;
                sqlparam[i++].Value = InvestmentLoanInfo.NextOperaterName;
                sqlparam[i++].Value = InvestmentLoanInfo.CreateTime;
                sqlparam[i++].Value = InvestmentLoanInfo.CreaterId;
                sqlparam[i++].Value = InvestmentLoanInfo.CreaterName;
                sqlparam[i++].Value = InvestmentLoanInfo.CreaterAccount;
                sqlparam[i++].Value = InvestmentLoanInfo.SubmitTime;
                sqlparam[i++].Value = InvestmentLoanInfo.AuditOpinion;
                sqlparam[i++].Value = InvestmentLoanInfo.AccountingRemark;
                sqlparam[i++].Value = InvestmentLoanInfo.DueDateForReceivables;
                sqlparam[i++].Value = InvestmentLoanInfo.ReceivablesRemindInfo;
                sqlparam[i++].Value = InvestmentLoanInfo.NextBAOperaterId;
                sqlparam[i++].Value = InvestmentLoanInfo.NextBAOperaterAccount;
                sqlparam[i++].Value = InvestmentLoanInfo.NextBAOperaterName;
                sqlparam[i++].Value = InvestmentLoanInfo.BAStatus;
                sqlparam[i++].Value = InvestmentLoanInfo.SubmitBATime;
                sqlparam[i++].Value = InvestmentLoanInfo.Adulters;
                sqlparam[i++].Value = InvestmentLoanInfo.BAAdulters;
                sqlparam[i++].Value = InvestmentLoanInfo.LoanTimeLimit;
                sqlparam[i++].Value = InvestmentLoanInfo.LoanType;
                sqlparam[i++].Value = InvestmentLoanInfo.Imprest;
                sqlparam[i++].Value = InvestmentLoanInfo.Penalbond;
                sqlparam[i++].Value = InvestmentLoanInfo.OpationRemark;
                sqlparam[i++].Value = InvestmentLoanInfo.Cash;
                sqlparam[i++].Value = InvestmentLoanInfo.TransferAccount;
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
        /// InvestmentLoan ??,??Datatable
        /// </summary>
        /// <param name="boName">???????key??</param>
        /// <param name="selectCondition">????</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //??????
                string strsql = "InvestmentLoan_Search";
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
        ///InvestmentLoan ??,??List
        ///</summary>
        ///<param name="boName">???????key??</param>
        ///<param name="selectCondition">????</param>
        /// <returns>List<InvestmentLoanInfo></returns>
        public List<InvestmentLoanInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<InvestmentLoanInfo> list = new List<InvestmentLoanInfo>();
            InvestmentLoanInfo accountInfo = new InvestmentLoanInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = InvestmentLoanInfoRowToInfo(row);
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
        /// <param name="InvestmentLoanDataRow">InvestmentLoanDataRow</param>
        /// <returns>InvestmentLoanInfo</returns>
        internal InvestmentLoanInfo InvestmentLoanInfoRowToInfo(DataRow InvestmentLoanInfoInfoDataRow)
        {
            InvestmentLoanInfo InvestmentLoanInfoInfo = new InvestmentLoanInfo();
            if (InvestmentLoanInfoInfoDataRow["ObjectId"] != null)
            {
                InvestmentLoanInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "ObjectId"));
            }
            if (InvestmentLoanInfoInfoDataRow["ProjectName"] != null)
            {
                InvestmentLoanInfoInfo.ProjectName = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "ProjectName");
            }
            if (InvestmentLoanInfoInfoDataRow["ProjectOverview"] != null)
            {
                InvestmentLoanInfoInfo.ProjectOverview = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "ProjectOverview");
            }
            if (InvestmentLoanInfoInfoDataRow["BorrowerNameA"] != null)
            {
                InvestmentLoanInfoInfo.BorrowerNameA = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "BorrowerNameA");
            }
            if (InvestmentLoanInfoInfoDataRow["BorrowerAId"] != null)
            {
                InvestmentLoanInfoInfo.BorrowerAId = new Guid(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "BorrowerAId"));
            }
            if (InvestmentLoanInfoInfoDataRow["PayerBName"] != null)
            {
                InvestmentLoanInfoInfo.PayerBName = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "PayerBName");
            }
            if (InvestmentLoanInfoInfoDataRow["BorrowerPhone"] != null)
            {
                InvestmentLoanInfoInfo.BorrowerPhone = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "BorrowerPhone");
            }
            if (InvestmentLoanInfoInfoDataRow["LoanAmount"] != null)
            {
                InvestmentLoanInfoInfo.LoanAmount = Decimal.Parse(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "LoanAmount"));
            }
            if (InvestmentLoanInfoInfoDataRow["LoanDate"] != null)
            {
                InvestmentLoanInfoInfo.LoanDate = DateTime.Parse(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "LoanDate"));
            }
            if (InvestmentLoanInfoInfoDataRow["Collateral"] != null)
            {
                InvestmentLoanInfoInfo.Collateral = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "Collateral");
            }
            if (InvestmentLoanInfoInfoDataRow["Guarantor"] != null)
            {
                InvestmentLoanInfoInfo.Guarantor = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "Guarantor");
            }
            if (InvestmentLoanInfoInfoDataRow["GuarantorPhone"] != null)
            {
                InvestmentLoanInfoInfo.GuarantorPhone = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "GuarantorPhone");
            }
            if (InvestmentLoanInfoInfoDataRow["RateOfReturn"] != null)
            {
                InvestmentLoanInfoInfo.RateOfReturn =  DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "RateOfReturn");
            }
            if (InvestmentLoanInfoInfoDataRow["DueDateForPay"] != null)
            {
                InvestmentLoanInfoInfo.DueDateForPay = int.Parse(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "DueDateForPay"));
            }
            if (InvestmentLoanInfoInfoDataRow["Remark"] != null)
            {
                InvestmentLoanInfoInfo.Remark = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "Remark");
            }
            if (InvestmentLoanInfoInfoDataRow["Status"] != null)
            {
                InvestmentLoanInfoInfo.Status = int.Parse(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "Status"));
            }
            if (InvestmentLoanInfoInfoDataRow["NextOperaterId"] != null)
            {
                InvestmentLoanInfoInfo.NextOperaterId = new Guid(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "NextOperaterId"));
            }
            if (InvestmentLoanInfoInfoDataRow["NextOperaterAccount"] != null)
            {
                InvestmentLoanInfoInfo.NextOperaterAccount = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "NextOperaterAccount");
            }
            if (InvestmentLoanInfoInfoDataRow["NextOperaterName"] != null)
            {
                InvestmentLoanInfoInfo.NextOperaterName = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "NextOperaterName");
            }
            if (InvestmentLoanInfoInfoDataRow["CreateTime"] != null)
            {
                InvestmentLoanInfoInfo.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "CreateTime"));
            }
            if (InvestmentLoanInfoInfoDataRow["CreaterId"] != null)
            {
                InvestmentLoanInfoInfo.CreaterId = new Guid(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "CreaterId"));
            }
            if (InvestmentLoanInfoInfoDataRow["CreaterName"] != null)
            {
                InvestmentLoanInfoInfo.CreaterName = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "CreaterName");
            }
            if (InvestmentLoanInfoInfoDataRow["CreaterAccount"] != null)
            {
                InvestmentLoanInfoInfo.CreaterAccount = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "CreaterAccount");
            }
            if (InvestmentLoanInfoInfoDataRow["SubmitTime"] != null)
            {
                InvestmentLoanInfoInfo.SubmitTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "SubmitTime"));
            }
            if (InvestmentLoanInfoInfoDataRow["AuditOpinion"] != null)
            {
                InvestmentLoanInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "AuditOpinion");
            }
            if (InvestmentLoanInfoInfoDataRow["AccountingRemark"] != null)
            {
                InvestmentLoanInfoInfo.AccountingRemark = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "AccountingRemark");
            }
            if (InvestmentLoanInfoInfoDataRow["DueDateForReceivables"] != null)
            {
                InvestmentLoanInfoInfo.DueDateForReceivables = int.Parse(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "DueDateForReceivables"));
            }
            if (InvestmentLoanInfoInfoDataRow["ReceivablesRemindInfo"] != null)
            {
                InvestmentLoanInfoInfo.ReceivablesRemindInfo = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "ReceivablesRemindInfo");
            }
            if (InvestmentLoanInfoInfoDataRow["NextBAOperaterId"] != null)
            {
                InvestmentLoanInfoInfo.NextBAOperaterId = new Guid(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "NextBAOperaterId"));
            }
            if (InvestmentLoanInfoInfoDataRow["NextBAOperaterAccount"] != null)
            {
                InvestmentLoanInfoInfo.NextBAOperaterAccount = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "NextBAOperaterAccount");
            }
            if (InvestmentLoanInfoInfoDataRow["NextBAOperaterName"] != null)
            {
                InvestmentLoanInfoInfo.NextBAOperaterName = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "NextBAOperaterName");
            }
            if (InvestmentLoanInfoInfoDataRow["BAStatus"] != null)
            {
                InvestmentLoanInfoInfo.BAStatus = int.Parse(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "BAStatus"));
            }
            if (InvestmentLoanInfoInfoDataRow["SubmitBATime"] != null)
            {
                InvestmentLoanInfoInfo.SubmitBATime = DateTime.Parse(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "SubmitBATime"));
            }
            if (InvestmentLoanInfoInfoDataRow["Adulters"] != null)
            {
                InvestmentLoanInfoInfo.Adulters = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "Adulters");
            }
            if (InvestmentLoanInfoInfoDataRow["BAAdulters"] != null)
            {
                InvestmentLoanInfoInfo.BAAdulters = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "BAAdulters");
            }
            if (InvestmentLoanInfoInfoDataRow["LoanTimeLimit"] != null)
            {
                InvestmentLoanInfoInfo.LoanTimeLimit = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "LoanTimeLimit");
            }
            if (InvestmentLoanInfoInfoDataRow["LoanType"] != null)
            {
                InvestmentLoanInfoInfo.LoanType = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "LoanType");
            }
            if (InvestmentLoanInfoInfoDataRow["LoanType"] != null)
            {
                InvestmentLoanInfoInfo.Imprest = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "Imprest");
            }
            if (InvestmentLoanInfoInfoDataRow["Imprest"] != null)
            {
                InvestmentLoanInfoInfo.Penalbond = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "Penalbond");
            }
            if (InvestmentLoanInfoInfoDataRow["OpationRemark"] != null)
            {
                InvestmentLoanInfoInfo.OpationRemark = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "OpationRemark");
            }
            if (InvestmentLoanInfoInfoDataRow["Cash"] != null)
            {
                InvestmentLoanInfoInfo.Cash = Decimal.Parse(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "Cash"));
            }
            if (InvestmentLoanInfoInfoDataRow["TransferAccount"] != null)
            {
                InvestmentLoanInfoInfo.TransferAccount = Decimal.Parse(DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "TransferAccount"));
            }
            return InvestmentLoanInfoInfo;
        }
        #endregion
    }
}
