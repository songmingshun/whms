using System;
namespace DTcms.Model
{
    /// <summary>
    /// 服务信息
    /// </summary>
    [Serializable]
    public partial class service
    {
        public service()
        { }
        #region Model
        private int _id;
        private string _name;
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
        /// 服务名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
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