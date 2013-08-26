using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;
using System.Collections.Generic;

namespace DTcms.DAL
{
    /// <summary>
    /// 用户短信息
    /// </summary>
    public partial class user_message
    {
        public user_message()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from gm_dt_sysuser_message");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回记录总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from gm_dt_sysuser_message ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.user_message model)
        {
            //收件箱
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into gm_dt_sysuser_message(");
            strSql.Append("type,post_user_name,accept_user_name,is_read,title,content,post_time,read_time)");
            strSql.Append(" values (");
            strSql.Append("@type,@post_user_name,@accept_user_name,@is_read,@title,@content,@post_time,@read_time)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@type", SqlDbType.TinyInt,1),
					new SqlParameter("@post_user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@accept_user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@is_read", SqlDbType.TinyInt,1),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@post_time", SqlDbType.DateTime),
					new SqlParameter("@read_time", SqlDbType.DateTime),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)};
            parameters[0].Value = 2;
            parameters[1].Value = model.post_user_name;
            parameters[2].Value = model.accept_user_name;
            parameters[3].Value = model.is_read;
            parameters[4].Value = model.title;
            parameters[5].Value = model.content;
            parameters[6].Value = model.post_time;
            parameters[7].Value = model.read_time;
            parameters[8].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //发件箱
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("insert into gm_dt_sysuser_message(");
            strSql2.Append("type,post_user_name,accept_user_name,title,content,post_time)");
            strSql2.Append(" values (");
            strSql2.Append("@type,@post_user_name,@accept_user_name,@title,@content,@post_time)");
            strSql2.Append(";select @@IDENTITY");
            SqlParameter[] parameters2 = {
					new SqlParameter("@type", SqlDbType.TinyInt,1),
					new SqlParameter("@post_user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@accept_user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@post_time", SqlDbType.DateTime)};
            parameters2[0].Value = 3;
            parameters2[1].Value = model.post_user_name;
            parameters2[2].Value = model.accept_user_name;
            parameters2[3].Value = model.title;
            parameters2[4].Value = model.content;
            parameters2[5].Value = model.post_time;

            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[8].Value;

        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update gm_dt_sysuser_message set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.user_message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update gm_dt_sysuser_message set ");
            strSql.Append("type=@type,");
            strSql.Append("post_user_name=@post_user_name,");
            strSql.Append("accept_user_name=@accept_user_name,");
            strSql.Append("is_read=@is_read,");
            strSql.Append("title=@title,");
            strSql.Append("content=@content,");
            strSql.Append("post_time=@post_time,");
            strSql.Append("read_time=@read_time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@type", SqlDbType.TinyInt,1),
					new SqlParameter("@post_user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@accept_user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@is_read", SqlDbType.TinyInt,1),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@post_time", SqlDbType.DateTime),
					new SqlParameter("@read_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.type;
            parameters[1].Value = model.post_user_name;
            parameters[2].Value = model.accept_user_name;
            parameters[3].Value = model.is_read;
            parameters[4].Value = model.title;
            parameters[5].Value = model.content;
            parameters[6].Value = model.post_time;
            parameters[7].Value = model.read_time;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from gm_dt_sysuser_message ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

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
        public bool Delete(int id, string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from gm_dt_sysuser_message ");
            strSql.Append(" where id=@id and (post_user_name=@post_user_name or accept_user_name=@accept_user_name)");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@post_user_name", SqlDbType.NVarChar,100),
                    new SqlParameter("@accept_user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = id;
            parameters[1].Value = user_name;
            parameters[2].Value = user_name;

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
        /// 得到一个对象实体
        /// </summary>
        public Model.user_message GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,type,post_user_name,accept_user_name,is_read,title,content,post_time,read_time from gm_dt_sysuser_message ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DTcms.Model.user_message model = new DTcms.Model.user_message();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["type"] != null && ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["post_user_name"] != null && ds.Tables[0].Rows[0]["post_user_name"].ToString() != "")
                {
                    model.post_user_name = ds.Tables[0].Rows[0]["post_user_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["accept_user_name"] != null && ds.Tables[0].Rows[0]["accept_user_name"].ToString() != "")
                {
                    model.accept_user_name = ds.Tables[0].Rows[0]["accept_user_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["is_read"] != null && ds.Tables[0].Rows[0]["is_read"].ToString() != "")
                {
                    model.is_read = int.Parse(ds.Tables[0].Rows[0]["is_read"].ToString());
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["content"] != null && ds.Tables[0].Rows[0]["content"].ToString() != "")
                {
                    model.content = ds.Tables[0].Rows[0]["content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["post_time"] != null && ds.Tables[0].Rows[0]["post_time"].ToString() != "")
                {
                    model.post_time = DateTime.Parse(ds.Tables[0].Rows[0]["post_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["read_time"] != null && ds.Tables[0].Rows[0]["read_time"].ToString() != "")
                {
                    model.read_time = DateTime.Parse(ds.Tables[0].Rows[0]["read_time"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
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
            strSql.Append(" id,type,post_user_name,accept_user_name,is_read,title,content,post_time,read_time ");
            strSql.Append(" FROM gm_dt_sysuser_message ");
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
            strSql.Append("select * FROM gm_dt_sysuser_message");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 获取收件箱未读站内信条数
        /// </summary>
        public int GetUnreadCount(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) count from gm_dt_sysuser_message ");
            strSql.Append("where type=2 and is_read=0 and accept_user_name='" + user_name + "' ");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
        }

        /// <summary>
        /// 获取收件箱未读站内信列表
        /// </summary>
        public DataSet GetUnreadListForDesktop(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 10 * from gm_dt_sysuser_message ");
            strSql.Append("where type=2 and is_read=0 and accept_user_name='" + user_name + "' ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}