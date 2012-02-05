//----------------------------------------------------------------------------------------------------
//程序名:	LeaveInfo 控制类
//功能:  	定义了与 dbo.LeaveInfo 表 对应的数据访问控制类
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
    /// LeaveInfoCtrl
    /// programmer:shunlian
    /// </summary>
    public class LeaveInfoCtrl
    {
        #region 构造函数

        /// <summary>
        /// LeaveInfoCtrl默认构造函数
        /// </summary>
        public LeaveInfoCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.LeaveInfo一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="LeaveInfo">LeaveInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, LeaveInfo LeaveInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "LeaveInfo_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@JobNo",DbType.String),
				new SqlParameter("@AccountNo",DbType.String),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@Type",DbType.String),
				new SqlParameter("@StartTime",DbType.DateTime),
				new SqlParameter("@StopTime",DbType.DateTime),
				new SqlParameter("@Reason",DbType.String),
				new SqlParameter("@WriteTime",DbType.DateTime),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproverId",DbType.Guid),
				new SqlParameter("@IsDelete",DbType.Boolean),
                new SqlParameter("@UserObjectID",DbType.Guid),
                new SqlParameter("@LeaveHours",DbType.Int32)
				};

                int i = 0;
                sqlparam[i++].Value = LeaveInfo.ObjectId;
                sqlparam[i++].Value = LeaveInfo.JobNo;
                sqlparam[i++].Value = LeaveInfo.AccountNo;
                sqlparam[i++].Value = LeaveInfo.Name;
                sqlparam[i++].Value = LeaveInfo.Dept;
                sqlparam[i++].Value = LeaveInfo.Type;
                sqlparam[i++].Value = LeaveInfo.StartTime;
                sqlparam[i++].Value = LeaveInfo.StopTime;
                sqlparam[i++].Value = LeaveInfo.Reason;
                sqlparam[i++].Value = LeaveInfo.WriteTime;
                sqlparam[i++].Value = LeaveInfo.State;
                sqlparam[i++].Value = LeaveInfo.ApproverId;
                sqlparam[i++].Value = LeaveInfo.IsDelete;
                sqlparam[i++].Value = LeaveInfo.UserObjectId;
                sqlparam[i++].Value = LeaveInfo.LeaveHours;
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
        /// dbo.LeaveInfo删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "LeaveInfo_Delete";

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
        /// LeaveInfo 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="LeaveInfo">LeaveInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, LeaveInfo LeaveInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "LeaveInfo_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@JobNo",DbType.String),
				new SqlParameter("@AccountNo",DbType.String),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@Type",DbType.String),
				new SqlParameter("@StartTime",DbType.DateTime),
				new SqlParameter("@StopTime",DbType.DateTime),
				new SqlParameter("@Reason",DbType.String),
				new SqlParameter("@WriteTime",DbType.DateTime),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproverId",DbType.Guid),
				new SqlParameter("@IsDelete",DbType.Boolean),
                new SqlParameter("@UserObjectID",DbType.Guid),
                new SqlParameter("@LeaveHours",DbType.Int32)
                };

                int i = 0;
                sqlparam[i++].Value = LeaveInfo.ObjectId;
                sqlparam[i++].Value = LeaveInfo.JobNo;
                sqlparam[i++].Value = LeaveInfo.AccountNo;
                sqlparam[i++].Value = LeaveInfo.Name;
                sqlparam[i++].Value = LeaveInfo.Dept;
                sqlparam[i++].Value = LeaveInfo.Type;
                sqlparam[i++].Value = LeaveInfo.StartTime;
                sqlparam[i++].Value = LeaveInfo.StopTime;
                sqlparam[i++].Value = LeaveInfo.Reason;
                sqlparam[i++].Value = LeaveInfo.WriteTime;
                sqlparam[i++].Value = LeaveInfo.State;
                sqlparam[i++].Value = LeaveInfo.ApproverId;
                sqlparam[i++].Value = LeaveInfo.IsDelete;
                sqlparam[i++].Value = LeaveInfo.UserObjectId;
                sqlparam[i++].Value = LeaveInfo.LeaveHours;
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
        /// LeaveInfo 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "LeaveInfo_Search";
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
        ///LeaveInfo 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<LeaveInfo></returns>
        public List<LeaveInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<LeaveInfo> list = new List<LeaveInfo>();
            LeaveInfo accountInfo = new LeaveInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = LeaveInfoRowToInfo(row);
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
        /// <param name="LeaveInfoDataRow">LeaveInfoDataRow</param>
        /// <returns>LeaveInfo</returns>
        internal LeaveInfo LeaveInfoRowToInfo(DataRow LeaveInfoInfoDataRow)
        {
            LeaveInfo LeaveInfoInfo = new LeaveInfo();
            if (LeaveInfoInfoDataRow["ObjectId"] != null)
            {
                LeaveInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "ObjectId"));
            }
            if (LeaveInfoInfoDataRow["JobNo"] != null)
            {
                LeaveInfoInfo.JobNo = DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "JobNo");
            }
            if (LeaveInfoInfoDataRow["AccountNo"] != null)
            {
                LeaveInfoInfo.AccountNo = DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "AccountNo");
            }
            if (LeaveInfoInfoDataRow["Name"] != null)
            {
                LeaveInfoInfo.Name = DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "Name");
            }
            if (LeaveInfoInfoDataRow["Dept"] != null)
            {
                LeaveInfoInfo.Dept = DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "Dept");
            }
            if (LeaveInfoInfoDataRow["Type"] != null)
            {
                LeaveInfoInfo.Type = DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "Type");
            }
            if (LeaveInfoInfoDataRow["StartTime"] != null)
            {
                LeaveInfoInfo.StartTime = DateTime.Parse(DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "StartTime"));
            }
            if (LeaveInfoInfoDataRow["StopTime"] != null)
            {
                LeaveInfoInfo.StopTime = DateTime.Parse(DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "StopTime"));
            }
            if (LeaveInfoInfoDataRow["Reason"] != null)
            {
                LeaveInfoInfo.Reason = DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "Reason");
            }
            if (LeaveInfoInfoDataRow["WriteTime"] != null)
            {
                LeaveInfoInfo.WriteTime = DateTime.Parse(DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "WriteTime"));
            }
            if (LeaveInfoInfoDataRow["State"] != null)
            {
                LeaveInfoInfo.State = short.Parse(DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "State"));
            }
            if (LeaveInfoInfoDataRow["ApproverId"] != null)
            {
                LeaveInfoInfo.ApproverId = new Guid(DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "ApproverId"));
            }
            if (LeaveInfoInfoDataRow["IsDelete"] != null)
            {
                LeaveInfoInfo.IsDelete = bool.Parse(DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "IsDelete"));
            }
            if (LeaveInfoInfoDataRow["UserObjectId"] != null)
            {
                LeaveInfoInfo.UserObjectId = new Guid(DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "UserObjectId"));
            }
            if (LeaveInfoInfoDataRow["LeaveHours"] != null)
            {
                LeaveInfoInfo.LeaveHours = Convert.ToInt32(DataUtil.GetStringValueOfRow(LeaveInfoInfoDataRow, "LeaveHours"));
            }
            return LeaveInfoInfo;
        }
        #endregion
    }
}
