//----------------------------------------------------------------------------------------------------
//???:	AdminPayment???
//??:   ???? dbo.AdminPayment ? ????????
//??:  	Model
//??:	2010-10-25 
//----------------------------------------------------------------------------------------------------
//????:
//??		         ???		     ????
//----------------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace com.TZMS.Model
{
    /// <summary>
    /// AdminPayment???
    /// </summary>
	[Serializable]
    public class AdminPaymentInfo : ACommonInfo
	{	 
		
		#region Constructor
		
        /// <summary>
        /// Constructor
        /// </summary>
        public AdminPaymentInfo()
        {
			//todo
        }
        #endregion 
		
		#region Field
		private Guid _objectId;
        private string _projectName = DBEmptyString;
        private string _company = DBEmptyString;
        private DateTime _dateFor = DBEmptyDate;
        private string _cause = DBEmptyString;
        private string _paymentType = DBEmptyString;
        private Decimal _amountOfPayment = DBEmptyDecimal;
        private string _remark = DBEmptyString;
        private string _auditOpinion = DBEmptyString;
        private string _accountingName = DBEmptyString;
		private Guid _accountingId;
		private Guid _createrId;
        private string _createrName = DBEmptyString;
        private DateTime _createTime = DBEmptyDate;
        private int _status = DBEmptyInt;
		private Guid _nextOperaterId;
        private string _nextOperaterName = DBEmptyString;
        private string _nextOperateDesc = DBEmptyString;
        private DateTime _submitTime = DBEmptyDate;
        private string _adulters = DBEmptyString;
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
        /// Company 
        /// </summary> 
		public string Company
		{
			get { return _company; }
			set { _company = value; }
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
        /// Cause 
        /// </summary> 
		public string Cause
		{
			get { return _cause; }
			set { _cause = value; }
		}

		/// <summary>
        /// PaymentType 
        /// </summary> 
		public string PaymentType
		{
			get { return _paymentType; }
			set { _paymentType = value; }
		}

		/// <summary>
        /// AmountOfPayment 
        /// </summary> 
		public Decimal AmountOfPayment
		{
			get { return GetDecimal(_amountOfPayment); }
			set { _amountOfPayment = value; }
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
        /// AccountingID 
        /// </summary> 
		public Guid AccountingId
		{
			get { return _accountingId; }
			set { _accountingId = value; }
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
        /// CreateTime 
        /// </summary> 
		public DateTime CreateTime
		{
			get { return _createTime; }
			set { _createTime = value; }
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
        /// NextOperaterID 
        /// </summary> 
		public Guid NextOperaterId
		{
			get { return _nextOperaterId; }
			set { _nextOperaterId = value; }
		}

		/// <summary>
        /// NextOperaterName 
        /// </summary> 
		public string NextOperaterName
		{
			get { return _nextOperaterName; }
			set { _nextOperaterName = value; }
		}

		/// <summary>
        /// NextOperateDesc 
        /// </summary> 
		public string NextOperateDesc
		{
			get { return _nextOperateDesc; }
			set { _nextOperateDesc = value; }
		}

		/// <summary>
        /// SubmitTime 
        /// </summary> 
		public DateTime SubmitTime
		{
			get { return _submitTime; }
			set { _submitTime = value; }
		}

		/// <summary>
        /// Adulters 
        /// </summary> 
		public string Adulters
		{
			get { return _adulters; }
			set { _adulters = value; }
		}

		#endregion
	}
}


