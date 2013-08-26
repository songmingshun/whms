using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.customer
{
    public partial class edit : DTcms.Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.customer().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //取得管理员信息
                Model.manager model = GetAdminInfo();
                TreeBind();
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.customer bll = new BLL.customer();
            Model.customer model = bll.GetModel(_id);

            txtCustomerName.Text = model.name;
            ddlScale.SelectedValue = model.scale.ToString();
            ddlTrade.SelectedValue = model.trade_id.ToString();
            ddlLevel.SelectedValue = model.vip_level_id.ToString();
            txtAddress.Text = model.address;
            txtContactDept.Text = model.contact_dept;
            txtContactPerson.Text = model.contact_person;
            txtContactTelphone.Text = model.contact_telphone;

        }
        #endregion

        #region 绑定模型=================================
        private void TreeBind()
        {
            BLL.customer bll = new BLL.customer();
            
            //绑定客户级别
            DataTable dt = bll.GetLevelList().Tables[0];
            this.ddlLevel.Items.Clear();
            this.ddlLevel.Items.Add(new ListItem("请选择级别...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlLevel.Items.Add(new ListItem(dr["level_name"].ToString(), dr["id"].ToString()));
            }

            //绑定客户行业
            DataTable dt2 = bll.GetTradeList().Tables[0];
            this.ddlTrade.Items.Clear();
            this.ddlTrade.Items.Add(new ListItem("请选择行业...", ""));
            foreach (DataRow dr in dt2.Rows)
            {
                this.ddlTrade.Items.Add(new ListItem(dr["trade_name"].ToString(), dr["id"].ToString()));
            }

            //绑定客户规模
            DataTable dt3 = bll.GetScaleList().Tables[0];
            this.ddlScale.Items.Clear();
            this.ddlScale.Items.Add(new ListItem("请选择规模...", ""));
            foreach (DataRow dr in dt3.Rows)
            {
                this.ddlScale.Items.Add(new ListItem(dr["name"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 绑定模型=================================
        private void TreeBind(DropDownList ddl)
        {
            BLL.dept bll = new BLL.dept();
            DataTable dt = bll.GetList("").Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("请选择部门...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                ddl.Items.Add(new ListItem(dr["dept_name"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.customer model = new Model.customer();
            BLL.customer bll = new BLL.customer();

            //取得管理员信息
            Model.manager manager = GetAdminInfo();

            model.name = txtCustomerName.Text.Trim();
            model.scale = int.Parse(ddlScale.SelectedValue);
            model.vip_level_id = int.Parse(ddlLevel.SelectedValue);
            model.trade_id = int.Parse(ddlTrade.SelectedValue);
            model.address = txtAddress.Text.Trim();
            model.contact_dept = txtContactDept.Text.Trim();
            model.contact_person = txtContactPerson.Text.Trim();
            model.contact_telphone = txtContactTelphone.Text.Trim();
            model.creator = manager.user_name;

            if (bll.Add(model) < 1)
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = true;
            BLL.customer bll = new BLL.customer();
            Model.customer model = bll.GetModel(_id);

            model.name = txtCustomerName.Text.Trim();
            model.scale = int.Parse(ddlScale.SelectedValue);
            model.vip_level_id = int.Parse(ddlLevel.SelectedValue);
            model.trade_id = int.Parse(ddlTrade.SelectedValue);
            model.address = txtAddress.Text.Trim();
            model.contact_dept = txtContactDept.Text.Trim();
            model.contact_person = txtContactPerson.Text.Trim();
            model.contact_telphone = txtContactTelphone.Text.Trim();

            if (!bll.Update(model))
            {
                result = false;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("sys_customer", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改用户成功啦！", "list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("sys_customer", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加用户成功啦！", "list.aspx", "Success");
            }
        }

    }
}