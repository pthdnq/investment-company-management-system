﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommonYewu.aspx.cs" Inherits="TZMS.Web.CommonYewu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>业务部-通用流程（固定的）--申请页面</title>
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
                            <ext:DropDownList ID="ddlstAproveState" runat="server" Label="业务状态">
                                <ext:ListItem Text="未完成" Value="0" Selected="true" />
                                <ext:ListItem Text="已完成" Value="1" />
                                <ext:ListItem Text="异常终止" Value="2" />
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" 
                                OnClick="btnSearch_Click">
                            </ext:Button>
                            <ext:Label ID="lbl1" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36" Layout="Fit" runat="server">
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
                            <ext:BoundField DataField="Title" Width="100px" HeaderText="业务标题" DataTooltipField="Title" />
                            <ext:BoundField DataField="Sument" HeaderText="业务内容" ExpandUnusedSpace="true" DataTooltipField="Sument" />
                            <ext:BoundField DataField="CurrentCheckerId" HeaderText="当前负责人" />
                            <ext:BoundField DataField="CurrentOp" HeaderText="当前操作" />
                            <ext:BoundField DataField="State" Width="60px" HeaderText="状态" />
                            <ext:LinkButtonField Width="38px" Text="查看" CommandName="View" />
                            <ext:LinkButtonField Width="38px" Text="删除" CommandName="Delete" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNewYewu" Title="新建普通业务" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="500px"
        Width="700px" OnClose="wndNewYewu_Close">
    </ext:Window>
    </form>
</body>
</html>
