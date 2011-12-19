//----------------------------------------------------------------------------------------------------
//程序名:	MaterialsApply 控制类
//功能:  	定义了与 dbo.MaterialsApply 表 对应的数据访问控制类
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
    /// MaterialsApplyCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class MaterialsApplyCtrl
    {
        #region 构造函数

        /// <summary>
        /// MaterialsApplyCtrl默认构造函数
        /// </summary>
        public MaterialsApplyCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.MaterialsApply一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="MaterialsApplyInfo">MaterialsApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, MaterialsApplyInfo MaterialsApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "MaterialsApply_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@MaterialsID",DbType.Guid),
				new SqlParameter("@ApplyCount",DbType.Int32),
                new SqlParameter("@ActualCount",DbType.Int32),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@CurrentApproverID",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
				};

                int i = 0;
                sqlparam[i++].Value = MaterialsApplyInfo.ObjectID;
                sqlparam[i++].Value = MaterialsApplyInfo.UserID;
                sqlparam[i++].Value = MaterialsApplyInfo.UserName;
                sqlparam[i++].Value = MaterialsApplyInfo.UserJobNo;
                sqlparam[i++].Value = MaterialsApplyInfo.UserAccountNo;
                sqlparam[i++].Value = MaterialsApplyInfo.UserDept;
                sqlparam[i++].Value = MaterialsApplyInfo.ApplyTime;
                sqlparam[i++].Value = MaterialsApplyInfo.MaterialsID;
                sqlparam[i++].Value = MaterialsApplyInfo.ApplyCount;
                sqlparam[i++].Value = MaterialsApplyInfo.ActualCount;
                sqlparam[i++].Value = MaterialsApplyInfo.Other;
                sqlparam[i++].Value = MaterialsApplyInfo.CurrentApproverID;
                sqlparam[i++].Value = MaterialsApplyInfo.State;
                sqlparam[i++].Value = MaterialsApplyInfo.IsDelete;
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
        /// dbo.MaterialsApply删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "MaterialsApply_Delete";

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
        /// MaterialsApply 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="MaterialsApplyInfo">MaterialsApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, MaterialsApplyInfo MaterialsApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "MaterialsApply_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@MaterialsID",DbType.Guid),
				new SqlParameter("@ApplyCount",DbType.Int32),
                new SqlParameter("@ActualCount",DbType.Int32),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@CurrentApproverID",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
                };

                int i = 0;
                sqlparam[i++].Value = MaterialsApplyInfo.ObjectID;
                sqlparam[i++].Value = MaterialsApplyInfo.UserID;
                sqlparam[i++].Value = MaterialsApplyInfo.UserName;
                sqlparam[i++].Value = MaterialsApplyInfo.UserJobNo;
                sqlparam[i++].Value = MaterialsApplyInfo.UserAccountNo;
                sqlparam[i++].Value = MaterialsApplyInfo.UserDept;
                sqlparam[i++].Value = MaterialsApplyInfo.ApplyTime;
                sqlparam[i++].Value = MaterialsApplyInfo.MaterialsID;
                sqlparam[i++].Value = MaterialsApplyInfo.ApplyCount;
                sqlparam[i++].Value = MaterialsApplyInfo.ActualCount;
                sqlparam[i++].Value = MaterialsApplyInfo.Other;
                sqlparam[i++].Value = MaterialsApplyInfo.CurrentApproverID;
                sqlparam[i++].Value = MaterialsApplyInfo.State;
                sqlparam[i++].Value = MaterialsApplyInfo.IsDelete;
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
        /// MaterialsApply 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "MaterialsApply_Search";
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
        ///MaterialsApply 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<MaterialsApplyInfo></returns>
        public List<MaterialsApplyInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<MaterialsApplyInfo> list = new List<MaterialsApplyInfo>();
            MaterialsApplyInfo accountInfo = new MaterialsApplyInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = MaterialsApplyInfoRowToInfo(row);
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
        /// <param name="MaterialsApplyDataRow">MaterialsApplyDataRow</param>
        /// <returns>MaterialsApplyInfo</returns>
        internal MaterialsApplyInfo MaterialsApplyInfoRowToInfo(DataRow InfoDataRow)
        {
            MaterialsApplyInfo Info = new MaterialsApplyInfo();
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
            if (InfoDataRow["ApplyTime"] != null)
            {
                Info.ApplyTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyTime"));
            }
            if (InfoDataRow["MaterialsID"] != null)
            {
                Info.MaterialsID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "MaterialsID"));
            }
            if (InfoDataRow["ApplyCount"] != null)
            {
                Info.ApplyCount = int.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyCount"));
            }
            if (InfoDataRow["ActualCount"] != null)
            {
                Info.ActualCount = int.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ActualCount"));
            }
            if (InfoDataRow["Other"] != null)
            {
                Info.Other = DataUtil.GetStringValueOfRow(InfoDataRow, "Other");
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

            return Info;
        }
        #endregion
    }
}
