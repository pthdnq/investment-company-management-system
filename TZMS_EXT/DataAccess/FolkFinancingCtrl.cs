//----------------------------------------------------------------------------------------------------
//程序名:	FolkFinancing 控制类
//功能:  	定义了与 dbo.FolkFinancing 表 对应的数据访问控制类
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
    /// FolkFinancingCtrl
    /// programmer:shunlian
    /// </summary>
    public class FolkFinancingCtrl
    {
        #region 构造函数

        /// <summary>
        /// FolkFinancingCtrl默认构造函数
        /// </summary>
        public FolkFinancingCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.FolkFinancing一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="FolkFinancingInfo">FolkFinancingInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, FolkFinancingInfo FolkFinancingInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "FolkFinancing_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjetctId",DbType.Guid),
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
				new SqlParameter("@Status",DbType.Byte),
				};

                int i = 0;
                sqlparam[i++].Value = FolkFinancingInfo.ObjetctId;
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
        /// dbo.FolkFinancing删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
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
        /// FolkFinancing 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="FolkFinancingInfo">FolkFinancingInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, FolkFinancingInfo FolkFinancingInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "FolkFinancing_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjetctId",DbType.Guid),
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
				new SqlParameter("@Status",DbType.Byte),
                };

                int i = 0;
                sqlparam[i++].Value = FolkFinancingInfo.ObjetctId;
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
        /// FolkFinancing 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "FolkFinancing_Search";
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
        ///FolkFinancing 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
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
            FolkFinancingInfo FolkFinancingInfoInfo = new FolkFinancingInfo();
            if (FolkFinancingInfoInfoDataRow["ObjetctId"] != null)
            {
                FolkFinancingInfoInfo.ObjetctId = new Guid(DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "ObjetctId"));
            }
            if (FolkFinancingInfoInfoDataRow["BorrowerNameA"] != null)
            {
                FolkFinancingInfoInfo.BorrowerNameA = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "BorrowerNameA");
            }
            if (FolkFinancingInfoInfoDataRow["BorrowerAId"] != null)
            {
                FolkFinancingInfoInfo.BorrowerAId = new Guid(DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "BorrowerAId"));
            }
            if (FolkFinancingInfoInfoDataRow["Lenders"] != null)
            {
                FolkFinancingInfoInfo.Lenders = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "Lenders");
            }
            if (FolkFinancingInfoInfoDataRow["Guarantee"] != null)
            {
                FolkFinancingInfoInfo.Guarantee = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "Guarantee");
            }
            if (FolkFinancingInfoInfoDataRow["LoanAmount"] != null)
            {
                FolkFinancingInfoInfo.LoanAmount =Decimal.Parse( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "LoanAmount"));
            }
            if (FolkFinancingInfoInfoDataRow["LoanDate"] != null)
            {
                FolkFinancingInfoInfo.LoanDate =DateTime.Parse( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "LoanDate"));
            }
            if (FolkFinancingInfoInfoDataRow["DueDateForPay"] != null)
            {
                FolkFinancingInfoInfo.DueDateForPay =int.Parse( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "DueDateForPay"));
            }
            if (FolkFinancingInfoInfoDataRow["Collateral"] != null)
            {
                FolkFinancingInfoInfo.Collateral = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "Collateral");
            }
            if (FolkFinancingInfoInfoDataRow["BorrowingCost"] != null)
            {
                FolkFinancingInfoInfo.BorrowingCost = Decimal.Parse( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "BorrowingCost"));
            }
            if (FolkFinancingInfoInfoDataRow["ContactPhone"] != null)
            {
                FolkFinancingInfoInfo.ContactPhone = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "ContactPhone");
            }
            if (FolkFinancingInfoInfoDataRow["LoanType"] != null)
            {
                FolkFinancingInfoInfo.LoanType = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "LoanType");
            }
            if (FolkFinancingInfoInfoDataRow["Remark"] != null)
            {
                FolkFinancingInfoInfo.Remark = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "Remark");
            }
            if (FolkFinancingInfoInfoDataRow["NextOperaterId"] != null)
            {
                FolkFinancingInfoInfo.NextOperaterId =new Guid( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "NextOperaterId"));
            }
            if (FolkFinancingInfoInfoDataRow["NextOperaterAccount"] != null)
            {
                FolkFinancingInfoInfo.NextOperaterAccount = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "NextOperaterAccount");
            }
            if (FolkFinancingInfoInfoDataRow["NextOperaterName"] != null)
            {
                FolkFinancingInfoInfo.NextOperaterName = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "NextOperaterName");
            }
            if (FolkFinancingInfoInfoDataRow["CreateTime"] != null)
            {
                FolkFinancingInfoInfo.CreateTime =DateTime.Parse( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "CreateTime"));
            }
            if (FolkFinancingInfoInfoDataRow["CreaterId"] != null)
            {
                FolkFinancingInfoInfo.CreaterId =new Guid( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "CreaterId"));
            }
            if (FolkFinancingInfoInfoDataRow["CreaterName"] != null)
            {
                FolkFinancingInfoInfo.CreaterName = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "CreaterName");
            }
            if (FolkFinancingInfoInfoDataRow["CreaterAccount"] != null)
            {
                FolkFinancingInfoInfo.CreaterAccount = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "CreaterAccount");
            }
            if (FolkFinancingInfoInfoDataRow["AuditOpinion"] != null)
            {
                FolkFinancingInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "AuditOpinion");
            }
            if (FolkFinancingInfoInfoDataRow["SubmitTime"] != null)
            {
                FolkFinancingInfoInfo.SubmitTime =DateTime.Parse( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "SubmitTime"));
            }
            if (FolkFinancingInfoInfoDataRow["Status"] != null)
            {
                FolkFinancingInfoInfo.Status =char.Parse( DataUtil.GetStringValueOfRow(FolkFinancingInfoInfoDataRow, "Status"));
            }

            return FolkFinancingInfoInfo;
        }
        #endregion
    }
}
