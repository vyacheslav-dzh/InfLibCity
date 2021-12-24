using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace InfLibCity
{

    class DBManipulator
    {
        static string connectionString = "server=vds90.server-1.biz;user id=st2;password=206206;database=st2;persistsecurityinfo=True";
        public static List<user> getUsers()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                List<user> DSusers = new List<user>();
                string command = "SELECT * FROM Users";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                adapter.Fill(dataSet);

                foreach (var row in dataSet.Tables[0].Select())
                {
                    DSusers.Add(new user((int)row[0], row[1].ToString(), (int)row[2]));
                }

                return DSusers;
            }
        }

        public static Person getPerson(user user) 
        {
            return new Librarian();
        }
        
    }
}
