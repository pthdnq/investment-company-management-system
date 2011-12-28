<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoanReceivablesAdd.aspx.cs"
    Inherits="TZMS.Web.Pages.InvestmentLoanPages.LoanReceivablesAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LoanReceivablesAdd</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" AutoHeight="true" Title="Panel" AutoScroll="false" ShowBorder="true"
        ShowHeader="false">
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                    <ext:Button ID="btnSave" runat="server" ValidateForms="mainFrame" OnClick="btnSave_Click"
                        Icon="Disk" Text="提交" ConfirmText="您确定提交该表单吗?" />
                    <ext:Label ID="Label1" runat="server" Text="应收借款日将用来计算客户积分。" CssStyle="Color:Gray;">
                    </ext:Label>
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
                            <ext:TextBox Hidden="true" Enabled="false" ID="tbProjectName" Label="项目名称" ShowRedStar="true"
                                Required="true" runat="server" MaxLength="100" MaxLengthMessage="最多只能输入100个字符！" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:DatePicker ID="dpDueDateForReceivables" Label="应收借款日" ShowRedStar="true" Required="true"
                                runat="server">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpDateForReceivables" Label="实收借款日" runat="server" ShowRedStar="true"
                                Required="true">
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbAmountofpaidUp" Label="实收金额" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="9" MaxLengthMessage="最多只能输入9个数字！" Regex="^[0-9]*$"
                                RegexMessage="只能输入数字!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextBox ID="tbReceivablesAccount" Label="收款帐号或现金" runat="server" MaxLength="100"
                                ShowRedStar="true" Required="true" EmptyText="开户行、帐号、开户名称" MaxLengthMessage="最多只能输入100个字符！">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextArea ID="taRemark" Label="备注(本金或利息)" runat="server" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
