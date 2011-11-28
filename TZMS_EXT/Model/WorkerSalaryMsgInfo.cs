//----------------------------------------------------------------------------------------------------
//程序名:	WorkerSalaryMsg实体类
//功能:   定义了与 dbo.WorkerSalaryMsg 表 对应的数据实体类
//作者:  	omit
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
    /// WorkerSalaryMsg实体类
    /// </summary>
    [Serializable]
    public class WorkerSalaryMsgInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkerSalaryMsgInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _userId;
        private string _name = DBEmptyString;
        private string _dept = DBEmptyString;
        private Decimal _baseSalary = DBEmptyDecimal;
        private Decimal _examSalary = DBEmptyDecimal;
        private Decimal _backSalary = DBEmptyDecimal;
        private Decimal _otherSalary = DBEmptyDecimal;
        private Decimal _shouldSalary = DBEmptyDecimal;
        private Decimal _salary = DBEmptyDecimal;
        private string _context = DBEmptyString;
        private Guid _salaryMsgId;
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
        /// UserID 
        /// </summary> 
        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        /// <summary>
        /// Name 
        /// </summary> 
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Dept 
        /// </summary> 
        public string Dept
        {
            get { return _dept; }
            set { _dept = value; }
        }

        /// <summary>
        /// BaseSalary 
        /// </summary> 
        public Decimal BaseSalary
        {
            get { return _baseSalary; }
            set { _baseSalary = value; }
        }

        /// <summary>
        /// ExamSalary 
        /// </summary> 
        public Decimal ExamSalary
        {
            get { return _examSalary; }
            set { _examSalary = value; }
        }

        /// <summary>
        /// BackSalary 
        /// </summary> 
        public Decimal BackSalary
        {
            get { return _backSalary; }
            set { _backSalary = value; }
        }

        /// <summary>
        /// OtherSalary 
        /// </summary> 
        public Decimal OtherSalary
        {
            get { return _otherSalary; }
            set { _otherSalary = value; }
        }

        /// <summary>
        /// ShouldSalary 
        /// </summary> 
        public Decimal ShouldSalary
        {
            get { return _shouldSalary; }
            set { _shouldSalary = value; }
        }

        /// <summary>
        /// Salary 
        /// </summary> 
        public Decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        /// <summary>
        /// Context 
        /// </summary> 
        public string Context
        {
            get { return _context; }
            set { _context = value; }
        }

        /// <summary>
        /// SalaryMsgID 
        /// </summary> 
        public Guid SalaryMsgId
        {
            get { return _salaryMsgId; }
            set { _salaryMsgId = value; }
        }

        #endregion
    }
}


