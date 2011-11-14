//----------------------------------------------------------------------------------------------------
//程序名:	SentMessage实体类
//功能:   定义了与 dbo.SentMessage 表 对应的数据实体类
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
    /// SentMessage实体类
    /// </summary>
    [Serializable]
    public class SentMessageInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public SentMessageInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _senderId;
        private string _senderName = DBEmptyString;
        private string _deptName = DBEmptyString;
        private string _tile = DBEmptyString;
        private string _context = DBEmptyString;
        private string _recevicer = DBEmptyString;
        private DateTime _sendDate = DBEmptyDate;
        private bool _isDelete;
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
        /// SenderID 
        /// </summary> 
        public Guid SenderId
        {
            get { return _senderId; }
            set { _senderId = value; }
        }

        /// <summary>
        /// SenderName 
        /// </summary> 
        public string SenderName
        {
            get { return _senderName; }
            set { _senderName = value; }
        }

        /// <summary>
        /// DeptName 
        /// </summary> 
        public string DeptName
        {
            get { return _deptName; }
            set { _deptName = value; }
        }

        /// <summary>
        /// Tile 
        /// </summary> 
        public string Tile
        {
            get { return _tile; }
            set { _tile = value; }
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
        /// Recevicer 
        /// </summary> 
        public string Recevicer
        {
            get { return _recevicer; }
            set { _recevicer = value; }
        }

        /// <summary>
        /// SendDate 
        /// </summary> 
        public DateTime SendDate
        {
            get { return _sendDate; }
            set { _sendDate = value; }
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


