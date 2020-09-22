using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;

namespace UtilData
{

    public class Connection<T> where T : new()
    {
        public Connection()
        {
        }

        public List<T> Get(string sql, Dictionary<string, object> parametro = null)
        {
            try
            {
                OpenConnection();
                return GlobalConnection.Connection.Query<T>(sql, parametro).ToList();
            }
            catch (SqlException ex)
            {
                throw new Exception(string.Format("{0}", ex.Message), ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        public int ExecInsert(string sql, Dictionary<string, object> parameters)
        {
            try 
            { 
                OpenConnection();
                 return GlobalConnection.Connection.Query<int>(sql, parameters).Single();
            }
            catch (SqlException ex)
            {
                throw new Exception(string.Format("{0}", ex.Message), ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        public int Exec(string sql, Dictionary<string, object> parametro)
        {
            try
            {
                OpenConnection();
                return GlobalConnection.Connection.Execute(sql, parametro);
            }
            catch (SqlException ex)
            {
                throw new Exception(string.Format("{0}", ex.Message), ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        private void OpenConnection()
        {
            if (GlobalConnection.Connection.State != ConnectionState.Open)
            {
                GlobalConnection.Connection.Open();
            }
        }
        private void CloseConnection()
        {
            //GlobalConnection.conn.Close();
        }

    }
    public static class GlobalConnection
    {
        public static SQLiteConnection Connection { get; set; }

        public static void OpenConnection()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
            Connection = SqLiteBase.SimpleDbConnection();
            Connection.Open();
        }

    

    }
}