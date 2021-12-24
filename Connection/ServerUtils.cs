using System;
// using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Connection
{
    class ServerUtils
    {
        public static MySqlConnection GetDBConnection(string host, string username, string password, string database)
        {
            // server = vds90.server - 1.biz; user id = st2; database = st2; persistsecurityinfo = True
            // server=vds90.server-1.biz;user id=st2;database=st2
            String connString = "Server=" + host + ";Database=" + database
                + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
    }
}
