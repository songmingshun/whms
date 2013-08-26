<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="select_manager_muti.aspx.cs" Inherits="DTcms.Web.admin.manager.select_manager_muti" %>
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

    //根据复选框的选中情况获取人员信息
    function GetMutiItems() {
        var chks = $('input[id$=_chkId]');
        var hidids = $('input[id$=_hidId]');
        var hidnames = $('input[id$=_hidName]');
        var split = ";";
        var idlist = "";
        var namelist = "";
        for (var i = 0; i < chks.length; i++) {

            if (chks[i].checked == true) {
                var id = hidids[i].value;
                var name = hidnames[i].value;
                if (idlist == "") {
                    idlist = id;
                    namelist = name;
                }
                else {
                    idlist = idlist + split + id;
                    namelist = namelist + split + name;
                }
            }
        }
        ReturnDialogResult(idlist, namelist);
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
            <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
        </div>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="10%">选择</th>
        <th width="30%" align="left">账号</th>
        <th width="30%" align="left">姓名</th>
        <th width="30%" align="left">部门</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <%--<td><a href="manager_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>"><%#Eval("user_name")%></a></td>--%>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("user_name")%>' runat="server" /><asp:HiddenField ID="hidName" Value='<%#Eval("real_name")%>' runat="server" /></td>
        <%--<td><a href="javascript:ReturnDialogResult('<%#Eval("user_name")%>','<%#Eval("real_name")%>');"><%#Eval("user_name")%></a></td>--%>
        <td><%#Eval("user_name")%></td>
        <td><%#Eval("real_name")%></td>
        <td><%#Eval("dept_name")%></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ""%>
      </table>
    </FooterTemplate>
    </asp:Repeater>
<%--    <!--列表展示.结束-->
    <div class="line15"></div>
    <div class="page_box">
      <div id="PageContent" runat="server" class="flickr right"></div>
      <div class="left">
         显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="txtInput2 small2" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" 
              AutoPostBack="True"></asp:TextBox>条/页
      </div>
    </div>
    <div class="line10"></div>--%>
        <div class="foot_btn_box">
        <input name="确定" type="reset" class="btnSubmit" value="确定" onclick="GetMutiItems();" />
        <input name="取消" type="reset" class="btnSubmit" value="取消" onclick="javascript:window.close();"/>
    </div>
</form>
</body>
</html>
