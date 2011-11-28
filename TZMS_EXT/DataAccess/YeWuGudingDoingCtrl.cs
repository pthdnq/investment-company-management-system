//----------------------------------------------------------------------------------------------------
//程序名:	YeWuGudingDoing 控制类
//功能:  	定义了与 dbo.YeWuGudingDoing 表 对应的数据访问控制类
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
    /// YeWuGudingDoingCtrl
    /// programmer:shunlian
    /// </summary>
    public class YeWuGudingDoingCtrl
    {
        #region 构造函数

        /// <summary>
        /// YeWuGudingDoingCtrl默认构造函数
        /// </summary>
        public YeWuGudingDoingCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.YeWuGudingDoing一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="YeWuGudingDoingInfo">YeWuGudingDoingInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, YeWuGudingDoingInfo YeWuGudingDoingInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "YeWuGudingDoing_Add";
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
				new SqlParameter("@OrderIndex",DbType.Int16),
				};

                int i = 0;
                sqlparam[i++].Value = YeWuGudingDoingInfo.ObjectId;
                sqlparam[i++].Value = YeWuGudingDoingInfo.CheckerId;
                sqlparam[i++].Value = YeWuGudingDoingInfo.CheckerName;
                sqlparam[i++].Value = YeWuGudingDoingInfo.CheckrDept;
                sqlparam[i++].Value = YeWuGudingDoingInfo.CheckDateTime;
                sqlparam[i++].Value = YeWuGudingDoingInfo.Checkstate;
                sqlparam[i++].Value = YeWuGudingDoingInfo.Result;
                sqlparam[i++].Value = YeWuGudingDoingInfo.CheckSugest;
                sqlparam[i++].Value = YeWuGudingDoingInfo.CheckOp;
                sqlparam[i++].Value = YeWuGudingDoingInfo.ApplyId;
                sqlparam[i++].Value = YeWuGudingDoingInfo.OrderIndex;
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
        /// dbo.YeWuGudingDoing删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "YeWuGudingDoing_Delete";

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
        /// YeWuGudingDoing 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="YeWuGudingDoingInfo">YeWuGudingDoingInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, YeWuGudingDoingInfo YeWuGudingDoingInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "YeWuGudingDoing_Update";
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
				new SqlParameter("@OrderIndex",DbType.Int16),
                };

                int i = 0;
                sqlparam[i++].Value = YeWuGudingDoingInfo.ObjectId;
                sqlparam[i++].Value = YeWuGudingDoingInfo.CheckerId;
                sqlparam[i++].Value = YeWuGudingDoingInfo.CheckerName;
                sqlparam[i++].Value = YeWuGudingDoingInfo.CheckrDept;
                sqlparam[i++].Value = YeWuGudingDoingInfo.CheckDateTime;
                sqlparam[i++].Value = YeWuGudingDoingInfo.Checkstate;
                sqlparam[i++].Value = YeWuGudingDoingInfo.Result;
                sqlparam[i++].Value = YeWuGudingDoingInfo.CheckSugest;
                sqlparam[i++].Value = YeWuGudingDoingInfo.CheckOp;
                sqlparam[i++].Value = YeWuGudingDoingInfo.ApplyId;
                sqlparam[i++].Value = YeWuGudingDoingInfo.OrderIndex;
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
        /// YeWuGudingDoing 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "YeWuGudingDoing_Search";
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
        ///YeWuGudingDoing 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<YeWuGudingDoingInfo></returns>
        public List<YeWuGudingDoingInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<YeWuGudingDoingInfo> list = new List<YeWuGudingDoingInfo>();
            YeWuGudingDoingInfo accountInfo = new YeWuGudingDoingInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = YeWuGudingDoingInfoRowToInfo(row);
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
        /// <param name="YeWuGudingDoingDataRow">YeWuGudingDoingDataRow</param>
        /// <returns>YeWuGudingDoingInfo</returns>
        internal YeWuGudingDoingInfo YeWuGudingDoingInfoRowToInfo(DataRow YeWuGudingDoingInfoInfoDataRow)
        {
            YeWuGudingDoingInfo YeWuGudingDoingInfoInfo = new YeWuGudingDoingInfo();
            if (YeWuGudingDoingInfoInfoDataRow["ObjectId"] != null)
            {
                YeWuGudingDoingInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(YeWuGudingDoingInfoInfoDataRow, "ObjectId"));
            }
            if (YeWuGudingDoingInfoInfoDataRow["CheckerId"] != null)
            {
                YeWuGudingDoingInfoInfo.CheckerId = new Guid(DataUtil.GetStringValueOfRow(YeWuGudingDoingInfoInfoDataRow, "CheckerId"));
            }
            if (YeWuGudingDoingInfoInfoDataRow["CheckerName"] != null)
            {
                YeWuGudingDoingInfoInfo.CheckerName = DataUtil.GetStringValueOfRow(YeWuGudingDoingInfoInfoDataRow, "CheckerName");
            }
            if (YeWuGudingDoingInfoInfoDataRow["CheckrDept"] != null)
            {
                YeWuGudingDoingInfoInfo.CheckrDept = DataUtil.GetStringValueOfRow(YeWuGudingDoingInfoInfoDataRow, "CheckrDept");
            }
            if (YeWuGudingDoingInfoInfoDataRow["CheckDateTime"] != null)
            {
                YeWuGudingDoingInfoInfo.CheckDateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(YeWuGudingDoingInfoInfoDataRow, "CheckDateTime"));
            }
            if (YeWuGudingDoingInfoInfoDataRow["Checkstate"] != null)
            {
                YeWuGudingDoingInfoInfo.Checkstate = short.Parse(DataUtil.GetStringValueOfRow(YeWuGudingDoingInfoInfoDataRow, "Checkstate"));
            }
            if (YeWuGudingDoingInfoInfoDataRow["Result"] != null)
            {
                YeWuGudingDoingInfoInfo.Result = DataUtil.GetStringValueOfRow(YeWuGudingDoingInfoInfoDataRow, "Result");
            }
            if (YeWuGudingDoingInfoInfoDataRow["CheckSugest"] != null)
            {
                YeWuGudingDoingInfoInfo.CheckSugest = DataUtil.GetStringValueOfRow(YeWuGudingDoingInfoInfoDataRow, "CheckSugest");
            }
            if (YeWuGudingDoingInfoInfoDataRow["CheckOp"] != null)
            {
                YeWuGudingDoingInfoInfo.CheckOp = DataUtil.GetStringValueOfRow(YeWuGudingDoingInfoInfoDataRow, "CheckOp");
            }
            if (YeWuGudingDoingInfoInfoDataRow["ApplyId"] != null)
            {
                YeWuGudingDoingInfoInfo.ApplyId = new Guid(DataUtil.GetStringValueOfRow(YeWuGudingDoingInfoInfoDataRow, "ApplyId"));
            }
            if (YeWuGudingDoingInfoInfoDataRow["OrderIndex"] != null)
            {
                YeWuGudingDoingInfoInfo.OrderIndex = short.Parse(DataUtil.GetStringValueOfRow(YeWuGudingDoingInfoInfoDataRow, "OrderIndex"));
            }

            return YeWuGudingDoingInfoInfo;
        }
        #endregion
    }
}
