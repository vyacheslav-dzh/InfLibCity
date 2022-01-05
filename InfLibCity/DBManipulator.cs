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


        /// <summary>
        /// Строка для подключения к БД
        /// </summary>
        static string connectionString = "server=vds90.server-1.biz;user id=st2;password=206206;database=st2;persistsecurityinfo=True;CharSet=utf8";



        /// <summary>
        /// Возвращает список всех зарегестрированных пользователей
        /// </summary>
        /// <returns>Список зарегестрированных пользователей</returns>
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



        /// <summary>
        /// Возвращает тип пользоватея
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Тип пользователя</returns>
        public static Person getPerson(user user) 
        {
            if (user.type == 0) {

                using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                    
                    DataSet dataSet = new DataSet();
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

        

        /// <summary>
        /// Добавление Пользователя в БД
        /// </summary>
        /// <param name="newPerson">Тип пользователя</param>
        /// <param name="newUser">Общие Данные пользователей, включая данные для входа в систему</param>
        public static void addUser(Person newPerson, user newUser) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {


                // Добавляем нового пользователя
                conn.Open();
                string command_user = $"INSERT INTO Users (user_login, user_pass, user_type, user_phone, user_email, user_lib_id) VALUES('{newUser.login}', '{newUser.pass}', {newUser.type}, '{newUser.phone}', '{newUser.email}', {newUser.libraryID})";
                ExecuteSQL(command_user, conn);


                // Берем id из новой созданной строки в таблице USERS
                string command = $"SELECT * FROM Users where user_login = '{newUser.login}'";
                int userid = GetNewRowID(command, conn);


                // Добавление библиотекаря
                if (newUser.type == 0) {

                    Librarian librarian = newPerson as Librarian;

                    //string command_libr = $"INSERT INTO Librarians (libr_id, libr_user_id, libr_first_name, libr_last_name, libr_middle_name) VALUES(NULL, {userid}, '{newPerson.firstName}', '{newPerson.lastName}', '{newPerson.middleName}')";
                    string command_libr = $"INSERT INTO Librarians (libr_user_id, libr_first_name, libr_last_name, libr_middle_name, libr_room_id) VALUES({userid}, '{librarian.firstName}', '{librarian.lastName}', '{librarian.middleName}', {librarian.roomID})";
                    ExecuteSQL(command_libr, conn);

                }

                // Добавление читателя
                else {

                    // Добавление Школьника
                    if (newPerson.GetType().Name == "SchoolBoy") {
                        
                        SchoolBoy schoolBoy = newPerson as SchoolBoy;

                        // Добавляем читателя
                        //string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES(NULL, {userid}, '{schoolBoy.firstName}', '{schoolBoy.lastName}', '{schoolBoy.middleName}', { SchoolBoy.personType})";
                        string command_people = $"INSERT INTO Peoples (people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES({userid}, '{schoolBoy.firstName}', '{schoolBoy.lastName}', '{schoolBoy.middleName}', { SchoolBoy.personType})";
                        ExecuteSQL(command_people, conn);


                        // Берем id из новой созданной строки в таблице Peoples
                        string commandPeople = $"SELECT * FROM Peoples where people_user_id = {userid}";
                        int peopleid = GetNewRowID(commandPeople, conn);


                        // Создаем строчку в строки в таблице PeopleAttributer
                        //string command_attr = $"INSERT INTO PeopleAttributes (pa_id, pa_people_id, pa_institution, pa_group, pa_subject, pa_faculty, pa_orgname, pa_direction, pa_post, pa_workname) VALUES(NULL, {peopleid}, '{schoolBoy.institution}', '{schoolBoy.group}', NULL, NULL, NULL, NULL, NULL, NULL)";
                        string command_attr = $"INSERT INTO PeopleAttributes (pa_people_id, pa_institution, pa_group) VALUES({peopleid}, '{schoolBoy.institution}', '{schoolBoy.group}')";
                        ExecuteSQL(command_attr, conn);

                    }

                    // Добавление студента
                    else if (newPerson.GetType().Name == "Student") {

                        Student student = newPerson as Student;

                        // Добавляем читателя
                        //string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES(NULL, {userid}, '{schoolBoy.firstName}', '{schoolBoy.lastName}', '{schoolBoy.middleName}', { SchoolBoy.personType})";
                        string command_people = $"INSERT INTO Peoples (people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES({userid}, '{student.firstName}', '{student.lastName}', '{student.middleName}', {Student.personType})";
                        ExecuteSQL(command_people, conn);


                        // Берем id из новой созданной строки в таблице Peoples
                        string commandPeople = $"SELECT * FROM Peoples where people_user_id = {userid}";
                        int peopleid = GetNewRowID(commandPeople, conn);


                        // Создаем строчку в строки в таблице PeopleAttributer
                        string command_attr = $"INSERT INTO PeopleAttributes (pa_people_id, pa_institution, pa_group, pa_faculty) VALUES({peopleid}, '{student.institution}', '{student.group}', '{student.faculty}')";
                        ExecuteSQL(command_attr, conn);

                    }

                    // Добалвение преподавателя
                    else if (newPerson.GetType().Name == "Teacher") {

                        Teacher teacher = newPerson as Teacher;

                        // Добавляем читателя
                        //string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES(NULL, {userid}, '{schoolBoy.firstName}', '{schoolBoy.lastName}', '{schoolBoy.middleName}', { SchoolBoy.personType})";
                        string command_people = $"INSERT INTO Peoples (people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES({userid}, '{teacher.firstName}', '{teacher.lastName}', '{teacher.middleName}', {Teacher.personType})";
                        ExecuteSQL(command_people, conn);


                        // Берем id из новой созданной строки в таблице Peoples
                        string commandPeople = $"SELECT * FROM Peoples where people_user_id = {userid}";
                        int peopleid = GetNewRowID(commandPeople, conn);


                        // Создаем строчку в строки в таблице PeopleAttributer
                        //string command_attr = $"INSERT INTO PeopleAttributes (pa_id, pa_people_id, pa_institution, pa_group, pa_subject, pa_faculty, pa_orgname, pa_direction, pa_post, pa_workname) VALUES(NULL, {peopleid}, '{teacher.orgName}', NULL, '{teacher.subject}', NULL, NULL, NULL, NULL, NULL)";
                        string command_attr = $"INSERT INTO PeopleAttributes (pa_people_id, pa_institution, pa_subject) VALUES({peopleid}, '{teacher.orgName}', '{teacher.subject}')";
                        ExecuteSQL(command_attr, conn);

                    }

                    // Добавление Научного деятеля
                    else if (newPerson.GetType().Name == "Scientist") {

                        Scientist scientist = newPerson as Scientist;

                        // Добавляем читателя
                        //string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES(NULL, {userid}, '{schoolBoy.firstName}', '{schoolBoy.lastName}', '{schoolBoy.middleName}', { SchoolBoy.personType})";
                        string command_people = $"INSERT INTO Peoples (people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES({userid}, '{scientist.firstName}', '{scientist.lastName}', '{scientist.middleName}', {Scientist.personType})";
                        ExecuteSQL(command_people, conn);


                        // Берем id из новой созданной строки в таблице Peoples
                        string commandPeople = $"SELECT * FROM Peoples where people_user_id = {userid}";
                        int peopleid = GetNewRowID(commandPeople, conn);


                        // Создаем строчку в строки в таблице PeopleAttributer
                        //string command_attr = $"INSERT INTO PeopleAttributes (pa_id, pa_people_id, pa_institution, pa_group, pa_subject, pa_faculty, pa_orgname, pa_direction, pa_post, pa_workname) VALUES(NULL, {peopleid}, NULL, NULL, NULL, NULL, '{scientist.orgName}', '{scientist.direction}', NULL, NULL)";
                        string command_attr = $"INSERT INTO PeopleAttributes (pa_people_id, pa_orgname, pa_direction) VALUES({peopleid}, '{scientist.orgName}', '{scientist.direction}')";
                        ExecuteSQL(command_attr, conn);

                    }

                    // Добавление рабочего
                    else if (newPerson.GetType().Name == "Worker") {

                        Worker worker = newPerson as Worker;

                        // Добавляем читателя
                        //string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES(NULL, {userid}, '{schoolBoy.firstName}', '{schoolBoy.lastName}', '{schoolBoy.middleName}', { SchoolBoy.personType})";
                        string command_people = $"INSERT INTO Peoples (people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES({userid}, '{worker.firstName}', '{worker.lastName}', '{worker.middleName}', {Worker.personType})";
                        ExecuteSQL(command_people, conn);


                        // Берем id из новой созданной строки в таблице Peoples
                        string commandPeople = $"SELECT * FROM Peoples where people_user_id = {userid}";
                        int peopleid = GetNewRowID(commandPeople, conn);


                        // Создаем строчку в строки в таблице PeopleAttributer
                        //string command_attr = $"INSERT INTO PeopleAttributes (pa_id, pa_people_id, pa_institution, pa_group, pa_subject, pa_faculty, pa_orgname, pa_direction, pa_post, pa_workname) VALUES(NULL, {peopleid}, NULL, NULL, NULL, NULL, '{worker.orgName}', NULL, '{worker.post}', NULL)";
                        string command_attr = $"INSERT INTO PeopleAttributes (pa_people_id, pa_orgname, pa_post) VALUES({peopleid}, '{worker.orgName}', '{worker.post}')";
                        ExecuteSQL(command_attr, conn);

                    }

                    // Добавление другого типа
                    else if (newPerson.GetType().Name == "Other") {

                        Other other = newPerson as Other;

                        // Добавляем читателя
                        //string command_people = $"INSERT INTO Peoples (people_id, people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES(NULL, {userid}, '{schoolBoy.firstName}', '{schoolBoy.lastName}', '{schoolBoy.middleName}', { SchoolBoy.personType})";
                        string command_people = $"INSERT INTO Peoples (people_user_id, people_first_name, people_last_name, people_middle_name, people_type) VALUES({userid}, '{other.firstName}', '{other.lastName}', '{other.middleName}', {Other.personType})";
                        ExecuteSQL(command_people, conn);


                        // Берем id из новой созданной строки в таблице Peoples
                        string commandPeople = $"SELECT * FROM Peoples where people_user_id = {userid}";
                        int peopleid = GetNewRowID(commandPeople, conn);


                        // Создаем строчку в строки в таблице PeopleAttributer
                        //string command_attr = $"INSERT INTO PeopleAttributes (pa_id, pa_people_id, pa_institution, pa_group, pa_subject, pa_faculty, pa_orgname, pa_direction, pa_post, pa_workname) VALUES(NULL, {peopleid}, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '{other.typeWork}')";
                        string command_attr = $"INSERT INTO PeopleAttributes (pa_people_id, pa_workname) VALUES({peopleid}, '{other.typeWork}')";
                        ExecuteSQL(command_attr, conn);

                    }

                }
            }

        }



        /// <summary>
        /// Возвращает список данных библиотек (id и название)
        /// </summary>
        /// <returns>Список данных библиотек (id и название)</returns>
        public static List<Library> getLibrariesNameList() {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                var librariesTable = getTable("SELECT * FROM LibLibraries", conn);
                List<Library> libList = new List<Library>();


                foreach(var item in librariesTable) {

                    Library library = new Library((int)item[0],
                                                  item[1].ToString());

                    libList.Add(library);

                }

                return libList;

            }

        }



        /// <summary>
        /// Получает список данных комнат определенной библиотеки (id и название)
        /// </summary>
        /// <param name="librID">ID библиотеки</param>
        /// <returns>список данных комнат определенной библиотеки (id и название)</returns>
        public static List<Room> getRoomsList(int librID) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = $"SELECT * FROM LibRooms WHERE room_lib_id = {librID}";
                var roomsTable = getTable(command, conn);
                List<Room> roomList = new List<Room>();


                foreach (var item in roomsTable) {

                    Room room = new Room((int)item[0],
                                         (int)item[1],
                                         (int)item[2]);

                    roomList.Add(room);

                }

                return roomList;

            }


        }



        public static void getShevilingsList() {

        }



        public static void getShelvesList() {

        }



        /// <summary>
        /// Возвращает таблицу запроса
        /// </summary>
        /// <param name="command">запрос SQL с результатом</param>
        /// <param name="conn">коннектор к БД</param>
        /// <returns>Итоговую таблицу запроса</returns>
        private static DataRow[] getTable(string command, MySqlConnection conn) {

            DataSet dataSet = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
            adapter.Fill(dataSet);
            var table = dataSet.Tables[0].Select();
            return table;

        }

        /// <summary>
        /// Возвращает ID только что созданной строки в таблице
        /// </summary>
        /// <param name="command">запрос SQL</param>
        /// <param name="conn">коннектор к БД</param>
        /// <returns>ID созданной строки в таблице</returns>
        private static int GetNewRowID(string command, MySqlConnection conn) {

            MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return (int)dataSet.Tables[0].Select()[0][0];

        }



        /// <summary>
        /// Выполняет запрос SQL без вывода
        /// </summary>
        /// <param name="command">запрос SQL без вывода</param>
        /// <param name="conn">коннектор к БД</param>
        private static void ExecuteSQL(string command, MySqlConnection conn) {

            MySqlCommand myCommandAttr = new MySqlCommand(command, conn);
            myCommandAttr.ExecuteNonQuery();

        }



        /// <summary>
        /// Функция, которая определяет оригинальность логина (логин не должен совпадать с другими логинами в БД)
        /// </summary>
        /// <param name="login">Логин нового аккаунта</param>
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
