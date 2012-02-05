<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SentJiangCheng.aspx.cs"
    Inherits="TZMS.Web.SentJiangCheng" %>

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
                    <ext:Button ID="btnSubmit" Text="下发" Icon="Disk" runat="server" ValidateForms="pelMain"
                        OnClick="btnSubmit_Click" ConfirmText="您确定下发该奖惩单吗?">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form EnableBackgroundColor="true" LabelWidth="65px" ShowHeader="false" ShowBorder="true"
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
                            <ext:FormRow ColumnWidths="50% 20% 30%">
                                <Items>
                                    <ext:TextBox ID="tbxJCName" runat="server" Label="奖惩人" Required="true" ShowRedStar="true"
                                        Enabled="false">
                                    </ext:TextBox>
                                    <ext:Button ID="btnSetJC" runat="server" Text="选取奖惩人..." OnClick="btnSetJC_Click">
                                    </ext:Button>
                                    <ext:DatePicker ID="dpkConfirmTime" runat="server" Label="确认时间" Required="true" ShowRedStar="true">
                                    </ext:DatePicker>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxZJ" runat="server" Label="部门领导" Required="true" ShowRedStar="true"
                                        Enabled="false">
                                    </ext:TextBox>
                                    <ext:Button ID="btnSetZJ" runat="server" Text="选取部门领导..." OnClick="btnSetZJ_Click">
                                    </ext:Button>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:DropDownList ID="ddlstType" runat="server" Label="奖惩类型" Required="true" ShowRedStar="true">
                                        <ext:ListItem Text="奖励" Value="0" Selected="true" />
                                        <ext:ListItem Text="惩罚" Value="1" />
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="60%">
                                <Items>
                                    <ext:TextArea ID="taaReason" runat="server" Label="奖惩原因" Required="true" ShowRedStar="true"
                                        EmptyText="请输入奖惩原因" MaxLength="1000" MaxLengthMessage="最多只能输入1000个字符!" Height="300px">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndChooseJC" Title="选取奖惩人" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="450px"
        Width="560px" OnClose="wndChooseJC_Close">
    </ext:Window>
    <ext:Window ID="wndChooseZJ" Title="选取部门领导" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="450px"
        Width="560px" OnClose="wndChooseZJ_Close">
    </ext:Window>
    </form>
</body>
</html>
