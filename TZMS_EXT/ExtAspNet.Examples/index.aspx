<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TZMS.Web.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=SystemName %></title>
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
            <ext:Region ID="Region1" Margins="0 0 0 0" Height="70px" ShowBorder="false" ShowHeader="false"
                Position="Top" Layout="Fit" runat="server">
                <Items>
                    <ext:ContentPanel ShowBorder="false" ShowHeader="false" BodyStyle="background:  url(images/top_bg.jpg) repeat-x;"
                        ID="ContentPanel2" runat="server">
                        <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                        <%--<td style="width:50px;"></td>--%>
                            <td>
                               
                                <%--<a href="#" style="color:#fff;"><asp:Label ID="labCurrentVersion" runat="server"></asp:Label></a>--%>
                                <img alt=""  id="logo"  src="images/logo/topLogo.png"/>
                               
                            </td>
                            <td align="right">



                             <br />
                           
                                <asp:Label  ID="labuserName" ForeColor="White" runat="server" Text="您好！ 李海（业务员）"></asp:Label>
                               <br />                               <table><tr><td> <img  src="images/help_circle.png"/></td><td> <asp:LinkButton ID="likButuon"  ToolTip="点击打开系统帮助" ForeColor="White" OnClientClick="return SystemBack();" runat="server" Text="帮助"></asp:LinkButton></td>                                                              <td> <img  src="images/cross.png"/></td><td><asp:LinkButton ID="labuserNasme"  ToolTip="点击退出系统" ForeColor="White" OnClientClick="return SystemBack();" runat="server" Text="退出系统"></asp:LinkButton></td></tr></table>
                               
                               
                               
                                
                            </td>
                            <td style="width:20px;"></td>
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
                            <ext:AccordionPane ID="AccordionPane8" runat="server" IconUrl="images/16/消息管理.png"
                                Title="消息管理 <a onclick='test();return false;'> 新消息</a>" BodyPadding="1px 1px"
                                ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="treeXXGL" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/我的消息.png" NodeID="wdxx" OnClientClick=" tabs('wdxx','UserKey');"
                                                Text="我的消息">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/已发消息.png" NodeID="yfxx" OnClientClick=" tabs('yfxx','UserKey');"
                                                Text="已发消息">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/发送消息.png" NodeID="fsxx" OnClientClick=" tabs('fsxx','UserKey');"
                                                Text="发送消息">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane2" runat="server" Title="集团综合部-行政管理" Icon="Cog" BodyPadding="1px 1px"
                                ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="treeXZGL" Hidden="false" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" Icon="UserKey" NodeID="yggl" AutoPostBack="false" OnClientClick=" tabs('yggl','UserKey');"
                                                Text="员工管理">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" Icon="UserKey" NodeID="zzns" AutoPostBack="false" OnClientClick=" tabs('zzns','UserKey');"
                                                Text="转正年数">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/系统配置.png" NodeID="xtpz" AutoPostBack="false"
                                                OnClientClick=" tabs('xtpz','UserKey');" Text="系统配置">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/调岗申请.png" NodeID="jsdgsq" AutoPostBack="false"
                                                OnClientClick=" tabs('jsdgsq','UserKey');" Text="晋升调岗申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/调岗审批.png" NodeID="jsdgsp" AutoPostBack="false"
                                                OnClientClick=" tabs('jsdgsp','UserKey');" Text="晋升调岗审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/调岗归档.png" NodeID="jsdggd" AutoPostBack="false"
                                                OnClientClick=" tabs('jsdggd','UserKey');" Text="晋升调岗归档">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/下发奖惩单.png" NodeID="xfjcd" AutoPostBack="false"
                                                OnClientClick=" tabs('xfjcd','UserKey');" Text="下发奖惩单">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/奖罚单确认.png" NodeID="jcdqr" AutoPostBack="false"
                                                OnClientClick=" tabs('jcdqr','UserKey');" Text="奖惩单确认">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/招聘申请.png" NodeID="zpsqd" AutoPostBack="false"
                                                OnClientClick=" tabs('zpsqd','UserKey');" Text="招聘申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/招聘审批.png" NodeID="zpsqsp" AutoPostBack="false"
                                                OnClientClick=" tabs('zpsqsp','UserKey');" Text="招聘审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/招聘归档.png" NodeID="zpsqgd" AutoPostBack="false"
                                                OnClientClick=" tabs('zpsqgd','UserKey');" Text="招聘归档">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" Icon="UserKey" NodeID="cmdj" AutoPostBack="false" OnClientClick=" tabs('cmdj','UserKey');"
                                                Text="出门登记">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" Icon="UserKey" NodeID="rmdj" AutoPostBack="false" OnClientClick=" tabs('rmdj','UserKey');"
                                                Text="入门登记">
                                            </ext:TreeNode>
                                            <%--                                            <ext:TreeNode Leaf="true"  Icon="UserKey" NodeID="cs" AutoPostBack="false" OnClientClick=" tabs('cs','UserKey');"
                                                Text="测试">
                                            </ext:TreeNode>--%>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane3" runat="server" IconUrl="images/16/假勤管理.gif"
                                Title="集团综合部-假勤管理" BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="treeJQGL" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
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
                                                Text="假勤审批">
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
                            <ext:AccordionPane ID="AccordionPane13" runat="server" IconUrl="images/16/薪资管理.png"
                                Title="集团综合部-薪资管理" BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="treeXZGL1" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/薪资信息管理.png" NodeID="wdxz" OnClientClick=" tabs('wdxz','UserKey');"
                                                Text="我的薪资">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/薪资信息管理.png" NodeID="xzxxgl" OnClientClick=" tabs('xzxxgl','UserKey');"
                                                Text="薪资信息管理">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/薪资信息申请.png" NodeID="xzsq" OnClientClick=" tabs('xzsq','UserKey');"
                                                Text="薪资信息申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/薪资信息审批.png" NodeID="xzsp" OnClientClick=" tabs('xzsp','UserKey');"
                                                Text="薪资信息审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/薪资信息管理.png" NodeID="xzff" OnClientClick=" tabs('xzff','UserKey');"
                                                Text="工资发放">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/加薪申请.png" NodeID="jxsq" OnClientClick=" tabs('jxsq','UserKey');"
                                                Text="加薪申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/加薪审批.png" NodeID="jxsp" OnClientClick=" tabs('jxsp','UserKey');"
                                                Text="加薪审批">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane11" runat="server" IconUrl="images/16/转正管理.png"
                                Title="集团综合部-转正离职" BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="treeZZLZ" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/转正申请.png" NodeID="zzsq" OnClientClick=" tabs('zzsq','UserKey');"
                                                Text="转正申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/转正审批.png" NodeID="zzsp" OnClientClick=" tabs('zzsp','UserKey');"
                                                Text="转正审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/转正归档.png" NodeID="zzgd" OnClientClick=" tabs('zzgd','UserKey');"
                                                Text="转正归档">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/离职申请.png" NodeID="lzsq" OnClientClick=" tabs('lzsq','UserKey');"
                                                Text="离职申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/离职审批.png" NodeID="lzsp" OnClientClick=" tabs('lzsp','UserKey');"
                                                Text="离职审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/离职审批归档.png" NodeID="lzspgd" OnClientClick=" tabs('lzspgd','UserKey');"
                                                Text="离职审批归档">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/离职交接.png" NodeID="lzjj" OnClientClick=" tabs('lzjj','UserKey');"
                                                Text="离职交接">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/离职交接归档.png" NodeID="lzjjgd" OnClientClick=" tabs('lzjjgd','UserKey');"
                                                Text="离职交接归档">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane10" runat="server" IconUrl="images/16/物资管理.gif"
                                Title="集团综合部-物资管理" BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="treeWZGL" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/物资申请.gif" NodeID="wzgl" OnClientClick=" tabs('wzgl','UserKey');"
                                                Text="物资管理">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/物资申请.gif" NodeID="wzcgsq" OnClientClick=" tabs('wzcgsq','UserKey');"
                                                Text="物资采购申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/物资审批.gif" NodeID="wzcgsp" OnClientClick=" tabs('wzcgsp','UserKey');"
                                                Text="物资采购审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/物资审批.gif" NodeID="wzcgrk" OnClientClick=" tabs('wzcgrk','UserKey');"
                                                Text="物资采购入库">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/物资申请.gif" NodeID="wzsq" OnClientClick=" tabs('wzsq','UserKey');"
                                                Text="物资领用申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/物资审批.gif" NodeID="wzsp" OnClientClick=" tabs('wzsp','UserKey');"
                                                Text="物资领用审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/物资审批.gif" NodeID="wzlytj" OnClientClick=" tabs('wzlytj','UserKey');"
                                                Text="物资领用统计">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane15" runat="server" Title="集团综合部-费用管理" IconUrl="images/16/收款信息.gif"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="TreeXZBFYGL" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" NodeID="xzbyjsq" OnClientClick=" tabs('xzbyjsq','');" Text="备用金申请列表"
                                                IconUrl="images/16/借款申请.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="xzbyjsh" OnClientClick=" tabs('xzbyjsh','');" Text="备用金审核列表"
                                                IconUrl="images/16/项目实施.png" />
                                            <ext:TreeNode Leaf="true" NodeID="xzbyjqr" OnClientClick=" tabs('xzbyjqr','');" IconUrl="images/16/支付确认列表.gif"
                                                Text="备用金确认列表" />
                                            <ext:TreeNode Leaf="true" NodeID="xzbyj" OnClientClick=" tabs('xzbyj','');" Text="备用金信息列表"
                                                IconUrl="images/16/银行贷款.png" />
                                            <ext:TreeNode Leaf="true" NodeID="xzsksjsq" OnClientClick=" tabs('xzsksjsq','');"
                                                Text="收款上交申请列表" IconUrl="images/16/民间融资.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="xzsksjqr" OnClientClick=" tabs('xzsksjqr','');"
                                                IconUrl="images/16/支付确认列表.gif" Text="收款上交确认列表" />
                                            <ext:TreeNode Leaf="true" NodeID="xzsksjsh" OnClientClick=" tabs('xzsksjsh','');"
                                                Text="收款上交审核列表" IconUrl="images/16/领导审核.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="xzsksj" OnClientClick=" tabs('xzsksj','');" Text="收款上交信息列表"
                                                IconUrl="images/16/融资合同列表.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="xzfksjsq" OnClientClick=" tabs('xzfksjsq','');"
                                                Text="行政付款申请列表" IconUrl="images/16/支付审核列表.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="xzfksjsh" OnClientClick=" tabs('xzfksjsh','');"
                                                Text="行政付款审核列表" IconUrl="images/16/支付确认列表.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="xzfksjqr" IconUrl="images/16/借款确认.gif" OnClientClick=" tabs('xzfksjqr','');"
                                                Text="行政付款确认列表" />
                                            <ext:TreeNode Leaf="true" NodeID="xzfksj" OnClientClick=" tabs('xzfksj','');" Text="行政付款信息列表"
                                                IconUrl="images/16/支付记录列表.gif" />
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane9" runat="server" IconUrl="images/16/代账管理.gif"
                                Title="吉信财务管理公司" BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="treeDZFGL" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/代账单位.gif" NodeID="dzdwgl" OnClientClick=" tabs('dzdwgl','UserKey');"
                                                Text="代账单位管理">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/代账申请.gif" NodeID="dzdmbzz" OnClientClick=" tabs('dzdmbzz','UserKey');"
                                                Text="代账单模板制作">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/代账审批.gif" NodeID="dzdmbsp" OnClientClick=" tabs('dzdmbsp','UserKey');"
                                                Text="代账单模板审批">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/代账审批.gif" NodeID="dzdgl" OnClientClick=" tabs('dzdgl','UserKey');"
                                                Text="代账单管理">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/代帐单打印.png" NodeID="wddzd" OnClientClick=" tabs('wddzd','UserKey');"
                                                Text="我的代帐单">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/代帐单打印.png" NodeID="dzfygl" OnClientClick=" tabs('dzfygl','UserKey');"
                                                Text="代帐费用管理">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            
                            <ext:AccordionPane ID="AccordionPane12" runat="server" Title="吉信企业管理公司" IconUrl="images/16/业务管理.gif"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="treeYWGL" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/普通业务.gif" NodeID="ptyw" AutoPostBack="false"
                                                OnClientClick=" tabs('ptyw','UserKey');" Text="普通业务列表">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/报销申请.gif" NodeID="ptywcz" AutoPostBack="false"
                                                OnClientClick=" tabs('ptywcz','UserKey');" Text="普通业务操作">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/定制业务创建.png" NodeID="dzywcj" AutoPostBack="false"
                                                OnClientClick=" tabs('dzywcj','UserKey');" Text="定制业务列表">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/定制业务操作.png" NodeID="dzywcz" AutoPostBack="false"
                                                OnClientClick=" tabs('dzywcz','UserKey');" Text="定制业务操作">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/定制业务操作.png" NodeID="ywfysq" AutoPostBack="false"
                                                OnClientClick=" tabs('ywfysq','UserKey');" Text="业务费用收取记录">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/定制业务操作.png" NodeID="ywfysp" AutoPostBack="false"
                                                OnClientClick=" tabs('ywfysp','UserKey');" Text="业务费用收取出纳确认">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/定制业务操作.png" NodeID="ywfyqr" AutoPostBack="false"
                                                OnClientClick=" tabs('ywfyqr','UserKey');" Text="业务费用收取确认归档">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/定制业务.gif" NodeID="byjsq" AutoPostBack="false"
                                                OnClientClick=" tabs('byjsq','UserKey');" Text="备用金申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/定制业务.gif" NodeID="byjsp" AutoPostBack="false"
                                                OnClientClick=" tabs('byjsp','UserKey');" Text="备用金审批">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane1" runat="server" Title="集团风险控制部" IconUrl="images/16/借款申请.gif"
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
                                            <ext:TreeNode Leaf="true" NodeID="zzhhIL" IconUrl="images/16/终止合同.gif" OnClientClick=" tabs('zzhhIL','');"
                                                Text="终止审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="dzysqspil" OnClientClick=" tabs('dzysqspil','');"
                                                IconUrl="images/16/贷款申请列表.png" Text="待转移申请审批列表" />
                                            <ext:TreeNode Leaf="true" NodeID="khylb" OnClientClick=" tabs('khylb','');" IconUrl="images/16/项目信息列表.png"
                                                Text="客户一览表" />
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane4" runat="server" Title="中企聚成担保-集团外项目" IconUrl="images/16/项目实施.png"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="TreeInvestmentProject" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" NodeID="xmsq" OnClientClick=" tabs('xmsq','');" IconUrl="images/16/项目申请.png"
                                                Text="项目申请列表" />
                                            <ext:TreeNode Leaf="true" NodeID="xmsh" OnClientClick=" tabs('xmsh','');" IconUrl="images/16/项目审核.png"
                                                Text="项目审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="shjg" OnClientClick=" tabs('shjg','');" IconUrl="images/16/审核结果列表.png"
                                                Text="审核结果列表" />
                                            <ext:TreeNode Leaf="true" NodeID="xmxx" OnClientClick=" tabs('xmxx','');" IconUrl="images/16/项目信息列表.png"
                                                Text="项目信息列表" />
                                            <ext:TreeNode Leaf="true" NodeID="byjsh" OnClientClick=" tabs('byjsh','');" IconUrl="images/16/项目审核.png"
                                                Text="备用金审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="byjzf" OnClientClick=" tabs('byjzf','');" IconUrl="images/16/支付确认列表.gif"
                                                Text="备用金支付确认" />
                                            <ext:TreeNode Leaf="true" NodeID="jzsh" OnClientClick=" tabs('jzsh','');" IconUrl="images/16/进展审核列表.png"
                                                Text="进展审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="syxx" OnClientClick=" tabs('syxx','');" IconUrl="images/16/所有项目列表.png"
                                                Text="所有项目列表" />
                                            <ext:TreeNode Leaf="true" NodeID="dzysqspip" OnClientClick=" tabs('dzysqspip','');"
                                                IconUrl="images/16/贷款申请列表.png" Text="待转移申请审批列表" />
                                            <ext:TreeNode Leaf="true" NodeID="dzyzcspip" OnClientClick=" tabs('dzyzcspip','');"
                                                IconUrl="images/16/贷款申请审核列表.png" Text="待转移过程审批列表" />
                                            <ext:TreeNode Leaf="true" NodeID="zzhhIP" IconUrl="images/16/终止合同.gif" OnClientClick=" tabs('zzhhIP','');"
                                                Text="终止审核列表" />
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane5" runat="server" Title="中企聚成担保-集团内项目" IconUrl="images/16/银行贷款.png"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="TreeBankLoan" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" NodeID="dksq" OnClientClick=" tabs('dksq','');" IconUrl="images/16/贷款申请列表.png"
                                                Text="贷款申请列表" />
                                            <ext:TreeNode Leaf="true" NodeID="sqsh" OnClientClick=" tabs('sqsh','');" IconUrl="images/16/贷款申请审核列表.png"
                                                Text="申请审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="dkshjg" OnClientClick=" tabs('dkshjg','');" IconUrl="images/16/贷款审核结果列表.png"
                                                Text="审核结果列表" />
                                            <ext:TreeNode Leaf="true" NodeID="xmqk" OnClientClick=" tabs('xmqk','');" IconUrl="images/16/贷款项目情况列表.png"
                                                Text="项目情况列表" />
                                            <ext:TreeNode Leaf="true" NodeID="byjzfsh" OnClientClick=" tabs('byjzfsh','');" IconUrl="images/16/贷款申请审核列表.png"
                                                Text="备用金审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="fyzf" OnClientClick=" tabs('fyzf','');" IconUrl="images/16/支付确认列表.gif"
                                                Text="费用支付确认" />
                                            <ext:TreeNode Leaf="true" NodeID="dkjzsh" OnClientClick=" tabs('dkjzsh','');" IconUrl="images/16/贷款进展审核.png"
                                                Text="进展审核列表" />
                                            <ext:TreeNode Leaf="true" NodeID="fyzc" OnClientClick=" tabs('fyzc','');" IconUrl="images/16/支付记录列表.gif"
                                                Text="所有费用支出" />
                                            <ext:TreeNode Leaf="true" NodeID="dzysqspbl" OnClientClick=" tabs('dzysqspbl','');"
                                                IconUrl="images/16/贷款申请列表.png" Text="待转移申请审批列表" />
                                            <ext:TreeNode Leaf="true" NodeID="dzyzcspbl" OnClientClick=" tabs('dzyzcspbl','');"
                                                IconUrl="images/16/贷款申请审核列表.png" Text="待转移过程审批列表" />
                                            <ext:TreeNode Leaf="true" NodeID="zzhhBL" IconUrl="images/16/终止合同.gif" OnClientClick=" tabs('zzhhBL','');"
                                                Text="终止审核列表" />
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane6" runat="server" Title="集团财务部-融资" IconUrl="images/16/民间融资.gif"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="TreeFolkFinancing" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" NodeID="rzsq" OnClientClick=" tabs('rzsq','');" Text="融资申请列表"
                                                IconUrl="images/16/融资申请.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="kjsh" OnClientClick=" tabs('kjsh','');" Text="会计审核列表"
                                                IconUrl="images/16/会计审核.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="ldsh" OnClientClick=" tabs('ldsh','');" Text="领导审核列表"
                                                IconUrl="images/16/领导审核.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="rzht" OnClientClick=" tabs('rzht','');" Text="融资合同列表"
                                                IconUrl="images/16/融资合同列表.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="zfsh" OnClientClick=" tabs('zfsh','');" Text="支付审核列表"
                                                IconUrl="images/16/支付审核列表.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="zfqr" OnClientClick=" tabs('zfqr','');" Text="支付确认列表"
                                                IconUrl="images/16/支付确认列表.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="zfjl" OnClientClick=" tabs('zfjl','');" Text="支付记录列表"
                                                IconUrl="images/16/支付记录列表.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="dzysqspff" OnClientClick=" tabs('dzysqspff','');"
                                                IconUrl="images/16/贷款申请列表.png" Text="待转移申请审批列表" />
                                            <ext:TreeNode Leaf="true" NodeID="dzyzcspff" OnClientClick=" tabs('dzyzcspff','');"
                                                IconUrl="images/16/贷款申请审核列表.png" Text="待转移过程审批列表" />
                                            <ext:TreeNode Leaf="true" NodeID="zzhhFF" IconUrl="images/16/终止合同.gif" OnClientClick=" tabs('zzhhFF','');"
                                                Text="终止审核列表" />
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane14" runat="server" Title="集团财务部-资金审核" IconUrl="images/16/收款信息.gif"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="Tree10" EnableLines="false" ShowHeader="false" ShowBorder="false" runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" NodeID="zjll" OnClientClick=" tabs('zjll','');" Text="资金流量表"
                                                IconUrl="images/16/融资申请.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="tzjkhs" OnClientClick=" tabs('tzjkhs','');" Text="投资借款会计核算"
                                                IconUrl="images/16/借款申请.gif" />
                                            <ext:TreeNode Leaf="true" NodeID="xmsshs" OnClientClick=" tabs('xmsshs','');" Text="项目实施会计核算"
                                                IconUrl="images/16/项目实施.png" />
                                            <ext:TreeNode Leaf="true" NodeID="yhdkhs" OnClientClick=" tabs('yhdkhs','');" Text="银行贷款会计核算"
                                                IconUrl="images/16/银行贷款.png" />
                                            <ext:TreeNode Leaf="true" NodeID="mjrzhs" OnClientClick=" tabs('mjrzhs','');" Text="民间融资会计核算"
                                                IconUrl="images/16/民间融资.gif" />
                                        </Nodes>
                                    </ext:Tree>
                                </Items>
                            </ext:AccordionPane>
                            <ext:AccordionPane ID="AccordionPane7" runat="server" Title="集团财务部-财务报销" IconUrl="images/16/网络报销.png"
                                BodyPadding="1px 1px" ShowBorder="false">
                                <Items>
                                    <ext:Tree ID="treeCWBX" EnableLines="false" ShowHeader="false" ShowBorder="false"
                                        runat="server">
                                        <Nodes>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/报销申请.gif" NodeID="bxsq" AutoPostBack="false"
                                                OnClientClick=" tabs('bxsq','UserKey');" Text="报销申请">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/报销审批.gif" NodeID="bxsp" AutoPostBack="false"
                                                OnClientClick=" tabs('bxsp','UserKey');" Text="报销审批">
                                            </ext:TreeNode>
                                            <%--<ext:TreeNode Leaf="true" IconUrl="images/16/报销列表.gif" NodeID="bxgd" OnClientClick=" tabs('bxgd','UserKey');"
                                                Text="报销归档">
                                            </ext:TreeNode>--%>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/报销凭证.png" NodeID="bxpzsq" AutoPostBack="false"
                                                OnClientClick=" tabs('bxpzsq','UserKey');" Text="报销凭证">
                                            </ext:TreeNode>
                                            <ext:TreeNode Leaf="true" IconUrl="images/16/报销凭证审批.png" NodeID="bxpzsp" AutoPostBack="false"
                                                OnClientClick=" tabs('bxpzsp','UserKey');" Text="报销凭证审批">
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
        Target="Parent" runat="server" IsModal="true" Width="550px" Height="450">
    </ext:Window>
    <ext:Window ID="changePswWindow" Title="修改密码" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Width="350px" Height="200px">
    </ext:Window>
    <ext:Timer ID="timeMsg" Interval="180" EnableAjax="true" OnTick="timeMsg_Tick" runat="server">
    </ext:Timer>
    <ext:Button ID="btnMessage" runat="server" Hidden="true" OnClick="btnMessage_Click">
    </ext:Button>
    </form>
    <script type="text/javascript">

        function onReady() {

            //setInterval("Msg();", 10000); //隔3分钟执行一次.
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
                case "jsdgsq":
                    LoadTab("Pages/adminManage/JingShengApplyList.aspx", "晋升调岗申请", icon);
                    break;
                case "jsdgsp":
                    LoadTab("Pages/adminManage/JingShengApproveList.aspx", "晋升调岗审批", icon);
                    break;
                case "jsdggd":
                    LoadTab("Pages/adminManage/JingShengToFile.aspx", "晋升调岗审批归档", icon);
                    break;
                case "xfjcd":
                    LoadTab("Pages/adminManage/JiangChengList.aspx", "下发奖惩单", icon);
                    break;
                case "jcdqr":
                    LoadTab("Pages/adminManage/JiangChengConfirmList.aspx", "奖惩单确认", icon);
                    break;
                case "zpsqd":
                    LoadTab("Pages/adminManage/RecruitmentApplyList.aspx", "招聘申请", icon);
                    break;
                case "zpsqsp":
                    LoadTab("Pages/adminManage/RecruitmentApproveList.aspx", "招聘审批", icon);
                    break;
                case "zpsqgd":
                    LoadTab("Pages/adminManage/RecruitmentToFile.aspx", "招聘归档", icon);
                    break;
                case "xtpz":
                    LoadTab("Pages/adminManage/SystemConfig.aspx", "系统配置", icon);
                    break;
                case "zzns":
                    LoadTab("Pages/adminManage/ProbationYear.aspx", "转正年数", icon);
                    break;
                case "cmdj":
                    LoadTab("Pages/adminManage/ChuRuApplyList.aspx", "出门登记", icon);
                    break;
                case "rmdj":
                    LoadTab("Pages/adminManage/ChuRuApproveList.aspx", "入门登记", icon);
                    break;
                case "cs":
                    LoadTab("Test.aspx", "我的日历", icon);
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
                    LoadTab("Pages/attendance/MyCheckApp.aspx", "假勤审批", icon);
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
                case "wdxz":
                    LoadTab("Pages/Salary/MySalary.aspx", "我的薪资", icon);
                    break;
                case "xzxxgl":
                    LoadTab("Pages/Salary/SalaryMsgManage.aspx", "薪资信息管理", icon);
                    break;
                case "xzsq":
                    LoadTab("Pages/Salary/SalaryMsgApplyList.aspx", "薪资信息申请", icon);
                    break;
                case "xzsp":
                    LoadTab("Pages/Salary/SalaryMsgApproveList.aspx", "薪资信息审批", icon);
                    break;
                case "xzff":
                    LoadTab("Pages/Salary/SalaryPayroll.aspx", "工资发放", icon);
                    break;
                case "jxsq":
                    LoadTab("Pages/Salary/AddSalaryApplyList.aspx", "加薪申请", icon);
                    break;
                case "jxsp":
                    LoadTab("Pages/Salary/AddSalaryApproveList.aspx", "加薪审批", icon);
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
                    LoadTab("Pages/BusinessPages/NormalBusinessList.aspx", "普通业务列表", icon);
                    break;
                case "ptywcz":
                    LoadTab("Pages/BusinessPages/NormalBusinessOperateList.aspx", "普通业务操作", icon);
                    break;
                case "dzywcj":
                    LoadTab("Pages/BusinessPages/CustomizeBusinessList.aspx", "定制业务列表", icon);
                    break;
                case "dzywcz":
                    LoadTab("Pages/BusinessPages/CustomizeBusinessOperateList.aspx", "定制业务操作", icon);
                    break;
                case "ywfysq":
                    LoadTab("Pages/BusinessPages/CostApplyList.aspx", "业务费用收取记录", icon);
                    break;
                case "ywfysp":
                    LoadTab("Pages/BusinessPages/CostApproveList.aspx", "业务费用收取出纳确认", icon);
                    break;
                case "ywfyqr":
                    LoadTab("Pages/BusinessPages/CostConfirmList.aspx", "业务费用收取确认归档", icon);
                    break;
                case "byjsq":
                    LoadTab("Pages/BusinessPages/BusinessImprestApplyList.aspx", "备用金申请", icon);
                    break;
                case "byjsp":
                    LoadTab("Pages/BusinessPages/BusinessImprestApproveList.aspx", "备用金审批", icon);
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
                case "wzgl":
                    LoadTab("Pages/MaterialsPages/MaterialsManagePage.aspx", "物资管理", icon);
                    break;
                case "wzcgsq":
                    LoadTab("Pages/MaterialsPages/MaterialsPurchaseApplyList.aspx", "物资采购申请", icon);
                    break;
                case "wzcgsp":
                    LoadTab("Pages/MaterialsPages/MaterialsPurchaseApproveList.aspx", "物资采购审批", icon);
                    break;
                case "wzcgrk":
                    LoadTab("Pages/MaterialsPages/MaterialsPurchaseImportList.aspx", "物资采购入库", icon);
                    break;
                case "wzsq":
                    LoadTab("Pages/MaterialsPages/MaterialsApplyList.aspx", "物资领用申请", icon);
                    break;
                case "wzsp":
                    LoadTab("Pages/MaterialsPages/MaterialsApproveList.aspx", "物资领用审批", icon);
                    break;
                case "wzlytj":
                    LoadTab("Pages/MaterialsPages/MaterialsStatistics.aspx", "物资领用统计", icon);
                    break;

                // 代帐管理                                                   
                case "dzdwgl":
                    LoadTab("Pages/ProxyAmount/ProxyAmountUnit.aspx", "代帐单位管理", icon);
                    break;
                case "dzdmbzz":
                    LoadTab("Pages/ProxyAmount/ProxyAmountTemplateApplyList.aspx", "代帐单模板制作", icon);
                    break;
                case "dzdmbsp":
                    LoadTab("Pages/ProxyAmount/ProxyAmountTemplateApproveList.aspx", "代帐单模板审批", icon);
                    break;
                case "dzdgl":
                    LoadTab("Pages/ProxyAmount/GenerateProxyAmount.aspx", "代帐单管理", icon);
                    break;
                case "wddzd":
                    LoadTab("Pages/ProxyAmount/MyProxyAmount.aspx", "我的代帐单", icon);
                    break;
                case "dzfygl":
                    LoadTab("Pages/ProxyAmount/ProxyAmountMoneyManage.aspx", "代帐费用管理", icon);
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
                    LoadTab("Pages/InvestmentLoanPages/LoanContractList.aspx", "终止合同列表", icon);
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
                case "byjsh":
                    LoadTab("Pages/InvestmentProjectPages/ImprestPayAuditList.aspx", "备用金审核列表", icon);
                    break;
                case "byjzf":
                    LoadTab("Pages/InvestmentProjectPages/ImprestPayConfirmList.aspx", "备用金支付确认", icon);
                    break;
                case "jzsh":
                    LoadTab("Pages/InvestmentProjectPages/ProjectProcessList.aspx", "进展审核列表", icon);
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
                case "byjzfsh":
                    LoadTab("Pages/BankLoanPages/FeePayAuditList.aspx", "备用金审核列表", icon);
                    break;
                case "fyzf":
                    LoadTab("Pages/BankLoanPages/FeePayConfirmList.aspx", "费用支付确认", icon);
                    break;
                case "dkjzsh":
                    LoadTab("Pages/BankLoanPages/ProcessAuditList.aspx", "进展审核列表", icon);
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

                //资金流量                            
                case "zjll":
                    LoadTab("Pages/CashFlow/CashFlowStatementList.aspx", "资金流量表", icon);
                    break;
                case "tzjkhs":
                    LoadTab("Pages/CashFlow/InvestmentLoanBAList.aspx", "投资借款会计核算", icon);
                    break;
                case "xmsshs":
                    LoadTab("Pages/CashFlow/InvestmentProjectBAList.aspx", "项目实施会计核算", icon);
                    break;
                case "yhdkhs":
                    LoadTab("Pages/CashFlow/BankLoanBAList.aspx", "银行贷款会计核算", icon);
                    break;
                case "mjrzhs":
                    LoadTab("Pages/CashFlow/FolkFinancingBAList.aspx", "民间融资会计核算", icon);
                    break;

                //审批转移                         
                case "dzysqspbl":
                    LoadTab("Pages/BankLoanPages/BankLoanAuditTransferList.aspx", "待转移申请审批", icon);
                    break;
                case "dzyzcspbl":
                    LoadTab("Pages/BankLoanPages/ProcessAuditTransferList.aspx", "待转移过程审批", icon);
                    break;

                case "dzysqspff":
                    LoadTab("Pages/FolkFinancingPages/LeaderAuditTransferList.aspx", "待转移申请审批", icon);
                    break;
                case "dzyzcspff":
                    LoadTab("Pages/FolkFinancingPages/PaymentAuditTransferList.aspx", "待转移支付审批", icon);
                    break;

                case "dzysqspil":
                    LoadTab("Pages/InvestmentLoanPages/PaymentAuditTransferList.aspx", "待转移申请审批", icon);
                    break;

                case "dzysqspip":
                    LoadTab("Pages/InvestmentProjectPages/ProjectAuditTransferList.aspx", "待转移申请审批", icon);
                    break;
                case "dzyzcspip":
                    LoadTab("Pages/InvestmentProjectPages/ProjectProcessTransferList.aspx", "待转移支付审批", icon);
                    break;

                case "khylb":
                    LoadTab("Pages/InvestmentLoanPages/CustomerList.aspx", "客户一览表", icon);
                    break;
                //合同终止审核           
                case "zzhhBL":
                    LoadTab("Pages/BankLoanPages/EndingContractAuditList.aspx", "终止审核列表", icon);
                    break;
                case "zzhhIL":
                    LoadTab("Pages/InvestmentLoanPages/EndingContractAuditList.aspx", "终止审核列表", icon);
                    break;
                case "zzhhIP":
                    LoadTab("Pages/InvestmentProjectPages/EndingContractAuditList.aspx", "终止审核列表", icon);
                    break;
                case "zzhhFF":
                    LoadTab("Pages/FolkFinancingPages/EndingContractAuditList.aspx", "终止审核列表", icon);
                    break;

                //行政部费用管理             
                case "xzbyjsq":
                    LoadTab("Pages/AdminExpensesManage/AdminImprestApplyList.aspx", "备用金申请列表", icon);
                    break;
                case "xzbyjsh":
                    LoadTab("Pages/AdminExpensesManage/AdminImprestAuditList.aspx", "备用金审核列表", icon);
                    break;
                case "xzbyjqr":
                    LoadTab("Pages/AdminExpensesManage/AdminImprestConfirmList.aspx", "备用金确认列表", icon);
                    break;
                case "xzbyj":
                    LoadTab("Pages/AdminExpensesManage/AdminImprestList.aspx", "备用金信息列表", icon);
                    break;
                case "xzsksjsq":
                    LoadTab("Pages/AdminExpensesManage/AdminReceivablesApplyList.aspx", "收款上交申请列表", icon);
                    break;
                case "xzsksjsh":
                    LoadTab("Pages/AdminExpensesManage/AdminReceivablesAuditList.aspx", "收款上交审核列表", icon);
                    break;
                case "xzsksjqr":
                    LoadTab("Pages/AdminExpensesManage/AdminReceivablesConfirmList.aspx", "收款上交确认列表", icon);
                    break;
                case "xzsksj":
                    LoadTab("Pages/AdminExpensesManage/AdminReceivablesList.aspx", "收款上交信息列表", icon);
                    break;
                case "xzfksjsq":
                    LoadTab("Pages/AdminExpensesManage/AdminPaymentApplyList.aspx", "行政付款申请列表", icon);
                    break;
                case "xzfksjsh":
                    LoadTab("Pages/AdminExpensesManage/AdminPaymentAuditList.aspx", "行政付款审核列表", icon);
                    break;
                case "xzfksjqr":
                    LoadTab("Pages/AdminExpensesManage/AdminPaymentConfirmList.aspx", "行政付款确认列表", icon);
                    break;
                case "xzfksj":
                    LoadTab("Pages/AdminExpensesManage/AdminPaymentList.aspx", "行政付款信息列表", icon);
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
                case "bxpzsq":
                    LoadTab("Pages/Baoxiao/BaoXiaoPinZhengApplyList.aspx", "报销凭证", icon);
                    break;
                case "bxpzsp":
                    LoadTab("Pages/Baoxiao/BaoXiaoPinZhengApproveList.aspx", "报销凭证审批", icon);
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
        function SystemBack() {

            window.location.href = "login.aspx";
            return false;
        }

        function SetMessageInfo() {
            __doPostBack('btnMessage', '');
            // var message = Ext.getCmp('<%= btnMessage.ClientID %>');
            // message.onClick(message);
            //  message.handler.call(message.scope);
            // message.events.click.listeners[0].fireFn(message, message.events.click.listeners[0].scope);
        }

        function test() {
            LoadTab("Pages/Message/MyMessageList.aspx", "我的消息", '');
        }
    </script>
</body>
</html>
