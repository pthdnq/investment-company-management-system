//----------------------------------------------------------------------------------------------------
//程序名:	WuZhiRecord 控制类
//功能:  	定义了与 dbo.WuZhiRecord 表 对应的数据访问控制类
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
    /// WuZhiRecordCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class WuZhiRecordCtrl
    {
        #region 构造函数

        /// <summary>
        /// WuZhiRecordCtrl默认构造函数
        /// </summary>
        public WuZhiRecordCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.WuZhiRecord一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="WuZhiRecordInfo">WuZhiRecordInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, WuZhiRecordInfo WuZhiRecordInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "WuZhiRecord_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@UserId",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@WuzhiObjectId",DbType.Guid),
				new SqlParameter("@Title",DbType.String),
				new SqlParameter("@Record",DbType.String),
				new SqlParameter("@RecorderId",DbType.Guid),
				new SqlParameter("@RecorderName",DbType.String),
				new SqlParameter("@Isdelete",DbType.Boolean),
				};

                int i = 0;
                sqlparam[i++].Value = WuZhiRecordInfo.ObjectId;
                sqlparam[i++].Value = WuZhiRecordInfo.UserId;
                sqlparam[i++].Value = WuZhiRecordInfo.UserName;
                sqlparam[i++].Value = WuZhiRecordInfo.UserJobNo;
                sqlparam[i++].Value = WuZhiRecordInfo.UserAccountNo;
                sqlparam[i++].Value = WuZhiRecordInfo.Dept;
                sqlparam[i++].Value = WuZhiRecordInfo.WuzhiObjectId;
                sqlparam[i++].Value = WuZhiRecordInfo.Title;
                sqlparam[i++].Value = WuZhiRecordInfo.Record;
                sqlparam[i++].Value = WuZhiRecordInfo.RecorderId;
                sqlparam[i++].Value = WuZhiRecordInfo.RecorderName;
                sqlparam[i++].Value = WuZhiRecordInfo.Isdelete;
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
        /// dbo.WuZhiRecord删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "WuZhiRecord_Delete";

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
        /// WuZhiRecord 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="WuZhiRecordInfo">WuZhiRecordInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, WuZhiRecordInfo WuZhiRecordInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "WuZhiRecord_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@UserId",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@WuzhiObjectId",DbType.Guid),
				new SqlParameter("@Title",DbType.String),
				new SqlParameter("@Record",DbType.String),
				new SqlParameter("@RecorderId",DbType.Guid),
				new SqlParameter("@RecorderName",DbType.String),
				new SqlParameter("@Isdelete",DbType.Boolean),
                };

                int i = 0;
                sqlparam[i++].Value = WuZhiRecordInfo.ObjectId;
                sqlparam[i++].Value = WuZhiRecordInfo.UserId;
                sqlparam[i++].Value = WuZhiRecordInfo.UserName;
                sqlparam[i++].Value = WuZhiRecordInfo.UserJobNo;
                sqlparam[i++].Value = WuZhiRecordInfo.UserAccountNo;
                sqlparam[i++].Value = WuZhiRecordInfo.Dept;
                sqlparam[i++].Value = WuZhiRecordInfo.WuzhiObjectId;
                sqlparam[i++].Value = WuZhiRecordInfo.Title;
                sqlparam[i++].Value = WuZhiRecordInfo.Record;
                sqlparam[i++].Value = WuZhiRecordInfo.RecorderId;
                sqlparam[i++].Value = WuZhiRecordInfo.RecorderName;
                sqlparam[i++].Value = WuZhiRecordInfo.Isdelete;
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
        /// WuZhiRecord 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "WuZhiRecord_Search";
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
        ///WuZhiRecord 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<WuZhiRecordInfo></returns>
        public List<WuZhiRecordInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<WuZhiRecordInfo> list = new List<WuZhiRecordInfo>();
            WuZhiRecordInfo accountInfo = new WuZhiRecordInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = WuZhiRecordInfoRowToInfo(row);
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
        /// <param name="WuZhiRecordDataRow">WuZhiRecordDataRow</param>
        /// <returns>WuZhiRecordInfo</returns>
        internal WuZhiRecordInfo WuZhiRecordInfoRowToInfo(DataRow InfoDataRow)
        {
            WuZhiRecordInfo Info = new WuZhiRecordInfo();
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
            if (InfoDataRow["WuzhiObjectId"] != null)
            {
                Info.WuzhiObjectId = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "WuzhiObjectId"));
            }
            if (InfoDataRow["Title"] != null)
            {
                Info.Title = DataUtil.GetStringValueOfRow(InfoDataRow, "Title");
            }
            if (InfoDataRow["Record"] != null)
            {
                Info.Record = DataUtil.GetStringValueOfRow(InfoDataRow, "Record");
            }
            if (InfoDataRow["RecorderId"] != null)
            {
                Info.RecorderId = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "RecorderId"));
            }
            if (InfoDataRow["RecorderName"] != null)
            {
                Info.RecorderName = DataUtil.GetStringValueOfRow(InfoDataRow, "RecorderName");
            }
            if (InfoDataRow["Isdelete"] != null)
            {
                Info.Isdelete = bool.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "Isdelete"));
            }

            return Info;
        }
        #endregion
    }
}
