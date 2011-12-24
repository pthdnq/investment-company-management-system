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
                        </Nodes>
                    </ext:Tree>
                </Items>
            </ext:Region>
        </Regions>
    </ext:RegionPanel>
    </form>
</body>
</html>
