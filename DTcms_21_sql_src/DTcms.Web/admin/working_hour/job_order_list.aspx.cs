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
    public partial class job_order_list : DTcms.Web.UI.ManagePage
    {
        protected string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            //获取页面参数
            this.id = DTRequest.GetQueryString("id").Trim();

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_manager", DTEnums.ActionEnum.View.ToString()); //检查权限

                //取得登录系统用户信息
                Model.manager model = GetAdminInfo();
                RptBind(" job_order_id=" + this.id);
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

        //显示工时汇总
        public string ShowTimeSum()
        {
            //取得登录系统用户信息
            Model.manager model = GetAdminInfo(); 
            BLL.manager bll = new BLL.manager();

            BLL.job_order bll1 = new BLL.job_order();
            Model.job_order model1 = bll1.GetModel(int.Parse(this.id));

            StringBuilder strReturn = new StringBuilder();
            string strWhere = "job_order_id='" + model1.job_order_id + "'";

            BLL.working_hour bll2 = new BLL.working_hour();
            DataSet ds = bll2.GetDeptTimeSum(strWhere);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];

                strReturn.Append("<tr>");
                strReturn.Append("<td></td>");
                strReturn.Append("<td></td>");
                strReturn.Append("<td></td>");

                strReturn.Append("<td style=\"font-weight:bold;color:red\">共计 " + dr["count"] + " 条</td>");
                strReturn.Append("<td style=\"font-weight:bold;color:red\">合计：</td>");

                strReturn.Append("<td style=\"font-weight:bold;color:red\">" + dr["sum_working"] + "</td>");
                strReturn.Append("<td style=\"font-weight:bold;color:red\">" + dr["sum_journey"] + "</td>");
                strReturn.Append("<td style=\"font-weight:bold;color:red\">" + dr["sum_overtime"] + "</td>");
                strReturn.Append("</tr>");

            }

            return strReturn.ToString();
        }
    }
}