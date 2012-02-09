<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProxyAmountDetial.aspx.cs"
    Inherits="TZMS.Web.ProxyAmountDetial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" ShowHeader="false">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Text="关闭" Icon="Cancel" runat="server" OnClick="btnClose_Click">
                    </ext:Button>
                    <ext:Button ID="btnSubmit" Text="保存" Icon="Disk" runat="server" ValidateForms="pelMain"
                        OnClick="btnSubmit_Click" ConfirmText="您确定保存该代帐单吗?">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                        AutoHeight="true" Height="387px">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="代账单" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Form EnableBackgroundColor="true" LabelWidth="65px" ShowHeader="false" ShowBorder="true"
                                        BodyPadding="5px" ID="mainForm" runat="server">
                                        <Rows>
                                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50%">
                                                <Items>
                                                    <ext:Label ID="lblAmountType" Label="费用类型" runat="server">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:Label ID="lblUnitName" Label="交款单位" runat="server">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:Label ID="lblCNMoney" runat="server" Label="大写金额">
                                                    </ext:Label>
                                                    <ext:TextBox ID="tbxMoney" runat="server" Label="小写金额" Required="true" ShowRedStar="true"
                                                        AutoPostBack="true" Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="金额格式不正确!" OnTextChanged="tbxMoney_TextChanged">
                                                    </ext:TextBox>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextBox ID="tbxSument" runat="server" Required="true" ShowRedStar="true" Label="收款事由"
                                                        MaxLength="100" MaxLengthMessage="最多只能输入100个字！">
                                                    </ext:TextBox>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow6" runat="server">
                                                <Items>
                                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstCollectMethod" runat="server"
                                                        Label="收款方式">
                                                        <ext:ListItem Text="现金" Value="现金" Selected="true" />
                                                        <ext:ListItem Text="转账" Value="转账" />
                                                    </ext:DropDownList>
                                                    <ext:DatePicker ID="dpkOpeningDate" ShowRedStar="true" Required="true" runat="server"
                                                        Label="开票日期" AutoPostBack="true" OnTextChanged="dpkOpeningDate_TextChanged">
                                                    </ext:DatePicker>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:Label ID="Label1" runat="server" Label="收款单位" Text="合肥吉信财务管理有限公司">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                        </Rows>
                                    </ext:Form>
                                </Items>
                            </ext:Tab>
                        </Tabs>
                    </ext:TabStrip>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
