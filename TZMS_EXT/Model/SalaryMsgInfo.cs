//----------------------------------------------------------------------------------------------------
//程序名:	SalaryMsg实体类
//功能:   定义了与 dbo.SalaryMsg 表 对应的数据实体类
//作者:  	omit
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
    /// SalaryMsg实体类
    /// </summary>
    [Serializable]
    public class SalaryMsgInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public SalaryMsgInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private int _year = DBEmptyInt;
        private short _month = DBEmptyShort;
        private DateTime _createTime = DBEmptyDate;
        private Guid _createrId;
        private string _name = DBEmptyString;
        private short _state =DBEmptyShort;
        private Guid _currentCheckerId;
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
        /// Year 
        /// </summary> 
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        /// <summary>
        /// Month 
        /// </summary> 
        public short Month
        {
            get { return _month; }
            set { _month = value; }
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
        /// CreaterID 
        /// </summary> 
        public Guid CreaterId
        {
            get { return _createrId; }
            set { _createrId = value; }
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
        /// state 
        /// </summary> 
        public short State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// CurrentCheckerID 
        /// </summary> 
        public Guid CurrentCheckerId
        {
            get { return _currentCheckerId; }
            set { _currentCheckerId = value; }
        }

        #endregion
    }
}


