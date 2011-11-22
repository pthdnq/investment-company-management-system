<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectAudit.aspx.cs" Inherits="TZMS.Web.Pages.InvestmentProjectPages.ProjectAudit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxName" Enabled="false" Label="客户名称" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextArea ID="tbxPosition2" Enabled="false"  runat="server" Label="项目概述" MaxLength="200" MaxLengthMessage="最多只能输入20个字符！"
                                Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                            </ext:TextArea>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:DatePicker ID="dpkEntryDate" Enabled="false"  Label="签订日期" ShowRedStar="true" Required="true"
                                runat="server">
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxGraduatedSchool" Enabled="false"  Label="联系人" runat="server" MaxLength="50" MaxLengthMessage="最多只能输入50个字符！"
                                Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                            <ext:TextBox ID="tbxPhoneNumber" Enabled="false"  Label="联系电话" runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！"
                                Regex="(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}" RegexMessage="电话号码格式不正确!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxWorkYear" Enabled="false"  Label="合同金额" runat="server" MaxLength="2" MaxLengthMessage="最多只能输入2个数字！"
                                Regex="^[0-9]*$" RegexMessage="只能输入数字!">
                            </ext:TextBox>
                            <ext:TextBox ID="TextBox2" Enabled="false"  Label="预付订金" runat="server" MaxLength="2" MaxLengthMessage="最多只能输入2个数字！"
                                Regex="^[0-9]*$" RegexMessage="只能输入数字!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextBox ID="TextBox1" Enabled="false"  Label="备注" runat="server" MaxLength="50" MaxLengthMessage="最多只能输入50个字符！"
                                Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="TextBox3" Enabled="false"  Label="申请人" runat="server" MaxLength="50" MaxLengthMessage="最多只能输入50个字符！"
                                Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextBox ID="tbxAddress" Label="审核意见" runat="server" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！"
                                Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
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
