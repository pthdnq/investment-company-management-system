<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<title>数据增删改查功能界面</title>
    	<script id="jart_js" type="text/javascript" src="../resources/jart/jart.js"></script>
	    <script type="text/javascript">
	    	$(function(){
	    		$("#grid1").grid({url:"<c:url value='/application/getData.do'/>",showRadio:true,pageSize:12,pageMode:"remote",columns:
	                [
	                    [
							{ title: "ID", field: "id" },
	                        { title: "FirstName", field: "firstName"},
	                        { title: "LastName", field: "lastName" },
	                        { title: "Phone", field: "phone" },
	                        { title: "Email", field: "email"}
	                    ]
	                ]
	            });
	    		var data=[[
					{id:'item1',text:'新建',icon:'add',	onclick:function(){add();}},
  	  		    	{id:'item2',text:'编辑',icon:'pencil', onclick:function(){edit();}},
					{id:'item3',text:'删除',icon:'remove', onclick:function(){del();}}
   		    	]];
   		    	$('#t').toolbar().bind(data);
	    	});
			//打开新建页面
	    	function add(){
	    		$("#layer1").layer({
		    		title:'新建',
		    		url:"<c:url value='/application/add.do'/> "
	    		}).open();
	    	}
	    	//保存
	    	function save(formData){
				$.ajax({
					  type: 'POST',
					  url:'<c:url value="/application/save.do"/>',
					  data: formData,
					  success:function(result){
						$.alert(result.msg);
						$("#grid1").grid().loadData();
					  }
				});
				closeLayer();
	    	}
	    	//打开编辑页面
	    	function edit(){
	    		var row=$('#grid1').grid("radioedRow");
	    		if(!row){
		    		$.alert("请先选择一项");
		    		return;
	    		}
		    	var id=row.data.id;
	    		$("#layer1").layer({
		    		title:'编辑',
		    		url:'<c:url value="/application/get.do?id={0}"/>'.format(id)
	    		}).open();
	    	}
			//删除
	    	function del(){
	    		var row=$('#grid1').grid("radioedRow");
	    		if(!row){
		    		$.alert("请先选择一项");
		    		return;
	    		}
		    	var id=row.data.id;
		    	$.confirm("确定删除？","确认框","question",function(){
			    	$.ajax({
						  type: 'POST',
						  url:'<c:url value="/application/delete.do"/>',
						  data: {id:id},
						  success:function(result){
							$.alert(result.msg);
							$("#grid1").grid().loadData();
						  }
					});
			    	
		    	});
	    	}
	    	//关闭弹出层
	    	function closeLayer(){
	    		$("#layer1").layer().close();
	    	}
	    </script>
	</head>
	<body style='margin:0px;'>
		<div art="layout">
			<div region="north">
				<div id="t" art='toolbar' borders="0"></div>
			</div>
			<div region="middle">
				<div id="grid1" borders="1,0,0,0">
			    </div>
			</div>
		</div>
	    <div id="layer1" art="layer" width="320" height="250" iframe="true">
		</div>
	</body>
</html>