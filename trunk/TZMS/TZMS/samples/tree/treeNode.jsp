<%@ page language="java" contentType="text/json; charset=utf-8" pageEncoding="utf-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<c:if test='${param.id ==null}'>[
     { id:"1",text: "安徽省(支持异步加载)",ajaxLoad:true},
     { id:"2",text: "江苏省（不支持异步加载）",nodes:
     	[
		    {id:"21", text: "南京市" },
		    {id:"22", text: "苏州市" },
		    {id:"23", text: "无锡市" },
		    {id:"24", text: "常州市" }
		]
     }
]</c:if><c:if test='${param.id eq "1"}'>[
    { id:"11",text: "合肥市"},
    { id:"12",text: "芜湖市"}
]</c:if><c:if test='${param.id eq "2"}'>[
    {id:"21", text: "南京市" },
    {id:"22", text: "苏州市" },
    {id:"23", text: "无锡市" },
    {id:"24", text: "常州市" }
]</c:if>