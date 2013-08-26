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
    /// 数据访问类:工时
    /// </summary>
    public partial class working_hour
    {
        public working_hour()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from gm_dt_working_hour");
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
        public int Add(Model.working_hour model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into gm_dt_working_hour(");
            strSql.Append("user_name,date,job_order_id,product_type,service_type,working_content,working_hours,journey_hours,overtime_hours,status,create_time)");
            strSql.Append(" values (");
            strSql.Append("@user_name,@date,@job_order_id,@product_type,@service_type,@working_content,@working_hours,@journey_hours,@overtime_hours,@status,@create_time)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@date", SqlDbType.DateTime),
					new SqlParameter("@job_order_id", SqlDbType.Int,4),
					new SqlParameter("@product_type", SqlDbType.TinyInt),
					new SqlParameter("@service_type", SqlDbType.TinyInt),
					new SqlParameter("@working_content", SqlDbType.NVarChar,1000),
					new SqlParameter("@working_hours", SqlDbType.Decimal),
					new SqlParameter("@journey_hours", SqlDbType.Decimal),
                    new SqlParameter("@overtime_hours", SqlDbType.Decimal),
                    new SqlParameter("@status", SqlDbType.TinyInt),
                    new SqlParameter("@create_time", SqlDbType.DateTime),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)};
            parameters[0].Value = model.user_name;
            parameters[1].Value = model.date;
            parameters[2].Value = model.job_order_id;
            parameters[3].Value = model.product_type;
            parameters[4].Value = model.service_type;
            parameters[5].Value = model.working_content;
            parameters[6].Value = model.working_hours;
            parameters[7].Value = model.journey_hours;
            parameters[8].Value = model.overtime_hours;
            parameters[9].Value = model.status;
            parameters[10].Value = model.create_time;
            parameters[11].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //附件
            if (model.download_attachs != null)
            {
                StringBuilder strSql4;
                foreach (Model.download_attach models in model.download_attachs)
                {
                    strSql4 = new StringBuilder();
                    strSql4.Append("insert into dt_download_attach(");
                    strSql4.Append("article_id,title,file_path,file_ext,file_size)");
                    strSql4.Append(" values (");
                    strSql4.Append("@article_id,@title,@file_path,@file_ext,@file_size)");
                    SqlParameter[] parameters4 = {
					        new SqlParameter("@article_id", SqlDbType.Int,4),
					        new SqlParameter("@title", SqlDbType.NVarChar,255),
					        new SqlParameter("@file_path", SqlDbType.NVarChar,255),
					        new SqlParameter("@file_ext", SqlDbType.NVarChar,100),
					        new SqlParameter("@file_size", SqlDbType.Int,4)};
                    parameters4[0].Direction = ParameterDirection.InputOutput;
                    parameters4[1].Value = models.title;
                    parameters4[2].Value = models.file_path;
                    parameters4[3].Value = models.file_ext;
                    parameters4[4].Value = models.file_size;
                    cmd = new CommandInfo(strSql4.ToString(), parameters4);
                    sqllist.Add(cmd);
                }
            }

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[11].Value;

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.working_hour model)
               
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update gm_dt_working_hour set ");
                        strSql.Append("date=@date,");
                        strSql.Append("job_order_id=@job_order_id,");
                        strSql.Append("product_type=@product_type,");
                        strSql.Append("service_type=@service_type,");
                        strSql.Append("working_content=@working_content,");
                        strSql.Append("working_hours=@working_hours,");
                        strSql.Append("journey_hours=@journey_hours,");
                        strSql.Append("overtime_hours=@overtime_hours,");
                        strSql.Append("status=@status");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					        new SqlParameter("@date", SqlDbType.DateTime),
					        new SqlParameter("@job_order_id", SqlDbType.Int,4),
					        new SqlParameter("@product_type", SqlDbType.TinyInt),
					        new SqlParameter("@service_type", SqlDbType.TinyInt),
					        new SqlParameter("@working_content", SqlDbType.NVarChar,1000),
					        new SqlParameter("@working_hours", SqlDbType.Decimal),
					        new SqlParameter("@journey_hours", SqlDbType.Decimal),
					        new SqlParameter("@overtime_hours", SqlDbType.Decimal),
					        new SqlParameter("@status", SqlDbType.TinyInt),
					        new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters[0].Value = model.date;
                        parameters[1].Value = model.job_order_id;
                        parameters[2].Value = model.product_type;
                        parameters[3].Value = model.service_type;
                        parameters[4].Value = model.working_content;
                        parameters[5].Value = model.working_hours;
                        parameters[6].Value = model.journey_hours;
                        parameters[7].Value = model.overtime_hours;
                        parameters[8].Value = model.status;
                        parameters[9].Value = model.id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //删除已删除的附件
                        new download_attach().DeleteList(conn, trans, model.download_attachs, model.id);
                        // 添加/修改附件
                        if (model.download_attachs != null)
                        {
                            StringBuilder strSql2;
                            foreach (Model.download_attach models in model.download_attachs)
                            {
                                strSql2 = new StringBuilder();
                                if (models.id > 0)
                                {
                                    strSql2.Append("update dt_download_attach set ");
                                    strSql2.Append("article_id=@article_id,");
                                    strSql2.Append("title=@title,");
                                    strSql2.Append("file_path=@file_path,");
                                    strSql2.Append("file_ext=@file_ext,");
                                    strSql2.Append("file_size=@file_size");
                                    strSql2.Append(" where id=@id");
                                    SqlParameter[] parameters2 = {
					                        new SqlParameter("@article_id", SqlDbType.Int,4),
					                        new SqlParameter("@title", SqlDbType.NVarChar,255),
					                        new SqlParameter("@file_path", SqlDbType.NVarChar,255),
					                        new SqlParameter("@file_ext", SqlDbType.NVarChar,100),
					                        new SqlParameter("@file_size", SqlDbType.Int,4),
					                        new SqlParameter("@id", SqlDbType.Int,4)};
                                    parameters2[0].Value = models.article_id;
                                    parameters2[1].Value = models.title;
                                    parameters2[2].Value = models.file_path;
                                    parameters2[3].Value = models.file_ext;
                                    parameters2[4].Value = models.file_size;
                                    parameters2[5].Value = models.id;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                                }
                                else
                                {
                                    strSql2.Append("insert into dt_download_attach(");
                                    strSql2.Append("article_id,title,file_path,file_ext,file_size)");
                                    strSql2.Append(" values (");
                                    strSql2.Append("@article_id,@title,@file_path,@file_ext,@file_size)");
                                    SqlParameter[] parameters2 = {
					                        new SqlParameter("@article_id", SqlDbType.Int,4),
					                        new SqlParameter("@title", SqlDbType.NVarChar,255),
					                        new SqlParameter("@file_path", SqlDbType.NVarChar,255),
					                        new SqlParameter("@file_ext", SqlDbType.NVarChar,100),
					                        new SqlParameter("@file_size", SqlDbType.Int,4)};
                                    parameters2[0].Value = models.article_id;
                                    parameters2[1].Value = models.title;
                                    parameters2[2].Value = models.file_path;
                                    parameters2[3].Value = models.file_ext;
                                    parameters2[4].Value = models.file_size;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                                }
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
            strSql.Append("delete from gm_dt_working_hour ");
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
        public Model.working_hour GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,user_name,date,job_order_id,product_type,service_type,working_content,working_hours,journey_hours,overtime_hours,status,create_time");
            strSql.Append(" from gm_dt_working_hour ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;


            DTcms.Model.working_hour model = new DTcms.Model.working_hour();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region  父表信息
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_name"] != null && ds.Tables[0].Rows[0]["user_name"].ToString() != "")
                {
                    model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["date"] != null && ds.Tables[0].Rows[0]["date"].ToString() != "")
                {
                    model.date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["job_order_id"] != null && ds.Tables[0].Rows[0]["job_order_id"].ToString() != "")
                {
                    model.job_order_id = int.Parse(ds.Tables[0].Rows[0]["job_order_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["product_type"] != null && ds.Tables[0].Rows[0]["product_type"].ToString() != "")
                {
                    model.product_type = byte.Parse(ds.Tables[0].Rows[0]["product_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["service_type"] != null && ds.Tables[0].Rows[0]["service_type"].ToString() != "")
                {
                    model.service_type = byte.Parse(ds.Tables[0].Rows[0]["service_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["working_content"] != null && ds.Tables[0].Rows[0]["working_content"].ToString() != "")
                {
                    model.working_content = ds.Tables[0].Rows[0]["working_content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["working_hours"] != null && ds.Tables[0].Rows[0]["working_hours"].ToString() != "")
                {
                    model.working_hours = Convert.ToDecimal(ds.Tables[0].Rows[0]["working_hours"].ToString());
                }
                if (ds.Tables[0].Rows[0]["journey_hours"] != null && ds.Tables[0].Rows[0]["journey_hours"].ToString() != "")
                {
                    model.journey_hours = Convert.ToDecimal(ds.Tables[0].Rows[0]["journey_hours"].ToString());
                }
                if (ds.Tables[0].Rows[0]["overtime_hours"] != null && ds.Tables[0].Rows[0]["overtime_hours"].ToString() != "")
                {
                    model.overtime_hours = Convert.ToDecimal(ds.Tables[0].Rows[0]["overtime_hours"].ToString());
                }
                if (ds.Tables[0].Rows[0]["status"] != null && ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.status = byte.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["create_time"] != null && ds.Tables[0].Rows[0]["create_time"].ToString() != "")
                {
                    model.create_time = DateTime.Parse(ds.Tables[0].Rows[0]["create_time"].ToString());
                }
                #endregion  父表信息end

                model.download_attachs = new download_attach().GetList(id); //附件列表

                return model;
            }
            else
            {
                return null;
            }
        }

        ///// <summary>
        ///// 根据用户名密码返回一个实体
        ///// </summary>
        //public Model.job_order GetModel(string user_name, string user_pwd)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select id from dt_manager");
        //    strSql.Append(" where user_name=@user_name and user_pwd=@user_pwd and is_lock=0");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@user_name", SqlDbType.NVarChar,100),
        //            new SqlParameter("@user_pwd", SqlDbType.NVarChar,100)};
        //    parameters[0].Value = user_name;
        //    parameters[1].Value = user_pwd;

        //    object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
        //    if (obj != null)
        //    {
        //        return GetModel(Convert.ToInt32(obj));
        //    }
        //    return null;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM gm_dt_working_hour ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by date desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDeptWorkingHourList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c.*,d.role_value");
            strSql.Append(" from(");
            strSql.Append(" select a.*,b.role_id,b.dept_id");
            strSql.Append(" from gm_dt_working_hour a");
            strSql.Append(" left join gm_dt_sysuser b on a.user_name=b.user_name");
            strSql.Append(" ) c ");
            strSql.Append(" left join dbo.gm_dt_sysuser_role d on c.role_id=d.id");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by user_name asc, date desc");
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
            strSql.Append(" id,user_name,date,job_order_id,product_type,service_type,working_content,working_hours,journey_hours,overtime_hours,status,create_time");
            strSql.Append(" FROM gm_dt_working_hour ");
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
            strSql.Append("SELECT * FROM gm_dt_working_hour");
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
        public DataSet GetTypeList(string table)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM " + table);

            return DbHelperSQL.Query(strSql.ToString());
        }

        ///// <summary>
        ///// 审核一条数据
        ///// </summary>
        //public bool Review(Model.job_order model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update gm_dt_job_order_base set ");
        //    strSql.Append("job_order_status=@job_order_status,");
        //    strSql.Append("job_order_advice=@job_order_advice");
        //    strSql.Append(" where job_order_id=@id");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@job_order_status", SqlDbType.NVarChar,50),
        //            new SqlParameter("@job_order_advice", SqlDbType.NVarChar,50),
        //            new SqlParameter("@id", SqlDbType.Int,4)};
        //    parameters[0].Value = model.job_order_status;
        //    parameters[1].Value = model.job_order_advice;
        //    parameters[2].Value = model.job_order_id;

        //    int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// 获得工单名称
        /// </summary>
        public string GetJobOrderName(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 job_order_name from gm_dt_job_order_base");
            strSql.Append(" where job_order_id=" + id);
            string name = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(name))
            {
                return "";
            }
            return name;
        }

        /// <summary>
        /// 获得产品类型名称
        /// </summary>
        public string GetProductTypeName(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 name from gm_dt_product_type");
            strSql.Append(" where id=" + id);
            string name = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(name))
            {
                return "";
            }
            return name;
        }

        /// <summary>
        /// 获得服务类型名称
        /// </summary>
        public string GetServiceTypeName(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 name from gm_dt_service_type");
            strSql.Append(" where id=" + id);
            string name = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(name))
            {
                return "";
            }
            return name;
        }

        /// <summary>
        /// 获得个人工时汇总
        /// </summary>
        public DataSet GetTimeSum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT top 1 count(1) count, ");
            strSql.Append("sum(working_hours) sum_working, ");
            strSql.Append("sum(journey_hours) sum_journey, ");
            strSql.Append("sum(overtime_hours) sum_overtime  ");
            strSql.Append("from ( ");
            strSql.Append("select * ");
            strSql.Append("from gm_dt_working_hour  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(") tmp ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得部门工时汇总
        /// </summary>
        public DataSet GetDeptTimeSum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT top 1 count(1) count, ");
            strSql.Append("sum(working_hours) sum_working, ");
            strSql.Append("sum(journey_hours) sum_journey, ");
            strSql.Append("sum(overtime_hours) sum_overtime  ");
            strSql.Append("from ( ");
            strSql.Append("select c.*,d.role_value ");
            strSql.Append("from( ");
            strSql.Append("select a.*,b.role_id,b.dept_id ");
            strSql.Append("from gm_dt_working_hour a ");
            strSql.Append("left join gm_dt_sysuser b on a.user_name=b.user_name ");
            strSql.Append(") c  ");
            strSql.Append("left join dbo.gm_dt_sysuser_role d on c.role_id=d.id ");
            strSql.Append(") e ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得指定工单工时列表
        /// </summary>
        public DataSet GetJobOrderWorkingHourList(int jobOrderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 5 a.id,a.user_name,a.date,a.job_order_id,product_type,a.service_type, ");
            strSql.Append(" a.working_content,a.working_hours,a.journey_hours,a.overtime_hours,a.status ");
            strSql.Append(" from dbo.gm_dt_working_hour a inner join dbo.gm_dt_job_order_base b ");
            strSql.Append(" on a.job_order_id =b.job_order_id ");
            strSql.Append(" where a.job_order_id='" + jobOrderId + "' ");
            strSql.Append(" order by a.date desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}