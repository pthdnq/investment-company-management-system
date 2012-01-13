//----------------------------------------------------------------------------------------------------
//???:	ProxyAmountUnit???
//??:   ???? dbo.ProxyAmountUnit ? ????????
//??:  	xiguazerg
//??:	2010-10-25 
//----------------------------------------------------------------------------------------------------
//????:
//??		         ???		     ????
//----------------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace com.TZMS.Model
{
    /// <summary>
    /// ProxyAmountUnit???
    /// </summary>
    [Serializable]
    public class ProxyAmountUnitInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ProxyAmountUnitInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private string _unitName = DBEmptyString;
        private string _unitAddress = DBEmptyString;
        private Guid _userId;
        private string _userName = DBEmptyString;
        private string _userDept = DBEmptyString;
        private string _sMDJNumber = DBEmptyString;
        private string _dSNumber = DBEmptyString;
        private string _fRSFZNumber = DBEmptyString;
        private string _kHHJAccountNo = DBEmptyString;
        private string _contactPhoneNumber = DBEmptyString;
        private string _gSManager = DBEmptyString;
        private string _dSManager = DBEmptyString;
        private string _other = DBEmptyString;
        private bool _isDelete = false;
        #endregion

        #region Property
        /// <summary>
        /// ObjectID 
        /// </summary> 
        public Guid ObjectID
        {
            get { return _objectId; }
            set { _objectId = value; }
        }

        /// <summary>
        /// UnitName 
        /// </summary> 
        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }

        /// <summary>
        /// UnitAddress 
        /// </summary> 
        public string UnitAddress
        {
            get { return _unitAddress; }
            set { _unitAddress = value; }
        }

        /// <summary>
        /// UserID 
        /// </summary> 
        public Guid UserID
        {
            get { return _userId; }
            set { _userId = value; }
        }

        /// <summary>
        /// UserName 
        /// </summary> 
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// UserDept 
        /// </summary> 
        public string UserDept
        {
            get { return _userDept; }
            set { _userDept = value; }
        }

        /// <summary>
        /// SMDJNumber 
        /// </summary> 
        public string SMDJNumber
        {
            get { return _sMDJNumber; }
            set { _sMDJNumber = value; }
        }

        /// <summary>
        /// DSNumber 
        /// </summary> 
        public string DSNumber
        {
            get { return _dSNumber; }
            set { _dSNumber = value; }
        }

        /// <summary>
        /// FRSFZNumber 
        /// </summary> 
        public string FRSFZNumber
        {
            get { return _fRSFZNumber; }
            set { _fRSFZNumber = value; }
        }

        /// <summary>
        /// KHHJAccountNo 
        /// </summary> 
        public string KHHJAccountNo
        {
            get { return _kHHJAccountNo; }
            set { _kHHJAccountNo = value; }
        }

        /// <summary>
        /// ContactPhoneNumber 
        /// </summary> 
        public string ContactPhoneNumber
        {
            get { return _contactPhoneNumber; }
            set { _contactPhoneNumber = value; }
        }

        /// <summary>
        /// GSManager 
        /// </summary> 
        public string GSManager
        {
            get { return _gSManager; }
            set { _gSManager = value; }
        }

        /// <summary>
        /// DSManager 
        /// </summary> 
        public string DSManager
        {
            get { return _dSManager; }
            set { _dSManager = value; }
        }

        /// <summary>
        /// Other 
        /// </summary> 
        public string Other
        {
            get { return _other; }
            set { _other = value; }
        }

        /// <summary>
        /// IsDelete 
        /// </summary> 
        public bool IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }

        #endregion
    }
}


