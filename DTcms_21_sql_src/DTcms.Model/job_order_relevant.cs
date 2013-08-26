using System;
namespace DTcms.Model
{
    /// <summary>
    /// 工单干系人
    /// </summary>
    [Serializable]
    public partial class job_order_relevant
    {
        public job_order_relevant()
        { }
        #region Model
        private int         _id;
        private int         _job_order_id;
        private string      _relevant_id;    //工单干系人，多人格式为“user1;user2;user3”

        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
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
        /// 工单干系人账号
        /// </summary>
        public string relevant_id
        {
            set { _relevant_id = value; }
            get { return _relevant_id; }
        }
        #endregion Model

    }
}