using System;
using System.Collections.Generic;
namespace DTcms.Model
{
    /// <summary>
    /// ��ʱ��Ϣ
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
        /// ��ʱID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// �û��˺�
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// ����ID
        /// </summary>
        public int job_order_id
        {
            set { _job_order_id = value; }
            get { return _job_order_id; }
        }
        /// <summary>
        /// ��Ʒ����ID
        /// </summary>
        public byte product_type
        {
            set { _product_type = value; }
            get { return _product_type; }
        }
        /// <summary>
        /// ��������ID
        /// </summary>
        public byte service_type
        {
            set { _service_type = value; }
            get { return _service_type; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string working_content
        {
            set { _working_content = value; }
            get { return _working_content; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public decimal working_hours
        {
            set { _working_hours = value; }
            get { return _working_hours; }
        }
        /// <summary>
        /// ��;ʱ��
        /// </summary>
        public decimal journey_hours
        {
            set { _journey_hours = value; }
            get { return _journey_hours; }
        }
        /// <summary>
        /// �Ӱ�ʱ��
        /// </summary>
        public decimal overtime_hours
        {
            set { _overtime_hours = value; }
            get { return _overtime_hours; }
        }
        /// <summary>
        /// ���״̬
        /// </summary>
        public byte status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime create_time
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        #endregion Model

        private List<download_attach> _download_attachs;
        /// <summary>
        /// ��������
        /// </summary>
        public List<download_attach> download_attachs
        {
            set { _download_attachs = value; }
            get { return _download_attachs; }
        }

    }
}