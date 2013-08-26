using System;
namespace DTcms.Model
{
    /// <summary>
    /// ������ϵ��
    /// </summary>
    [Serializable]
    public partial class job_order_relevant
    {
        public job_order_relevant()
        { }
        #region Model
        private int         _id;
        private int         _job_order_id;
        private string      _relevant_id;    //������ϵ�ˣ����˸�ʽΪ��user1;user2;user3��

        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
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
        /// ������ϵ���˺�
        /// </summary>
        public string relevant_id
        {
            set { _relevant_id = value; }
            get { return _relevant_id; }
        }
        #endregion Model

    }
}