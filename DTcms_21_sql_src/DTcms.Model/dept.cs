using System;
namespace DTcms.Model
{
    /// <summary>
    /// ������Ϣ
    /// </summary>
    [Serializable]
    public partial class dept
    {
        public dept()
        { }
        #region Model
        private int _id;
        private string _dept_name;
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
        /// ������
        /// </summary>
        public string dept_name
        {
            set { _dept_name = value; }
            get { return _dept_name; }
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