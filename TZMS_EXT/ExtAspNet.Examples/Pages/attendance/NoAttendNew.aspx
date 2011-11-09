<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoAttendNew.aspx.cs" Inherits="TZMS.Web.NoAttendNew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未打卡申请单</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" ShowHeader="false">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" OnClick="btnClose_Click" runat="server" Icon="Cancel" Text="关闭">
                    </ext:Button>
                    <ext:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Icon="Disk" Text="提交">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form EnableBackgroundColor="true" ShowHeader="false" ShowBorder="false" BodyPadding="5px"
                        ID="Form2" runat="server" LabelWidth="60px">
                        <Rows>
                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstNext" runat="server"
                                        Label="下一步">
                                    </ext:DropDownList>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUser" runat="server"
                                        Label="执行人" RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" Height="391px" ShowBorder="false">
                        <Tabs>
                            <ext:Tab ID="tabLeaveInfo" Title="未打卡申请单" EnableBackgroundColor="true" runat="server"
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
                                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:DropDownList ID="ddlstYear" runat="server" Required="true" ShowRedStar="true"
                                                        Label="年">
                                                    </ext:DropDownList>
                                                    <ext:DropDownList ID="ddlstMonth" runat="server" Required="true" ShowRedStar="true"
                                                        Label="月">
                                                        <ext:ListItem Value="1" Text="1" />
                                                        <ext:ListItem Value="2" Text="2" />
                                                        <ext:ListItem Value="3" Text="3" />
                                                        <ext:ListItem Value="4" Text="4" />
                                                        <ext:ListItem Value="5" Text="5" />
                                                        <ext:ListItem Value="6" Text="6" />
                                                        <ext:ListItem Value="7" Text="7" />
                                                        <ext:ListItem Value="8" Text="8" />
                                                        <ext:ListItem Value="9" Text="9" />
                                                        <ext:ListItem Value="10" Text="10" />
                                                        <ext:ListItem Value="11" Text="11" />
                                                        <ext:ListItem Value="12" Text="12" />
                                                    </ext:DropDownList>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextArea ID="taaSument" Height="100px" runat="server" Label="事项" Required="true"
                                                        ShowRedStar="true">
                                                    </ext:TextArea>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextArea ID="taaOther" Height="100px" runat="server" Label="备注">
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
                                            <ext:BoundField DataField="ApproveTime" HeaderText="执行时间" />
                                            <ext:BoundField DataField="ApproveResult" HeaderText="执行结果" />
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
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
