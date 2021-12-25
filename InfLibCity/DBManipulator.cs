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
                    DSusers.Add(new user((int)row[0], 
                                         row[1].ToString(), 
                                         row[2].ToString(), 
                                         (int)row[3]));
                }

                return DSusers;
            }
        }

        public static Person getPerson(user user) 
        {
            if (user.type == 0) {

                using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                    
                    DataSet dataSet = new DataSet();
                    List<Librarian> DSusers = new List<Librarian>();
                    string command = $"SELECT * FROM Librarians where libr_user_id = {user.id}";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                    adapter.Fill(dataSet);

                    var stroka = dataSet.Tables[0].Select()[0];

                    Librarian librarian = new Librarian((int)stroka[0], 
                                                        (int)stroka[1], 
                                                        stroka[2].ToString(), 
                                                        stroka[3].ToString(), 
                                                        stroka[4].ToString());

                    return librarian;
                }
            }
            else {

                using (MySqlConnection conn = new MySqlConnection(connectionString)) {


                    DataSet dataSet = new DataSet();
                    List<Librarian> DSusers = new List<Librarian>();
                    string command = $"SELECT *  FROM Peoples where people_user_id = {user.id}";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                    adapter.Fill(dataSet);

                    var stroka = dataSet.Tables[0].Select()[0];

                    People people = new People((int)stroka[0],
                                               (int)stroka[1],
                                               stroka[2].ToString(),
                                               stroka[3].ToString(),
                                               stroka[4].ToString());

                    return people;
                }
            }
        }

        public static void addUser(int type, string login, string pass, string firstName, string lastName, string middleName) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                conn.Open();

                // Добавляем USER
                string command_user = "INSERT INTO Users (user_id, user_login, user_pass, user_type) VALUES(NULL, @login, @pass, @type)";
                MySqlCommand myCommandUser = new MySqlCommand(command_user, conn);

                myCommandUser.Parameters.AddWithValue("@login", login);
                myCommandUser.Parameters.AddWithValue("@pass", pass);
                myCommandUser.Parameters.AddWithValue("@type", type);

                myCommandUser.ExecuteNonQuery();

                string command = $"SELECT * FROM Users where user_login = '{login}'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (type == 0) {

                    //string command_libr = "INSERT INTO Librarians"
                    firstName = "";
                    lastName = "";
                    middleName = "";
                }


               

            }

        }
        
    }
}
