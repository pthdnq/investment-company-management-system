<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialsPurchaseImport.aspx.cs"
    Inherits="TZMS.Web.MaterialsPurchaseImport" %>

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
                    <ext:Button ID="btnPass" Text="入库" Icon="Accept" runat="server" ValidateForms="mainForm2"
                        OnClick="btnPass_Click" ConfirmText="您确定入库吗?">
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
                                    <ext:TextBox ID="tbxImportCount" runat="server" Required="true" ShowRedStar="true"
                                        Label="数量" Regex="^\d*$" RegexMessage="只能输入数字!">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxImportMoney" runat="server" Required="true" ShowRedStar="true"
                                        Label="金额" Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="金额格式不正确!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                        AutoHeight="true" Height="335px">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="物资申请单" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Form EnableBackgroundColor="true" LabelWidth="55px" ShowHeader="false" ShowBorder="false"
                                        BodyPadding="5px" ID="mainForm" runat="server">
                                        <Rows>
                                            <ext:FormRow ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:Label ID="lblName" runat="server" Label="申请人">
                                                    </ext:Label>
                                                    <ext:Label ID="lblApplyTime" runat="server" Label="申请时间">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="frw2" runat="server" ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:Label ID="ddlstType" runat="server" Label="物资类型">
                                                    </ext:Label>
                                                    <ext:Label ID="ddlstMaterialName" runat="server" Label="物资名称">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:Label ID="tbxCount" runat="server" Label="数量">
                                                    </ext:Label>
                                                    <ext:Label ID="tbxMoney" runat="server" Label="金额">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:Label ID="dpkNeedsDate" runat="server" Label="需要日期">
                                                    </ext:Label>
                                                    <ext:Label ID="Label1" runat="server">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextArea ID="taaSument" runat="server" Label="申请事由" Height="100px" Enabled="false">
                                                    </ext:TextArea>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextArea ID="taaOther" runat="server" Label="备注" Height="60px" Enabled="false">
                                                    </ext:TextArea>
                                                </Items>
                                            </ext:FormRow>
                                        </Rows>
                                    </ext:Form>
                                </Items>
                            </ext:Tab>
                            <ext:Tab ID="Tab2" Title="审批历史" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Grid ID="gridApproveHistory" Title="Grid1" ShowBorder="true" ShowHeader="false"
                                        runat="server" EnableRowNumber="True" AutoScroll="true" AutoHeight="true" OnRowDataBound="gridApproveHistory_RowDataBound">
                                        <Columns>
                                            <ext:BoundField DataField="ApproverName" HeaderText="执行人" />
                                            <ext:BoundField DataField="ApproveTime" HeaderText="执行时间" />
                                            <ext:BoundField DataField="ApproveOp" HeaderText="执行结果" />
                                            <ext:BoundField DataField="ApproveSugest" HeaderText="执行人意见" DataTooltipField="ApproveSugest"
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
