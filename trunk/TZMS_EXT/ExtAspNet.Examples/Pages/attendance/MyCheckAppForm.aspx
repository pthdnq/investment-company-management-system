<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCheckAppForm.aspx.cs"
    Inherits="TZMS.Web.MyCheckAppForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>审批</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" ShowHeader="false">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Text="关闭" Icon="Cancel" runat="server" OnClick="btnClose_Click">
                    </ext:Button>
                    <ext:Button ID="btnPass" Text="通过" Icon="Accept" runat="server" OnClick="btnPass_Click">
                    </ext:Button>
                    <ext:Button ID="btnRefuse" Text="打回" Icon="Stop" runat="server" OnClick="btnRefuse_Click">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="Form2"
                        runat="server">
                        <Rows>
                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstNext" runat="server"
                                        Label="下一步" AutoPostBack="true" OnSelectedIndexChanged="ddlstNext_SelectedIndexChanged">
                                    </ext:DropDownList>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUser" runat="server"
                                        Label="执行人">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextArea ID="taaApproveComment" Height="50px" runat="server" Label="审批意见">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:TabStrip runat="server" ActiveTabIndex="0" ShowBorder="false" AutoHeight="true"
                        Height="280px">
                        <Tabs>
                            <ext:Tab Title="请假申请单" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="mainForm"
                                        runat="server">
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
                                                    <ext:Label ID="lblStartTime" runat="server" Label="开始日期">
                                                    </ext:Label>
                                                    <ext:Label ID="lblStopTime" runat="server" Label="结束日期">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:Label ID="lblLeaveType" runat="server" Label="请假类型">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:TextArea ID="taaLeaveReason" Height="100px" runat="server" Label="请假原因" Enabled="false">
                                                    </ext:TextArea>
                                                </Items>
                                            </ext:FormRow>
                                        </Rows>
                                    </ext:Form>
                                </Items>
                            </ext:Tab>
                            <ext:Tab Title="审批历史" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Grid ID="gridApproveHistory" Title="Grid1" ShowBorder="true" ShowHeader="false"
                                        AllowPaging="true" runat="server" IsDatabasePaging="true" EnableRowNumber="True"
                                        AutoHeight="true" OnPageIndexChange="gridApproveHistory_PageIndexChange" OnRowDataBound="gridApproveHistory_RowDataBound">
                                        <Columns>
                                            <ext:BoundField DataField="ApproverName" HeaderText="审批人姓名" />
                                            <ext:BoundField DataField="ApproveTime" HeaderText="审批时间" />
                                            <ext:BoundField DataField="ApproveResult" HeaderText="审批结果" />
                                            <ext:BoundField DataField="ApproveComment" HeaderText="审批人意见" />
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
