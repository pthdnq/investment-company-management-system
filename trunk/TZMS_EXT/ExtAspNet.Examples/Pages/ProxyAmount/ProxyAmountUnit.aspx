<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProxyAmountUnit.aspx.cs"
    Inherits="TZMS.Web.ProxyAmountUnit" %>

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
                    <ext:FormRow>
                        <Items>
                            <ext:TextBox ID="tbxSearch" runat="server" EmptyText="请输入单位名称查询" ShowLabel="false">
                            </ext:TextBox>
                            <ext:Button ID="btnSearch" runat="server" Icon="Magnifier" Text="查询" OnClick="btnSearch_Click">
                            </ext:Button>
                            <ext:Label ID="Label1" runat="server">
                            </ext:Label>
                            <ext:Label ID="Label2" runat="server">
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
                            <ext:Button ID="btnNewUnit" Text="添加单位" ToolTip="添加单位" Icon="Add" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridProxyAmountUnit" Title="Grid1" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" IsDatabasePaging="true" EnableRowNumber="True"
                        AutoHeight="true" OnPageIndexChange="gridProxyAmountUnit_PageIndexChange" OnRowCommand="gridProxyAmountUnit_RowCommand"
                        OnRowDataBound="gridProxyAmountUnit_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="AccountancyID" Hidden="true" />
                            <ext:BoundField DataField="UnitName" Width="250px" HeaderText="单位名称" />
                            <ext:BoundField DataField="UnitAddress" HeaderText="单位地址" DataTooltipField="UnitAddress"
                                ExpandUnusedSpace="true" />
                            <ext:BoundField DataField="Other" HeaderText="备注" DataTooltipField="Other" />
                            <ext:BoundField DataField="UserName" Width="70px" HeaderText="代账会计" />
                            <ext:LinkButtonField Width="38px" Text="查看" CommandName="View" />
                            <ext:LinkButtonField Width="38px" Text="编辑" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="删除" ConfirmTarget="Parent" ConfirmText="确定删除该单位?"
                                CommandName="Delete" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndProxyAmountUnit" Title="新增代帐单位" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" Target="Parent" runat="server" IsModal="true" Width="700px"
        EnableConfirmOnClose="true" Height="500px" OnClose="wndProxyAmountUnit_Close">
    </ext:Window>
    </form>
</body>
</html>
