<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProxyAccountingPrint.aspx.cs"
    Inherits="TZMS.Web.ProxyAccountingPrint" %>

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
                            <ext:TextBox ID="tbxSearch" runat="server" EmptyText="请输入交款单位查询" ShowLabel="false">
                            </ext:TextBox>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelPrintMain" ShowBorder="true" ShowHeader="false" AnchorValue="100% -36"
                runat="server" AutoScroll="true" EnableBackgroundColor="true">
                <Toolbars>
                    <ext:Toolbar ID="toolApp" runat="server">
                        <Items>
                            <ext:Button ID="btnPrint" Text="代账单打印" ToolTip="代账单打印" Icon="Printer" runat="server"
                                OnClientClick="printProxyAccounting(); return false;">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Panel ID="pelPrint" ShowBorder="false" ShowHeader="false" AnchorValue="100% -36"
                        runat="server" AutoScroll="false" EnableBackgroundColor="false">
                    </ext:Panel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
<%--    <script src="../../App_Flash/Printer.js" type="text/javascript"></script>
    <script src="../../App_Flash/Base.js" type="text/javascript"></script>
    <script src="../../App_Flash/Panel.js" type="text/javascript"></script>--%>
    <script type="text/javascript">

//        window.onload = function () {

//            /**
//            * Prints the contents of an Ext.Panel
//            */
//            Ext.ux.Printer.PanelRenderer = Ext.extend(Ext.ux.Printer.BaseRenderer, {

//                /**
//                * Generates the HTML fragment that will be rendered inside the <html> element of the printing window
//                */
//                generateBody: function (panel) {
//                    return String.format("<div class='x-panel-print'>{0}</div>", panel.body.dom.innerHTML);
//                }
//            });

//            Ext.ux.Printer.registerRenderer("panel", Ext.ux.Printer.PanelRenderer);
//        }

        function printProxyAccounting() {

//            Ext.ux.Printer.BaseRenderer.prototype.stylesheetPath = "../../css/print.css";
//            var print = Ext.getCmp('<%= pelPrint.ClientID %>');
//            Ext.ux.Printer.print(print);
        }
    </script>
</body>
</html>
