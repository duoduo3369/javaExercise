using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MyQQ.utils;
using System.Data.Common;
using MyQQ.dbmanagers;

namespace MyQQ
{
    // 数据库帮助类，维护数据库连接字符串和数据库连接对象
    class DBHelper
    {
        private static string connString = "Data Source=.;Initial Catalog=MyQQ;User ID=sa;Pwd=sa";
        private static DbConnection connection = (new SqlConnectionManager()).GetConnection();
        private static SqlCommandManager sqlCommandManager = new SqlCommandManager();
        private static SqlDataAdapterManager sqlDataAdapterManager = new SqlDataAdapterManager();
        public static DbConnection GetConnection()
        {
            return connection;
        }
        public static DbCommand GetCommand() 
        {
            return sqlCommandManager.GetCommand();
        }
        public static DbCommand GetCommand(string sql, DbConnection connection)
        {
            return sqlCommandManager.GetCommand(sql, connection);

        }
        public static DbDataAdapter GetDataAdapter(string sql, DbConnection connection)
        {
            return sqlDataAdapterManager.GetDataAdapter(sql, connection);
        }
        public static string GetConnectionString()
        {
            return connString;
        }
        public static void OpenConnection()
        {
            if (connection != null)
            {
                connection.Open();
            }
        }
        public static void ColseConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}
