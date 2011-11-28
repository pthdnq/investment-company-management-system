//----------------------------------------------------------------------------------------------------
//程序名:	SalaryCheck 控制类
//功能:  	定义了与 dbo.SalaryCheck 表 对应的数据访问控制类
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
    /// SalaryCheckCtrl
    /// programmer:shunlian
    /// </summary>
    public class SalaryCheckCtrl
    {
        #region 构造函数

        /// <summary>
        /// SalaryCheckCtrl默认构造函数
        /// </summary>
        public SalaryCheckCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.SalaryCheck一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="SalaryCheckInfo">SalaryCheckInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, SalaryCheckInfo SalaryCheckInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "SalaryCheck_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@CheckerId",DbType.Guid),
				new SqlParameter("@CheckerName",DbType.String),
				new SqlParameter("@CheckrDept",DbType.String),
				new SqlParameter("@CheckDateTime",DbType.DateTime),
				new SqlParameter("@Checkstate",DbType.Int16),
				new SqlParameter("@Result",DbType.String),
				new SqlParameter("@CheckSugest",DbType.String),
				new SqlParameter("@CheckOp",DbType.String),
				new SqlParameter("@ApplyId",DbType.Guid),
				};

                int i = 0;
                sqlparam[i++].Value = SalaryCheckInfo.ObjectId;
                sqlparam[i++].Value = SalaryCheckInfo.CheckerId;
                sqlparam[i++].Value = SalaryCheckInfo.CheckerName;
                sqlparam[i++].Value = SalaryCheckInfo.CheckrDept;
                sqlparam[i++].Value = SalaryCheckInfo.CheckDateTime;
                sqlparam[i++].Value = SalaryCheckInfo.Checkstate;
                sqlparam[i++].Value = SalaryCheckInfo.Result;
                sqlparam[i++].Value = SalaryCheckInfo.CheckSugest;
                sqlparam[i++].Value = SalaryCheckInfo.CheckOp;
                sqlparam[i++].Value = SalaryCheckInfo.ApplyId;
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
        /// dbo.SalaryCheck删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "SalaryCheck_Delete";

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
        /// SalaryCheck 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="SalaryCheckInfo">SalaryCheckInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, SalaryCheckInfo SalaryCheckInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "SalaryCheck_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@CheckerId",DbType.Guid),
				new SqlParameter("@CheckerName",DbType.String),
				new SqlParameter("@CheckrDept",DbType.String),
				new SqlParameter("@CheckDateTime",DbType.DateTime),
				new SqlParameter("@Checkstate",DbType.Int16),
				new SqlParameter("@Result",DbType.String),
				new SqlParameter("@CheckSugest",DbType.String),
				new SqlParameter("@CheckOp",DbType.String),
				new SqlParameter("@ApplyId",DbType.Guid),
                };

                int i = 0;
                sqlparam[i++].Value = SalaryCheckInfo.ObjectId;
                sqlparam[i++].Value = SalaryCheckInfo.CheckerId;
                sqlparam[i++].Value = SalaryCheckInfo.CheckerName;
                sqlparam[i++].Value = SalaryCheckInfo.CheckrDept;
                sqlparam[i++].Value = SalaryCheckInfo.CheckDateTime;
                sqlparam[i++].Value = SalaryCheckInfo.Checkstate;
                sqlparam[i++].Value = SalaryCheckInfo.Result;
                sqlparam[i++].Value = SalaryCheckInfo.CheckSugest;
                sqlparam[i++].Value = SalaryCheckInfo.CheckOp;
                sqlparam[i++].Value = SalaryCheckInfo.ApplyId;
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
        /// SalaryCheck 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "SalaryCheck_Search";
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
        ///SalaryCheck 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<SalaryCheckInfo></returns>
        public List<SalaryCheckInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<SalaryCheckInfo> list = new List<SalaryCheckInfo>();
            SalaryCheckInfo accountInfo = new SalaryCheckInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = SalaryCheckInfoRowToInfo(row);
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
        /// <param name="SalaryCheckDataRow">SalaryCheckDataRow</param>
        /// <returns>SalaryCheckInfo</returns>
        internal SalaryCheckInfo SalaryCheckInfoRowToInfo(DataRow SalaryCheckInfoInfoDataRow)
        {
            SalaryCheckInfo SalaryCheckInfoInfo = new SalaryCheckInfo();
            if (SalaryCheckInfoInfoDataRow["ObjectId"] != null)
            {
                SalaryCheckInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(SalaryCheckInfoInfoDataRow, "ObjectId"));
            }
            if (SalaryCheckInfoInfoDataRow["CheckerId"] != null)
            {
                SalaryCheckInfoInfo.CheckerId = new Guid(DataUtil.GetStringValueOfRow(SalaryCheckInfoInfoDataRow, "CheckerId"));
            }
            if (SalaryCheckInfoInfoDataRow["CheckerName"] != null)
            {
                SalaryCheckInfoInfo.CheckerName = DataUtil.GetStringValueOfRow(SalaryCheckInfoInfoDataRow, "CheckerName");
            }
            if (SalaryCheckInfoInfoDataRow["CheckrDept"] != null)
            {
                SalaryCheckInfoInfo.CheckrDept = DataUtil.GetStringValueOfRow(SalaryCheckInfoInfoDataRow, "CheckrDept");
            }
            if (SalaryCheckInfoInfoDataRow["CheckDateTime"] != null)
            {
                SalaryCheckInfoInfo.CheckDateTime =DateTime.Parse( DataUtil.GetStringValueOfRow(SalaryCheckInfoInfoDataRow, "CheckDateTime"));
            }
            if (SalaryCheckInfoInfoDataRow["Checkstate"] != null)
            {
                SalaryCheckInfoInfo.Checkstate = short.Parse(DataUtil.GetStringValueOfRow(SalaryCheckInfoInfoDataRow, "Checkstate"));
            }
            if (SalaryCheckInfoInfoDataRow["Result"] != null)
            {
                SalaryCheckInfoInfo.Result = DataUtil.GetStringValueOfRow(SalaryCheckInfoInfoDataRow, "Result");
            }
            if (SalaryCheckInfoInfoDataRow["CheckSugest"] != null)
            {
                SalaryCheckInfoInfo.CheckSugest = DataUtil.GetStringValueOfRow(SalaryCheckInfoInfoDataRow, "CheckSugest");
            }
            if (SalaryCheckInfoInfoDataRow["CheckOp"] != null)
            {
                SalaryCheckInfoInfo.CheckOp = DataUtil.GetStringValueOfRow(SalaryCheckInfoInfoDataRow, "CheckOp");
            }
            if (SalaryCheckInfoInfoDataRow["ApplyId"] != null)
            {
                SalaryCheckInfoInfo.ApplyId =new Guid( DataUtil.GetStringValueOfRow(SalaryCheckInfoInfoDataRow, "ApplyId"));
            }

            return SalaryCheckInfoInfo;
        }
        #endregion
    }
}
