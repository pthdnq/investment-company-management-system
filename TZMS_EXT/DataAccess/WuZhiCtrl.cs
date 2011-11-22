//----------------------------------------------------------------------------------------------------
//程序名:	 WuZhi 控制类
//功能:  	定义了与 dbo.WuZhi 表 对应的数据访问控制类
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
    /// WuZhiCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class WuZhiCtrl
    {
        #region 构造函数

        /// <summary>
        /// WuZhiCtrl默认构造函数
        /// </summary>
        public WuZhiCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.WuZhi一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="WuZhiInfo">WuZhiInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, WuZhiInfo WuZhiInfo)
        {
            try
            {
                //存储过程名称
                string strsql = " WuZhi_Add";
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
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@CurrentCheckerId",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@Isdelete",DbType.Boolean),
				new SqlParameter("@Type",DbType.Int16),
				};

                int i = 0;
                sqlparam[i++].Value = WuZhiInfo.ObjectId;
                sqlparam[i++].Value = WuZhiInfo.UserId;
                sqlparam[i++].Value = WuZhiInfo.UserName;
                sqlparam[i++].Value = WuZhiInfo.UserJobNo;
                sqlparam[i++].Value = WuZhiInfo.UserAccountNo;
                sqlparam[i++].Value = WuZhiInfo.Dept;
                sqlparam[i++].Value = WuZhiInfo.Title;
                sqlparam[i++].Value = WuZhiInfo.Sument;
                sqlparam[i++].Value = WuZhiInfo.Other;
                sqlparam[i++].Value = WuZhiInfo.ApplyTime;
                sqlparam[i++].Value = WuZhiInfo.CurrentCheckerId;
                sqlparam[i++].Value = WuZhiInfo.State;
                sqlparam[i++].Value = WuZhiInfo.Isdelete;
                sqlparam[i++].Value = WuZhiInfo.Type;
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
        /// dbo.WuZhi删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = " WuZhi_Delete";

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
        ///  WuZhi 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="WuZhiInfo">WuZhiInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, WuZhiInfo WuZhiInfo)
        {
            try
            {
                //存储过程名称
                string strsql = " WuZhi_Update";
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
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@CurrentCheckerId",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@Isdelete",DbType.Boolean),
				new SqlParameter("@Type",DbType.Int16),
                };

                int i = 0;
                sqlparam[i++].Value = WuZhiInfo.ObjectId;
                sqlparam[i++].Value = WuZhiInfo.UserId;
                sqlparam[i++].Value = WuZhiInfo.UserName;
                sqlparam[i++].Value = WuZhiInfo.UserJobNo;
                sqlparam[i++].Value = WuZhiInfo.UserAccountNo;
                sqlparam[i++].Value = WuZhiInfo.Dept;
                sqlparam[i++].Value = WuZhiInfo.Title;
                sqlparam[i++].Value = WuZhiInfo.Sument;
                sqlparam[i++].Value = WuZhiInfo.Other;
                sqlparam[i++].Value = WuZhiInfo.ApplyTime;
                sqlparam[i++].Value = WuZhiInfo.CurrentCheckerId;
                sqlparam[i++].Value = WuZhiInfo.State;
                sqlparam[i++].Value = WuZhiInfo.Isdelete;
                sqlparam[i++].Value = WuZhiInfo.Type;
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
        ///  WuZhi 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = " WuZhi_Search";
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
        /// WuZhi 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<WuZhiInfo></returns>
        public List<WuZhiInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<WuZhiInfo> list = new List<WuZhiInfo>();
            WuZhiInfo accountInfo = new WuZhiInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = WuZhiInfoRowToInfo(row);
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
        /// <param name=" WuZhiDataRow"> WuZhiDataRow</param>
        /// <returns>WuZhiInfo</returns>
        internal WuZhiInfo WuZhiInfoRowToInfo(DataRow InfoDataRow)
        {
            WuZhiInfo Info = new WuZhiInfo();
            if (InfoDataRow["ObjectId"] != null)
            {
                Info.ObjectId = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectId"));
            }
            if (InfoDataRow["UserId"] != null)
            {
                Info.UserId = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "UserId"));
            }
            if (InfoDataRow["UserName"] != null)
            {
                Info.UserName = DataUtil.GetStringValueOfRow(InfoDataRow, "UserName");
            }
            if (InfoDataRow["UserJobNo"] != null)
            {
                Info.UserJobNo = DataUtil.GetStringValueOfRow(InfoDataRow, "UserJobNo");
            }
            if (InfoDataRow["UserAccountNo"] != null)
            {
                Info.UserAccountNo = DataUtil.GetStringValueOfRow(InfoDataRow, "UserAccountNo");
            }
            if (InfoDataRow["Dept"] != null)
            {
                Info.Dept = DataUtil.GetStringValueOfRow(InfoDataRow, "Dept");
            }
            if (InfoDataRow["Title"] != null)
            {
                Info.Title = DataUtil.GetStringValueOfRow(InfoDataRow, "Title");
            }
            if (InfoDataRow["Sument"] != null)
            {
                Info.Sument = DataUtil.GetStringValueOfRow(InfoDataRow, "Sument");
            }
            if (InfoDataRow["Other"] != null)
            {
                Info.Other = DataUtil.GetStringValueOfRow(InfoDataRow, "Other");
            }
            if (InfoDataRow["ApplyTime"] != null)
            {
                Info.ApplyTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyTime"));
            }
            if (InfoDataRow["CurrentCheckerId"] != null)
            {
                Info.CurrentCheckerId = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "CurrentCheckerId"));
            }
            if (InfoDataRow["State"] != null)
            {
                Info.State = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "State"));
            }
            if (InfoDataRow["Isdelete"] != null)
            {
                Info.Isdelete = bool.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "Isdelete"));
            }
            if (InfoDataRow["Type"] != null)
            {
                Info.Type = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "Type"));
            }

            return Info;
        }
        #endregion
    }
}
