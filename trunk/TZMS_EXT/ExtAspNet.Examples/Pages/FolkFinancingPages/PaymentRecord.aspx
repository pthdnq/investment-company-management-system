<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentRecord.aspx.cs"
    Inherits="TZMS.Web.Pages.FolkFinancingPages.PaymentRecord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PaymentRecord</title>
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
                AutoHeight="true" Height="342px">
                <Tabs>
                    <ext:Tab ID="TabForm" Title="表单" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                        <Items>
                            <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="mainFrame"
                                runat="server">
                                <Rows>
                                    <ext:FormRow ColumnWidths="100%">
                                        <Items>
                                            <ext:TextArea ID="taAccountingRemark" Label="支付备注" runat="server" MaxLength="200"
                                                Enabled="false" MaxLengthMessage="最多只能输入200个字符！">
                                            </ext:TextArea>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbPaymentAccount" Enabled="false" Label="付款帐号" runat="server" MaxLength="60"
                                                MaxLengthMessage="最多只能输入60个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                            <ext:TextBox ID="tbReceivablesAccount" Enabled="false" Label="收款帐号" runat="server"
                                                MaxLength="60" MaxLengthMessage="最多只能输入60个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                                RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbAmountOfPayment" Label="支付金额" Enabled="false" runat="server" MaxLength="8"
                                                MaxLengthMessage="最多只能输入8个数字！" Regex="^[0-9]*$" RegexMessage="只能输入数字!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:DatePicker ID="dpDateForPay" Label="实付账款日" runat="server" Enabled="false">
                                            </ext:DatePicker>
                                            <ext:DatePicker ID="dpDueDateForPay" Label="应付账款日" runat="server" Enabled="false">
                                            </ext:DatePicker>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="100%">
                                        <Items>
                                            <ext:TextArea ID="taRemark" Enabled="false" Label="备注" runat="server" MaxLength="200"
                                                MaxLengthMessage="最多只能输入200个字符！">
                                            </ext:TextArea>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="100%">
                                        <Items>
                                            <ext:TextArea ID="taAuditOpinion" Enabled="false" Label="审核意见" runat="server" MaxLength="200"
                                                MaxLengthMessage="最多只能输入200个字符！">
                                            </ext:TextArea>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="tabHistory" Title="操作历史" EnableBackgroundColor="true" runat="server"
                      Layout="Fit"   BodyPadding="5px">
                        <Items>
                            <ext:Grid ID="gridHistory" Title="Grid1" ShowBorder="true" ShowHeader="false" runat="server"
                                IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true" AutoHeight="true">
                                <Columns>
                                    <ext:BoundField Width="50px" DataField="OperationerName" HeaderText="操作人" />
                                    <%--        <ext:BoundField Width="55px" DataField="OperationerAccount" HeaderText="帐号" />--%>
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
