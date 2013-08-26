using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
using System.Text;

namespace DTcms.Web.admin
{
    public partial class center : Web.UI.ManagePage
    {
        protected Model.manager admin_info;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                admin_info = GetAdminInfo(); //管理员信息
                Utils.GetDomainStr("dt_cache_domain_info", "http://www.dtcms.net/upgrade.ashx?u=" + Request.Url.DnsSafeHost + "&i=" + Request.ServerVariables["LOCAL_ADDR"]);

                //绑定待审核
                BLL.job_order job_order = new BLL.job_order();
                DataSet ds = new DataSet();
                ds = job_order.GetUnreviewListForDesktop(admin_info.user_name);
                int iCount = ds.Tables[0].Rows.Count;
                if (iCount < 10)
                {
                    for (int i = 0; i < 10 - iCount; i++) 
                    {
                        DataRow dr = ds.Tables[0].NewRow();
                        ds.Tables[0].Rows.Add(dr);
                    }
                }

                rptJobOrderList.DataSource = ds;
                rptJobOrderList.DataBind();

                //绑定未读
                BLL.user_message user_message = new BLL.user_message();
                DataSet ds2 = new DataSet();
                ds2 = user_message.GetUnreadListForDesktop(admin_info.user_name);

                int iCount2 = ds2.Tables[0].Rows.Count;
                if (iCount2 < 10)
                {
                    for (int i = 0; i < 10 - iCount2; i++)
                    {
                        DataRow dr = ds2.Tables[0].NewRow();
                        ds2.Tables[0].Rows.Add(dr);
                    }
                }
                rptMessageList.DataSource = ds2;
                rptMessageList.DataBind();

                //绑定待处理任务
                //BLL.user_message user_message = new BLL.user_message();
                DataSet ds3 = new DataSet();
                ds3 = job_order.GetRelevantListForDesktop(admin_info.user_name);

                int iCount3 = ds3.Tables[0].Rows.Count;
                if (iCount3 < 10)
                {
                    for (int i = 0; i < 10 - iCount3; i++)
                    {
                        DataRow dr = ds3.Tables[0].NewRow();
                        ds3.Tables[0].Rows.Add(dr);
                    }
                }
                rptRelevantJobList.DataSource = ds3;
                rptRelevantJobList.DataBind();
                
                //绑定部门级任务
                //BLL.user_message user_message = new BLL.user_message();
                DataSet ds4 = new DataSet();
                ds4 = job_order.GetDeptListForDesktop(admin_info.dept_id);

                int iCount4 = ds4.Tables[0].Rows.Count;
                if (iCount4 < 10)
                {
                    for (int i = 0; i < 10 - iCount4; i++)
                    {
                        DataRow dr = ds4.Tables[0].NewRow();
                        ds4.Tables[0].Rows.Add(dr);
                    }
                }
                rptDeptJobList.DataSource = ds4;
                rptDeptJobList.DataBind();
            }
        }

        //工单图标
        public string ShowJobOrderImage(string begintime)
        {
            string strReturn=string.Empty;
            if (begintime == string.Empty)
            {
                return strReturn;
            }
            if (DateTime.Parse(begintime).CompareTo(DateTime.Now) < 0)
            {
                strReturn = "<img alt=\"超期待审工单\" src=\"images/ico-5.png\" />";
            }
            else
            {
                strReturn = "<img alt=\"正常待审工单\" src=\"images/ico-5_.png\" />";
            }

            return strReturn.ToString();
        }
    }
}