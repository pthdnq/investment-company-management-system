<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialsPurchaseImportList.aspx.cs"
    Inherits="TZMS.Web.MaterialsPurchaseImportList" %>

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
                            <ext:TextBox ID="tbxSearch" runat="server" EmptyText="请输入物资名称查询" ShowLabel="false">
                            </ext:TextBox>
                            <ext:DropDownList ID="ddlstWuZhiType" runat="server" Label="物资类型">
                                <ext:ListItem Text="全部" Value="all" Selected="true" />
                                <ext:ListItem Text="办公用品" Value="0" />
                                <ext:ListItem Text="固定资产" Value="1" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstAproveState" runat="server" Label="入库状态">
                                <ext:ListItem Text="全部" Value="-1" />
                                <ext:ListItem Text="待入库" Value="0" Selected="true" />
                                <ext:ListItem Text="已入库" Value="1" />
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server">
                        <Items>
                            <ext:DropDownList ID="ddlstDept" runat="server" Label="部门名称">
                            </ext:DropDownList>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Label ID="Label1" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -60"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridApply" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridApply_PageIndexChange" OnRowCommand="gridApply_RowCommand"
                        OnRowDataBound="gridApply_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="MaterialsID" Hidden="true" />
                            <ext:BoundField DataField="UserName" HeaderText="申请人" />
                            <ext:BoundField DataField="UserDept" HeaderText="部门" />
                            <ext:BoundField DataField="ApplyTime" HeaderText="申请时间" />
                            <ext:BoundField DataField="MaterialsType" HeaderText="物资类型" />
                            <ext:BoundField DataField="MaterialsName" HeaderText="物资名称" />
                            <ext:BoundField DataField="Count" HeaderText="申请数量" />
                            <ext:BoundField DataField="MoneyEx" HeaderText="金额" />
                            <ext:BoundField DataField="NeedsDate" HeaderText="需要日期" />
                            <ext:BoundField DataField="Sument" HeaderText="申请事由" ExpandUnusedSpace="true" DataTooltipField="Sument" />
                            <ext:BoundField DataField="HasImport" HeaderText="入库状态" />
                            <ext:BoundField DataField="ImportTime" HeaderText="入库时间" />
                            <ext:LinkButtonField Width="38px" Text="入库" CommandName="View" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNewPurchaseImport" Title="物资采购入库" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true"
        Height="500px" Width="700px" onclose="wndNewPurchaseImport_Close">
    </ext:Window>
    </form>
</body>
</html>
