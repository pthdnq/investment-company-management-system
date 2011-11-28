<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommonYewu.aspx.cs" Inherits="TZMS.Web.CommonYewu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>业务部-通用流程（固定的）</title>
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
                            <%--                            <ext:DropDownList ID="ddlstAproveState" runat="server" Label="申请状态">
                                <ext:ListItem Text="审批中" Value="0" Selected="true" />
                                <ext:ListItem Text="归档" Value="2" />
                                <ext:ListItem Text="未通过" Value="1" />
                            </ext:DropDownList>--%>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier">
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
                            <ext:Button ID="btnNewYewu" Text="新建普通业务" ToolTip="新建普通业务" Icon="Add" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridYewu" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridYewu_PageIndexChange" OnRowCommand="gridYewu_RowCommand"
                        OnRowDataBound="gridYewu_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectId" Hidden="true" />
                            <ext:BoundField DataField="Type" HeaderText="物资类型" />
                            <ext:BoundField DataField="Title" Width="160px" HeaderText="业务标题" DataTooltipField="Title" />
                            <ext:BoundField DataField="Sument" HeaderText="业务内容" DataTooltipField="Sument" ExpandUnusedSpace="true" />
                            <ext:BoundField DataField="Other" HeaderText="当前责任人" Hidden="true" DataTooltipField="Other" />
                            <ext:BoundField DataField="ApplyTime" HeaderText="状态" />
                            <ext:LinkButtonField Width="38px" Text="转交" CommandName="View" />
                            <ext:LinkButtonField Width="38px" Text="核名" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="刻章" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="开户" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="验资报告" CommandName="View" />
                            <ext:LinkButtonField Width="38px" Text="营业执照" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="办代码证" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="国地税" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="转基本户" ConfirmTarget="Parent" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNewWuZhi" Title="新建普通业务" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="500px"
        Width="700px" OnClose="wndNewYewu_Close">
    </ext:Window>
    </form>
</body>
</html>
