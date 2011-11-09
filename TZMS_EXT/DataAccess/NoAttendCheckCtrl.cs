//----------------------------------------------------------------------------------------------------
//程序名:	NoAttendCheck 控制类
//功能:  	定义了与 dbo.NoAttendCheck 表 对应的数据访问控制类
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
    /// NoAttendCheckCtrl
    /// programmer:shunlian
    /// </summary>
    public class NoAttendCheckCtrl
    {
        #region 构造函数

        /// <summary>
        /// NoAttendCheckCtrl默认构造函数
        /// </summary>
        public NoAttendCheckCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.NoAttendCheck一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="NoAttendCheckInfo">NoAttendCheckInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, NoAttendCheckInfo NoAttendCheckInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "NoAttendCheck_Add";
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
                sqlparam[i++].Value = NoAttendCheckInfo.ObjectId;
                sqlparam[i++].Value = NoAttendCheckInfo.CheckerId;
                sqlparam[i++].Value = NoAttendCheckInfo.CheckerName;
                sqlparam[i++].Value = NoAttendCheckInfo.CheckrDept;
                sqlparam[i++].Value = NoAttendCheckInfo.CheckDateTime;
                sqlparam[i++].Value = NoAttendCheckInfo.Checkstate;
                sqlparam[i++].Value = NoAttendCheckInfo.Result;
                sqlparam[i++].Value = NoAttendCheckInfo.CheckSugest;
                sqlparam[i++].Value = NoAttendCheckInfo.CheckOp;
                sqlparam[i++].Value = NoAttendCheckInfo.ApplyId;
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
        /// dbo.NoAttendCheck删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "NoAttendCheck_Delete";

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
        /// NoAttendCheck 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="NoAttendCheckInfo">NoAttendCheckInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, NoAttendCheckInfo NoAttendCheckInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "NoAttendCheck_Update";
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
                sqlparam[i++].Value = NoAttendCheckInfo.ObjectId;
                sqlparam[i++].Value = NoAttendCheckInfo.CheckerId;
                sqlparam[i++].Value = NoAttendCheckInfo.CheckerName;
                sqlparam[i++].Value = NoAttendCheckInfo.CheckrDept;
                sqlparam[i++].Value = NoAttendCheckInfo.CheckDateTime;
                sqlparam[i++].Value = NoAttendCheckInfo.Checkstate;
                sqlparam[i++].Value = NoAttendCheckInfo.Result;
                sqlparam[i++].Value = NoAttendCheckInfo.CheckSugest;
                sqlparam[i++].Value = NoAttendCheckInfo.CheckOp;
                sqlparam[i++].Value = NoAttendCheckInfo.ApplyId;
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
        /// NoAttendCheck 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "NoAttendCheck_Search";
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
        ///NoAttendCheck 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<NoAttendCheckInfo></returns>
        public List<NoAttendCheckInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<NoAttendCheckInfo> list = new List<NoAttendCheckInfo>();
            NoAttendCheckInfo accountInfo = new NoAttendCheckInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = NoAttendCheckInfoRowToInfo(row);
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
        /// <param name="NoAttendCheckDataRow">NoAttendCheckDataRow</param>
        /// <returns>NoAttendCheckInfo</returns>
        internal NoAttendCheckInfo NoAttendCheckInfoRowToInfo(DataRow NoAttendCheckInfoInfoDataRow)
        {
            NoAttendCheckInfo NoAttendCheckInfoInfo = new NoAttendCheckInfo();
            if (NoAttendCheckInfoInfoDataRow["ObjectId"] != null)
            {
                NoAttendCheckInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(NoAttendCheckInfoInfoDataRow, "ObjectId"));
            }
            if (NoAttendCheckInfoInfoDataRow["CheckerId"] != null)
            {
                NoAttendCheckInfoInfo.CheckerId = new Guid(DataUtil.GetStringValueOfRow(NoAttendCheckInfoInfoDataRow, "CheckerId"));
            }
            if (NoAttendCheckInfoInfoDataRow["CheckerName"] != null)
            {
                NoAttendCheckInfoInfo.CheckerName = DataUtil.GetStringValueOfRow(NoAttendCheckInfoInfoDataRow, "CheckerName");
            }
            if (NoAttendCheckInfoInfoDataRow["CheckrDept"] != null)
            {
                NoAttendCheckInfoInfo.CheckrDept = DataUtil.GetStringValueOfRow(NoAttendCheckInfoInfoDataRow, "CheckrDept");
            }
            if (NoAttendCheckInfoInfoDataRow["CheckDateTime"] != null)
            {
                NoAttendCheckInfoInfo.CheckDateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(NoAttendCheckInfoInfoDataRow, "CheckDateTime"));
            }
            if (NoAttendCheckInfoInfoDataRow["Checkstate"] != null)
            {
                NoAttendCheckInfoInfo.Checkstate = short.Parse(DataUtil.GetStringValueOfRow(NoAttendCheckInfoInfoDataRow, "Checkstate"));
            }
            if (NoAttendCheckInfoInfoDataRow["Result"] != null)
            {
                NoAttendCheckInfoInfo.Result = DataUtil.GetStringValueOfRow(NoAttendCheckInfoInfoDataRow, "Result");
            }
            if (NoAttendCheckInfoInfoDataRow["CheckSugest"] != null)
            {
                NoAttendCheckInfoInfo.CheckSugest = DataUtil.GetStringValueOfRow(NoAttendCheckInfoInfoDataRow, "CheckSugest");
            }
            if (NoAttendCheckInfoInfoDataRow["CheckOp"] != null)
            {
                NoAttendCheckInfoInfo.CheckOp = DataUtil.GetStringValueOfRow(NoAttendCheckInfoInfoDataRow, "CheckOp");
            }
            if (NoAttendCheckInfoInfoDataRow["ApplyId"] != null)
            {
                NoAttendCheckInfoInfo.ApplyId = new Guid(DataUtil.GetStringValueOfRow(NoAttendCheckInfoInfoDataRow, "ApplyId"));
            }

            return NoAttendCheckInfoInfo;
        }
        #endregion
    }
}
