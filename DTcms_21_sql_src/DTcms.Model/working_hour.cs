using System;
using System.Collections.Generic;
namespace DTcms.Model
{
    /// <summary>
    /// 工时信息
    /// </summary>
    [Serializable]
    public partial class working_hour
    {
        public working_hour()
        { }
        #region Model
        private int         _id;
        private string      _user_name;
        private DateTime    _date;
        private int         _job_order_id;
        private byte        _product_type;
        private byte        _service_type;
        private string      _working_content;
        private decimal     _working_hours;
        private decimal     _journey_hours;
        private decimal     _overtime_hours;
        private byte        _status;
        private DateTime    _create_time;

        /// <summary>
        /// 工时ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 工单日期
        /// </summary>
        public DateTime date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 工单ID
        /// </summary>
        public int job_order_id
        {
            set { _job_order_id = value; }
            get { return _job_order_id; }
        }
        /// <summary>
        /// 产品类型ID
        /// </summary>
        public byte product_type
        {
            set { _product_type = value; }
            get { return _product_type; }
        }
        /// <summary>
        /// 服务类型ID
        /// </summary>
        public byte service_type
        {
            set { _service_type = value; }
            get { return _service_type; }
        }
        /// <summary>
        /// 工作内容
        /// </summary>
        public string working_content
        {
            set { _working_content = value; }
            get { return _working_content; }
        }
        /// <summary>
        /// 工作时长
        /// </summary>
        public decimal working_hours
        {
            set { _working_hours = value; }
            get { return _working_hours; }
        }
        /// <summary>
        /// 在途时长
        /// </summary>
        public decimal journey_hours
        {
            set { _journey_hours = value; }
            get { return _journey_hours; }
        }
        /// <summary>
        /// 加班时长
        /// </summary>
        public decimal overtime_hours
        {
            set { _overtime_hours = value; }
            get { return _overtime_hours; }
        }
        /// <summary>
        /// 完成状态
        /// </summary>
        public byte status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        #endregion Model

        private List<download_attach> _download_attachs;
        /// <summary>
        /// 附件子类
        /// </summary>
        public List<download_attach> download_attachs
        {
            set { _download_attachs = value; }
            get { return _download_attachs; }
        }

    }
}