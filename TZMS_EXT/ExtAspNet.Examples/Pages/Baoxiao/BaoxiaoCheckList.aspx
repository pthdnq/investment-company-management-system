<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaoxiaoCheckList.aspx.cs"
    Inherits="TZMS.Web.BaoxiaoCheckList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报销审批列表</title>
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
                            <ext:DropDownList ID="ddlstDept" runat="server" Label="部门名称" OnSelectedIndexChanged="ddlstDept_SelectedIndexChanged">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstAproveState" runat="server" Label="审批状态" OnSelectedIndexChanged="ddlstAproveState_SelectedIndexChanged">
                                <ext:ListItem Text="全部" Value="0" />
                                <ext:ListItem Text="待审批" Value="1" Selected="true" />
                                <ext:ListItem Text="已审批" Value="2" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddldateRange" AutoPostBack="true" runat="server" Label="日期范围"
                                OnSelectedIndexChanged="ddldateRange_SelectedIndexChanged" Hidden="true">
                                <ext:ListItem Text="全部" Value="0" />
                                <ext:ListItem Text="一月内" Value="1" Selected="true" />
                                <ext:ListItem Text="三月内" Value="2" />
                                <ext:ListItem Text="半年内" Value="3" />
                                <ext:ListItem Text="一年内" Value="4" />
                            </ext:DropDownList>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:TwinTriggerBox runat="server" EmptyText="请输入姓名查询" ShowLabel="false" ID="ttbSearch"
                                Trigger1Icon="Search" ShowTrigger2="false" OnTrigger1Click="ttbSearch_Trigger1Click">
                            </ext:TwinTriggerBox>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridBaoxiaoCheck" Title="Grid1" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" IsDatabasePaging="true" EnableRowNumber="True"
                        AutoHeight="true" OnPageIndexChange="gridBaoxiaoCheck_PageIndexChange" OnRowCommand="gridBaoxiaoCheck_RowCommand"
                        OnRowDataBound="gridBaoxiaoCheck_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="BaoxiaoCheckID" Hidden="true" />
                            <ext:BoundField DataField="UserName" Width="70px" HeaderText="姓名" />
                            <ext:BoundField DataField="Dept" Width="70px" HeaderText="部门" />
                            <ext:BoundField DataField="TellPhone" Width="70px" HeaderText="联系电话" />
                            <ext:BoundField DataField="ApplyTime" Width="140px" HeaderText="申请时间" />
                            <ext:BoundField DataField="StartTime" Width="140px" HeaderText="开始日期" />
                            <ext:BoundField DataField="EndTime" Width="140px" HeaderText="结束日期" />
                            <ext:BoundField DataField="Money" Width="70px" HeaderText="总金额(元)" />
                            <ext:BoundField DataField="Sument" HeaderText="事项" ExpandUnusedSpace="true" DataTooltipField="Sument" />
                            <ext:BoundField DataField="Other" Width="150px" HeaderText="备注" DataTooltipField="Other" />
                            <ext:BoundField DataField="Checkstate" Width="60px" HeaderText="审批状态" />
                            <ext:BoundField DataField="Result" Width="60px" HeaderText="审批结果" />
                            <ext:BoundField DataField="CheckDateTime" Width="140px" HeaderText="审批时间" />
                            <ext:LinkButtonField Width="38px" Text="审批" CommandName="Approve" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndBaoxiaoCheck" Title="报销审批" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="500px"
        Width="700px" OnClose="wndBaoxiaoCheck_Close">
    </ext:Window>
    </form>
</body>
</html>
