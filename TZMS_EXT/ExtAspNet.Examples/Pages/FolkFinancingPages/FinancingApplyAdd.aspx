<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinancingApplyAdd.aspx.cs"
    Inherits="TZMS.Web.Pages.FolkFinancingPages.FinancingApplyAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FinancingApplyAdd</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" AutoHeight="true" Title="Panel" AutoScroll="true" ShowBorder="true"
        ShowHeader="false">
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                    <ext:Button ID="btnSave" runat="server" ValidateForms="mainFrame" OnClick="btnSave_Click"
                        Icon="Disk" Text="提交" ConfirmText="您确定提交该表单吗?" />
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="mainFrame"
                AutoHeight="true" runat="server">
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
                            <ext:TextBox ID="tbBorrowerNameA" Label="借款人" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                            <ext:TextBox ID="tbLenders" Label="出借人" ShowRedStar="true" Required="true" runat="server"
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
                            <ext:TextBox ID="tbLoanAmount" Label="借款金额" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="20" MaxLengthMessage="最多只能输入20个数字！"   Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="金额格式不正确!"
                                AutoPostBack="true" OnTextChanged="tbCash_OnTextChanged" CompareControl="tbLoanAmount"
                                CompareType="Float" CompareOperator="LessThanEqual" CompareMessage="现金不能大于借款总金额">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbCash" Label="现金(元)" ShowRedStar="true" Required="true" runat="server"
                                AutoPostBack="true" OnTextChanged="tbCash_OnTextChanged" MaxLength="20" MaxLengthMessage="最多只能输入20个数字！"
                                  Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="金额格式不正确!" CompareControl="tbLoanAmount" CompareType="Float"
                                CompareOperator="LessThanEqual" CompareMessage="现金不能大于借款总金额">
                            </ext:TextBox>
                            <ext:Label runat="server" ID="lbTransferAccount" Text="转账：0 元">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:DatePicker ID="dpLoanDate" Label="借款日期" runat="server" ShowRedStar="true" Required="true">
                            </ext:DatePicker>
                            <ext:TextBox ID="dpDueDateForPay" Label="应付账款日" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="2" MaxLengthMessage="最多只能输入2个数字！" Regex="^[0-9]*$"
                                EmptyText="某日" RegexMessage="只能输入数字!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbCollateral" Label="抵押物" runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 49% 1%">
                        <Items>
                            <ext:TextBox ID="tbBorrowingCost" Label="借款成本" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="8" MaxLengthMessage="最多只能输入8个数字！" Regex="^[0-9]*$"
                                RegexMessage="只能输入数字!">
                            </ext:TextBox>
                            <ext:TextBox ID="tbLoanTimeLimit" Label="借款期限" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                            <ext:DropDownList ID="ddlLoanType" Hidden="true" HideMode="Display" Label="借款方式"
                                runat="server">
                                <ext:ListItem Text="转账" Value="TransferAccount" Selected="true" />
                                <ext:ListItem Text="现金" Value="Cash" />
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:DropDownList ID="ddlInterestType" Label="利息" runat="server">
                                <ext:ListItem Text="先付" Value="先付" Selected="true" />
                                <ext:ListItem Text="后付" Value="后付" />
                            </ext:DropDownList>
                            <ext:TextBox ID="tbContactPhone" Label="联系电话" runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！"
                                Regex="(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}" RegexMessage="电话号码格式不正确!">
                            </ext:TextBox>
                            <%--    <ext:Label runat="server" ID="lbtmp221"></ext:Label>--%>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form EnableBackgroundColor="true" EnableCollapse="true" Title="会计核算" BodyPadding="5px"
                AutoHeight="true" ID="Form2" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="60% 40%">
                        <Items>
                            <%--    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstNextBA" runat="server"
                                Label="下一步">
                            </ext:DropDownList>--%>
                            <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUserBA" runat="server"
                                RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="核算会计">
                            </ext:DropDownList>
                            <ext:Label runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextArea ID="tbRemark" Label="备注(需提供材料)" runat="server" MaxLength="50" MaxLengthMessage="最多只能输入50个字符！">
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
