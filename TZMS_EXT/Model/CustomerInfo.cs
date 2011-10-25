//----------------------------------------------------------------------------------------------------
//程序名:	Customer实体类
//功能:   定义了与 dbo.Customer 表 对应的数据实体类
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
    /// Customer实体类
    /// </summary>
    [Serializable]
    public class CustomerInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomerInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objetctId;
        private string _name = DBEmptyString;
        private bool _sex;
        private DateTime _birthday = DBEmptyDate;
        private string _cardId = DBEmptyString;
        private string _address = DBEmptyString;
        private string _officePhone = DBEmptyString;
        private string _mobilePhone = DBEmptyString;
        private string _email = DBEmptyString;
        private int _creditScore  =DBEmptyInt;
        private string _company = DBEmptyString;
        private string _position = DBEmptyString;
        private string _homeAddress = DBEmptyString;
        private string _homePhone = DBEmptyString;
        private string _remark = DBEmptyString;
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
        /// Birthday 
        /// </summary> 
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        /// <summary>
        /// CardID 
        /// </summary> 
        public string CardId
        {
            get { return _cardId; }
            set { _cardId = value; }
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
        /// OfficePhone 
        /// </summary> 
        public string OfficePhone
        {
            get { return _officePhone; }
            set { _officePhone = value; }
        }

        /// <summary>
        /// MobilePhone 
        /// </summary> 
        public string MobilePhone
        {
            get { return _mobilePhone; }
            set { _mobilePhone = value; }
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
        /// CreditScore 
        /// </summary> 
        public int CreditScore
        {
            get { return _creditScore; }
            set { _creditScore = value; }
        }

        /// <summary>
        /// Company 
        /// </summary> 
        public string Company
        {
            get { return _company; }
            set { _company = value; }
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
        /// HomeAddress 
        /// </summary> 
        public string HomeAddress
        {
            get { return _homeAddress; }
            set { _homeAddress = value; }
        }

        /// <summary>
        /// HomePhone 
        /// </summary> 
        public string HomePhone
        {
            get { return _homePhone; }
            set { _homePhone = value; }
        }

        /// <summary>
        /// Remark 
        /// </summary> 
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        #endregion
    }
}


