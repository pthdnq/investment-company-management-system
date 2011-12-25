<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="TZMS.Web.Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>菜单配置</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" HideScrollbar="false"
        runat="server"></ext:PageManager>
    <ext:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
        <Regions>
            <ext:Region ID="Region2" Split="true" EnableSplitTip="true" CollapseMode="Mini" Width="200px"
                Margins="0 0 0 0" ShowHeader="false" Title="Examples" Icon="Outline" EnableCollapse="true"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Tree ID="rootNode" Title="菜单" OnNodeCheck="Menu_NodeCheck" runat="server" ShowHeader="false">
                        <Toolbars>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:Button ID="btnClose" runat="server" Text="关闭" Icon="Cancel" OnClick="CloseEvent">
                                    </ext:Button>
                                    <ext:Button ID="btnSave" runat="server" Text="保存" Icon="Disk" OnClick="SaveEvent">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Nodes>
                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Text="消息管理" NodeID="xxgl">
                                <Nodes>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="wdxx" OnClientClick="return false;"
                                        Text="我的消息">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="yfxx" OnClientClick="return false;"
                                        Text="已发消息">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="fsxx" OnClientClick="return false;"
                                        Text="发送消息">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Text="行政管理" NodeID="xzgl">
                                <Nodes>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="tggl" OnClientClick="return false;"
                                        Text="员工管理">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="zzns" OnClientClick="return false;"
                                        Text="转正年数">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="xtpz" OnClientClick="return false;"
                                        Text="系统配置">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="jstgsp" OnClientClick="return false;"
                                        Text="晋升调岗审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="jstggd" OnClientClick="return false;"
                                        Text="晋升调岗归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="xfjfd" OnClientClick="return false;"
                                        Text="下发奖惩单">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="jfdqr" OnClientClick="return false;"
                                        Text="奖惩单确认">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="zpsq" OnClientClick="return false;"
                                        Text="招聘申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="zpsp" OnClientClick="return false;"
                                        Text="招聘审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="zpgd" OnClientClick="return false;"
                                        Text="招聘归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="cmdj" OnClientClick="return false;"
                                        Text="出门登记">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" NodeID="rmdj" OnClientClick="return false;"
                                        Text="入门登记">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="JQGL" Text="假勤管理">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="ygkq" OnClientClick="return false;"
                                        Text="员工考勤">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="wdkq" OnClientClick="return false;"
                                        Text="我的考勤">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="qjsq" OnClientClick="return false;"
                                        Text="请假申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="txsq" OnClientClick="return false;"
                                        Text="调休申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="wdsp" OnClientClick="return false;"
                                        Text="我的审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="qjgd" OnClientClick="return false;"
                                        Text="请假归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="wdksm" OnClientClick="return false;"
                                        Text="未打卡申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="wdksp" OnClientClick="return false;"
                                        Text="未打卡审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="wdkgd" OnClientClick="return false;"
                                        Text="未打卡归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="XZGL1" Text="薪资管理">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="wdxz" OnClientClick="return false;"
                                        Text="我的薪资">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="xzxxgl" OnClientClick="return false;"
                                        Text="薪资信息管理">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="xzsq" OnClientClick="return false;"
                                        Text="薪资信息申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="xzsp" OnClientClick="return false;"
                                        Text="薪资信息审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="jxsq" OnClientClick="return false;"
                                        Text="加薪申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="jxsp" OnClientClick="return false;"
                                        Text="加薪审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="ZZLZ" Text="转正离职">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="zzsq" OnClientClick="return false;"
                                        Text="转正申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="zzsp" OnClientClick="return false;"
                                        Text="转正审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="zzgd" OnClientClick="return false;"
                                        Text="转正归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="lzsq" OnClientClick="return false;"
                                        Text="离职申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="lzsp" OnClientClick="return false;"
                                        Text="离职审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="lzspgd" OnClientClick="return false;"
                                        Text="离职审批归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="lzjj" OnClientClick="return false;"
                                        Text="离职交接">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="lzjjgd" OnClientClick="return false;"
                                        Text="离职交接归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="WZGL" Text="物资管理">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="wzgl" OnClientClick="return false;"
                                        Text="物资管理">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="wzsq" OnClientClick="return false;"
                                        Text="物资申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="wzsp" OnClientClick="return false;"
                                        Text="物资审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="DZFGL" Text="代账管理">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="paal" OnClientClick="return false;"
                                        Text="代账单位">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dzfsq" OnClientClick="return false;"
                                        Text="代账费申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dzfsp" OnClientClick="return false;"
                                        Text="代账费审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dzfdy" OnClientClick="return false;"
                                        Text="代账单导出">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="CWBX" Text="财务报销">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="bxsq" OnClientClick="return false;"
                                        Text="报销申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="bxsp" OnClientClick="return false;"
                                        Text="报销审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="bxpzsq" OnClientClick="return false;"
                                        Text="报销凭证">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="bxpzsp" OnClientClick="return false;"
                                        Text="报销凭证审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="YWGL" Text="业务管理">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="ptyw" OnClientClick="return false;"
                                        Text="普通业务创建">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="ptywcz" OnClientClick="return false;"
                                        Text="普通业务操作">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dzywcj" OnClientClick="return false;"
                                        Text="定制业务创建">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dzywcz" OnClientClick="return false;"
                                        Text="定制业务操作">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="byjsq" OnClientClick="return false;"
                                        Text="备用金申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="byjsp" OnClientClick="return false;"
                                        Text="备用金审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="InvestmentLoan" Text="投资部借款">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="fksq" OnClientClick="return false;"
                                        Text="借款申请列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="fksh" OnClientClick="return false;"
                                        Text="借款审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="fkqr" OnClientClick="return false;"
                                        Text="借款确认列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="jkxx" OnClientClick="return false;"
                                        Text="借款信息列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="skqr" OnClientClick="return false;"
                                        Text="收款确认列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="skxx" OnClientClick="return false;"
                                        Text="收款信息列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="zzht" OnClientClick="return false;"
                                        Text="终止合同列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dzysqspil" OnClientClick="return false;"
                                        Text="待转移申请审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="khylb" OnClientClick="return false;"
                                        Text="客户一览表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="InvestmentProject"
                                Text="投资部项目实施">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="xmsq" OnClientClick="return false;"
                                        Text="项目申请列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="xmsh" OnClientClick="return false;"
                                        Text="项目审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="shjg" OnClientClick="return false;"
                                        Text="审核结果列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="xmxx" OnClientClick="return false;"
                                        Text="项目信息列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="byjsh" OnClientClick="return false;"
                                        Text="备用金审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="byjzf" OnClientClick="return false;"
                                        Text="备用金支付确认">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="jzsh" OnClientClick="return false;"
                                        Text="进展审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="syxx" OnClientClick="return false;"
                                        Text="所有项目列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dzysqspip" OnClientClick="return false;"
                                        Text="待转移申请审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dzyzcspip" OnClientClick="return false;"
                                        Text="待转移过程审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="BankLoan" Text="银行贷款">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dksq" OnClientClick="return false;"
                                        Text="贷款申请列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="sqsh" OnClientClick="return false;"
                                        Text="申请审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dkshjg" OnClientClick="return false;"
                                        Text="审核结果列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="xmqk" OnClientClick="return false;"
                                        Text="项目情况列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="byjzfsh" OnClientClick="return false;"
                                        Text="备用金审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="fyzf" OnClientClick="return false;"
                                        Text="费用支付确认">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dkjzsh" OnClientClick="return false;"
                                        Text="进展审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="fyzc" OnClientClick="return false;"
                                        Text="所有费用支出">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dzysqspbl" OnClientClick="return false;"
                                        Text="待转移申请审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dzyzcspbl" OnClientClick="return false;"
                                        Text="待转移过程审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="FolkFinancing" Text="民间融资">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="rzsq" OnClientClick="return false;"
                                        Text="融资申请列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="kjsh" OnClientClick="return false;"
                                        Text="会计审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="ldsh" OnClientClick="return false;"
                                        Text="领导审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="rzht" OnClientClick="return false;"
                                        Text="融资合同列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="zfsh" OnClientClick="return false;"
                                        Text="支付审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="zfqr" OnClientClick="return false;"
                                        Text="支付确认列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="zfjl" OnClientClick="return false;"
                                        Text="支付记录列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dzysqspff" OnClientClick="return false;"
                                        Text="待转移申请审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="dzyzcspff" OnClientClick="return false;"
                                        Text="待转移过程审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="ZJSH" Text="资金审核">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="zjll" OnClientClick="return false;"
                                        Text="资金流量表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="tzjkhs" OnClientClick="return false;"
                                        Text="投资借款会计核算">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="xmsshs" OnClientClick="return false;"
                                        Text="项目实施会计核算">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="yhdkhs" OnClientClick="return false;"
                                        Text="银行贷款会计核算">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="true" EnableCheckBox="true" NodeID="mjrzhs" OnClientClick="return false;"
                                        Text="民间融资会计核算">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="true" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                        </Nodes>
                    </ext:Tree>
                </Items>
            </ext:Region>
        </Regions>
    </ext:RegionPanel>
    </form>
</body>
</html>
