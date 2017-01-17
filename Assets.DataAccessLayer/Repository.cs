using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace Assets.DataAccessLayer
{
    public abstract class Repository<T> where T:class
    {
        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            }
        }

        protected virtual void Add(T item, string sql)
        {
            IDbConnection cn = null;
            try
            {
                cn = Connection;
                cn.Open();
                cn.Execute(sql, item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn != null)
                    cn.Close();
            }
        }

        protected virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        protected virtual IEnumerable<T> FindAll(string _tableName)
        {
            IEnumerable<T> items = null;
            IDbConnection cn = null;
            try
            {
                cn = Connection;
                cn.Open();
                items = cn.Query<T>(string.Format(" select * from [{0}] ", _tableName));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (cn != null)
                    cn.Close();
            }
            return items;
        }

        protected virtual void Remove(T item, string sql)
        {
            IDbConnection cn = null;
            try
            {
                cn = Connection;
                cn.Open();
                cn.Execute(sql, item);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (cn != null)
                    cn.Close();
            }
        }

        protected virtual void Update(T item,string sql)
        {
            IDbConnection cn = null;
            try
            {
                cn = Connection;
                cn.Open();
                cn.Execute(sql, item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn != null)
                    cn.Close();
            }
        }
    }
}
