//----------------------------------------------------------------------------------------------------
//程序名:	BankLoanProjectProcess 控制类
//功能:  	定义了与 dbo.BankLoanProjectProcess 表 对应的数据访问控制类
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
    /// BankLoanProjectProcessCtrl
    /// programmer:shunlian
    /// </summary>
    public class BankLoanProjectProcessCtrl
    {
        #region 构造函数

        /// <summary>
        /// BankLoanProjectProcessCtrl默认构造函数
        /// </summary>
        public BankLoanProjectProcessCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.BankLoanProjectProcess一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BankLoanProjectProcessInfo">BankLoanProjectProcessInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, BankLoanProjectProcessInfo BankLoanProjectProcessInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BankLoanProjectProcess_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@NeedImprest",DbType.Byte),
				new SqlParameter("@LoanBank",DbType.String),
				new SqlParameter("@GuaranteeCompany",DbType.String),
				new SqlParameter("@ImplementationPhase",DbType.String),
				new SqlParameter("@ImprestAmount",DbType.Guid),
				new SqlParameter("@AmountExpended",DbType.Guid),
				new SqlParameter("@ExpendedTime",DbType.String),
				new SqlParameter("@ImprestAmountBalance",DbType.Guid),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@Status",DbType.Int16),
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
                 new SqlParameter("@Use",DbType.String),
                 new SqlParameter("@ImprestRemark",DbType.String),
                      new SqlParameter("@Adulters",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ObjectId;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ForId;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ProjectName;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.NeedImprest;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.LoanBank;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.GuaranteeCompany;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ImplementationPhase;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ImprestAmount;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.AmountExpended;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ExpendedTime;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ImprestAmountBalance;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.Remark;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.Status;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.NextOperaterId;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.NextOperaterAccount;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.NextOperaterName;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.CreateTime;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.CreaterId;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.CreaterName;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.CreaterAccount;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.SubmitTime;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.AuditOpinion;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.AccountingRemark;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.Use;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ImprestRemark;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.Adulters;
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
        /// dbo.BankLoanProjectProcess删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "BankLoanProjectProcess_Delete";

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
        /// BankLoanProjectProcess 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BankLoanProjectProcessInfo">BankLoanProjectProcessInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, BankLoanProjectProcessInfo BankLoanProjectProcessInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BankLoanProjectProcess_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@NeedImprest",DbType.Byte),
				new SqlParameter("@LoanBank",DbType.String),
				new SqlParameter("@GuaranteeCompany",DbType.String),
				new SqlParameter("@ImplementationPhase",DbType.String),
				new SqlParameter("@ImprestAmount",DbType.Guid),
				new SqlParameter("@AmountExpended",DbType.Guid),
				new SqlParameter("@ExpendedTime",DbType.String),
				new SqlParameter("@ImprestAmountBalance",DbType.Guid),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@Status",DbType.Int16),
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
                    new SqlParameter("@Use",DbType.String),
                 new SqlParameter("@ImprestRemark",DbType.String),
                       new SqlParameter("@Adulters",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ObjectId;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ForId;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ProjectName;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.NeedImprest;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.LoanBank;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.GuaranteeCompany;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ImplementationPhase;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ImprestAmount;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.AmountExpended;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ExpendedTime;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ImprestAmountBalance;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.Remark;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.Status;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.NextOperaterId;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.NextOperaterAccount;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.NextOperaterName;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.CreateTime;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.CreaterId;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.CreaterName;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.CreaterAccount;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.SubmitTime;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.AuditOpinion;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.AccountingRemark;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.Use;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.ImprestRemark;
                sqlparam[i++].Value = BankLoanProjectProcessInfo.Adulters;
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
        /// BankLoanProjectProcess 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "BankLoanProjectProcess_Search";
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
        ///BankLoanProjectProcess 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<BankLoanProjectProcessInfo></returns>
        public List<BankLoanProjectProcessInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<BankLoanProjectProcessInfo> list = new List<BankLoanProjectProcessInfo>();
            BankLoanProjectProcessInfo accountInfo = new BankLoanProjectProcessInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = BankLoanProjectProcessInfoRowToInfo(row);
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
        /// <param name="BankLoanProjectProcessDataRow">BankLoanProjectProcessDataRow</param>
        /// <returns>BankLoanProjectProcessInfo</returns>
        internal BankLoanProjectProcessInfo BankLoanProjectProcessInfoRowToInfo(DataRow BankLoanProjectProcessInfoInfoDataRow)
        {
            BankLoanProjectProcessInfo BankLoanProjectProcessInfoInfo = new BankLoanProjectProcessInfo();
            if (BankLoanProjectProcessInfoInfoDataRow["ObjectId"] != null)
            {
                BankLoanProjectProcessInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "ObjectId"));
            }
            if (BankLoanProjectProcessInfoInfoDataRow["ForId"] != null)
            {
                BankLoanProjectProcessInfoInfo.ForId = new Guid(DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "ForId"));
            }
            if (BankLoanProjectProcessInfoInfoDataRow["ProjectName"] != null)
            {
                BankLoanProjectProcessInfoInfo.ProjectName = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "ProjectName");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["NeedImprest"] != null)
            {
                BankLoanProjectProcessInfoInfo.NeedImprest = int.Parse(DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "NeedImprest"));
            }
            if (BankLoanProjectProcessInfoInfoDataRow["LoanBank"] != null)
            {
                BankLoanProjectProcessInfoInfo.LoanBank = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "LoanBank");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["GuaranteeCompany"] != null)
            {
                BankLoanProjectProcessInfoInfo.GuaranteeCompany = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "GuaranteeCompany");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["ImplementationPhase"] != null)
            {
                BankLoanProjectProcessInfoInfo.ImplementationPhase = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "ImplementationPhase");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["ImprestAmount"] != null)
            {
                BankLoanProjectProcessInfoInfo.ImprestAmount = Decimal.Parse(DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "ImprestAmount"));
            }
            if (BankLoanProjectProcessInfoInfoDataRow["AmountExpended"] != null)
            {
                BankLoanProjectProcessInfoInfo.AmountExpended = Decimal.Parse(DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "AmountExpended"));
            }
            if (BankLoanProjectProcessInfoInfoDataRow["ExpendedTime"] != null)
            {
                BankLoanProjectProcessInfoInfo.ExpendedTime = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "ExpendedTime");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["ImprestAmountBalance"] != null)
            {
                BankLoanProjectProcessInfoInfo.ImprestAmountBalance = Decimal.Parse(DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "ImprestAmountBalance"));
            }
            if (BankLoanProjectProcessInfoInfoDataRow["Remark"] != null)
            {
                BankLoanProjectProcessInfoInfo.Remark = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "Remark");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["Status"] != null)
            {
                BankLoanProjectProcessInfoInfo.Status = int.Parse(DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "Status"));
            }
            if (BankLoanProjectProcessInfoInfoDataRow["NextOperaterId"] != null)
            {
                BankLoanProjectProcessInfoInfo.NextOperaterId = new Guid(DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "NextOperaterId"));
            }
            if (BankLoanProjectProcessInfoInfoDataRow["NextOperaterAccount"] != null)
            {
                BankLoanProjectProcessInfoInfo.NextOperaterAccount = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "NextOperaterAccount");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["NextOperaterName"] != null)
            {
                BankLoanProjectProcessInfoInfo.NextOperaterName = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "NextOperaterName");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["CreateTime"] != null)
            {
                BankLoanProjectProcessInfoInfo.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "CreateTime"));
            }
            if (BankLoanProjectProcessInfoInfoDataRow["CreaterId"] != null)
            {
                BankLoanProjectProcessInfoInfo.CreaterId = new Guid(DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "CreaterId"));
            }
            if (BankLoanProjectProcessInfoInfoDataRow["CreaterName"] != null)
            {
                BankLoanProjectProcessInfoInfo.CreaterName = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "CreaterName");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["CreaterAccount"] != null)
            {
                BankLoanProjectProcessInfoInfo.CreaterAccount = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "CreaterAccount");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["SubmitTime"] != null)
            {
                BankLoanProjectProcessInfoInfo.SubmitTime = DateTime.Parse(DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "SubmitTime"));
            }
            if (BankLoanProjectProcessInfoInfoDataRow["AuditOpinion"] != null)
            {
                BankLoanProjectProcessInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "AuditOpinion");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["AccountingRemark"] != null)
            {
                BankLoanProjectProcessInfoInfo.AccountingRemark = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "AccountingRemark");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["Use"] != null)
            {
                BankLoanProjectProcessInfoInfo.Use = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "Use");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["ImprestRemark"] != null)
            {
                BankLoanProjectProcessInfoInfo.ImprestRemark = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "ImprestRemark");
            }
            if (BankLoanProjectProcessInfoInfoDataRow["Adulters"] != null)
            {
                BankLoanProjectProcessInfoInfo.Adulters = DataUtil.GetStringValueOfRow(BankLoanProjectProcessInfoInfoDataRow, "Adulters");
            }
            
            return BankLoanProjectProcessInfoInfo;
        }
        #endregion
    }
}
