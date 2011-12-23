<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePsw.aspx.cs" Inherits="TZMS.Web.ChangePsw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Height="168px" Title="Panel" AutoScroll="false" ShowBorder="true"
        ShowHeader="false">
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnSave" runat="server" OnClick="btnSave_Click" ValidateForms="mainFrame" Icon="Disk" Text="保存">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form EnableBackgroundColor="true" LabelWidth="110px" ShowHeader="false" BodyPadding="5px"
                ID="mainFrame" runat="server">
                <Rows>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxOldPsw" Label="原始密码" TextMode="Password" runat="server" Required="true"
                                MaxLength="15" MaxLengthMessage="最多只能输入15个字母或数字！" Regex="^[a-zA-Z0-9]*$" RegexMessage="只能输入字母或数字!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxOldPsw1" Label="请您输入新密码" TextMode="Password" Required="true" runat="server"
                                MaxLength="15" MaxLengthMessage="最多只能输入15个字母或数字！" Regex="^[a-zA-Z0-9]*$" RegexMessage="只能输入字母或数字!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxOldPsw2" Label="再次输入新密码" TextMode="Password" Required="true" runat="server"
                                MaxLength="15" MaxLengthMessage="最多只能输入15个字母或数字！" Regex="^[a-zA-Z0-9]*$" RegexMessage="只能输入字母或数字!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
