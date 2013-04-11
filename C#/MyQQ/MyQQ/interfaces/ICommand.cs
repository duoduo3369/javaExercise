using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace MyQQ.interfaces
{
    interface ICommand
    {
        DbCommand GetCommand(String sql, DbConnection connection);
        DbCommand GetCommand();
    }
}
