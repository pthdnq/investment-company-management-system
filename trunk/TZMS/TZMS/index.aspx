<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TZMS.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>原型界面</title>
    <script type="text/javascript" src="resources/jart/jart.js"></script>
    <script type="text/javascript">
        //字符串替换
        function ReplaceAll(str, sptr, sptr1) {
            while (str.indexOf(sptr) >= 0) {
                str = str.replace(sptr, sptr1);
            }
            return str;
        }
        $(function () {
            //ajax加载初始化信息
            $.ajax({ url: window.location.href + "?op=initData" })
            .success(function (data) {
                if ('' == data) {
                    window.navigate("Login.aspx");
                }
                else {
                    //$('#mainPanel').val("sa");
                    //                    var test = document.getElementById('mainPanel').innerHTML;
                    //                    test = ReplaceAll(test, '李@德!虎', data);
                    //                    document.getElementById('mainPanel').innerHTML = test;
                }
            })
            .error(function () {
                window.navigate("Login.aspx");
            })
            .complete(function () { ; });
        });
    </script>
</head>
<body style="margin: 0px; background-color: #eee;">
    <form id="form1" runat="server">
    <div art="layout" filly="true">
        <div region="north" collapsable="true">
            <div style="background-repeat: repeat-x; background-image: url('images/top_bg.jpg');
                font-size: 22px; font-weight: bold; padding: 5px 10px;">
                <table style="width: 100%; height: 60px;">
                    <tr>
                        <td style="text-align: left;">
                        </td>
                        <td style="text-align: right;">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div region="west" resizable="true" size="180" collapsable="true">
            <div art="panel" title="李德虎，您好！" filly="{hidden:true}" style="background-color: #ffe;">
                <div filly="{hidden:true}" art="navbar" exclude="true" align="center" borders="0">
                    <div text="系统管理" iconurl="images/search.png">
                        <div text="我的首页" url="Pages/system/MyWeb.aspx" target="fm">
                        </div>
                        <div text="我的信息" url="Pages/system/myMessage.aspx" target="fm">
                        </div>
                        <div text="修改密码" url="Pages/system/changePsw.aspx" target="fm">
                        </div>
                    </div>
                    <div text="行政管理" iconurl="images/search.png">
                        <div text="员工管理" url="Pages/adminManage/WorkerManage.aspx" target="fm">
                        </div>
                        <div text="人事申请" url="ReleaseHistory.htm" target="fm">
                        </div>
                        <div text="入职管理" url="ReleaseHistory.htm" target="fm">
                        </div>
                    </div>
                    <div text="假勤管理" iconurl="images/search.png">
                        <div text="员工考勤" url="Pages/attendance/WorkerAttend.aspx" target="fm">
                        </div>
                        <div text="我的考勤" url="Pages/attendance/MyAttend.aspx" target="fm">
                        </div>
                        <div text="请假申请" url="Pages/attendance/LeaveApply.aspx" target="fm">
                        </div>
                        <div text="调休申请" url="Pages/attendance/DayOffApply.aspx" target="fm">
                        </div>
                        <div text="假勤审批" url="Pages/attendance/AttendApprove.aspx" target="fm">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div region="middle">
            <div art="panel" id="main" filly="true" title="主页">
                <iframe id="fm" name="fm" url="ReleaseHistory.htm" art="iframe" width="100%" frameborder="0"
                    filly="{hidden:true}" panelid="main"></iframe>
            </div>
        </div>
        <div region="south" collapsable="true">
            <div align="center" style="background-repeat: repeat-x; background-image: url('images/copyright_bg.jpg');
                font-size: 12px; padding: 5px 5px;">
                版权所有 讯飞教育工程中心 @ 2008-2011
            </div>
        </div>
    </div>
    </form>
</body>
</html>
