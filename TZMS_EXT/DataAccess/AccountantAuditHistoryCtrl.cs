//----------------------------------------------------------------------------------------------------
//������:	AccountantAuditHistory ������
//����:  	�������� dbo.AccountantAuditHistory �� ��Ӧ�����ݷ��ʿ�����
//����:  	 
//ʱ��:	2011-10-26 
//----------------------------------------------------------------------------------------------------
//������ʷ:
// ����		            ������		     ��������
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
    /// AccountantAuditHistoryCtrl
    /// programmer:shunlian
    /// </summary>
    public class AccountantAuditHistoryCtrl
    {
        #region ���캯��

        /// <summary>
        /// AccountantAuditHistoryCtrlĬ�Ϲ��캯��
        /// </summary>
        public AccountantAuditHistoryCtrl()
        {
            //ToDo
        }

        #endregion

        #region ����ɾ���ġ���

        /// <summary>
        /// ����dbo.AccountantAuditHistoryһ����¼
        /// </summary>
        /// <param name="boName">���ݿ���������key??</param>
        /// <param name="AccountantAuditHistoryInfo">AccountantAuditHistoryInfo??</param>
        /// <returns>���ر�־,0:ʧ��,1:�ɹ�</returns>
        public int Insert(string boName, AccountantAuditHistoryInfo AccountantAuditHistoryInfo)
        {
            try
            {
                //�洢��������
                string strsql = "AccountantAuditHistory_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@Id",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@OperationerName",DbType.String),
				new SqlParameter("@OperationerAccount",DbType.String),
				new SqlParameter("@OperationTime",DbType.DateTime),
				new SqlParameter("@OperationType",DbType.String),
				new SqlParameter("@OperationDesc",DbType.String),
				new SqlParameter("@Remark",DbType.String),
                	new SqlParameter("@BizType",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.Id;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.ForId;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.OperationerName;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.OperationTime;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.OperationType;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.OperationDesc;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.Remark;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.BizType;
                SqlDBAccess dbaccess = new SqlDBAccess();
                //ִ�д洢����
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
        /// dbo.AccountantAuditHistoryɾ����¼(ͨ����¼ID ObjectID)
        /// </summary>
        /// <param name="boName">���ݿ���������key��Ϣ</param>
        /// <param name="objectID">ObjectID(ΨһID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "AccountantAuditHistory_Delete";

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
        /// AccountantAuditHistory ���¼�¼
        /// </summary>
        /// <param name="boName">���ݿ���������key��Ϣ</param>
        /// <param name="AccountantAuditHistoryInfo">AccountantAuditHistoryInfo??</param>
        /// <returns>���ر�־,0:ʧ��,1:�ɹ�</returns>
        public int UpDate(string boName, AccountantAuditHistoryInfo AccountantAuditHistoryInfo)
        {
            try
            {
                //�洢��������
                string strsql = "AccountantAuditHistory_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@Id",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@OperationerName",DbType.String),
				new SqlParameter("@OperationerAccount",DbType.String),
				new SqlParameter("@OperationTime",DbType.DateTime),
				new SqlParameter("@OperationType",DbType.String),
				new SqlParameter("@OperationDesc",DbType.String),
				new SqlParameter("@Remark",DbType.String),
                new SqlParameter("@BizType",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.Id;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.ForId;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.OperationerName;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.OperationTime;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.OperationType;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.OperationDesc;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.Remark;
                sqlparam[i++].Value = AccountantAuditHistoryInfo.BizType;
                SqlDBAccess dbaccess = new SqlDBAccess();
                //ִ�д洢����
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
        /// AccountantAuditHistory ��ѯ,����Datatable
        /// </summary>
        /// <param name="boName">���ݿ���������key��Ϣ</param>
        /// <param name="selectCondition">��ѯ����</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //�洢��������
                string strsql = "AccountantAuditHistory_Search";
                SqlParameter[] sqlparam =
                {
					new SqlParameter("@Condition",SqlDbType.NVarChar), 
                };

                int i = 0;
                sqlparam[i++].Value = condition;
                SqlDBAccess dbaccess = new SqlDBAccess();
                //ִ�д洢����
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
        ///AccountantAuditHistory ��ѯ,����List
        ///</summary>
        ///<param name="boName">���ݿ���������key��Ϣ</param>
        ///<param name="selectCondition">��ѯ����</param>
        /// <returns>List<AccountantAuditHistoryInfo></returns>
        public List<AccountantAuditHistoryInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<AccountantAuditHistoryInfo> list = new List<AccountantAuditHistoryInfo>();
            AccountantAuditHistoryInfo accountInfo = new AccountantAuditHistoryInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = AccountantAuditHistoryInfoRowToInfo(row);
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
        /// <param name="AccountantAuditHistoryDataRow">AccountantAuditHistoryDataRow</param>
        /// <returns>AccountantAuditHistoryInfo</returns>
        internal AccountantAuditHistoryInfo AccountantAuditHistoryInfoRowToInfo(DataRow AccountantAuditHistoryInfoInfoDataRow)
        {
            AccountantAuditHistoryInfo AccountantAuditHistoryInfoInfo = new AccountantAuditHistoryInfo();
            if (AccountantAuditHistoryInfoInfoDataRow["Id"] != null)
            {
                AccountantAuditHistoryInfoInfo.Id = new Guid(DataUtil.GetStringValueOfRow(AccountantAuditHistoryInfoInfoDataRow, "Id"));
            }
            if (AccountantAuditHistoryInfoInfoDataRow["ForId"] != null)
            {
                AccountantAuditHistoryInfoInfo.ForId = new Guid(DataUtil.GetStringValueOfRow(AccountantAuditHistoryInfoInfoDataRow, "ForId"));
            }
            if (AccountantAuditHistoryInfoInfoDataRow["OperationerName"] != null)
            {
                AccountantAuditHistoryInfoInfo.OperationerName = DataUtil.GetStringValueOfRow(AccountantAuditHistoryInfoInfoDataRow, "OperationerName");
            }
            if (AccountantAuditHistoryInfoInfoDataRow["OperationerAccount"] != null)
            {
                AccountantAuditHistoryInfoInfo.OperationerAccount = DataUtil.GetStringValueOfRow(AccountantAuditHistoryInfoInfoDataRow, "OperationerAccount");
            }
            if (AccountantAuditHistoryInfoInfoDataRow["OperationTime"] != null)
            {
                AccountantAuditHistoryInfoInfo.OperationTime = DateTime.Parse(DataUtil.GetStringValueOfRow(AccountantAuditHistoryInfoInfoDataRow, "OperationTime"));
            }
            if (AccountantAuditHistoryInfoInfoDataRow["OperationType"] != null)
            {
                AccountantAuditHistoryInfoInfo.OperationType = DataUtil.GetStringValueOfRow(AccountantAuditHistoryInfoInfoDataRow, "OperationType");
            }
            if (AccountantAuditHistoryInfoInfoDataRow["OperationDesc"] != null)
            {
                AccountantAuditHistoryInfoInfo.OperationDesc = DataUtil.GetStringValueOfRow(AccountantAuditHistoryInfoInfoDataRow, "OperationDesc");
            }
            if (AccountantAuditHistoryInfoInfoDataRow["Remark"] != null)
            {
                AccountantAuditHistoryInfoInfo.Remark = DataUtil.GetStringValueOfRow(AccountantAuditHistoryInfoInfoDataRow, "Remark");
            }
            if (AccountantAuditHistoryInfoInfoDataRow["BizType"] != null)
            {
                AccountantAuditHistoryInfoInfo.BizType = DataUtil.GetStringValueOfRow(AccountantAuditHistoryInfoInfoDataRow, "BizType");
            }

            return AccountantAuditHistoryInfoInfo;
        }
        #endregion
    }
}
