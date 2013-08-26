using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
    /// <summary>
    /// ����
    /// </summary>
    public partial class job_order
    {
        private readonly DAL.job_order dal = new DAL.job_order();
        public job_order()
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
        public int Add(Model.job_order model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.job_order model)
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
        public DTcms.Model.job_order GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// �����û������뷵��һ��ʵ��
        /// </summary>
        public Model.job_order GetModel(string user_name, string user_pwd)
        {
            return dal.GetModel(user_name, user_pwd);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
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

        /// <summary>
        /// ��ù�����������
        /// </summary>
        public DataSet GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ���һ������
        /// </summary>
        public bool Review(Model.job_order model)
        {
            return dal.Review(model);
        }

        /// <summary>
        /// ��ȡ�������������
        /// </summary>
        public int GetUnreviewCount(string user_name)
        {
            return dal.GetUnreviewCount(user_name);
        }

        /// <summary>
        /// ��ò��Ź�ʱ��ѯ�����б�����
        /// </summary>
        public DataSet GetWorkingHourJobOrderList(int dept_id)
        {
            return dal.GetWorkingHourJobOrderList(dept_id);
        }

        /// <summary>
        /// ϵͳ��ҳ����˹����б�
        /// </summary>
        public DataSet GetUnreviewListForDesktop(string user_name)
        {
            return dal.GetUnreviewListForDesktop(user_name);
        }

        /// <summary>
        /// ϵͳ��ҳ���������б�
        /// </summary>
        public DataSet GetRelevantListForDesktop(string user_name)
        {
            return dal.GetRelevantListForDesktop(user_name);
        }

        /// <summary>
        /// ϵͳ��ҳ���ż������б�
        /// </summary>
        public DataSet GetDeptListForDesktop(int dept_id)
        {
            return dal.GetDeptListForDesktop(dept_id);
        }

        #endregion  Method
    }
}