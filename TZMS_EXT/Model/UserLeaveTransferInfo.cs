//----------------------------------------------------------------------------------------------------
//程序名:	UserLeaveTransfer实体类
//功能:   定义了与 dbo.UserLeaveTransfer 表 对应的数据实体类
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
    /// UserLeaveTransfer实体类
    /// </summary>
    [Serializable]
    public class UserLeaveTransferInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserLeaveTransferInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _transferId;
        private string _transferName = DBEmptyString;
        private string _transferDept = DBEmptyString;
        private bool _isTransfer;
        private DateTime _transferTime = DBMAXDate;
        private short _transferType = -1;
        private string _other = DBEmptyString;
        private Guid _applyId;
        private short _transferState = -1;
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
        /// TransferID 
        /// </summary> 
        public Guid TransferID
        {
            get { return _transferId; }
            set { _transferId = value; }
        }

        /// <summary>
        /// TransferName 
        /// </summary> 
        public string TransferName
        {
            get { return _transferName; }
            set { _transferName = value; }
        }

        /// <summary>
        /// TransferDept 
        /// </summary> 
        public string TransferDept
        {
            get { return _transferDept; }
            set { _transferDept = value; }
        }

        /// <summary>
        /// IsTransfer 
        /// </summary> 
        public bool IsTransfer
        {
            get { return _isTransfer; }
            set { _isTransfer = value; }
        }

        /// <summary>
        /// TransferTime 
        /// </summary> 
        public DateTime TransferTime
        {
            get { return _transferTime; }
            set { _transferTime = value; }
        }

        /// <summary>
        /// TransferType 
        /// </summary> 
        public short TransferType
        {
            get { return _transferType; }
            set { _transferType = value; }
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
        /// ApplyID 
        /// </summary> 
        public Guid ApplyID
        {
            get { return _applyId; }
            set { _applyId = value; }
        }

        /// <summary>
        /// TransferType 
        /// </summary> 
        public short TransferState
        {
            get { return _transferState; }
            set { _transferState = value; }
        }

        #endregion
    }
}


