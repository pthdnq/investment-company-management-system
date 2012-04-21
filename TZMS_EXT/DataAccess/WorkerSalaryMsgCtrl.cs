//----------------------------------------------------------------------------------------------------
//程序名:	WorkerSalaryMsg 控制类
//功能:  	定义了与 dbo.WorkerSalaryMsg 表 对应的数据访问控制类
//作者:  	xiguazerg
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
    /// programmer:xiguazerg
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
				new SqlParameter("@Jbgz",DbType.String),
				new SqlParameter("@Glgz",DbType.String),
				new SqlParameter("@Syqgz",DbType.String),
				new SqlParameter("@Nzj",DbType.String),
				new SqlParameter("@Jlgz",DbType.String),
				new SqlParameter("@Khgz",DbType.String),
				new SqlParameter("@Cb",DbType.String),
				new SqlParameter("@Jtbz",DbType.String),
				new SqlParameter("@Yfgz",DbType.String),
				new SqlParameter("@Cd",DbType.String),
				new SqlParameter("@Zt",DbType.String),
				new SqlParameter("@Kg",DbType.String),
				new SqlParameter("@Sj",DbType.String),
				new SqlParameter("@Bj",DbType.String),
				new SqlParameter("@Sb",DbType.String),
				new SqlParameter("@Fk",DbType.String),
				new SqlParameter("@Cf",DbType.String),
				new SqlParameter("@Bjf",DbType.String),
				new SqlParameter("@Lyf",DbType.String),
				new SqlParameter("@Sfgz",DbType.String),

                				new SqlParameter("@BaseSalaryFlag",DbType.String),
                                				new SqlParameter("@ExamSalaryFlag",DbType.String),
                                                				new SqlParameter("@BackSalaryFlag",DbType.String),
                                                                				new SqlParameter("@OtherSalaryFlag",DbType.String),
                                                                                				new SqlParameter("@ShouldSalaryFlag",DbType.String),
                                                                                                				new SqlParameter("@SalaryFlag",DbType.String),
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
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Jbgz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Glgz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Syqgz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Nzj;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Jlgz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Khgz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Cb;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Jtbz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Yfgz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Cd;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Zt;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Kg;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Sj;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Bj;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Sb;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Fk;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Cf;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Bjf;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Lyf;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Sfgz;

                sqlparam[i++].Value = WorkerSalaryMsgInfo.BaseSalaryFlag;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.ExamSalaryFlag;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.BackSalaryFlag;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.OtherSalaryFlag;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.ShouldSalaryFlag;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.SalaryFlag;
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
				new SqlParameter("@Jbgz",DbType.String),
				new SqlParameter("@Glgz",DbType.String),
				new SqlParameter("@Syqgz",DbType.String),
				new SqlParameter("@Nzj",DbType.String),
				new SqlParameter("@Jlgz",DbType.String),
				new SqlParameter("@Khgz",DbType.String),
				new SqlParameter("@Cb",DbType.String),
				new SqlParameter("@Jtbz",DbType.String),
				new SqlParameter("@Yfgz",DbType.String),
				new SqlParameter("@Cd",DbType.String),
				new SqlParameter("@Zt",DbType.String),
				new SqlParameter("@Kg",DbType.String),
				new SqlParameter("@Sj",DbType.String),
				new SqlParameter("@Bj",DbType.String),
				new SqlParameter("@Sb",DbType.String),
				new SqlParameter("@Fk",DbType.String),
				new SqlParameter("@Cf",DbType.String),
				new SqlParameter("@Bjf",DbType.String),
				new SqlParameter("@Lyf",DbType.String),
				new SqlParameter("@Sfgz",DbType.String),
                                				new SqlParameter("@BaseSalaryFlag",DbType.String),
                                				new SqlParameter("@ExamSalaryFlag",DbType.String),
                                                				new SqlParameter("@BackSalaryFlag",DbType.String),
                                                                				new SqlParameter("@OtherSalaryFlag",DbType.String),
                                                                                				new SqlParameter("@ShouldSalaryFlag",DbType.String),
                                                                                                				new SqlParameter("@SalaryFlag",DbType.String),
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
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Jbgz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Glgz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Syqgz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Nzj;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Jlgz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Khgz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Cb;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Jtbz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Yfgz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Cd;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Zt;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Kg;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Sj;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Bj;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Sb;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Fk;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Cf;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Bjf;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Lyf;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.Sfgz;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.BaseSalaryFlag;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.ExamSalaryFlag;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.BackSalaryFlag;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.OtherSalaryFlag;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.ShouldSalaryFlag;
                sqlparam[i++].Value = WorkerSalaryMsgInfo.SalaryFlag;
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
        internal WorkerSalaryMsgInfo WorkerSalaryMsgInfoRowToInfo(DataRow InfoDataRow)
        {
            WorkerSalaryMsgInfo Info = new WorkerSalaryMsgInfo();
            if (InfoDataRow["ObjectId"] != null)
            {
                Info.ObjectId = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectId"));
            }
            if (InfoDataRow["UserId"] != null)
            {
                Info.UserId = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "UserId"));
            }
            if (InfoDataRow["Name"] != null)
            {
                Info.Name = DataUtil.GetStringValueOfRow(InfoDataRow, "Name");
            }
            if (InfoDataRow["Dept"] != null)
            {
                Info.Dept = DataUtil.GetStringValueOfRow(InfoDataRow, "Dept");
            }
            if (InfoDataRow["BaseSalary"] != null)
            {
                Info.BaseSalary = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "BaseSalary"));
            }
            if (InfoDataRow["ExamSalary"] != null)
            {
                Info.ExamSalary = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "ExamSalary"));
            }
            if (InfoDataRow["BackSalary"] != null)
            {
                Info.BackSalary = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "BackSalary"));
            }
            if (InfoDataRow["OtherSalary"] != null)
            {
                Info.OtherSalary = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "OtherSalary"));
            }
            if (InfoDataRow["ShouldSalary"] != null)
            {
                Info.ShouldSalary = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "ShouldSalary"));
            }
            if (InfoDataRow["Salary"] != null)
            {
                Info.Salary = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "Salary"));
            }
            if (InfoDataRow["Context"] != null)
            {
                Info.Context = DataUtil.GetStringValueOfRow(InfoDataRow, "Context");
            }
            if (InfoDataRow["SalaryMsgId"] != null)
            {
                Info.SalaryMsgId = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "SalaryMsgId"));
            }
            if (InfoDataRow["Jbgz"] != null)
            {
                Info.Jbgz = DataUtil.GetStringValueOfRow(InfoDataRow, "Jbgz");
            }
            if (InfoDataRow["Glgz"] != null)
            {
                Info.Glgz = DataUtil.GetStringValueOfRow(InfoDataRow, "Glgz");
            }
            if (InfoDataRow["Syqgz"] != null)
            {
                Info.Syqgz = DataUtil.GetStringValueOfRow(InfoDataRow, "Syqgz");
            }
            if (InfoDataRow["Nzj"] != null)
            {
                Info.Nzj = DataUtil.GetStringValueOfRow(InfoDataRow, "Nzj");
            }
            if (InfoDataRow["Jlgz"] != null)
            {
                Info.Jlgz = DataUtil.GetStringValueOfRow(InfoDataRow, "Jlgz");
            }
            if (InfoDataRow["Khgz"] != null)
            {
                Info.Khgz = DataUtil.GetStringValueOfRow(InfoDataRow, "Khgz");
            }
            if (InfoDataRow["Cb"] != null)
            {
                Info.Cb = DataUtil.GetStringValueOfRow(InfoDataRow, "Cb");
            }
            if (InfoDataRow["Jtbz"] != null)
            {
                Info.Jtbz = DataUtil.GetStringValueOfRow(InfoDataRow, "Jtbz");
            }
            if (InfoDataRow["Yfgz"] != null)
            {
                Info.Yfgz = DataUtil.GetStringValueOfRow(InfoDataRow, "Yfgz");
            }
            if (InfoDataRow["Cd"] != null)
            {
                Info.Cd = DataUtil.GetStringValueOfRow(InfoDataRow, "Cd");
            }
            if (InfoDataRow["Zt"] != null)
            {
                Info.Zt = DataUtil.GetStringValueOfRow(InfoDataRow, "Zt");
            }
            if (InfoDataRow["Kg"] != null)
            {
                Info.Kg = DataUtil.GetStringValueOfRow(InfoDataRow, "Kg");
            }
            if (InfoDataRow["Sj"] != null)
            {
                Info.Sj = DataUtil.GetStringValueOfRow(InfoDataRow, "Sj");
            }
            if (InfoDataRow["Bj"] != null)
            {
                Info.Bj = DataUtil.GetStringValueOfRow(InfoDataRow, "Bj");
            }
            if (InfoDataRow["Sb"] != null)
            {
                Info.Sb = DataUtil.GetStringValueOfRow(InfoDataRow, "Sb");
            }
            if (InfoDataRow["Fk"] != null)
            {
                Info.Fk = DataUtil.GetStringValueOfRow(InfoDataRow, "Fk");
            }
            if (InfoDataRow["Cf"] != null)
            {
                Info.Cf = DataUtil.GetStringValueOfRow(InfoDataRow, "Cf");
            }
            if (InfoDataRow["Bjf"] != null)
            {
                Info.Bjf = DataUtil.GetStringValueOfRow(InfoDataRow, "Bjf");
            }
            if (InfoDataRow["Lyf"] != null)
            {
                Info.Lyf = DataUtil.GetStringValueOfRow(InfoDataRow, "Lyf");
            }
            if (InfoDataRow["Sfgz"] != null)
            {
                Info.Sfgz = DataUtil.GetStringValueOfRow(InfoDataRow, "Sfgz");
            }

            if (InfoDataRow["BaseSalaryFlag"] != null)
            {
                Info.BaseSalaryFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "BaseSalaryFlag");
            }
            if (InfoDataRow["SalaryFlag"] != null)
            {
                Info.SalaryFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "SalaryFlag");
            }
            if (InfoDataRow["ExamSalaryFlag"] != null)
            {
                Info.ExamSalaryFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "ExamSalaryFlag");
            }
            if (InfoDataRow["BackSalaryFlag"] != null)
            {
                Info.BackSalaryFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "BackSalaryFlag");
            }
            if (InfoDataRow["OtherSalaryFlag"] != null)
            {
                Info.OtherSalaryFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "OtherSalaryFlag");
            }
            if (InfoDataRow["ShouldSalaryFlag"] != null)
            {
                Info.ShouldSalaryFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "ShouldSalaryFlag");
            }

            return Info;
        }
        #endregion
    }
}
