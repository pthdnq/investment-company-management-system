//----------------------------------------------------------------------------------------------------
//程序名:	BankLoanProjectProcess实体类
//功能:   定义了与 dbo.BankLoanProjectProcess 表 对应的数据实体类
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
    /// BankLoanProjectProcess实体类
    /// </summary>
    [Serializable]
    public class BankLoanProjectProcessInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public BankLoanProjectProcessInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objetctId;
        private Guid _forId;
        private string _projectName = DBEmptyString;
        private int _needImprest = DBEmptyInt;
        private string _loanBank = DBEmptyString;
        private string _guaranteeCompany = DBEmptyString;
        private string _implementationPhase = DBEmptyString;
        private Decimal _imprestAmount = DBEmptyDecimal;
        private Decimal _amountExpended = DBEmptyDecimal;
        private string _expendedTime = DBEmptyString;
        private Decimal _imprestAmountBalance = DBEmptyDecimal;
        private string _remark = DBEmptyString;
        private int _status = DBEmptyInt;
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
        private string _use = DBEmptyString;
        private string _imprestRemark = DBEmptyString;
        private string _adulters = DBEmptyString;
        private bool _isPassImprest;
        private Guid _firstOperaterID;
        private string _firstOperaterName = DBEmptyString;
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
        /// ForID 
        /// </summary> 
        public Guid ForId
        {
            get { return _forId; }
            set { _forId = value; }
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
        /// NeedImprest 
        /// </summary> 
        public int NeedImprest
        {
            get { return _needImprest; }
            set { _needImprest = value; }
        }

        /// <summary>
        /// LoanBank 
        /// </summary> 
        public string LoanBank
        {
            get { return _loanBank; }
            set { _loanBank = value; }
        }

        /// <summary>
        /// GuaranteeCompany 
        /// </summary> 
        public string GuaranteeCompany
        {
            get { return _guaranteeCompany; }
            set { _guaranteeCompany = value; }
        }

        /// <summary>
        /// ImplementationPhase 
        /// </summary> 
        public string ImplementationPhase
        {
            get { return _implementationPhase; }
            set { _implementationPhase = value; }
        }

        /// <summary>
        /// ImprestAmount 
        /// </summary> 
        public Decimal ImprestAmount
        {
            get { return _imprestAmount; }
            set { _imprestAmount = value; }
        }

        /// <summary>
        /// AmountExpended 
        /// </summary> 
        public Decimal AmountExpended
        {
            get { return _amountExpended; }
            set { _amountExpended = value; }
        }

        /// <summary>
        /// ExpendedTime 
        /// </summary> 
        public string ExpendedTime
        {
            get { return _expendedTime; }
            set { _expendedTime = value; }
        }

        /// <summary>
        /// ImprestAmountBalance 
        /// </summary> 
        public Decimal ImprestAmountBalance
        {
            get { return _imprestAmountBalance; }
            set { _imprestAmountBalance = value; }
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
        /// AccountingRemark 
        /// </summary> 
        public string AccountingRemark
        {
            get { return _accountingRemark; }
            set { _accountingRemark = value; }
        }

        public string Use
        {
            get { return _use; }
            set { _use = value; }
        }

        public string ImprestRemark
        {
            get { return _imprestRemark; }
            set { _imprestRemark = value; }
        }

        public string Adulters
        {
            get { return _adulters; }
            set { _adulters = value; }
        }

        public bool IsPassImprest
        {
            get { return _isPassImprest; }
            set { _isPassImprest = value; }
        }

        /// <summary>
        /// FirstOperaterID 
        /// </summary> 
        public Guid FirstOperaterID
        {
            get { return _firstOperaterID; }
            set { _firstOperaterID = value; }
        }

        /// <summary>
        /// FirstOperaterName 
        /// </summary> 
        public string FirstOperaterName
        {
            get { return _firstOperaterName; }
            set { _firstOperaterName = value; }
        }

        #endregion
    }
}


