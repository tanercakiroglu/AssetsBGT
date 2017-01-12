using Assets.DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Assets.DataAccessLayer
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection( "Data Source=188.121.44.212;Initial Catalog=assetsDB;User ID=assets-user;Password=Sa123456");
            }
        }

     

        public void Add(T item, string sql)
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

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindAll(string _tableName)
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


        public void Remove(T item, string sql)
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

        public void Update(T item,string sql)
        {
            IDbConnection cn = null;
            try
            {
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
