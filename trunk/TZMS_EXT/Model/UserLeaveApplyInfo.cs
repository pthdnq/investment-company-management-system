//----------------------------------------------------------------------------------------------------
//程序名:	UserLeaveApply实体类
//功能:   定义了与 dbo.UserLeaveApply 表 对应的数据实体类
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
    /// UserLeaveApply实体类
    /// </summary>
    [Serializable]
    public class UserLeaveApplyInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserLeaveApplyInfo()
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
        private string _userPosition = DBEmptyString;
        private DateTime _contractStartDate = DBMAXDate;
        private DateTime _contractEndDate = DBMAXDate;
        private DateTime _leaveDate = DBMAXDate;
        private short _leaveType = -1;
        private string _leaveSeason = DBEmptyString;
        private short _state = -1;
        private Guid _approverId;
        private DateTime _applyTime = DBMAXDate;
        private Guid _transferId;
        private short _transferState = -1;
        private bool _isDelete;
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
        /// UserPosition 
        /// </summary> 
        public string UserPosition
        {
            get { return _userPosition; }
            set { _userPosition = value; }
        }

        /// <summary>
        /// ContractStartDate 
        /// </summary> 
        public DateTime ContractStartDate
        {
            get { return _contractStartDate; }
            set { _contractStartDate = value; }
        }

        /// <summary>
        /// ContractEndDate 
        /// </summary> 
        public DateTime ContractEndDate
        {
            get { return _contractEndDate; }
            set { _contractEndDate = value; }
        }

        /// <summary>
        /// LeaveDate 
        /// </summary> 
        public DateTime LeaveDate
        {
            get { return _leaveDate; }
            set { _leaveDate = value; }
        }

        /// <summary>
        /// LeaveType 
        /// </summary> 
        public short LeaveType
        {
            get { return _leaveType; }
            set { _leaveType = value; }
        }

        /// <summary>
        /// LeaveSeason 
        /// </summary> 
        public string LeaveSeason
        {
            get { return _leaveSeason; }
            set { _leaveSeason = value; }
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
        /// ApplyTime 
        /// </summary> 
        public DateTime ApplyTime
        {
            get { return _applyTime; }
            set { _applyTime = value; }
        }

        /// <summary>
        /// TransferID 
        /// </summary> 
        public Guid TransferID
        {
            get { return _transferId; }
            set { _transferId = value; }
        }

        /// <summary>
        /// TransferState 
        /// </summary> 
        public short TransferState
        {
            get { return _transferState; }
            set { _transferState = value; }
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


