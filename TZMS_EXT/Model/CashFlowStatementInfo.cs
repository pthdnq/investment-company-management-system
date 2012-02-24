//----------------------------------------------------------------------------------------------------
//程序名:	CashFlowStatementInfo实体类
//功能:   定义了与 dbo.CashFlowStatementInfo 表 对应的数据实体类
//作者:  	CodeSmith
//时间:	2010-10-25 
//----------------------------------------------------------------------------------------------------
//更改历史:
//日期		         更改人		     更改内容
//----------------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace com.TZMS.Model
{
    /// <summary>
    /// CashFlowStatement???
    /// </summary>
	[Serializable]
    public class CashFlowStatementInfo : ACommonInfo
	{	 
		
		#region Constructor
		
        /// <summary>
        /// Constructor
        /// </summary>
        public CashFlowStatementInfo()
        {
			//todo
        }
        #endregion 
		
		#region Field
		private Guid _objectId;
        private string _projectName = DBEmptyString;
		private DateTime _dateFor = DBEmptyDate;
        private Decimal _amount = DBEmptyDecimal;
        private Decimal _remainingAmount = DBEmptyDecimal;
        private string _flowDirection = DBEmptyString;
        private string _flowType = DBEmptyString;
        private string _receivables = DBEmptyString;
        private string _payment = DBEmptyString;
        private int _isAccountingAudit = DBEmptyTinyInt;
        private string _auditOpinion = DBEmptyString;
        private string _accountingName = DBEmptyString;
        private string _accountingAccount = DBEmptyString;
		private Guid _createrId;
		private string _createrName =DBEmptyString;
        private DateTime _cteateTime = DBEmptyDate;
        private int _status = DBEmptyTinyInt;
        private string _biz = DBEmptyString;
        private string _summary = DBEmptyString;
        private string _matter = DBEmptyString;
        private string _remark = DBEmptyString;
		#endregion 

		#region Property
		/// <summary>
        /// ObjectID 
        /// </summary> 
		public Guid ObjectId
		{
			get { return _objectId; }
			set { _objectId = value; }
		}

        /// <summary>
        /// ProjectName 
        /// </summary> 
        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }

		/// <summary>
        /// DateFor 
        /// </summary> 
		public DateTime DateFor
		{
			get { return _dateFor; }
			set { _dateFor = value; }
		}

		/// <summary>
        /// Amount 
        /// </summary> 
		public Decimal Amount
		{
			get { return GetDecimal(_amount); }
			set { _amount = value; }
		}

        /// <summary>
        /// Amount 
        /// </summary> 
        public Decimal RemainingAmount
        {
            get { return GetDecimal(_remainingAmount); }
            set { _remainingAmount = value; }
        }

		/// <summary>
        /// FlowDirection 
        /// </summary> 
		public string FlowDirection
		{
			get { return _flowDirection; }
			set { _flowDirection = value; }
		}

		/// <summary>
        /// FlowType 
        /// </summary> 
		public string FlowType
		{
			get { return _flowType; }
			set { _flowType = value; }
		}

		/// <summary>
        /// Receivables 
        /// </summary> 
		public string Receivables
		{
			get { return _receivables; }
			set { _receivables = value; }
		}

		/// <summary>
        /// Payment 
        /// </summary> 
		public string Payment
		{
			get { return _payment; }
			set { _payment = value; }
		}

		/// <summary>
        /// IsAccountingAudit 
        /// </summary> 
		public int IsAccountingAudit
		{
			get { return _isAccountingAudit; }
			set { _isAccountingAudit = value; }
		}

		/// <summary>
        /// AuditOpinion 
        /// </summary> 
		public string AuditOpinion
		{
			get { return _auditOpinion; }
			set { _auditOpinion = value; }
		}

		/// <summary>
        /// AccountingName 
        /// </summary> 
		public string AccountingName
		{
			get { return _accountingName; }
			set { _accountingName = value; }
		}

		/// <summary>
        /// AccountingAccount 
        /// </summary> 
		public string AccountingAccount
		{
			get { return _accountingAccount; }
			set { _accountingAccount = value; }
		}

		/// <summary>
        /// CreaterID 
        /// </summary> 
		public Guid CreaterId
		{
			get { return _createrId; }
			set { _createrId = value; }
		}

		/// <summary>
        /// CreaterName 
        /// </summary> 
		public string CreaterName
		{
			get { return _createrName; }
			set { _createrName = value; }
		}

		/// <summary>
        /// CteateTime 
        /// </summary> 
		public DateTime CreateTime
		{
			get { return _cteateTime; }
			set { _cteateTime = value; }
		}

		/// <summary>
        /// Status 
        /// </summary> 
		public int Status
		{
			get { return _status; }
			set { _status = value; }
		}

		/// <summary>
        /// Biz 
        /// </summary> 
		public string Biz
		{
			get { return _biz; }
			set { _biz = value; }
		}

		/// <summary>
        /// Summary 
        /// </summary> 
		public string Summary
		{
			get { return _summary; }
			set { _summary = value; }
		}

		/// <summary>
        /// Matter 
        /// </summary> 
		public string Matter
		{
			get { return _matter; }
			set { _matter = value; }
		}

		/// <summary>
        /// Remark 
        /// </summary> 
		public string Remark
		{
			get { return _remark; }
			set { _remark = value; }
		}

		#endregion

     
    }
}


