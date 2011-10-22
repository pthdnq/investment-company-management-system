//----------------------------------------------------------------------------------------------------
//程序名:	UserInfo实体类
//功能:   定义了与 dbo.UserInfo 表 对应的数据实体类
//作者:  	shunlian
//时间:	2011-10-16 
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
    /// UserInfo实体类
    /// </summary>
    [Serializable]
    public class UserInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserInfo()
        {
            //todo          
            _birthday = DateTime.Parse("1900-1-1 12:00");
            _entryDate = DateTime.Parse("1900-1-1 12:00");
        }
        #endregion

        #region Field
        private Guid _objectId;
        private string _accountNo = string.Empty;
        private string _jobNo = string.Empty;
        private string _name = string.Empty;
        private bool _sex = true;
        private string _dept =  string.Empty;
        private DateTime _birthday;
        private string _phoneNumber =  string.Empty;
        private string _address =  string.Empty;
        private DateTime _entryDate;
        private string _position = string.Empty;
        private short _state = 1;
        private string _backIpPhoneNumber = string.Empty;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _educational = string.Empty;
        private short _workYear = 0;
        private string _graduatedSchool = string.Empty;
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
        /// AccountNo 
        /// </summary> 
        public string AccountNo
        {
            get { return _accountNo; }
            set { _accountNo = value; }
        }

        /// <summary>
        /// JobNo 
        /// </summary> 
        public string JobNo
        {
            get { return _jobNo; }
            set { _jobNo = value; }
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
        /// Sex 
        /// </summary> 
        public bool Sex
        {
            get { return _sex; }
            set { _sex = value; }
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
        /// Birthday 
        /// </summary> 
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        /// <summary>
        /// PhoneNumber 
        /// </summary> 
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        /// <summary>
        /// Address 
        /// </summary> 
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// EntryDate 
        /// </summary> 
        public DateTime EntryDate
        {
            get { return _entryDate; }
            set { _entryDate = value; }
        }

        /// <summary>
        /// Position 
        /// </summary> 
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }

        /// <summary>
        /// state 
        /// </summary> 
        public short State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// BackIpPhoneNumber 
        /// </summary> 
        public string BackIpPhoneNumber
        {
            get { return _backIpPhoneNumber; }
            set { _backIpPhoneNumber = value; }
        }

        /// <summary>
        /// Email 
        /// </summary> 
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// Password 
        /// </summary> 
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// Educational
        /// </summary>
        public string Educational
        {
            get { return _educational; }
            set { _educational = value; }
        }
        /// <summary>
        /// WorkYear
        /// </summary>
        public short WorkYear
        {
            get { return _workYear; }
            set { _workYear = value; }
        }
        /// <summary>
        /// GraduatedSchool
        /// </summary>
        public string GraduatedSchool
        {
            get { return _graduatedSchool; }
            set { _graduatedSchool = value; }
        }

        #endregion
    }
}


