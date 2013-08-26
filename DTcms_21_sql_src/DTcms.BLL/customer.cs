using System;
using System.Data;
using System.Collections.Generic;

namespace DTcms.BLL
{
    /// <summary>
    /// �ͻ�
    /// </summary>
    public partial class customer
    {
        private readonly DAL.customer dal = new DAL.customer();
        public customer()
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
        public int Add(Model.customer model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.customer model)
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
        public DTcms.Model.customer GetModel(int id)
        {
            return dal.GetModel(id);
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
        /// ��ÿͻ����������б�
        /// </summary>
        public DataSet GetLevelList()
        {
            return dal.GetLevelList();
        }

        /// <summary>
        /// ��ÿͻ���ģ�����б�
        /// </summary>
        public DataSet GetScaleList()
        {
            return dal.GetScaleList();
        }

        /// <summary>
        /// ��ÿͻ���ҵ�����б�
        /// </summary>
        public DataSet GetTradeList()
        {
            return dal.GetTradeList();
        }

        /// <summary>
        /// ��ÿͻ�����
        /// </summary>
        public string GetName(int id)
        {
            return dal.GetName(id);
        }
        
        #endregion  Method
    }
}