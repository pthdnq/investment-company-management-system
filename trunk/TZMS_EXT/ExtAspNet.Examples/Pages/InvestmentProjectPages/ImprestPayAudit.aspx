﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprestPayAudit.aspx.cs"
    Inherits="TZMS.Web.Pages.InvestmentProjectPages.ImprestPayAudit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ImprestPayAudit</title>
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
                        IconUrl="~/Images/ico_nextstep.gif" Text="通过" ConfirmText="您确定通过该申请吗?" />
                    <ext:Button ID="btnDismissed" runat="server" ValidateForms="mainFrame" OnClick="btnDismissed_Click"
                        IconUrl="~/Images/ico_firststep.gif" Text="不通过" ConfirmText="您确定不通过该申请吗?" />
                    <ext:Label runat="server" ID="HighMoneyTips" />
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
                            <ext:TextArea ID="taAuditOpinion" Label="审批说明" runat="server" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                AutoHeight="true" Height="298px">
                <Tabs>
                    <ext:Tab ID="TabForm" Title="表单" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                        <Items>
                            <ext:Form EnableBackgroundColor="true" LabelWidth="59px" ShowHeader="false" ShowBorder="false"
                                BodyPadding="5px" ID="mainForm" runat="server">
                                <Rows>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox Enabled="false" ID="tbImplementationPhase" Label="实施阶段" ShowRedStar="true"
                                                Required="true" runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！"
                                                Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!" />
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbAmountExpended" Enabled="false" Label="支用金额" ShowRedStar="true"
                                                Required="true" runat="server" Text="0" MaxLength="20" MaxLengthMessage="最多只能输入20个数字！"
                                                Regex="^[0-9]*$" RegexMessage="只能输入字母!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="dpExpendedTime" Enabled="false" Label="支用时间" runat="server">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbImprestAmount" Enabled="false" Label="备用金额" ShowRedStar="true"
                                                Required="true" runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个数字！"
                                                Regex="^[0-9]*$" RegexMessage="只能输入字母!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextArea ID="taRemark" Enabled="false" Label="备注" runat="server" MaxLength="200"
                                                MaxLengthMessage="最多只能输入200个字符！" />
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
                                    <ext:BoundField Width="55px" DataField="OperationerAccount" HeaderText="帐号" />
                                    <ext:BoundField Width="100px" DataField="OperationTime" DataFormatString="{0:yyyy/MM/dd HH:mm}"
                                        HeaderText="操作时间" />
                                    <ext:BoundField Width="50px" DataField="OperationType" HeaderText="操作类型" />
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