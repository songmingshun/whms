using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;

namespace DTcms.Web.admin.working_hour
{
    public partial class dept_list : DTcms.Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        //protected string keywords;

        protected string datebegin;
        protected string dateend;

        protected int joborderindex=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //获取页面参数
            this.datebegin = DTRequest.GetQueryString("datebegin").Trim();
            this.dateend = DTRequest.GetQueryString("dateend").Trim();
            if (!string.IsNullOrEmpty(DTRequest.GetQueryString("joborderindex").Trim()))
            {
                this.joborderindex = int.Parse(DTRequest.GetQueryString("joborderindex").Trim()); 
            }

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_manager", DTEnums.ActionEnum.View.ToString()); //检查权限

                //显示参数到页面
                if (!string.IsNullOrEmpty(this.datebegin))
                {
                    txtDataBegin.Text = this.datebegin;
                }
                else 
                {
                    txtDataBegin.Text = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).ToString("yyyy-MM-dd");
                    this.datebegin = txtDataBegin.Text;
                }
                if (!string.IsNullOrEmpty(this.dateend))
                {
                    txtDataEnd.Text = this.dateend;
                }
                else
                {
                    txtDataEnd.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    this.dateend = txtDataEnd.Text;
                }

                //绑定工单列表
                TreeBind(ddlJobOrder);

                //设置选中项
                ddlJobOrder.SelectedIndex = this.joborderindex;

                //取得登录系统用户信息
                Model.manager model = GetAdminInfo();
                BLL.manager bll = new BLL.manager();
                RptBind("dept_id=" + "'" + model.dept_id + "' and (role_value>" + bll.GetRoleValue(model.role_id) + " or user_name='" + model.user_name + "')" + CombSqlTxt(this.datebegin, this.dateend, ddlJobOrder.SelectedValue));
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere)
        {
            BLL.working_hour bll = new BLL.working_hour();
            this.rptList.DataSource = bll.GetDeptWorkingHourList(_strWhere);
            this.rptList.DataBind();
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _datebegin,string _dateend,string _joborderid)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!string.IsNullOrEmpty(_datebegin))
            {
                strTemp.Append(" and (CONVERT(varchar(10), date, 120) >= '" + _datebegin + "')");
            }
            if (!string.IsNullOrEmpty(_dateend))
            {
                strTemp.Append(" and (CONVERT(varchar(10), date, 120) <= '" + _dateend + "')");
            }
            if (!string.IsNullOrEmpty(_joborderid))
            {
                strTemp.Append(" and (job_order_id = " + _joborderid + " )");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 绑定工单下拉框=================================
        private void TreeBind(DropDownList ddl)
        {
            //取得登录系统用户信息
            Model.manager model = GetAdminInfo();

            BLL.job_order bll = new BLL.job_order();
            DataTable dt = bll.GetWorkingHourJobOrderList(model.dept_id).Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("请选择工单...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                ddl.Items.Add(new ListItem(dr["job_order_name"].ToString(), dr["job_order_id"].ToString()));
            }
        }
        #endregion

        //时间段查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //当前日期框返回的日期格式可能为：2013-7-1，数据库比较需要：2013-07-01，所以需要转换
            string strBeginDate = string.Empty;
            string strEndDate = string.Empty;
            string strJobOrderId = string.Empty;
            try
            {
                strBeginDate = (DateTime.Parse(txtDataBegin.Text)).ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                strBeginDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            try
            {
                strEndDate = (DateTime.Parse(txtDataEnd.Text)).ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                strEndDate = DateTime.Now.ToString("yyyy-MM-dd");
            }

            //if (!string.IsNullOrEmpty(ddlJobOrder.SelectedValue))
            //{
            //    strJobOrderId = ddlJobOrder.SelectedValue.ToString();
            //}

            Response.Redirect(Utils.CombUrlTxt("dept_list.aspx", "datebegin={0}&dateend={1}&joborderindex={2}", strBeginDate, strEndDate, ddlJobOrder.SelectedIndex.ToString()));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("sys_manager", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.working_hour bll = new BLL.working_hour();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked && GetAdminInfo().id != id)
                {
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("my_list.aspx", "datebegin={0}", "dateend={1}", this.datebegin,this.dateend), "Success");
        }

        //显示工时汇总
        public string ShowTimeSum()
        {
            //取得登录系统用户信息
            Model.manager model = GetAdminInfo();
            BLL.manager bll = new BLL.manager();

            StringBuilder strReturn = new StringBuilder();
            string strWhere = "dept_id=" + "'" + model.dept_id + "' and (role_value>" + bll.GetRoleValue(model.role_id) + " or user_name='" + model.user_name + "')" + CombSqlTxt(this.datebegin, this.dateend,ddlJobOrder.SelectedValue);
            BLL.working_hour bll1 = new BLL.working_hour();
            DataSet ds = bll1.GetDeptTimeSum(strWhere);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];

                strReturn.Append("<tr>");
                strReturn.Append("<td colspan=4></td>");
                strReturn.Append("<td style=\"font-weight:bold;color:red\">共计 " + dr["count"] + " 条</td>");
                strReturn.Append("<td style=\"font-weight:bold;color:red\" >合计：</td>");
                strReturn.Append("<td style=\"font-weight:bold;color:red\">" + dr["sum_working"] + "</td>");
                strReturn.Append("<td style=\"font-weight:bold;color:red\">" + dr["sum_journey"] + "</td>");
                strReturn.Append("<td style=\"font-weight:bold;color:red\" colspan=2>" + dr["sum_overtime"] + "</td>");
                strReturn.Append("</tr>");
                    
            }

            return strReturn.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "gb2312";
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment;filename=Dept List(" + DateTime.Now.ToString("g") + ").xls");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            this.EnableViewState = false;
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            rptList.RenderControl(oHtmlTextWriter);
            Response.Write("<meta http-equiv=Content-Type content=text/html;charset=GB2312>");
            Response.Write(oStringWriter.ToString());
            Response.Flush();
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}