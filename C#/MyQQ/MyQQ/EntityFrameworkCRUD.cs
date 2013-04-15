using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using MyQQ.factorys;
using MyQQ.interfaces;
using System.Data.Common;

namespace MyQQ
{
    class EntityFrameworkCRUD
    {
        private DbConnection connection;
        private MyQQEntities entities;
        private IDbManagerFactory dbManagerFactory;
        private IConnection connectionManager;
        private ICommand commandManager;
        public EntityFrameworkCRUD()
        {
            dbManagerFactory = new EntityManagerFactory();
            connectionManager = dbManagerFactory.GetConnectionManager();
            commandManager = dbManagerFactory.GetCommandManager();
            connection = connectionManager.GetConnection();
            entities = new MyQQEntities(connection as EntityConnection);
        }
        public int Count()
        {
            return entities.BloodTypes.Count<BloodType>();
        }
        public int sql()
        {
            int num = entities.Users.Count<User>(item => item.Id == 10000 && item.LoginPwd == "0000");
            return num;

        }
    }
}
