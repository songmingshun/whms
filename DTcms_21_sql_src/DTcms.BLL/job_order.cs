using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
    /// <summary>
    /// 工单
    /// </summary>
    public partial class job_order
    {
        private readonly DAL.job_order dal = new DAL.job_order();
        public job_order()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

         /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public bool Exists(string user_name)
        {
            return dal.Exists(user_name);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.job_order model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.job_order model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.job_order GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.job_order GetModel(string user_name, string user_pwd)
        {
            return dal.GetModel(user_name, user_pwd);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// 获得工单服务类型
        /// </summary>
        public DataSet GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 审核一条数据
        /// </summary>
        public bool Review(Model.job_order model)
        {
            return dal.Review(model);
        }

        /// <summary>
        /// 获取待审核数据条数
        /// </summary>
        public int GetUnreviewCount(string user_name)
        {
            return dal.GetUnreviewCount(user_name);
        }

        /// <summary>
        /// 获得部门工时查询工单列表数据
        /// </summary>
        public DataSet GetWorkingHourJobOrderList(int dept_id)
        {
            return dal.GetWorkingHourJobOrderList(dept_id);
        }

        /// <summary>
        /// 系统首页待审核工单列表
        /// </summary>
        public DataSet GetUnreviewListForDesktop(string user_name)
        {
            return dal.GetUnreviewListForDesktop(user_name);
        }

        /// <summary>
        /// 系统首页待处理工单列表
        /// </summary>
        public DataSet GetRelevantListForDesktop(string user_name)
        {
            return dal.GetRelevantListForDesktop(user_name);
        }

        /// <summary>
        /// 系统首页部门级工单列表
        /// </summary>
        public DataSet GetDeptListForDesktop(int dept_id)
        {
            return dal.GetDeptListForDesktop(dept_id);
        }

        #endregion  Method
    }
}