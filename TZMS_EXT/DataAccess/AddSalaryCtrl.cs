//----------------------------------------------------------------------------------------------------
//程序名:	AddSalary 控制类
//功能:  	定义了与 dbo.AddSalary 表 对应的数据访问控制类
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
    /// AddSalaryCtrl
    /// programmer:shunlian
    /// </summary>
    public class AddSalaryCtrl
    {
        #region 构造函数

        /// <summary>
        /// AddSalaryCtrl默认构造函数
        /// </summary>
        public AddSalaryCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.AddSalary一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="AddSalaryInfo">AddSalaryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, AddSalaryInfo AddSalaryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "AddSalary_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@UserId",DbType.Guid),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@BaseSalary",DbType.Guid),
				new SqlParameter("@ExamSalary",DbType.Guid),
				new SqlParameter("@OtherSalary",DbType.Guid),
				new SqlParameter("@Context",DbType.String),
				new SqlParameter("@CurrentCheckerId",DbType.Guid),
                new SqlParameter("@State",DbType.Int16),
                new SqlParameter("@ApplyTime",DbType.DateTime),
                new SqlParameter("@BaseSalaryFlag",DbType.String),
                new SqlParameter("@ExamSalaryFlag",DbType.String),
                new SqlParameter("@OtherSalaryFlag",DbType.String)
				};

                int i = 0;
                sqlparam[i++].Value = AddSalaryInfo.ObjectId;
                sqlparam[i++].Value = AddSalaryInfo.UserId;
                sqlparam[i++].Value = AddSalaryInfo.Name;
                sqlparam[i++].Value = AddSalaryInfo.Dept;
                sqlparam[i++].Value = AddSalaryInfo.BaseSalary;
                sqlparam[i++].Value = AddSalaryInfo.ExamSalary;
                sqlparam[i++].Value = AddSalaryInfo.OtherSalary;
                sqlparam[i++].Value = AddSalaryInfo.Context;
                sqlparam[i++].Value = AddSalaryInfo.CurrentCheckerId;
                sqlparam[i++].Value = AddSalaryInfo.State;
                sqlparam[i++].Value = AddSalaryInfo.ApplyTime;
                sqlparam[i++].Value = AddSalaryInfo.BaseSalaryFlag;
                sqlparam[i++].Value = AddSalaryInfo.ExamSalaryFlag;
                sqlparam[i++].Value = AddSalaryInfo.OtherSalaryFlag;
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
        /// dbo.AddSalary删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "AddSalary_Delete";

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
        /// AddSalary 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="AddSalaryInfo">AddSalaryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, AddSalaryInfo AddSalaryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "AddSalary_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@UserId",DbType.Guid),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@BaseSalary",DbType.Guid),
				new SqlParameter("@ExamSalary",DbType.Guid),
				new SqlParameter("@OtherSalary",DbType.Guid),
				new SqlParameter("@Context",DbType.String),
				new SqlParameter("@CurrentCheckerId",DbType.Guid),
                new SqlParameter("@State",DbType.Int16),
                new SqlParameter("@ApplyTime",DbType.DateTime),
                new SqlParameter("@BaseSalaryFlag",DbType.String),
                new SqlParameter("@ExamSalaryFlag",DbType.String),
                new SqlParameter("@OtherSalaryFlag",DbType.String)
                };

                int i = 0;
                sqlparam[i++].Value = AddSalaryInfo.ObjectId;
                sqlparam[i++].Value = AddSalaryInfo.UserId;
                sqlparam[i++].Value = AddSalaryInfo.Name;
                sqlparam[i++].Value = AddSalaryInfo.Dept;
                sqlparam[i++].Value = AddSalaryInfo.BaseSalary;
                sqlparam[i++].Value = AddSalaryInfo.ExamSalary;
                sqlparam[i++].Value = AddSalaryInfo.OtherSalary;
                sqlparam[i++].Value = AddSalaryInfo.Context;
                sqlparam[i++].Value = AddSalaryInfo.CurrentCheckerId;
                sqlparam[i++].Value = AddSalaryInfo.State;
                sqlparam[i++].Value = AddSalaryInfo.ApplyTime;
                sqlparam[i++].Value = AddSalaryInfo.BaseSalaryFlag;
                sqlparam[i++].Value = AddSalaryInfo.ExamSalaryFlag;
                sqlparam[i++].Value = AddSalaryInfo.OtherSalaryFlag;
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
        /// AddSalary 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "AddSalary_Search";
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
        ///AddSalary 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<AddSalaryInfo></returns>
        public List<AddSalaryInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<AddSalaryInfo> list = new List<AddSalaryInfo>();
            AddSalaryInfo accountInfo = new AddSalaryInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = AddSalaryInfoRowToInfo(row);
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
        /// <param name="AddSalaryDataRow">AddSalaryDataRow</param>
        /// <returns>AddSalaryInfo</returns>
        internal AddSalaryInfo AddSalaryInfoRowToInfo(DataRow AddSalaryInfoInfoDataRow)
        {
            AddSalaryInfo AddSalaryInfoInfo = new AddSalaryInfo();
            if (AddSalaryInfoInfoDataRow["ObjectId"] != null)
            {
                AddSalaryInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "ObjectId"));
            }
            if (AddSalaryInfoInfoDataRow["UserId"] != null)
            {
                AddSalaryInfoInfo.UserId = new Guid(DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "UserId"));
            }
            if (AddSalaryInfoInfoDataRow["Name"] != null)
            {
                AddSalaryInfoInfo.Name = DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "Name");
            }
            if (AddSalaryInfoInfoDataRow["Dept"] != null)
            {
                AddSalaryInfoInfo.Dept = DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "Dept");
            }
            if (AddSalaryInfoInfoDataRow["BaseSalary"] != null)
            {
                AddSalaryInfoInfo.BaseSalary =decimal.Parse( DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "BaseSalary"));
            }
            if (AddSalaryInfoInfoDataRow["ExamSalary"] != null)
            {
                AddSalaryInfoInfo.ExamSalary = decimal.Parse(DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "ExamSalary"));
            }
            if (AddSalaryInfoInfoDataRow["OtherSalary"] != null)
            {
                AddSalaryInfoInfo.OtherSalary = decimal.Parse(DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "OtherSalary"));
            }
            if (AddSalaryInfoInfoDataRow["Context"] != null)
            {
                AddSalaryInfoInfo.Context = DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "Context");
            }
            if (AddSalaryInfoInfoDataRow["CurrentCheckerId"] != null)
            {
                AddSalaryInfoInfo.CurrentCheckerId = new Guid(DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "CurrentCheckerId"));
            }
            if (AddSalaryInfoInfoDataRow["State"] != null)
            {
                AddSalaryInfoInfo.State = short.Parse(DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "State"));
            }
            if (AddSalaryInfoInfoDataRow["ApplyTime"] != null)
            {
                AddSalaryInfoInfo.ApplyTime = DateTime.Parse(DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "ApplyTime"));
            }

            if (AddSalaryInfoInfoDataRow["BaseSalaryFlag"] != null)
            {
                AddSalaryInfoInfo.BaseSalaryFlag = DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "BaseSalaryFlag");
            }
            if (AddSalaryInfoInfoDataRow["ExamSalaryFlag"] != null)
            {
                AddSalaryInfoInfo.ExamSalaryFlag = DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "ExamSalaryFlag");
            }
            if (AddSalaryInfoInfoDataRow["OtherSalaryFlag"] != null)
            {
                AddSalaryInfoInfo.OtherSalaryFlag = DataUtil.GetStringValueOfRow(AddSalaryInfoInfoDataRow, "OtherSalaryFlag");
            }

            return AddSalaryInfoInfo;
        }
        #endregion
    }
}
