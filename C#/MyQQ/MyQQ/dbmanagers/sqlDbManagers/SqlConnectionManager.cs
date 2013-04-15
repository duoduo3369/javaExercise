using System;
using System.Collections.Generic;
using System.Text;
using MyQQ.interfaces;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace MyQQ.dbmanagers.sqlDbManagers.sqlDbManagers
{
    class SqlConnectionManager : IConnection
    {
        public SqlConnectionManager()
        {
        }
        public DbConnection GetConnection()
        {

            return new SqlConnection(ConfigurationManager.ConnectionStrings["MyQQConnection"].ConnectionString);
        }

        public void ReleaseConnection(DbConnection connection)
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}
