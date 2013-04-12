using System;
using System.Collections.Generic;
using System.Text;
using MyQQ.interfaces;
using MyQQ.utils;
using MyQQ.dbmanagers;

namespace MyQQ.factorys
{
    class SqlManagerFactory:IDbManagerFactory
    {
        public ICommand GetCommandManager()
        {
            return new SqlCommandManager();
        }

        public IConnection GetConnectionManager()
        {
            return new SqlConnectionManager();
        }

        public IDataAdapter GetDataAdapterManager()
        {
            return new SqlDataAdapterManager();
        }
    }
}
