<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="job_order_list.aspx.cs" Inherits="DTcms.Web.admin.working_hour.job_order_list" %>
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
    <div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 工单管理 &gt; 工时列表</div>
    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="10%" align="left">日期</th>
        <th width="10%" align="left">提交人</th>
        <th width="10%" align="left">服务类型</th>
        <th width="30%" align="left">工作内容</th>
        <th width="10%" align="left">产品类型</th>
        <th width="10%" align="left">工作时长</th>
        <th width="10%" align="left">在途时长</th>
        <th width="10%" align="left">加班时长</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="left"><a href="../working_hour/my_edit.aspx?action=<%#DTEnums.ActionEnum.View %>&id=<%#Eval("id")%>"><%#string.Format("{0:g}", Eval("date","{0:yyyy-MM-dd}"))%></a></td>
        <td><%#new DTcms.BLL.manager().GetRealName(Eval("user_name").ToString())%></td>
        <td><%#new DTcms.BLL.working_hour().GetServiceTypeName(Convert.ToInt32(Eval("service_type")))%></td>
        <td align="left"><%#Eval("working_content")%></td>
        <td><%#new DTcms.BLL.working_hour().GetProductTypeName(Convert.ToInt32(Eval("product_type")))%></td>
        <td align="left"><%#Eval("working_hours")%></td>
        <td align="left"><%#Eval("journey_hours")%></td>
        <td align="left"><%#Eval("overtime_hours")%></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ShowTimeSum()%>
      </table>
    </FooterTemplate>
    </asp:Repeater>
</form>
</body>
</html>
