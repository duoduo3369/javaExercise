using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.EntityClient;
using System.Data.Common;
using MyQQ.interfaces;
namespace MyQQ.dbmanagers.sqlDbManagers.entityManagers
{
    class EntityConnectionManager : IConnection
    {
        
        public EntityConnectionManager()
        {
            
        }
        public DbConnection GetConnection()
        {
            return new EntityConnection(ConfigurationManager.ConnectionStrings["MyQQEntities"].ConnectionString);  
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
