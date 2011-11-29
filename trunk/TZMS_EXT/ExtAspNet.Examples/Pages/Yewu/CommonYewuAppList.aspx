<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommonYewuAppList.aspx.cs"
    Inherits="TZMS.Web.CommonYewuAppList" %>

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
                            <ext:DropDownList ID="ddlstState" runat="server" Label="操作状态">
                                <ext:ListItem Text="待操作" Value="0" Selected="true" />
                                <ext:ListItem Text="已操作" Value="1" />
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" 
                                OnClick="btnSearch_Click">
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
                            <%-- <ext:Button ID="btnNewYewu" Text="新建普通业务" ToolTip="新建普通业务" Icon="Add" runat="server">
                            </ext:Button>--%>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridYewu" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridYewu_PageIndexChange" OnRowCommand="gridYewu_RowCommand"
                        OnRowDataBound="gridYewu_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="Title" Width="300px" HeaderText="业务标题" DataTooltipField="Title" />
                            <ext:BoundField DataField="ObjectID" Hidden="true" HeaderText="业务内容" DataTooltipField="Sument" />
                            <ext:BoundField DataField="CurrentCheckerID" HeaderText="当前负责人" />
                            <ext:BoundField DataField="CheckOp" HeaderText="当前操作" />
                            <ext:BoundField DataField="State" Width="60px" HeaderText="状态" />
                            <ext:LinkButtonField Width="38px" Text="操作" CommandName="CZ" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNewYewu" Title="普通业务操作" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="500px"
        Width="700px" OnClose="wndNewYewu_Close">
    </ext:Window>
    </form>
</body>
</html>
