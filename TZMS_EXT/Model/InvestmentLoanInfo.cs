﻿//----------------------------------------------------------------------------------------------------
//程序名:	InvestmentLoan实体类
//功能:   定义了与 dbo.InvestmentLoan 表 对应的数据实体类
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
    /// InvestmentLoan实体类
    /// </summary>
    [Serializable]
    public class InvestmentLoanInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public InvestmentLoanInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objetctId;
        private string _projectName = DBEmptyString;
        private string _projectOverview = DBEmptyString;
        private string _borrowerNameA = DBEmptyString;
        private Guid _borrowerAId;
        private string _payerBName = DBEmptyString;
        private string _borrowerPhone = DBEmptyString;
        private Decimal _loanAmount = DBEmptyDecimal;
        private DateTime _loanDate = DBEmptyDate;
        private string _collateral = DBEmptyString;
        private string _guarantor = DBEmptyString;
        private string _guarantorPhone = DBEmptyString;
        private char _rateOfReturn = DBEmptyChar;
        private DateTime _dueDateForPay = DBEmptyDate;
        private string _remark = DBEmptyString;
        private char _status = DBEmptyChar;
        private Guid _nextOperaterId;
        private string _nextOperaterAccount = DBEmptyString;
        private string _nextOperaterName = DBEmptyString;
        private DateTime _createTime = DBEmptyDate;
        private Guid _createrId;
        private string _createrName = DBEmptyString;
        private string _createrAccount = DBEmptyString;
        private DateTime _submitTime = DBEmptyDate;
        private string _auditOpinion = DBEmptyString;
        private string _accountingRemark= DBEmptyString;
        private int _dueDateForReceivables = DBEmptyInt;
        private string _receivablesRemindInfo= DBEmptyString;
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
        /// ProjectName 
        /// </summary> 
        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }

        /// <summary>
        /// ProjectOverview 
        /// </summary> 
        public string ProjectOverview
        {
            get { return _projectOverview; }
            set { _projectOverview = value; }
        }

        /// <summary>
        /// BorrowerNameA 
        /// </summary> 
        public string BorrowerNameA
        {
            get { return _borrowerNameA; }
            set { _borrowerNameA = value; }
        }

        /// <summary>
        /// BorrowerAID 
        /// </summary> 
        public Guid BorrowerAId
        {
            get { return _borrowerAId; }
            set { _borrowerAId = value; }
        }

        /// <summary>
        /// PayerBName 
        /// </summary> 
        public string PayerBName
        {
            get { return _payerBName; }
            set { _payerBName = value; }
        }

        /// <summary>
        /// BorrowerPhone 
        /// </summary> 
        public string BorrowerPhone
        {
            get { return _borrowerPhone; }
            set { _borrowerPhone = value; }
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
        /// LoanDate 
        /// </summary> 
        public DateTime LoanDate
        {
            get { return _loanDate; }
            set { _loanDate = value; }
        }

        /// <summary>
        /// Collateral 
        /// </summary> 
        public string Collateral
        {
            get { return _collateral; }
            set { _collateral = value; }
        }

        /// <summary>
        /// Guarantor 
        /// </summary> 
        public string Guarantor
        {
            get { return _guarantor; }
            set { _guarantor = value; }
        }

        /// <summary>
        /// GuarantorPhone 
        /// </summary> 
        public string GuarantorPhone
        {
            get { return _guarantorPhone; }
            set { _guarantorPhone = value; }
        }

        /// <summary>
        /// RateOfReturn 
        /// </summary> 
        public char RateOfReturn
        {
            get { return _rateOfReturn; }
            set { _rateOfReturn = value; }
        }

        /// <summary>
        /// DueDateForPay 
        /// </summary> 
        public DateTime DueDateForPay
        {
            get { return _dueDateForPay; }
            set { _dueDateForPay = value; }
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
        /// Status 
        /// </summary> 
        public char Status
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
        /// AccountingRemark 
        /// </summary> 
        public string AccountingRemark
        {
            get { return _accountingRemark; }
            set { _accountingRemark = value; }
        }

        /// <summary>
        /// DueDateForReceivables 
        /// </summary> 
        public int DueDateForReceivables
        {
            get { return _dueDateForReceivables; }
            set { _dueDateForReceivables = value; }
        }

        /// <summary>
        /// ReceivablesRemindInfo 
        /// </summary> 
        public string ReceivablesRemindInfo
        {
            get { return _receivablesRemindInfo; }
            set { _receivablesRemindInfo = value; }
        }

        #endregion
    }
}

