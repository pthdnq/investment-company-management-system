<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkerAttend.aspx.cs" Inherits="TZMS.Web.WorkerAttend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>员工考勤</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="pelMain" HideScrollbar="true"
        EnableAjax="false" runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" ShowBorder="false" ShowHeader="false"
        Layout="Anchor">
        <Items>
            <ext:Form ID="Form2" ShowBorder="False" LabelWidth="55px" BodyPadding="5px" AnchorValue="100%"
                EnableBackgroundColor="true" ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:TextBox ID="tbxSearch" runat="server" EmptyText="请输入姓名或账号查询" ShowLabel="false">
                            </ext:TextBox>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
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
                            <ext:Button ID="btnExport" Text="导出" ToolTip="导出到Excel" IconUrl="~/Images/xls.gif"
                                runat="server" OnClick="btnExport_Click">
                            </ext:Button>
                            <ext:Button ID="btnImport" Text="导入..." ToolTip="导入考勤信息" Icon="Add" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridAttend" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridAttend_PageIndexChange" OnRowDataBound="gridAttend_RowDataBound">
                        <Columns>
                            <ext:BoundField HeaderText="日期" />
                            <ext:BoundField HeaderText="工号" />
                            <ext:BoundField HeaderText="姓名" />
                            <ext:BoundField HeaderText="帐号" />
                            <ext:BoundField HeaderText="星期" />
                            <ext:BoundField HeaderText="上班时间" />
                            <ext:BoundField HeaderText="下班时间" />
                            <ext:BoundField HeaderText="备注" ExpandUnusedSpace="true" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndImportAttend" Title="导入考勤" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Width="450px" EnableConfirmOnClose="true"
        Height="191px" OnClose="wndImportAttend_Close">
    </ext:Window>
    </form>
</body>
</html>
