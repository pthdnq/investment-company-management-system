//----------------------------------------------------------------------------------------------------
//程序名:	SalaryMsg 控制类
//功能:  	定义了与 dbo.SalaryMsg 表 对应的数据访问控制类
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
    /// SalaryMsgCtrl
    /// programmer:shunlian
    /// </summary>
    public class SalaryMsgCtrl
    {
        #region 构造函数

        /// <summary>
        /// SalaryMsgCtrl默认构造函数
        /// </summary>
        public SalaryMsgCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.SalaryMsg一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="SalaryMsgInfo">SalaryMsgInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, SalaryMsgInfo SalaryMsgInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "SalaryMsg_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@Year",DbType.Int32),
				new SqlParameter("@Month",DbType.Int16),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@CurrentCheckerId",DbType.Guid),
                new SqlParameter("@SumMoney",DbType.Decimal)
				};

                int i = 0;
                sqlparam[i++].Value = SalaryMsgInfo.ObjectId;
                sqlparam[i++].Value = SalaryMsgInfo.Year;
                sqlparam[i++].Value = SalaryMsgInfo.Month;
                sqlparam[i++].Value = SalaryMsgInfo.CreateTime;
                sqlparam[i++].Value = SalaryMsgInfo.CreaterId;
                sqlparam[i++].Value = SalaryMsgInfo.Name;
                sqlparam[i++].Value = SalaryMsgInfo.State;
                sqlparam[i++].Value = SalaryMsgInfo.CurrentCheckerId;
                sqlparam[i++].Value = SalaryMsgInfo.SumMoney;
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
        /// dbo.SalaryMsg删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "SalaryMsg_Delete";

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
        /// SalaryMsg 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="SalaryMsgInfo">SalaryMsgInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, SalaryMsgInfo SalaryMsgInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "SalaryMsg_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@Year",DbType.Int32),
				new SqlParameter("@Month",DbType.Int16),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@CurrentCheckerId",DbType.Guid),
                new SqlParameter("@SumMoney",DbType.Decimal)
                };

                int i = 0;
                sqlparam[i++].Value = SalaryMsgInfo.ObjectId;
                sqlparam[i++].Value = SalaryMsgInfo.Year;
                sqlparam[i++].Value = SalaryMsgInfo.Month;
                sqlparam[i++].Value = SalaryMsgInfo.CreateTime;
                sqlparam[i++].Value = SalaryMsgInfo.CreaterId;
                sqlparam[i++].Value = SalaryMsgInfo.Name;
                sqlparam[i++].Value = SalaryMsgInfo.State;
                sqlparam[i++].Value = SalaryMsgInfo.CurrentCheckerId;
                sqlparam[i++].Value = SalaryMsgInfo.SumMoney;
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
        /// SalaryMsg 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "SalaryMsg_Search";
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
        ///SalaryMsg 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<SalaryMsgInfo></returns>
        public List<SalaryMsgInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<SalaryMsgInfo> list = new List<SalaryMsgInfo>();
            SalaryMsgInfo accountInfo = new SalaryMsgInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = SalaryMsgInfoRowToInfo(row);
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
        /// <param name="SalaryMsgDataRow">SalaryMsgDataRow</param>
        /// <returns>SalaryMsgInfo</returns>
        internal SalaryMsgInfo SalaryMsgInfoRowToInfo(DataRow SalaryMsgInfoInfoDataRow)
        {
            SalaryMsgInfo SalaryMsgInfoInfo = new SalaryMsgInfo();
            if (SalaryMsgInfoInfoDataRow["ObjectId"] != null)
            {
                SalaryMsgInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(SalaryMsgInfoInfoDataRow, "ObjectId"));
            }
            if (SalaryMsgInfoInfoDataRow["Year"] != null)
            {
                SalaryMsgInfoInfo.Year = short.Parse(DataUtil.GetStringValueOfRow(SalaryMsgInfoInfoDataRow, "Year"));
            }
            if (SalaryMsgInfoInfoDataRow["Month"] != null)
            {
                SalaryMsgInfoInfo.Month = short.Parse(DataUtil.GetStringValueOfRow(SalaryMsgInfoInfoDataRow, "Month"));
            }
            if (SalaryMsgInfoInfoDataRow["CreateTime"] != null)
            {
                SalaryMsgInfoInfo.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(SalaryMsgInfoInfoDataRow, "CreateTime"));
            }
            if (SalaryMsgInfoInfoDataRow["CreaterId"] != null)
            {
                SalaryMsgInfoInfo.CreaterId = new Guid(DataUtil.GetStringValueOfRow(SalaryMsgInfoInfoDataRow, "CreaterId"));
            }
            if (SalaryMsgInfoInfoDataRow["Name"] != null)
            {
                SalaryMsgInfoInfo.Name = DataUtil.GetStringValueOfRow(SalaryMsgInfoInfoDataRow, "Name");
            }
            if (SalaryMsgInfoInfoDataRow["State"] != null)
            {
                SalaryMsgInfoInfo.State = short.Parse(DataUtil.GetStringValueOfRow(SalaryMsgInfoInfoDataRow, "State"));
            }
            if (SalaryMsgInfoInfoDataRow["CurrentCheckerId"] != null)
            {
                SalaryMsgInfoInfo.CurrentCheckerId = new Guid(DataUtil.GetStringValueOfRow(SalaryMsgInfoInfoDataRow, "CurrentCheckerId"));
            }

            if (SalaryMsgInfoInfoDataRow["SumMoney"] != null)
            {
                SalaryMsgInfoInfo.SumMoney = Convert.ToDecimal(DataUtil.GetStringValueOfRow(SalaryMsgInfoInfoDataRow, "SumMoney"));
            }

            return SalaryMsgInfoInfo;
        }
        #endregion
    }
}
