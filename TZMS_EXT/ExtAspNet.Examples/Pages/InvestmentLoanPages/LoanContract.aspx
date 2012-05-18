﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoanContract.aspx.cs" Inherits="TZMS.Web.Pages.InvestmentLoanPages.LoanContract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LoanContract</title>
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
                    <ext:Button ID="btnSave" Hidden="true" runat="server" ValidateForms="mainFrame" OnClick="btnSave_Click"
                        IconUrl="~/Images/ico_nextstep.gif" Text="终止合同" ConfirmText="您确定要终止合同吗?" />
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="Form2"
                runat="server">
                <Rows>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox Enabled="false" ID="tbPenalbond" Label="违约金" runat="server" MaxLength="16"
                                MaxLengthMessage="最多只能输入16位！" Regex="^\-?[0-9]*\.?[0-9]{1,2}$" RegexMessage="金额格式不正确!">
                            </ext:TextBox>
                            <ext:TextBox Enabled="false" ID="tbImprest" Label="备用金" runat="server" MaxLength="16"
                                MaxLengthMessage="最多只能输入16位！" Regex="^\-?[0-9]*\.?[0-9]{1,2}$" RegexMessage="金额格式不正确!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextArea Enabled="false" ID="taOpationRemark" Label="终止申请备注" runat="server"
                                MaxLength="200" MaxLengthMessage="最多只能输入200个字符！" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                AutoHeight="true" Height="392px">
                <Tabs>
                    <ext:Tab ID="TabForm" Title="表单" AutoHeight="true" EnableBackgroundColor="true" runat="server"
                        BodyPadding="5px">
                        <Items>
                            <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="mainFrame"
                                runat="server">
                                <Rows>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbProjectName" Enabled="false" Label="项目名称" runat="server" MaxLength="30"
                                                MaxLengthMessage="最多只能输入30个字符！" RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextArea ID="tbProjectOverview" Readonly="true" Label="项目概述" Height="52px" runat="server"
                                                MaxLength="200" MaxLengthMessage="最多只能输入200个字符！" RegexMessage="不能输入特殊字符!" />
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbBorrowerNameA" Enabled="false" Label="借款人(甲方)" runat="server"
                                                MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                            <ext:TextBox ID="tbBorrowerPhone" Enabled="false" Label="借款联系电话" runat="server" MaxLength="20"
                                                MaxLengthMessage="最多只能输入20个字符！" Regex="(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}"
                                                RegexMessage="电话号码格式不正确!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%" Hidden="true">
                                        <Items>
                                            <ext:Label Hidden="true" ID="Label1" runat="server" Text="借款人信用星级：***" />
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbPayerBName" Enabled="false" Label="付款人(乙方)" runat="server" MaxLength="20"
                                                MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                            <ext:TextBox ID="tbCash" Enabled="false" Label="现金(元)" runat="server" MaxLength="16"
                                                MaxLengthMessage="最多只能输入16位！" Regex="^\-?[0-9]*\.?[0-9]{1,2}$" RegexMessage="金额格式不正确!">
                                            </ext:TextBox>
                                            <ext:DropDownList Hidden="true" HideMode="Display" runat="server" Enabled="false"
                                                Label="付款方式" ID="ddlLoanType">
                                                <ext:ListItem Text="现金" Value="Cash" />
                                                <ext:ListItem Text="转账" Value="TransferAccount" Selected="true" />
                                            </ext:DropDownList>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label runat="server" ID="lbTransferAccount" Label="转账(元)" Text=" 0  ">
                                            </ext:Label>
                                            <ext:TextBox ID="tbRateOfReturn" Enabled="false" Label="投资回报率" runat="server" MaxLength="10"
                                                MaxLengthMessage="最多只能输入10位！" Regex="^\-?[0-9]*\.?[0-9]{1,2}$"  RegexMessage="格式不正确!" />
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbGuarantor" Enabled="false" Label="担保人" runat="server" MaxLength="20"
                                                MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                            <ext:TextBox ID="tbGuarantorPhone" Enabled="false" Label="担保人联系电话" runat="server"
                                                MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}"
                                                RegexMessage="电话号码格式不正确!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbLoanAmount" Enabled="false" Label="借款金额" runat="server" MaxLength="16"
                                                MaxLengthMessage="最多只能输入16位！" Regex="^\-?[0-9]*\.?[0-9]{1,2}$" RegexMessage="金额格式不正确!">
                                            </ext:TextBox>
                                            <ext:TextBox ID="tbLoanTimeLimit" Enabled="false" Label="借款期限" runat="server">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbCollateral" Enabled="false" Label="抵押物" runat="server" MaxLength="20"
                                                MaxLengthMessage="最多只能输入20个字符！" RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:DatePicker ID="dpLoanDate" Enabled="false" Label="借款日期" runat="server">
                                            </ext:DatePicker>
                                            <ext:TextBox ID="dpDueDateForPay" Enabled="false" Label="应付借款日" runat="server">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextArea ID="tbRemark" Readonly="true" Label="备注" runat="server" MaxLength="200"
                                                Height="54px" MaxLengthMessage="最多只能输入200个字符！" RegexMessage="不能输入特殊字符!" />
                                        </Items>
                                    </ext:FormRow>
                                    <%--      <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextArea ID="taAuditOpinion" Enabled="false" Label="审核意见" ShowRedStar="true"
                                                Required="true" runat="server" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！"
                                                Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!" />
                                        </Items>
                                    </ext:FormRow>--%>
                                    <%--         <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextArea ID="taAccountingRemark" Enabled="false" Label="支付备注" ShowRedStar="true"
                                                Required="true" runat="server" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！"
                                                Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!" />
                                        </Items>
                                    </ext:FormRow>--%>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="tabHistory" Title="操作历史" EnableBackgroundColor="true" runat="server"
                        Layout="Fit" BodyPadding="5px">
                        <Items>
                            <ext:Grid ID="gridHistory" Title="Grid1" ShowBorder="true" ShowHeader="false" runat="server"
                                IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true" AutoHeight="true">
                                <Columns>
                                    <ext:BoundField Width="50px" DataField="OperationerName" HeaderText="操作人" />
                                    <%--                                    <ext:BoundField Width="50px" DataField="OperationerAccount" HeaderText="帐号" />--%>
                                    <ext:BoundField Width="100px" DataField="OperationTime" DataFormatString="{0:yyyy/MM/dd HH:mm}"
                                        HeaderText="操作时间" />
                                    <ext:BoundField Width="56px" DataField="OperationType" HeaderText="操作类型" />
                                    <ext:BoundField Width="100px" DataField="OperationDesc" DataTooltipField="OperationDesc"
                                        HeaderText="操作描述" />
                                    <ext:BoundField DataField="Remark" HeaderText="操作人意见" DataTooltipField="Remark" ExpandUnusedSpace="true" />
                                </Columns>
                            </ext:Grid>
                        </Items>
                    </ext:Tab>
                </Tabs>
            </ext:TabStrip>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
