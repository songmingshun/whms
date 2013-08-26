using System;
namespace DTcms.Model
{
    /// <summary>
    /// 客户信息
    /// </summary>
    [Serializable]
    public partial class customer
    {
        public customer()
        { }
        #region Model
        private int _id;
        private string _name;
        private int _scale;
        private int _trade_id;
        private string _address;
        private int _vip_level_id;
        private string _contact_person;
        private string _contact_dept;
        private string _contact_telphone;
        private string _creator;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 客户名
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 规模
        /// </summary>
        public int scale
        {
            set { _scale = value; }
            get { return _scale; }
        }
        /// <summary>
        /// 行业
        /// </summary>
        public int trade_id
        {
            set { _trade_id = value; }
            get { return _trade_id; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 级别
        /// </summary>
        public int vip_level_id
        {
            set { _vip_level_id = value; }
            get { return _vip_level_id; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string contact_person
        {
            set { _contact_person = value; }
            get { return _contact_person; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string contact_dept
        {
            set { _contact_dept = value; }
            get { return _contact_dept; }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string contact_telphone
        {
            set { _contact_telphone = value; }
            get { return _contact_telphone; }
        }

        /// <summary>
        /// 创建者
        /// </summary>
        public string creator
        {
            set { _creator = value; }
            get { return _creator; }
        }

        #endregion Model

    }
}