﻿using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.message
{
    public partial class message_list_post : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int type_id;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.type_id = DTRequest.GetQueryInt("type_id");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
                //取得系统登录用户信息
                Model.manager model = GetAdminInfo();

                //ChkAdminLevel("user_message", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind("(post_user_name='"+model.user_name+"')" + CombSqlTxt(this.type_id, this.keywords), "post_time desc,id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (this.type_id > 0)
            {
                this.ddlType.SelectedValue = this.type_id.ToString();
            }
            this.txtKeywords.Text = this.keywords;
            BLL.user_message bll = new BLL.user_message();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("message_list_post.aspx", "type_id={0}&keywords={1}&page={2}",
                this.type_id.ToString(), this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _type_id, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_type_id > 0)
            {
                strTemp.Append(" and type=" + _type_id);
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (accept_user_name like '%" + _keywords + "%' or post_user_name like '%" + _keywords + "%' or title like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
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

        #region 返回短信类型=============================
        protected string GetMessageType(int _type)
        {
            string result = string.Empty;
            switch (_type)
            {
                case 1:
                    result = "系统消息";
                    break;
                case 2:
                    result = "收件箱";
                    break;
                case 3:
                    result = "发件箱";
                    break;
            }
            return result;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("message_list_post.aspx", "type_id={0}&keywords={1}",
                this.type_id.ToString(), txtKeywords.Text));
        }

        //筛选类别
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strUrl = string.Empty;
            if (ddlType.SelectedValue == "3")
            {
                strUrl = "message_list_post.aspx";
            }
            else
            {
                strUrl = "message_list.aspx";
            }

            Response.Redirect(Utils.CombUrlTxt(strUrl, "type_id={0}&keywords={1}",
                ddlType.SelectedValue, this.keywords));
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
            Response.Redirect(Utils.CombUrlTxt("message_list_post.aspx", "type_id={0}&keywords={1}",
                this.type_id.ToString(), this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("user_message", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.user_message bll = new BLL.user_message();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("message_list_post.aspx", "type_id={0}&keywords={1}",
                this.type_id.ToString(), this.keywords), "Success");
        }
    }
}