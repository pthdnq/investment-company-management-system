//----------------------------------------------------------------------------------------------------
//程序名:	NoAttend 控制类
//功能:  	定义了与 dbo.NoAttend 表 对应的数据访问控制类
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
    /// NoAttendCtrl
    /// programmer:shunlian
    /// </summary>
    public class NoAttendCtrl
    {
        #region 构造函数

        /// <summary>
        /// NoAttendCtrl默认构造函数
        /// </summary>
        public NoAttendCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.NoAttend一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="NoAttendInfo">NoAttendInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, NoAttendInfo NoAttendInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "NoAttend_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@UserId",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@TellPhone",DbType.String),
				new SqlParameter("@Year",DbType.Int16),
				new SqlParameter("@Month",DbType.Int16),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@Comment",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@Isdelete",DbType.Boolean),
				new SqlParameter("@CurrentCheckId",DbType.Guid),
				};

                int i = 0;
                sqlparam[i++].Value = NoAttendInfo.ObjectId;
                sqlparam[i++].Value = NoAttendInfo.UserId;
                sqlparam[i++].Value = NoAttendInfo.UserName;
                sqlparam[i++].Value = NoAttendInfo.UserJobNo;
                sqlparam[i++].Value = NoAttendInfo.UserAccountNo;
                sqlparam[i++].Value = NoAttendInfo.Dept;
                sqlparam[i++].Value = NoAttendInfo.TellPhone;
                sqlparam[i++].Value = NoAttendInfo.Year;
                sqlparam[i++].Value = NoAttendInfo.Month;
                sqlparam[i++].Value = NoAttendInfo.ApplyTime;
                sqlparam[i++].Value = NoAttendInfo.Comment;
                sqlparam[i++].Value = NoAttendInfo.Other;
                sqlparam[i++].Value = NoAttendInfo.State;
                sqlparam[i++].Value = NoAttendInfo.Isdelete;
                sqlparam[i++].Value = NoAttendInfo.CurrentCheckId;
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
        /// dbo.NoAttend删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "NoAttend_Delete";

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
        /// NoAttend 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="NoAttendInfo">NoAttendInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, NoAttendInfo NoAttendInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "NoAttend_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@UserId",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@TellPhone",DbType.String),
				new SqlParameter("@Year",DbType.Int16),
				new SqlParameter("@Month",DbType.Int16),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@Comment",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@Isdelete",DbType.Boolean),
				new SqlParameter("@CurrentCheckId",DbType.Guid),
                };

                int i = 0;
                sqlparam[i++].Value = NoAttendInfo.ObjectId;
                sqlparam[i++].Value = NoAttendInfo.UserId;
                sqlparam[i++].Value = NoAttendInfo.UserName;
                sqlparam[i++].Value = NoAttendInfo.UserJobNo;
                sqlparam[i++].Value = NoAttendInfo.UserAccountNo;
                sqlparam[i++].Value = NoAttendInfo.Dept;
                sqlparam[i++].Value = NoAttendInfo.TellPhone;
                sqlparam[i++].Value = NoAttendInfo.Year;
                sqlparam[i++].Value = NoAttendInfo.Month;
                sqlparam[i++].Value = NoAttendInfo.ApplyTime;
                sqlparam[i++].Value = NoAttendInfo.Comment;
                sqlparam[i++].Value = NoAttendInfo.Other;
                sqlparam[i++].Value = NoAttendInfo.State;
                sqlparam[i++].Value = NoAttendInfo.Isdelete;
                sqlparam[i++].Value = NoAttendInfo.CurrentCheckId;
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
        /// NoAttend 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "NoAttend_Search";
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
        ///NoAttend 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<NoAttendInfo></returns>
        public List<NoAttendInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<NoAttendInfo> list = new List<NoAttendInfo>();
            NoAttendInfo accountInfo = new NoAttendInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = NoAttendInfoRowToInfo(row);
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
        /// <param name="NoAttendDataRow">NoAttendDataRow</param>
        /// <returns>NoAttendInfo</returns>
        internal NoAttendInfo NoAttendInfoRowToInfo(DataRow NoAttendInfoInfoDataRow)
        {
            NoAttendInfo NoAttendInfoInfo = new NoAttendInfo();
            if (NoAttendInfoInfoDataRow["ObjectId"] != null)
            {
                NoAttendInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "ObjectId"));
            }
            if (NoAttendInfoInfoDataRow["UserId"] != null)
            {
                NoAttendInfoInfo.UserId = new Guid(DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "UserId"));
            }
            if (NoAttendInfoInfoDataRow["UserName"] != null)
            {
                NoAttendInfoInfo.UserName = DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "UserName");
            }
            if (NoAttendInfoInfoDataRow["UserJobNo"] != null)
            {
                NoAttendInfoInfo.UserJobNo = DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "UserJobNo");
            }
            if (NoAttendInfoInfoDataRow["UserAccountNo"] != null)
            {
                NoAttendInfoInfo.UserAccountNo = DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "UserAccountNo");
            }
            if (NoAttendInfoInfoDataRow["Dept"] != null)
            {
                NoAttendInfoInfo.Dept = DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "Dept");
            }
            if (NoAttendInfoInfoDataRow["TellPhone"] != null)
            {
                NoAttendInfoInfo.TellPhone = DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "TellPhone");
            }
            if (NoAttendInfoInfoDataRow["Year"] != null)
            {
                NoAttendInfoInfo.Year = short.Parse(DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "Year"));
            }
            if (NoAttendInfoInfoDataRow["Month"] != null)
            {
                NoAttendInfoInfo.Month = short.Parse(DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "Month"));
            }
            if (NoAttendInfoInfoDataRow["ApplyTime"] != null)
            {
                NoAttendInfoInfo.ApplyTime = DateTime.Parse(DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "ApplyTime"));
            }
            if (NoAttendInfoInfoDataRow["Comment"] != null)
            {
                NoAttendInfoInfo.Comment = DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "Comment");
            }
            if (NoAttendInfoInfoDataRow["Other"] != null)
            {
                NoAttendInfoInfo.Other = DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "Other");
            }
            if (NoAttendInfoInfoDataRow["State"] != null)
            {
                NoAttendInfoInfo.State = short.Parse(DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "State"));
            }
            if (NoAttendInfoInfoDataRow["Isdelete"] != null)
            {
                NoAttendInfoInfo.Isdelete = bool.Parse(DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "Isdelete"));
            }
            if (NoAttendInfoInfoDataRow["CurrentCheckId"] != null)
            {
                NoAttendInfoInfo.CurrentCheckId = new Guid(DataUtil.GetStringValueOfRow(NoAttendInfoInfoDataRow, "CurrentCheckId"));
            }

            return NoAttendInfoInfo;
        }
        #endregion
    }
}
