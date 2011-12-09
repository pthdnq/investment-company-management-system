//----------------------------------------------------------------------------------------------------
//������:	AccountantAuditHistoryʵ����
//����:   �������� dbo.AccountantAuditHistory �� ��Ӧ������ʵ����
//����:  	CodeSmith
//ʱ��:	2010-10-26 
//----------------------------------------------------------------------------------------------------
//������ʷ:
//����		         ������		     ��������
//----------------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace com.TZMS.Model
{
    /// <summary>
    /// AccountantAuditHistoryʵ����
    /// </summary>
	[Serializable]
    public class AccountantAuditHistoryInfo : ACommonInfo
	{	 
		
		#region Constructor
		
        /// <summary>
        /// Constructor
        /// </summary>
        public AccountantAuditHistoryInfo()
        {
			//todo
        }
        #endregion 
		
		#region Field
		private Guid _id;
		private Guid _forId;
		private string _operationerName;
		private string _operationerAccount;
		private DateTime _operationTime;
		private string _operationType;
		private string _operationDesc;
		private string _remark;
        private string _bizType;
		#endregion 

		#region Property
		/// <summary>
        /// ID 
        /// </summary> 
		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}

		/// <summary>
        /// ForID 
        /// </summary> 
		public Guid ForId
		{
			get { return _forId; }
			set { _forId = value; }
		}

		/// <summary>
        /// OperationerName 
        /// </summary> 
		public string OperationerName
		{
			get { return _operationerName; }
			set { _operationerName = value; }
		}

		/// <summary>
        /// OperationerAccount 
        /// </summary> 
		public string OperationerAccount
		{
			get { return _operationerAccount; }
			set { _operationerAccount = value; }
		}

		/// <summary>
        /// OperationTime 
        /// </summary> 
		public DateTime OperationTime
		{
			get { return _operationTime; }
			set { _operationTime = value; }
		}

		/// <summary>
        /// OperationType 
        /// </summary> 
		public string OperationType
		{
			get { return _operationType; }
			set { _operationType = value; }
		}

		/// <summary>
        /// OperationDesc 
        /// </summary> 
		public string OperationDesc
		{
			get { return _operationDesc; }
			set { _operationDesc = value; }
		}

		/// <summary>
        /// Remark 
        /// </summary> 
		public string Remark
		{
			get { return _remark; }
			set { _remark = value; }
		}

        /// <summary>
        /// BizType 
        /// </summary> 
        public string BizType
        {
            get { return _bizType; }
            set { _bizType = value; }
        }

		#endregion
	}
}


