<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="my_edit.aspx.cs" Inherits="DTcms.Web.admin.job_order.my_edit" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑工单</title>
<link href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
<link href="../images/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
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
        var time = new Date();//用于清除缓存

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
    //打开选择客户页面并接收返回值
    function SelectCustomer() {
        var time = new Date(); //用于清除缓存

        var info = new Array(2);   //客户id,客户名称
        info = window.showModalDialog("../customer/select.aspx?time=" + time, info, "dialogHeight: 370px; dialogWidth: 600px; center: Yes; help: No; resizable: No; status: No; scroll: Yes");

        if (info != null) {
            document.getElementById("hidCustomer").value = info[0];
            document.getElementById("txtCustomer").value = info[1];
        }
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 工单管理 &gt; 编辑工单</div>
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
                <td><asp:TextBox ID="txtJobOrderName" runat="server" CssClass="txtInput normal required" maxlength="100"></asp:TextBox><label>*例：吉林农信视频会议项目</label></td>
            </tr>
            <tr>
                <th>服务类型：</th>
                <td>
                    <asp:DropDownList ID="ddlJobOrderType" runat="server" CssClass="select2 required">
                    </asp:DropDownList>
                    <label>*必选</label>
                </td>
            </tr>
            <tr>
                <th>工单描述：</th>
                <td><asp:TextBox ID="txtJobOrderDescript" runat="server" TextMode="MultiLine" CssClass="small"  onkeyup="this.value = this.value.slice(0, 50)"></asp:TextBox><label>最多可以输入50个字符</label></td>
            </tr>
            <tr>
                <th>客户名称：</th>
                <td><asp:HiddenField ID="hidCustomer" Value="" runat="server" /><asp:TextBox ID="txtCustomer" runat="server" CssClass="txtInput normal required" maxlength="100" ReadOnly="true" ></asp:TextBox>
                    <a href="javascript:SelectCustomer();"><img src="../images/icon_user.png" alt="选择客户" /></a><label>*点击图标选择</label></td>
            </tr>
            <tr>
                <th>合同编号：</th>
                <td><asp:TextBox ID="txtContractId" runat="server" CssClass="txtInput normal" maxlength="100"></asp:TextBox><label>例:JLGM20130505011A</label></td>
            </tr>
            <tr>
                <th>销售人员：</th>
                <td><asp:HiddenField ID="hidSalesman" Value="" runat="server" /><asp:TextBox ID="txtSalesman" runat="server" CssClass="txtInput normal required" maxlength="100" ReadOnly="true" ></asp:TextBox>
                    <a href="javascript:SelectUser('saler');"><img src="../images/icon_manaer.png" alt="选择销售人员" /></a><label>*点击图标选择</label></td>
            </tr>
            <tr>
                <th>工单开始日期：</th>
                <td><asp:TextBox ID="txtBeginDate" runat="server" 
                        CssClass="txtInput normal dateISO" maxlength="20" Width="200px" onclick="return Calendar('txtBeginDate');"></asp:TextBox><label>*点击输入框选择</label></td>
            </tr>
            <tr>
                <th>工单结束日期：</th>
                <td><asp:TextBox ID="txtEndDate" runat="server" CssClass="txtInput normal dateISO" 
                        maxlength="20" Width="200px" onclick="return Calendar('txtEndDate');"></asp:TextBox><label>*点击输入框选择</label></td>
            </tr>
            <tr>
                <th>技术责任人：</th>
                <td><asp:HiddenField ID="hidTechnicalResId" Value="" runat="server" /><asp:TextBox ID="txtTechnicalResId" runat="server" CssClass="txtInput normal required" maxlength="50" ReadOnly="true"></asp:TextBox>
                    <a href="javascript:SelectUser('responser');"><img src="../images/icon_manaer.png" alt="选择技术责任人" /></a><label>*点击图标选择</label></td>
            </tr>
            <tr>
                <th>工单审核人：</th>
                <td><asp:HiddenField ID="hidReviewerId" Value="" runat="server" /><asp:TextBox ID="txtReviewerId" runat="server" CssClass="txtInput normal required" maxlength="50" ReadOnly="true"></asp:TextBox>
                    <a href="javascript:SelectUser('reviewer');"><img src="../images/icon_manaer.png" alt="选择工单审核人" /></a><label>*点击图标选择</label></td>
            </tr>
            <tr>
                <th>工单干系人：</th>
                <td><asp:HiddenField ID="hidRelevant" Value="" runat="server" /><asp:TextBox ID="txtRelevant" runat="server" CssClass="txtInput normal"  maxlength="50" ReadOnly="true"></asp:TextBox>
                <a href="javascript:SelectUser('relevant');"><img src="../images/icon_manaer.png" alt="选择工单干系人" /></a><label>*点击图标选择</label></td>
            </tr>
            <tr>
                <th>工单状态：</th>
                <td><asp:TextBox ID="txtStatus" runat="server" CssClass="txtInput normal" maxlength="50"></asp:TextBox><label>无需手动输入</label></td>
            </tr>
            <tr>
                <th>审核意见：</th>
                <td><asp:TextBox ID="txtReviewAdvice" runat="server" CssClass="txtInput normal" maxlength="50"></asp:TextBox><label>无需手动输入</label></td>
            </tr>
            <tr>
                <th>工单创建者：</th>
                <td><asp:HiddenField ID="hideCreator" Value="" runat="server" /><asp:TextBox ID="txtCreator" runat="server" CssClass="txtInput normal" maxlength="50"></asp:TextBox><label>无需手动输入</label></td>
            </tr>
            <tr>
                <th>工单创建时间：</th>
                <td><asp:TextBox ID="txtCreateTime" runat="server" CssClass="txtInput normal" maxlength="50"></asp:TextBox><label>无需手动输入</label></td>
            </tr>
            <tr>
                <th></th>
                <td><asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" onclick="btnSubmit_Click" /></td>
            </tr>
            </tbody>
        </table>
    </div>
    
<%--    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="10%" align="left">日期</th>
        <th width="18%" align="left">提交人</th>
        <th width="9%" align="left">产品类型</th>
        <th width="9%" align="left">服务类型</th>
        <th width="22%" align="left">工作内容</th>
        <th width="7%" align="left">工作时长</th>
        <th width="7%" align="left">在途时长</th>
        <th width="7%" align="left">加班时长</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="left"><a href="my_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>"><%#string.Format("{0:g}", Eval("date","{0:yyyy-MM-dd}"))%></a></td>
        <td>提交人</td>
        <td><%#new DTcms.BLL.working_hour().GetProductTypeName(Convert.ToInt32(Eval("product_type")))%></td>
        <td><%#new DTcms.BLL.working_hour().GetServiceTypeName(Convert.ToInt32(Eval("service_type")))%></td>
        <td align="left"><%#Eval("working_content")%></td>
        <td align="left"><%#Eval("working_hours")%></td>
        <td align="left"><%#Eval("journey_hours")%></td>
        <td align="left"><%#Eval("overtime_hours")%></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\">暂无记录</td></tr>" : ShowTimeSum()%>
      </table>
    </FooterTemplate>
    </asp:Repeater>--%>

</div>
</form>
</body>
</html>
