<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinancingContractPayAdd.aspx.cs" Inherits="TZMS.Web.Pages.FolkFinancingPages.FinancingContractPayAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FinancingContractPayAdd</title>
</head>
<body>
        <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server"   AutoSizePanelID="pelMain"/>
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
                        Icon="Disk" Text="提交"  ConfirmText="您确定提交该表单吗?"/>
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
                            <ext:TextBox ID="tbPaymentAccount" Label="付款帐号" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="50" MaxLengthMessage="最多只能输入50个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                            <ext:TextBox ID="tbReceivablesAccount" Label="收款帐号" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="50" MaxLengthMessage="最多只能输入50个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
          
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbAmountOfPayment" Label="支付金额" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="20" MaxLengthMessage="最多只能输入20个数字！" Regex="^[0-9]*$" RegexMessage="只能输入数字!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:DatePicker ID="dpDateForPay" Label="支付日期" runat="server" ShowRedStar="true" Required="true">
                            </ext:DatePicker>
                          <ext:DatePicker ID="dpDueDateForPay" Label="应付款日" runat="server" ShowRedStar="true" Required="true">
                            </ext:DatePicker>
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
