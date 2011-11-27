//----------------------------------------------------------------------------------------------------
//程序名:	UserLeaveApply 控制类
//功能:  	定义了与 dbo.UserLeaveApply 表 对应的数据访问控制类
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
    /// UserLeaveApplyCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class UserLeaveApplyCtrl
    {
        #region 构造函数

        /// <summary>
        /// UserLeaveApplyCtrl默认构造函数
        /// </summary>
        public UserLeaveApplyCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.UserLeaveApply一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="UserLeaveApplyInfo">UserLeaveApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, UserLeaveApplyInfo UserLeaveApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "UserLeaveApply_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@UserPosition",DbType.String),
				new SqlParameter("@ContractStartDate",DbType.DateTime),
				new SqlParameter("@ContractEndDate",DbType.DateTime),
				new SqlParameter("@LeaveDate",DbType.DateTime),
				new SqlParameter("@LeaveType",DbType.Int16),
				new SqlParameter("@LeaveSeason",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@TransferID",DbType.Guid),
				new SqlParameter("@TransferState",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
				};

                int i = 0;
                sqlparam[i++].Value = UserLeaveApplyInfo.ObjectID;
                sqlparam[i++].Value = UserLeaveApplyInfo.UserID;
                sqlparam[i++].Value = UserLeaveApplyInfo.UserName;
                sqlparam[i++].Value = UserLeaveApplyInfo.UserJobNo;
                sqlparam[i++].Value = UserLeaveApplyInfo.UserAccountNo;
                sqlparam[i++].Value = UserLeaveApplyInfo.UserDept;
                sqlparam[i++].Value = UserLeaveApplyInfo.UserPosition;
                sqlparam[i++].Value = UserLeaveApplyInfo.ContractStartDate;
                sqlparam[i++].Value = UserLeaveApplyInfo.ContractEndDate;
                sqlparam[i++].Value = UserLeaveApplyInfo.LeaveDate;
                sqlparam[i++].Value = UserLeaveApplyInfo.LeaveType;
                sqlparam[i++].Value = UserLeaveApplyInfo.LeaveSeason;
                sqlparam[i++].Value = UserLeaveApplyInfo.State;
                sqlparam[i++].Value = UserLeaveApplyInfo.ApproverID;
                sqlparam[i++].Value = UserLeaveApplyInfo.ApplyTime;
                sqlparam[i++].Value = UserLeaveApplyInfo.TransferID;
                sqlparam[i++].Value = UserLeaveApplyInfo.TransferState;
                sqlparam[i++].Value = UserLeaveApplyInfo.IsDelete;
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
        /// dbo.UserLeaveApply删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "UserLeaveApply_Delete";

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
        /// UserLeaveApply 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="UserLeaveApplyInfo">UserLeaveApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, UserLeaveApplyInfo UserLeaveApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "UserLeaveApply_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@UserPosition",DbType.String),
				new SqlParameter("@ContractStartDate",DbType.DateTime),
				new SqlParameter("@ContractEndDate",DbType.DateTime),
				new SqlParameter("@LeaveDate",DbType.DateTime),
				new SqlParameter("@LeaveType",DbType.Int16),
				new SqlParameter("@LeaveSeason",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@TransferID",DbType.Guid),
				new SqlParameter("@TransferState",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
                };

                int i = 0;
                sqlparam[i++].Value = UserLeaveApplyInfo.ObjectID;
                sqlparam[i++].Value = UserLeaveApplyInfo.UserID;
                sqlparam[i++].Value = UserLeaveApplyInfo.UserName;
                sqlparam[i++].Value = UserLeaveApplyInfo.UserJobNo;
                sqlparam[i++].Value = UserLeaveApplyInfo.UserAccountNo;
                sqlparam[i++].Value = UserLeaveApplyInfo.UserDept;
                sqlparam[i++].Value = UserLeaveApplyInfo.UserPosition;
                sqlparam[i++].Value = UserLeaveApplyInfo.ContractStartDate;
                sqlparam[i++].Value = UserLeaveApplyInfo.ContractEndDate;
                sqlparam[i++].Value = UserLeaveApplyInfo.LeaveDate;
                sqlparam[i++].Value = UserLeaveApplyInfo.LeaveType;
                sqlparam[i++].Value = UserLeaveApplyInfo.LeaveSeason;
                sqlparam[i++].Value = UserLeaveApplyInfo.State;
                sqlparam[i++].Value = UserLeaveApplyInfo.ApproverID;
                sqlparam[i++].Value = UserLeaveApplyInfo.ApplyTime;
                sqlparam[i++].Value = UserLeaveApplyInfo.TransferID;
                sqlparam[i++].Value = UserLeaveApplyInfo.TransferState;
                sqlparam[i++].Value = UserLeaveApplyInfo.IsDelete;
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
        /// UserLeaveApply 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "UserLeaveApply_Search";
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
        ///UserLeaveApply 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<UserLeaveApplyInfo></returns>
        public List<UserLeaveApplyInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<UserLeaveApplyInfo> list = new List<UserLeaveApplyInfo>();
            UserLeaveApplyInfo accountInfo = new UserLeaveApplyInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = UserLeaveApplyInfoRowToInfo(row);
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
        /// <param name="UserLeaveApplyDataRow">UserLeaveApplyDataRow</param>
        /// <returns>UserLeaveApplyInfo</returns>
        internal UserLeaveApplyInfo UserLeaveApplyInfoRowToInfo(DataRow InfoDataRow)
        {
            UserLeaveApplyInfo Info = new UserLeaveApplyInfo();
            if (InfoDataRow["ObjectID"] != null)
            {
                Info.ObjectID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectID"));
            }
            if (InfoDataRow["UserID"] != null)
            {
                Info.UserID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "UserID"));
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
            if (InfoDataRow["UserDept"] != null)
            {
                Info.UserDept = DataUtil.GetStringValueOfRow(InfoDataRow, "UserDept");
            }
            if (InfoDataRow["UserPosition"] != null)
            {
                Info.UserPosition = DataUtil.GetStringValueOfRow(InfoDataRow, "UserPosition");
            }
            if (InfoDataRow["ContractStartDate"] != null)
            {
                Info.ContractStartDate = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ContractStartDate"));
            }
            if (InfoDataRow["ContractEndDate"] != null)
            {
                Info.ContractEndDate = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ContractEndDate"));
            }
            if (InfoDataRow["LeaveDate"] != null)
            {
                Info.LeaveDate = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "LeaveDate"));
            }
            if (InfoDataRow["LeaveType"] != null)
            {
                Info.LeaveType = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "LeaveType"));
            }
            if (InfoDataRow["LeaveSeason"] != null)
            {
                Info.LeaveSeason = DataUtil.GetStringValueOfRow(InfoDataRow, "LeaveSeason");
            }
            if (InfoDataRow["State"] != null)
            {
                Info.State = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "State"));
            }
            if (InfoDataRow["ApproverID"] != null)
            {
                Info.ApproverID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ApproverID"));
            }
            if (InfoDataRow["ApplyTime"] != null)
            {
                Info.ApplyTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyTime"));
            }
            if (InfoDataRow["TransferID"] != null)
            {
                Info.TransferID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "TransferID"));
            }
            if (InfoDataRow["TransferState"] != null)
            {
                Info.TransferState = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "TransferState"));
            }
            if (InfoDataRow["IsDelete"] != null)
            {
                Info.IsDelete = bool.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "IsDelete"));
            }

            return Info;
        }
        #endregion
    }
}
