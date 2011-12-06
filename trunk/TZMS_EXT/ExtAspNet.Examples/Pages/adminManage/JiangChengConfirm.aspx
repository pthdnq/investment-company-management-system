<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiangChengConfirm.aspx.cs"
    Inherits="TZMS.Web.JiangChengConfirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" ShowHeader="false">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Text="关闭" Icon="Cancel" runat="server" OnClick="btnClose_Click">
                    </ext:Button>
                    <ext:Button ID="btnSubmit" Text="确认" Icon="Disk" runat="server" ValidateForms="pelMain"
                        OnClick="btnSubmit_Click" ConfirmText="您确定确认该奖惩单吗?">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form EnableBackgroundColor="true" LabelWidth="85px" ShowHeader="false" ShowBorder="true"
                        BodyPadding="5px" ID="mainForm" runat="server">
                        <Rows>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="lblName" runat="server" Label="下发人">
                                    </ext:Label>
                                    <ext:Label ID="lblApplyTime" runat="server" Label="下发时间">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="lblJC" runat="server" Label="奖惩人">
                                    </ext:Label>
                                    <ext:Label ID="lblZJ" runat="server" Label="部门总监">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="lblType" runat="server" Label="奖惩类型">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="60%">
                                <Items>
                                    <ext:TextArea ID="taaReason" runat="server" Label="奖惩原因" Height="300px" Enabled="false">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
