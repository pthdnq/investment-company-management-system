<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveAppNew.aspx.cs" Inherits="TZMS.Web.LeaveAppNew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>请假申请</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Toolbar ID="toolApp" runat="server">
        <Items>
            <ext:Button ID="btnClose" Text="关闭" ToolTip="关闭" runat="server">
            </ext:Button>
        </Items>
    </ext:Toolbar>
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="0px"
        EnableLargeHeader="true" Title="Panel" ShowBorder="false" ShowHeader="false"
        Layout="Anchor">
        <Items>
            <ext:Form Title="Form2" LabelWidth="100px" EnableBackgroundColor="true" BodyPadding="5px"
                ID="Form2" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:Label ID="Label3" Label="Phone" Text="请假类型" runat="server" />
                            <ext:Label ID="Label16" runat="server" Label="Applicant" Text="sanshi">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
