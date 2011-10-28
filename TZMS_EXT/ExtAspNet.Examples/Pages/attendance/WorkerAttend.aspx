<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkerAttend.aspx.cs" Inherits="TZMS.Web.WorkerAttend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>员工考勤</title>
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
                            <ext:TwinTriggerBox runat="server" EmptyText="请输入姓名或账号查询" ShowLabel="false" ID="ttbSearch"
                                Trigger1Icon="Search" ShowTrigger2="false">
                            </ext:TwinTriggerBox>
                            <ext:DropDownList ID="ddldateRange" AutoPostBack="true" runat="server" Label="日期范围">
                                <ext:ListItem Text="全部" Value="0" />
                                <ext:ListItem Text="一月内" Value="1" Selected="true" />
                                <ext:ListItem Text="三月内" Value="2" />
                                <ext:ListItem Text="半年内" Value="3" />
                                <ext:ListItem Text="一年内" Value="4" />
                            </ext:DropDownList>
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
                            <ext:Button ID="Button1" Text="导出" ToolTip="导出到Excel" IconUrl="~/Images/xls.gif"
                                runat="server">
                            </ext:Button>
                            <ext:Button ID="btnNewApp" Text="导入..." ToolTip="导入考勤信息" Icon="Add" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridAttend" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true">
                        <Columns>
                            <ext:BoundField HeaderText="日期" />
                            <ext:BoundField HeaderText="工号" />
                            <ext:BoundField HeaderText="姓名" />
                            <ext:BoundField HeaderText="帐号" />
                            <ext:BoundField HeaderText="上班时间" />
                            <ext:BoundField HeaderText="下班时间" />
                            <ext:BoundField HeaderText="缺勤原因" />
                            <ext:BoundField HeaderText="审批状态" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
