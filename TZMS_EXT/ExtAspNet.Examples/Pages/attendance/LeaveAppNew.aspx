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
        EnableLargeHeader="true" Height="317px" Title="Panel" AutoScroll="false" ShowBorder="true"
        ShowHeader="false" >
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button ID="btnClose" runat="server" Icon="Cross" Text="关闭">
                    </ext:Button>
                    <ext:Button ID="btnSave" runat="server" Icon="BulletTick" Text="提交">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="Form2"
                runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="lbName" runat="server" Label="申请人" Text="张三">
                            </ext:Label>
                            <ext:Label ID="lbAppDate" runat="server" Label="申请时间" Text="2011年9月29日">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:DropDownList Required="true"  ShowRedStar="true" ID="DropDownList1" runat="server" Label="下一步">
                            </ext:DropDownList>
                            <ext:DropDownList Required="true"  ShowRedStar="true" ID="DropDownList2" runat="server" Label="执行人">
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:DatePicker ID="DatePicker2"  ShowRedStar="true" Required="true" runat="server" Label="开始时间">
                            </ext:DatePicker>
                            <ext:DatePicker ID="DatePicker1"  ShowRedStar="true" Required="true" runat="server" Label="结束时间">
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow runat="server" ColumnWidths="60%">
                        <Items>
                            <ext:DropDownList  ShowRedStar="true" Required="true" ID="Qjtype" runat="server" Label="请假类型">
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextArea ID="txtA" ShowRedStar="true" MaxLength="100" MaxLengthMessage="最多只能输入100个字！" Height="100px"  Required="true"  runat="server" Label="请假原因">
                            </ext:TextArea>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
