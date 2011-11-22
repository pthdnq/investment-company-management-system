//----------------------------------------------------------------------------------------------------
//程序名:	WuzhiCheck 控制类
//功能:  	定义了与 dbo.WuzhiCheck 表 对应的数据访问控制类
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
    /// WuzhiCheckCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class WuzhiCheckCtrl
    {
        #region 构造函数

        /// <summary>
        /// WuzhiCheckCtrl默认构造函数
        /// </summary>
        public WuzhiCheckCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.WuzhiCheck一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="WuzhiCheckInfo">WuzhiCheckInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, WuzhiCheckInfo WuzhiCheckInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "WuzhiCheck_Add";
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
                sqlparam[i++].Value = WuzhiCheckInfo.ObjectId;
                sqlparam[i++].Value = WuzhiCheckInfo.CheckerId;
                sqlparam[i++].Value = WuzhiCheckInfo.CheckerName;
                sqlparam[i++].Value = WuzhiCheckInfo.CheckrDept;
                sqlparam[i++].Value = WuzhiCheckInfo.CheckDateTime;
                sqlparam[i++].Value = WuzhiCheckInfo.Checkstate;
                sqlparam[i++].Value = WuzhiCheckInfo.Result;
                sqlparam[i++].Value = WuzhiCheckInfo.CheckSugest;
                sqlparam[i++].Value = WuzhiCheckInfo.CheckOp;
                sqlparam[i++].Value = WuzhiCheckInfo.ApplyId;
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
        /// dbo.WuzhiCheck删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "WuzhiCheck_Delete";

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
        /// WuzhiCheck 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="WuzhiCheckInfo">WuzhiCheckInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, WuzhiCheckInfo WuzhiCheckInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "WuzhiCheck_Update";
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
                sqlparam[i++].Value = WuzhiCheckInfo.ObjectId;
                sqlparam[i++].Value = WuzhiCheckInfo.CheckerId;
                sqlparam[i++].Value = WuzhiCheckInfo.CheckerName;
                sqlparam[i++].Value = WuzhiCheckInfo.CheckrDept;
                sqlparam[i++].Value = WuzhiCheckInfo.CheckDateTime;
                sqlparam[i++].Value = WuzhiCheckInfo.Checkstate;
                sqlparam[i++].Value = WuzhiCheckInfo.Result;
                sqlparam[i++].Value = WuzhiCheckInfo.CheckSugest;
                sqlparam[i++].Value = WuzhiCheckInfo.CheckOp;
                sqlparam[i++].Value = WuzhiCheckInfo.ApplyId;
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
        /// WuzhiCheck 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "WuzhiCheck_Search";
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
        ///WuzhiCheck 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<WuzhiCheckInfo></returns>
        public List<WuzhiCheckInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<WuzhiCheckInfo> list = new List<WuzhiCheckInfo>();
            WuzhiCheckInfo accountInfo = new WuzhiCheckInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = WuzhiCheckInfoRowToInfo(row);
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
        /// <param name="WuzhiCheckDataRow">WuzhiCheckDataRow</param>
        /// <returns>WuzhiCheckInfo</returns>
        internal WuzhiCheckInfo WuzhiCheckInfoRowToInfo(DataRow InfoDataRow)
        {
            WuzhiCheckInfo Info = new WuzhiCheckInfo();
            if (InfoDataRow["ObjectId"] != null)
            {
                Info.ObjectId = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectId"));
            }
            if (InfoDataRow["CheckerId"] != null)
            {
                Info.CheckerId = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "CheckerId"));
            }
            if (InfoDataRow["CheckerName"] != null)
            {
                Info.CheckerName = DataUtil.GetStringValueOfRow(InfoDataRow, "CheckerName");
            }
            if (InfoDataRow["CheckrDept"] != null)
            {
                Info.CheckrDept = DataUtil.GetStringValueOfRow(InfoDataRow, "CheckrDept");
            }
            if (InfoDataRow["CheckDateTime"] != null)
            {
                Info.CheckDateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "CheckDateTime"));
            }
            if (InfoDataRow["Checkstate"] != null)
            {
                Info.Checkstate = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "Checkstate"));
            }
            if (InfoDataRow["Result"] != null)
            {
                Info.Result = DataUtil.GetStringValueOfRow(InfoDataRow, "Result");
            }
            if (InfoDataRow["CheckSugest"] != null)
            {
                Info.CheckSugest = DataUtil.GetStringValueOfRow(InfoDataRow, "CheckSugest");
            }
            if (InfoDataRow["CheckOp"] != null)
            {
                Info.CheckOp = DataUtil.GetStringValueOfRow(InfoDataRow, "CheckOp");
            }
            if (InfoDataRow["ApplyId"] != null)
            {
                Info.ApplyId = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyId"));
            }

            return Info;
        }
        #endregion
    }
}