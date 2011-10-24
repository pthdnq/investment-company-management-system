<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TZMS.Web.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=SystemName %></title>
    <%--<link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />--%>
    <%--    <meta name="Title" content="ExtJS based ASP.NET Controls with Full AJAX Support" />
    <meta name="Description" content="ExtAspNet is a set of professional ASP.NET controls with native AJAX support and rich UI effect, which aim at No ViewState, No JavaScript, No CSS, No UpdatePanel and No WebServices." />--%>
    <link href="css/default.css" rel="stylesheet" type="text/css" />
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
                    <ext:ContentPanel ShowBorder="false" ShowHeader="false" BodyStyle="background-color:#1C3E7E;"
                        ID="ContentPanel2" runat="server">
                        <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <div class="header">
                                <a href="./default.aspx" style="color:#fff;">ExtAspNet - v<asp:Label ID="labCurrentVersion" runat="server"></asp:Label></a>
                                </div>
                            </td>
                            <td style="text-align:right;color:#ccc;display:none;">粤ICP备09194734号&nbsp;</td>
                        </tr>
                        </table>
                    </ext:ContentPanel>
                </Items>
            </ext:Region>
            <ext:Region ID="Region2" Split="true" EnableSplitTip="true" CollapseMode="Mini" Width="200px"
                Margins="0 0 0 0" ShowHeader="false" Title="Examples" Icon="Outline" EnableCollapse="true"
                Layout="Fit" Position="Left" runat="server">
                <Items>
                    <ext:Accordion ID="Accordion1"  Title="菜单" runat="server" Width="280px" EnableLargeHeader="false"
                        Height="450px" EnableFill="true" ShowBorder="True" ActiveIndex="0">
                        <Panes>
                            <ext:AccordionPane ID="AccordionPane1" runat="server" Title="系统管理" IconUrl="images/16/1.png"
                                BodyPadding="2px 5px" ShowBorder="false">
                                <Items>
                                    <ext:HyperLink ID="das" OnClientClick="return tabs();" NavigateUrl="#" runat="server"
                                        Text="菜单">
                                    </ext:HyperLink>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane2" runat="server" Title="行政管理" IconUrl="images/16/1.png"
                                BodyPadding="2px 5px" ShowBorder="false">
                                <Items>
                                    <ext:HyperLink ID="yggl" OnClientClick="return tabs('yggl');" NavigateUrl="#" runat="server"
                                        Text="员工管理">
                                    </ext:HyperLink>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane3" runat="server" Title="假勤管理" IconUrl="images/16/1.png"
                                BodyPadding="2px 5px" ShowBorder="false">
                                <Items>
                                    <ext:HyperLink ID="ygkq" OnClientClick="return tabs('ygkq');" NavigateUrl="#" runat="server"
                                        Text="员工考勤">
                                    </ext:HyperLink>
                                    <ext:HyperLink ID="wdkq" OnClientClick="return tabs('wdkq');" NavigateUrl="#" runat="server"
                                        Text="我的考勤">
                                    </ext:HyperLink>
                                    <ext:HyperLink ID="qjsq" OnClientClick="return tabs('qjsq');" NavigateUrl="#" runat="server"
                                        Text="请假申请">
                                    </ext:HyperLink>
                                    <ext:HyperLink ID="txsq" OnClientClick="return tabs('txsq');" NavigateUrl="#" runat="server"
                                        Text="调休申请">
                                    </ext:HyperLink>
                                    <ext:HyperLink ID="wdsp" OnClientClick="return tabs('wdsp');" NavigateUrl="#" runat="server"
                                        Text="我的审批">
                                    </ext:HyperLink>
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
                            <ext:Tab ID="systemTab" Title="我的首页" Layout="Fit" Icon="House" runat="server">
                                <Items>
                                    <ext:ContentPanel ID="ContentPanel1" ShowBorder="false" BodyPadding="10px" ShowHeader="false"
                                        AutoScroll="true" CssClass="intro" runat="server">
                                        <strong>ExtAspNet - ExtJS based ASP.NET Controls with Full AJAX Support</strong>

                                    </ext:ContentPanel>
                                </Items>
                            </ext:Tab>
                        </Tabs>
                    </ext:TabStrip>
                </Items>
            </ext:Region>
        </Regions>
    </ext:RegionPanel>
    </form>
    <script type="text/javascript">

        function onReady() {

        }
        //加载tab
        function tabs(keyIndex) {
            var mainTabStrip = Ext.getCmp('<%= tabManage.ClientID %>');
            if (mainTabStrip.items.length > 1) {
                var items = mainTabStrip.getComponent('functionTab');
                mainTabStrip.remove(items);
            }
            switch (keyIndex) {
                case "yggl":
                //行政管理
                    LoadTab("Pages/adminManage/WorkerManage.aspx", "员工管理");
                    break;

                //假勤管理
                case "ygkq":
                    LoadTab("Pages/attendance/WorkerAttend.aspx", "员工考勤");
                    break;
                case "wdkq":
                    LoadTab("Pages/attendance/MyAttend.aspx", "我的考勤");
                    break;
                case "qjsq":
                    LoadTab("Pages/attendance/LeaveApp.aspx", "请假申请");
                    break;
                case "txsq":
                    LoadTab("Pages/attendance/WorkLeaveApp.aspx", "调休申请");
                    break;
                case "wdsp":
                    LoadTab("Pages/attendance/MyCheckApp.aspx", "我的审批");
                    break;

                default:
                    braek;
            }

            return false;
        }
        //加载Tab
        function LoadTab(url, title) {
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
