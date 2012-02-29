<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankLoanApplyAdd.aspx.cs"
    Inherits="TZMS.Web.Pages.BankLoanPages.BankLoanApplyAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BankLoanApplyAdd</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" />
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
                        Icon="Disk" Text="提交" ConfirmText="您确定提交该表单吗?" />
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
                    <%--             <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstNextBA" runat="server"
                                Label="下一步">
                            </ext:DropDownList>
                            <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUserBA" runat="server"
                                RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="执行人">
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>--%>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbProjectName" Label="项目名称" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="100" MaxLengthMessage="最多只能输入100个字符！">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbCustomerName" Label="客户名称" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" 
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                            <ext:TextBox ID="tbLoanCompany" Label="贷款公司" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="100" MaxLengthMessage="最多只能输入100个字符！" 
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbLoanAmount" Label="贷款金额" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="16" MaxLengthMessage="最多只能输入16个数字！"   Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="金额格式不正确!">
                            </ext:TextBox>
                            <ext:TextBox ID="tbLoanFee" Label="贷款手续费" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="16" MaxLengthMessage="最多只能输入16个数字！"   Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="金额格式不正确!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbCollateralCompany" Label="抵押物公司" runat="server" MaxLength="20"
                                ShowRedStar="true" Required="true" MaxLengthMessage="最多只能输入20个字符！" 
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:DatePicker ID="dpSignDate" Label="签订日期" ShowRedStar="true" Required="true" runat="server">
                            </ext:DatePicker>
                            <ext:TextBox ID="tbDownPayment" Label="预付定金" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="16" MaxLengthMessage="最多只能输入16个数字！"   Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="金额格式不正确!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextArea ID="taContact" Label="联系方式(贷款人，抵押物方)" runat="server" MaxLength="200"
                                MaxLengthMessage="最多只能输入200个字符！">
                            </ext:TextArea>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form EnableBackgroundColor="true" EnableCollapse="true" Title="会计核算" BodyPadding="5px"
                ID="Form2" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="60% 40%">
                        <Items>
                            <%--            <ext:DropDownList Required="true" ShowRedStar="true" ID="DropDownList1" runat="server"
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
                            <ext:TextArea ID="tbRemark" Label="备注(财务需提供材料)" runat="server" MaxLength="300" MaxLengthMessage="最多只能输入300个字符！">
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
