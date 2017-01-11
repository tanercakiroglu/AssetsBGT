using System;
using System.Data;
using System.Data.SqlClient;

namespace Assets.DataAccessLayer
{
    public abstract class BaseDAO
    {
        private const string connString = "Data Source=188.121.44.212;Initial Catalog=assetsDB;User ID=assets-user;Password=Sa123456";

        private SqlConnection getConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return connection;
        }

        private void closeConneciton(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected DataTable ExecuteQuery(string sqlQuery)
        {
            var conn = getConnection();
            SqlCommand sqlCommand = null;
            DataTable dt = null;
            if (conn != null)
            {
                try
                {
                    conn.Open();
                    sqlCommand = new SqlCommand(sqlQuery, conn);
                    if (sqlCommand != null)
                    {
                        dt = new DataTable();
                        dt.Load(sqlCommand.ExecuteReader());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    try
                    {
                        closeConneciton(conn);
                        sqlCommand.Dispose();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }

            return dt;
        }

        protected void ExecuteNonQuery(string sqlQuery, params SqlParameter[] parameters)
        {
            var conn = getConnection();
            SqlCommand sqlCommand = null;
            if (conn != null)
            {
                try
                {
                    conn.Open();
                    sqlCommand = new SqlCommand(sqlQuery, conn);
                    sqlCommand.Parameters.AddRange(parameters);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    try
                    {
                        closeConneciton(conn);
                        sqlCommand.Dispose();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }
    }
}
