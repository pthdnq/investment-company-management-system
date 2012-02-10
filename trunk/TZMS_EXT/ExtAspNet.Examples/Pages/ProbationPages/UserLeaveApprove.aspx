﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLeaveApprove.aspx.cs"
    Inherits="TZMS.Web.UserLeaveApprove" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" EnableAjax="false" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" ShowHeader="false">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Text="关闭" Icon="Cancel" runat="server" OnClick="btnClose_Click">
                    </ext:Button>
                    <ext:Button ID="btnPass" Text="同意" Icon="Accept" runat="server" ValidateForms="frmApprove"
                        OnClick="btnPass_Click" ConfirmText="您确定同意吗?">
                    </ext:Button>
                    <ext:Button ID="btnRefuse" Text="不同意" Icon="Stop" runat="server" OnClick="btnRefuse_Click"
                        ValidateForms="frmApprove" ConfirmText="您确定不同意吗?">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form ID="frmApprove" EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px"
                        runat="server" LabelWidth="100px">
                        <Rows>
                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstNext" runat="server"
                                        AutoPostBack="true" Label="下一步" OnSelectedIndexChanged="ddlstNext_SelectedIndexChanged">
                                    </ext:DropDownList>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUser" runat="server"
                                        RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="执行人">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:DropDownList ID="ddlstTransferSSDept" runat="server" ShowRedStar="true" Required="true"
                                        Label="所属部门交接人" Hidden="true" Enabled="false">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="ddlstTransferXZDept" runat="server" ShowRedStar="true" Required="true"
                                        Label="行政部交接人" Hidden="true" Enabled="false">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow9" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:DropDownList ID="ddlstTransferCWDept" runat="server" ShowRedStar="true" Required="true"
                                        Label="财务部交接人" Hidden="true" Enabled="false">
                                    </ext:DropDownList>
                                    <ext:Label ID="Label2" runat="server" Hidden="true">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextArea ID="taaApproveSugest" Height="50px" runat="server" Label="审批意见" MaxLength="100"
                                        MaxLengthMessage="最多只能输入100个字！">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                        AutoHeight="true" Height="335px">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="离职申请单" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Form EnableBackgroundColor="true" LabelWidth="75px" ShowHeader="false" ShowBorder="false"
                                        BodyPadding="5px" ID="mainForm" runat="server">
                                        <Rows>
                                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:Label ID="lblName" runat="server" Label="申请人">
                                                    </ext:Label>
                                                    <ext:Label ID="lblAppDate" runat="server" Label="申请时间">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:Label ID="lblPosition" runat="server" Label="职务">
                                                    </ext:Label>
                                                    <ext:Label ID="lblLeaveDate" runat="server" Label="拟离职时间">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:Label ID="lblContractStartDate" runat="server" Label="合同开始日期">
                                                    </ext:Label>
                                                    <ext:Label ID="lblContractEndDate" runat="server" Label="合同结束日期">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:Label ID="lblLeaveType" runat="server" Label="离职类型">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow11" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextArea ID="taaLeaveReason" Label="离职原因" runat="server" Height="200px" Enabled="false">
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
                                            <ext:BoundField DataField="ApproveResult" HeaderText="执行结果" />
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
