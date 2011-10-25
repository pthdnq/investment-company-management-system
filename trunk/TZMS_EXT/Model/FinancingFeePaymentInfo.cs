//----------------------------------------------------------------------------------------------------
//程序名:	FinancingFeePayment实体类
//功能:   定义了与 dbo.FinancingFeePayment 表 对应的数据实体类
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
    /// FinancingFeePayment实体类
    /// </summary>
    [Serializable]
    public class FinancingFeePaymentInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public FinancingFeePaymentInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objetctId;
        private Guid _forId;
        private DateTime _dueDateForPay = DBEmptyDate;
        private DateTime _dateForPay = DBEmptyDate;
        private Decimal _amountOfPayment = DBEmptyDecimal;
        private string _paymentAccount = DBEmptyString;
        private string _receivablesAccount = DBEmptyString;
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
        private string _accountingRemark = DBEmptyString;
        private char _status = DBEmptyChar;
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
        /// ForID 
        /// </summary> 
        public Guid ForId
        {
            get { return _forId; }
            set { _forId = value; }
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
        /// DateForPay 
        /// </summary> 
        public DateTime DateForPay
        {
            get { return _dateForPay; }
            set { _dateForPay = value; }
        }

        /// <summary>
        /// AmountOfPayment 
        /// </summary> 
        public Decimal AmountOfPayment
        {
            get { return _amountOfPayment; }
            set { _amountOfPayment = value; }
        }

        /// <summary>
        /// PaymentAccount 
        /// </summary> 
        public string PaymentAccount
        {
            get { return _paymentAccount; }
            set { _paymentAccount = value; }
        }

        /// <summary>
        /// ReceivablesAccount 
        /// </summary> 
        public string ReceivablesAccount
        {
            get { return _receivablesAccount; }
            set { _receivablesAccount = value; }
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
        /// AccountingRemark 
        /// </summary> 
        public string AccountingRemark
        {
            get { return _accountingRemark; }
            set { _accountingRemark = value; }
        }

        /// <summary>
        /// Status 
        /// </summary> 
        public char Status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion
    }
}


