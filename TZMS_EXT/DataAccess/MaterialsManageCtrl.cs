//----------------------------------------------------------------------------------------------------
//程序名:	MaterialsManage 控制类
//功能:  	定义了与 dbo.MaterialsManage 表 对应的数据访问控制类
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
    /// MaterialsManageCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class MaterialsManageCtrl
    {
        #region 构造函数

        /// <summary>
        /// MaterialsManageCtrl默认构造函数
        /// </summary>
        public MaterialsManageCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.MaterialsManage一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="MaterialsManageInfo">MaterialsManageInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, MaterialsManageInfo MaterialsManageInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "MaterialsManage_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@MaterialsType",DbType.Int16),
				new SqlParameter("@MaterialsName",DbType.String),
				new SqlParameter("@Numbers",DbType.Int32),
				new SqlParameter("@CurrentNumbers",DbType.Int32),
                new SqlParameter("@IsDelete",DbType.Boolean)
				};

                int i = 0;
                sqlparam[i++].Value = MaterialsManageInfo.ObjectID;
                sqlparam[i++].Value = MaterialsManageInfo.MaterialsType;
                sqlparam[i++].Value = MaterialsManageInfo.MaterialsName;
                sqlparam[i++].Value = MaterialsManageInfo.Numbers;
                sqlparam[i++].Value = MaterialsManageInfo.CurrentNumbers;
                sqlparam[i++].Value = MaterialsManageInfo.IsDelete;
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
        /// dbo.MaterialsManage删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "MaterialsManage_Delete";

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
        /// MaterialsManage 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="MaterialsManageInfo">MaterialsManageInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, MaterialsManageInfo MaterialsManageInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "MaterialsManage_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@MaterialsType",DbType.Int16),
				new SqlParameter("@MaterialsName",DbType.String),
				new SqlParameter("@Numbers",DbType.Int32),
				new SqlParameter("@CurrentNumbers",DbType.Int32),
                new SqlParameter("@IsDelete",DbType.Boolean)
                };

                int i = 0;
                sqlparam[i++].Value = MaterialsManageInfo.ObjectID;
                sqlparam[i++].Value = MaterialsManageInfo.MaterialsType;
                sqlparam[i++].Value = MaterialsManageInfo.MaterialsName;
                sqlparam[i++].Value = MaterialsManageInfo.Numbers;
                sqlparam[i++].Value = MaterialsManageInfo.CurrentNumbers;
                sqlparam[i++].Value = MaterialsManageInfo.IsDelete;
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
        /// MaterialsManage 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "MaterialsManage_Search";
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
        ///MaterialsManage 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<MaterialsManageInfo></returns>
        public List<MaterialsManageInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<MaterialsManageInfo> list = new List<MaterialsManageInfo>();
            MaterialsManageInfo accountInfo = new MaterialsManageInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = MaterialsManageInfoRowToInfo(row);
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
        /// <param name="MaterialsManageDataRow">MaterialsManageDataRow</param>
        /// <returns>MaterialsManageInfo</returns>
        internal MaterialsManageInfo MaterialsManageInfoRowToInfo(DataRow InfoDataRow)
        {
            MaterialsManageInfo Info = new MaterialsManageInfo();
            if (InfoDataRow["ObjectID"] != null)
            {
                Info.ObjectID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectID"));
            }
            if (InfoDataRow["MaterialsType"] != null)
            {
                Info.MaterialsType = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "MaterialsType"));
            }
            if (InfoDataRow["MaterialsName"] != null)
            {
                Info.MaterialsName = DataUtil.GetStringValueOfRow(InfoDataRow, "MaterialsName");
            }
            if (InfoDataRow["Numbers"] != null)
            {
                Info.Numbers = int.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "Numbers"));
            }
            if (InfoDataRow["CurrentNumbers"] != null)
            {
                Info.CurrentNumbers = int.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "CurrentNumbers"));
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
