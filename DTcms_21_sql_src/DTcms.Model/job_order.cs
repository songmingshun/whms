using System;
using System.Collections.Generic;
namespace DTcms.Model
{
    /// <summary>
    /// ������Ϣ
    /// </summary>
    [Serializable]
    public partial class job_order
    {
        public job_order()
        { }
        #region Model
        private int         _job_order_id;
        private string      _job_order_name;
        private int         _job_order_type;
        private string      _job_order_discripe;
        private string      _contract_id;
        private string      _salesman_id;
        private DateTime    _job_order_begintime;
        private DateTime    _job_order_endtime;
        private string      _technical_respon_id;
        private string      _job_order_reviewer_id;
        private DateTime    _job_order_create_time;
        private string      _job_order_status;
        private string      _job_order_advice;
        private string      _job_order_creator_id;
        private int         _customer_id;

        //private DateTime _add_time = DateTime.Now;

        /// <summary>
        /// ����ID
        /// </summary>
        public int job_order_id
        {
            set { _job_order_id = value; }
            get { return _job_order_id; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string job_order_name
        {
            set { _job_order_name = value; }
            get { return _job_order_name; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int job_order_type
        {
            set { _job_order_type = value; }
            get { return _job_order_type; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string job_order_discripe
        {
            set { _job_order_discripe = value; }
            get { return _job_order_discripe; }
        }
        /// <summary>
        /// ��ͬID
        /// </summary>
        public string contract_id
        {
            set { _contract_id = value; }
            get { return _contract_id; }
        }
        /// <summary>
        /// ������ԱID
        /// </summary>
        public string salesman_id
        {
            set { _salesman_id = value; }
            get { return _salesman_id; }
        }
        /// <summary>
        /// ������ʼʱ��
        /// </summary>
        public DateTime job_order_begintime
        {
            set { _job_order_begintime = value; }
            get { return _job_order_begintime; }
        }
        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime job_order_endtime
        {
            set { _job_order_endtime = value; }
            get { return _job_order_endtime; }
        }
        /// <summary>
        /// ����������ID
        /// </summary>
        public string technical_respon_id
        {
            set { _technical_respon_id = value; }
            get { return _technical_respon_id; }
        }
        /// <summary>
        /// �����ID
        /// </summary>
        public string job_order_reviewer_id
        {
            set { _job_order_reviewer_id = value; }
            get { return _job_order_reviewer_id; }
        }
        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime job_order_create_time
        {
            set { _job_order_create_time = value; }
            get { return _job_order_create_time; }
        }
        /// <summary>
        /// ����״̬
        /// </summary>
        public string job_order_status
        {
            set { _job_order_status = value; }
            get { return _job_order_status; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string job_order_advice
        {
            set { _job_order_advice = value; }
            get { return _job_order_advice; }
        }
        /// <summary>
        /// ������ID
        /// </summary>
        public string job_order_creator_id
        {
            set { _job_order_creator_id = value; }
            get { return _job_order_creator_id; }
        }

        private List<job_order_relevant> _job_order_relevant;
        /// <summary>
        /// ������ϵ��
        /// </summary>
        public List<job_order_relevant> job_order_relevant
        {
            set { _job_order_relevant = value; }
            get { return _job_order_relevant; }
        }

        /// <summary>
        /// �ͻ�ID
        /// </summary>
        public int customer_id
        {
            set { _customer_id = value; }
            get { return _customer_id; }
        }
        #endregion Model

    }
}