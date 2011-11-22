<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentAudit.aspx.cs" Inherits="TZMS.Web.Pages.FolkFinancingPages.PaymentAudit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PaymentAudit</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Height="317px" Title="Panel" AutoScroll="false" ShowBorder="true"
        ShowHeader="false">
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                    <ext:Button ID="btnSave" runat="server" ValidateForms="mainFrame" OnClick="btnSave_Click"
                        Icon="Disk" Text="保存" />
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="mainFrame"
                runat="server">
                <Rows>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:DatePicker ID="DatePicker1" Enabled="false" Label="应付款日" runat="server">
                            </ext:DatePicker>
                            <ext:DatePicker ID="DatePicker2" Enabled="false" Label="实付款日" runat="server">
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextBox ID="TextBox5" Enabled="false" Label="支付金额" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个数字！" Regex="^[0-9]*$"
                                RegexMessage="只能输入字母!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextBox ID="TextBox6" Enabled="false" Label="付款帐号" runat="server" MaxLength="200"
                                MaxLengthMessage="最多只能输入200个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextBox ID="TextBox7" Enabled="false" Label="收款帐号" runat="server" MaxLength="200"
                                MaxLengthMessage="最多只能输入200个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextBox ID="TextBox8" Enabled="false" Label="备注" runat="server" MaxLength="200"
                                MaxLengthMessage="最多只能输入200个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                       <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextArea ID="TextArea1"   Label="审核意见" runat="server" MaxLength="200"
                                MaxLengthMessage="最多只能输入200个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                            </ext:TextArea>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
