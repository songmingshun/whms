<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my_edit.aspx.cs" Inherits="DTcms.Web.admin.working_hour.my_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑工时</title>
<link href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
<link href="../images/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
<script type="text/javascript" src="../../scripts/WdatePicker.js"></script>
<script type="text/javascript" src="../../scripts/calendar.js"></script>
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

    //打开选择用户页面并接收返回值
    function SelectUser(type) 
    {
        var time = new Date(); //用于清除缓存

        var info = new Array(2);   //用户账号,用户名称
        if (type == "relevant") {
            info = window.showModalDialog("../manager/select_manager_muti.aspx?time=" + time, info, "dialogHeight: 370px; dialogWidth: 430px; center: Yes; help: No; resizable: No; status: No; scroll: Yes");
        }
        else {
            info = window.showModalDialog("../manager/select_manager_single.aspx?time=" + time, info, "dialogHeight: 370px; dialogWidth: 430px; center: Yes; help: No; resizable: No; status: No; scroll: Yes");
        }

        if (info != null) {
            switch (type) {
                case 'saler':
                    document.getElementById("hidSalesman").value = info[0];
                    document.getElementById("txtSalesman").value = info[1];
                    break;
                case 'responser':
                    document.getElementById("hidTechnicalResId").value = info[0];
                    document.getElementById("txtTechnicalResId").value = info[1];
                    break;
                case 'reviewer':
                    document.getElementById("hidReviewerId").value = info[0];
                    document.getElementById("txtReviewerId").value = info[1];
                    break;
                case 'relevant':
                    document.getElementById("hidRelevant").value = info[0];
                    document.getElementById("txtRelevant").value = info[1]; 
                    break;
                default:
                    break;
            }
        }
    }

    //打开选择用户页面并接收返回值
    function SelectJobOrder() {
        var time = new Date(); //用于清除缓存
        
        var info = new Array(2);   //工单id,工单名称
        info = window.showModalDialog("../job_order/select_single.aspx?time=" + time, info, "dialogHeight: 370px; dialogWidth: 430px; center: Yes; help: No; resizable: No; status: No; scroll: Yes");

        if (info != null) {
            document.getElementById("hidJobOrderId").value = info[0];
            document.getElementById("txtJobOrderName").value = info[1];
        }
    }

//    //验证工作时长
//    $(function () {
//        $("#txtWorkingHours").change(function () {
//            var hours = $(this).val();
//            if (!isNaN(hours)) {
//                if (hours > 8) {
//                    parent.jsprint("有1项填写有误，请检查！", "", "Warning");
//                }
//            }
//        });
    //    });

    //删除附件Li节点
    function DelAttachLi(obj) {
        $.ligerDialog.confirm("确定要删除吗？", "提示信息", function (result) {
            if (result) {
                $(obj).parent().remove(); //删除节点
            }
        });
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 工时管理 &gt; 编辑工时</div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">编辑工时信息</a></li>
    </ul>
    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="180px"><col>
            <tbody>
            <tr>
                <th>日期：</th>
                <td><asp:TextBox ID="txtDate" runat="server" 
                        CssClass="txtInput normal dateISO" maxlength="20" Width="200px" onclick="return Calendar('txtDate');"></asp:TextBox><label>*点击输入框选择。</label></td>
            </tr>
            <tr>
                <th>工单名称：</th>
                <td><asp:HiddenField ID="hidJobOrderId" Value="" runat="server" /><asp:TextBox ID="txtJobOrderName" runat="server" CssClass="txtInput normal required" maxlength="100" ReadOnly="true" ></asp:TextBox>
                    <a href="javascript:SelectJobOrder();"><img src="../images/icon_channel.png" alt="选择工单" /></a><label>*点击图标选择。</label></td>
                                    <%--<td><asp:HiddenField ID="hidJobOrderId" Value="" runat="server" /><asp:TextBox ID="txtJobOrderName" runat="server" CssClass="txtInput normal required" maxlength="100" ReadOnly="false" ></asp:TextBox>--%>
            </tr>
            <tr>
                <th>产品类型：</th>
                <td>
                    <asp:DropDownList ID="ddlProductType" runat="server" CssClass="select2 required">
                    </asp:DropDownList>
                    <label>*必选</label>
                </td>
            </tr>
            <tr>
                <th>服务类型：</th>
                <td>
                    <asp:DropDownList ID="ddlServiceType" runat="server" CssClass="select2 required">
                    </asp:DropDownList>
                    <label>*必选</label>
                </td>
            </tr>
            <tr>
                <th>工作内容：</th>
                <td><asp:TextBox ID="txtWorkingContent" runat="server" TextMode="MultiLine" CssClass="small" onkeyup="this.value = this.value.slice(0, 1000)"></asp:TextBox><label>*最多可以输入1000个字符</label></td>
            </tr>
            <tr>
                <th>工作时长：</th>
                <td><asp:TextBox ID="txtWorkingHours" runat="server" CssClass="txtInput normal small required number" maxlength="4"></asp:TextBox><label>*工作时长不能超过8小时，保留一位小数</label></td>
            </tr>
            <tr>
                <th>在途时长：</th>
                <td><asp:TextBox ID="txtJourneyHours" runat="server" CssClass="txtInput normal small required number" maxlength="4"></asp:TextBox><label>*在途时长不能超过24小时，保留一位小数</label></td>
            </tr>
            <tr>
                <th>加班时长：</th>
                <td><asp:TextBox ID="txtOvertimeHours" runat="server" CssClass="txtInput normal small required number" maxlength="4"></asp:TextBox><label>*加班时长不能超过24小时，保留一位小数</label></td>
            </tr>
            <tr>
                <th>完成状态：</th>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="select2 required">
                        <asp:ListItem>请选择状态...</asp:ListItem>
                        <asp:ListItem Value="1">已完成</asp:ListItem>
                        <asp:ListItem Value="2">处理中</asp:ListItem>
                        <asp:ListItem Value="3">未完成</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th valign="top" style="padding-top:10px;">上传附件：</th>
                <td>
                    <a href="javascript:;" class="files"><input type="file" id="FileUpload2" name="FileUpload2" onchange="WHAttachUpload('AttachList','FileUpload2');" /></a>
                    <span class="uploading">正在上传，请稍候...</span>
                </td>
            </tr>
            <tr>
                <th></th>
                <td>
                    <div id="AttachList" class="attach_list">
                      <ul>
                        <asp:Repeater ID="rptAttach" runat="server">
                        <ItemTemplate>
                        <li>
                          <input name="hidFileName" type="hidden" value="<%#Eval("id")%>|<%#Eval("title")%>|<%#Eval("file_path")%>" />
                          <b class="close" title="删除" onclick="DelAttachLi(this);"></b>
                          <%--<span class="title">附件：<%#Eval("title")%></span>--%>
                          <span class="title">附件： <a href="../../tools/download.ashx?id=<%#Eval("id")%>" ><%#Eval("title")%></a></span>
                          <span><%#Convert.ToInt32(Eval("file_size")) < 1024 ? Eval("file_size").ToString() + "KB" : Convert.ToInt32(Eval("file_size"))/1024 + "MB"%></span>
                        </li>
                        </ItemTemplate>
                        </asp:Repeater>
                      </ul>
                    </div>
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
