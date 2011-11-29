<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TZMS.Web.index" %>

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
                                <a href="#" style="color:#fff;"><asp:Label ID="labCurrentVersion" runat="server"></asp:Label></a>
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
                            <ext:AccordionPane ID="AccordionPane3" runat="server" IconUrl="images/16/假勤管理.gif"
                                Title="假勤管理" BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="Tree2" EnableLines="false" ShowHeader="false" ShowBorder="false" runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/员工考勤.gif" NodeID="ygkq" OnClientClick=" tabs('ygkq','UserKey');"
                                                Text="员工考勤">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/我的考勤.gif" NodeID="wdkq" OnClientClick=" tabs('wdkq','UserKey');"
                                                Text="我的考勤">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/请假申请.gif" NodeID="qjsq" OnClientClick=" tabs('qjsq','UserKey');"
                                                Text="请假申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/调休申请.gif" NodeID="txsq" OnClientClick=" tabs('txsq','UserKey');"
                                                Text="调休申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/我的审批.gif" NodeID="wdsp" OnClientClick=" tabs('wdsp','UserKey');"
                                                Text="我的审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/请假归档.gif" NodeID="qjgd" OnClientClick=" tabs('qjgd','UserKey');"
                                                Text="请假归档">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/未打卡申请.gif" NodeID="wdksm" OnClientClick=" tabs('wdksm','UserKey');"
                                                Text="未打卡申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/未打卡审批.gif" NodeID="wdksp" OnClientClick=" tabs('wdksp','UserKey');"
                                                Text="未打卡审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/未打卡归档.gif" NodeID="wdkgd" OnClientClick=" tabs('wdkgd','UserKey');"
                                                Text="未打卡归档">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane13" runat="server" IconUrl="images/16/消息管理.gif"
                                Title="薪资管理" BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="Tree9" EnableLines="false" ShowHeader="false" ShowBorder="false" runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/我的消息.gif" NodeID="xzgl" OnClientClick=" tabs('xzgl','UserKey');"
                                                Text="薪资信息管理">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane8" runat="server" IconUrl="images/16/消息管理.gif"
                                Title="消息管理" BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="Tree4" EnableLines="false" ShowHeader="false" ShowBorder="false" runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/我的消息.gif" NodeID="wdxx" OnClientClick=" tabs('wdxx','UserKey');"
                                                Text="我的消息">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/已发消息.gif" NodeID="yfxx" OnClientClick=" tabs('yfxx','UserKey');"
                                                Text="已发消息">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/发送消息.gif" NodeID="fsxx" OnClientClick=" tabs('fsxx','UserKey');"
                                                Text="发送消息">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane11" runat="server" IconUrl="images/16/消息管理.gif"
                                Title="转正管理" BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="Tree7" EnableLines="false" ShowHeader="false" ShowBorder="false" runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/我的消息.gif" NodeID="zzsq" OnClientClick=" tabs('zzsq','UserKey');"
                                                Text="转正申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/已发消息.gif" NodeID="zzsp" OnClientClick=" tabs('zzsp','UserKey');"
                                                Text="转正审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/发送消息.gif" NodeID="zzgd" OnClientClick=" tabs('zzgd','UserKey');"
                                                Text="转正归档">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/发送消息.gif" NodeID="lzsq" OnClientClick=" tabs('lzsq','UserKey');"
                                                Text="离职申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/发送消息.gif" NodeID="lzsp" OnClientClick=" tabs('lzsp','UserKey');"
                                                Text="离职审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/发送消息.gif" NodeID="lzspgd" OnClientClick=" tabs('lzspgd','UserKey');"
                                                Text="离职审批归档">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/发送消息.gif" NodeID="lzjj" OnClientClick=" tabs('lzjj','UserKey');"
                                                Text="离职交接">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/发送消息.gif" NodeID="lzjjgd" OnClientClick=" tabs('lzjjgd','UserKey');"
                                                Text="离职交接归档">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane10" runat="server" IconUrl="images/16/物资管理.gif"
                                Title="物资管理" BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="Tree6" EnableLines="false" ShowHeader="false" ShowBorder="false" runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/物资申请.gif" NodeID="wzsq" OnClientClick=" tabs('wzsq','UserKey');"
                                                Text="物资申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/物资审批.gif" NodeID="wzsp" OnClientClick=" tabs('wzsp','UserKey');"
                                                Text="物资审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/物资领用.gif" NodeID="wzly" OnClientClick=" tabs('wzly','UserKey');"
                                                Text="物资领用">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane9" runat="server" IconUrl="images/16/代账管理.gif"
                                Title="代账管理" BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="Tree5" EnableLines="false" ShowHeader="false" ShowBorder="false" runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/代账单位.gif" NodeID="paal" OnClientClick=" tabs('paal','UserKey');"
                                                Text="代账单位">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/代账申请.gif" NodeID="dzfsq" OnClientClick=" tabs('dzfsq','UserKey');"
                                                Text="代账费申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/代账审批.gif" NodeID="dzfsp" OnClientClick=" tabs('dzfsp','UserKey');"
                                                Text="代账费审批">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane7" runat="server" Title="网络报销" IconUrl="images/16/网络报销.png"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="Tree3" EnableLines="false" ShowHeader="false" ShowBorder="false" runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/报销申请.gif" NodeID="bxsq" AutoPostBack="false"
                                                OnClientClick=" tabs('bxsq','UserKey');" Text="报销申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/报销审批.gif" NodeID="bxsp" AutoPostBack="false"
                                                OnClientClick=" tabs('bxsp','UserKey');" Text="报销审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/报销列表.gif" NodeID="bxgd" OnClientClick=" tabs('bxgd','UserKey');"
                                                Text="报销归档">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane12" runat="server" Title="业务管理" IconUrl="images/16/网络报销.png"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="Tree8" EnableLines="false" ShowHeader="false" ShowBorder="false" runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/报销申请.gif" NodeID="ptyw" AutoPostBack="false"
                                                OnClientClick=" tabs('ptyw','UserKey');" Text="普通业务创建">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/报销申请.gif" NodeID="ptywcz" AutoPostBack="false"
                                                OnClientClick=" tabs('ptywcz','UserKey');" Text="普通业务操作">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/报销审批.gif" NodeID="bxsp" AutoPostBack="false"
                                                OnClientClick=" tabs('dzyw','UserKey');" Text="定制业务创建">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane1" runat="server" Title="投资部借款" IconUrl="images/16/借款申请.gif"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="TreeInvestmentLoan" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" NodeID="fksq" IconUrl="images/16/借款申请.gif" OnClientClick=" tabs('fksq','');"
                                                Text="借款申请列表" />
                                            <ext:TreeNode Leaf="true" NodeID="fksh" IconUrl="images/16/借款审核.gif" OnClientClick=" tabs('fksh','');"
                                                Text="借款审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="fkqr" IconUrl="images/16/借款确认.gif" OnClientClick=" tabs('fkqr','');"
                                                Text="借款确认列表" />
                                            <ext:TreeNode Leaf="true" NodeID="jkxx" IconUrl="images/16/借款信息.gif" OnClientClick=" tabs('jkxx','');"
                                                Text="借款信息列表" />
                                            <ext:TreeNode Leaf="true" NodeID="skqr" IconUrl="images/16/收款确认.gif" OnClientClick=" tabs('skqr','');"
                                                Text="收款确认列表" />
                                            <ext:TreeNode Leaf="true" NodeID="skxx" IconUrl="images/16/收款信息.gif" OnClientClick=" tabs('skxx','');"
                                                Text="收款信息列表" />
                                            <ext:TreeNode Leaf="true" NodeID="zzht" IconUrl="images/16/终止合同.gif" OnClientClick=" tabs('zzht','');"
                                                Text="终止合同列表" />
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane4" runat="server" Title="项目实施" IconUrl="images/16/1.png"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="TreeInvestmentProject" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" NodeID="xmsq" OnClientClick=" tabs('xmsq','');" Text="项目申请列表" />
                                            <ext:TreeNode Leaf="true" NodeID="xmsh" OnClientClick=" tabs('xmsh','');" Text="项目审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="shjg" OnClientClick=" tabs('shjg','');" Text="审核结果列表" />
                                            <ext:TreeNode Leaf="true" NodeID="xmxx" OnClientClick=" tabs('xmxx','');" Text="项目信息列表" />
                                            <ext:TreeNode Leaf="true" NodeID="jzsh" OnClientClick=" tabs('jzsh','');" Text="进展审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="byjzf" OnClientClick=" tabs('byjzf','');" Text="备用金支付确认" />
                                            <ext:TreeNode Leaf="true" NodeID="syxx" OnClientClick=" tabs('syxx','');" Text="所有项目列表" />
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane5" runat="server" Title="银行贷款" IconUrl="images/16/1.png"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="TreeBankLoan" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" NodeID="dksq" OnClientClick=" tabs('dksq','');" Text="贷款申请列表" />
                                            <ext:TreeNode Leaf="true" NodeID="sqsh" OnClientClick=" tabs('sqsh','');" Text="申请审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="dkshjg" OnClientClick=" tabs('dkshjg','');" Text="审核结果列表" />
                                            <ext:TreeNode Leaf="true" NodeID="xmqk" OnClientClick=" tabs('xmqk','');" Text="项目情况列表" />
                                            <ext:TreeNode Leaf="true" NodeID="dkjzsh" OnClientClick=" tabs('dkjzsh','');" Text="进展审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="fyzf" OnClientClick=" tabs('fyzf','');" Text="费用支付确认" />
                                            <ext:TreeNode Leaf="true" NodeID="fyzc" OnClientClick=" tabs('fyzc','');" Text="所有费用支出" />
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane6" runat="server" Title="民间融资" IconUrl="images/16/1.png"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="TreeFolkFinancing" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" NodeID="rzsq" OnClientClick=" tabs('rzsq','');" Text="融资申请列表" />
                                            <ext:TreeNode Leaf="true" NodeID="kjsh" OnClientClick=" tabs('kjsh','');" Text="会计审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="ldsh" OnClientClick=" tabs('ldsh','');" Text="领导审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="rzht" OnClientClick=" tabs('rzht','');" Text="融资合同列表" />
                                            <ext:TreeNode Leaf="true" NodeID="zfsh" OnClientClick=" tabs('zfsh','');" Text="支付审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="zfqr" OnClientClick=" tabs('zfqr','');" Text="支付确认列表" />
                                            <ext:TreeNode Leaf="true" NodeID="zfjl" OnClientClick=" tabs('zfjl','');" Text="支付记录列表" />
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
                                                    <ext:Button ID="myMessage" Icon="User" runat="server" Text="个人信息">
                                                    </ext:Button>
                                                    <ext:Button ID="changePsw" runat="server" Icon="LockKey" Text="修改密码">
                                                    </ext:Button>
                                                    <ext:Button ID="setChecker" runat="server" Icon="GroupKey" Text="设置审批人">
                                                    </ext:Button>
                                                </Items>
                                            </ext:Toolbar>
                                        </Toolbars>
                                        <Items>
                                            <ext:ContentPanel runat="server" ShowHeader="false" AutoWidth="true" AutoHeight="true"
                                                Height="500px"><%--http://localhost:19429/CM/Mycalendar/123--%>
                                                    <iframe src="http://enroll.sse.ustc.edu.cn/rili/Default.aspx?account=<%=Account %>" width="100%" height="500px"></iframe>
                            <%--                  <iframe src="http://211.86.153.66:57682/Default.aspx?account=<%=Account %>" width="100%" height="500px"></iframe>--%>
                                            </ext:ContentPanel>
                                        </Items>
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
        Height="450px">
    </ext:Window>
    <ext:Window ID="myMessageWindow" Title="个人信息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Width="550px" Height="349">
    </ext:Window>
    <ext:Window ID="changePswWindow" Title="修改密码" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Width="350px" Height="200px">
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
                case "qjgd":
                    LoadTab("Pages/attendance/AttendToFile.aspx", "请假归档", icon);
                    break;
                case "wdksm":
                    LoadTab("Pages/attendance/NoAttend.aspx", "未打卡申请", icon);
                    break;
                case "wdksp":
                    LoadTab("Pages/attendance/NoAttendCheck.aspx", "未打卡审批", icon);
                    break;
                case "wdkgd":
                    LoadTab("Pages/attendance/NoAttendToFile.aspx", "未打卡归档", icon);
                    break;

                // 薪资管理. 
                case "xzgl":
                    LoadTab("Pages/Salary/SalaryMsgManage.aspx", "薪资信息管理", icon);
                    break;

                // 消息管理.           
                case "wdxx":
                    LoadTab("Pages/Message/MyMessageList.aspx", "我的消息", icon);
                    break;
                case "yfxx":
                    LoadTab("Pages/Message/SentMessage.aspx", "已发消息", icon);
                    break;
                case "fsxx":
                    LoadTab("Pages/Message/NewMessage.aspx?Type=Add", "发送消息", icon);
                    break;
                // 业务管理           
                case "ptyw":
                    LoadTab("Pages/Yewu/CommonYewu.aspx", "普通业务创建", icon);
                    break;
                case "ptywcz":
                    LoadTab("Pages/Yewu/CommonYewuAppList.aspx", "普通业务操作", icon);
                    break;
                case "dzyw":
                    LoadTab("Pages/Yewu/DingzhiYewu.aspx", "定制业务创建", icon);
                    break;


                case "zzsq":
                    LoadTab("Pages/ProbationPages/ProbationApply.aspx", "转正申请", icon);
                    break;
                case "zzsp":
                    LoadTab("Pages/ProbationPages/ProbationApproveList.aspx", "转正审批", icon);
                    break;
                case "zzgd":
                    LoadTab("Pages/ProbationPages/ProbationToFile.aspx", "转正归档", icon);
                    break;
                case "lzsq":
                    LoadTab("Pages/ProbationPages/UserLeaveApply.aspx", "离职申请", icon);
                    break;
                case "lzsp":
                    LoadTab("Pages/ProbationPages/UserLeaveApproveList.aspx", "离职审批", icon);
                    break;
                case "lzspgd":
                    LoadTab("Pages/ProbationPages/UserLeaveApproveToFile.aspx", "离职审批归档", icon);
                    break;
                case "lzjj":
                    LoadTab("Pages/ProbationPages/UserLeaveTransferList.aspx", "离职交接", icon);
                    break;
                case "lzjjgd":
                    LoadTab("Pages/ProbationPages/UserLeaveTransferToFile.aspx", "离职交接归档", icon);
                    break;

                // 物资管理        
                case "wzsq":
                    LoadTab("Pages/WuZhiPages/WuZhiApplyList.aspx", "物资申请", icon);
                    break;
                case "wzsp":
                    LoadTab("Pages/WuZhiPages/WuZhiCheckList.aspx", "物资审批", icon);
                    break;
                case "wzly":
                    LoadTab("Pages/WuZhiPages/WuZhiRecordList.aspx", "物资领用", icon);
                    break;

                // 代帐管理         
                case "paal":
                    LoadTab("Pages/ProxyAccountingPages/ProxyAccountingUnitList.aspx", "代帐单位", icon);
                    break;
                case "dzfsq":
                    LoadTab("Pages/ProxyAccountingPages/ProxyAccountingApplyList.aspx", "代帐费申请", icon);
                    break;
                case "dzfsp":
                    LoadTab("Pages/ProxyAccountingPages/ProxyAccountingApproveList.aspx", "代帐费审批", icon);
                    break;

                //投资部借款 InvestmentLoan                               
                case "fksq":
                    LoadTab("Pages/InvestmentLoanPages/PaymentApplyList.aspx", "借款申请", icon);
                    break;
                case "fksh":
                    LoadTab("Pages/InvestmentLoanPages/PaymentAuditList.aspx", "借款审核", icon);
                    break;
                case "fkqr":
                    LoadTab("Pages/InvestmentLoanPages/PaymentConfirmList.aspx", "借款确认", icon);
                    break;
                case "jkxx":
                    LoadTab("Pages/InvestmentLoanPages/LoanInfoList.aspx", "借款信息", icon);
                    break;
                case "skqr":
                    LoadTab("Pages/InvestmentLoanPages/ReceivablesConfirmList.aspx", "收款确认", icon);
                    break;
                case "skxx":
                    LoadTab("Pages/InvestmentLoanPages/ReceivablesInfoList.aspx", "收款信息", icon);
                    break;
                case "zzht":
                    LoadTab("Pages/InvestmentLoanPages/LoanContractList.aspx", "借款合同", icon);
                    break;

                //投资部项目实施 InvestmentProject                                 
                case "xmsq":
                    LoadTab("Pages/InvestmentProjectPages/ProjectApplyList.aspx", "项目申请列表", icon);
                    break;
                case "xmsh":
                    LoadTab("Pages/InvestmentProjectPages/ProjectAuditList.aspx", "项目审核列表", icon);
                    break;
                case "shjg":
                    LoadTab("Pages/InvestmentProjectPages/ProjectAuditResult.aspx", "审核结果列表", icon);
                    break;
                case "xmxx":
                    LoadTab("Pages/InvestmentProjectPages/ProjectInfoList.aspx", "项目信息列表", icon);
                    break;
                case "jzsh":
                    LoadTab("Pages/InvestmentProjectPages/ProjectProcessList.aspx", "进展审核列表", icon);
                    break;
                case "byjzf":
                    LoadTab("Pages/InvestmentProjectPages/ImprestPayConfirmList.aspx", "备用金支付确认", icon);
                    break;
                case "syxx":
                    LoadTab("Pages/InvestmentProjectPages/AllProjectList.aspx", "所有项目列表", icon);
                    break;

                //银行贷款 BankLoan                                   
                case "dksq":
                    LoadTab("Pages/BankLoanPages/BankLoanApplyList.aspx", "贷款申请列表", icon);
                    break;
                case "sqsh":
                    LoadTab("Pages/BankLoanPages/BankLoanAuditList.aspx", "申请审核列表", icon);
                    break;
                case "dkshjg":
                    LoadTab("Pages/BankLoanPages/BankLoanAuditResult.aspx", "审核结果列表", icon);
                    break;
                case "xmqk":
                    LoadTab("Pages/BankLoanPages/ProjectInfoList.aspx", "项目情况列表", icon);
                    break;
                case "dkjzsh":
                    LoadTab("Pages/BankLoanPages/ProcessAuditList.aspx", "进展审核列表", icon);
                    break;
                case "fyzf":
                    LoadTab("Pages/BankLoanPages/FeePayConfirmList.aspx", "费用支付确认", icon);
                    break;
                case "fyzc":
                    LoadTab("Pages/BankLoanPages/AllFeePayList.aspx", "所有费用支出列表", icon);
                    break;

                //民间融资 FolkFinancing                                      
                case "rzsq":
                    LoadTab("Pages/FolkFinancingPages/FinancingApplyList.aspx", "融资申请列表", icon);
                    break;
                case "kjsh":
                    LoadTab("Pages/FolkFinancingPages/AccountingAuditList.aspx", "会计审核列表", icon);
                    break;
                case "ldsh":
                    LoadTab("Pages/FolkFinancingPages/LeaderAuditList.aspx", "领导审核列表", icon);
                    break;
                case "rzht":
                    LoadTab("Pages/FolkFinancingPages/FinancingContractList.aspx", "融资合同列表", icon);
                    break;
                case "zfsh":
                    LoadTab("Pages/FolkFinancingPages/PaymentAuditList.aspx", "支付审核列表", icon);
                    break;
                case "zfqr":
                    LoadTab("Pages/FolkFinancingPages/PaymentConfirmList.aspx", "支付确认列表", icon);
                    break;
                case "zfjl":
                    LoadTab("Pages/FolkFinancingPages/PaymentRecordList.aspx", "支付记录列表", icon);
                    break;

                //网络报销      Baoxiao                                   
                case "bxsq":
                    LoadTab("Pages/Baoxiao/BaoxiaoApplyList.aspx", "报销申请", icon);
                    break;
                case "bxsp":
                    LoadTab("Pages/Baoxiao/BaoxiaoCheckList.aspx", "报销审批", icon);
                    break;
                case "bxgd":
                    LoadTab("Pages/Baoxiao/BaoxiaoToFile.aspx", "报销归档", icon);
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
