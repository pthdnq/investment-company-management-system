<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<title></title>
	    <link href="../resources/jart/themes/default/main.css" rel="Stylesheet" />
	    <link href="../resources/jart/themes/default/icons.css" rel="Stylesheet" />
	    
	    <script type="text/javascript" src="../resources/jart/jquery-1.4.4.min.js"></script>
	    <script type="text/javascript" src="../resources/jart/jart.const.js"></script>
	    <script type="text/javascript" src="../resources/jart/jart.all.js"></script>
	    <script type="text/javascript">
	    	$(function(){
		    	$('#btn1').button({icon:'ok'});
		    	$('#btn2').button({icon:'cancel'});
	    	});

	    	function submit1(){
	    		if(!$.isValid()){
					return;
				}
				window.parent.save($('#form1').serialize());
	    	}
	    	
	    </script>
	</head>
	<body>
	    <form id="form1">
	    	 <table art="form" columns="100,*">
		    	 <tr>
			    	 <td><label art="label" required="true" >FirstName</label></td>
			    	 <td>
				    	 <input type="hidden" name="id" value="${person.id }">
				    	 <input type="text" art="textbox" name="firstName" value="${person.firstName }" required="true" display="tip"/>
			    	 </td>
		    	 </tr>
		    	 <tr>
			    	 <td><label art="label"  required="true">LastName</label></td>
			    	 <td><input type="text" art="textbox" name="lastName" value="${person.lastName }" required="true" display="tip"/></td>
		    	 </tr>
		    	 <tr>
			    	 <td><label art="label">Phone</label></td>
			    	 <td><input type="text" art="textbox" name="phone" value="${person.phone }" textmode="1"/></td>
		    	 </tr>
		    	 <tr>
			    	 <td><label art="label">Email</label></td>
			    	 <td><input type="text" art="textbox" name="email" value="${person.email }" validType="email|length[0,10]"/></td>
		    	 </tr>
		    	  <tr>
			    	 <td colspan="2">
		    	 		<span id="btn1"  onclick="submit1();">提交</span>
						<span id="btn2" onclick="window.parent.closeLayer()">取消</span>
			    	 </td>
		    	 </tr>
			</table>
		</form>
	</body>
</html>