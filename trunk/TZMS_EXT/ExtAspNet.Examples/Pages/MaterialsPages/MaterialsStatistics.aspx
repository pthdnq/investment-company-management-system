<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialsStatistics.aspx.cs"
    Inherits="TZMS.Web.MaterialsStatistics" %>

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
                            <ext:TextBox ID="tbxSearch" runat="server" EmptyText="请输入姓名或物资名称查询" ShowLabel="false">
                            </ext:TextBox>
                            <ext:DropDownList ID="ddlstType" runat="server" Label="物资类型">
                                <ext:ListItem Text="全部" Value="all" Selected="true" />
                                <ext:ListItem Text="办公用品" Value="0" />
                                <ext:ListItem Text="固定资产" Value="1" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstDept" runat="server" Label="部门名称">
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
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -60"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridComsumeHistory" Title="Grid1" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" IsDatabasePaging="true" EnableRowNumber="True"
                        AutoHeight="true" OnRowCommand="gridComsumeHistory_RowCommand" OnRowDataBound="gridComsumeHistory_RowDataBound"
                        OnPageIndexChange="gridComsumeHistory_PageIndexChange">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="MaterialsID" Hidden="true" />
                            <ext:BoundField DataField="MaterialsType" HeaderText="物资类型" />
                            <ext:BoundField DataField="MaterialsName" HeaderText="物资名称" />
                            <ext:BoundField DataField="TotalNumber" HeaderText="总领用数量" />
                            <ext:BoundField DataField="TotalCount" HeaderText="总领用次数" />
                            <ext:BoundField DataField="UserName" HeaderText="员工姓名" />
                            <ext:BoundField DataField="UserDept" HeaderText="部门" />
                            <ext:BoundField DataField="ActualCount" HeaderText="领用数量" />
                            <ext:BoundField DataField="ApproveTime" HeaderText="领用时间" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
