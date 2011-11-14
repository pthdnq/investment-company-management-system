//----------------------------------------------------------------------------------------------------
//程序名:	SentMessage 控制类
//功能:  	定义了与 dbo.SentMessage 表 对应的数据访问控制类
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
    /// SentMessageCtrl
    /// programmer:shunlian
    /// </summary>
    public class SentMessageCtrl
    {
        #region 构造函数

        /// <summary>
        /// SentMessageCtrl默认构造函数
        /// </summary>
        public SentMessageCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.SentMessage一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="SentMessageInfo">SentMessageInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, SentMessageInfo SentMessageInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "SentMessage_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@SenderId",DbType.Guid),
				new SqlParameter("@SenderName",DbType.String),
				new SqlParameter("@DeptName",DbType.String),
				new SqlParameter("@Tile",DbType.String),
				new SqlParameter("@Context",DbType.String),
				new SqlParameter("@Recevicer",DbType.String),
				new SqlParameter("@SendDate",DbType.DateTime),
				new SqlParameter("@IsDelete",DbType.Boolean),
				};

                int i = 0;
                sqlparam[i++].Value = SentMessageInfo.ObjectId;
                sqlparam[i++].Value = SentMessageInfo.SenderId;
                sqlparam[i++].Value = SentMessageInfo.SenderName;
                sqlparam[i++].Value = SentMessageInfo.DeptName;
                sqlparam[i++].Value = SentMessageInfo.Tile;
                sqlparam[i++].Value = SentMessageInfo.Context;
                sqlparam[i++].Value = SentMessageInfo.Recevicer;
                sqlparam[i++].Value = SentMessageInfo.SendDate;
                sqlparam[i++].Value = SentMessageInfo.IsDelete;
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
        /// dbo.SentMessage删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "SentMessage_Delete";

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
        /// SentMessage 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="SentMessageInfo">SentMessageInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, SentMessageInfo SentMessageInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "SentMessage_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@SenderId",DbType.Guid),
				new SqlParameter("@SenderName",DbType.String),
				new SqlParameter("@DeptName",DbType.String),
				new SqlParameter("@Tile",DbType.String),
				new SqlParameter("@Context",DbType.String),
				new SqlParameter("@Recevicer",DbType.String),
				new SqlParameter("@SendDate",DbType.DateTime),
				new SqlParameter("@IsDelete",DbType.Boolean),
                };

                int i = 0;
                sqlparam[i++].Value = SentMessageInfo.ObjectId;
                sqlparam[i++].Value = SentMessageInfo.SenderId;
                sqlparam[i++].Value = SentMessageInfo.SenderName;
                sqlparam[i++].Value = SentMessageInfo.DeptName;
                sqlparam[i++].Value = SentMessageInfo.Tile;
                sqlparam[i++].Value = SentMessageInfo.Context;
                sqlparam[i++].Value = SentMessageInfo.Recevicer;
                sqlparam[i++].Value = SentMessageInfo.SendDate;
                sqlparam[i++].Value = SentMessageInfo.IsDelete;
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
        /// SentMessage 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "SentMessage_Search";
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
        ///SentMessage 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<SentMessageInfo></returns>
        public List<SentMessageInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<SentMessageInfo> list = new List<SentMessageInfo>();
            SentMessageInfo accountInfo = new SentMessageInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = SentMessageInfoRowToInfo(row);
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
        /// <param name="SentMessageDataRow">SentMessageDataRow</param>
        /// <returns>SentMessageInfo</returns>
        internal SentMessageInfo SentMessageInfoRowToInfo(DataRow SentMessageInfoInfoDataRow)
        {
            SentMessageInfo SentMessageInfoInfo = new SentMessageInfo();
            if (SentMessageInfoInfoDataRow["ObjectId"] != null)
            {
                SentMessageInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(SentMessageInfoInfoDataRow, "ObjectId"));
            }
            if (SentMessageInfoInfoDataRow["SenderId"] != null)
            {
                SentMessageInfoInfo.SenderId = new Guid(DataUtil.GetStringValueOfRow(SentMessageInfoInfoDataRow, "SenderId"));
            }
            if (SentMessageInfoInfoDataRow["SenderName"] != null)
            {
                SentMessageInfoInfo.SenderName = DataUtil.GetStringValueOfRow(SentMessageInfoInfoDataRow, "SenderName");
            }
            if (SentMessageInfoInfoDataRow["DeptName"] != null)
            {
                SentMessageInfoInfo.DeptName = DataUtil.GetStringValueOfRow(SentMessageInfoInfoDataRow, "DeptName");
            }
            if (SentMessageInfoInfoDataRow["Tile"] != null)
            {
                SentMessageInfoInfo.Tile = DataUtil.GetStringValueOfRow(SentMessageInfoInfoDataRow, "Tile");
            }
            if (SentMessageInfoInfoDataRow["Context"] != null)
            {
                SentMessageInfoInfo.Context = DataUtil.GetStringValueOfRow(SentMessageInfoInfoDataRow, "Context");
            }
            if (SentMessageInfoInfoDataRow["Recevicer"] != null)
            {
                SentMessageInfoInfo.Recevicer = DataUtil.GetStringValueOfRow(SentMessageInfoInfoDataRow, "Recevicer");
            }
            if (SentMessageInfoInfoDataRow["SendDate"] != null)
            {
                SentMessageInfoInfo.SendDate = DateTime.Parse(DataUtil.GetStringValueOfRow(SentMessageInfoInfoDataRow, "SendDate"));
            }
            if (SentMessageInfoInfoDataRow["IsDelete"] != null)
            {
                SentMessageInfoInfo.IsDelete = bool.Parse(DataUtil.GetStringValueOfRow(SentMessageInfoInfoDataRow, "IsDelete"));
            }

            return SentMessageInfoInfo;
        }
        #endregion
    }
}
