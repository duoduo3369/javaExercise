using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace MyQQ.interfaces
{
	interface IConnection
	{
        DbConnection GetConnection();
        void ReleaseConnection(DbConnection connection);
	}
}
