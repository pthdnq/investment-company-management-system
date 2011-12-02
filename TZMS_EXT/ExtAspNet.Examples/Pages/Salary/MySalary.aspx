<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MySalary.aspx.cs" Inherits="TZMS.Web.MySalary" %>

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
                            <ext:DropDownList ID="ddlstYear" runat="server" Label="年份">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstMonth" runat="server" Label="月份">
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
                            <ext:Button ID="btnSearch" runat="server" Icon="Magnifier" Text="查询" OnClick="btnSearch_Click">
                            </ext:Button>
                            <ext:Label ID="lbl1" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridSalary" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" 
                        AutoHeight="true" OnPageIndexChange="gridSalary_PageIndexChange" 
                        OnRowCommand="gridSalary_RowCommand" OnRowDataBound="gridSalary_RowDataBound">
                        <Columns>
                            
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
