using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.working_hour
{
    public partial class my_edit : DTcms.Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private string job_order_id = string.Empty;
        private string job_order_name = string.Empty;

        //管理员信息
        Model.manager manager;

        protected void Page_Load(object sender, EventArgs e)
        {
            //取得管理员信息
            manager = GetAdminInfo();

            action = DTRequest.GetQueryString("action");
            job_order_id = DTRequest.GetQueryString("id");
            job_order_name = DTRequest.GetQueryString("name");
            if (!string.IsNullOrEmpty(action) && (action == DTEnums.ActionEnum.Edit.ToString()||action == DTEnums.ActionEnum.View.ToString()))
            {
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.working_hour().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                TreeBind(ddlProductType, "gm_dt_product_type");
                TreeBind(ddlServiceType, "gm_dt_service_type");
                ShowInfo(action,this.id);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(string _action, int _id)
        {
            BLL.working_hour bll = new BLL.working_hour();
            Model.working_hour model = bll.GetModel(_id);

            BLL.manager tmpmanager = new BLL.manager();

            if (_action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                txtDate.Text = model.date.ToString("yyyy-MM-dd");
                txtJobOrderName.Text = bll.GetJobOrderName(model.job_order_id);
                hidJobOrderId.Value = model.job_order_id.ToString() ;
                ddlProductType.SelectedIndex = model.product_type;
                ddlServiceType.SelectedIndex = model.service_type;
                txtWorkingContent.Text = model.working_content;
                ddlStatus.SelectedIndex = model.status;
                txtWorkingHours.Text = model.working_hours.ToString(); 
                txtJourneyHours.Text = model.journey_hours.ToString();
                txtOvertimeHours.Text = model.overtime_hours.ToString();

                //绑定附件
                rptAttach.DataSource = model.download_attachs;
                rptAttach.DataBind();
            }
            else if (_action == DTEnums.ActionEnum.View.ToString()) //查看
            {
                txtDate.Text = model.date.ToString("yyyy-MM-dd");
                txtJobOrderName.Text = bll.GetJobOrderName(model.job_order_id);
                hidJobOrderId.Value = model.job_order_id.ToString();
                ddlProductType.SelectedIndex = model.product_type;
                ddlServiceType.SelectedIndex = model.service_type;
                txtWorkingContent.Text = model.working_content;
                ddlStatus.SelectedIndex = model.status;
                txtWorkingHours.Text = model.working_hours.ToString();
                txtJourneyHours.Text = model.journey_hours.ToString();
                txtOvertimeHours.Text = model.overtime_hours.ToString();

                txtDate.Enabled = false;
                txtJobOrderName.Enabled = false;
                ddlProductType.Enabled = false;
                ddlServiceType.Enabled = false;
                txtWorkingContent.Enabled = false;
                ddlStatus.Enabled = false;
                ddlProductType.Enabled = false;
                txtJourneyHours.Enabled = false;
                txtOvertimeHours.Enabled = false;
                txtWorkingHours.Enabled = false;

                btnSubmit.Visible = false;

                //绑定附件
                rptAttach.DataSource = model.download_attachs;
                rptAttach.DataBind();
            }
            else
            {
                hidJobOrderId.Value = this.job_order_id;
                txtJobOrderName.Text = this.job_order_name;
            }

        }
        #endregion

        #region 绑定模型=================================
        private void TreeBind(DropDownList ddl,string table)
        {
            BLL.working_hour bll = new BLL.working_hour();
            DataTable dt = bll.GetTypeList(table).Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("请选择类型...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                ddl.Items.Add(new ListItem(dr["name"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.working_hour model = new Model.working_hour();
            BLL.working_hour bll = new BLL.working_hour();

            model.user_name = manager.user_name;
            model.date = DateTime.Parse(txtDate.Text.Trim());
            //model.job_order_id = int.Parse(hidJobOrderId.Value.Trim());
            model.job_order_id = Convert.ToInt32(hidJobOrderId.Value.Trim());
            model.product_type = Convert.ToByte(ddlProductType.SelectedIndex);
            model.service_type = Convert.ToByte(ddlServiceType.SelectedIndex);
            model.working_content = txtWorkingContent.Text.Trim();
            model.status = Convert.ToByte(ddlStatus.SelectedIndex);
            model.working_hours = decimal.Parse(txtWorkingHours.Text.ToString());
            model.journey_hours = decimal.Parse(txtJourneyHours.Text.ToString());
            model.overtime_hours = decimal.Parse(txtOvertimeHours.Text.ToString());
            model.create_time = DateTime.Now;

            //保存附件
            string hidFileList = Request.Params["hidFileName"];
            if (!string.IsNullOrEmpty(hidFileList))
            {
                string[] fileListArr = hidFileList.Split(',');
                List<Model.download_attach> ls = new List<Model.download_attach>();
                for (int i = 0; i < fileListArr.Length; i++)
                {
                    string[] fileArr = fileListArr[i].Split('|');
                    if (fileArr.Length == 3)
                    {
                        int fileSize = Utils.GetFileSize(fileArr[2]);
                        string fileExt = Utils.GetFileExt(fileArr[2]);
                        ls.Add(new Model.download_attach { id = int.Parse(fileArr[0]), title = fileArr[1], file_path = fileArr[2], file_size = fileSize, file_ext = fileExt });
                    }
                }
                model.download_attachs = ls;
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
            Model.working_hour model = new Model.working_hour();
            BLL.working_hour bll = new BLL.working_hour();

            model.id = this.id;
            model.date = DateTime.Parse(txtDate.Text.Trim());
            model.job_order_id = Convert.ToInt32(hidJobOrderId.Value.Trim());
            model.product_type = Convert.ToByte(ddlProductType.SelectedIndex);
            model.service_type = Convert.ToByte(ddlServiceType.SelectedIndex);
            model.working_content = txtWorkingContent.Text.Trim();
            model.status = Convert.ToByte(ddlStatus.SelectedIndex);
            model.working_hours = decimal.Parse(txtWorkingHours.Text.ToString());
            model.journey_hours = decimal.Parse(txtJourneyHours.Text.ToString());
            model.overtime_hours = decimal.Parse(txtOvertimeHours.Text.ToString());

            //保存附件
            if (model.download_attachs != null)
            {
                model.download_attachs.Clear();
            }
            string hidFileList = Request.Params["hidFileName"];
            if (!string.IsNullOrEmpty(hidFileList))
            {
                string[] fileListArr = hidFileList.Split(',');
                List<Model.download_attach> ls = new List<Model.download_attach>();
                for (int i = 0; i < fileListArr.Length; i++)
                {
                    string[] fileArr = fileListArr[i].Split('|');
                    if (fileArr.Length == 3)
                    {
                        int attach_id = int.Parse(fileArr[0]);
                        int fileSize = Utils.GetFileSize(fileArr[2]);
                        string fileExt = Utils.GetFileExt(fileArr[2]);
                        //删除旧文件
                        if (attach_id > 0)
                        {
                            new BLL.download_attach().DeleteFile(attach_id, fileArr[2]);
                        }
                        ls.Add(new Model.download_attach { id = attach_id, article_id = _id, title = fileArr[1], file_path = fileArr[2], file_size = fileSize, file_ext = fileExt });
                    }
                }
                model.download_attachs = ls;
            }

            if (!bll.Update(model))
            {
                result = false;
            }

            return result;
        }
        #endregion

        #region 验证时长=================================
        //验证工作时长、在途时长、加班时长是否合法
        //工作时长不能超过8小时，加班时长和在途时长不能超过24小时
        //工作时长+在途时长+加班时长<=24小时
        private string CheckHours()
        {
            string strReturn=string.Empty;
            decimal working_hours = decimal.Parse(txtWorkingHours.Text.ToString());
            decimal journey_hours = decimal.Parse(txtJourneyHours.Text.ToString());
            decimal overtime_hours = decimal.Parse(txtOvertimeHours.Text.ToString());

            if (working_hours > 8)
            {
                strReturn = "工作时长不能超过8小时！";
                return strReturn;
            }

            if (journey_hours>24)
            {
                strReturn = "在途时长不能超过24小时！";
                return strReturn;
            }

            if (overtime_hours > 24)
            {
                strReturn = "加班时长不能超过24小时！";
                return strReturn;
            }

            if (working_hours + journey_hours + overtime_hours > 24)
            {
                strReturn = "工作时长、在途时长、加班时长的总和不能超过24小时！";
            }
            
            return strReturn;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strMsg = CheckHours();
            if (strMsg != string.Empty)
            {
                JscriptMsg(strMsg, "", "Error");
                return;
            }

            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                //ChkAdminLevel("sys_manager", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改工时成功啦！", "my_list.aspx", "Success");
            }
            else //添加
            {
                //ChkAdminLevel("sys_manager", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                if (job_order_id.Equals(string.Empty))
                {
                    JscriptMsg("填写工时成功啦！", "my_list.aspx", "Success");
                }
                else
                {
                    Response.Redirect("../job_order/relevant_edit.aspx?action=Edit&id=" + this.job_order_id);
                }
            }
        }

    }
}