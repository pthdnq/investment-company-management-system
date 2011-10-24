<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveApp.aspx.cs" Inherits="TZMS.Web.Pages.attendance.LeaveApp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>请假申请</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="pelMain" HideScrollbar="true"
        runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" ShowBorder="false" ShowHeader="false"
        Layout="Anchor">
        <Items>
            <ext:Form ID="Form2" ShowBorder="False" BodyPadding="5px" AnchorValue="100%" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:DropDownList ID="ddlappState" AutoPostBack="true" runat="server" Width="100px"
                                Label="状态">
                                <ext:ListItem Text="审批中" Value="1" Selected="true" />
                                <ext:ListItem Text="已审批" Value="0" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddldateRange" AutoPostBack="true" runat="server" Width="100px"
                                Label="日期范围">
                                <ext:ListItem Text="全部" Value="0" />
                                <ext:ListItem Text="一周内" Value="1" Selected="true" />
                                <ext:ListItem Text="一月内" Value="2" />
                                <ext:ListItem Text="三月内" Value="3" />
                                <ext:ListItem Text="半年内" Value="4" />
                                <ext:ListItem Text="一年内" Value="5" />
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="toolApp" runat="server">
                        <Items>
                            <ext:Button ID="btnNewApp" Text="我要请假" ToolTip="我要请假" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridUser" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        PageSize="1" runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true">
                        <Columns>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
