<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TZMS.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>吉信投资集团-OA系统</title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <script type="text/javascript" src="resources/jart/jart.js"></script>
    <style type="text/css">
        body
        {
            text-align: center;
            background: #c0c0c0;
            text-align: left;
            color: #666;
            font-size: 12px;
            font-family: "宋体";
            padding: 0;
            margin: 0;
        }
        .login_bg
        {
            background-image: url(Images/login_bg.jpg);
            background-repeat: no-repeat;
            margin: auto auto;
            height: 509px;
            width: 764px;
            text-align: left;
        }
        .form_area
        {
            width: 300px;
            height: 100px;
            padding-top: 220px;
            padding-left: 230px;
            border: soild 1px;
        }
        .form_area label
        {
            display: block;
            float: left;
            color: #336699;
            font-weight: bold;
            font-size: 14px;
            padding-top: 5px;
            letter-spacing: 0.5em;
            margin-right: 10px;
        }
        .form_area .textbox
        {
            font-size: 14px;
            color: #666666;
            border: solid 1px #8AA7CC;
            height: 20px;
            line-height: 20px;
            padding-left: 5px;
            width: 195px;
            background: url(Images/login_txb.gif) no-repeat;
        }
        .form_area a.btn
        {
            display: block;
            line-height: 27px;
            text-align: center;
            height: 27px;
            width: 72px;
            background: url(Images/btn_06.jpg) no-repeat;
            margin-right: 10px;
            font-size: 14px;
            color: #FFFFFF;
            float: left;
            cursor: pointer;
        }
        .form_area a:hover
        {
            background: url(Images/btn_06_hover.jpg) no-repeat;
            color: #CCFFFF;
        }
        .form_area p
        {
            margin: 10px;
        }
    </style>
    <script type="text/javascript">

        function pswEmpty() {
            document.getElementById("txtPsw").value = "";
        }

        function login() {
            var name = document.getElementById("txtUserName").value;
            var psw = document.getElementById("txtPsw").value;
            if (name == '' || psw == '') {
                //alert('帐号或密码不能为空!');
                $.alert("帐号或密码不能为空!", "登录", "warning");
                if (name == '')
                    //document.getElementById("txtUserName").focus();
                //else if (psw == '')
                //document.getElementById("txtPsw").focus();
                return false;
            }
            if (name.indexOf("'") != -1 || psw.indexOf("'") != -1) {
                //alert('帐号或密码中包含特殊字符!');
                $.alert("帐号或密码不正确!", "登录", "warning");
                //if (name.indexOf("'") != -1)
                //document.getElementById("txtUserName").focus();
                //else if (psw.indexOf("'") != -1)
                //document.getElementById("txtPsw").focus();
                return false;
            }
            //document.getElementById("imgBtnLogin").click();
            //ajax 登录
            $.block(1, { message: "<br/><br/><br/><br/><span style='color:blue;font-size: 18px;'>正在登录...</span>", alpha: 0.1 });
            $.ajax({ url: "Login.aspx?name=" + name + "&psw=" + psw })
            .success(function (data) {
                if (data == 'success') {
                    //正确
                    window.navigate("index.aspx");
                }
                else {
                    //错误
                    $.alert("帐号或密码不正确!", "登录", "warning", pswEmpty());
                }
            })
            .error(function () { $.alert("超时，请重新登录!", "登录", "warning", pswEmpty()); })
            .complete(function () { $.unblock(1); });

        }
        function cancel() {
            document.getElementById("txtUserName").value = '';
            document.getElementById("txtPsw").value = '';
            document.getElementById("txtUserName").focus();

        }
        function enterLogin() {

            var myEvent = event || window.event;
            var keyCode = myEvent.keyCode;
            if (keyCode == 13) {
                login();
            }
        }
    </script>
</head>
<body>
    <form id="loginForm" runat="server">
    <div>
        <div class="login_bg">
            <div class="form_area" style="height: 200px;">
                <p>
                    <label id="lbluser">
                        帐号</label>
                    <input id="txtUserName" tabindex="0" onkeypress="enterLogin();" runat="Server" type="text"
                        name="" title=""  class="textbox" value="" />
                    <br />
                    <span id="cueUser" style="color: Red; font-size: 12px; display: none;">请录入6~18个由字母、数字、下划线组成的账号！</span>
                    <span id="cueLogin" style="color: Red; font-size: 12px; display: none;"></span>
                </p>
                <p>
                    <label id="lblpassword">
                        密码</label>
                    <input id="txtPsw" tabindex='1'  onkeypress="enterLogin();" type="password" runat="Server"
                        name="" title="" class="textbox" value="" /></p>
                <p style="padding-left: 60px;">
                    <a class="btn" tabindex='3' onclick="login();">登录</a> <a class="btn" onclick="cancel();">
                        取消</a>
                </p>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
