using System;
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
                Alert.Show("请导入Excel文件!");
                return;
            }

            string strFileExt = Path.GetExtension(uploadExcel.FileName);
            if (strFileExt != ".xls" && strFileExt != ".xlsx")
            {
                Alert.Show("只能导入后缀为xls或xlsx的文件!");
                return;
            }

            try
            {
                // 导入数据.
                WorkerAttendManage _manage = new WorkerAttendManage();
                _manage.ImportAttendInfo(_manage.GetExcelData(uploadExcel.PostedFile.FileName));

                Alert.Show("导入成功!");
            }
            catch (Exception ex)
            {
                Alert.Show("导入失败: " + ex.Message);
            }

        }
    }
}