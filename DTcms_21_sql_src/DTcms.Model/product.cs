using System;
namespace DTcms.Model
{
    /// <summary>
    /// ��Ʒ��Ϣ
    /// </summary>
    [Serializable]
    public partial class product
    {
        public product()
        { }
        #region Model
        private int _id;
        private string _name;
        private DateTime _add_time = DateTime.Now;
        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model

    }
}