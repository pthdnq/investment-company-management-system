//----------------------------------------------------------------------------------------------------
//程序名:	Message 控制类
//功能:  	定义了与 dbo.Message 表 对应的数据访问控制类
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
    /// MessageCtrl
    /// programmer:shunlian
    /// </summary>
    public class MessageCtrl
    {
        #region 构造函数

        /// <summary>
        /// MessageCtrl默认构造函数
        /// </summary>
        public MessageCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.Message一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="MessageInfo">MessageInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, MessageInfo MessageInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "Message_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@SenderId",DbType.Guid),
				new SqlParameter("@SenderName",DbType.String),
				new SqlParameter("@DeptName",DbType.String),
				new SqlParameter("@Tile",DbType.String),
				new SqlParameter("@Context",DbType.String),
				new SqlParameter("@ReceviceId",DbType.Guid),
				new SqlParameter("@Recevicer",DbType.String),
				new SqlParameter("@SendDate",DbType.DateTime),
				new SqlParameter("@ViewDate",DbType.DateTime),
				new SqlParameter("@IsView",DbType.Boolean),
				new SqlParameter("@IsDelete",DbType.Boolean),
                new SqlParameter("@SentMessageId",DbType.Guid)
				};

                int i = 0;
                sqlparam[i++].Value = MessageInfo.ObjectId;
                sqlparam[i++].Value = MessageInfo.SenderId;
                sqlparam[i++].Value = MessageInfo.SenderName;
                sqlparam[i++].Value = MessageInfo.DeptName;
                sqlparam[i++].Value = MessageInfo.Tile;
                sqlparam[i++].Value = MessageInfo.Context;
                sqlparam[i++].Value = MessageInfo.ReceviceId;
                sqlparam[i++].Value = MessageInfo.Recevicer;
                sqlparam[i++].Value = MessageInfo.SendDate;
                sqlparam[i++].Value = MessageInfo.ViewDate;
                sqlparam[i++].Value = MessageInfo.IsView;
                sqlparam[i++].Value = MessageInfo.IsDelete;
                sqlparam[i++].Value = MessageInfo.SentMessageId;
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
        /// dbo.Message删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "Message_Delete";

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
        /// Message 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="MessageInfo">MessageInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, MessageInfo MessageInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "Message_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@SenderId",DbType.Guid),
				new SqlParameter("@SenderName",DbType.String),
				new SqlParameter("@DeptName",DbType.String),
				new SqlParameter("@Tile",DbType.String),
				new SqlParameter("@Context",DbType.String),
				new SqlParameter("@ReceviceId",DbType.Guid),
				new SqlParameter("@Recevicer",DbType.String),
				new SqlParameter("@SendDate",DbType.DateTime),
				new SqlParameter("@ViewDate",DbType.DateTime),
				new SqlParameter("@IsView",DbType.Boolean),
				new SqlParameter("@IsDelete",DbType.Boolean),
                new SqlParameter("@SentMessageId",DbType.Guid)
                };

                int i = 0;
                sqlparam[i++].Value = MessageInfo.ObjectId;
                sqlparam[i++].Value = MessageInfo.SenderId;
                sqlparam[i++].Value = MessageInfo.SenderName;
                sqlparam[i++].Value = MessageInfo.DeptName;
                sqlparam[i++].Value = MessageInfo.Tile;
                sqlparam[i++].Value = MessageInfo.Context;
                sqlparam[i++].Value = MessageInfo.ReceviceId;
                sqlparam[i++].Value = MessageInfo.Recevicer;
                sqlparam[i++].Value = MessageInfo.SendDate;
                sqlparam[i++].Value = MessageInfo.ViewDate;
                sqlparam[i++].Value = MessageInfo.IsView;
                sqlparam[i++].Value = MessageInfo.IsDelete;
                sqlparam[i++].Value = MessageInfo.SentMessageId;
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
        /// Message 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "Message_Search";
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
        ///Message 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<MessageInfo></returns>
        public List<MessageInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<MessageInfo> list = new List<MessageInfo>();
            MessageInfo accountInfo = new MessageInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = MessageInfoRowToInfo(row);
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
        /// <param name="MessageDataRow">MessageDataRow</param>
        /// <returns>MessageInfo</returns>
        internal MessageInfo MessageInfoRowToInfo(DataRow MessageInfoInfoDataRow)
        {
            MessageInfo MessageInfoInfo = new MessageInfo();
            if (MessageInfoInfoDataRow["ObjectId"] != null)
            {
                MessageInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(MessageInfoInfoDataRow, "ObjectId"));
            }
            if (MessageInfoInfoDataRow["SenderId"] != null)
            {
                MessageInfoInfo.SenderId = new Guid(DataUtil.GetStringValueOfRow(MessageInfoInfoDataRow, "SenderId"));
            }
            if (MessageInfoInfoDataRow["SenderName"] != null)
            {
                MessageInfoInfo.SenderName = DataUtil.GetStringValueOfRow(MessageInfoInfoDataRow, "SenderName");
            }
            if (MessageInfoInfoDataRow["DeptName"] != null)
            {
                MessageInfoInfo.DeptName = DataUtil.GetStringValueOfRow(MessageInfoInfoDataRow, "DeptName");
            }
            if (MessageInfoInfoDataRow["Tile"] != null)
            {
                MessageInfoInfo.Tile = DataUtil.GetStringValueOfRow(MessageInfoInfoDataRow, "Tile");
            }
            if (MessageInfoInfoDataRow["Context"] != null)
            {
                MessageInfoInfo.Context = DataUtil.GetStringValueOfRow(MessageInfoInfoDataRow, "Context");
            }
            if (MessageInfoInfoDataRow["ReceviceId"] != null)
            {
                MessageInfoInfo.ReceviceId = new Guid(DataUtil.GetStringValueOfRow(MessageInfoInfoDataRow, "ReceviceId"));
            }
            if (MessageInfoInfoDataRow["Recevicer"] != null)
            {
                MessageInfoInfo.Recevicer = DataUtil.GetStringValueOfRow(MessageInfoInfoDataRow, "Recevicer");
            }
            if (MessageInfoInfoDataRow["SendDate"] != null)
            {
                MessageInfoInfo.SendDate = DateTime.Parse(DataUtil.GetStringValueOfRow(MessageInfoInfoDataRow, "SendDate"));
            }
            if (MessageInfoInfoDataRow["ViewDate"] != null)
            {
                MessageInfoInfo.ViewDate = DateTime.Parse(DataUtil.GetStringValueOfRow(MessageInfoInfoDataRow, "ViewDate"));
            }
            if (MessageInfoInfoDataRow["IsView"] != null)
            {
                MessageInfoInfo.IsView = bool.Parse(DataUtil.GetStringValueOfRow(MessageInfoInfoDataRow, "IsView"));
            }
            if (MessageInfoInfoDataRow["IsDelete"] != null)
            {
                MessageInfoInfo.IsDelete = bool.Parse(DataUtil.GetStringValueOfRow(MessageInfoInfoDataRow, "IsDelete"));
            }
            if (MessageInfoInfoDataRow["SentMessageId"] != null)
            {
                MessageInfoInfo.SentMessageId = new Guid(DataUtil.GetStringValueOfRow(MessageInfoInfoDataRow, "SentMessageId"));
            }

            return MessageInfoInfo;
        }
        #endregion
    }
}
