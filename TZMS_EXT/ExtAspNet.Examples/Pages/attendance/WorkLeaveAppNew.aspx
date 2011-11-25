<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkLeaveAppNew.aspx.cs" Inherits="TZMS.Web.WorkLeaveAppNew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>调休申请</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" ShowHeader="false">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" OnClick="btnClose_Click" runat="server" Icon="Cancel" Text="关闭">
                    </ext:Button>
                    <ext:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Icon="Disk" Text="提交"
                        ValidateForms="mainForm" ConfirmText="您确定提交该表单吗?">
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
                                        Label="下一步" AutoPostBack="True" OnSelectedIndexChanged="ddlstNext_SelectedIndexChanged">
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
                                            <ext:FormRow ID="FormRow1" runat="server">
                                                <Items>
                                                    <ext:DatePicker ID="dpkStartTime" ShowRedStar="true" Required="true" runat="server"
                                                        Label="开始时间">
                                                    </ext:DatePicker>
                                                    <ext:DropDownList ID="ddlstStartHour" runat="server" ShowLabel="false" Width="70 px">
                                                        <ext:ListItem Text="0点" Value="0" Selected="true" />
                                                        <ext:ListItem Text="1点" Value="1" />
                                                        <ext:ListItem Text="2点" Value="2" />
                                                        <ext:ListItem Text="3点" Value="3" />
                                                        <ext:ListItem Text="4点" Value="4" />
                                                        <ext:ListItem Text="5点" Value="5" />
                                                        <ext:ListItem Text="6点" Value="6" />
                                                        <ext:ListItem Text="7点" Value="7" />
                                                        <ext:ListItem Text="8点" Value="8" />
                                                        <ext:ListItem Text="9点" Value="9" />
                                                        <ext:ListItem Text="10点" Value="10" />
                                                        <ext:ListItem Text="11点" Value="11" />
                                                        <ext:ListItem Text="12点" Value="12" />
                                                        <ext:ListItem Text="13点" Value="13" />
                                                        <ext:ListItem Text="14点" Value="14" />
                                                        <ext:ListItem Text="15点" Value="15" />
                                                        <ext:ListItem Text="16点" Value="16" />
                                                        <ext:ListItem Text="17点" Value="17" />
                                                        <ext:ListItem Text="18点" Value="18" />
                                                        <ext:ListItem Text="19点" Value="19" />
                                                        <ext:ListItem Text="20点" Value="20" />
                                                        <ext:ListItem Text="21点" Value="21" />
                                                        <ext:ListItem Text="22点" Value="22" />
                                                        <ext:ListItem Text="23点" Value="23" />
                                                    </ext:DropDownList>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:DatePicker ID="dpkEndTime" ShowRedStar="true" Required="true" runat="server"
                                                        Label="结束时间">
                                                    </ext:DatePicker>
                                                    <ext:DropDownList ID="ddlstEndHour" runat="server" ShowLabel="false" Width="70px">
                                                        <ext:ListItem Text="0点" Value="0" Selected="true" />
                                                        <ext:ListItem Text="1点" Value="1" />
                                                        <ext:ListItem Text="2点" Value="2" />
                                                        <ext:ListItem Text="3点" Value="3" />
                                                        <ext:ListItem Text="4点" Value="4" />
                                                        <ext:ListItem Text="5点" Value="5" />
                                                        <ext:ListItem Text="6点" Value="6" />
                                                        <ext:ListItem Text="7点" Value="7" />
                                                        <ext:ListItem Text="8点" Value="8" />
                                                        <ext:ListItem Text="9点" Value="9" />
                                                        <ext:ListItem Text="10点" Value="10" />
                                                        <ext:ListItem Text="11点" Value="11" />
                                                        <ext:ListItem Text="12点" Value="12" />
                                                        <ext:ListItem Text="13点" Value="13" />
                                                        <ext:ListItem Text="14点" Value="14" />
                                                        <ext:ListItem Text="15点" Value="15" />
                                                        <ext:ListItem Text="16点" Value="16" />
                                                        <ext:ListItem Text="17点" Value="17" />
                                                        <ext:ListItem Text="18点" Value="18" />
                                                        <ext:ListItem Text="19点" Value="19" />
                                                        <ext:ListItem Text="20点" Value="20" />
                                                        <ext:ListItem Text="21点" Value="21" />
                                                        <ext:ListItem Text="22点" Value="22" />
                                                        <ext:ListItem Text="23点" Value="23" />
                                                    </ext:DropDownList>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow10" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:DropDownList ShowRedStar="true" Required="true" ID="ddlstLeaveType" runat="server"
                                                        Label="请假类型" AutoPostBack="True">
                                                    </ext:DropDownList>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow12" runat="server" ColumnWidths="50% 50%">
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
