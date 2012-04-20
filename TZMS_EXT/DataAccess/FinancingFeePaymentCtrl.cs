//----------------------------------------------------------------------------------------------------
//程序名:	FinancingFeePayment 控制类
//功能:  	定义了与 dbo.FinancingFeePayment 表 对应的数据访问控制类
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
    /// FinancingFeePaymentCtrl
    /// programmer:shunlian
    /// </summary>
    public class FinancingFeePaymentCtrl
    {
        #region 构造函数

        /// <summary>
        /// FinancingFeePaymentCtrl默认构造函数
        /// </summary>
        public FinancingFeePaymentCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.FinancingFeePayment一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="FinancingFeePaymentInfo">FinancingFeePaymentInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, FinancingFeePaymentInfo FinancingFeePaymentInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "FinancingFeePayment_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@DueDateForPay",DbType.DateTime),
				new SqlParameter("@DateForPay",DbType.DateTime),
				new SqlParameter("@AmountOfPayment",DbType.Guid),
				new SqlParameter("@PaymentAccount",DbType.String),
				new SqlParameter("@ReceivablesAccount",DbType.String),
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
				new SqlParameter("@AccountingRemark",DbType.String),
				new SqlParameter("@Status",DbType.Byte),
                	new SqlParameter("@Adulters",DbType.Byte),
                    new SqlParameter("@AmountOfPaymentFlag",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = FinancingFeePaymentInfo.ObjectId;
                sqlparam[i++].Value = FinancingFeePaymentInfo.ForId;
                sqlparam[i++].Value = FinancingFeePaymentInfo.DueDateForPay;
                sqlparam[i++].Value = FinancingFeePaymentInfo.DateForPay;
                sqlparam[i++].Value = FinancingFeePaymentInfo.AmountOfPayment;
                sqlparam[i++].Value = FinancingFeePaymentInfo.PaymentAccount;
                sqlparam[i++].Value = FinancingFeePaymentInfo.ReceivablesAccount;
                sqlparam[i++].Value = FinancingFeePaymentInfo.Remark;
                sqlparam[i++].Value = FinancingFeePaymentInfo.NextOperaterId;
                sqlparam[i++].Value = FinancingFeePaymentInfo.NextOperaterAccount;
                sqlparam[i++].Value = FinancingFeePaymentInfo.NextOperaterName;
                sqlparam[i++].Value = FinancingFeePaymentInfo.CreateTime;
                sqlparam[i++].Value = FinancingFeePaymentInfo.CreaterId;
                sqlparam[i++].Value = FinancingFeePaymentInfo.CreaterName;
                sqlparam[i++].Value = FinancingFeePaymentInfo.CreaterAccount;
                sqlparam[i++].Value = FinancingFeePaymentInfo.SubmitTime;
                sqlparam[i++].Value = FinancingFeePaymentInfo.AuditOpinion;
                sqlparam[i++].Value = FinancingFeePaymentInfo.AccountingRemark;
                sqlparam[i++].Value = FinancingFeePaymentInfo.Status;
                sqlparam[i++].Value = FinancingFeePaymentInfo.Adulters;
                sqlparam[i++].Value = FinancingFeePaymentInfo.AmountOfPaymentFlag;
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
        /// dbo.FinancingFeePayment删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "FinancingFeePayment_Delete";

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
        /// FinancingFeePayment 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="FinancingFeePaymentInfo">FinancingFeePaymentInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, FinancingFeePaymentInfo FinancingFeePaymentInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "FinancingFeePayment_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@DueDateForPay",DbType.DateTime),
				new SqlParameter("@DateForPay",DbType.DateTime),
				new SqlParameter("@AmountOfPayment",DbType.Guid),
				new SqlParameter("@PaymentAccount",DbType.String),
				new SqlParameter("@ReceivablesAccount",DbType.String),
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
				new SqlParameter("@AccountingRemark",DbType.String),
				new SqlParameter("@Status",DbType.Byte),
                   	new SqlParameter("@Adulters",DbType.Byte),
                      new SqlParameter("@AmountOfPaymentFlag",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = FinancingFeePaymentInfo.ObjectId;
                sqlparam[i++].Value = FinancingFeePaymentInfo.ForId;
                sqlparam[i++].Value = FinancingFeePaymentInfo.DueDateForPay;
                sqlparam[i++].Value = FinancingFeePaymentInfo.DateForPay;
                sqlparam[i++].Value = FinancingFeePaymentInfo.AmountOfPayment;
                sqlparam[i++].Value = FinancingFeePaymentInfo.PaymentAccount;
                sqlparam[i++].Value = FinancingFeePaymentInfo.ReceivablesAccount;
                sqlparam[i++].Value = FinancingFeePaymentInfo.Remark;
                sqlparam[i++].Value = FinancingFeePaymentInfo.NextOperaterId;
                sqlparam[i++].Value = FinancingFeePaymentInfo.NextOperaterAccount;
                sqlparam[i++].Value = FinancingFeePaymentInfo.NextOperaterName;
                sqlparam[i++].Value = FinancingFeePaymentInfo.CreateTime;
                sqlparam[i++].Value = FinancingFeePaymentInfo.CreaterId;
                sqlparam[i++].Value = FinancingFeePaymentInfo.CreaterName;
                sqlparam[i++].Value = FinancingFeePaymentInfo.CreaterAccount;
                sqlparam[i++].Value = FinancingFeePaymentInfo.SubmitTime;
                sqlparam[i++].Value = FinancingFeePaymentInfo.AuditOpinion;
                sqlparam[i++].Value = FinancingFeePaymentInfo.AccountingRemark;
                sqlparam[i++].Value = FinancingFeePaymentInfo.Status;
                sqlparam[i++].Value = FinancingFeePaymentInfo.Adulters;
                sqlparam[i++].Value = FinancingFeePaymentInfo.AmountOfPaymentFlag;
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
        /// FinancingFeePayment 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "FinancingFeePayment_Search";
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
        ///FinancingFeePayment 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<FinancingFeePaymentInfo></returns>
        public List<FinancingFeePaymentInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<FinancingFeePaymentInfo> list = new List<FinancingFeePaymentInfo>();
            FinancingFeePaymentInfo accountInfo = new FinancingFeePaymentInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = FinancingFeePaymentInfoRowToInfo(row);
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
        /// <param name="FinancingFeePaymentDataRow">FinancingFeePaymentDataRow</param>
        /// <returns>FinancingFeePaymentInfo</returns>
        internal FinancingFeePaymentInfo FinancingFeePaymentInfoRowToInfo(DataRow FinancingFeePaymentInfoInfoDataRow)
        {
            FinancingFeePaymentInfo FinancingFeePaymentInfoInfo = new FinancingFeePaymentInfo();
            if (FinancingFeePaymentInfoInfoDataRow["ObjectId"] != null)
            {
                FinancingFeePaymentInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "ObjectId"));
            }
            if (FinancingFeePaymentInfoInfoDataRow["ForId"] != null)
            {
                FinancingFeePaymentInfoInfo.ForId = new Guid(DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "ForId"));
            }
            if (FinancingFeePaymentInfoInfoDataRow["DueDateForPay"] != null)
            {
                FinancingFeePaymentInfoInfo.DueDateForPay = DateTime.Parse(DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "DueDateForPay"));
            }
            if (FinancingFeePaymentInfoInfoDataRow["DateForPay"] != null)
            {
                FinancingFeePaymentInfoInfo.DateForPay = DateTime.Parse(DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "DateForPay"));
            }
            if (FinancingFeePaymentInfoInfoDataRow["AmountOfPayment"] != null)
            {
                FinancingFeePaymentInfoInfo.AmountOfPayment = Decimal.Parse(DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "AmountOfPayment"));
            }
            if (FinancingFeePaymentInfoInfoDataRow["PaymentAccount"] != null)
            {
                FinancingFeePaymentInfoInfo.PaymentAccount = DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "PaymentAccount");
            }
            if (FinancingFeePaymentInfoInfoDataRow["ReceivablesAccount"] != null)
            {
                FinancingFeePaymentInfoInfo.ReceivablesAccount = DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "ReceivablesAccount");
            }
            if (FinancingFeePaymentInfoInfoDataRow["Remark"] != null)
            {
                FinancingFeePaymentInfoInfo.Remark = DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "Remark");
            }
            if (FinancingFeePaymentInfoInfoDataRow["NextOperaterId"] != null)
            {
                FinancingFeePaymentInfoInfo.NextOperaterId = new Guid(DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "NextOperaterId"));
            }
            if (FinancingFeePaymentInfoInfoDataRow["NextOperaterAccount"] != null)
            {
                FinancingFeePaymentInfoInfo.NextOperaterAccount = DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "NextOperaterAccount");
            }
            if (FinancingFeePaymentInfoInfoDataRow["NextOperaterName"] != null)
            {
                FinancingFeePaymentInfoInfo.NextOperaterName = DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "NextOperaterName");
            }
            if (FinancingFeePaymentInfoInfoDataRow["CreateTime"] != null)
            {
                FinancingFeePaymentInfoInfo.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "CreateTime"));
            }
            if (FinancingFeePaymentInfoInfoDataRow["CreaterId"] != null)
            {
                FinancingFeePaymentInfoInfo.CreaterId = new Guid(DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "CreaterId"));
            }
            if (FinancingFeePaymentInfoInfoDataRow["CreaterName"] != null)
            {
                FinancingFeePaymentInfoInfo.CreaterName = DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "CreaterName");
            }
            if (FinancingFeePaymentInfoInfoDataRow["CreaterAccount"] != null)
            {
                FinancingFeePaymentInfoInfo.CreaterAccount = DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "CreaterAccount");
            }
            if (FinancingFeePaymentInfoInfoDataRow["SubmitTime"] != null)
            {
                FinancingFeePaymentInfoInfo.SubmitTime = DateTime.Parse(DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "SubmitTime"));
            }
            if (FinancingFeePaymentInfoInfoDataRow["AuditOpinion"] != null)
            {
                FinancingFeePaymentInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "AuditOpinion");
            }
            if (FinancingFeePaymentInfoInfoDataRow["AccountingRemark"] != null)
            {
                FinancingFeePaymentInfoInfo.AccountingRemark = DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "AccountingRemark");
            }
            if (FinancingFeePaymentInfoInfoDataRow["Status"] != null)
            {
                FinancingFeePaymentInfoInfo.Status = int.Parse(DataUtil.GetStringValueOfRow(FinancingFeePaymentInfoInfoDataRow, "Status"));
            }

            return FinancingFeePaymentInfoInfo;
        }
        #endregion
    }
}
