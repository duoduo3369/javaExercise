using System;
using System.Collections.Generic;
using System.Text;
using MyQQ.interfaces;
using System.Data.Common;
using System.Data.SqlClient;

namespace MyQQ.utils
{
    class SqlConnectionManager : IConnection
    {
        private String connString;
        public SqlConnectionManager()
        {
            connString = DBHelper.GetConnectionString();
        }
        public DbConnection GetConnection()
        {
            return new SqlConnection(connString);
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
