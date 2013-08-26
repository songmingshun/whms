<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="center.aspx.cs" Inherits="DTcms.Web.admin.center" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>系统首页</title>
<link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
<link type="text/css" rel="stylesheet" href="images/style.css" />
<link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="js/function.js"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation nav_icon">你好，<i><%=admin_info.user_name %>(<%=new DTcms.BLL.manager_role().GetTitle(admin_info.role_id) %>)</i>，欢迎进入工时管理系统 </div>
<div class="line10"></div>

<div style="FLOAT: left; WIDTH: 49%;">
    <!--列表展示.开始-->
    <asp:Repeater ID="rptRelevantJobList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th>待处理的任务提醒</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr style="height:26px;">
        <%--<td><a href="job_order/relevant_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("job_order_id")%>"><%#Eval("job_order_name").ToString() != "" ? Eval("job_order_name") + "【" + DateTime.Parse(Eval("job_order_endtime").ToString()).ToString("yyyy-MM-dd")+ "】" : ""%></a></td>--%>
        <td><a href="javascript:parent.f_addTab('relevant_edit','我相关的任务','job_order/relevant_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("job_order_id")%>')"><%#Eval("job_order_name").ToString() != "" ? Eval("job_order_name") + "【" + DateTime.Parse(Eval("job_order_endtime").ToString()).ToString("yyyy-MM-dd")+ "】" : ""%></a></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <tr>
         <td align="right"><a href="javascript:parent.f_addTab('relevant_list','我相关的任务','job_order/relevant_list.aspx')">查看更多</a></td>
      </tr>
      </table>
    </FooterTemplate>
    </asp:Repeater>
    <!--列表展示.结束-->
</div>
<div style="FLOAT: left; WIDTH: 49%;">
    <!--列表展示.开始-->
    <asp:Repeater ID="rptDeptJobList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th>部门级任务提醒</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr style="height:26px;">
        <%--<td><a href="job_order/relevant_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("job_order_id")%>"><%#Eval("job_order_name")%></a></td>--%>
        <td><a href="javascript:parent.f_addTab('relevant_edit','我相关的任务','job_order/relevant_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("job_order_id")%>')"><%#Eval("job_order_name")%></a></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <tr>
         <td align="right"><a href="javascript:parent.f_addTab('relevant_list','我相关的任务','job_order/relevant_list.aspx')">查看更多</a></td>
      </tr>
      </table>
    </FooterTemplate>
    </asp:Repeater>
    <!--列表展示.结束-->
</div>
<div class="line10"></div>
<div style="FLOAT: left; WIDTH: 49%;">
    <!--列表展示.开始-->
    <asp:Repeater ID="rptJobOrderList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th>待审核的工单提醒</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr style="height:26px;">
        <%--<td><a href="job_order/review_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("job_order_id")%>"><%#Eval("job_order_name").ToString() != "" ? Eval("job_order_name") + "【" + DateTime.Parse(Eval("job_order_endtime").ToString()).ToString("yyyy-MM-dd")+ "】" : ""%></a></td>--%>
        
        <td>
<%--            <%if (DateTime.Now > DateTime.Parse(Eval("job_order_begintime").ToString())) %>
            <%{ %>
                <img alt="超期待审工单" src="images/ico-5.png" /><a href="javascript:parent.f_addTab('review_edit','我审核的任务','job_order/review_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("job_order_id")%>')"><%#Eval("job_order_name").ToString() != "" ? Eval("job_order_name") + "【" + DateTime.Parse(Eval("job_order_begintime").ToString()).ToString("yyyy-MM-dd")+ "】" : ""%></a>
            <%} %>
            <%else %>
            <%{ %>
                <img alt="正常待审工单" src="images/ico-5_.png" /><a href="javascript:parent.f_addTab('review_edit','我审核的任务','job_order/review_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("job_order_id")%>')"><%#Eval("job_order_name").ToString() != "" ? Eval("job_order_name") + "【" + DateTime.Parse(Eval("job_order_begintime").ToString()).ToString("yyyy-MM-dd")+ "】" : ""%></a>
            <%} %>--%>

<%--            <%#Eval("job_order_begintime").ToString().Trim().CompareTo(DateTime.Now.ToString()) == 0 ? "<img title=\"超期待审工单\" src=\"images/ico-5.png\" />" : "<img title=\"正常待审工单\" src=\"images/ico-5_.png\" />"%>
            <a href="javascript:parent.f_addTab('review_edit','我审核的任务','job_order/review_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("job_order_id")%>')"><%#Eval("job_order_name").ToString() != "" ? Eval("job_order_name") + "【" + DateTime.Parse(Eval("job_order_begintime").ToString()).ToString("yyyy-MM-dd")+ "】" : ""%></a>
        --%>
            <%# ShowJobOrderImage(Eval("job_order_begintime").ToString())%>
            <a href="javascript:parent.f_addTab('review_edit','我审核的任务','job_order/review_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("job_order_id")%>')"><%#Eval("job_order_name").ToString() != "" ? Eval("job_order_name") + "【" + DateTime.Parse(Eval("job_order_begintime").ToString()).ToString("yyyy-MM-dd")+ "】" : ""%></a>

        </td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <tr>
        <td align="right"><a href="javascript:parent.f_addTab('review_list','我审核的工单','job_order/review_list.aspx')">查看更多</a></td>
      </tr>
      </table>
    </FooterTemplate>
    </asp:Repeater>
    <!--列表展示.结束-->
</div>
<div style="FLOAT: left; WIDTH: 49%;">
    <!--列表展示.开始-->
    <asp:Repeater ID="rptMessageList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th>未读邮件提醒</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr style="height:26px;">
        <%--<td><a href="message/message_detail.aspx?action=<%#DTEnums.ActionEnum.View %>&id=<%#Eval("id")%>&is_read=<%#Eval("is_read")%>"><%#Eval("title")%>  <%#Eval("post_user_name")%>  <%#Eval("post_time")%></a></td>--%>
        <td><a href="javascript:parent.f_addTab('message_detail','站内信','message/message_detail.aspx?action=<%#DTEnums.ActionEnum.View %>&id=<%#Eval("id")%>&is_read=<%#Eval("is_read")%>')"><%#Eval("title")%>  <%#Eval("post_user_name")%>  <%#Eval("post_time")%></a></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <tr>
         <td align="right"><a href="javascript:parent.f_addTab('message_list','站内信','message/message_list.aspx')">查看更多</a></td>
      </tr>
      </table>
    </FooterTemplate>
    </asp:Repeater>
    <!--列表展示.结束-->
</div>

</form>
</body>
</html>