//----------------------------------------------------------------------------------------------------
//程序名:	ProxyAccountingUnit实体类
//功能:   定义了与 dbo.ProxyAccountingUnit 表 对应的数据实体类
//作者:  	xiguazerg
//时间:	2009-10-16 
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
    /// ProxyAccountingUnit实体类
    /// </summary>
    [Serializable]
    public class ProxyAccountingUnitInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ProxyAccountingUnitInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectID;
        private string _unitName = DBEmptyString;
        private string _unitAddress = DBEmptyString;
        private Guid _accountancyID;
        private string _accountancyName = DBEmptyString;
        private string _other = DBEmptyString;
        private bool _isDelete;
        #endregion

        #region Property
        /// <summary>
        /// ObjectID 
        /// </summary> 
        public Guid ObjectID
        {
            get { return _objectID; }
            set { _objectID = value; }
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
        /// AccountancyID 
        /// </summary> 
        public Guid AccountancyID
        {
            get { return _accountancyID; }
            set { _accountancyID = value; }
        }

        /// <summary>
        /// AccountancyName 
        /// </summary> 
        public string AccountancyName
        {
            get { return _accountancyName; }
            set { _accountancyName = value; }
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


