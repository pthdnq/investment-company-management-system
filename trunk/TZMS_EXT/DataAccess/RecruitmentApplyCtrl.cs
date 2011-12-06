//----------------------------------------------------------------------------------------------------
//程序名:	RecruitmentApply 控制类
//功能:  	定义了与 dbo.RecruitmentApply 表 对应的数据访问控制类
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
    /// RecruitmentApplyCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class RecruitmentApplyCtrl
    {
        #region 构造函数

        /// <summary>
        /// RecruitmentApplyCtrl默认构造函数
        /// </summary>
        public RecruitmentApplyCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.RecruitmentApply一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="RecruitmentApplyInfo">RecruitmentApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, RecruitmentApplyInfo RecruitmentApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "RecruitmentApply_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@Title",DbType.String),
				new SqlParameter("@Content",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproveID",DbType.Guid),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				};

                int i = 0;
                sqlparam[i++].Value = RecruitmentApplyInfo.ObjectID;
                sqlparam[i++].Value = RecruitmentApplyInfo.UserID;
                sqlparam[i++].Value = RecruitmentApplyInfo.Name;
                sqlparam[i++].Value = RecruitmentApplyInfo.Dept;
                sqlparam[i++].Value = RecruitmentApplyInfo.Title;
                sqlparam[i++].Value = RecruitmentApplyInfo.Content;
                sqlparam[i++].Value = RecruitmentApplyInfo.State;
                sqlparam[i++].Value = RecruitmentApplyInfo.ApproveID;
                sqlparam[i++].Value = RecruitmentApplyInfo.ApplyTime;
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
        /// dbo.RecruitmentApply删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "RecruitmentApply_Delete";

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
        /// RecruitmentApply 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="RecruitmentApplyInfo">RecruitmentApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, RecruitmentApplyInfo RecruitmentApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "RecruitmentApply_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@Title",DbType.String),
				new SqlParameter("@Content",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproveID",DbType.Guid),
				new SqlParameter("@ApplyTime",DbType.DateTime),
                };

                int i = 0;
                sqlparam[i++].Value = RecruitmentApplyInfo.ObjectID;
                sqlparam[i++].Value = RecruitmentApplyInfo.UserID;
                sqlparam[i++].Value = RecruitmentApplyInfo.Name;
                sqlparam[i++].Value = RecruitmentApplyInfo.Dept;
                sqlparam[i++].Value = RecruitmentApplyInfo.Title;
                sqlparam[i++].Value = RecruitmentApplyInfo.Content;
                sqlparam[i++].Value = RecruitmentApplyInfo.State;
                sqlparam[i++].Value = RecruitmentApplyInfo.ApproveID;
                sqlparam[i++].Value = RecruitmentApplyInfo.ApplyTime;
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
        /// RecruitmentApply 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "RecruitmentApply_Search";
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
        ///RecruitmentApply 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<RecruitmentApplyInfo></returns>
        public List<RecruitmentApplyInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<RecruitmentApplyInfo> list = new List<RecruitmentApplyInfo>();
            RecruitmentApplyInfo accountInfo = new RecruitmentApplyInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = RecruitmentApplyInfoRowToInfo(row);
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
        /// <param name="RecruitmentApplyDataRow">RecruitmentApplyDataRow</param>
        /// <returns>RecruitmentApplyInfo</returns>
        internal RecruitmentApplyInfo RecruitmentApplyInfoRowToInfo(DataRow InfoDataRow)
        {
            RecruitmentApplyInfo Info = new RecruitmentApplyInfo();
            if (InfoDataRow["ObjectID"] != null)
            {
                Info.ObjectID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectID"));
            }
            if (InfoDataRow["UserID"] != null)
            {
                Info.UserID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "UserID"));
            }
            if (InfoDataRow["Name"] != null)
            {
                Info.Name = DataUtil.GetStringValueOfRow(InfoDataRow, "Name");
            }
            if (InfoDataRow["Dept"] != null)
            {
                Info.Dept = DataUtil.GetStringValueOfRow(InfoDataRow, "Dept");
            }
            if (InfoDataRow["Title"] != null)
            {
                Info.Title = DataUtil.GetStringValueOfRow(InfoDataRow, "Title");
            }
            if (InfoDataRow["Content"] != null)
            {
                Info.Content = DataUtil.GetStringValueOfRow(InfoDataRow, "Content");
            }
            if (InfoDataRow["State"] != null)
            {
                Info.State = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "State"));
            }
            if (InfoDataRow["ApproveID"] != null)
            {
                Info.ApproveID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ApproveID"));
            }
            if (InfoDataRow["ApplyTime"] != null)
            {
                Info.ApplyTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyTime"));
            }

            return Info;
        }
        #endregion
    }
}
