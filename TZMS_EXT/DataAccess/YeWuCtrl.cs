//----------------------------------------------------------------------------------------------------
//程序名:	YeWu 控制类
//功能:  	定义了与 dbo.YeWu 表 对应的数据访问控制类
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
    /// YeWuCtrl
    /// programmer:shunlian
    /// </summary>
    public class YeWuCtrl
    {
        #region 构造函数

        /// <summary>
        /// YeWuCtrl默认构造函数
        /// </summary>
        public YeWuCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.YeWu一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="YeWuInfo">YeWuInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, YeWuInfo YeWuInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "YeWu_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@UserId",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@Title",DbType.String),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@CurrentCheckerId",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@Isdelete",DbType.Boolean),
				new SqlParameter("@Type",DbType.Int16),
				};

                int i = 0;
                sqlparam[i++].Value = YeWuInfo.ObjectId;
                sqlparam[i++].Value = YeWuInfo.UserId;
                sqlparam[i++].Value = YeWuInfo.UserName;
                sqlparam[i++].Value = YeWuInfo.UserJobNo;
                sqlparam[i++].Value = YeWuInfo.UserAccountNo;
                sqlparam[i++].Value = YeWuInfo.Dept;
                sqlparam[i++].Value = YeWuInfo.Title;
                sqlparam[i++].Value = YeWuInfo.Sument;
                sqlparam[i++].Value = YeWuInfo.Other;
                sqlparam[i++].Value = YeWuInfo.CurrentCheckerId;
                sqlparam[i++].Value = YeWuInfo.State;
                sqlparam[i++].Value = YeWuInfo.Isdelete;
                sqlparam[i++].Value = YeWuInfo.Type;
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
        /// dbo.YeWu删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "YeWu_Delete";

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
        /// YeWu 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="YeWuInfo">YeWuInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, YeWuInfo YeWuInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "YeWu_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@UserId",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@Title",DbType.String),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@CurrentCheckerId",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@Isdelete",DbType.Boolean),
				new SqlParameter("@Type",DbType.Int16),
                };

                int i = 0;
                sqlparam[i++].Value = YeWuInfo.ObjectId;
                sqlparam[i++].Value = YeWuInfo.UserId;
                sqlparam[i++].Value = YeWuInfo.UserName;
                sqlparam[i++].Value = YeWuInfo.UserJobNo;
                sqlparam[i++].Value = YeWuInfo.UserAccountNo;
                sqlparam[i++].Value = YeWuInfo.Dept;
                sqlparam[i++].Value = YeWuInfo.Title;
                sqlparam[i++].Value = YeWuInfo.Sument;
                sqlparam[i++].Value = YeWuInfo.Other;
                sqlparam[i++].Value = YeWuInfo.CurrentCheckerId;
                sqlparam[i++].Value = YeWuInfo.State;
                sqlparam[i++].Value = YeWuInfo.Isdelete;
                sqlparam[i++].Value = YeWuInfo.Type;
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
        /// YeWu 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "YeWu_Search";
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
        ///YeWu 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<YeWuInfo></returns>
        public List<YeWuInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<YeWuInfo> list = new List<YeWuInfo>();
            YeWuInfo accountInfo = new YeWuInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = YeWuInfoRowToInfo(row);
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
        /// <param name="YeWuDataRow">YeWuDataRow</param>
        /// <returns>YeWuInfo</returns>
        internal YeWuInfo YeWuInfoRowToInfo(DataRow YeWuInfoInfoDataRow)
        {
            YeWuInfo YeWuInfoInfo = new YeWuInfo();
            if (YeWuInfoInfoDataRow["ObjectId"] != null)
            {
                YeWuInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(YeWuInfoInfoDataRow, "ObjectId"));
            }
            if (YeWuInfoInfoDataRow["UserId"] != null)
            {
                YeWuInfoInfo.UserId = new Guid(DataUtil.GetStringValueOfRow(YeWuInfoInfoDataRow, "UserId"));
            }
            if (YeWuInfoInfoDataRow["UserName"] != null)
            {
                YeWuInfoInfo.UserName = DataUtil.GetStringValueOfRow(YeWuInfoInfoDataRow, "UserName");
            }
            if (YeWuInfoInfoDataRow["UserJobNo"] != null)
            {
                YeWuInfoInfo.UserJobNo = DataUtil.GetStringValueOfRow(YeWuInfoInfoDataRow, "UserJobNo");
            }
            if (YeWuInfoInfoDataRow["UserAccountNo"] != null)
            {
                YeWuInfoInfo.UserAccountNo = DataUtil.GetStringValueOfRow(YeWuInfoInfoDataRow, "UserAccountNo");
            }
            if (YeWuInfoInfoDataRow["Dept"] != null)
            {
                YeWuInfoInfo.Dept = DataUtil.GetStringValueOfRow(YeWuInfoInfoDataRow, "Dept");
            }
            if (YeWuInfoInfoDataRow["Title"] != null)
            {
                YeWuInfoInfo.Title = DataUtil.GetStringValueOfRow(YeWuInfoInfoDataRow, "Title");
            }
            if (YeWuInfoInfoDataRow["Sument"] != null)
            {
                YeWuInfoInfo.Sument = DataUtil.GetStringValueOfRow(YeWuInfoInfoDataRow, "Sument");
            }
            if (YeWuInfoInfoDataRow["Other"] != null)
            {
                YeWuInfoInfo.Other = DataUtil.GetStringValueOfRow(YeWuInfoInfoDataRow, "Other");
            }
            if (YeWuInfoInfoDataRow["CurrentCheckerId"] != null)
            {
                YeWuInfoInfo.CurrentCheckerId = new Guid(DataUtil.GetStringValueOfRow(YeWuInfoInfoDataRow, "CurrentCheckerId"));
            }
            if (YeWuInfoInfoDataRow["State"] != null)
            {
                YeWuInfoInfo.State = short.Parse(DataUtil.GetStringValueOfRow(YeWuInfoInfoDataRow, "State"));
            }
            if (YeWuInfoInfoDataRow["Isdelete"] != null)
            {
                YeWuInfoInfo.Isdelete = bool.Parse(DataUtil.GetStringValueOfRow(YeWuInfoInfoDataRow, "Isdelete"));
            }
            if (YeWuInfoInfoDataRow["Type"] != null)
            {
                YeWuInfoInfo.Type = short.Parse(DataUtil.GetStringValueOfRow(YeWuInfoInfoDataRow, "Type"));
            }

            return YeWuInfoInfo;
        }
        #endregion
    }
}
