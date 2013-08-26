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
    /// 数据访问类:工单
    /// </summary>
    public partial class job_order
    {
        public job_order()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from gm_dt_job_order_base");
            strSql.Append(" where job_order_id=@id ");
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
            strSql.Append("select count(1) from dt_manager");
            strSql.Append(" where user_name=@user_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.job_order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into gm_dt_job_order_base(");
            strSql.Append("job_order_name,job_order_type,job_order_discripe,contract_id,salesman_id,job_order_begintime,job_order_endtime,technical_respon_id,job_order_reviewer_id,job_order_create_time,job_order_status,job_order_advice,job_order_creator_id,customer_id)");
            strSql.Append(" values (");
            strSql.Append("@job_order_name,@job_order_type,@job_order_discripe,@contract_id,@salesman_id,@job_order_begintime,@job_order_endtime,@technical_respon_id,@job_order_reviewer_id,@job_order_create_time,@job_order_status,@job_order_advice,@job_order_creator_id,@customer_id)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
					//new SqlParameter("@job_order_id", SqlDbType.Int,4),
					new SqlParameter("@job_order_name", SqlDbType.NVarChar,50),
					new SqlParameter("@job_order_type", SqlDbType.Int,4),
					new SqlParameter("@job_order_discripe", SqlDbType.NVarChar,50),
					new SqlParameter("@contract_id", SqlDbType.NVarChar,50),
					new SqlParameter("@salesman_id", SqlDbType.NVarChar,50),
					new SqlParameter("@job_order_begintime", SqlDbType.DateTime),
					new SqlParameter("@job_order_endtime", SqlDbType.DateTime),
                    new SqlParameter("@technical_respon_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@job_order_reviewer_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@job_order_create_time", SqlDbType.DateTime),
                    new SqlParameter("@job_order_status", SqlDbType.NVarChar,50),
                    new SqlParameter("@job_order_advice", SqlDbType.NVarChar,100),
                    new SqlParameter("@job_order_creator_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@customer_id", SqlDbType.Int,4),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)};
            //parameters[0].Value = model.job_order_id;
            parameters[0].Value = model.job_order_name;
            parameters[1].Value = model.job_order_type;
            parameters[2].Value = model.job_order_discripe;
            parameters[3].Value = model.contract_id;
            parameters[4].Value = model.salesman_id;
            parameters[5].Value = model.job_order_begintime;
            parameters[6].Value = model.job_order_endtime;
            parameters[7].Value = model.technical_respon_id;
            parameters[8].Value = model.job_order_reviewer_id;
            parameters[9].Value = model.job_order_create_time;
            parameters[10].Value = model.job_order_status;
            parameters[11].Value = model.job_order_advice;
            parameters[12].Value = model.job_order_creator_id;
            parameters[13].Value = model.customer_id;
            parameters[14].Direction = ParameterDirection.Output;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //工单干系人
            if (model.job_order_relevant != null)
            {
                StringBuilder strSql2;
                foreach (Model.job_order_relevant models in model.job_order_relevant)
                {
                    strSql2 = new StringBuilder();
                    strSql2.Append("insert into gm_dt_job_order_relevant(");
                    strSql2.Append("job_order_id,relevant_id)");
                    strSql2.Append(" values (");
                    strSql2.Append("@job_order_id,@relevant_id)");
                    SqlParameter[] parameters2 = {
						new SqlParameter("@job_order_id", SqlDbType.Int,4),
						new SqlParameter("@relevant_id", SqlDbType.NVarChar,50)};
                    parameters2[0].Direction = ParameterDirection.InputOutput;
                    parameters2[1].Value = models.relevant_id;

                    cmd = new CommandInfo(strSql2.ToString(), parameters2);
                    sqllist.Add(cmd);
                }
            }
            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[14].Value;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.job_order model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update gm_dt_job_order_base set ");
                        strSql.Append("job_order_type=@job_order_type,");
                        strSql.Append("job_order_discripe=@job_order_discripe,");
                        strSql.Append("contract_id=@contract_id,");
                        strSql.Append("salesman_id=@salesman_id,");
                        strSql.Append("job_order_begintime=@job_order_begintime,");
                        strSql.Append("job_order_endtime=@job_order_endtime,");
                        strSql.Append("technical_respon_id=@technical_respon_id,");
                        strSql.Append("job_order_status=@job_order_status,");
                        strSql.Append("job_order_reviewer_id=@job_order_reviewer_id,");
                        strSql.Append("customer_id=@customer_id,");
                        strSql.Append("job_order_advice=@job_order_advice");
                        strSql.Append(" where job_order_id=@id");
                        SqlParameter[] parameters = {
					        new SqlParameter("@job_order_type", SqlDbType.Int,4),
					        new SqlParameter("@job_order_discripe", SqlDbType.NVarChar,50),
					        new SqlParameter("@contract_id", SqlDbType.NVarChar,50),
					        new SqlParameter("@salesman_id", SqlDbType.NVarChar,50),
					        new SqlParameter("@job_order_begintime", SqlDbType.DateTime),
					        new SqlParameter("@job_order_endtime", SqlDbType.DateTime),
					        new SqlParameter("@technical_respon_id", SqlDbType.NVarChar,50),
					        new SqlParameter("@job_order_status", SqlDbType.NVarChar,50),
					        new SqlParameter("@job_order_reviewer_id", SqlDbType.NVarChar,50),
                            new SqlParameter("@customer_id", SqlDbType.Int,4),
                            new SqlParameter("@job_order_advice", SqlDbType.NVarChar,100),
					        new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters[0].Value = model.job_order_type;
                        parameters[1].Value = model.job_order_discripe;
                        parameters[2].Value = model.contract_id;
                        parameters[3].Value = model.salesman_id;
                        parameters[4].Value = model.job_order_begintime;
                        parameters[5].Value = model.job_order_endtime;
                        parameters[6].Value = model.technical_respon_id;
                        parameters[7].Value = model.job_order_status;
                        parameters[8].Value = model.job_order_reviewer_id;
                        parameters[9].Value = model.customer_id;
                        parameters[10].Value = model.job_order_advice;
                        parameters[11].Value = model.job_order_id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //先删除原工单干系人数据
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("delete from gm_dt_job_order_relevant ");
                        strSql2.Append(" where job_order_id=@id");
                        SqlParameter[] parameters2 = {
					        new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters2[0].Value = model.job_order_id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);

                        //先添加新工单干系人数据
                        if (model.job_order_relevant != null)
                        {
                            StringBuilder strSql3;
                            foreach (Model.job_order_relevant models in model.job_order_relevant)
                            {
                                strSql3 = new StringBuilder();
                                strSql3.Append("insert into gm_dt_job_order_relevant(");
                                strSql3.Append("job_order_id,relevant_id)");
                                strSql3.Append(" values (");
                                strSql3.Append("@job_order_id,@relevant_id)");
                                SqlParameter[] parameters3 = {
					                    new SqlParameter("@job_order_id", SqlDbType.Int,4),
					                    new SqlParameter("@relevant_id", SqlDbType.NVarChar,50)};
                                parameters3[0].Value = model.job_order_id;
                                parameters3[1].Value = models.relevant_id;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);
                            }
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from gm_dt_job_order_relevant ");
            strSql.Append(" where job_order_id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from gm_dt_job_order_base ");
            strSql1.Append(" where job_order_id=@id");
            SqlParameter[] parameters1 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters1[0].Value = id;
            cmd = new CommandInfo(strSql1.ToString(), parameters1);
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
        public Model.job_order GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 job_order_id,job_order_name,job_order_type,job_order_discripe,contract_id,salesman_id,job_order_begintime,job_order_endtime,technical_respon_id,job_order_reviewer_id,job_order_create_time,job_order_status,job_order_advice,job_order_creator_id,customer_id from gm_dt_job_order_base ");
            strSql.Append(" where job_order_id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DTcms.Model.job_order model = new DTcms.Model.job_order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region  父表信息
                if (ds.Tables[0].Rows[0]["job_order_id"] != null && ds.Tables[0].Rows[0]["job_order_id"].ToString() != "")
                {
                    model.job_order_id = int.Parse(ds.Tables[0].Rows[0]["job_order_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["job_order_name"] != null && ds.Tables[0].Rows[0]["job_order_name"].ToString() != "")
                {
                    model.job_order_name = ds.Tables[0].Rows[0]["job_order_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["job_order_type"] != null && ds.Tables[0].Rows[0]["job_order_type"].ToString() != "")
                {
                    model.job_order_type = int.Parse(ds.Tables[0].Rows[0]["job_order_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["job_order_discripe"] != null && ds.Tables[0].Rows[0]["job_order_discripe"].ToString() != "")
                {
                    model.job_order_discripe = ds.Tables[0].Rows[0]["job_order_discripe"].ToString();
                }
                if (ds.Tables[0].Rows[0]["contract_id"] != null && ds.Tables[0].Rows[0]["contract_id"].ToString() != "")
                {
                    model.contract_id = ds.Tables[0].Rows[0]["contract_id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["salesman_id"] != null && ds.Tables[0].Rows[0]["salesman_id"].ToString() != "")
                {
                    model.salesman_id = ds.Tables[0].Rows[0]["salesman_id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["job_order_begintime"] != null && ds.Tables[0].Rows[0]["job_order_begintime"].ToString() != "")
                {
                    model.job_order_begintime = DateTime.Parse(ds.Tables[0].Rows[0]["job_order_begintime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["job_order_endtime"] != null && ds.Tables[0].Rows[0]["job_order_endtime"].ToString() != "")
                {
                    model.job_order_endtime = DateTime.Parse(ds.Tables[0].Rows[0]["job_order_endtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["technical_respon_id"] != null && ds.Tables[0].Rows[0]["technical_respon_id"].ToString() != "")
                {
                    model.technical_respon_id = ds.Tables[0].Rows[0]["technical_respon_id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["job_order_reviewer_id"] != null && ds.Tables[0].Rows[0]["job_order_reviewer_id"].ToString() != "")
                {
                    model.job_order_reviewer_id = ds.Tables[0].Rows[0]["job_order_reviewer_id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["job_order_create_time"] != null && ds.Tables[0].Rows[0]["job_order_create_time"].ToString() != "")
                {
                    model.job_order_create_time = DateTime.Parse(ds.Tables[0].Rows[0]["job_order_create_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["job_order_status"] != null && ds.Tables[0].Rows[0]["job_order_status"].ToString() != "")
                {
                    model.job_order_status = ds.Tables[0].Rows[0]["job_order_status"].ToString();
                }
                if (ds.Tables[0].Rows[0]["job_order_advice"] != null && ds.Tables[0].Rows[0]["job_order_advice"].ToString() != "")
                {
                    model.job_order_advice = ds.Tables[0].Rows[0]["job_order_advice"].ToString();
                }
                if (ds.Tables[0].Rows[0]["job_order_creator_id"] != null && ds.Tables[0].Rows[0]["job_order_creator_id"].ToString() != "")
                {
                    model.job_order_creator_id = ds.Tables[0].Rows[0]["job_order_creator_id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["customer_id"] != null && ds.Tables[0].Rows[0]["customer_id"].ToString() != "")
                {
                    model.customer_id = int.Parse(ds.Tables[0].Rows[0]["customer_id"].ToString());
                }
                #endregion  父表信息end

                #region  子表信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,job_order_id,relevant_id from gm_dt_job_order_relevant ");
                strSql2.Append(" where job_order_id=@id ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
                parameters2[0].Value = id;

                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    #region  子表字段信息
                    int i = ds2.Tables[0].Rows.Count;
                    List<Model.job_order_relevant> models = new List<Model.job_order_relevant>();
                    Model.job_order_relevant modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new Model.job_order_relevant();
                        if (ds2.Tables[0].Rows[n]["id"] != null && ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["job_order_id"] != null && ds2.Tables[0].Rows[n]["job_order_id"].ToString() != "")
                        {
                            modelt.job_order_id = int.Parse(ds2.Tables[0].Rows[n]["job_order_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["relevant_id"] != null && ds2.Tables[0].Rows[n]["relevant_id"].ToString() != "")
                        {
                            modelt.relevant_id = ds2.Tables[0].Rows[n]["relevant_id"].ToString();
                        }
                        
                        models.Add(modelt);
                    }
                    model.job_order_relevant = models;
                    #endregion  子表字段信息end
                }
                #endregion  子表信息end


                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.job_order GetModel(string user_name, string user_pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from dt_manager");
            strSql.Append(" where user_name=@user_name and user_pwd=@user_pwd and is_lock=0");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                    new SqlParameter("@user_pwd", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            parameters[1].Value = user_pwd;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,job_order_id,job_order_name,job_order_type,job_order_discripe,contract_id,salesman_id,job_order_begintime,job_order_endtime,technical_respon_id,job_order_reviewer_id,job_order_create_time,job_order_status,job_order_advice,job_order_creator_id ");
            strSql.Append(" FROM gm_dt_job_order_base ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by job_order_create_time desc");
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
            strSql.Append(" id,job_order_id,job_order_name,job_order_type,job_order_discripe,contract_id,salesman_id,job_order_begintime,job_order_endtime,technical_respon_id,job_order_reviewer_id,job_order_create_time,job_order_status,job_order_advice,job_order_creator_id ");
            strSql.Append(" FROM gm_dt_job_order_base ");
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
            //strSql.Append("select * FROM gm_dt_job_order_base");
            strSql.Append("SELECT * FROM gm_dt_job_order_base AS a LEFT OUTER JOIN gm_dt_job_order_service_type AS b ON a.job_order_type = b.service_id");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 获得工单服务类型
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM gm_dt_job_order_service_type");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 审核一条数据
        /// </summary>
        public bool Review(Model.job_order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update gm_dt_job_order_base set ");
            strSql.Append("job_order_status=@job_order_status,");
            strSql.Append("job_order_advice=@job_order_advice");
            strSql.Append(" where job_order_id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@job_order_status", SqlDbType.NVarChar,50),
					new SqlParameter("@job_order_advice", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.job_order_status;
            parameters[1].Value = model.job_order_advice;
            parameters[2].Value = model.job_order_id;

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
        /// 获取待审核数据条数
        /// </summary>
        public int GetUnreviewCount(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) count from gm_dt_job_order_base ");
            strSql.Append("where job_order_status='未审核' and job_order_reviewer_id='" + user_name + "' ");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return int.Parse(ds.Tables[0].Rows[0]["count"].ToString());
        }

        /// <summary>
        /// 获得部门工时查询工单列表数据
        /// </summary>
        public DataSet GetWorkingHourJobOrderList(int dept_id)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT * FROM gm_dt_job_order_base AS a LEFT OUTER JOIN gm_dt_job_order_service_type AS b ON a.job_order_type = b.service_id");

            //strSql.Append(" where ");
            //strSql.Append(" ((job_order_id IN (");
            //strSql.Append(" SELECT job_order_id");
            //strSql.Append(" from gm_dt_job_order_relevant ");
            //strSql.Append(" where relevant_id='" + user_name + "') ");
            //strSql.Append(" OR (salesman_id='" + user_name + "') ");
            //strSql.Append(" OR (job_order_reviewer_id='" + user_name + "') ");
            //strSql.Append(" OR (job_order_creator_id='" + user_name + "') ");
            //strSql.Append(" OR (technical_respon_id='" + user_name + "')) ");
            //strSql.Append(" AND job_order_status='同意' )");

            strSql.Append("select a.job_order_id,a.job_order_name from dbo.gm_dt_job_order_base a ");
            strSql.Append(" left join dbo.gm_dt_sysuser b ");
            strSql.Append(" on a.job_order_creator_id=b.user_name ");
            strSql.Append(" where b.dept_id='" + dept_id + "' and a.job_order_status='同意'");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 系统首页待审核工单列表
        /// </summary>
        public DataSet GetUnreviewListForDesktop(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 10 * from dbo.gm_dt_job_order_base");
            strSql.Append(" where job_order_reviewer_id='" + user_name + "' ");
            strSql.Append(" and job_order_status='未审核' ");
            strSql.Append(" order by job_order_begintime asc ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 系统首页待处理工单列表
        /// </summary>
        public DataSet GetRelevantListForDesktop(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT top 10 job_order_id,job_order_name,job_order_endtime  ");
            strSql.Append("FROM gm_dt_job_order_base AS a  ");
            strSql.Append("LEFT OUTER JOIN gm_dt_job_order_service_type AS b ON a.job_order_type = b.service_id ");
            strSql.Append("where ((job_order_id IN  ");
            strSql.Append("(SELECT job_order_id from gm_dt_job_order_relevant where relevant_id='" + user_name + "')  ");
            strSql.Append("OR salesman_id='" + user_name + "' ");
            strSql.Append("OR technical_respon_id='" + user_name + "' ");
            strSql.Append("OR job_order_creator_id='" + user_name + "' ");
            strSql.Append("OR job_order_reviewer_id='" + user_name + "' )  ");
            strSql.Append(")AND job_order_status='同意' and a.job_order_type in(1,2,3,4) ");
            strSql.Append("AND CONVERT(varchar(10),job_order_endtime,120)>=CONVERT(varchar(10),getdate(),120) ");
            strSql.Append("order by job_order_endtime asc ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 系统首页部门级工单列表
        /// </summary>
        public DataSet GetDeptListForDesktop(int dept_id)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select a.job_order_id,a.job_order_name from dbo.gm_dt_job_order_base a  ");
            strSql.Append("left join dbo.gm_dt_sysuser b ");
            strSql.Append("on a.job_order_creator_id=b.user_name ");
            strSql.Append("left join dbo.gm_dt_job_order_service_type c ");
            strSql.Append("on a.job_order_type=c.service_id ");
            //strSql.Append("where b.dept_id='" + dept_id + "' and a.job_order_status='同意' and a.job_order_type in(6,7,8,9,10)");
            strSql.Append("where a.job_order_status='同意' and a.job_order_type in(6,7,8,9,10)" );
            strSql.Append("AND CONVERT(varchar(10),job_order_endtime,120)>=CONVERT(varchar(10),getdate(),120)");

            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}