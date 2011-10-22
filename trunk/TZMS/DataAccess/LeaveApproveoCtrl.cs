//----------------------------------------------------------------------------------------------------
//程序名:	LeaveApprove 控制类
//功能:  	定义了与 dbo.LeaveApprove 表 对应的数据访问控制类
//作者:  	shunlian
//时间:	2011-10-16 
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
using com.TZMS.Model;

namespace com.TZMS.DataAccess
{
    /// <summary>
    /// LeaveApproveoCtrl
    /// programmer:shunlian
    /// </summary>
    public class LeaveApproveoCtrl
    {
        #region 构造函数

        /// <summary>
        /// LeaveApproveoCtrl默认构造函数
        /// </summary>
        public LeaveApproveoCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.LeaveApprove一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="LeaveApproveInfo">LeaveApproveInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, LeaveApproveInfo LeaveApproveInfo)
        {
            try
            {
				//存储过程名称
                string strsql = "LeaveApprove_Add"; 
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@LeaveID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproveTime",DbType.DateTime),
				new SqlParameter("@ApproveResult",DbType.Int16),
				new SqlParameter("@ApproveComment",DbType.String),
				};
				
				int i=0;
				sqlparam[i++].Value = LeaveApproveInfo.ObjectId; 
				sqlparam[i++].Value = LeaveApproveInfo.LeaveId; 
				sqlparam[i++].Value = LeaveApproveInfo.ApproverId; 
				sqlparam[i++].Value = LeaveApproveInfo.ApproverName; 
				sqlparam[i++].Value = LeaveApproveInfo.ApproveTime; 
				sqlparam[i++].Value = LeaveApproveInfo.ApproveResult; 
				sqlparam[i++].Value = LeaveApproveInfo.ApproveComment; 
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
        /// dbo.LeaveApprove删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "LeaveApprove_Delete";

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
        /// LeaveApprove 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="LeaveApproveInfo">LeaveApproveInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, LeaveApproveInfo LeaveApproveInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "LeaveApprove_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@LeaveID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproveTime",DbType.DateTime),
				new SqlParameter("@ApproveResult",DbType.Int16),
				new SqlParameter("@ApproveComment",DbType.String),
                };

                int i = 0;
				sqlparam[i++].Value = LeaveApproveInfo.ObjectId; 
				sqlparam[i++].Value = LeaveApproveInfo.LeaveId; 
				sqlparam[i++].Value = LeaveApproveInfo.ApproverId; 
				sqlparam[i++].Value = LeaveApproveInfo.ApproverName; 
				sqlparam[i++].Value = LeaveApproveInfo.ApproveTime; 
				sqlparam[i++].Value = LeaveApproveInfo.ApproveResult; 
				sqlparam[i++].Value = LeaveApproveInfo.ApproveComment; 
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
        /// LeaveApprove 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "LeaveApprove_Search";
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
        ///LeaveApprove 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<LeaveApproveInfo></returns>
        public List<LeaveApproveInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<LeaveApproveInfo> list = new List<LeaveApproveInfo>();
            LeaveApproveInfo accountInfo = new LeaveApproveInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = LeaveApproveInfoRowToInfo(row);
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
        /// <param name="LeaveApproveDataRow">LeaveApproveDataRow</param>
        /// <returns>LeaveApproveInfo</returns>
        internal LeaveApproveInfo LeaveApproveInfoRowToInfo(DataRow LeaveApproveInfoInfoDataRow)
        {
            LeaveApproveInfo LeaveApproveInfoInfo = new LeaveApproveInfo();
            if (LeaveApproveInfoInfoDataRow["ObjectID"] != null)
            {
                LeaveApproveInfoInfo.ObjectId = new Guid(LeaveApproveInfoInfoDataRow["ObjectID"].ToString());
            }
            if (LeaveApproveInfoInfoDataRow["LeaveID"] != null)
            {
                LeaveApproveInfoInfo.LeaveId = new Guid(LeaveApproveInfoInfoDataRow["LeaveID"].ToString());
            }
            if (LeaveApproveInfoInfoDataRow["ApproverID"] != null)
            {
                LeaveApproveInfoInfo.ApproverId = new Guid(LeaveApproveInfoInfoDataRow["ApproverID"].ToString());
            }
            if (LeaveApproveInfoInfoDataRow["ApproverName"] != null)
            {
                LeaveApproveInfoInfo.ApproverName = LeaveApproveInfoInfoDataRow["ApproverName"].ToString();
            }
            if (LeaveApproveInfoInfoDataRow["ApproveTime"] != null)
            {
                LeaveApproveInfoInfo.ApproveTime = DateTime.Parse((LeaveApproveInfoInfoDataRow["ApproveTime"].ToString()));
            }
            if (LeaveApproveInfoInfoDataRow["ApproveResult"] != null)
            {
                LeaveApproveInfoInfo.ApproveResult = short.Parse(LeaveApproveInfoInfoDataRow["ApproveResult"].ToString());
            }
            if (LeaveApproveInfoInfoDataRow["ApproveComment"] != null)
            {
                LeaveApproveInfoInfo.ApproveComment = LeaveApproveInfoInfoDataRow["ApproveComment"].ToString();
            }

            return LeaveApproveInfoInfo;
        }
        #endregion
    }
}
