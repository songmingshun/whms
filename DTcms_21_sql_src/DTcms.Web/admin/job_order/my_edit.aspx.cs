using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.job_order
{
    public partial class my_edit : DTcms.Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        //管理员信息
        Model.manager manager;

        protected void Page_Load(object sender, EventArgs e)
        {
            //日期文本框添加日历控件
            //txtBeginDate.Attributes.Add("onclick", "return Calendar('txtBeginDate');");
            //txtEndDate.Attributes.Add("onclick", "return Calendar('txtEndDate');");

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

            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                txtJobOrderName.Text = model.job_order_name;
                txtJobOrderName.Enabled = false;
                ddlJobOrderType.SelectedIndex = model.job_order_type;
                txtJobOrderDescript.Text = model.job_order_discripe;
                txtContractId.Text = model.contract_id;
                hidSalesman.Value = model.salesman_id;
                txtSalesman.Text = tmpmanager.GetRealName(model.salesman_id);
                txtBeginDate.Text = model.job_order_begintime.ToString("yyyy-MM-dd");
                txtEndDate.Text = model.job_order_endtime.ToString("yyyy-MM-dd"); ;
                hidTechnicalResId.Value = model.technical_respon_id;
                txtTechnicalResId.Text = tmpmanager.GetRealName(model.technical_respon_id);
                hidReviewerId.Value = model.job_order_reviewer_id;
                txtReviewerId.Text = tmpmanager.GetRealName(model.job_order_reviewer_id);
                txtCreateTime.Text = model.job_order_create_time.ToString();
                txtCreator.Text = tmpmanager.GetRealName(model.job_order_creator_id);
                hideCreator.Value = model.job_order_creator_id;
                txtReviewAdvice.Text = model.job_order_advice;
                txtStatus.Text = model.job_order_status;

                hidCustomer.Value = model.customer_id.ToString();
                txtCustomer.Text = customer.GetName(model.customer_id);

                string strRelevantIdList = string.Empty;
                string strRelevantNameList = string.Empty;
                if (model.job_order_relevant != null)
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
                    hidRelevant.Value = strRelevantIdList;
                    txtRelevant.Text = strRelevantNameList;
                }
            }
            else if (action == DTEnums.ActionEnum.Add.ToString()) //添加
            {
                txtCreator.Text = manager.real_name;
                hideCreator.Value = manager.user_name;
            }

            txtCreateTime.Enabled = false;
            txtCreator.Enabled = false;
            txtReviewAdvice.Enabled = false;
            txtStatus.Enabled = false;

            if (txtStatus.Text.Equals("同意"))
            {
                txtJobOrderName.Enabled=false;
                txtJobOrderName.Enabled = false;
                ddlJobOrderType.Enabled = false;
                txtJobOrderDescript.Enabled = false;
                txtContractId.Enabled = false;
                txtSalesman.Enabled = false;
                txtBeginDate.Enabled = false;
                txtEndDate.Enabled = false;
                txtTechnicalResId.Enabled = false;
                txtReviewerId.Enabled = false;
                btnSubmit.Visible = false;
                txtRelevant.Enabled = false;
                txtCustomer.Enabled = false;
            }

            ////工时列表绑定
            //BLL.working_hour working_hour = new BLL.working_hour();

            //rptList.DataSource = working_hour.GetJobOrderWorkingHourList(model.job_order_id);
            //rptList.DataBind();

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

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.job_order model = new Model.job_order();
            BLL.job_order bll = new BLL.job_order();

            model.job_order_name = txtJobOrderName.Text.Trim();
            model.job_order_type = ddlJobOrderType.SelectedIndex;
            model.job_order_discripe = txtJobOrderDescript.Text.Trim();
            model.contract_id = txtContractId.Text.Trim();
            //model.salesman_id = txtSalesman.Text.Trim();
            model.salesman_id = hidSalesman.Value.Trim();
            model.job_order_begintime=DateTime.Parse(txtBeginDate.Text.Trim());
            model.job_order_endtime = DateTime.Parse(txtEndDate.Text.Trim());
            //model.technical_respon_id = txtTechnicalResId.Text.Trim();
            model.technical_respon_id = hidTechnicalResId.Value.Trim();
            //model.job_order_reviewer_id = txtReviewerId.Text.Trim();
            model.job_order_reviewer_id = hidReviewerId.Value.Trim();
            model.job_order_status = "未审核";
            model.job_order_create_time = DateTime.Now;
            model.job_order_creator_id = manager.user_name;

            model.customer_id = int.Parse(hidCustomer.Value.Trim());

            //model.job_order_relevant = txtRelevant.Text.Trim();
            //model.job_order_relevant = hidRelevant.Value.Trim();
            string strRelevant = hidRelevant.Value.Trim();
            if (!string.IsNullOrEmpty(strRelevant))
            {
                try
                {
                    string[] relevantArr = strRelevant.Split(';');
                    List<DTcms.Model.job_order_relevant> ls = new List<Model.job_order_relevant>();
                    for (int i = 0; i < relevantArr.Length; i++)
                    {
                        ls.Add(new DTcms.Model.job_order_relevant { relevant_id = relevantArr[i] });
                    }
                    model.job_order_relevant = ls;
                }
                catch
                {
                    result = false;
                }
            }

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
            Model.manager manager = GetAdminInfo();

            bool result = true;
            Model.job_order model = new Model.job_order();
            BLL.job_order bll = new BLL.job_order();

            model.job_order_id = _id;
            model.job_order_name = txtJobOrderName.Text.Trim();
            model.job_order_type = ddlJobOrderType.SelectedIndex;
            model.job_order_discripe = txtJobOrderDescript.Text.Trim();
            model.contract_id = txtContractId.Text.Trim();
            model.salesman_id = hidSalesman.Value.Trim();
            model.job_order_begintime = DateTime.Parse(txtBeginDate.Text.Trim());
            model.job_order_endtime = DateTime.Parse(txtEndDate.Text.Trim());
            model.technical_respon_id = hidTechnicalResId.Value.Trim();
            model.job_order_reviewer_id = hidReviewerId.Value.Trim();
            model.job_order_status = "未审核";
            //model.job_order_create_time = DateTime.Now;
            model.job_order_creator_id = manager.user_name;
            //model.job_order_relevant = hidRelevant.Value.Trim();

            model.customer_id = int.Parse(hidCustomer.Value.Trim());
            model.job_order_advice = "";

            string strRelevant = hidRelevant.Value.Trim();
            if (!string.IsNullOrEmpty(strRelevant))
            {
                try
                {
                    string[] relevantArr = strRelevant.Split(';');
                    List<DTcms.Model.job_order_relevant> ls = new List<Model.job_order_relevant>();
                    for (int i = 0; i < relevantArr.Length; i++)
                    {
                        ls.Add(new DTcms.Model.job_order_relevant { relevant_id = relevantArr[i] });
                    }
                    model.job_order_relevant = ls;
                }
                catch
                {
                    result = false;
                }
            }

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
                //ChkAdminLevel("sys_manager", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改工单成功啦！", "my_list.aspx", "Success");
            }
            else //添加
            {
                //ChkAdminLevel("sys_manager", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("创建工单成功啦！", "my_list.aspx", "Success");
            }
        }

    }
}