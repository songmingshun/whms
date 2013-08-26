using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
    /// <summary>
    /// 工时
    /// </summary>
    public partial class working_hour
    {
        private readonly DAL.working_hour dal = new DAL.working_hour();
        public working_hour()
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
        public int Add(Model.working_hour model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.working_hour model)
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
        public DTcms.Model.working_hour GetModel(int id)
        {
            return dal.GetModel(id);
        }

        ///// <summary>
        ///// 根据用户名密码返回一个实体
        ///// </summary>
        //public Model.working_hour GetModel(string user_name, string user_pwd)
        //{
        //    return dal.GetModel(user_name, user_pwd);
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得部门工时列表
        /// </summary>
        public DataSet GetDeptWorkingHourList(string strWhere)
        {
            return dal.GetDeptWorkingHourList(strWhere);
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

        ///// <summary>
        ///// 获得工单服务类型
        ///// </summary>
        //public DataSet GetList()
        //{
        //    return dal.GetList();
        //}

        /// <summary>
        /// 获得产品/服务类型
        /// </summary>
        public DataSet GetTypeList(string table)
        {
            return dal.GetTypeList(table);
        }

        /// <summary>
        /// 获得工单名称
        /// </summary>
        public string GetJobOrderName(int id)
        {
            return dal.GetJobOrderName(id);
        }

        /// <summary>
        /// 获得产品类型名称
        /// </summary>
        public string GetProductTypeName(int id)
        {
            return dal.GetProductTypeName(id);
        }

        /// <summary>
        /// 获得服务类型名称
        /// </summary>
        public string GetServiceTypeName(int id)
        {
            return dal.GetServiceTypeName(id);
        }

        /// <summary>
        /// 获得个人工时汇总
        /// </summary>
        public DataSet GetTimeSum(string strWhere)
        {
            return dal.GetTimeSum(strWhere);
        }

        /// <summary>
        /// 获得部门工时汇总
        /// </summary>
        public DataSet GetDeptTimeSum(string strWhere)
        {
            return dal.GetDeptTimeSum(strWhere);
        }

        /// <summary>
        /// 获得指定工单工时列表
        /// </summary>
        public DataSet GetJobOrderWorkingHourList(int jobOrderId)
        {
            return dal.GetJobOrderWorkingHourList(jobOrderId);
        }

        #endregion  Method
    }
}