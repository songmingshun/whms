using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using System.Text;

namespace DTcms.Web.admin.job_order
{
    public partial class relevant_edit : DTcms.Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        protected int id = 0;
        protected string name = string.Empty;

        //管理员信息
        Model.manager manager;

        protected void Page_Load(object sender, EventArgs e)
        {
            //取得管理员信息
            manager = GetAdminInfo();

            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.job_order().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                TreeBind(ddlJobOrderType);
                ShowInfo(action,this.id);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(string _action, int _id)
        {
            BLL.job_order bll = new BLL.job_order();
            Model.job_order model = bll.GetModel(_id);

            BLL.manager tmpmanager = new BLL.manager();
            BLL.customer customer = new BLL.customer();

            this.name = model.job_order_name;

            txtJobOrderName.Text = model.job_order_name;
            txtJobOrderName.Enabled = false;
            ddlJobOrderType.SelectedIndex = model.job_order_type;
            txtJobOrderDescript.Text = model.job_order_discripe;
            txtContractId.Text = model.contract_id;
            txtSalesman.Text = tmpmanager.GetRealName(model.salesman_id);
            txtBeginDate.Text = model.job_order_begintime.ToString("yyyy-MM-dd");
            txtEndDate.Text = model.job_order_endtime.ToString("yyyy-MM-dd"); ;
            txtTechnicalResId.Text = tmpmanager.GetRealName(model.technical_respon_id);
            txtReviewerId.Text = tmpmanager.GetRealName(model.job_order_reviewer_id);
            txtCreateTime.Text = model.job_order_create_time.ToString();
            txtCreator.Text = tmpmanager.GetRealName(model.job_order_creator_id);
            txtReviewAdvice.Text = model.job_order_advice;
            txtStatus.Text = model.job_order_status;

            txtCustomer.Text = customer.GetName(model.customer_id);

            string strRelevantIdList = string.Empty;
            string strRelevantNameList = string.Empty;
            if (!object.Equals(model.job_order_relevant, null))
            {
                for (int i = 0; i < model.job_order_relevant.Count; i++)
                {
                    if (strRelevantIdList.Equals(string.Empty))
                    {
                        strRelevantIdList = model.job_order_relevant[i].relevant_id;
                        strRelevantNameList = tmpmanager.GetRealName(model.job_order_relevant[i].relevant_id);
                    }
                    else
                    {
                        strRelevantIdList = strRelevantIdList + ";" + model.job_order_relevant[i].relevant_id;
                        strRelevantNameList = strRelevantNameList + ";" + tmpmanager.GetRealName(model.job_order_relevant[i].relevant_id);
                    }
                }
            }
            //hidRelevant.Value = strRelevantIdList;
            txtRelevant.Text = strRelevantNameList;

            txtJobOrderName.Enabled = false;
            ddlJobOrderType.Enabled = false;
            txtJobOrderDescript.Enabled = false;
            txtContractId.Enabled = false;
            txtSalesman.Enabled = false;
            txtBeginDate.Enabled = false;
            txtEndDate.Enabled = false;
            txtTechnicalResId.Enabled = false;
            txtReviewerId.Enabled = false;
            txtCreateTime.Enabled = false;
            txtCreator.Enabled = false;
            txtRelevant.Enabled = false;
            txtReviewAdvice.Enabled = false;
            txtStatus.Enabled = false;

            txtRelevant.Enabled = false;
            txtCustomer.Enabled = false;

            //工时列表绑定
            BLL.working_hour working_hour = new BLL.working_hour();

            rptList.DataSource = working_hour.GetJobOrderWorkingHourList(model.job_order_id);
            rptList.DataBind();

        }
        #endregion

        #region 绑定模型=================================
        private void TreeBind(DropDownList ddl)
        {
            BLL.job_order bll = new BLL.job_order();
            DataTable dt = bll.GetList().Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("请选择类型...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                ddl.Items.Add(new ListItem(dr["service_name"].ToString(), dr["service_id"].ToString()));
            }
        }
        #endregion
        #region 修改操作=================================
        private bool DoEdit(string _review,int _id)
        {
            Model.manager manager = GetAdminInfo();

            bool result = true;
            Model.job_order model = new Model.job_order();
            BLL.job_order bll = new BLL.job_order();

            model.job_order_id = _id;
            model.job_order_name = txtJobOrderName.Text.Trim();
            model.job_order_type = ddlJobOrderType.SelectedIndex;
            model.job_order_discripe = txtJobOrderDescript.Text.Trim();
            model.contract_id = txtContractId.Text.Trim();
            model.salesman_id = txtSalesman.Text.Trim();
            model.job_order_begintime = DateTime.Parse(txtBeginDate.Text.Trim());
            model.job_order_endtime = DateTime.Parse(txtEndDate.Text.Trim());
            model.technical_respon_id = txtTechnicalResId.Text.Trim();
            model.job_order_reviewer_id = txtReviewerId.Text.Trim();
            model.job_order_status = _review;
            model.job_order_create_time = DateTime.Now;
            model.job_order_creator_id = manager.user_name;
            model.job_order_advice = txtReviewAdvice.Text.Trim();

            if (!bll.Update(model))
            {
                result = false;
            }

            return result;
        }
        #endregion


        //显示工时汇总
        public string ShowTimeSum()
        {
            //取得登录系统用户信息
            Model.manager model = GetAdminInfo();
            BLL.manager bll = new BLL.manager();

            BLL.job_order bll1 = new BLL.job_order();
            Model.job_order model1 = bll1.GetModel(this.id);

            StringBuilder strReturn = new StringBuilder();
            string strWhere = "job_order_id='" + model1 .job_order_id+ "'";

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

        //隐藏“填写工时”按钮
        public bool HideLinkOrNot()
        {
            BLL.job_order bll1 = new BLL.job_order();
            Model.job_order model1 = bll1.GetModel(this.id);

            if (DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) > DateTime.Parse(model1.job_order_endtime.ToString("yyyy-MM-dd")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}