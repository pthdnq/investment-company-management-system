//----------------------------------------------------------------------------------------------------
//程序名:	InvestmentProject实体类
//功能:   定义了与 dbo.InvestmentProject 表 对应的数据实体类
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
    /// InvestmentProject实体类
    /// </summary>
    [Serializable]
    public class InvestmentProjectInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public InvestmentProjectInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objetctId;
        private string _customerName = DBEmptyString;
        private Guid _customerId;
        private string _projectName = DBEmptyString;
        private string _projectOverview = DBEmptyString;
        private DateTime _signDate = DBEmptyDate;
        private string _contact = DBEmptyString;
        private string _contactPhone = DBEmptyString;
        private Decimal _contractAmount = DBEmptyDecimal;
        private Decimal _downPayment = DBEmptyDecimal;
        private string _remark = DBEmptyString;
        private int _status = DBEmptyChar;
        private Guid _nextOperaterId;
        private string _nextOperaterAccount = DBEmptyString;
        private string _nextOperaterName = DBEmptyString;
        private DateTime _createTime = DBEmptyDate;
        private Guid _createrId;
        private string _createrName = DBEmptyString;
        private string _createrAccount = DBEmptyString;
        private DateTime _submitTime = DBEmptyDate;
        private string _auditOpinion = DBEmptyString;
        private Guid _nextBAOperaterId;
        private string _nextBAOperaterAccount = DBEmptyString;
        private string _nextBAOperaterName = DBEmptyString;
        private DateTime _submitBATime = DBEmptyDate;
        private string _adulters = DBEmptyString;
        private string _baadulters = DBEmptyString;
        private int _bastatus = DBEmptyInt;
  
        #endregion

        #region Property
        /// <summary>
        /// ObjectID 
        /// </summary> 
        public Guid ObjectId
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
        /// SignDate 
        /// </summary> 
        public DateTime SignDate
        {
            get { return _signDate; }
            set { _signDate = value; }
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
        /// ContactPhone 
        /// </summary> 
        public string ContactPhone
        {
            get { return _contactPhone; }
            set { _contactPhone = value; }
        }

        /// <summary>
        /// ContractAmount 
        /// </summary> 
        public Decimal ContractAmount
        {
            get { return GetDecimal(_contractAmount); }
            set { _contractAmount = value; }
        }

        /// <summary>
        /// DownPayment 
        /// </summary> 
        public Decimal DownPayment
        {
            get { return GetDecimal(_downPayment); }
            set { _downPayment = value; }
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
        /// NextBAOperaterID 
        /// </summary> 
        public Guid NextBAOperaterId
        {
            get { return _nextBAOperaterId; }
            set { _nextBAOperaterId = value; }
        }

        /// <summary>
        /// NextBAOperaterAccount 
        /// </summary> 
        public string NextBAOperaterAccount
        {
            get { return _nextBAOperaterAccount; }
            set { _nextBAOperaterAccount = value; }
        }

        /// <summary>
        /// NextBAOperaterName 
        /// </summary> 
        public string NextBAOperaterName
        {
            get { return _nextBAOperaterName; }
            set { _nextBAOperaterName = value; }
        }

        /// <summary>
        /// SubmitBATime 
        /// </summary> 
        public DateTime SubmitBATime
        {
            get { return _submitBATime; }
            set { _submitBATime = value; }
        }

        /// <summary>
        /// Adulters 
        /// </summary> 
        public string Adulters
        {
            get { return _adulters; }
            set { _adulters = value; }
        }

        /// <summary>
        /// BAAdulters 
        /// </summary> 
        public string BAAdulters
        {
            get { return _baadulters; }
            set { _baadulters = value; }
        }

        /// <summary>
        /// BAStatus 
        /// </summary> 
        public int BAStatus
        {
            get { return _bastatus; }
            set { _bastatus = value; }
        } 
     
        #endregion
    }
}


