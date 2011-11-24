<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprestPayConfirm.aspx.cs" Inherits="TZMS.Web.Pages.InvestmentProjectPages.ImprestPayConfirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                     IconUrl="~/Images/ico_nextstep.gif" Text="支付确认" />
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="mainFrame"
                runat="server">
                <Rows>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox Enabled="false"   ID="tbImplementationPhase" Label="实施阶段" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbAmountExpended" Enabled="false"  Label="支用金额" ShowRedStar="true" Required="true" runat="server"
                                Text="0" MaxLength="20" MaxLengthMessage="最多只能输入20个数字！" Regex="^[0-9]*$" RegexMessage="只能输入字母!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:DatePicker ID="dpExpendedTime" Enabled="false"  Label="支用时间" runat="server">
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbImprestAmount" Enabled="false"  Label="备用金额" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="20" MaxLengthMessage="最多只能输入20个数字！" Regex="^[0-9]*$" RegexMessage="只能输入字母!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextArea ID="taRemark"  Enabled="false" Label="备注" runat="server" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextArea ID="taAuditOpinion"   Enabled="false" Label="审批说明" runat="server" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！" />
                        </Items>
                    </ext:FormRow>
                        <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextArea ID="taAccountingRemark" Label="支付备注" runat="server" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！" />
                        </Items>
                    </ext:FormRow>
                </Rows>
                  

            </ext:Form>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
