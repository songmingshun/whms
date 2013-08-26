<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="review_edit.aspx.cs" Inherits="DTcms.Web.admin.job_order.review_edit" %>
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
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation"><a href="review_list.aspx" class="back">后退</a>首页 &gt; 工单管理 &gt; 编辑工单</div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">编辑工单信息</a></li>
    </ul>
    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="180px"><col>
            <tbody>
            <tr>
                <th>工单名称：</th>
                <td><asp:TextBox ID="txtJobOrderName" runat="server" CssClass="txtInput normal required" maxlength="100"></asp:TextBox></td>
            </tr>
            <tr>
                <th>服务类型：</th>
                <td>
                    <asp:DropDownList ID="ddlJobOrderType" runat="server" CssClass="select2 required">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>工单描述：</th>
                <td><asp:TextBox ID="txtJobOrderDescript" runat="server" TextMode="MultiLine" CssClass="small" onkeyup="this.value = this.value.slice(0, 50)"></asp:TextBox></td>
            </tr>
            <tr>
                <th>客户名称：</th>
                <td><asp:TextBox ID="txtCustomer" runat="server" CssClass="txtInput normal required" maxlength="100" ReadOnly="true" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>合同编号：</th>
                <td><asp:TextBox ID="txtContractId" runat="server" CssClass="txtInput normal required" maxlength="100"></asp:TextBox></td>
            </tr>
            <tr>
                <th>销售人员：</th>
                <td><asp:TextBox ID="txtSalesman" runat="server" CssClass="txtInput normal required" maxlength="100" ></asp:TextBox></td>
            </tr>
            <tr>
                <th>工单开始日期：</th>
                <td><asp:TextBox ID="txtBeginDate" runat="server" CssClass="txtInput normal required" maxlength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <th>工单结束日期：</th>
                <td><asp:TextBox ID="txtEndDate" runat="server" CssClass="txtInput normal" maxlength="30"></asp:TextBox></td>
            </tr>
            <tr>
                <th>技术责任人：</th>
                <td><asp:TextBox ID="txtTechnicalResId" runat="server" CssClass="txtInput normal required" maxlength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <th>工单审核人：</th>
                <td><asp:TextBox ID="txtReviewerId" runat="server" CssClass="txtInput normal required" maxlength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <th>工单干系人：</th>
                <td><asp:TextBox ID="txtRelevant" runat="server" CssClass="txtInput normal"  maxlength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <th>工单状态：</th>
                <td><asp:TextBox ID="txtStatus" runat="server" CssClass="txtInput normal" maxlength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <th>审核意见：</th>
                <td><asp:TextBox ID="txtReviewAdvice" runat="server" CssClass="txtInput normal" maxlength="50"></asp:TextBox>
                <label>审核工单请输入审核意见。</label>
                </td>
            </tr>
            <tr>
                <th>工单创建者：</th>
                <td><asp:TextBox ID="txtCreator" runat="server" CssClass="txtInput normal" maxlength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <th>工单创建时间：</th>
                <td><asp:TextBox ID="txtCreateTime" runat="server" CssClass="txtInput normal" maxlength="50"></asp:TextBox></td>
            </tr>
            <tr>
                <th>审核：</th>
                <td>
                    <asp:RadioButtonList ID="rblReviewOrReject" runat="server"  RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="0">同意</asp:ListItem>
                        <asp:ListItem Value="1">驳回</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th></th>
                <td><asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" onclick="btnSubmit_Click" /></td>
            </tr>
            </tbody>
        </table>
    </div>
        
</div>
</form>
</body>
</html>
