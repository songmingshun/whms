﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="select_manager_single.aspx.cs" Inherits="DTcms.Web.admin.manager.select_manager_single" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>人员选择</title>
<link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
<link type="text/css" rel="stylesheet" href="../images/style.css" />
<link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
<script type="text/javascript">
    //返回人员信息给编辑工单页面
    function ReturnDialogResult(user_name,real_name) {
        var user_info = new Array(2);
        user_info[0] = user_name;
        user_info[1] = real_name;
        window.returnValue = user_info;
        window.opener = null;
        window.close();
    } 
</script>
<base target="_self"/>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <%--<asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch"  />--%>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
        </div>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="30%" align="left">账号</th>
        <th width="30%" align="left">姓名</th>
        <th width="40%" align="left">部门</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <%--<td><a href="manager_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>"><%#Eval("user_name")%></a></td>--%>
        <td><a href="javascript:ReturnDialogResult('<%#Eval("user_name")%>','<%#Eval("real_name")%>');"><%#Eval("user_name")%></a></td>
        <td><%#Eval("real_name")%></td>
        <td><%#Eval("dept_name")%></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
      </table>
    </FooterTemplate>
    </asp:Repeater>
    <!--列表展示.结束-->
    <div class="line15"></div>
    <div class="page_box">
      <div id="PageContent" runat="server" class="flickr right"></div>
      <div class="left">
         显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="txtInput2 small2" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" 
              AutoPostBack="True" Enabled="false"></asp:TextBox>条/页
      </div>
    </div>
    <div class="line10"></div>
</form>
</body>
</html>
