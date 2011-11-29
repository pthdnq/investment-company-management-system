using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class YewuManage : ParentManage
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public YewuManage()
        {

        }

        /// <summary>
        /// 添加一条新业务记录（业务单和流程）
        /// </summary>
        /// <param name="yewu"></param>
        /// <param name="yewuDoing"></param>
        /// <param name="boName"></param>
        public void AddYeWu(YeWuInfo yewu, YeWuGudingDoingInfo yewuDoing, string boName = BoName)
        {
            YeWuCtrl yewuCtrl = new YeWuCtrl();
            YeWuGudingDoingCtrl yeWudongCtrl = new YeWuGudingDoingCtrl();
            yewuCtrl.Insert(boName, yewu);
            yeWudongCtrl.Insert(boName, yewuDoing);
        }

        /// <summary>
        /// 添加记录表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="boName"></param>
        public void AddRecord(List<YeWuGudingDoingInfo> list, string boName = BoName)
        {
            YeWuGudingDoingCtrl yeWudongCtrl = new YeWuGudingDoingCtrl();
            foreach (YeWuGudingDoingInfo info in list)
            {
                yeWudongCtrl.Insert(boName, info);
            }
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="boName"></param>
        /// <returns>List</returns>
        public List<YeWuInfo> GetYeWuForList(string condition, string boName = BoName)
        {
            List<YeWuInfo> list = new List<YeWuInfo>();

            YeWuCtrl yewuCtrl = new YeWuCtrl();
            list = yewuCtrl.SelectAsList(boName, condition);
            return list;
        }

    }
}
