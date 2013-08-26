using System;
namespace DTcms.Model
{
    /// <summary>
    /// 部门信息
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
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 部门名
        /// </summary>
        public string dept_name
        {
            set { _dept_name = value; }
            get { return _dept_name; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model

    }
}