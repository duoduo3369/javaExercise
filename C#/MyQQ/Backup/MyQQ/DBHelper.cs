using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MyQQ
{
    // ���ݿ�����࣬ά�����ݿ������ַ��������ݿ����Ӷ���
    class DBHelper
    {
        private static string connString = "Data Source=.;Initial Catalog=MyQQ;User ID=sa;Pwd=sa";
        public static SqlConnection connection = new SqlConnection(connString);
    }
}
