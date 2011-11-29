﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectProcessAdd.aspx.cs"
    Inherits="TZMS.Web.Pages.InvestmentProjectPages.ProjectProcessAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProjectProcessAdd</title>
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
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstNext" runat="server"
                                Label="下一步">
                            </ext:DropDownList>
                            <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUser" runat="server"
                                RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="执行人">
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbImplementationPhase" Label="实施阶段" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="50" MaxLengthMessage="最多只能输入50个字符！" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="60% 40%">
                        <Items>
                            <ext:TextBox ID="tbAmountExpended" Label="支用金额" ShowRedStar="true" Required="true"
                                runat="server" Text="0" MaxLength="20" MaxLengthMessage="最多只能输入20个数字！" Regex="^[0-9]*$"
                                RegexMessage="只能输入字母!">
                            </ext:TextBox>
                            <ext:Label runat="server" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="60% 40%">
                        <Items>
                            <ext:DatePicker ID="dpExpendedTime" Label="支用时间 至" runat="server" ShowRedStar="true"
                                Required="true">
                            </ext:DatePicker>
                            <ext:Label ID="Label1" runat="server" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="60% 40%">
                        <Items>
                            <ext:TextBox ID="tbImprestAmount" Label="备用金额" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个数字！" Regex="^[0-9]*$"
                                RegexMessage="只能输入数字!">
                            </ext:TextBox>
                            <ext:Label ID="Label2" runat="server" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="60% 40%">
                        <Items>
                            <ext:TextArea ID="taRemark" Label="备注" runat="server" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
