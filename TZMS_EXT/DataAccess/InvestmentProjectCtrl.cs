//----------------------------------------------------------------------------------------------------
//程序名:	InvestmentProject 控制类
//功能:  	定义了与 dbo.InvestmentProject 表 对应的数据访问控制类
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
    /// InvestmentProjectCtrl
    /// programmer:shunlian
    /// </summary>
    public class InvestmentProjectCtrl
    {
        #region 构造函数

        /// <summary>
        /// InvestmentProjectCtrl默认构造函数
        /// </summary>
        public InvestmentProjectCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.InvestmentProject一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="InvestmentProjectInfo">InvestmentProjectInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, InvestmentProjectInfo InvestmentProjectInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "InvestmentProject_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjetctId",DbType.Guid),
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
				};

                int i = 0;
                sqlparam[i++].Value = InvestmentProjectInfo.ObjetctId;
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
        /// dbo.InvestmentProject删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
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
        /// InvestmentProject 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="InvestmentProjectInfo">InvestmentProjectInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, InvestmentProjectInfo InvestmentProjectInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "InvestmentProject_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjetctId",DbType.Guid),
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
                };

                int i = 0;
                sqlparam[i++].Value = InvestmentProjectInfo.ObjetctId;
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
        /// InvestmentProject 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "InvestmentProject_Search";
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
        ///InvestmentProject 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
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
            if (InvestmentProjectInfoInfoDataRow["ObjetctId"] != null)
            {
                InvestmentProjectInfoInfo.ObjetctId =    new Guid( DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "ObjetctId"));
            }
            if (InvestmentProjectInfoInfoDataRow["CustomerName"] != null)
            {
                InvestmentProjectInfoInfo.CustomerName = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "CustomerName");
            }
            if (InvestmentProjectInfoInfoDataRow["CustomerId"] != null)
            {
                InvestmentProjectInfoInfo.CustomerId =  new Guid( DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "CustomerId"));
            }
            if (InvestmentProjectInfoInfoDataRow["ProjectName"] != null)
            {
                InvestmentProjectInfoInfo.ProjectName =  DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "ProjectName");
            }
            if (InvestmentProjectInfoInfoDataRow["ProjectOverview"] != null)
            {
                InvestmentProjectInfoInfo.ProjectOverview = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "ProjectOverview");
            }
            if (InvestmentProjectInfoInfoDataRow["SignDate"] != null)
            {
                InvestmentProjectInfoInfo.SignDate =DateTime.Parse( DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "SignDate"));
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
                InvestmentProjectInfoInfo.ContractAmount =Decimal.Parse( DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "ContractAmount"));
            }
            if (InvestmentProjectInfoInfoDataRow["DownPayment"] != null)
            {
                InvestmentProjectInfoInfo.DownPayment =Decimal.Parse( DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "DownPayment"));
            }
            if (InvestmentProjectInfoInfoDataRow["Remark"] != null)
            {
                InvestmentProjectInfoInfo.Remark = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "Remark");
            }
            if (InvestmentProjectInfoInfoDataRow["Status"] != null)
            {
                InvestmentProjectInfoInfo.Status =int.Parse( DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "Status"));
            }
            if (InvestmentProjectInfoInfoDataRow["NextOperaterId"] != null)
            {
                InvestmentProjectInfoInfo.NextOperaterId = new Guid(  DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "NextOperaterId"));
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
                InvestmentProjectInfoInfo.CreateTime =DateTime.Parse( DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "CreateTime"));
            }
            if (InvestmentProjectInfoInfoDataRow["CreaterId"] != null)
            {
                InvestmentProjectInfoInfo.CreaterId = new Guid(  DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "CreaterId"));
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
                InvestmentProjectInfoInfo.SubmitTime =DateTime.Parse( DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "SubmitTime"));
            }
            if (InvestmentProjectInfoInfoDataRow["AuditOpinion"] != null)
            {
                InvestmentProjectInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(InvestmentProjectInfoInfoDataRow, "AuditOpinion");
            }

            return InvestmentProjectInfoInfo;
        }
        #endregion
    }
}
