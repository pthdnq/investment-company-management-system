<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiangChengConfirmList.aspx.cs"
    Inherits="TZMS.Web.JiangChengConfirmList" %>

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
                            <ext:DropDownList ID="ddlstAproveState" runat="server" Label="奖惩类型">
                                <ext:ListItem Text="全部" Value="3" Selected="true" />
                                <ext:ListItem Text="奖励" Value="0" />
                                <ext:ListItem Text="惩罚" Value="1" />
                            </ext:DropDownList>
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
                <Items>
                    <ext:Grid ID="gridConfirm" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridConfirm_PageIndexChange" OnRowCommand="gridConfirm_RowCommand"
                        OnRowDataBound="gridConfirm_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="UserID" Hidden="true" />
                            <ext:BoundField DataField="ZjID" Hidden="true" />
                            <ext:BoundField DataField="UserName" HeaderText="奖惩人" />
                            <ext:BoundField DataField="UserDept" HeaderText="部门" />
                            <ext:BoundField DataField="Type" HeaderText="奖惩类型" />
                            <ext:BoundField DataField="Reason" HeaderText="奖惩原因" DataTooltipField="Reason" ExpandUnusedSpace="true" />
                            <ext:BoundField DataField="CreateTime" HeaderText="下发时间" />
                            <ext:BoundField DataField="ZJName" HeaderText="部门总监" />
                            <ext:BoundField DataField="State" HeaderText="确认状态" />
                            <ext:LinkButtonField Width="38px" Text="确认" CommandName="Confirm" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndConfirm" Title="奖惩单确认" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="500px"
        Width="700px" OnClose="wndConfirm_Close">
    </ext:Window>
    </form>
</body>
</html>
