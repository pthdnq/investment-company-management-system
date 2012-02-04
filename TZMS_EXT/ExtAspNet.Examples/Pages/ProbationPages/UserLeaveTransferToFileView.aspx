<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLeaveTransferToFileView.aspx.cs"
    Inherits="TZMS.Web.UserLeaveTransferToFileView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" ShowHeader="false">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Text="关闭" Icon="Cancel" runat="server" OnClick="btnClose_Click">
                    </ext:Button>
                    <ext:Button ID="btnSubmit" Text="确认归档" Icon="Accept" runat="server" ValidateForms="pelMain"
                        OnClick="btnSubmit_Click" ConfirmText="您确定归档吗?">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Grid ID="gridTransfer" Title="Grid1" ShowBorder="true" ShowHeader="false" runat="server"
                        IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true" AutoHeight="true"
                        OnRowDataBound="gridTransfer_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="TransferName" HeaderText="交接人" />
                            <ext:BoundField DataField="TransferTime" HeaderText="交接时间" />
                            <ext:BoundField DataField="TransferType" HeaderText="交接类型" />
                            <ext:BoundField DataField="Other" HeaderText="交接内容" DataTooltipField="Other" ExpandUnusedSpace="true" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
