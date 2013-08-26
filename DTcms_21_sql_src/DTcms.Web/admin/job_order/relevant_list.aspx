<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relevant_list.aspx.cs" Inherits="DTcms.Web.admin.job_order.relevant_list" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>工单列表</title>
<link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
<link type="text/css" rel="stylesheet" href="../images/style.css" />
<link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 工单管理 &gt; 我相关的工单</div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box" >
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
            <%--<a href="my_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>" class="tools_btn"><span><b class="add">创建工单</b></span></a>--%>
            <%--<a href="role_list.aspx" class="tools_btn"><span><b class="return">角色管理</b></span></a>--%>
		    <%--<a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>--%>
<%--            <asp:LinkButton ID="btnAgree" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="stop">审核通过</b></span></asp:LinkButton>
                            <asp:LinkButton ID="btnReject" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="stop">审核驳回</b></span></asp:LinkButton>--%>
        </div>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="6%">选择</th>
        <th width="13%" align="left">工单名称</th>
        <th width="10%" align="left">类型</th>
        <th width="12%" align="left">创建人</th>
        <th width="12%" align="left">创建时间</th>
        <th width="10%" align="center">审核人</th>
        <th width="10%" align="center">审核状态</th>
        <th width="20%" align="left">审核意见</th>
        <th width="6%" align="center">操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("job_order_id")%>' runat="server" /></td>
        <td><a href="relevant_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("job_order_id")%>"><%#Eval("job_order_name")%></a></td>
        <%--<td><%#new DTcms.BLL.manager_role().GetTitle(Convert.ToInt32(Eval("role_id")))%></td>--%>
        <%--<td><%#Eval("job_order_name")%></td>--%>
        <td><%#Eval("service_name")%></td>
        <td><%#new DTcms.BLL.manager().GetRealName(Convert.ToString(Eval("job_order_creator_id")))%></td>
        <td><%#string.Format("{0:g}", Eval("job_order_create_time"))%></td>
        <td  align="center"><%#new DTcms.BLL.manager().GetRealName(Convert.ToString(Eval("job_order_reviewer_id")))%></td>
        <td align="center"><%#StatusImage(Eval("job_order_status").ToString())%></td>
        <td><%#Eval("job_order_advice")%></td>
        <td align="center"><a href="relevant_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("job_order_id")%>">详细</a></td>
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
             ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
      </div>
    </div>
    <div class="line10"></div>
</form>
</body>
</html>
