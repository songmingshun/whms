<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="message_detail.aspx.cs" Inherits="DTcms.Web.admin.message.message_detail" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>查看站内信</title>
<link href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
<link href="../images/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script> 
<script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
<script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
<script type="text/javascript">
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation"><a href="<%=CreateBackButtonAction() %>" class="back">后退</a>首页 &gt; 控制面板 &gt; 查看站内信</div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">查看站内信</a></li>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>标 题：</th>
                <td><asp:TextBox ID="txtTitle" runat="server" CssClass="txtInput normal required" maxlength="100" /></td>
            </tr>
            <tr>
                <th valign="top">内 容：</th>
                <td>
                    <textarea id="txtContent" cols="100" rows="8" style="width:80%;height:240px;" runat="server"></textarea>
                </td>
            </tr>
            </tbody>
        </table>
    </div>

</div>
</form>
</body>
</html>
