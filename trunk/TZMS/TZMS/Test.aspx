<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="TZMS.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="resources/jart/jart.js"></script>
 
</head>
<body>
    <form id="form1" runat="server">
    <div art="panel" id="mainPanel" title="李德虎，您好！" filly="{hidden:true}" style="background-color: #ffe;">
    </div>
    </form>
</body>
   <script type="text/javascript">
       function ReplaceAll(str, sptr, sptr1) {
           while (str.indexOf(sptr) >= 0) {
               str = str.replace(sptr, sptr1);
           }
           return str;
       }

       $(function () {
           //$("#mainPanel")[0].attr('title') = "1";
           var test = document.getElementById('mainPanel').innerHTML;
           alert(test);
           test = ReplaceAll(test, '李德虎', '11');
           alert(test);
           document.getElementById('mainPanel').innerHTML = test;
           // document.getelementbyid('mainPanel').title = '11';
           //alert($("#mainPanel").attr('type'))
           // $("#mainPanel").attr("value", "123");
           //$("#mainPanel").val( "123");
       });
    </script>
</html>
