//----------------------------------------------------------------------------------------------------
//程序名:	AddSalary实体类
//功能:   定义了与 dbo.AddSalary 表 对应的数据实体类
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
    /// AddSalary实体类
    /// </summary>
    [Serializable]
    public class AddSalaryInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public AddSalaryInfo()
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
        private Decimal _otherSalary = DBEmptyDecimal;
        private string _context = DBEmptyString;
        private Guid _currentCheckerId;
        private short _state;
        private DateTime _applyTime = DBMAXDate;
        string _baseSalaryFlag = DBEmptyString;
        string _examSalaryFlag = DBEmptyString;
        string _otherSalaryFlag = DBEmptyString;
    
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
            get
            {
                return GetDecimal(_baseSalary);
            }
            set { _baseSalary = value; }
        }

        /// <summary>
        /// ExamSalary 
        /// </summary> 
        public Decimal ExamSalary
        {
            get { return GetDecimal(_examSalary); }
            set { _examSalary = value; }
        }

        /// <summary>
        /// OtherSalary 
        /// </summary> 
        public Decimal OtherSalary
        {
            get { return GetDecimal(_otherSalary); }
            set { _otherSalary = value; }
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
        /// CurrentCheckerID 
        /// </summary> 
        public Guid CurrentCheckerId
        {
            get { return _currentCheckerId; }
            set { _currentCheckerId = value; }
        }

        public short State
        {
            get { return _state; }
            set { _state = value; }
        }

        public DateTime ApplyTime
        {
            get { return _applyTime; }
            set { _applyTime = value; }
        }

        public string BaseSalaryFlag
        {
            get { return _baseSalaryFlag; }
            set { _baseSalaryFlag = value; }
        }

        public string ExamSalaryFlag
        {
            get { return _examSalaryFlag; }
            set { _examSalaryFlag = value; }
        }


        public string OtherSalaryFlag
        {
            get { return _otherSalaryFlag; }
            set { _otherSalaryFlag = value; }
        }

        #endregion
    }
}


