<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaoxiaoApplyList.aspx.cs"
    Inherits="TZMS.Web.BaoxiaoApplyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报销列表</title>
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
                    <ext:FormRow>
                        <Items>
                            <ext:DropDownList ID="ddlState" runat="server" Label="申请状态">
                                <ext:ListItem Text="审批中" Value="0" Selected="true" />
                                <ext:ListItem Text="归档" Value="2" />
                                <ext:ListItem Text="未通过" Value="1" />
                            </ext:DropDownList>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Button ID="btnSearch" runat="server" Icon="Magnifier" Text="查询" OnClick="btnSearch_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="toolApp" runat="server">
                        <Items>
                            <ext:Button ID="btnNewBaoxiao" Text="报销申请" ToolTip="报销申请" Icon="Add" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridBaoxiao" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridBaoxiao_PageIndexChange" OnRowCommand="gridBaoxiao_RowCommand"
                        OnRowDataBound="gridBaoxiao_RowDataBound">
                        <Columns>
                            <ext:BoundField Width="140px" DataField="ObjectId" HeaderText="ID" Hidden="true" />
                            <ext:BoundField DataField="CheckerId" HeaderText="ID" Hidden="true" />
                            <ext:BoundField Width="130px" DataField="ApplyTime" HeaderText="申请时间" />
                            <ext:BoundField Width="110px" DataField="StartTime" HeaderText="开始日期" />
                            <ext:BoundField Width="110px" DataField="EndTime" HeaderText="结束日期" />
                            <ext:BoundField Width="80px" DataField="MoneyEx" HeaderText="金额(元)" />
                            <ext:BoundField DataField="Sument" HeaderText="事项" ExpandUnusedSpace="true" DataTooltipField="Sument" />
                            <ext:BoundField Width="10px" Hidden="true" DataField="Other" HeaderText="备注" DataTooltipField="Other" />
                            <ext:BoundField Width="70px" DataField="CheckerName" HeaderText="当前执行人" />
                            <ext:BoundField Width="70px" DataField="State" HeaderText="申请状态" />
                            <ext:LinkButtonField Width="38px" Text="查看" CommandName="View" />
                            <ext:LinkButtonField Width="38px" Text="编辑" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="删除" ConfirmTarget="Parent" ConfirmText="确定删除该报销申请单?"
                                CommandName="Delete" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndBaoxiao" Title="" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="500px"
        Width="700px" OnClose="wndBaoxiao_Close">
    </ext:Window>
    </form>
</body>
</html>
