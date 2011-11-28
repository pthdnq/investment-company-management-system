//----------------------------------------------------------------------------------------------------
//程序名:	UserLeaveTransfer 控制类
//功能:  	定义了与 dbo.UserLeaveTransfer 表 对应的数据访问控制类
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
    /// UserLeaveTransferCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class UserLeaveTransferCtrl
    {
        #region 构造函数

        /// <summary>
        /// UserLeaveTransferCtrl默认构造函数
        /// </summary>
        public UserLeaveTransferCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.UserLeaveTransfer一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="UserLeaveTransferInfo">UserLeaveTransferInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, UserLeaveTransferInfo UserLeaveTransferInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "UserLeaveTransfer_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@TransferID",DbType.Guid),
				new SqlParameter("@TransferName",DbType.String),
				new SqlParameter("@TransferDept",DbType.String),
				new SqlParameter("@IsTransfer",DbType.Boolean),
				new SqlParameter("@TransferTime",DbType.DateTime),
				new SqlParameter("@TransferType",DbType.Int16),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@ApplyID",DbType.Guid),
                new SqlParameter("@TransferState",DbType.Int16)
				};

                int i = 0;
                sqlparam[i++].Value = UserLeaveTransferInfo.ObjectID;
                sqlparam[i++].Value = UserLeaveTransferInfo.TransferID;
                sqlparam[i++].Value = UserLeaveTransferInfo.TransferName;
                sqlparam[i++].Value = UserLeaveTransferInfo.TransferDept;
                sqlparam[i++].Value = UserLeaveTransferInfo.IsTransfer;
                sqlparam[i++].Value = UserLeaveTransferInfo.TransferTime;
                sqlparam[i++].Value = UserLeaveTransferInfo.TransferType;
                sqlparam[i++].Value = UserLeaveTransferInfo.Other;
                sqlparam[i++].Value = UserLeaveTransferInfo.ApplyID;
                sqlparam[i++].Value = UserLeaveTransferInfo.TransferState;
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
        /// dbo.UserLeaveTransfer删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "UserLeaveTransfer_Delete";

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
        /// UserLeaveTransfer 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="UserLeaveTransferInfo">UserLeaveTransferInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, UserLeaveTransferInfo UserLeaveTransferInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "UserLeaveTransfer_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@TransferID",DbType.Guid),
				new SqlParameter("@TransferName",DbType.String),
				new SqlParameter("@TransferDept",DbType.String),
				new SqlParameter("@IsTransfer",DbType.Boolean),
				new SqlParameter("@TransferTime",DbType.DateTime),
				new SqlParameter("@TransferType",DbType.Int16),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@ApplyID",DbType.Guid),
                new SqlParameter("@TransferState",DbType.Int16)
                };

                int i = 0;
                sqlparam[i++].Value = UserLeaveTransferInfo.ObjectID;
                sqlparam[i++].Value = UserLeaveTransferInfo.TransferID;
                sqlparam[i++].Value = UserLeaveTransferInfo.TransferName;
                sqlparam[i++].Value = UserLeaveTransferInfo.TransferDept;
                sqlparam[i++].Value = UserLeaveTransferInfo.IsTransfer;
                sqlparam[i++].Value = UserLeaveTransferInfo.TransferTime;
                sqlparam[i++].Value = UserLeaveTransferInfo.TransferType;
                sqlparam[i++].Value = UserLeaveTransferInfo.Other;
                sqlparam[i++].Value = UserLeaveTransferInfo.ApplyID;
                sqlparam[i++].Value = UserLeaveTransferInfo.TransferState;
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
        /// UserLeaveTransfer 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "UserLeaveTransfer_Search";
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
        ///UserLeaveTransfer 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<UserLeaveTransferInfo></returns>
        public List<UserLeaveTransferInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<UserLeaveTransferInfo> list = new List<UserLeaveTransferInfo>();
            UserLeaveTransferInfo accountInfo = new UserLeaveTransferInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = UserLeaveTransferInfoRowToInfo(row);
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
        /// <param name="UserLeaveTransferDataRow">UserLeaveTransferDataRow</param>
        /// <returns>UserLeaveTransferInfo</returns>
        internal UserLeaveTransferInfo UserLeaveTransferInfoRowToInfo(DataRow InfoDataRow)
        {
            UserLeaveTransferInfo Info = new UserLeaveTransferInfo();
            if (InfoDataRow["ObjectID"] != null)
            {
                Info.ObjectID = new Guid( DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectID"));
            }
            if (InfoDataRow["TransferID"] != null)
            {
                Info.TransferID = new Guid( DataUtil.GetStringValueOfRow(InfoDataRow, "TransferID"));
            }
            if (InfoDataRow["TransferName"] != null)
            {
                Info.TransferName = DataUtil.GetStringValueOfRow(InfoDataRow, "TransferName");
            }
            if (InfoDataRow["TransferDept"] != null)
            {
                Info.TransferDept = DataUtil.GetStringValueOfRow(InfoDataRow, "TransferDept");
            }
            if (InfoDataRow["IsTransfer"] != null)
            {
                Info.IsTransfer = bool.Parse( DataUtil.GetStringValueOfRow(InfoDataRow, "IsTransfer"));
            }
            if (InfoDataRow["TransferTime"] != null)
            {
                Info.TransferTime = DateTime.Parse( DataUtil.GetStringValueOfRow(InfoDataRow, "TransferTime"));
            }
            if (InfoDataRow["TransferType"] != null)
            {
                Info.TransferType = short.Parse( DataUtil.GetStringValueOfRow(InfoDataRow, "TransferType"));
            }
            if (InfoDataRow["Other"] != null)
            {
                Info.Other = DataUtil.GetStringValueOfRow(InfoDataRow, "Other");
            }
            if (InfoDataRow["ApplyID"] != null)
            {
                Info.ApplyID =  new Guid( DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyID"));
            }
            if (InfoDataRow["TransferState"] != null)
            {
                Info.TransferState = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "TransferState"));
            }
            return Info;
        }
        #endregion
    }
}
