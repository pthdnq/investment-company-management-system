//----------------------------------------------------------------------------------------------------
//程序名:	UserLeaveApprove 控制类
//功能:  	定义了与 dbo.UserLeaveApprove 表 对应的数据访问控制类
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
    /// UserLeaveApproveCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class UserLeaveApproveCtrl
    {
        #region 构造函数

        /// <summary>
        /// UserLeaveApproveCtrl默认构造函数
        /// </summary>
        public UserLeaveApproveCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.UserLeaveApprove一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="UserLeaveApproveInfo">UserLeaveApproveInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, UserLeaveApproveInfo UserLeaveApproveInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "UserLeaveApprove_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproverDept",DbType.String),
				new SqlParameter("@IsApprove",DbType.Boolean),
				new SqlParameter("@ApproveResult",DbType.Int16),
				new SqlParameter("@ApproverSugest",DbType.String),
				new SqlParameter("@ApplyID",DbType.Guid),
				};

                int i = 0;
                sqlparam[i++].Value = UserLeaveApproveInfo.ObjectID;
                sqlparam[i++].Value = UserLeaveApproveInfo.ApproverID;
                sqlparam[i++].Value = UserLeaveApproveInfo.ApproverName;
                sqlparam[i++].Value = UserLeaveApproveInfo.ApproverDept;
                sqlparam[i++].Value = UserLeaveApproveInfo.IsApprove;
                sqlparam[i++].Value = UserLeaveApproveInfo.ApproveResult;
                sqlparam[i++].Value = UserLeaveApproveInfo.ApproverSugest;
                sqlparam[i++].Value = UserLeaveApproveInfo.ApplyID;
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
        /// dbo.UserLeaveApprove删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "UserLeaveApprove_Delete";

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
        /// UserLeaveApprove 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="UserLeaveApproveInfo">UserLeaveApproveInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, UserLeaveApproveInfo UserLeaveApproveInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "UserLeaveApprove_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproverDept",DbType.String),
				new SqlParameter("@IsApprove",DbType.Boolean),
				new SqlParameter("@ApproveResult",DbType.Int16),
				new SqlParameter("@ApproverSugest",DbType.String),
				new SqlParameter("@ApplyID",DbType.Guid),
                };

                int i = 0;
                sqlparam[i++].Value = UserLeaveApproveInfo.ObjectID;
                sqlparam[i++].Value = UserLeaveApproveInfo.ApproverID;
                sqlparam[i++].Value = UserLeaveApproveInfo.ApproverName;
                sqlparam[i++].Value = UserLeaveApproveInfo.ApproverDept;
                sqlparam[i++].Value = UserLeaveApproveInfo.IsApprove;
                sqlparam[i++].Value = UserLeaveApproveInfo.ApproveResult;
                sqlparam[i++].Value = UserLeaveApproveInfo.ApproverSugest;
                sqlparam[i++].Value = UserLeaveApproveInfo.ApplyID;
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
        /// UserLeaveApprove 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "UserLeaveApprove_Search";
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
        ///UserLeaveApprove 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<UserLeaveApproveInfo></returns>
        public List<UserLeaveApproveInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<UserLeaveApproveInfo> list = new List<UserLeaveApproveInfo>();
            UserLeaveApproveInfo accountInfo = new UserLeaveApproveInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = UserLeaveApproveInfoRowToInfo(row);
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
        /// <param name="UserLeaveApproveDataRow">UserLeaveApproveDataRow</param>
        /// <returns>UserLeaveApproveInfo</returns>
        internal UserLeaveApproveInfo UserLeaveApproveInfoRowToInfo(DataRow InfoDataRow)
        {
            UserLeaveApproveInfo Info = new UserLeaveApproveInfo();
            if (InfoDataRow["ObjectID"] != null)
            {
                Info.ObjectID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectID"));
            }
            if (InfoDataRow["ApproverID"] != null)
            {
                Info.ApproverID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ApproverID"));
            }
            if (InfoDataRow["ApproverName"] != null)
            {
                Info.ApproverName = DataUtil.GetStringValueOfRow(InfoDataRow, "ApproverName");
            }
            if (InfoDataRow["ApproverDept"] != null)
            {
                Info.ApproverDept = DataUtil.GetStringValueOfRow(InfoDataRow, "ApproverDept");
            }
            if (InfoDataRow["IsApprove"] != null)
            {
                Info.IsApprove = bool.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "IsApprove"));
            }
            if (InfoDataRow["ApproveResult"] != null)
            {
                Info.ApproveResult = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApproveResult"));
            }
            if (InfoDataRow["ApproverSugest"] != null)
            {
                Info.ApproverSugest = DataUtil.GetStringValueOfRow(InfoDataRow, "ApproverSugest");
            }
            if (InfoDataRow["ApplyID"] != null)
            {
                Info.ApplyID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyID"));
            }

            return Info;
        }
        #endregion
    }
}
