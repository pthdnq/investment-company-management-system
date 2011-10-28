﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TZMS.Web.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=SystemName %></title>
    <%--<link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />--%>
    <%--    <meta name="Title" content="ExtJS based ASP.NET Controls with Full AJAX Support" />
    <meta name="Description" content="ExtAspNet is a set of professional ASP.NET controls with native AJAX support and rich UI effect, which aim at No ViewState, No JavaScript, No CSS, No UpdatePanel and No WebServices." />--%>
    <%-- <link href="css/default.css" rel="stylesheet" type="text/css" />--%>
    <style type="text/css">
        .nav-hoverd
        {
            border: #ffbd69 1px solid;
            background-image: url(images/nav_hover_highlight_2.gif);
            padding: 0px 1px;
            background-repeat: repeat-x;
        }
        .nav-selected
        {
            background-image: url();
            border: #ffb74c 1px solid;
            padding: 0px 1px;
            background-color: #ffe6a0;
        }
        
        .toolbar-pagemenu
        {
            background: url(images/top_bg.jpg) repeat-x left top;
        }
        .toolbar-pagemenu .ytb-sep
        {
            background-image: url(../images/pagemenu-separator.gif);
        }
        .ds
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" HideScrollbar="true"
        runat="server"></ext:PageManager>
    <ext:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
        <Regions>
            <ext:Region ID="Region1" Margins="0 0 0 0" Height="62px" ShowBorder="false" ShowHeader="false"
                Position="Top" Layout="Fit" runat="server">
                <Items>
                    <ext:ContentPanel ShowBorder="false" ShowHeader="false" BodyStyle="background:  url(images/top_bg.jpg) repeat-x;"
                        ID="ContentPanel2" runat="server">
                        <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <div class="header">
                                <a href="#" style="color:#fff;">ExtAspNet - v<asp:Label ID="labCurrentVersion" runat="server"></asp:Label></a>
                                </div>
                            </td>
                        </tr>
                        </table>
                    </ext:ContentPanel>
                </Items>
            </ext:Region>
            <ext:Region ID="Region2" Split="true" EnableSplitTip="true" CollapseMode="Mini" Width="200px"
                Margins="0 0 0 0" ShowHeader="false" Title="Examples" Icon="Outline" EnableCollapse="true"
                Layout="Fit" Position="Left" runat="server">
                <Items>
                    <ext:Accordion ID="Accordion1" Title="办公平台" runat="server" Width="280px" EnableLargeHeader="false"
                        Height="450px" EnableFill="true" ShowBorder="True" ActiveIndex="0">
                        <Panes>
                            <ext:AccordionPane ID="AccordionPane2" runat="server" Title="行政管理" Icon="Cog" BodyPadding="1px 1px"
                                ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="Tree1" EnableLines="false" ShowHeader="false" ShowBorder="false" runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" Icon="UserKey" NodeID="yggl" AutoPostBack="false" OnClientClick=" tabs('yggl','UserKey');"
                                                Text="员工管理">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane3" runat="server" Title="假勤管理" IconUrl="images/16/1.png"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="Tree2" EnableLines="false" ShowHeader="false" ShowBorder="false" runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" NodeID="ygkq" OnClientClick=" tabs('ygkq','UserKey');"
                                                Text="员工考勤">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" NodeID="wdkq" OnClientClick=" tabs('wdkq','UserKey');"
                                                Text="我的考勤">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" NodeID="qjsq" OnClientClick=" tabs('qjsq','UserKey');"
                                                Text="请假申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" NodeID="txsq" OnClientClick=" tabs('txsq','UserKey');"
                                                Text="调休申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" NodeID="wdsp" OnClientClick=" tabs('wdsp','UserKey');"
                                                Text="我的审批">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                        </Panes>
                    </ext:Accordion>
                </Items>
            </ext:Region>
            <ext:Region ID="mainRegion" IFrameName="_main" ShowHeader="false" Layout="Fit" Margins="0 0 0 0"
                Position="Center" runat="server">
                <Items>
                    <ext:TabStrip ID="tabManage" EnableTabCloseMenu="false" ShowBorder="false" runat="server">
                        <Tabs>
                            <ext:Tab ID="systemTab" Title="我的首页" IFrameUrl="Pages/system/MyWeb.aspx" Layout="Fit"
                                Icon="House" runat="server">
                                <Items>
                                    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                                        EnableLargeHeader="true" Title="Panel" ShowHeader="false" Layout="Anchor">
                                        <Toolbars>
                                            <ext:Toolbar ID="Toolbar1" runat="server">
                                                <Items>
                                                    <ext:Button ID="myMessage" runat="server" Text="个人信息">
                                                    </ext:Button>
                                                    <ext:Button ID="changePsw" runat="server" Text="修改密码">
                                                    </ext:Button>
                                                    <ext:Button ID="setChecker" runat="server" Text="设置审批人">
                                                    </ext:Button>
                                                </Items>
                                            </ext:Toolbar>
                                        </Toolbars>
                                    </ext:Panel>
                                </Items>
                            </ext:Tab>
                        </Tabs>
                    </ext:TabStrip>
                </Items>
            </ext:Region>
        </Regions>
    </ext:RegionPanel>
    <ext:Window ID="newSetCheckerWindow" Title="设置审批人" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" Target="Parent" runat="server" IsModal="true" Width="600px"
        EnableConfirmOnClose="true" Height="450px">
    </ext:Window>
    </form>
    <script type="text/javascript">

        function onReady() {

        }
        //加载tab
        function tabs(keyIndex, icon) {
            var mainTabStrip = Ext.getCmp('<%= tabManage.ClientID %>');
            if (mainTabStrip.items.length > 1) {
                var items = mainTabStrip.getComponent('functionTab');
                mainTabStrip.remove(items);
            }
            switch (keyIndex) {
                case "yggl":
                    //行政管理
                    LoadTab("Pages/adminManage/WorkerManage.aspx", "员工管理", icon);
                    break;

                //假勤管理                        
                case "ygkq":
                    LoadTab("Pages/attendance/WorkerAttend.aspx", "员工考勤", icon);
                    break;
                case "wdkq":
                    LoadTab("Pages/attendance/MyAttend.aspx", "我的考勤", icon);
                    break;
                case "qjsq":
                    LoadTab("Pages/attendance/LeaveApp.aspx", "请假申请", icon);
                    break;
                case "txsq":
                    LoadTab("Pages/attendance/WorkLeaveApp.aspx", "调休申请", icon);
                    break;
                case "wdsp":
                    LoadTab("Pages/attendance/MyCheckApp.aspx", "我的审批", icon);
                    break;

                default:
                    braek;
            }

            return false;
        }
        //加载Tab
        function LoadTab(url, title, icon) {
            var mainTabStrip = Ext.getCmp('<%= tabManage.ClientID %>');
            mainTabStrip.addTab({
                'id': 'functionTab',
                'url': url,
                'title': title,
                'closable': true,
                'bodyStyle': 'padding:0px;'
            });
        }

    </script>
</body>
</html>
