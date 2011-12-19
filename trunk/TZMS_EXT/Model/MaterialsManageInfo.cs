//----------------------------------------------------------------------------------------------------
//程序名:	MaterialsManage实体类
//功能:   定义了与 dbo.MaterialsManage 表 对应的数据实体类
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
    /// MaterialsManage实体类
    /// </summary>
    [Serializable]
    public class MaterialsManageInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsManageInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private short _materialsType = DBEmptyShort;
        private string _materialsName = DBEmptyString;
        private int _numbers = 0;
        private int _currentNumbers = 0;
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
        /// MaterialsType 
        /// </summary> 
        public short MaterialsType
        {
            get { return _materialsType; }
            set { _materialsType = value; }
        }

        /// <summary>
        /// MaterialsName 
        /// </summary> 
        public string MaterialsName
        {
            get { return _materialsName; }
            set { _materialsName = value; }
        }

        /// <summary>
        /// Numbers 
        /// </summary> 
        public int Numbers
        {
            get { return _numbers; }
            set { _numbers = value; }
        }

        /// <summary>
        /// CurrentNumbers 
        /// </summary> 
        public int CurrentNumbers
        {
            get { return _currentNumbers; }
            set { _currentNumbers = value; }
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


