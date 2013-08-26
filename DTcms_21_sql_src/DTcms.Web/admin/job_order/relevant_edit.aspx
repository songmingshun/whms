<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relevant_edit.aspx.cs" Inherits="DTcms.Web.admin.job_order.relevant_edit" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑工单</title>
<link href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
<link href="../images/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script> 
<script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
<script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
<script type="text/javascript">
    //表单验证
    $(function () {
        $("#form1").validate({
            errorPlacement: function (lable, element) {
                element.ligerTip({ content: lable.html(), appendIdTo: lable });
            },
            success: function (lable) {
                lable.ligerHideTip();
            }
        });
    });
</script>
    <style type="text/css">
        .style1
        {
            width: 446px;
        }
    </style>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation"><a href="relevant_list.aspx" class="back">后退</a>
    
    <%if (HideLinkOrNot())
      {%>
    <a  style="display:;" href="../working_hour/my_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>&id=<%=id %>&name=<%=name %> "><span><u><b class="add">填写工时</b></u></span></a>
    <%} %>
    <%else
        { %>
        <a style="display:none;" href="../working_hour/my_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>&id=<%=id %>&name=<%=name %> "><span><u><b class="add">填写工时</b></u></span></a>
    <% }%>

<%--<a href="../working_hour/my_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>&id=<%=id %>&name=<%=name %> "><span><u><b class="add">填写工时</b></u></span></a></div>--%>
<div id="contentTab">
    
    <div class="tab_con" style="display:block;">
        <table style="border-style: solid; border-color: inherit; border-width: 1px; width: 100%;">
            <tbody>
            <tr>
                <td style="border:1px solid;">工单名称：</td>
                <td style="border:1px solid;" class="style1"><asp:TextBox ID="txtJobOrderName" runat="server" CssClass="txtInput normal required" maxlength="100" Width="98%"></asp:TextBox></td>
                <td style="border:1px solid;">服务类型：</td>
                <td style="border:1px solid;">
                    <asp:DropDownList ID="ddlJobOrderType" runat="server" CssClass="select2 required">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="border:1px solid;">工单描述：</td>
                <td style="border:1px solid;" class="style1">
                    <asp:TextBox ID="txtJobOrderDescript" runat="server" 
                        TextMode="MultiLine" CssClass="small" 
                        onkeyup="this.value = this.value.slice(0, 50)" Width="98%"></asp:TextBox></td>
                <td style="border:1px solid;">合同编号：</td>
                <td style="border:1px solid;"><asp:TextBox ID="txtContractId" runat="server" CssClass="txtInput normal required" maxlength="100" Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border:1px solid;">客户名称：</td>
                <td style="border:1px solid;" class="style1"><asp:TextBox ID="txtCustomer" runat="server" CssClass="txtInput normal required" maxlength="100" ReadOnly="true"  Width="98%"></asp:TextBox></td>
                <td style="border:1px solid;">销售人员：</td>
                <td style="border:1px solid;"><asp:TextBox ID="txtSalesman" runat="server" CssClass="txtInput normal required" maxlength="100"  Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border:1px solid;">工单开始日期：</td>
                <td style="border:1px solid;" class="style1"><asp:TextBox ID="txtBeginDate" runat="server" CssClass="txtInput normal required" maxlength="30" Width="98%"></asp:TextBox></td>
                <td style="border:1px solid;">工单结束日期：</td>
                <td style="border:1px solid;"><asp:TextBox ID="txtEndDate" runat="server" CssClass="txtInput normal" maxlength="30" Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border:1px solid;">技术责任人：</td>
                <td style="border:1px solid;" class="style1"><asp:TextBox ID="txtTechnicalResId" runat="server" CssClass="txtInput normal required" maxlength="50" Width="98%"></asp:TextBox></td>
                <td style="border:1px solid;">工单审核人：</td>
                <td style="border:1px solid;"><asp:TextBox ID="txtReviewerId" runat="server" CssClass="txtInput normal required" maxlength="50" Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border:1px solid;">工单干系人：</td>
                <td style="border:1px solid;" class="style1"><asp:TextBox ID="txtRelevant" runat="server" CssClass="txtInput normal"  maxlength="50" Width="98%"></asp:TextBox></td>
                <td style="border:1px solid;">工单状态：</td>
                <td style="border:1px solid;"><asp:TextBox ID="txtStatus" runat="server" CssClass="txtInput normal" maxlength="50" Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border:1px solid;">审核意见：</td>
                <td colspan="3"><asp:TextBox ID="txtReviewAdvice" runat="server" 
                        CssClass="txtInput normal" maxlength="50" Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border:1px solid;">工单创建者：</td>
                <td style="border:1px solid;" class="style1"><asp:TextBox ID="txtCreator" runat="server" CssClass="txtInput normal" maxlength="50" Width="98%"></asp:TextBox></td>
                <td style="border:1px solid;">工单创建时间：</td>
                <td style="border:1px solid;"><asp:TextBox ID="txtCreateTime" runat="server" CssClass="txtInput normal" maxlength="50" Width="98%"></asp:TextBox></td>
            </tr>
            </tbody>
        </table>
    </div>
    <div class="line10"></div>
    <div class="select_box">
	    <ul>
    	    <li style="font-weight:bold;">工作内容 <a href="../working_hour/job_order_list.aspx?id=<%=this.id%>">查看所有工时</a></li>
        </ul>
    </div>
    <div class="line10"></div>
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
</div>
</form>
</body>
</html>
