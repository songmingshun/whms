<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="DTcms.Web.admin.customer.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑客户</title>
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
<div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 客户管理 &gt; 客户信息维护</div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">编辑客户信息</a></li>
    </ul>
    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="180px"><col>
            <tbody>
            <tr>
                <th>客户名：</th>
                <td><asp:TextBox ID="txtCustomerName" runat="server" 
                        CssClass="txtInput normal required" minlength="2" maxlength="100"></asp:TextBox><label>*例:吉林省农村信用社</label></td>
            </tr>
            <tr>
                <th>行业：</th>
                <td>
                    <asp:DropDownList ID="ddlTrade" runat="server" CssClass="select2 required"/>
                    <label>*必选</label>
                </td>
            </tr>
            <tr>
                <th>规模：</th>
                <td>
                    <asp:DropDownList ID="ddlScale" runat="server" CssClass="select2 required"/>
                    <label>*必选</label>
                </td>
            </tr>
            <tr>
                <th>客户级别：</th>
                <td>
                    <asp:DropDownList ID="ddlLevel" runat="server" CssClass="select2 required"/>
                    <label>*必选</label>
                </td>
            </tr>
            <tr>
                <th>地址：</th>
                <td><asp:TextBox ID="txtAddress" runat="server" CssClass="txtInput normal" MaxLength="100"></asp:TextBox>
                <label>例:长春市自由大路7555号</label>
                </td>
            </tr>
            <tr>
                <th>联系人：</th>
                <td><asp:TextBox ID="txtContactPerson" runat="server" CssClass="txtInput normal" MaxLength="100"></asp:TextBox>
                <label>例:王伟</label>
                </td>
            </tr>
            <tr>
                <th>联系电话：</th>
                <td><asp:TextBox ID="txtContactTelphone" runat="server" CssClass="txtInput normal" MaxLength="100"></asp:TextBox>
                <label>例:13600001111</label>
                </td>
            </tr>
            <tr>
                <th>联系人部门：</th>
                <td><asp:TextBox ID="txtContactDept" runat="server" CssClass="txtInput normal" MaxLength="100"></asp:TextBox>
                <label>例:科技信息部</label>
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
