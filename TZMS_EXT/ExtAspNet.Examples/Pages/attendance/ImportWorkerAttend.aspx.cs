﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Collections;
using System.Data.OleDb;
using System.Data;
using com.TZMS.Business;
using System.IO;

namespace TZMS.Web
{
    public partial class ImportWorkerAttend : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 导入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnImport_Click(object sender, EventArgs e)
        {
            if (uploadExcel.HasFile == false)
            {
                Alert.Show("请选择Excel文件!");
                return;
            }

            string strFileExt = Path.GetExtension(uploadExcel.FileName);
            if (strFileExt != ".xls" && strFileExt != ".xlsx")
            {
                Alert.Show("只能导入后缀为xls或xlsx的文件!");
                return;
            }
            // 保存文件.
            string randomFilePath = Server.MapPath("..\\..\\Temp\\" + Guid.NewGuid().ToString() + strFileExt);
            uploadExcel.PostedFile.SaveAs(randomFilePath);
            try
            {
                // 导入数据.
                WorkerAttendManage _manage = new WorkerAttendManage();
                _manage.ImportAttendInfo(_manage.GetExcelData(randomFilePath));

                Alert.Show("导入成功!");

            }
            catch (Exception)
            {
                Alert.Show("导入失败: 请检查Excel格式!");
            }
            finally
            {
                File.Delete(randomFilePath);
            }

        }
    }
}