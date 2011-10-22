<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changePsw.aspx.cs" Inherits="TZMS.Pages.system.changePsw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <script id="jart_js" type="text/javascript" src="../../resources/jart/jart.js"></script>
    <script type="text/javascript">
        //修改密码，Ajax
        function changePsw() {
            var oldp = $('#oldpsw').val();
            var new1 = $('#newpsw1').val();
            var new2 = $('#newpsw2').val();

            ///生成随机数字
            var randomparam = Math.floor(Math.random() * 1000000);
            $.ajax({ url: "changePsw.ashx",
                data: "op=changePsw&oldpsw=" + oldp + "&newpsw1=" + new1 + "&newpsw2=" + new2 + "&randomparam=" + randomparam
            })
            .success(function (data) {
                switch (data) {
                    case "success":
                        //成功
                        $.alert("密码修改成功！", "修改密码", "info");
                        break;
                    case "old":
                        //现在的密码输入错误
                        $.alert("现在的密码输入有误！", "修改密码", "info");
                        break;
                    default:
                        $.alert("对不起，请重试！", "修改密码", "info");
                        break;
                }
            })
            .error(function () {
                //window.navigate("Login.aspx");
            })
            .complete(function () { ; });
        }
    </script>
</head>
<body style="background-color: #ecf3fd">
    <form runat="server">
    <table art="form" columns="100,*">
        <tr>
            <td align="right">
                <label art='label' required='true'>
                    现在的密码：</label>
            </td>
            <td>
                <input id="oldpsw" type="password" art="textbox" />
            </td>
        </tr>
        <tr style="height: 5px">
        </tr>
        <tr>
            <td align="right">
                <label art='label' required='true'>
                    设置新的密码：</label>
            </td>
            <td>
                <input type="password" id="newpsw1" emptytext="4到15位的数字或字母" art="textbox" />
            </td>
        </tr>
        <tr style="height: 5px">
        </tr>
        <tr>
            <td align="right">
                <label art='label' required='true'>
                    重复新的密码：</label>
            </td>
            <td>
                <input type="password" id="newpsw2" art="textbox" />
            </td>
        </tr>
        <tr style="height: 8px">
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <span id="btn" art='button' onclick="changePsw()" iconurl='../../images/edit.gif'>确认</span>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
