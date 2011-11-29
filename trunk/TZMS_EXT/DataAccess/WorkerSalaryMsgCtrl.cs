//----------------------------------------------------------------------------------------------------
//程序名:	WorkerSalaryMsg 控制类
//功能:  	定义了与 dbo.WorkerSalaryMsg 表 对应的数据访问控制类
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
    /// WorkerSalaryMsgCtrl
    /// programmer:shunlian
    /// </summary>
    public class WorkerSalaryMsgCtrl
    {
        #region 构造函数

        /// <summary>
        /// WorkerSalaryMsgCtrl默认构造函数
        /// </summary>
        public WorkerSalaryMsgCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.WorkerSalaryMsg一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="WorkerSalaryMsgInfo">WorkerSalaryMsgInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, WorkerSalaryMsgInfo WorkerSalaryMsgInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "WorkerSalaryMsg_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@UserId",DbType.Guid),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@BaseSalary",DbType.Guid),
				new SqlParameter("@ExamSalary",DbType.Guid),
				new SqlParameter("@BackSalary",DbType.Guid),
				new SqlParameter("@OtherSalary",DbType.Guid),
				new SqlParameter("@ShouldSalary",DbType.Guid),
				new SqlParameter("@Salary",DbType.Guid),
				new SqlParameter("@Context",DbType.String),
				new SqlParameter("@SalaryMsgId",DbType.Guid),
				};

                int i = 0;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.ObjectId;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.UserId;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Name;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Dept;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.BaseSalary;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.ExamSalary;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.BackSalary;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.OtherSalary;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.ShouldSalary;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Salary;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Context;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.SalaryMsgId;
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
        /// dbo.WorkerSalaryMsg删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "WorkerSalaryMsg_Delete";

                SqlParameter[] sqlparam =
				{
					new SqlParameter ( "@Condition", SqlDbType.NVarChar )
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
        /// WorkerSalaryMsg 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="WorkerSalaryMsgInfo">WorkerSalaryMsgInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, WorkerSalaryMsgInfo WorkerSalaryMsgInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "WorkerSalaryMsg_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@UserId",DbType.Guid),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@BaseSalary",DbType.Guid),
				new SqlParameter("@ExamSalary",DbType.Guid),
				new SqlParameter("@BackSalary",DbType.Guid),
				new SqlParameter("@OtherSalary",DbType.Guid),
				new SqlParameter("@ShouldSalary",DbType.Guid),
				new SqlParameter("@Salary",DbType.Guid),
				new SqlParameter("@Context",DbType.String),
				new SqlParameter("@SalaryMsgId",DbType.Guid),
                };

                int i = 0;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.ObjectId;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.UserId;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Name;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Dept;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.BaseSalary;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.ExamSalary;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.BackSalary;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.OtherSalary;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.ShouldSalary;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Salary;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Context;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.SalaryMsgId;
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
        /// WorkerSalaryMsg 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "WorkerSalaryMsg_Search";
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
        ///WorkerSalaryMsg 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<WorkerSalaryMsgInfo></returns>
        public List<WorkerSalaryMsgInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<WorkerSalaryMsgInfo> list = new List<WorkerSalaryMsgInfo>();
            WorkerSalaryMsgInfo accountInfo = new WorkerSalaryMsgInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = WorkerSalaryMsgInfoRowToInfo(row);
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
        /// <param name="WorkerSalaryMsgDataRow">WorkerSalaryMsgDataRow</param>
        /// <returns>WorkerSalaryMsgInfo</returns>
        internal WorkerSalaryMsgInfo WorkerSalaryMsgInfoRowToInfo(DataRow WorkerSalaryMsgInfoInfoDataRow)
        {
            WorkerSalaryMsgInfo WorkerSalaryMsgInfoInfo = new WorkerSalaryMsgInfo();
            if (WorkerSalaryMsgInfoInfoDataRow["ObjectId"] != null)
            {
                WorkerSalaryMsgInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(WorkerSalaryMsgInfoInfoDataRow, "ObjectId"));
            }
            if (WorkerSalaryMsgInfoInfoDataRow["UserId"] != null)
            {
                WorkerSalaryMsgInfoInfo.UserId = new Guid(DataUtil.GetStringValueOfRow(WorkerSalaryMsgInfoInfoDataRow, "UserId"));
            }
            if (WorkerSalaryMsgInfoInfoDataRow["Name"] != null)
            {
                WorkerSalaryMsgInfoInfo.Name = DataUtil.GetStringValueOfRow(WorkerSalaryMsgInfoInfoDataRow, "Name");
            }
            if (WorkerSalaryMsgInfoInfoDataRow["Dept"] != null)
            {
                WorkerSalaryMsgInfoInfo.Dept = DataUtil.GetStringValueOfRow(WorkerSalaryMsgInfoInfoDataRow, "Dept");
            }
            if (WorkerSalaryMsgInfoInfoDataRow["BaseSalary"] != null)
            {
                WorkerSalaryMsgInfoInfo.BaseSalary = decimal.Parse(DataUtil.GetStringValueOfRow(WorkerSalaryMsgInfoInfoDataRow, "BaseSalary"));
            }
            if (WorkerSalaryMsgInfoInfoDataRow["ExamSalary"] != null)
            {
                WorkerSalaryMsgInfoInfo.ExamSalary = decimal.Parse(DataUtil.GetStringValueOfRow(WorkerSalaryMsgInfoInfoDataRow, "ExamSalary"));
            }
            if (WorkerSalaryMsgInfoInfoDataRow["BackSalary"] != null)
            {
                WorkerSalaryMsgInfoInfo.BackSalary = decimal.Parse(DataUtil.GetStringValueOfRow(WorkerSalaryMsgInfoInfoDataRow, "BackSalary"));
            }
            if (WorkerSalaryMsgInfoInfoDataRow["OtherSalary"] != null)
            {
                WorkerSalaryMsgInfoInfo.OtherSalary = decimal.Parse(DataUtil.GetStringValueOfRow(WorkerSalaryMsgInfoInfoDataRow, "OtherSalary"));
            }
            if (WorkerSalaryMsgInfoInfoDataRow["ShouldSalary"] != null)
            {
                WorkerSalaryMsgInfoInfo.ShouldSalary = decimal.Parse(DataUtil.GetStringValueOfRow(WorkerSalaryMsgInfoInfoDataRow, "ShouldSalary"));
            }
            if (WorkerSalaryMsgInfoInfoDataRow["Salary"] != null)
            {
                WorkerSalaryMsgInfoInfo.Salary = decimal.Parse(DataUtil.GetStringValueOfRow(WorkerSalaryMsgInfoInfoDataRow, "Salary"));
            }
            if (WorkerSalaryMsgInfoInfoDataRow["Context"] != null)
            {
                WorkerSalaryMsgInfoInfo.Context = DataUtil.GetStringValueOfRow(WorkerSalaryMsgInfoInfoDataRow, "Context");
            }
            if (WorkerSalaryMsgInfoInfoDataRow["SalaryMsgId"] != null)
            {
                WorkerSalaryMsgInfoInfo.SalaryMsgId = new Guid(DataUtil.GetStringValueOfRow(WorkerSalaryMsgInfoInfoDataRow, "SalaryMsgId"));
            }

            return WorkerSalaryMsgInfoInfo;
        }
        #endregion
    }
}
