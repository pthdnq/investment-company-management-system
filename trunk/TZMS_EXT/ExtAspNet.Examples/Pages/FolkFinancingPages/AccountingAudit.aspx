<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingAudit.aspx.cs"
    Inherits="TZMS.Web.Pages.FolkFinancingPages.AccountingAudit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AccountingAudit</title>
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
                        IconUrl="~/Images/ico_nextstep.gif" Text="通过" />
                    <ext:Button ID="btnDismissed" runat="server" ValidateForms="mainFrame" OnClick="btnDismissed_Click"
                        IconUrl="~/Images/ico_firststep.gif" Text="不通过" />
             <%--       <ext:Label runat="server" ID="HighMoneyTips"/>--%>
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
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextArea ID="taAuditOpinion" Label="审核备注" runat="server" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！"
                                Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                            </ext:TextArea>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbBorrowerNameA" Label="借款人" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                            <ext:TextBox ID="tbLenders" Label="出款人" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbGuarantee" Label="担保人" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbLoanAmount" Label="借款金额" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="20" MaxLengthMessage="最多只能输入20个数字！" Regex="^[0-9]*$" RegexMessage="只能输入数字!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:DatePicker ID="dpLoanDate" Label="借款日期" runat="server">
                            </ext:DatePicker>
                            <ext:TextBox ID="dpDueDateForPay" Label="应付款日" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="2" MaxLengthMessage="最多只能输入2个数字！" Regex="[1-3][0-9]*$"
                                RegexMessage="只能输入数字!" Text="1">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbCollateral" Label="抵押物" runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbBorrowingCost" Label="借款成本" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="8" MaxLengthMessage="最多只能输入8个数字！" Regex="^[0-9]*$"
                                RegexMessage="只能输入数字!">
                            </ext:TextBox>
                            <ext:DropDownList ID="ddlLoanType" Label="借款方式" runat="server">
                                <ext:ListItem Text="转账" Value="TransferAccount" Selected="true" />
                                <ext:ListItem Text="现金" Value="Cash" />
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbContactPhone" Label="联系电话" runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！"
                                Regex="(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}" RegexMessage="电话号码格式不正确!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextArea ID="tbRemark" Label="备注" runat="server" MaxLength="50" MaxLengthMessage="最多只能输入50个字符！">
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
