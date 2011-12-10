//----------------------------------------------------------------------------------------------------
//程序名:	Receivables实体类
//功能:   定义了与 dbo.Receivables 表 对应的数据实体类
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
    /// Receivables实体类
    /// </summary>
    [Serializable]
    public class ReceivablesInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ReceivablesInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objetctId;
        private Guid _forId;
        private string _projectName = DBEmptyString;
        private DateTime _dueDateForReceivables;
        private DateTime _dateForReceivables;
        private Decimal _amountofpaidUp;
        private string _receivablesAccount = DBEmptyString;
        private string _remark = DBEmptyString;
        private bool _isAccountingAudit;
        private string _auditOpinion = DBEmptyString;
        private string _accountingName = DBEmptyString;
        private string _accountingAccount = DBEmptyString;
        private Guid _createrId;
        private string _createrName = DBEmptyString;
        private DateTime _createTime = DBEmptyDate;
        private int _status = DBEmptyChar;
        #endregion

        #region Property
        /// <summary>
        /// ObjetctID 
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
        /// DueDateForReceivables 
        /// </summary> 
        public DateTime DueDateForReceivables
        {
            get { return _dueDateForReceivables; }
            set { _dueDateForReceivables = value; }
        }

        /// <summary>
        /// DateForReceivables 
        /// </summary> 
        public DateTime DateForReceivables
        {
            get { return _dateForReceivables; }
            set { _dateForReceivables = value; }
        }

        /// <summary>
        /// AmountOfPaid_Up 
        /// </summary> 
        public Decimal AmountofpaidUp
        {
            get { return _amountofpaidUp; }
            set { _amountofpaidUp = value; }
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
        /// IsAccountingAudit 
        /// </summary> 
        public bool IsAccountingAudit
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

        #endregion
    }
}


