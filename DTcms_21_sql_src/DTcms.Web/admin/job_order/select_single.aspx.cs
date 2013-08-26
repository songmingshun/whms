using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.job_order
{
    public partial class select_single : DTcms.Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = DTRequest.GetQueryString("keywords").Trim();
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_manager", DTEnums.ActionEnum.View.ToString()); //检查权限
                //取得登录系统用户信息
                Model.manager model = GetAdminInfo();
                //RptBind("role_type>=" + model.role_type + CombSqlTxt(this.keywords), "add_time desc");
                //RptBind("((job_order_id IN (SELECT job_order_id FROM gm_dt_job_order_relevant WHERE (technician_id = " + "'" + model.user_name + "'))) OR (salesman_id='" + model.user_name + "' or technical_respon_id='" + model.user_name + "') AND job_order_status='同意' )" + CombSqlTxt(this.keywords), "job_order_create_time desc");
                //RptBind("((salesman_id='" + model.user_name + "' OR technical_respon_id='" + model.user_name + "') AND job_order_status='同意' )" + CombSqlTxt(this.keywords), "job_order_create_time desc");
                StringBuilder strWhere = new StringBuilder();
                strWhere.Append("((job_order_id IN ");
                strWhere.Append("(SELECT job_order_id from gm_dt_job_order_relevant where relevant_id='" + model.user_name + "') ");
                strWhere.Append("OR (salesman_id='" + model.user_name + "' ");
                strWhere.Append("OR technical_respon_id='" + model.user_name + "' ");
                strWhere.Append("OR job_order_creator_id='" + model.user_name + "' ");
                strWhere.Append("OR job_order_reviewer_id='" + model.user_name + "' ");
                strWhere.Append(")) AND job_order_status='同意' ");
                strWhere.Append("AND CONVERT(varchar(10),job_order_endtime,120)>=CONVERT(varchar(10),getdate(),120) )");
                strWhere.Append(CombSqlTxt(this.keywords));

                RptBind(strWhere.ToString(), "job_order_create_time desc");
                //RptBind("((job_order_id IN (SELECT job_order_id from gm_dt_job_order_relevant where relevant_id='" + model.user_name + "') OR (salesman_id='" + model.user_name + "' OR technical_respon_id='" + model.user_name + "' OR job_order_creator_id='" + model.user_name + "' OR job_order_reviewer_id='" + model.user_name + "')) AND job_order_status='同意' )" + CombSqlTxt(this.keywords), "job_order_create_time desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            BLL.job_order bll = new BLL.job_order();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("select_single.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (job_order_name like '%" + _keywords + "%' )");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("manager_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("select_single.aspx", "keywords={0}", txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("manager_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("select_single.aspx", "keywords={0}", this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("sys_manager", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.job_order bll = new BLL.job_order();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked && GetAdminInfo().id != id)
                {
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("select_single.aspx", "keywords={0}", this.keywords), "Success");
        }

        //审核状态图片展示
        public string StatusImage(string strStatus)
        {
            string strTmp = strStatus;
            if (strStatus == "同意")
            {
                strTmp = "<img title=\"同意\" src=\"../images/icon_correct.png\" />";
            }
            else if (strStatus == "驳回")
            {
                strTmp = "<img title=\"驳回\" src=\"../images/icon_no.png\" />";
            }
            else if (strStatus == "未审核")
            {
                strTmp = "<img title=\"未审核\" src=\"../images/icon_msg.gif\" />";
            }
            return strTmp;
        }
    }
}