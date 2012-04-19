//----------------------------------------------------------------------------------------------------
//程序名:	ProjectProcess实体类
//功能:   定义了与 dbo.ProjectProcess 表 对应的数据实体类
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
    /// ProjectProcess实体类
    /// </summary>
    [Serializable]
    public class ProjectProcessInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectProcessInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objetctId;
        private Guid _forId;
        private string _projectName = DBEmptyString;
        private bool _needImprest;
        private string _implementationPhase = DBEmptyString;
        private Decimal _amountExpended = DBEmptyDecimal;
        private string _expendedTime = DBEmptyString;
        private Decimal _imprestAmount = DBEmptyDecimal;
        private string _remark = DBEmptyString;
        private Decimal _prepaidAmount = DBEmptyDecimal;
        private string _use = DBEmptyString;
        private string _imprestRemark = DBEmptyString;
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
        private string _accountingRemark = DBEmptyString;
        private string _adulters = DBEmptyString;
        private bool _isPassImprest;
        private Guid _firstOperaterID;
        private string _firstOperaterName = DBEmptyString;

        private string _amountExpendedFlag = DBEmptyString;

        public string AmountExpendedFlag
        {
            get { return _amountExpendedFlag; }
            set { _amountExpendedFlag = value; }
        }
        private string _imprestAmountFlag = DBEmptyString;

        public string ImprestAmountFlag
        {
            get { return _imprestAmountFlag; }
            set { _imprestAmountFlag = value; }
        }
        private string _prepaidAmountFlag = DBEmptyString;

        public string PrepaidAmountFlag
        {
            get { return _prepaidAmountFlag; }
            set { _prepaidAmountFlag = value; }
        }
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
        public bool NeedImprest
        {
            get { return _needImprest; }
            set { _needImprest = value; }
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
        /// AmountExpended 
        /// </summary> 
        public Decimal AmountExpended
        {
            get { return GetDecimal(_amountExpended); }
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
        /// ImprestAmount 
        /// </summary> 
        public Decimal ImprestAmount
        {
            get { return GetDecimal(_imprestAmount); }
            set { _imprestAmount = value; }
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
        /// PrepaidAmount 
        /// </summary> 
        public Decimal PrepaidAmount
        {
            get { return GetDecimal(_prepaidAmount); }
            set { _prepaidAmount = value; }
        }

        /// <summary>
        /// Use 
        /// </summary> 
        public string Use
        {
            get { return _use; }
            set { _use = value; }
        }

        /// <summary>
        /// ImprestRemark 
        /// </summary> 
        public string ImprestRemark
        {
            get { return _imprestRemark; }
            set { _imprestRemark = value; }
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

         /// <summary>
        /// Adulters 
        /// </summary> 
        public string  Adulters
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


