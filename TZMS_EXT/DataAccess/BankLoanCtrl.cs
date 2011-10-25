//----------------------------------------------------------------------------------------------------
//程序名:	BankLoan 控制类
//功能:  	定义了与 dbo.BankLoan 表 对应的数据访问控制类
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
    /// BankLoanCtrl
    /// programmer:shunlian
    /// </summary>
    public class BankLoanCtrl
    {
        #region 构造函数

        /// <summary>
        /// BankLoanCtrl默认构造函数
        /// </summary>
        public BankLoanCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.BankLoan一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BankLoanInfo">BankLoanInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, BankLoanInfo BankLoanInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BankLoan_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjetctId",DbType.Guid),
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
				new SqlParameter("@Status",DbType.Byte),
				};

                int i = 0;
                sqlparam[i++].Value = BankLoanInfo.ObjetctId;
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
        /// dbo.BankLoan删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
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
        /// BankLoan 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BankLoanInfo">BankLoanInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, BankLoanInfo BankLoanInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BankLoan_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjetctId",DbType.Guid),
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
				new SqlParameter("@Status",DbType.Byte),
                };

                int i = 0;
                sqlparam[i++].Value = BankLoanInfo.ObjetctId;
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
        /// BankLoan 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "BankLoan_Search";
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
        ///BankLoan 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
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
            BankLoanInfo BankLoanInfoInfo = new BankLoanInfo();
            ////if (BankLoanInfoInfoDataRow["ObjetctId"] != null)
            ////{
            ////    BankLoanInfoInfo.ObjetctId =new Guid(BankLoanInfoInfoDataRow["ObjetctId"].ToString());
            ////}
            ////if (BankLoanInfoInfoDataRow["CustomerName"] != null)
            ////{
            ////    BankLoanInfoInfo.CustomerName = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "CustomerName");
            ////}
            ////if (BankLoanInfoInfoDataRow["CustomerId"] != null)
            ////{
            ////    BankLoanInfoInfo.CustomerId = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "CustomerId");
            ////}
            ////if (BankLoanInfoInfoDataRow["LoanCompany"] != null)
            ////{
            ////    BankLoanInfoInfo.LoanCompany = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "LoanCompany");
            ////}
            ////if (BankLoanInfoInfoDataRow["LoanAmount"] != null)
            ////{
            ////    BankLoanInfoInfo.LoanAmount = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "LoanAmount");
            ////}
            ////if (BankLoanInfoInfoDataRow["LoanFee"] != null)
            ////{
            ////    BankLoanInfoInfo.LoanFee = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "LoanFee");
            ////}
            ////if (BankLoanInfoInfoDataRow["CollateralCompany"] != null)
            ////{
            ////    BankLoanInfoInfo.CollateralCompany = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "CollateralCompany");
            ////}
            ////if (BankLoanInfoInfoDataRow["SignDate"] != null)
            ////{
            ////    BankLoanInfoInfo.SignDate = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "SignDate");
            ////}
            ////if (BankLoanInfoInfoDataRow["DownPayment"] != null)
            ////{
            ////    BankLoanInfoInfo.DownPayment = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "DownPayment");
            ////}
            ////if (BankLoanInfoInfoDataRow["Contact"] != null)
            ////{
            ////    BankLoanInfoInfo.Contact = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "Contact");
            ////}
            ////if (BankLoanInfoInfoDataRow["Remark"] != null)
            ////{
            ////    BankLoanInfoInfo.Remark = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "Remark");
            ////}
            ////if (BankLoanInfoInfoDataRow["NextOperaterId"] != null)
            ////{
            ////    BankLoanInfoInfo.NextOperaterId = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "NextOperaterId");
            ////}
            ////if (BankLoanInfoInfoDataRow["NextOperaterAccount"] != null)
            ////{
            ////    BankLoanInfoInfo.NextOperaterAccount = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "NextOperaterAccount");
            ////}
            ////if (BankLoanInfoInfoDataRow["NextOperaterName"] != null)
            ////{
            ////    BankLoanInfoInfo.NextOperaterName = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "NextOperaterName");
            ////}
            ////if (BankLoanInfoInfoDataRow["CreateTime"] != null)
            ////{
            ////    BankLoanInfoInfo.CreateTime = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "CreateTime");
            ////}
            ////if (BankLoanInfoInfoDataRow["CreaterId"] != null)
            ////{
            ////    BankLoanInfoInfo.CreaterId = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "CreaterId");
            ////}
            ////if (BankLoanInfoInfoDataRow["CreaterName"] != null)
            ////{
            ////    BankLoanInfoInfo.CreaterName = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "CreaterName");
            ////}
            ////if (BankLoanInfoInfoDataRow["CreaterAccount"] != null)
            ////{
            ////    BankLoanInfoInfo.CreaterAccount = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "CreaterAccount");
            ////}
            ////if (BankLoanInfoInfoDataRow["SubmitTime"] != null)
            ////{
            ////    BankLoanInfoInfo.SubmitTime = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "SubmitTime");
            ////}
            ////if (BankLoanInfoInfoDataRow["AuditOpinion"] != null)
            ////{
            ////    BankLoanInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "AuditOpinion");
            ////}
            ////if (BankLoanInfoInfoDataRow["Status"] != null)
            ////{
            ////    BankLoanInfoInfo.Status = (char)DataUtil.GetStringValueOfRow(BankLoanInfoInfoDataRow, "Status");
            ////}

            return BankLoanInfoInfo;
        }
        #endregion
    }
}
