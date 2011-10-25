//----------------------------------------------------------------------------------------------------
//程序名:	Customer 控制类
//功能:  	定义了与 dbo.Customer 表 对应的数据访问控制类
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
    /// CustomerCtrl
    /// programmer:shunlian
    /// </summary>
    public class CustomerCtrl
    {
        #region 构造函数

        /// <summary>
        /// CustomerCtrl默认构造函数
        /// </summary>
        public CustomerCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.Customer一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="CustomerInfo">CustomerInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, CustomerInfo CustomerInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "Customer_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjetctId",DbType.Guid),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Sex",DbType.Boolean),
				new SqlParameter("@Birthday",DbType.DateTime),
				new SqlParameter("@CardId",DbType.String),
				new SqlParameter("@Address",DbType.String),
				new SqlParameter("@OfficePhone",DbType.String),
				new SqlParameter("@MobilePhone",DbType.String),
				new SqlParameter("@Email",DbType.String),
				new SqlParameter("@CreditScore",DbType.Int32),
				new SqlParameter("@Company",DbType.String),
				new SqlParameter("@Position",DbType.String),
				new SqlParameter("@HomeAddress",DbType.String),
				new SqlParameter("@HomePhone",DbType.String),
				new SqlParameter("@Remark",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = CustomerInfo.ObjetctId;
                sqlparam[i++].Value = CustomerInfo.Name;
                sqlparam[i++].Value = CustomerInfo.Sex;
                sqlparam[i++].Value = CustomerInfo.Birthday;
                sqlparam[i++].Value = CustomerInfo.CardId;
                sqlparam[i++].Value = CustomerInfo.Address;
                sqlparam[i++].Value = CustomerInfo.OfficePhone;
                sqlparam[i++].Value = CustomerInfo.MobilePhone;
                sqlparam[i++].Value = CustomerInfo.Email;
                sqlparam[i++].Value = CustomerInfo.CreditScore;
                sqlparam[i++].Value = CustomerInfo.Company;
                sqlparam[i++].Value = CustomerInfo.Position;
                sqlparam[i++].Value = CustomerInfo.HomeAddress;
                sqlparam[i++].Value = CustomerInfo.HomePhone;
                sqlparam[i++].Value = CustomerInfo.Remark;
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
        /// dbo.Customer删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "Customer_Delete";

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
        /// Customer 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="CustomerInfo">CustomerInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, CustomerInfo CustomerInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "Customer_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjetctId",DbType.Guid),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Sex",DbType.Boolean),
				new SqlParameter("@Birthday",DbType.DateTime),
				new SqlParameter("@CardId",DbType.String),
				new SqlParameter("@Address",DbType.String),
				new SqlParameter("@OfficePhone",DbType.String),
				new SqlParameter("@MobilePhone",DbType.String),
				new SqlParameter("@Email",DbType.String),
				new SqlParameter("@CreditScore",DbType.Int32),
				new SqlParameter("@Company",DbType.String),
				new SqlParameter("@Position",DbType.String),
				new SqlParameter("@HomeAddress",DbType.String),
				new SqlParameter("@HomePhone",DbType.String),
				new SqlParameter("@Remark",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = CustomerInfo.ObjetctId;
                sqlparam[i++].Value = CustomerInfo.Name;
                sqlparam[i++].Value = CustomerInfo.Sex;
                sqlparam[i++].Value = CustomerInfo.Birthday;
                sqlparam[i++].Value = CustomerInfo.CardId;
                sqlparam[i++].Value = CustomerInfo.Address;
                sqlparam[i++].Value = CustomerInfo.OfficePhone;
                sqlparam[i++].Value = CustomerInfo.MobilePhone;
                sqlparam[i++].Value = CustomerInfo.Email;
                sqlparam[i++].Value = CustomerInfo.CreditScore;
                sqlparam[i++].Value = CustomerInfo.Company;
                sqlparam[i++].Value = CustomerInfo.Position;
                sqlparam[i++].Value = CustomerInfo.HomeAddress;
                sqlparam[i++].Value = CustomerInfo.HomePhone;
                sqlparam[i++].Value = CustomerInfo.Remark;
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
        /// Customer 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "Customer_Search";
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
        ///Customer 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<CustomerInfo></returns>
        public List<CustomerInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<CustomerInfo> list = new List<CustomerInfo>();
            CustomerInfo accountInfo = new CustomerInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = CustomerInfoRowToInfo(row);
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
        /// <param name="CustomerDataRow">CustomerDataRow</param>
        /// <returns>CustomerInfo</returns>
        internal CustomerInfo CustomerInfoRowToInfo(DataRow CustomerInfoInfoDataRow)
        {
            CustomerInfo CustomerInfoInfo = new CustomerInfo();
            if (CustomerInfoInfoDataRow["ObjetctId"] != null)
            {
                CustomerInfoInfo.ObjetctId =new Guid( DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "ObjetctId"));
            }
            if (CustomerInfoInfoDataRow["Name"] != null)
            {
                CustomerInfoInfo.Name = DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "Name");
            }
            if (CustomerInfoInfoDataRow["Sex"] != null)
            {
                CustomerInfoInfo.Sex =bool.Parse( DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "Sex"));
            }
            if (CustomerInfoInfoDataRow["Birthday"] != null)
            {
                CustomerInfoInfo.Birthday =DateTime.Parse( DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "Birthday"));
            }
            if (CustomerInfoInfoDataRow["CardId"] != null)
            {
                CustomerInfoInfo.CardId = DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "CardId");
            }
            if (CustomerInfoInfoDataRow["Address"] != null)
            {
                CustomerInfoInfo.Address = DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "Address");
            }
            if (CustomerInfoInfoDataRow["OfficePhone"] != null)
            {
                CustomerInfoInfo.OfficePhone = DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "OfficePhone");
            }
            if (CustomerInfoInfoDataRow["MobilePhone"] != null)
            {
                CustomerInfoInfo.MobilePhone = DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "MobilePhone");
            }
            if (CustomerInfoInfoDataRow["Email"] != null)
            {
                CustomerInfoInfo.Email = DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "Email");
            }
            if (CustomerInfoInfoDataRow["CreditScore"] != null)
            {
                CustomerInfoInfo.CreditScore =int.Parse( DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "CreditScore"));
            }
            if (CustomerInfoInfoDataRow["Company"] != null)
            {
                CustomerInfoInfo.Company = DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "Company");
            }
            if (CustomerInfoInfoDataRow["Position"] != null)
            {
                CustomerInfoInfo.Position = DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "Position");
            }
            if (CustomerInfoInfoDataRow["HomeAddress"] != null)
            {
                CustomerInfoInfo.HomeAddress = DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "HomeAddress");
            }
            if (CustomerInfoInfoDataRow["HomePhone"] != null)
            {
                CustomerInfoInfo.HomePhone = DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "HomePhone");
            }
            if (CustomerInfoInfoDataRow["Remark"] != null)
            {
                CustomerInfoInfo.Remark = DataUtil.GetStringValueOfRow(CustomerInfoInfoDataRow, "Remark");
            }

            return CustomerInfoInfo;
        }
        #endregion
    }
}
