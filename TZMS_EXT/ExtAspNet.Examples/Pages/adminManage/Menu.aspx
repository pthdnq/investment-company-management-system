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
    <ext:RegionPanel ID="RegionPanel1" AutoScroll="true" Height="520px" ShowBorder="false"
        runat="server">
        <Regions>
            <ext:Region ID="Region2" ShowHeader="false" Layout="Fit" Margins="0 0 0 0" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:Button ID="btnClose" runat="server" Text="关闭" Icon="Cancel" OnClick="CloseEvent">
                            </ext:Button>
                            <ext:Button ID="btnSave" runat="server" Text="保存" Icon="Disk" OnClick="SaveEvent">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Tree ID="rootNode" Title="菜单" Width="200px" AutoScroll="true" Height="520px"
                        EnableBackgroundColor="true" OnNodeCheck="Menu_NodeCheck" runat="server" ShowHeader="false">
                        <Nodes>
                            <ext:TreeNode EnableCheckBox="true" Text="消息管理" NodeID="xxgl">
                                <Nodes>
                                    <ext:TreeNode EnableCheckBox="true" NodeID="wdxx" OnClientClick="return false;" Text="我的消息">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" NodeID="yfxx" OnClientClick="return false;" Text="已发消息">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" NodeID="fsxx" OnClientClick="return false;" Text="发送消息">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Text="行政管理" NodeID="xzgl">
                                <Nodes>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" NodeID="yggl" OnClientClick="return false;"
                                        Text="员工管理">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" NodeID="zzns" OnClientClick="return false;"
                                        Text="转正年数">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" NodeID="xtpz" OnClientClick="return false;"
                                        Text="系统配置">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" NodeID="jsdgsq" OnClientClick="return false;"
                                        Text="晋升调岗申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" NodeID="jsdgsp" OnClientClick="return false;"
                                        Text="晋升调岗审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" NodeID="jsdggd" OnClientClick="return false;"
                                        Text="晋升调岗归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" NodeID="xfjcd" OnClientClick="return false;"
                                        Text="下发奖惩单">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" NodeID="jcdqr" OnClientClick="return false;"
                                        Text="奖惩单确认">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" NodeID="zpsqd" OnClientClick="return false;"
                                        Text="招聘申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" NodeID="zpsqsp" OnClientClick="return false;"
                                        Text="招聘审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" NodeID="zpsqgd" OnClientClick="return false;"
                                        Text="招聘归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" NodeID="cmdj" OnClientClick="return false;"
                                        Text="出门登记">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" NodeID="rmdj" OnClientClick="return false;"
                                        Text="入门登记">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="JQGL" Text="假勤管理">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="ygkq" OnClientClick="return false;"
                                        Text="员工考勤">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="wdkq" OnClientClick="return false;"
                                        Text="我的考勤">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="qjsq" OnClientClick="return false;"
                                        Text="请假申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="txsq" OnClientClick="return false;"
                                        Text="调休申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="wdsp" OnClientClick="return false;"
                                        Text="我的审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="qjgd" OnClientClick="return false;"
                                        Text="请假归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="wdksm" OnClientClick="return false;"
                                        Text="未打卡申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="wdksp" OnClientClick="return false;"
                                        Text="未打卡审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="wdkgd" OnClientClick="return false;"
                                        Text="未打卡归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="XZGL1" Text="薪资管理">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="wdxz" OnClientClick="return false;"
                                        Text="我的薪资">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzxxgl" OnClientClick="return false;"
                                        Text="薪资信息管理">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzsq" OnClientClick="return false;"
                                        Text="薪资信息申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzsp" OnClientClick="return false;"
                                        Text="薪资信息审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzff" OnClientClick="return false;"
                                        Text="工资发放">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="jxsq" OnClientClick="return false;"
                                        Text="加薪申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="jxsp" OnClientClick="return false;"
                                        Text="加薪审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="ZZLZ" Text="转正离职">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="zzsq" OnClientClick="return false;"
                                        Text="转正申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="zzsp" OnClientClick="return false;"
                                        Text="转正审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="zzgd" OnClientClick="return false;"
                                        Text="转正归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="lzsq" OnClientClick="return false;"
                                        Text="离职申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="lzsp" OnClientClick="return false;"
                                        Text="离职审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="lzspgd" OnClientClick="return false;"
                                        Text="离职审批归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="lzjj" OnClientClick="return false;"
                                        Text="离职交接">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="lzjjgd" OnClientClick="return false;"
                                        Text="离职交接归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="WZGL" Text="物资管理">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="wzgl" OnClientClick="return false;"
                                        Text="物资管理">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="wzsq" OnClientClick="return false;"
                                        Text="物资申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="wzsp" OnClientClick="return false;"
                                        Text="物资审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="DZFGL" Text="代账管理">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dzdwgl" OnClientClick="return false;"
                                        Text="代账单位管理">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dzdmbzz" OnClientClick="return false;"
                                        Text="代账单模板制作">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dzdmbsp" OnClientClick="return false;"
                                        Text="代账单模板审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dzdgl" OnClientClick="return false;"
                                        Text="代账单管理">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="wddzd" OnClientClick="return false;"
                                        Text="我的代帐单">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="CWBX" Text="财务报销">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="bxsq" OnClientClick="return false;"
                                        Text="报销申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="bxsp" OnClientClick="return false;"
                                        Text="报销审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="bxpzsq" OnClientClick="return false;"
                                        Text="报销凭证">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="bxpzsp" OnClientClick="return false;"
                                        Text="报销凭证审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="YWGL" Text="业务管理">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="ptyw" OnClientClick="return false;"
                                        Text="普通业务列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="ptywcz" OnClientClick="return false;"
                                        Text="普通业务操作">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dzywcj" OnClientClick="return false;"
                                        Text="定制业务列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dzywcz" OnClientClick="return false;"
                                        Text="定制业务操作">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="ywfysq" OnClientClick="return false;"
                                        Text="业务费用收取申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="ywfysp" OnClientClick="return false;"
                                        Text="业务费用收取出纳确认">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="ywfyqr" OnClientClick="return false;"
                                        Text="业务费用收取确认归档">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="byjsq" OnClientClick="return false;"
                                        Text="备用金申请">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="byjsp" OnClientClick="return false;"
                                        Text="备用金审批">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="InvestmentLoan"
                                Text="投资部借款">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="fksq" OnClientClick="return false;"
                                        Text="借款申请列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="fksh" OnClientClick="return false;"
                                        Text="借款审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="fkqr" OnClientClick="return false;"
                                        Text="借款确认列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="jkxx" OnClientClick="return false;"
                                        Text="借款信息列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="skqr" OnClientClick="return false;"
                                        Text="收款确认列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="skxx" OnClientClick="return false;"
                                        Text="收款信息列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="zzht" OnClientClick="return false;"
                                        Text="终止合同列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dzysqspil" OnClientClick="return false;"
                                        Text="待转移申请审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="khylb" OnClientClick="return false;"
                                        Text="客户一览表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="zzhhIL" OnClientClick="return false;"
                                        Text="终止审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="InvestmentProject"
                                Text="投资部项目实施">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xmsq" OnClientClick="return false;"
                                        Text="项目申请列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xmsh" OnClientClick="return false;"
                                        Text="项目审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="shjg" OnClientClick="return false;"
                                        Text="审核结果列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xmxx" OnClientClick="return false;"
                                        Text="项目信息列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="byjsh" OnClientClick="return false;"
                                        Text="备用金审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="byjzf" OnClientClick="return false;"
                                        Text="备用金支付确认">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="jzsh" OnClientClick="return false;"
                                        Text="进展审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="syxx" OnClientClick="return false;"
                                        Text="所有项目列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dzysqspip" OnClientClick="return false;"
                                        Text="待转移申请审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dzyzcspip" OnClientClick="return false;"
                                        Text="待转移过程审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="zzhhIP" OnClientClick="return false;"
                                        Text="终止审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="BankLoan" Text="银行贷款">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dksq" OnClientClick="return false;"
                                        Text="贷款申请列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="sqsh" OnClientClick="return false;"
                                        Text="申请审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dkshjg" OnClientClick="return false;"
                                        Text="审核结果列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xmqk" OnClientClick="return false;"
                                        Text="项目情况列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="byjzfsh" OnClientClick="return false;"
                                        Text="备用金审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="fyzf" OnClientClick="return false;"
                                        Text="费用支付确认">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dkjzsh" OnClientClick="return false;"
                                        Text="进展审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="fyzc" OnClientClick="return false;"
                                        Text="所有费用支出">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dzysqspbl" OnClientClick="return false;"
                                        Text="待转移申请审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dzyzcspbl" OnClientClick="return false;"
                                        Text="待转移过程审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="zzhhBL" OnClientClick="return false;"
                                        Text="终止审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="FolkFinancing" Text="民间融资">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="rzsq" OnClientClick="return false;"
                                        Text="融资申请列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="kjsh" OnClientClick="return false;"
                                        Text="会计审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="ldsh" OnClientClick="return false;"
                                        Text="领导审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="rzht" OnClientClick="return false;"
                                        Text="融资合同列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="zfsh" OnClientClick="return false;"
                                        Text="支付审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="zfqr" OnClientClick="return false;"
                                        Text="支付确认列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="zfjl" OnClientClick="return false;"
                                        Text="支付记录列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dzysqspff" OnClientClick="return false;"
                                        Text="待转移申请审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="dzyzcspff" OnClientClick="return false;"
                                        Text="待转移过程审批列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="zzhhFF" OnClientClick="return false;"
                                        Text="终止审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="ZJSH" Text="资金审核">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="zjll" OnClientClick="return false;"
                                        Text="资金流量表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="tzjkhs" OnClientClick="return false;"
                                        Text="投资借款会计核算">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xmsshs" OnClientClick="return false;"
                                        Text="项目实施会计核算">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="yhdkhs" OnClientClick="return false;"
                                        Text="银行贷款会计核算">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="mjrzhs" OnClientClick="return false;"
                                        Text="民间融资会计核算">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                            <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="XZBFYGL" Text="行政部费用管理">
                                <Nodes>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzbyjsq" OnClientClick="return false;"
                                        Text="备用金申请列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzbyjsh" OnClientClick="return false;"
                                        Text="备用金审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzbyjqr" OnClientClick="return false;"
                                        Text="备用金确认列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzbyj" OnClientClick="return false;"
                                        Text="备用金信息列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzsksjsq" OnClientClick="return false;"
                                        Text="收款上交申请列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzsksjqr" OnClientClick="return false;"
                                        Text="收款上交确认列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzsksjsh" OnClientClick="return false;"
                                        Text="收款上交审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzsksj" OnClientClick="return false;"
                                        Text="收款上交信息列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzfksjsq" OnClientClick="return false;"
                                        Text="行政付款申请列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzfksjsh" OnClientClick="return false;"
                                        Text="行政付款审核列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzfksjqr" OnClientClick="return false;"
                                        Text="行政付款确认列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="编辑">
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode AutoPostBack="false" EnableCheckBox="true" NodeID="xzfksj" OnClientClick="return false;"
                                        Text="行政付款信息列表">
                                        <Nodes>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
                                                Text="查看">
                                            </ext:TreeNode>
                                            <ext:TreeNode EnableCheckBox="true" AutoPostBack="false" Leaf="true" OnClientClick="return false;"
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
    <script type="text/javascript">

        function selectAllChild(node, checked) {
            if (node != null) {
                node.eachChild(function (child) {
                    child.attributes.checked = checked;
                    child.ui.toggleCheck(checked);
                    selectAllChild(child, checked);
                });
            }
        }

        function selectAllParent(node, checked) {
            if (node != null) {
                var tree = Ext.getCmp('<%= rootNode.ClientID %>');
                if (node.id != (tree.id + "_root")) {
                    if (checked) {
                        node.attributes.checked = checked;
                        node.ui.toggleCheck(checked);
                        selectAllParent(node.parentNode, checked);
                    }
                    else {

                        var isChildChecked = false;
                        node.eachChild(function (child) {
                            if (child.attributes.checked)
                                isChildChecked = true;
                        });
                        if (!isChildChecked) {
                            node.attributes.checked = checked;
                            node.ui.toggleCheck(checked);
                            selectAllParent(node.parentNode, checked);
                        }
                    }
                }
            }
        }

        function nodeCheckChange(node, checked, isParent) {

            node.attributes.checked = checked;
            removeListenerForAllObject();
            selectAllChild(node, checked);
            selectAllParent(node.parentNode, checked);
            addListenerForAllObject();
        }

        function addListenerForAllObject() {
            var tree = Ext.getCmp('<%= rootNode.ClientID %>');
            tree.cascade(function (childElement) {
                childElement.addListener('checkchange', nodeCheckChange);
                //childElement.resumeEvents();
            });
        }

        function removeListenerForAllObject() {
            var tree = Ext.getCmp('<%= rootNode.ClientID %>');
            tree.cascade(function (childElement) {
                //childElement.purgeListeners();
                childElement.removeListener('checkchange', nodeCheckChange);
                //childElement.suspendEvents();
                //                var saveButton = Ext.getCmp('<%= btnSave.ClientID %>');
                //                if (saveButton.hasListener('click'))
                //                    alert('有click');
            });
        }

        function onReady() {
            addListenerForAllObject();
        }

    </script>
</body>
</html>
