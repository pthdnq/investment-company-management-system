//----------------------------------------------------------------------------------------------------
//程序名:	BankLoan实体类
//功能:   定义了与 dbo.BankLoan 表 对应的数据实体类
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
    /// BankLoan实体类
    /// </summary>
	[Serializable]
    public class BankLoanInfo : ACommonInfo
	{	 
		
		#region Constructor
		
        /// <summary>
        /// Constructor
        /// </summary>
        public BankLoanInfo()
        {
			//todo
        }
        #endregion 
		
		#region Field
		private Guid _objetctId;
		private string _customerName = DBEmptyString;
		private Guid _customerId;
        private string _loanCompany = DBEmptyString;
        private Decimal _loanAmount = DBEmptyDecimal;
        private Decimal _loanFee = DBEmptyDecimal;
        private string _collateralCompany = DBEmptyString;
        private DateTime _signDate = DBEmptyDate;
        private Decimal _downPayment = DBEmptyDecimal;
        private string _contact = DBEmptyString;
        private string _remark = DBEmptyString;
		private Guid _nextOperaterId;
        private string _nextOperaterAccount = DBEmptyString;
        private string _nextOperaterName = DBEmptyString;
        private DateTime _createTime = DBEmptyDate;
		private Guid _createrId;
        private string _createrName = DBEmptyString;
        private string _createrAccount = DBEmptyString;
		private DateTime _submitTime = DBEmptyDate;
        private string _auditOpinion = DBEmptyString;
		private  char _status =DBEmptyChar;
		#endregion 

		#region Property
		/// <summary>
        /// ObjetctID 
        /// </summary> 
		public Guid ObjetctId
		{
			get { return _objetctId; }
			set { _objetctId = value; }
		}

		/// <summary>
        /// CustomerName 
        /// </summary> 
		public string CustomerName
		{
			get { return _customerName; }
			set { _customerName = value; }
		}

		/// <summary>
        /// CustomerID 
        /// </summary> 
		public Guid CustomerId
		{
			get { return _customerId; }
			set { _customerId = value; }
		}

		/// <summary>
        /// LoanCompany 
        /// </summary> 
		public string LoanCompany
		{
			get { return _loanCompany; }
			set { _loanCompany = value; }
		}

		/// <summary>
        /// LoanAmount 
        /// </summary> 
		public Decimal LoanAmount
		{
			get { return _loanAmount; }
			set { _loanAmount = value; }
		}

		/// <summary>
        /// LoanFee 
        /// </summary> 
		public Decimal LoanFee
		{
			get { return _loanFee; }
			set { _loanFee = value; }
		}

		/// <summary>
        /// CollateralCompany 
        /// </summary> 
		public string CollateralCompany
		{
			get { return _collateralCompany; }
			set { _collateralCompany = value; }
		}

		/// <summary>
        /// SignDate 
        /// </summary> 
		public DateTime SignDate
		{
			get { return _signDate; }
			set { _signDate = value; }
		}

		/// <summary>
        /// DownPayment 
        /// </summary> 
		public Decimal DownPayment
		{
			get { return _downPayment; }
			set { _downPayment = value; }
		}

		/// <summary>
        /// Contact 
        /// </summary> 
		public string Contact
		{
			get { return _contact; }
			set { _contact = value; }
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
        /// NextOperaterID 
        /// </summary> 
		public Guid NextOperaterId
		{
			get { return _nextOperaterId; }
			set { _nextOperaterId = value; }
		}

		/// <summary>
        /// NextOperaterAccount 
        /// </summary> 
		public string NextOperaterAccount
		{
			get { return _nextOperaterAccount; }
			set { _nextOperaterAccount = value; }
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
        /// CreateTime 
        /// </summary> 
		public DateTime CreateTime
		{
			get { return _createTime; }
			set { _createTime = value; }
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
        /// CreaterAccount 
        /// </summary> 
		public string CreaterAccount
		{
			get { return _createrAccount; }
			set { _createrAccount = value; }
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
        /// AuditOpinion 
        /// </summary> 
		public string AuditOpinion
		{
			get { return _auditOpinion; }
			set { _auditOpinion = value; }
		}

		/// <summary>
        /// Status 
        /// </summary> 
		public  char Status
		{
			get { return _status; }
			set { _status = value; }
		}

		#endregion
	}
}


