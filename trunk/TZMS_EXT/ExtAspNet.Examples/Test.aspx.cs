using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.iFlytek.OA.MUDCommon;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class Test : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("http://enroll.sse.ustc.edu.cn/rili/Default.aspx");
            //MUDFilesCtrl fileCtrl = new MUDFilesCtrl();
            //fileCtrl.AcceptFiles(string.Empty, "测试", "123", "12345");
            //this.BindAttachsRecordInfo(true);
            //隐藏按钮
            //this.MUDAttachment.ShowAddBtn = "true";
            //this.MUDAttachment.ShowDelBtn = "true";
            //系统名称和属性
            //this.MUDAttachment.SystemName = "测试";
            //this.MUDAttachment.AttributeName = "属性";
            ////这个表单的唯一ID 即可（支持多附件）
            //this.MUDAttachment.RecordID = "12345";

            //MUDFilesCtrl fileCtrl1 = new MUDFilesCtrl();
            //fileCtrl1.ResetFiles(string.Empty, "测试", "123", "属性");
            //Decimal temp = 198.00M;
            //Decimal hh = GetDecimal(temp);
            //Response.Write(hh.ToString());
            // 账号.

            for (int i = 0; i < 900000; i++)
            {
                UserInfo _userInfo = null;
                UserManage _userManage = new UserManage();
                _userInfo = new UserInfo();
                //默认密码：1111
                _userInfo.Password = "1111";
                // 用户ID.
                _userInfo.ObjectId = Guid.NewGuid();
                _userInfo.AccountNo = "1290";
                // 工号. 
                _userInfo.JobNo = "工号";
                _userInfo.Menu = "RJM%KKKKFF7FG&gghjkkk哈哈kkkjjjdfskfdsknmskjda&djlksaflkdsfk&fjsklfksadlf&哈哈哈哈哈";

                // 姓名.        
                _userInfo.Name = "Name";
                // 性别.          
                _userInfo.Sex = true;
                // 部门.
                _userInfo.Dept = "测试中心";
                // 职位.
                _userInfo.Position = "管理员";
                // 入职时间.
                _userInfo.EntryDate = DateTime.Now;
                // 基本工资.
                _userInfo.BaseSalary = decimal.Parse("1989.09");

                // 出生日期.
                _userInfo.Birthday = DateTime.Now; ;
                // 学历.
                _userInfo.Educational = "博士";
                _userInfo.WorkYear = 101;
                // 员工状态.
                _userInfo.State = 1;
                // 转正状态.
                _userInfo.IsProbation = false;
                // 转正时间.
                _userInfo.ProbationTime = DateTime.Now;

                // 离职时间.
                _userInfo.LeaveTime = DateTime.Now;

                // 毕业院校.
                _userInfo.GraduatedSchool = "科技大学";
                // 联系电话.
                _userInfo.PhoneNumber = "178218987921";
                // 备用联系电话.
                _userInfo.BackIpPhoneNumber = "2345678967"; ;
                // 电子邮箱.
                _userInfo.Email = "ddjaskl@67.com";
                // 住址.
                _userInfo.Address = "fdhoijsafjksa";

                _userManage.AddUser(_userInfo);
            }
        }

        public Decimal GetDecimal(Decimal temp)
        {
            string strTemp = temp.ToString();
            string[] strs = strTemp.Split('.');
            if (strs.Length > 1)
            {
                string str = strs[1];
                if (str.Contains("00"))
                    return Decimal.Parse(strs[0]);
                if (strTemp.Contains(".0"))
                {
                    return temp;
                }
                if (str.Contains("0"))
                {
                    string ss = strTemp.Substring(0, strTemp.Length - 1);
                    return Decimal.Parse(ss);
                }
            }
            return temp;
        }
    }
}