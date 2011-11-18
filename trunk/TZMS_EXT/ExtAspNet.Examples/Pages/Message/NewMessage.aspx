<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewMessage.aspx.cs" Inherits="TZMS.Web.Pages.NewMessage" %>

<%@ Register Src="~/CommonControls/MudFlexCtrl.ascx" TagName="MudFlexCtrl" TagPrefix="ucl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发送消息</title>
    <script language="javascript" src="../../App_Flash/AC_OETags.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" ShowHeader="false">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" OnClick="btnClose_Click" runat="server" Icon="Cancel" Text="关闭">
                    </ext:Button>
                    <ext:Button ID="btnSend" OnClick="btnSend_Click" runat="server" Icon="Disk" Text="发送"
                        ValidateForms="mainForm">
                    </ext:Button>
                    <ext:Button ID="btnRecevicer" OnClick="btnRecevicer_Click" runat="server" Text="收信人...">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form EnableBackgroundColor="true" ShowHeader="false" ShowBorder="false" BodyPadding="5px"
                        ID="mainForm" runat="server" LabelWidth="60px">
                        <Rows>
                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="lblSender" runat="server" Label="发送人">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="lblSentDate" runat="server" Label="发送时间">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="60%">
                                <Items>
                                    <ext:TextBox ID="tbxTitle" runat="server" Required="true" ShowRedStar="true" Label="消息标题"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="60%">
                                <Items>
                                    <ext:TextArea ID="taaContent" ShowRedStar="true" MaxLength="100" MaxLengthMessage="最多只能输入100个字！"
                                        Height="191px" Required="true" runat="server" Label="消息内容">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="60%">
                                <Items>
                                    <ext:ContentPanel ID="ContentPanel1" runat="server" BodyPadding="5px" EnableBackgroundColor="true"
                                        ShowBorder="false" ShowHeader="false" Height="172px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<ucl:MudFlexCtrl ID="MUDAttachment" runat="server" AttributeName="消息属性" SystemName="消息"></ucl:MudFlexCtrl>

                                    



                                    




                                    





                                    






                                    </ext:ContentPanel>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndRecevicers" Title="设置收信人" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Top" runat="server" IsModal="true" Width="560px" EnableConfirmOnClose="true"
        Height="450px">
    </ext:Window>
    </form>
</body>
</html>
