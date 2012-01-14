<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostApprove.aspx.cs" Inherits="TZMS.Web.CostApprove" %>

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
                    <ext:Button ID="btnPass" Text="确认" Icon="Accept" runat="server" ValidateForms="mainForm2"
                        OnClick="btnPass_Click" ConfirmText="您确定确认吗?">
                    </ext:Button>
                    <ext:Button ID="btnRefuse" Text="不同意" Icon="Stop" runat="server" OnClick="btnRefuse_Click"
                        Hidden="true" ConfirmText="您确定不同意吗?">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form ID="mainForm2" EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px"
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
                            <ext:FormRow ColumnWidths="60%">
                                <Items>
                                    <ext:TextBox ID="tbxActualMoney" runat="server" Label="实际金额" Required="true" ShowRedStar="true"
                                        Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="金额格式不正确!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%" Hidden="true">
                                <Items>
                                    <ext:TextArea ID="taaApproveSugest" Height="50px" runat="server" Label="审批意见" MaxLength="100"
                                        MaxLengthMessage="最多只能输入100个字！" Hidden="true">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                        AutoHeight="true" Height="335px">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="业务费用申请单" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Form EnableBackgroundColor="true" LabelWidth="90px" ShowHeader="false" ShowBorder="false"
                                        BodyPadding="5px" ID="mainForm" runat="server">
                                        <Rows>
                                            <ext:FormRow ColumnWidths="60%">
                                                <Items>
                                                    <ext:DropDownList ID="ddlstCompanyname" runat="server" Label="公司名称" Enabled="false">
                                                    </ext:DropDownList>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:DropDownList ID="ddlstCostType" runat="server" Label="费用类型" Enabled="false">
                                                        <ext:ListItem Text="预收定金" Value="0" Selected="true" />
                                                        <ext:ListItem Text="业务尾款" Value="1" />
                                                    </ext:DropDownList>
                                                    <ext:Label ID="lblApplyMoney" runat="server" Label="金额">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:DropDownList ID="ddlstPayType" runat="server" Label="付款方式" Enabled="false">
                                                        <ext:ListItem Text="转账" Value="0" Selected="true" />
                                                        <ext:ListItem Text="现金" Value="1" />
                                                    </ext:DropDownList>
                                                    <ext:DatePicker ID="dpkPayDate" runat="server" Label="付款日期" Enabled="false">
                                                    </ext:DatePicker>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextBox ID="taaOther" runat="server" Label="备注" Height="60px" MaxLength="100"
                                                        Enabled="false" MaxLengthMessage="最多只能输入100个字!">
                                                    </ext:TextBox>
                                                </Items>
                                            </ext:FormRow>
                                        </Rows>
                                    </ext:Form>
                                </Items>
                            </ext:Tab>
                            <ext:Tab ID="Tab2" Title="确认历史" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Grid ID="gridCostApproveHistory" Title="Grid1" ShowBorder="true" ShowHeader="false"
                                        runat="server" EnableRowNumber="True" AutoScroll="true" AutoHeight="true" OnRowDataBound="gridApproveHistory_RowDataBound">
                                        <Columns>
                                            <ext:BoundField DataField="ApproverName" HeaderText="执行人" />
                                            <ext:BoundField DataField="ApproveTime" HeaderText="执行时间" />
                                            <ext:BoundField DataField="ApproveOp" HeaderText="执行结果" />
                                            <ext:BoundField DataField="ApproverSugest" HeaderText="执行人意见" DataTooltipField="ApproverSugest"
                                                ExpandUnusedSpace="true" />
                                        </Columns>
                                    </ext:Grid>
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
