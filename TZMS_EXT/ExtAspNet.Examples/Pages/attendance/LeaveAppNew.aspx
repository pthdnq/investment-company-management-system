<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveAppNew.aspx.cs" Inherits="TZMS.Web.LeaveAppNew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>请假申请</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Height="318px" Title="Panel" AutoScroll="false" ShowBorder="true"
        ShowHeader="false">
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button runat="server" Text="关闭">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="Form2"
                runat="server">
                <Rows>
                    <ext:FormRow runat="server" ColumnWidths="100%">
                        <Items>
                            <ext:DropDownList ID="Qjtype" runat="server" Label="请假类型">
                            </ext:DropDownList>
                         
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:DatePicker ID="DatePicker2" runat="server" Label="开始时间">
                            </ext:DatePicker>
                            <ext:DatePicker ID="DatePicker1" runat="server" Label="结束时间">
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
