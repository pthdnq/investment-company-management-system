//----------------------------------------------------------------------------------------------------
//程序名:	InvestmentLoan 控制类
//功能:  	定义了与 dbo.InvestmentLoan 表 对应的数据访问控制类
//作者:  	shunlian
//时间:	2011-10-26 
//----------------------------------------------------------------------------------------------------
//更改历史:
// 日期		            更改人		     更改内容
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
    /// programmer:shunlian
    /// </summary>
    public class InvestmentLoanCtrl
    {
        #region 构造函数

        /// <summary>
        /// InvestmentLoanCtrl默认构造函数
        /// </summary>
        public InvestmentLoanCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.InvestmentLoan一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="InvestmentLoanInfo">InvestmentLoanInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, InvestmentLoanInfo InvestmentLoanInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "InvestmentLoan_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjetctId",DbType.Guid),
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
				new SqlParameter("@RateOfReturn",DbType.Byte),
				new SqlParameter("@DueDateForPay",DbType.DateTime),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@Status",DbType.Byte),
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
				};

                int i = 0;
                sqlparam[i++].Value = InvestmentLoanInfo.ObjetctId;
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
                SqlDBAccess dbaccess = new SqlDBAccess();
                //执行存储过程
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
        /// dbo.InvestmentLoan删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
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
        /// InvestmentLoan 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="InvestmentLoanInfo">InvestmentLoanInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, InvestmentLoanInfo InvestmentLoanInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "InvestmentLoan_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjetctId",DbType.Guid),
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
				new SqlParameter("@RateOfReturn",DbType.Byte),
				new SqlParameter("@DueDateForPay",DbType.DateTime),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@Status",DbType.Byte),
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
                };

                int i = 0;
                sqlparam[i++].Value = InvestmentLoanInfo.ObjetctId;
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
                SqlDBAccess dbaccess = new SqlDBAccess();
                //执行存储过程
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
        /// InvestmentLoan 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "InvestmentLoan_Search";
                SqlParameter[] sqlparam =
                {
					new SqlParameter("@Condition",SqlDbType.NVarChar), 
                };

                int i = 0;
                sqlparam[i++].Value = condition;
                SqlDBAccess dbaccess = new SqlDBAccess();
                //执行存储过程
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
        ///InvestmentLoan 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
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
            //if (InvestmentLoanInfoInfoDataRow["ObjetctId"] != null)
            //{
            //    InvestmentLoanInfoInfo.ObjetctId = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "ObjetctId");
            //}
            //if (InvestmentLoanInfoInfoDataRow["ProjectName"] != null)
            //{
            //    InvestmentLoanInfoInfo.ProjectName = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "ProjectName");
            //}
            //if (InvestmentLoanInfoInfoDataRow["ProjectOverview"] != null)
            //{
            //    InvestmentLoanInfoInfo.ProjectOverview = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "ProjectOverview");
            //}
            //if (InvestmentLoanInfoInfoDataRow["BorrowerNameA"] != null)
            //{
            //    InvestmentLoanInfoInfo.BorrowerNameA = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "BorrowerNameA");
            //}
            //if (InvestmentLoanInfoInfoDataRow["BorrowerAId"] != null)
            //{
            //    InvestmentLoanInfoInfo.BorrowerAId = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "BorrowerAId");
            //}
            //if (InvestmentLoanInfoInfoDataRow["PayerBName"] != null)
            //{
            //    InvestmentLoanInfoInfo.PayerBName = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "PayerBName");
            //}
            //if (InvestmentLoanInfoInfoDataRow["BorrowerPhone"] != null)
            //{
            //    InvestmentLoanInfoInfo.BorrowerPhone = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "BorrowerPhone");
            //}
            //if (InvestmentLoanInfoInfoDataRow["LoanAmount"] != null)
            //{
            //    InvestmentLoanInfoInfo.LoanAmount = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "LoanAmount");
            //}
            //if (InvestmentLoanInfoInfoDataRow["LoanDate"] != null)
            //{
            //    InvestmentLoanInfoInfo.LoanDate = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "LoanDate");
            //}
            //if (InvestmentLoanInfoInfoDataRow["Collateral"] != null)
            //{
            //    InvestmentLoanInfoInfo.Collateral = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "Collateral");
            //}
            //if (InvestmentLoanInfoInfoDataRow["Guarantor"] != null)
            //{
            //    InvestmentLoanInfoInfo.Guarantor = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "Guarantor");
            //}
            //if (InvestmentLoanInfoInfoDataRow["GuarantorPhone"] != null)
            //{
            //    InvestmentLoanInfoInfo.GuarantorPhone = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "GuarantorPhone");
            //}
            //if (InvestmentLoanInfoInfoDataRow["RateOfReturn"] != null)
            //{
            //    InvestmentLoanInfoInfo.RateOfReturn = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "RateOfReturn");
            //}
            //if (InvestmentLoanInfoInfoDataRow["DueDateForPay"] != null)
            //{
            //    InvestmentLoanInfoInfo.DueDateForPay = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "DueDateForPay");
            //}
            //if (InvestmentLoanInfoInfoDataRow["Remark"] != null)
            //{
            //    InvestmentLoanInfoInfo.Remark = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "Remark");
            //}
            //if (InvestmentLoanInfoInfoDataRow["Status"] != null)
            //{
            //    InvestmentLoanInfoInfo.Status = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "Status");
            //}
            //if (InvestmentLoanInfoInfoDataRow["NextOperaterId"] != null)
            //{
            //    InvestmentLoanInfoInfo.NextOperaterId = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "NextOperaterId");
            //}
            //if (InvestmentLoanInfoInfoDataRow["NextOperaterAccount"] != null)
            //{
            //    InvestmentLoanInfoInfo.NextOperaterAccount = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "NextOperaterAccount");
            //}
            //if (InvestmentLoanInfoInfoDataRow["NextOperaterName"] != null)
            //{
            //    InvestmentLoanInfoInfo.NextOperaterName = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "NextOperaterName");
            //}
            //if (InvestmentLoanInfoInfoDataRow["CreateTime"] != null)
            //{
            //    InvestmentLoanInfoInfo.CreateTime = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "CreateTime");
            //}
            //if (InvestmentLoanInfoInfoDataRow["CreaterId"] != null)
            //{
            //    InvestmentLoanInfoInfo.CreaterId = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "CreaterId");
            //}
            //if (InvestmentLoanInfoInfoDataRow["CreaterName"] != null)
            //{
            //    InvestmentLoanInfoInfo.CreaterName = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "CreaterName");
            //}
            //if (InvestmentLoanInfoInfoDataRow["CreaterAccount"] != null)
            //{
            //    InvestmentLoanInfoInfo.CreaterAccount = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "CreaterAccount");
            //}
            //if (InvestmentLoanInfoInfoDataRow["SubmitTime"] != null)
            //{
            //    InvestmentLoanInfoInfo.SubmitTime = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "SubmitTime");
            //}
            //if (InvestmentLoanInfoInfoDataRow["AuditOpinion"] != null)
            //{
            //    InvestmentLoanInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "AuditOpinion");
            //}
            //if (InvestmentLoanInfoInfoDataRow["AccountingRemark"] != null)
            //{
            //    InvestmentLoanInfoInfo.AccountingRemark = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "AccountingRemark");
            //}
            //if (InvestmentLoanInfoInfoDataRow["DueDateForReceivables"] != null)
            //{
            //    InvestmentLoanInfoInfo.DueDateForReceivables = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "DueDateForReceivables");
            //}
            //if (InvestmentLoanInfoInfoDataRow["ReceivablesRemindInfo"] != null)
            //{
            //    InvestmentLoanInfoInfo.ReceivablesRemindInfo = DataUtil.GetStringValueOfRow(InvestmentLoanInfoInfoDataRow, "ReceivablesRemindInfo");
            //}

            return InvestmentLoanInfoInfo;
        }
        #endregion
    }
}
