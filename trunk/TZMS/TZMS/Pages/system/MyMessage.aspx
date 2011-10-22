<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyMessage.aspx.cs" Inherits="TZMS.Pages.system.MyMessages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的信息</title>
    <script id="jart_js" type="text/javascript" src="../../resources/jart/jart.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table art="form" columns="60,*,50,60,*" style="width: 500px;">
        <tr>
            <td  align="right">
                姓名 
            </td>
            <td>
                <input type="text" art="textbox" />
            </td>
            <td>
            </td>
            <td  align="right">
                密码 
            </td>
            <td>
                <input type="text" art="textbox" />
            </td>
        </tr>
        <tr>
            <td align="right">
                电话 
            </td>
            <td>
                <input type="text" art="textbox" />
            </td>
            <td>
            </td>
            <td align="right">
                年龄 
            </td>
            <td>
                <input type="text" art="textbox" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
