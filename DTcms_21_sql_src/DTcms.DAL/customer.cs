using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:客户
    /// </summary>
    public partial class customer
    {
        public customer()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from gm_dt_customer_base");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public bool Exists(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from gm_dt_sysuser");
            strSql.Append(" where user_name=@user_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into gm_dt_customer_base(");
            strSql.Append("name,scale,trade_id,address,vip_level_id,contact_person,contact_dept,contact_telphone,creator)");
            strSql.Append(" values (");
            strSql.Append("@name,@scale,@trade_id,@address,@vip_level_id,@contact_person,@contact_dept,@contact_telphone,@creator)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@scale", SqlDbType.Int,4),
					new SqlParameter("@trade_id", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@vip_level_id", SqlDbType.Int,4),
					new SqlParameter("@contact_person", SqlDbType.NVarChar,100),
					new SqlParameter("@contact_dept", SqlDbType.NVarChar,100),
                    new SqlParameter("@contact_telphone", SqlDbType.NVarChar,100),
                    new SqlParameter("@creator", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.scale;
            parameters[2].Value = model.trade_id;
            parameters[3].Value = model.address;
            parameters[4].Value = model.vip_level_id;
            parameters[5].Value = model.contact_person;
            parameters[6].Value = model.contact_dept;
            parameters[7].Value = model.contact_telphone;
            parameters[8].Value = model.creator;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update gm_dt_customer_base set ");
            strSql.Append("name=@name,");
            strSql.Append("scale=@scale,");
            strSql.Append("trade_id=@trade_id,");
            strSql.Append("address=@address,");
            strSql.Append("vip_level_id=@vip_level_id,");
            strSql.Append("contact_person=@contact_person,");
            strSql.Append("contact_dept=@contact_dept,");
            strSql.Append("contact_telphone=@contact_telphone");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@scale", SqlDbType.Int,4),
					new SqlParameter("@trade_id", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@vip_level_id", SqlDbType.Int,4),
					new SqlParameter("@contact_person", SqlDbType.NVarChar,100),
					new SqlParameter("@contact_dept", SqlDbType.NVarChar,100),
                    new SqlParameter("@contact_telphone", SqlDbType.NVarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.scale;
            parameters[2].Value = model.trade_id;
            parameters[3].Value = model.address;
            parameters[4].Value = model.vip_level_id;
            parameters[5].Value = model.contact_person;
            parameters[6].Value = model.contact_dept;
            parameters[7].Value = model.contact_telphone;
            parameters[8].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from gm_dt_customer_base ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.customer GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,name,scale,trade_id,vip_level_id,contact_person,contact_dept,address,contact_telphone from dbo.gm_dt_customer_base ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DTcms.Model.customer model = new DTcms.Model.customer();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["name"] != null && ds.Tables[0].Rows[0]["name"].ToString() != "")
                {
                    model.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["scale"] != null && ds.Tables[0].Rows[0]["scale"].ToString() != "")
                {
                    model.scale = int.Parse(ds.Tables[0].Rows[0]["scale"].ToString());
                }
                if (ds.Tables[0].Rows[0]["trade_id"] != null && ds.Tables[0].Rows[0]["trade_id"].ToString() != "")
                {
                    model.trade_id = int.Parse(ds.Tables[0].Rows[0]["trade_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["address"] != null && ds.Tables[0].Rows[0]["address"].ToString() != "")
                {
                    model.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["vip_level_id"] != null && ds.Tables[0].Rows[0]["vip_level_id"].ToString() != "")
                {
                    model.vip_level_id = int.Parse(ds.Tables[0].Rows[0]["vip_level_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["contact_person"] != null && ds.Tables[0].Rows[0]["contact_person"].ToString() != "")
                {
                    model.contact_person = ds.Tables[0].Rows[0]["contact_person"].ToString();
                }
                if (ds.Tables[0].Rows[0]["contact_dept"] != null && ds.Tables[0].Rows[0]["contact_dept"].ToString() != "")
                {
                    model.contact_dept = ds.Tables[0].Rows[0]["contact_dept"].ToString();
                }
                if (ds.Tables[0].Rows[0]["contact_telphone"] != null && ds.Tables[0].Rows[0]["contact_telphone"].ToString() != "")
                {
                    model.contact_telphone = ds.Tables[0].Rows[0]["contact_telphone"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,role_id,role_type,user_name,user_pwd,real_name,telephone,email,is_lock,add_time ");
            strSql.Append(" FROM gm_dt_sysuser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by add_time desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,role_id,role_type,user_name,user_pwd,real_name,telephone,email,is_lock,add_time ");
            strSql.Append(" FROM gm_dt_sysuser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.id,a.name,a.address,a.contact_person,a.contact_dept,a.contact_telphone,b.level_name,c.trade_name,d.name scale ");
            strSql.Append("from gm_dt_customer_base a ");
            strSql.Append("left join dbo.gm_dt_customer_level b on a.vip_level_id=b.id ");
            strSql.Append("left join dbo.gm_dt_customer_trade c on a.trade_id=c.id ");
            strSql.Append("left join dbo.gm_dt_customer_scale d on a.scale=d.id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 获得客户级别数据列表
        /// </summary>
        public DataSet GetLevelList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from dbo.gm_dt_customer_level ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得客户规模数据列表
        /// </summary>
        public DataSet GetScaleList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from dbo.gm_dt_customer_scale ");
            
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得客户行业数据列表
        /// </summary>
        public DataSet GetTradeList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from dbo.gm_dt_customer_trade ");
            
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得客户行业数据列表
        /// </summary>
        public string GetName(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 name from gm_dt_customer_base");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.NVarChar,100)};
            parameters[0].Value = id;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return id.ToString();
            }
            else
            {
                return obj.ToString();
            }
        }

        #endregion  Method
    }
}