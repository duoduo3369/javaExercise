using System;
using System.Collections.Generic;
using System.Text;
using MyQQ.interfaces;
using System.Data.Common;
using System.Data.SqlClient;

namespace MyQQ.dbmanagers.sqlDbManagers
{
    class SqlDataAdapterManager:IDataAdapter
    {
        public DbDataAdapter GetDataAdapter(string sql, DbConnection connection)
        {
            return new SqlDataAdapter(sql, connection as SqlConnection);
        }
    }
}
