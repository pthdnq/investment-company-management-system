//----------------------------------------------------------------------------------------------------
//程序名:	JingShengApprove实体类
//功能:   定义了与 dbo.JiangCheng 表 对应的数据实体类
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
    /// JingShengApprove实体类
    /// </summary>
    [Serializable]
    public class JiangChengInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public JiangChengInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _createUserId;
        private string _createName = DBEmptyString;
        private DateTime _createTime = DBMAXDate;
        private short _type = DBEmptyShort;
        private string _reason = DBEmptyString;
        private Guid _userId;
        private string _userName = DBEmptyString;
        private string _userDept = DBEmptyString;
        private Guid _zjid;
        private string _zJName = DBEmptyString;
        private short _state = DBEmptyShort;
        private DateTime _userConfirmTime = DBMAXDate;
        private DateTime _confirmTime = DBMAXDate;
        private short _confirmType = 0;
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
        /// CreateUserID 
        /// </summary> 
        public Guid CreateUserID
        {
            get { return _createUserId; }
            set { _createUserId = value; }
        }

        /// <summary>
        /// CreateName 
        /// </summary> 
        public string CreateName
        {
            get { return _createName; }
            set { _createName = value; }
        }

        /// <summary>
        /// CreateTime 
        /// </summary> 
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        /// <summary>
        /// Type 
        /// </summary> 
        public short Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Reason 
        /// </summary> 
        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
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
        /// ZJID 
        /// </summary> 
        public Guid ZjID
        {
            get { return _zjid; }
            set { _zjid = value; }
        }

        /// <summary>
        /// ZJName 
        /// </summary> 
        public string ZJName
        {
            get { return _zJName; }
            set { _zJName = value; }
        }

        /// <summary>
        /// State 
        /// </summary> 
        public short State
        {
            get { return _state; }
            set { _state = value; }
        }

        public DateTime UserConfirmTime
        {
            get { return _userConfirmTime; }
            set { _userConfirmTime = value; }
        }

        public DateTime ConfirmTime
        {
            get { return _confirmTime; }
            set { _confirmTime = value; }
        }

        public short ConfirmType
        {
            get { return _confirmType; }
            set { _confirmType = value; }
        }

        #endregion
    }
}


