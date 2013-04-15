using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyQQ.interfaces;
using MyQQ.dbmanagers.sqlDbManagers.entityManagers;

namespace MyQQ.factorys
{
    class EntityManagerFactory:IDbManagerFactory
    {
        public ICommand GetCommandManager()
        {
            return new EntityCommandManager();
        }

        public IConnection GetConnectionManager()
        {
            return new EntityConnectionManager();
        }

        public IDataAdapter GetDataAdapterManager()
        {
            return null;
        }
    }
}
