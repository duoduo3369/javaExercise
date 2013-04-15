using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MyQQ.dbmanagers.sqlDbManagers.sqlDbManagers;
using System.Data.Common;
using MyQQ.dbmanagers.sqlDbManagers;
using MyQQ.interfaces;
using MyQQ.factorys;
using System.Configuration;
using System.Data.EntityClient;
using MyQQ.dbmanagers.sqlDbManagers.entityManagers;

namespace MyQQ
{
    // 数据库帮助类，维护数据库连接字符串和数据库连接对象
    class DBHelper
    {
        //private static string connString = "Data Source=.;Initial Catalog=MyQQ;User ID=sa;Pwd=sa";
        private static IDbManagerFactory dbManagerFactory = new SqlManagerFactory();
        //private static IDbManagerFactory dbManagerFactory = new EntityManagerFactory();

        private static IConnection connectionManager = dbManagerFactory.GetConnectionManager();
        private static ICommand commandManager = dbManagerFactory.GetCommandManager();
        private static IDataAdapter dataAdapterManager = dbManagerFactory.GetDataAdapterManager();
        private static DbConnection connection = connectionManager.GetConnection();
        private static EntityConnection entityConnection = (new EntityConnectionManager()).GetConnection() as EntityConnection;
        private static MyQQEntities myQQEntities = new MyQQEntities(entityConnection);
        public static DbConnection GetConnection()
        {
            return connection;
        }
        public static MyQQEntities GetEntities() 
        {
            return myQQEntities;
        }
        public static MyQQEntities GetNewEntities() {
            return new MyQQEntities(entityConnection);
        }
        public static DbCommand GetCommand()
        {
            return commandManager.GetCommand();
        }
        public static DbCommand GetCommand(string sql, DbConnection connection)
        {
            return commandManager.GetCommand(sql, connection);

        }
        public static DbDataAdapter GetDataAdapter(string sql, DbConnection connection)
        {
            return dataAdapterManager.GetDataAdapter(sql, connection);
        }
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyQQConnection"].ConnectionString;
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
