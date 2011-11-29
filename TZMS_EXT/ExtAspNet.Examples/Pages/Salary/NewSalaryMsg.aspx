<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewSalaryMsg.aspx.cs" Inherits="TZMS.Web.NewSalaryMsg" %>

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
                    <ext:Button ID="btnSubmit" Text="保存" Icon="Disk" runat="server" ValidateForms="pelMain"
                        OnClick="btnSubmit_Click" ConfirmText="您确定创建该薪资信息吗?">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form ID="mainForm2" EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px"
                        runat="server">
                        <Rows>
                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstYear" runat="server"
                                        Label="年份">
                                    </ext:DropDownList>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstMonth" runat="server"
                                        Label="月份">
                                        <ext:ListItem Text="1" Value="1" />
                                        <ext:ListItem Text="2" Value="2" />
                                        <ext:ListItem Text="3" Value="3" />
                                        <ext:ListItem Text="4" Value="4" />
                                        <ext:ListItem Text="5" Value="5" />
                                        <ext:ListItem Text="6" Value="6" />
                                        <ext:ListItem Text="7" Value="7" />
                                        <ext:ListItem Text="8" Value="8" />
                                        <ext:ListItem Text="9" Value="9" />
                                        <ext:ListItem Text="10" Value="10" />
                                        <ext:ListItem Text="11" Value="11" />
                                        <ext:ListItem Text="12" Value="12" />
                                    </ext:DropDownList>
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
