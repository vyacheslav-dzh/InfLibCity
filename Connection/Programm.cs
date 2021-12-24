using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Connection
{
    class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Get connection...");
            MySqlConnection conn = ServerUtils.GetDBConnection("vds90.server-1.biz", "st2", "206206", "st2");

            try
            {
                Console.WriteLine("Openning connection...");
                conn.Open();
                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.ReadKey();
        }
    }
}
