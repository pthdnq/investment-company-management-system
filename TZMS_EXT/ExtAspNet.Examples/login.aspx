<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TZMS.Web.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>登录</title>
    <style type="text/css">
        body
        {
            background: url(images/bodyback.jpg);
background-repeat:repeat-x;
            margin: 0;
            padding: 0;
            overflow:hidden;
        }
        #login_bg
        {
            background-image: url(images/bg2.jpg);
            background-repeat: no-repeat;
            background-position:top center;
            position:relative;
            width: 1000px;
            height:850px;
            margin: 0 auto;
        }
        #loginBox
        {
            background-image: url(images/bg_03.png);
            background-repeat: no-repeat;
            position:absolute;
            top:185px;
            right:0px;
            width: 366px;
            height: 225px;
        }
        .title
        {
            position: relative;
            height:70px;
        }
        .titleimg
        {
             position:absolute;
             top:30px;
             left:375px;
        }
        .logintitle
        {
        	position:absolute;
            background-image: url(images/ff_06.png);
            background-repeat: no-repeat;
            background-position: center center;
            width:318px;
            height: 53px;
            left: 11px;
            top: 1px;
        }
        .text{ font-family:SimSun; font-size:14px; color:#274069; float:left;margin-left:40px; margin-top:8px;}
        .textbox{height:23px; line-height:23px; font-size:14px; width:182px; border:solid 1px #7a9fcb; background:#fff; float:left;background-repeat:no-repeat; background-position:center center;}
        .btn{ width:70px; height:26px; border:0;margin-top:10px; cursor:pointer;}
        .margin{margin-left:100px; margin-right:20px;}
    </style>
    <script type="text/javascript">
        function tzmslogin_() {
            var txtName = document.getElementById("tbxUserName").value;
            var txtPsw = document.getElementById("tbxPassword").value;
            if (txtName == '') {
                alert("帐号不能为空！");
                return;
            }
            if (txtPsw == '') {
                alert("密码不能为空！");
                return;
            }
            if (txtName.indexOf("'") > -1 || txtPsw.indexOf("'") > -1
            || txtName.indexOf("--") > -1 || txtPsw.indexOf("--") > -1) {
                alert("帐号或密码不正确！");
                return;
            }
            //检查
            var btn = document.getElementById("<%=btnLogin.ClientID %>");
            btn.click();
        }
        function ReLogin0() {
            document.getElementById("tbxPassword").value = '';
            document.getElementById("tbxUserName").value = '';
        }
        function enterLogin() {
            
            var myEvent = event || window.event;
            var keyCode = myEvent.keyCode;
            if (keyCode == 13) {
                tzmslogin_();
            }
        }
 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <img class="titleimg" alt="" src="images/title.png" />
    <div id="login_bg">
        <div id="loginBox">
            <div class="title">
               <%-- <img alt="" src="images/computer.png" />--%>
                <div class="logintitle">
                </div>
            </div>
            <table border="0" cellpadding="5" cellspacing="0" class="tab">
                <tr>
                    <td>
                        <div class="text">
                            帐&nbsp;号：</div>
                        <input class="textbox" id='tbxUserName' runat="server" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="text">
                            密&nbsp;码：</div>
                        <input class="textbox" onkeypress="enterLogin();" id='tbxPassword' runat="server" type="password"  value="1" />
                    </td>
                </tr>
            </table>
            <input class="btn margin" onfocus="this.blur()" onclick="tzmslogin_();" type="button"
                style="background-image: url(images/loginBt.png);" /><input class="btn" onfocus="this.blur()"
                    onclick="ReLogin0()" type="button" style="background-image: url(images/btn.png);" />
        </div>
    </div>
    
    <div style="visibility:hidden">
        <asp:Button ID="btnLogin" OnClick="btnLogin_Click" runat="server" Text="" />
    </div>
    </form>
</body>
</html>
