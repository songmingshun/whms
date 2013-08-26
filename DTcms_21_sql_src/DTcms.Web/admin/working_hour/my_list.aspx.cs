using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

namespace DTcms.Web.admin.working_hour
{
    public partial class my_list : DTcms.Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        //protected string keywords;

        protected string datebegin;
        protected string dateend;

        protected void Page_Load(object sender, EventArgs e)
        {
            //获取页面参数
            this.datebegin = DTRequest.GetQueryString("datebegin").Trim();
            this.dateend = DTRequest.GetQueryString("dateend").Trim();

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

                //取得登录系统用户信息
                Model.manager model = GetAdminInfo();
                RptBind("user_name=" + "'" + model.user_name + "'" + CombSqlTxt(this.datebegin, this.dateend));
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere)
        {
            BLL.working_hour bll = new BLL.working_hour();
            this.rptList.DataSource = bll.GetList(_strWhere);
            this.rptList.DataBind();
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _datebegin,string _dateend)
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
            return strTemp.ToString();
        }
        #endregion

        //时间段查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //当前日期框返回的日期格式可能为：2013-7-1，数据库比较需要：2013-07-01，所以需要转换
            string strBeginDate = string.Empty;
            string strEndDate = string.Empty;
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
            Response.Redirect(Utils.CombUrlTxt("my_list.aspx", "datebegin={0}&dateend={1}", strBeginDate, strEndDate));
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

            StringBuilder strReturn = new StringBuilder();
            string strWhere = "user_name=" + "'" + model.user_name + "'" + CombSqlTxt(this.datebegin, this.dateend);
            BLL.working_hour bll = new BLL.working_hour();
            DataSet ds = bll.GetTimeSum(strWhere);

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
            Response.AppendHeader("Content-Disposition", "attachment;filename=My List(" + DateTime.Now.ToString("g") + ").xls");
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