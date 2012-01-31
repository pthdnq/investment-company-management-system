//----------------------------------------------------------------------------------------------------
//???:	MaterialsPurchaseApply???
//??:   ???? dbo.MaterialsPurchaseApply ? ????????
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
    /// MaterialsPurchaseApply???
    /// </summary>
    [Serializable]
    public class MaterialsPurchaseApplyInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsPurchaseApplyInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _userId;
        private string _userName = DBEmptyString;
        private string _userJobNo = DBEmptyString;
        private string _userAccountNo = DBEmptyString;
        private string _userDept = DBEmptyString;
        private Guid _materialsId;
        private DateTime _applyTime = DBMAXDate;
        private int _count;
        private Decimal _money;
        private string _sument = DBEmptyString;
        private string _other = DBEmptyString;
        private short _state = -1;
        private Guid _approverId;
        private bool _isDelete = false;
        private DateTime _needsDate = DBMAXDate;
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
        /// UserJobNo 
        /// </summary> 
        public string UserJobNo
        {
            get { return _userJobNo; }
            set { _userJobNo = value; }
        }

        /// <summary>
        /// UserAccountNo 
        /// </summary> 
        public string UserAccountNo
        {
            get { return _userAccountNo; }
            set { _userAccountNo = value; }
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
        /// MaterialsID 
        /// </summary> 
        public Guid MaterialsID
        {
            get { return _materialsId; }
            set { _materialsId = value; }
        }

        /// <summary>
        /// ApplyTime 
        /// </summary> 
        public DateTime ApplyTime
        {
            get { return _applyTime; }
            set { _applyTime = value; }
        }

        /// <summary>
        /// Count 
        /// </summary> 
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        /// <summary>
        /// Money 
        /// </summary> 
        public Decimal Money
        {
            get { return _money; }
            set { _money = value; }
        }

        /// <summary>
        /// Sument 
        /// </summary> 
        public string Sument
        {
            get { return _sument; }
            set { _sument = value; }
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
        /// State 
        /// </summary> 
        public short State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// ApproverID 
        /// </summary> 
        public Guid ApproverID
        {
            get { return _approverId; }
            set { _approverId = value; }
        }

        /// <summary>
        /// IsDelete 
        /// </summary> 
        public bool IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }

        /// <summary>
        /// IsDelete 
        /// </summary> 
        public DateTime NeedsDate
        {
            get { return _needsDate; }
            set { _needsDate = value; }
        }

        #endregion
    }
}


