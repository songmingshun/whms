using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
    /// <summary>
    /// ��ʱ
    /// </summary>
    public partial class working_hour
    {
        private readonly DAL.working_hour dal = new DAL.working_hour();
        public working_hour()
        { }
        #region  Method
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

         /// <summary>
        /// ����û����Ƿ����
        /// </summary>
        public bool Exists(string user_name)
        {
            return dal.Exists(user_name);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.working_hour model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.working_hour model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DTcms.Model.working_hour GetModel(int id)
        {
            return dal.GetModel(id);
        }

        ///// <summary>
        ///// �����û������뷵��һ��ʵ��
        ///// </summary>
        //public Model.working_hour GetModel(string user_name, string user_pwd)
        //{
        //    return dal.GetModel(user_name, user_pwd);
        //}

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ��ò��Ź�ʱ�б�
        /// </summary>
        public DataSet GetDeptWorkingHourList(string strWhere)
        {
            return dal.GetDeptWorkingHourList(strWhere);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        ///// <summary>
        ///// ��ù�����������
        ///// </summary>
        //public DataSet GetList()
        //{
        //    return dal.GetList();
        //}

        /// <summary>
        /// ��ò�Ʒ/��������
        /// </summary>
        public DataSet GetTypeList(string table)
        {
            return dal.GetTypeList(table);
        }

        /// <summary>
        /// ��ù�������
        /// </summary>
        public string GetJobOrderName(int id)
        {
            return dal.GetJobOrderName(id);
        }

        /// <summary>
        /// ��ò�Ʒ��������
        /// </summary>
        public string GetProductTypeName(int id)
        {
            return dal.GetProductTypeName(id);
        }

        /// <summary>
        /// ��÷�����������
        /// </summary>
        public string GetServiceTypeName(int id)
        {
            return dal.GetServiceTypeName(id);
        }

        /// <summary>
        /// ��ø��˹�ʱ����
        /// </summary>
        public DataSet GetTimeSum(string strWhere)
        {
            return dal.GetTimeSum(strWhere);
        }

        /// <summary>
        /// ��ò��Ź�ʱ����
        /// </summary>
        public DataSet GetDeptTimeSum(string strWhere)
        {
            return dal.GetDeptTimeSum(strWhere);
        }

        /// <summary>
        /// ���ָ��������ʱ�б�
        /// </summary>
        public DataSet GetJobOrderWorkingHourList(int jobOrderId)
        {
            return dal.GetJobOrderWorkingHourList(jobOrderId);
        }

        #endregion  Method
    }
}