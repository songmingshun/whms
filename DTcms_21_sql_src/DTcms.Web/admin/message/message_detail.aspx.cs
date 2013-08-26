using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.message
{
    public partial class message_detail : Web.UI.ManagePage
    {
        private int id = 0;
        private string action = string.Empty;
        private string is_read = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            string _is_read = DTRequest.GetQueryString("is_read");

            if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!new BLL.user_message().Exists(this.id))
            {
                JscriptMsg("信息不存在或已被删除！", "back", "Error");
                return;
            }

            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.View.ToString() && _is_read=="0")
            {
                //设为已阅读状态
                this.action = _action;
                new BLL.user_message().UpdateField(this.id, "is_read=1,read_time='" + DateTime.Now + "'");
            }

            //页面展示
            ShowInfo(this.id);
        }
        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.user_message bll = new BLL.user_message();
            Model.user_message model = bll.GetModel(_id);

            txtTitle.Text = model.title;
            txtContent.InnerText = model.content;

        }
        #endregion

        //构造后退按钮触发事件-查看未读邮件，需要页面刷新
        public string CreateBackButtonAction()
        {
            if (action == DTEnums.ActionEnum.View.ToString())
            {
                return "message_list.aspx";
            }
            else
            {
                return "javascript:history.go(-1);";
            }
        }

    }
}