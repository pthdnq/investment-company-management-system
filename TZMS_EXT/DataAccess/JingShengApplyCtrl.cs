//----------------------------------------------------------------------------------------------------
//程序名:	JingShengApply 控制类
//功能:  	定义了与 dbo.JingShengApply 表 对应的数据访问控制类
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
    /// JingShengApplyCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class JingShengApplyCtrl
    {
        #region 构造函数

        /// <summary>
        /// JingShengApplyCtrl默认构造函数
        /// </summary>
        public JingShengApplyCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.JingShengApply一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="JingShengApplyInfo">JingShengApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, JingShengApplyInfo JingShengApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "JingShengApply_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@Position",DbType.String),
				new SqlParameter("@ApplyPosition",DbType.String),
				new SqlParameter("@Context",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproveID",DbType.Guid),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				};

                int i = 0;
                sqlparam[i++].Value = JingShengApplyInfo.ObjectID;
                sqlparam[i++].Value = JingShengApplyInfo.UserID;
                sqlparam[i++].Value = JingShengApplyInfo.Name;
                sqlparam[i++].Value = JingShengApplyInfo.Dept;
                sqlparam[i++].Value = JingShengApplyInfo.Position;
                sqlparam[i++].Value = JingShengApplyInfo.ApplyPosition;
                sqlparam[i++].Value = JingShengApplyInfo.Context;
                sqlparam[i++].Value = JingShengApplyInfo.State;
                sqlparam[i++].Value = JingShengApplyInfo.ApproveID;
                sqlparam[i++].Value = JingShengApplyInfo.ApplyTime;
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
        /// dbo.JingShengApply删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "JingShengApply_Delete";

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
        /// JingShengApply 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="JingShengApplyInfo">JingShengApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, JingShengApplyInfo JingShengApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "JingShengApply_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@Position",DbType.String),
				new SqlParameter("@ApplyPosition",DbType.String),
				new SqlParameter("@Context",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproveID",DbType.Guid),
				new SqlParameter("@ApplyTime",DbType.DateTime),
                };

                int i = 0;
                sqlparam[i++].Value = JingShengApplyInfo.ObjectID;
                sqlparam[i++].Value = JingShengApplyInfo.UserID;
                sqlparam[i++].Value = JingShengApplyInfo.Name;
                sqlparam[i++].Value = JingShengApplyInfo.Dept;
                sqlparam[i++].Value = JingShengApplyInfo.Position;
                sqlparam[i++].Value = JingShengApplyInfo.ApplyPosition;
                sqlparam[i++].Value = JingShengApplyInfo.Context;
                sqlparam[i++].Value = JingShengApplyInfo.State;
                sqlparam[i++].Value = JingShengApplyInfo.ApproveID;
                sqlparam[i++].Value = JingShengApplyInfo.ApplyTime;
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
        /// JingShengApply 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "JingShengApply_Search";
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
        ///JingShengApply 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<JingShengApplyInfo></returns>
        public List<JingShengApplyInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<JingShengApplyInfo> list = new List<JingShengApplyInfo>();
            JingShengApplyInfo accountInfo = new JingShengApplyInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = JingShengApplyInfoRowToInfo(row);
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
        /// <param name="JingShengApplyDataRow">JingShengApplyDataRow</param>
        /// <returns>JingShengApplyInfo</returns>
        internal JingShengApplyInfo JingShengApplyInfoRowToInfo(DataRow InfoDataRow)
        {
            JingShengApplyInfo Info = new JingShengApplyInfo();
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
            if (InfoDataRow["Position"] != null)
            {
                Info.Position = DataUtil.GetStringValueOfRow(InfoDataRow, "Position");
            }
            if (InfoDataRow["ApplyPosition"] != null)
            {
                Info.ApplyPosition = DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyPosition");
            }
            if (InfoDataRow["Context"] != null)
            {
                Info.Context = DataUtil.GetStringValueOfRow(InfoDataRow, "Context");
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
