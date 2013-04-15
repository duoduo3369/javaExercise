using System;
using System.Collections.Generic;
using System.Text;
using MyQQ.interfaces;
using System.Data.Common;
using System.Data.SqlClient;

namespace MyQQ.dbmanagers.sqlDbManagers.sqlDbManagers
{
    class SqlCommandManager:ICommand
    {
        public DbCommand GetCommand(string sql, DbConnection connection)
        {
            return new SqlCommand(sql, connection as SqlConnection);
        }


        public DbCommand GetCommand()
        {
            return new SqlCommand();
        }
    }
}
