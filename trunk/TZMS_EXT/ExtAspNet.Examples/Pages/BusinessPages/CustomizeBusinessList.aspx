<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomizeBusinessList.aspx.cs" Inherits="TZMS.Web.CustomizeBusinessList" %>

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
                            <ext:TextBox ID="tbxSearch" runat="server" EmptyText="请输入公司名称查询" ShowLabel="false">
                            </ext:TextBox>
                            <ext:DropDownList ID="ddlstAproveState" runat="server" Label="业务状态">
                                <ext:ListItem Text="未完成" Value="0" Selected="true" />
                                <ext:ListItem Text="已完成" Value="1" />
                                <ext:ListItem Text="异常终止" Value="2" />
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
                            </ext:Button>
                            <ext:Label ID="Label1" runat="server">
                            </ext:Label>
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
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -60"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="toolApp" runat="server">
                        <Items>
                            <ext:Button ID="btnNewNormalBusiness" Text="新增定制业务" ToolTip="新增定制业务" Icon="Add" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridCustomizeBusiness" Title="Grid1" ShowBorder="true" 
                        ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" 
                        AutoHeight="true" OnPageIndexChange="gridCustomizeBusiness_PageIndexChange" 
                        OnRowCommand="gridCustomizeBusiness_RowCommand" 
                        OnRowDataBound="gridCustomizeBusiness_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="CreaterID" Hidden="true" />
                            <ext:BoundField DataField="BusinessType" Hidden="true" />
                            <ext:BoundField DataField="CompanyName" HeaderText="公司名称" ExpandUnusedSpace="true"
                                DataTooltipField="CompanyName" />
                            <ext:BoundField DataField="CurrentBusinessRecordID" HeaderText="当前办理流程" />
                            <ext:BoundField DataField="State" HeaderText="业务状态" />
                            <ext:LinkButtonField Width="38px" Text="查看" CommandName="View" />
                            <ext:LinkButtonField Width="60px" Text="成本变更" CommandName="Change" />
                            <ext:LinkButtonField Width="38px" Text="编辑" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="删除" CommandName="Delete" ConfirmTarget="Parent"
                                ConfirmText="确定删除该业务?" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNewCustomizeBusiness" Title="新增定制业务" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true"
        Height="540px" Width="700px" onclose="wndNewCustomizeBusiness_Close" >
    </ext:Window>
    </form>
</body>
</html>
