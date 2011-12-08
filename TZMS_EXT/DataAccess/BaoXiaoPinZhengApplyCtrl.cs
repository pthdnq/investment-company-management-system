//----------------------------------------------------------------------------------------------------
//程序名:	BaoXiaoPinZhengApply 控制类
//功能:  	定义了与 dbo.BaoXiaoPinZhengApply 表 对应的数据访问控制类
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
    /// BaoXiaoPinZhengApplyCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class BaoXiaoPinZhengApplyCtrl
    {
        #region 构造函数

        /// <summary>
        /// BaoXiaoPinZhengApplyCtrl默认构造函数
        /// </summary>
        public BaoXiaoPinZhengApplyCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.BaoXiaoPinZhengApply一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BaoXiaoPinZhengApplyInfo">BaoXiaoPinZhengApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, BaoXiaoPinZhengApplyInfo BaoXiaoPinZhengApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BaoXiaoPinZhengApply_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@Title",DbType.String),
				new SqlParameter("@Report",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@CurrentApproverID",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
				new SqlParameter("@BaoXiaoID",DbType.Guid),
				};

                int i = 0;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.ObjectID;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.UserID;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.UserName;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.UserJobNo;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.UserAccountNo;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.UserDept;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.Title;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.Report;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.ApplyTime;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.CurrentApproverID;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.State;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.IsDelete;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.BaoXiaoID;
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
        /// dbo.BaoXiaoPinZhengApply删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "BaoXiaoPinZhengApply_Delete";

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
        /// BaoXiaoPinZhengApply 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BaoXiaoPinZhengApplyInfo">BaoXiaoPinZhengApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, BaoXiaoPinZhengApplyInfo BaoXiaoPinZhengApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BaoXiaoPinZhengApply_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@Title",DbType.String),
				new SqlParameter("@Report",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@CurrentApproverID",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
				new SqlParameter("@BaoXiaoID",DbType.Guid),
                };

                int i = 0;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.ObjectID;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.UserID;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.UserName;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.UserJobNo;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.UserAccountNo;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.UserDept;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.Title;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.Report;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.ApplyTime;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.CurrentApproverID;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.State;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.IsDelete;
                sqlparam[i++].Value = BaoXiaoPinZhengApplyInfo.BaoXiaoID;
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
        /// BaoXiaoPinZhengApply 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "BaoXiaoPinZhengApply_Search";
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
        ///BaoXiaoPinZhengApply 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<BaoXiaoPinZhengApplyInfo></returns>
        public List<BaoXiaoPinZhengApplyInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<BaoXiaoPinZhengApplyInfo> list = new List<BaoXiaoPinZhengApplyInfo>();
            BaoXiaoPinZhengApplyInfo accountInfo = new BaoXiaoPinZhengApplyInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = BaoXiaoPinZhengApplyInfoRowToInfo(row);
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
        /// <param name="BaoXiaoPinZhengApplyDataRow">BaoXiaoPinZhengApplyDataRow</param>
        /// <returns>BaoXiaoPinZhengApplyInfo</returns>
        internal BaoXiaoPinZhengApplyInfo BaoXiaoPinZhengApplyInfoRowToInfo(DataRow InfoDataRow)
        {
            BaoXiaoPinZhengApplyInfo Info = new BaoXiaoPinZhengApplyInfo();
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
            if (InfoDataRow["Title"] != null)
            {
                Info.Title = DataUtil.GetStringValueOfRow(InfoDataRow, "Title");
            }
            if (InfoDataRow["Report"] != null)
            {
                Info.Report = DataUtil.GetStringValueOfRow(InfoDataRow, "Report");
            }
            if (InfoDataRow["ApplyTime"] != null)
            {
                Info.ApplyTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyTime"));
            }
            if (InfoDataRow["CurrentApproverID"] != null)
            {
                Info.CurrentApproverID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "CurrentApproverID"));
            }
            if (InfoDataRow["State"] != null)
            {
                Info.State = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "State"));
            }
            if (InfoDataRow["IsDelete"] != null)
            {
                Info.IsDelete = bool.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "IsDelete"));
            }
            if (InfoDataRow["BaoXiaoID"] != null)
            {
                Info.BaoXiaoID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "BaoXiaoID"));
            }

            return Info;
        }
        #endregion
    }
}
