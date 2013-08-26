﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;

namespace DTcms.Web.admin.manager
{
    public partial class manager_list : DTcms.Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int dept_id;
        protected string keywords;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.dept_id = DTRequest.GetQueryInt("dept_id");
            this.keywords = DTRequest.GetQueryString("keywords").Trim();
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_manager", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(""); //绑定类别
                //取得系统登录用户信息
                Model.manager model = GetAdminInfo();
                RptBind("role_type>=" + model.role_type + CombSqlTxt(this.dept_id,this.keywords), "add_time desc");
            }
        }

        #region 绑定类别=================================
        private void TreeBind(string strWhere)
        {
            BLL.dept bll = new BLL.dept();
            DataTable dt = bll.GetList(0, strWhere, "id desc").Tables[0];

            this.ddlDeptId.Items.Clear();
            this.ddlDeptId.Items.Add(new ListItem("所有部门", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlDeptId.Items.Add(new ListItem(dr["dept_name"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (this.dept_id > 0)
            {
                this.ddlDeptId.SelectedValue = this.dept_id.ToString();
            }
            this.txtKeywords.Text = this.keywords;
            BLL.manager bll = new BLL.manager();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("manager_list.aspx", "dept_id={0}&keywords={1}&page={2}",
                this.dept_id.ToString(), this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _dept_id, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_dept_id > 0)
            {
                strTemp.Append(" and dept_id=" + _dept_id);
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (user_name like '%" + _keywords + "%' or real_name like '%" + _keywords + "%')");
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
            Response.Redirect(Utils.CombUrlTxt("manager_list.aspx", "group_id={0}&keywords={1}",
                this.dept_id.ToString(), txtKeywords.Text));
        }

        //筛选类别
        protected void ddlDeptId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("manager_list.aspx", "dept_id={0}&keywords={1}",
                ddlDeptId.SelectedValue, this.keywords));
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
            Response.Redirect(Utils.CombUrlTxt("manager_list.aspx", "group_id={0}&keywords={1}",
                this.dept_id.ToString(), this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("sys_manager", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.manager bll = new BLL.manager();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked && GetAdminInfo().id != id)
                {
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("manager_list.aspx", "group_id={0}&keywords={1}",
                this.dept_id.ToString(), this.keywords), "Success");
        }

    }
}