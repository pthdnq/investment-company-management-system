//----------------------------------------------------------------------------------------------------
//程序名:	WorkerSalaryMsg实体类
//功能:   定义了与 dbo.WorkerSalaryMsg 表 对应的数据实体类
//作者:  	xiguazerg
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
        private Decimal _baseSalary;
        private Decimal _examSalary;
        private Decimal _backSalary;
        private Decimal _otherSalary;
        private Decimal _shouldSalary;
        private Decimal _salary;
        private string _context = DBEmptyString;
        private Guid _salaryMsgId;
        private string _jbgz = "0.00";
        private string _glgz = "0.00";
        private string _syqgz = "0.00";
        private string _nzj = "0.00";
        private string _jlgz = "0.00";
        private string _khgz = "0.00";
        private string _cb = "0.00";
        private string _jtbz = "0.00";
        private string _yfgz = "0.00";
        private string _cd = "0.00";
        private string _zt = "0.00";
        private string _kg = "0.00";
        private string _sj = "0.00";
        private string _bj = "0.00";
        private string _sb = "0.00";
        private string _fk = "0.00";
        private string _cf = "0.00";
        private string _bjf = "0.00";
        private string _lyf = "0.00";
        private string _sfgz = "0.00";
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

        /// <summary>
        /// 基本工资
        /// </summary> 
        public string Jbgz
        {
            get { return _jbgz; }
            set { _jbgz = value; }
        }

        /// <summary>
        /// 工龄工资
        /// </summary> 
        public string Glgz
        {
            get { return _glgz; }
            set { _glgz = value; }
        }

        /// <summary>
        /// 试用期补发工资
        /// </summary> 
        public string Syqgz
        {
            get { return _syqgz; }
            set { _syqgz = value; }
        }

        /// <summary>
        /// 年终奖 
        /// </summary> 
        public string Nzj
        {
            get { return _nzj; }
            set { _nzj = value; }
        }

        /// <summary>
        /// 奖励工资
        /// </summary> 
        public string Jlgz
        {
            get { return _jlgz; }
            set { _jlgz = value; }
        }

        /// <summary>
        /// 考核工资
        /// </summary> 
        public string Khgz
        {
            get { return _khgz; }
            set { _khgz = value; }
        }

        /// <summary>
        /// 餐补
        /// </summary> 
        public string Cb
        {
            get { return _cb; }
            set { _cb = value; }
        }

        /// <summary>
        /// 交通补助
        /// </summary> 
        public string Jtbz
        {
            get { return _jtbz; }
            set { _jtbz = value; }
        }

        /// <summary>
        /// 应发工资
        /// </summary> 
        public string Yfgz
        {
            get { return _yfgz; }
            set { _yfgz = value; }
        }

        /// <summary>
        /// 迟到
        /// </summary> 
        public string Cd
        {
            get { return _cd; }
            set { _cd = value; }
        }

        /// <summary>
        /// 早退
        /// </summary> 
        public string Zt
        {
            get { return _zt; }
            set { _zt = value; }
        }

        /// <summary>
        /// 旷工
        /// </summary> 
        public string Kg
        {
            get { return _kg; }
            set { _kg = value; }
        }

        /// <summary>
        /// 事假
        /// </summary> 
        public string Sj
        {
            get { return _sj; }
            set { _sj = value; }
        }

        /// <summary>
        /// 病假
        /// </summary> 
        public string Bj
        {
            get { return _bj; }
            set { _bj = value; }
        }

        /// <summary>
        /// 社保
        /// </summary> 
        public string Sb
        {
            get { return _sb; }
            set { _sb = value; }
        }

        /// <summary>
        /// 罚款
        /// </summary> 
        public string Fk
        {
            get { return _fk; }
            set { _fk = value; }
        }

        /// <summary>
        /// 餐费
        /// </summary> 
        public string Cf
        {
            get { return _cf; }
            set { _cf = value; }
        }

        /// <summary>
        /// 保洁费
        /// </summary> 
        public string Bjf
        {
            get { return _bjf; }
            set { _bjf = value; }
        }

        /// <summary>
        /// 旅游费
        /// </summary> 
        public string Lyf
        {
            get { return _lyf; }
            set { _lyf = value; }
        }

        /// <summary>
        /// 实发工资
        /// </summary> 
        public string Sfgz
        {
            get { return _sfgz; }
            set { _sfgz = value; }
        }

        #endregion
    }
}


