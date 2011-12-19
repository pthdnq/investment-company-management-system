<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WuZhiApplyList.aspx.cs"
    Inherits="TZMS.Web.WuZhiApplyList" %>

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
                            <ext:TextBox ID="tbxSearch" runat="server" EmptyText="请输入标题查询" ShowLabel="false">
                            </ext:TextBox>
                            <ext:DropDownList ID="ddlstWuZhiType" runat="server" Label="物资类型">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstAproveState" runat="server" Label="申请状态">
                                <ext:ListItem Text="审批中" Value="0" Selected="true" />
                                <ext:ListItem Text="归档" Value="2" />
                                <ext:ListItem Text="未通过" Value="1" />
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server">
                        <Items>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Label ID="Label3" runat="server">
                            </ext:Label>
                            <ext:Label ID="Label4" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="toolApp" runat="server">
                        <Items>
                            <ext:Button ID="btnNewWuZhi" Text="物资申请" ToolTip="物资申请" Icon="Add" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridWuZhi" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridWuZhi_PageIndexChange" OnRowCommand="gridWuZhi_RowCommand"
                        OnRowDataBound="gridWuZhi_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectId" Hidden="true" />
                            <ext:BoundField DataField="Type" HeaderText="物资类型" />
                            <ext:BoundField DataField="Title" Width="160px" HeaderText="标题" DataTooltipField="Title" />
                            <ext:BoundField DataField="Sument" HeaderText="事项" DataTooltipField="Sument" ExpandUnusedSpace="true" />
                            <ext:BoundField DataField="Other" HeaderText="备注" Hidden="true" DataTooltipField="Other" />
                            <ext:BoundField DataField="ApplyTime" HeaderText="申请时间" />
                            <ext:BoundField DataField="CurrentCheckerId" HeaderText="当前执行人" />
                            <ext:BoundField DataField="State" HeaderText="申请状态" />
                            <ext:LinkButtonField Width="38px" Text="查看" CommandName="View" />
                            <ext:LinkButtonField Width="38px" Text="编辑" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="删除" ConfirmTarget="Parent" ConfirmText="确定删除该代物资申请单?" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNewWuZhi" Title="物资申请" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="500px"
        Width="700px" OnClose="wndNewWuZhi_Close">
    </ext:Window>
    </form>
</body>
</html>
