<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalaryMsgApplyList.aspx.cs"
    Inherits="TZMS.Web.SalaryMsgApplyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="pelMain" HideScrollbar="true"
        runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" ShowBorder="false" ShowHeader="false"
        Layout="Anchor">
        <Items>
            <ext:Form ID="Form2" ShowBorder="False" LabelWidth="55px" BodyPadding="5px" AnchorValue="100%"
                EnableBackgroundColor="true" ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <ext:DropDownList ID="ddlState" runat="server" Label="申请状态">
                                <ext:ListItem Text="审批中" Value="0" Selected="true" />
                                <ext:ListItem Text="归档" Value="2" />
                                <ext:ListItem Text="未通过" Value="1" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstYear" runat="server" Label="年份">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstMonth" runat="server" Label="月份">
                                <ext:ListItem Text="1" Value="1" />
                                <ext:ListItem Text="2" Value="2" />
                                <ext:ListItem Text="3" Value="3" />
                                <ext:ListItem Text="4" Value="4" />
                                <ext:ListItem Text="5" Value="5" />
                                <ext:ListItem Text="6" Value="6" />
                                <ext:ListItem Text="7" Value="7" />
                                <ext:ListItem Text="8" Value="8" />
                                <ext:ListItem Text="9" Value="9" />
                                <ext:ListItem Text="10" Value="10" />
                                <ext:ListItem Text="11" Value="11" />
                                <ext:ListItem Text="12" Value="12" />
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Icon="Magnifier" Text="查询" OnClick="btnSearch_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server">
                        <Items>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:Label ID="Label3" runat="server">
                            </ext:Label>
                            <ext:Label ID="Label1" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <%--                <Toolbars>
                    <ext:Toolbar ID="toolApp" runat="server">
                        <Items>
                            <ext:Button ID="btnNewSalaryMsg" Text="薪资申请" ToolTip="薪资申请" Icon="Add" runat="server"
                                Hidden="true">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>--%>
                <Items>
                    <ext:Grid ID="gridApply" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridApply_PageIndexChange" OnRowCommand="gridApply_RowCommand"
                        OnRowDataBound="gridApply_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectId" HeaderText="ID" Hidden="true" />
                            <ext:BoundField DataField="Year" HeaderText="年" />
                            <ext:BoundField DataField="Month" HeaderText="月" />
                            <ext:BoundField DataField="CreateTime" HeaderText="申请时间" />
                            <ext:BoundField DataField="state" HeaderText="申请状态" />
                            <ext:BoundField DataField="CurrentCheckerID" HeaderText="当前执行人" ExpandUnusedSpace="true" />
                            <ext:LinkButtonField Width="38px" Text="申请" CommandName="View" />
                            <ext:LinkButtonField Width="38px" Text="查看" CommandName="View" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndApply" Title="" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="500px"
        Width="700px" OnClose="wndApply_Close">
    </ext:Window>
    </form>
</body>
</html>
