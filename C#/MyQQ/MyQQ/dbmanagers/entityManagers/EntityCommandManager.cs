using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyQQ.interfaces;
using System.Data.Common;
using System.Data.EntityClient;

namespace MyQQ.dbmanagers.sqlDbManagers.entityManagers
{
    class EntityCommandManager:ICommand
    {
        public DbCommand GetCommand(string sql, DbConnection connection)
        {
            return new EntityCommand(sql, connection as EntityConnection);
        }


        public DbCommand GetCommand()
        {
            return new EntityCommand();
        }
    }
}
