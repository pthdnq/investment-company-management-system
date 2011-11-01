﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveAppNew.aspx.cs" Inherits="TZMS.Web.LeaveAppNew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>请假申请</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Height="317px" Title="Panel" AutoScroll="false" ShowBorder="true"
        ShowHeader="false">
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button ID="btnClose" OnClick="btnClose_Click" runat="server" Icon="Cancel" Text="关闭">
                    </ext:Button>
                    <ext:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Icon="Disk" Text="提交"
                        ValidateForms="mainForm">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                AutoHeight="true" Height="280px">
                <Tabs>
                    <ext:Tab ID="tabLeaveInfo" Title="请假申请单" EnableBackgroundColor="true" runat="server"
                        BodyPadding="5px">
                        <Items>
                            <ext:Form EnableBackgroundColor="true" ShowHeader="false" ShowBorder="false" BodyPadding="5px"
                                ID="mainForm" runat="server" LabelWidth="60px">
                                <Rows>
                                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="lblName" runat="server" Label="申请人">
                                            </ext:Label>
                                            <ext:Label ID="lblAppDate" runat="server" Label="申请时间">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstNext" runat="server"
                                                Label="下一步" AutoPostBack="True" OnSelectedIndexChanged="ddlstNext_SelectedIndexChanged">
                                            </ext:DropDownList>
                                            <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUser" runat="server"
                                                Label="执行人" RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！">
                                            </ext:DropDownList>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:DatePicker ID="dpkStartTime" ShowRedStar="true" Required="true" runat="server"
                                                Label="开始日期">
                                            </ext:DatePicker>
                                            <ext:DatePicker ID="dpkEndTime" ShowRedStar="true" Required="true" runat="server"
                                                Label="结束日期">
                                            </ext:DatePicker>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow runat="server" ColumnWidths="60%">
                                        <Items>
                                            <ext:DropDownList ShowRedStar="true" Required="true" ID="ddlstLeaveType" runat="server"
                                                Label="请假类型">
                                            </ext:DropDownList>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextArea ID="taaLeaveReason" ShowRedStar="true" MaxLength="100" MaxLengthMessage="最多只能输入100个字！"
                                                Height="100px" Required="true" runat="server" Label="请假原因">
                                            </ext:TextArea>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="tabApproveHistory" Title="审批历史" EnableBackgroundColor="true" runat="server"
                        BodyPadding="5px">
                        <Items>
                            <ext:Grid ID="gridApproveHistory" Title="Grid1" ShowBorder="true" ShowHeader="false"
                                runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                                AutoScroll="true" OnRowDataBound="gridApproveHistory_RowDataBound">
                                <Columns>
                                    <ext:BoundField DataField="ApproverName" HeaderText="执行人" />
                                    <ext:BoundField DataField="ApproveTime" HeaderText="审批时间" />
                                    <ext:BoundField DataField="ApproveResult" HeaderText="审批结果" />
                                    <ext:BoundField DataField="ApproveComment" HeaderText="执行人意见" DataTooltipField="ApproveComment"
                                        ExpandUnusedSpace="true" />
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
