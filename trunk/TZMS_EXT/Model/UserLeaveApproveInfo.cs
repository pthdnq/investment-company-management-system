//----------------------------------------------------------------------------------------------------
//程序名:	UserLeaveApprove实体类
//功能:   定义了与 dbo.UserLeaveApprove 表 对应的数据实体类
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
    /// UserLeaveApprove实体类
    /// </summary>
    [Serializable]
    public class UserLeaveApproveInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserLeaveApproveInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _approverId;
        private string _approverName = DBEmptyString;
        private string _approverDept = DBEmptyString;
        private bool _isApprove;
        private short _approveResult = -1;
        private string _approverSugest = DBEmptyString;
        private Guid _applyId;
        private DateTime _approveTime = DBMAXDate;
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
        /// ApproverID 
        /// </summary> 
        public Guid ApproverID
        {
            get { return _approverId; }
            set { _approverId = value; }
        }

        /// <summary>
        /// ApproverName 
        /// </summary> 
        public string ApproverName
        {
            get { return _approverName; }
            set { _approverName = value; }
        }

        /// <summary>
        /// ApproverDept 
        /// </summary> 
        public string ApproverDept
        {
            get { return _approverDept; }
            set { _approverDept = value; }
        }

        /// <summary>
        /// IsApprove 
        /// </summary> 
        public bool IsApprove
        {
            get { return _isApprove; }
            set { _isApprove = value; }
        }

        /// <summary>
        /// ApproveResult 
        /// </summary> 
        public short ApproveResult
        {
            get { return _approveResult; }
            set { _approveResult = value; }
        }

        /// <summary>
        /// ApproverSugest 
        /// </summary> 
        public string ApproverSugest
        {
            get { return _approverSugest; }
            set { _approverSugest = value; }
        }

        /// <summary>
        /// ApplyID 
        /// </summary> 
        public Guid ApplyID
        {
            get { return _applyId; }
            set { _applyId = value; }
        }

        /// <summary>
        /// ApproveTime 
        /// </summary> 
        public DateTime ApproveTime
        {
            get { return _approveTime; }
            set { _approveTime = value; }
        }

        #endregion
    }
}


