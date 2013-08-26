<%@ Page Language="C#"EnableEventValidation = "false"  AutoEventWireup="true" CodeBehind="my_list.aspx.cs" Inherits="DTcms.Web.admin.working_hour.my_list" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>工时列表</title>
<link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
<link type="text/css" rel="stylesheet" href="../images/style.css" />
<link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../scripts/WdatePicker.js"></script>
<script type="text/javascript" src="../../scripts/calendar.js"></script>
<script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 工时管理 &gt; 我的工时</div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
                <label>起始时间：</label>
			    <asp:TextBox ID="txtDataBegin" runat="server" CssClass="input txt required dateISO" onclick="return Calendar('txtDataBegin');"></asp:TextBox>
                <label>截止时间：</label>
                <asp:TextBox ID="txtDataEnd" runat="server" CssClass="input txt required dateISO" onclick="return Calendar('txtDataEnd');"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
                <asp:Button ID="Button1" runat="server" Text="导 出" CssClass="btnSearch" onclick="Button1_Click" />
		    </div>
            <a href="my_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>" class="tools_btn"><span><b class="add">填写工时</b></span></a>
		    <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>
        </div>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="5%">选择</th>
        <th width="10%" align="left">日期</th>
        <th width="18%" align="left">工单名称</th>
        <th width="9%" align="left">产品类型</th>
        <th width="9%" align="left">服务类型</th>
        <th width="22%" align="left">工作内容</th>
        <th width="7%" align="left">工作时长</th>
        <th width="7%" align="left">在途时长</th>
        <th width="7%" align="left">加班时长</th>
        <th width="6%" align="center">操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></td>
        <td align="left"><%#string.Format("{0:g}", Eval("date","{0:yyyy-MM-dd}"))%></td>
        <td><%#new DTcms.BLL.working_hour().GetJobOrderName(Convert.ToInt32(Eval("job_order_id")))%></td>
        <td><%#new DTcms.BLL.working_hour().GetProductTypeName(Convert.ToInt32(Eval("product_type")))%></td>
        <td><%#new DTcms.BLL.working_hour().GetServiceTypeName(Convert.ToInt32(Eval("service_type")))%></td>
        <td align="left"><%#Eval("working_content")%></td>
        <td align="left"><%#Eval("working_hours")%></td>
        <td align="left"><%#Eval("journey_hours")%></td>
        <td align="left"><%#Eval("overtime_hours")%></td>
        <td align="center"><a href="my_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ShowTimeSum()%>
      </table>
    </FooterTemplate>
    </asp:Repeater>
<%--    <!--列表展示.结束-->
    <div class="line15"></div>
    <div class="page_box">
      <div id="PageContent" runat="server" class="flickr right"></div>
      <div class="left">
         显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="txtInput2 small2" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" 
             ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
      </div>
    </div>
    <div class="line10"></div>--%>
</form>
</body>
</html>
