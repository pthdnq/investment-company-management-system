<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MySalary.aspx.cs" Inherits="TZMS.Web.MySalary" %>

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
                            <ext:DropDownList ID="ddlstYear" runat="server" Label="年份">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstMonth" runat="server" Label="月份">
                                <ext:ListItem Text="1" Value="1" />
                                <ext:ListItem Text="2" Value="2" />
                                <ext:ListItem Text="3" Value="3" />
                                <ext:ListItem Text="4" Value="4" />
                                <ext:ListItem Text="5" Value="5" />
                                <ext:ListItem Text="6" Value="6" />
                                <ext:ListItem Text="7" Value="7" />
                                <ext:ListItem Text="8" Value="8" />
                                <ext:ListItem Text="9" Value="9" />
                                <ext:ListItem Text="10" Value="10" />
                                <ext:ListItem Text="11" Value="11" />
                                <ext:ListItem Text="12" Value="12" />
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Icon="Magnifier" Text="查询" OnClick="btnSearch_Click">
                            </ext:Button>
                            <ext:Label ID="lbl1" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridSalary" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridSalary_PageIndexChange" OnRowCommand="gridSalary_RowCommand"
                        OnRowDataBound="gridSalary_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="Year" HeaderText="年份" />
                            <ext:BoundField DataField="Month" HeaderText="月份" />
                            <ext:BoundField DataField="BaseSalary" HeaderText="基本工资" Hidden="true" />
                            <ext:BoundField DataField="ExamSalary" HeaderText="考核工资" Hidden="true"/>
                            <ext:BoundField DataField="BackSalary" HeaderText="补贴" Hidden="true"/>
                            <ext:BoundField DataField="OtherSalary" HeaderText="其它" Hidden="true"/>
                            <ext:BoundField DataField="ShouldSalary" HeaderText="应发工资总额" Hidden="true"/>
                            <ext:BoundField DataField="Salary" HeaderText="实发工资总额" Hidden="true"/>
                            <ext:BoundField DataField="JBGZ" HeaderText="基本工资" Width="150px" />
                            <ext:BoundField DataField="GLGZ" HeaderText="工龄工资" />
                            <ext:BoundField DataField="SYQGZ" HeaderText="试用期补发工资" Width="150px" />
                            <ext:BoundField DataField="NZJ" HeaderText="年终奖" />
                            <ext:BoundField DataField="JLGZ" HeaderText="奖励工资" />
                            <ext:BoundField DataField="KHGZ" HeaderText="考核工资" />
                            <ext:BoundField DataField="CB" HeaderText="餐补" />
                            <ext:BoundField DataField="JTBZ" HeaderText="交通补助" />
                            <ext:BoundField DataField="YFGZ" HeaderText="应发工资" />
                            <ext:BoundField DataField="CD" HeaderText="迟到" Width="60px" />
                            <ext:BoundField DataField="ZT" HeaderText="早退" Width="60px"/>
                            <ext:BoundField DataField="KG" HeaderText="旷工" Width="60px"/>
                            <ext:BoundField DataField="SJ" HeaderText="事假" Width="60px"/>
                            <ext:BoundField DataField="BJ" HeaderText="病假" Width="60px"/>
                            <ext:BoundField DataField="SB" HeaderText="社保" Width="60px"/>
                            <ext:BoundField DataField="FK" HeaderText="罚款" Width="60px"/>
                            <ext:BoundField DataField="CF" HeaderText="餐费" Width="60px"/>
                            <ext:BoundField DataField="BJF" HeaderText="保洁费" Width="60px"/>
                            <ext:BoundField DataField="LYF" HeaderText="旅游费" Width="60px"/>
                            <ext:BoundField DataField="SFGZ" HeaderText="实发工资" />
                            <ext:BoundField DataField="Context" HeaderText="备注" ExpandUnusedSpace="true" DataTooltipField="Context" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
