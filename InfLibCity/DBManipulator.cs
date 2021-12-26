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
        static string connectionString = "server=vds90.server-1.biz;user id=st2;password=206206;database=st2;persistsecurityinfo=True;CharSet=utf8";
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
                                         (int)row[3],
                                         row[4].ToString(),
                                         row[5].ToString()));
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

        public static void addUser(int type, string login, string pass, string firstName, string lastName, string middleName) { // Person newPerson, user newUser

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                conn.Open();

                // Добавляем USER
                string command_user = $"INSERT INTO Users (user_id, user_login, user_pass, user_type) VALUES(NULL, '{login}', '{pass}', {type})";
                MySqlCommand myCommandUser = new MySqlCommand(command_user, conn);
                myCommandUser.ExecuteNonQuery();


                // Берем id из новой созданной строки в таблице USERS
                string command = $"SELECT * FROM Users where user_login = '{login}'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                int userid = (int)dataSet.Tables[0].Select()[0][0];


                if (type == 0) {

                    string command_libr = $"INSERT INTO Librarians (libr_id, libr_user_id, libr_first_name, libr_last_name, libr_middle_name) VALUES(NULL, {userid}, '{firstName}', '{lastName}', '{middleName}')";
                    MySqlCommand myCommandLibrarians = new MySqlCommand(command_libr, conn);
                    myCommandLibrarians.ExecuteNonQuery();

                }
                else {

                    string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name) VALUES(NULL, {userid}, '{firstName}', '{lastName}', '{middleName}')";
                    MySqlCommand myCommandPeoples = new MySqlCommand(command_people, conn);
                    myCommandPeoples.ExecuteNonQuery();

                }

            }

        }


        public static void addUser(Person newPerson, user newUser) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {


                // Добавляем нового пользователя
                conn.Open();
                string command_user = $"INSERT INTO Users (user_id, user_login, user_pass, user_type, user_phone, user_email) VALUES(NULL, '{newUser.login}', '{newUser.pass}', {newUser.type}, '{newUser.phone}', '{newUser.email}')";
                MySqlCommand myCommandUser = new MySqlCommand(command_user, conn);
                myCommandUser.ExecuteNonQuery();


                // Берем id из новой созданной строки в таблице USERS
                string command = $"SELECT * FROM Users where user_login = '{newUser.login}'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                int userid = (int)dataSet.Tables[0].Select()[0][0];

                
                if (newUser.type == 0) {

                    // Добавляем библиотекаря
                    string command_libr = $"INSERT INTO Librarians (libr_id, libr_user_id, libr_first_name, libr_last_name, libr_middle_name) VALUES(NULL, {userid}, '{newPerson.firstName}', '{newPerson.lastName}', '{newPerson.middleName}')";
                    MySqlCommand myCommandLibrarians = new MySqlCommand(command_libr, conn);
                    myCommandLibrarians.ExecuteNonQuery();

                }
                else {

                    // Добавляем читателя
                    //string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name) VALUES(NULL, {userid}, '{newPerson.firstName}', '{newPerson.lastName}', '{newPerson.middleName}')";
                    //MySqlCommand myCommandPeoples = new MySqlCommand(command_people, conn);
                    //myCommandPeoples.ExecuteNonQuery();

                    
                    if (newPerson.GetType().Name == "SchoolBoy") {
                       
                        SchoolBoy schoolBoy = newPerson as SchoolBoy;

                        // Добавляем читателя
                        string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES(NULL, {userid}, '{schoolBoy.firstName}', '{schoolBoy.lastName}', '{schoolBoy.middleName}', {SchoolBoy.personType})";
                        MySqlCommand myCommandPeoples = new MySqlCommand(command_people, conn);
                        myCommandPeoples.ExecuteNonQuery();

                    }
                    else if (newPerson.GetType().Name == "Student") {

                        Student student = newPerson as Student;

                        // Добавляем читателя
                        string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES(NULL, {userid}, '{student.firstName}', '{student.lastName}', '{student.middleName}', {Student.personType})";
                        MySqlCommand myCommandPeoples = new MySqlCommand(command_people, conn);
                        myCommandPeoples.ExecuteNonQuery();

                    }
                    else if (newPerson.GetType().Name == "Teacher") {

                        Teacher teacher = newPerson as Teacher;

                        // Добавляем читателя
                        string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES(NULL, {userid}, '{teacher.firstName}', '{teacher.lastName}', '{teacher.middleName}', {Teacher.personType})";
                        MySqlCommand myCommandPeoples = new MySqlCommand(command_people, conn);
                        myCommandPeoples.ExecuteNonQuery();

                    }
                    else if (newPerson.GetType().Name == "Scientist") {

                        Scientist scientist = newPerson as Scientist;

                        // Добавляем читателя
                        string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES(NULL, {userid}, '{scientist.firstName}', '{scientist.lastName}', '{scientist.middleName}', {Scientist.personType})";
                        MySqlCommand myCommandPeoples = new MySqlCommand(command_people, conn);
                        myCommandPeoples.ExecuteNonQuery();

                    }
                    else if (newPerson.GetType().Name == "Worker") {

                        Worker worker = newPerson as Worker;

                        // Добавляем читателя
                        string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES(NULL, {userid}, '{worker.firstName}', '{worker.lastName}', '{worker.middleName}', {Worker.personType})";
                        MySqlCommand myCommandPeoples = new MySqlCommand(command_people, conn);
                        myCommandPeoples.ExecuteNonQuery();

                    }
                    else if (newPerson.GetType().Name == "Other") {

                        Other other = newPerson as Other;

                        // Добавляем читателя
                        string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES(NULL, {userid}, '{other.firstName}', '{other.lastName}', '{other.middleName}', {Other.personType})";
                        MySqlCommand myCommandPeoples = new MySqlCommand(command_people, conn);
                        myCommandPeoples.ExecuteNonQuery();

                    }

                }
            }

        }


        /// <summary>
        /// Функция, которая определяет оригинальность логина (логин не должен совпадать с другими логинами в БД)
        /// </summary>
        /// <param name="login"> - логин нового аккаунта</param>
        /// <returns>true - совпадение найдено; false - совпадений нет</returns>
        public static bool Samelogin(string login) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                string command = "SELECT user_login FROM Users";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                foreach (var row in dataSet.Tables[0].Select()) {
                    if (login == row[0].ToString())
                        return true;
                }

            }

            return false;
        }

    }
}
