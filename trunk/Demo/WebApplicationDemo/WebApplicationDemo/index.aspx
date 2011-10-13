<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplicationDemo.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Admin Template</title>
    <link href="styles/layout.css" rel="stylesheet" type="text/css" />
    <link href="styles/wysiwyg.css" rel="stylesheet" type="text/css" />
    <link href="themes/blue/styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://dwpe.googlecode.com/svn/trunk/_shared/EnhanceJS/enhance.js"></script>
    <script type='text/javascript' src='http://dwpe.googlecode.com/svn/trunk/charting/js/excanvas.js'></script>
    <script type='text/javascript' src='https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js'></script>
    <script type='text/javascript' src='https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.6/jquery-ui.min.js'></script>
    <script type='text/javascript' src='scripts/jquery.wysiwyg.js'></script>
    <script type='text/javascript' src='scripts/visualize.jQuery.js'></script>
    <script type="text/javascript" src='scripts/functions.js'></script>
    <script type="text/javascript">

        $(document).ready(function () {

            $('.navigation li').click(function () {

                var pageCategory = $(this).text();

                switch (pageCategory) {
                    case '页面1':
                        $('#pageFrame').attr('src', 'WebForm1.aspx');
                        break;
                    case '页面2':
                        $('#pageFrame').attr('src', 'WebForm2.aspx');
                        break;
                    default:
                        alert('别点了!压根就没有页面3');
                }

                return false;
            });
        });


    </script>
</head>
<body id="homepage">
    <div id="header">
        <a href="" title="">
            <img src="img/cp_logo.png" alt="Control Panel" class="logo" /></a>
<%--        <div id="searcharea">
            <p class="left smltxt">
                <a href="#" title="">Advanced</a></p>
            <input type="text" class="searchbox" value="Search control panel..." onclick="if (this.value =='Search control panel...'){this.value=''}" />
            <input type="submit" value="Search" class="searchbtn" />
        </div>--%>
    </div>
    <!-- Top Breadcrumb Start -->
    <div id="breadcrumb">
        <ul>
            <li>
                <img src="img/icons/icon_breadcrumb.png" alt="Location" /></li>
            <li><strong>Location:</strong></li>
            <li><a href="#" title="">Sub Section</a></li>
            <li>/</li>
            <li class="current">Control Panel</li>
        </ul>
    </div>
    <!-- Top Breadcrumb End -->
    <!-- Right Side/Main Content Start -->
    <div id="rightside">
        <iframe id='pageFrame' src="WebForm1.aspx" frameborder="no"></iframe>
    </div>
    <!-- Right Side/Main Content End -->
    <!-- Left Dark Bar Start -->
    <div id="leftside">
        <div class="user">
            <img src="img/avatar.png" width="44" height="44" class="hoverimg" alt="Avatar" />
            <p>
                Logged in as:</p>
            <p class="username">
                Administrator</p>
            <p class="userbtn">
                <a href="#" title="">Profile</a></p>
            <p class="userbtn">
                <a href="#" title="">Log out</a></p>
        </div>
        <ul id="nav">
            <li><a class="expanded heading">Section Heading</a>
                <ul class="navigation">
                    <li><a href="#" title="" class="likelogin">页面1</a></li>
                    <li><a href="#" title="">页面2</a></li>
                    <li><a href="#" title="">页面3</a></li>
                </ul>
            </li>
        </ul>
    </div>
    <!-- Notifications Box/Pop-Up End -->
</body>
</html>
