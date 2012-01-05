<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaderAuditResultView.aspx.cs"
    Inherits="TZMS.Web.Pages.FolkFinancingPages.LeaderAuditResultView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LeaderAuditResultView</title>
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
                    <ext:Button ID="btnSave" Hidden="true" runat="server" ValidateForms="mainFrame" OnClick="btnSave_Click"
                        Icon="Disk" Text="保存" />
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                AutoHeight="true" Height="392px">
                <Tabs>
                    <ext:Tab ID="TabForm" Title="表单" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                        <Items>
                            <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="mainFrame"
                                runat="server">
                                <Rows>
                                    <ext:FormRow ColumnWidths="100%">
                                        <Items>
                                            <ext:TextArea ID="taAuditOpinion" Enabled="false" Label="审核备注" runat="server" MaxLength="200"
                                                MaxLengthMessage="最多只能输入200个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                                            </ext:TextArea>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbBorrowerNameA" Enabled="false" Label="借款人" runat="server" MaxLength="20"
                                                MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                            <ext:TextBox ID="tbLenders" Enabled="false" Label="出借人" runat="server" MaxLength="20"
                                                MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbGuarantee" Label="担保人" Enabled="false" runat="server" MaxLength="20"
                                                MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbLoanAmount" Label="借款金额" Enabled="false" runat="server" MaxLength="20"
                                                MaxLengthMessage="最多只能输入20个数字！" Regex="^[0-9]*$" RegexMessage="只能输入数字!">
                                            </ext:TextBox>
                                            <ext:TextBox ID="tbLoanTimeLimit" Label="借款期限" Enabled="false" runat="server" MaxLength="20"
                                                MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:DatePicker ID="dpLoanDate" Label="借款日期" runat="server" Enabled="false">
                                            </ext:DatePicker>
                                            <ext:TextBox ID="dpDueDateForPay" Label="应付款日" Enabled="false" runat="server" MaxLength="2"
                                                MaxLengthMessage="最多只能输入2个数字！" Regex="[1-3][0-9]*$" RegexMessage="只能输入数字!" Text="1">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbCollateral" Enabled="false" Label="抵押物" runat="server" MaxLength="20"
                                                MaxLengthMessage="最多只能输入20个字符！">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbBorrowingCost" Enabled="false" Label="借款成本" runat="server" MaxLength="8"
                                                MaxLengthMessage="最多只能输入8个数字！" Regex="^[0-9]*$" RegexMessage="只能输入数字!">
                                            </ext:TextBox>
                                            <ext:DropDownList ID="ddlLoanType" Enabled="false" Label="借款方式" runat="server">
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
                                            <ext:TextBox ID="tbContactPhone" Enabled="false" Label="联系电话" runat="server" MaxLength="20"
                                                MaxLengthMessage="最多只能输入20个字符！" Regex="(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}"
                                                RegexMessage="电话号码格式不正确!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="100%">
                                        <Items>
                                            <ext:TextArea ID="tbRemark" Enabled="false" Label="备注" runat="server" MaxLength="50"
                                                MaxLengthMessage="最多只能输入50个字符！">
                                            </ext:TextArea>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="tabHistory" Title="操作历史" EnableBackgroundColor="true" runat="server"
                        BodyPadding="5px">
                        <Items>
                            <ext:Grid ID="gridHistory" Title="Grid1" ShowBorder="true" ShowHeader="false" runat="server"
                                IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true" AutoHeight="true">
                                <Columns>
                                    <ext:BoundField Width="52px" DataField="OperationerName" HeaderText="操作人" />
                                    <%--       <ext:BoundField Width="55px" DataField="OperationerAccount" HeaderText="帐号" />--%>
                                    <ext:BoundField Width="100px" DataField="OperationTime" DataFormatString="{0:yyyy/MM/dd HH:mm}"
                                        HeaderText="操作时间" />
                                    <ext:BoundField Width="60px" DataField="OperationType" HeaderText="操作类型" />
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
