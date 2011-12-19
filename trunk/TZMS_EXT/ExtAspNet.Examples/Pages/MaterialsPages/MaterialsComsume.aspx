<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialsComsume.aspx.cs"
    Inherits="TZMS.Web.MaterialsComsume" %>

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
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                        AutoHeight="true" Height="335px">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="目前申请领用" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Grid ID="gridApply" Title="Grid1" ShowBorder="true" ShowHeader="false" runat="server"
                                        IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true" AutoHeight="true"
                                        OnRowCommand="gridApply_RowCommand" OnRowDataBound="gridApply_RowDataBound">
                                        <Columns>
                                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                                            <ext:BoundField DataField="UserName" HeaderText="员工姓名" />
                                            <ext:BoundField DataField="UserDept" HeaderText="部门" />
                                            <ext:BoundField DataField="ApplyCount" HeaderText="申请数量" />
                                            <ext:BoundField DataField="Other" HeaderText="备注" ExpandUnusedSpace="true" DataTooltipField="Other" />
                                            <ext:BoundField DataField="ApplyTime" HeaderText="申请时间" />
                                            <ext:LinkButtonField Width="70px" Text="确认领用" CommandName="Comsume" />
                                        </Columns>
                                    </ext:Grid>
                                </Items>
                            </ext:Tab>
                            <ext:Tab ID="Tab2" Title="领用历史" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Grid ID="gridComsumeHistory" Title="Grid1" ShowBorder="true" ShowHeader="false"
                                        runat="server" EnableRowNumber="True" AutoScroll="true" AutoHeight="true" OnRowDataBound="gridComsumeHistory_RowDataBound">
                                        <Columns>
                                            <ext:BoundField DataField="UserName" HeaderText="员工姓名" />
                                            <ext:BoundField DataField="UserDept" HeaderText="部门" />
                                            <ext:BoundField DataField="ApplyCount" HeaderText="申请数量" />
                                            <ext:BoundField DataField="ActualCount" HeaderText="领用数量" />
                                            <ext:BoundField HeaderText="领用时间" />
                                        </Columns>
                                    </ext:Grid>
                                </Items>
                            </ext:Tab>
                        </Tabs>
                    </ext:TabStrip>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndComsume" Title="物资领用" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="500px"
        Width="700px" OnClose="wndComsume_Close">
    </ext:Window>
    </form>
</body>
</html>
