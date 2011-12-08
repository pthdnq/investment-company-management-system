//----------------------------------------------------------------------------------------------------
//程序名:	BaoXiaoPinZhengApprove 控制类
//功能:  	定义了与 dbo.BaoXiaoPinZhengApprove 表 对应的数据访问控制类
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
    /// BaoXiaoPinZhengApproveCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class BaoXiaoPinZhengApproveCtrl
    {
        #region 构造函数

        /// <summary>
        /// BaoXiaoPinZhengApproveCtrl默认构造函数
        /// </summary>
        public BaoXiaoPinZhengApproveCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.BaoXiaoPinZhengApprove一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BaoXiaoPinZhengApproveInfo">BaoXiaoPinZhengApproveInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, BaoXiaoPinZhengApproveInfo BaoXiaoPinZhengApproveInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BaoXiaoPinZhengApprove_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproverDept",DbType.String),
				new SqlParameter("@ApproveTime",DbType.DateTime),
				new SqlParameter("@ApproveState",DbType.Int16),
				new SqlParameter("@Result",DbType.Int16),
				new SqlParameter("@ApproveSugest",DbType.String),
				new SqlParameter("@ApproveOp",DbType.Int16),
				new SqlParameter("@ApplyID",DbType.Guid),
				};

                int i = 0;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ObjectID;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproverID;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproverName;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproverDept;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproveTime;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproveState;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.Result;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproveSugest;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproveOp;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApplyID;
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
        /// dbo.BaoXiaoPinZhengApprove删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "BaoXiaoPinZhengApprove_Delete";

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
        /// BaoXiaoPinZhengApprove 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BaoXiaoPinZhengApproveInfo">BaoXiaoPinZhengApproveInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, BaoXiaoPinZhengApproveInfo BaoXiaoPinZhengApproveInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BaoXiaoPinZhengApprove_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproverDept",DbType.String),
				new SqlParameter("@ApproveTime",DbType.DateTime),
				new SqlParameter("@ApproveState",DbType.Int16),
				new SqlParameter("@Result",DbType.Int16),
				new SqlParameter("@ApproveSugest",DbType.String),
				new SqlParameter("@ApproveOp",DbType.Int16),
				new SqlParameter("@ApplyID",DbType.Guid),
                };

                int i = 0;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ObjectID;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproverID;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproverName;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproverDept;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproveTime;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproveState;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.Result;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproveSugest;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApproveOp;
                sqlparam[i++].Value = BaoXiaoPinZhengApproveInfo.ApplyID;
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
        /// BaoXiaoPinZhengApprove 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "BaoXiaoPinZhengApprove_Search";
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
        ///BaoXiaoPinZhengApprove 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<BaoXiaoPinZhengApproveInfo></returns>
        public List<BaoXiaoPinZhengApproveInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<BaoXiaoPinZhengApproveInfo> list = new List<BaoXiaoPinZhengApproveInfo>();
            BaoXiaoPinZhengApproveInfo accountInfo = new BaoXiaoPinZhengApproveInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = BaoXiaoPinZhengApproveInfoRowToInfo(row);
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
        /// <param name="BaoXiaoPinZhengApproveDataRow">BaoXiaoPinZhengApproveDataRow</param>
        /// <returns>BaoXiaoPinZhengApproveInfo</returns>
        internal BaoXiaoPinZhengApproveInfo BaoXiaoPinZhengApproveInfoRowToInfo(DataRow InfoDataRow)
        {
            BaoXiaoPinZhengApproveInfo Info = new BaoXiaoPinZhengApproveInfo();
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
            if (InfoDataRow["ApproveTime"] != null)
            {
                Info.ApproveTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApproveTime"));
            }
            if (InfoDataRow["ApproveState"] != null)
            {
                Info.ApproveState = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApproveState"));
            }
            if (InfoDataRow["Result"] != null)
            {
                Info.Result = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "Result"));
            }
            if (InfoDataRow["ApproveSugest"] != null)
            {
                Info.ApproveSugest = DataUtil.GetStringValueOfRow(InfoDataRow, "ApproveSugest");
            }
            if (InfoDataRow["ApproveOp"] != null)
            {
                Info.ApproveOp = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApproveOp"));
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
