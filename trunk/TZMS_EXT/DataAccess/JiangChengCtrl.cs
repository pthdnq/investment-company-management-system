//----------------------------------------------------------------------------------------------------
//程序名:	JingShengApprove 控制类
//功能:  	定义了与 dbo.JiangCheng 表 对应的数据访问控制类
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
    /// JiangChengCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class JiangChengCtrl
    {
        #region 构造函数

        /// <summary>
        /// JiangChengCtrl默认构造函数
        /// </summary>
        public JiangChengCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.JiangCheng一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="JiangChengInfo">JiangChengInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, JiangChengInfo JiangChengInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "JingShengApprove_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@CreateUserID",DbType.Guid),
				new SqlParameter("@CreateName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@Type",DbType.Int16),
				new SqlParameter("@Reason",DbType.String),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@ZjID",DbType.Guid),
				new SqlParameter("@ZJName",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				};

                int i = 0;
                sqlparam[i++].Value = JiangChengInfo.ObjectID;
                sqlparam[i++].Value = JiangChengInfo.CreateUserID;
                sqlparam[i++].Value = JiangChengInfo.CreateName;
                sqlparam[i++].Value = JiangChengInfo.CreateTime;
                sqlparam[i++].Value = JiangChengInfo.Type;
                sqlparam[i++].Value = JiangChengInfo.Reason;
                sqlparam[i++].Value = JiangChengInfo.UserID;
                sqlparam[i++].Value = JiangChengInfo.UserName;
                sqlparam[i++].Value = JiangChengInfo.UserDept;
                sqlparam[i++].Value = JiangChengInfo.ZjID;
                sqlparam[i++].Value = JiangChengInfo.ZJName;
                sqlparam[i++].Value = JiangChengInfo.State;
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
        /// dbo.JiangCheng删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "JingShengApprove_Delete";

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
        /// JingShengApprove 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="JiangChengInfo">JiangChengInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, JiangChengInfo JiangChengInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "JingShengApprove_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@CreateUserID",DbType.Guid),
				new SqlParameter("@CreateName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@Type",DbType.Int16),
				new SqlParameter("@Reason",DbType.String),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@ZjID",DbType.Guid),
				new SqlParameter("@ZJName",DbType.String),
				new SqlParameter("@State",DbType.Int16),
                };

                int i = 0;
                sqlparam[i++].Value = JiangChengInfo.ObjectID;
                sqlparam[i++].Value = JiangChengInfo.CreateUserID;
                sqlparam[i++].Value = JiangChengInfo.CreateName;
                sqlparam[i++].Value = JiangChengInfo.CreateTime;
                sqlparam[i++].Value = JiangChengInfo.Type;
                sqlparam[i++].Value = JiangChengInfo.Reason;
                sqlparam[i++].Value = JiangChengInfo.UserID;
                sqlparam[i++].Value = JiangChengInfo.UserName;
                sqlparam[i++].Value = JiangChengInfo.UserDept;
                sqlparam[i++].Value = JiangChengInfo.ZjID;
                sqlparam[i++].Value = JiangChengInfo.ZJName;
                sqlparam[i++].Value = JiangChengInfo.State;
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
        /// JingShengApprove 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "JingShengApprove_Search";
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
        ///JingShengApprove 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<JiangChengInfo></returns>
        public List<JiangChengInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<JiangChengInfo> list = new List<JiangChengInfo>();
            JiangChengInfo accountInfo = new JiangChengInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = JiangChengInfoRowToInfo(row);
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
        /// <param name="JingShengApproveDataRow">JingShengApproveDataRow</param>
        /// <returns>JiangChengInfo</returns>
        internal JiangChengInfo JiangChengInfoRowToInfo(DataRow InfoDataRow)
        {
            JiangChengInfo Info = new JiangChengInfo();
            if (InfoDataRow["ObjectID"] != null)
            {
                Info.ObjectID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectID"));
            }
            if (InfoDataRow["CreateUserID"] != null)
            {
                Info.CreateUserID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "CreateUserID"));
            }
            if (InfoDataRow["CreateName"] != null)
            {
                Info.CreateName = DataUtil.GetStringValueOfRow(InfoDataRow, "CreateName");
            }
            if (InfoDataRow["CreateTime"] != null)
            {
                Info.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "CreateTime"));
            }
            if (InfoDataRow["Type"] != null)
            {
                Info.Type = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "Type"));
            }
            if (InfoDataRow["Reason"] != null)
            {
                Info.Reason = DataUtil.GetStringValueOfRow(InfoDataRow, "Reason");
            }
            if (InfoDataRow["UserID"] != null)
            {
                Info.UserID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "UserID"));
            }
            if (InfoDataRow["UserName"] != null)
            {
                Info.UserName = DataUtil.GetStringValueOfRow(InfoDataRow, "UserName");
            }
            if (InfoDataRow["UserDept"] != null)
            {
                Info.UserDept = DataUtil.GetStringValueOfRow(InfoDataRow, "UserDept");
            }
            if (InfoDataRow["ZjID"] != null)
            {
                Info.ZjID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ZjID"));
            }
            if (InfoDataRow["ZJName"] != null)
            {
                Info.ZJName = DataUtil.GetStringValueOfRow(InfoDataRow, "ZJName");
            }
            if (InfoDataRow["State"] != null)
            {
                Info.State = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "State"));
            }

            return Info;
        }
        #endregion
    }
}
