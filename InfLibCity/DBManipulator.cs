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
                    if ((int)row[3] == 2)
                        DSusers.Add(new user((int)row[0],
                                         row[1].ToString(),
                                         row[2].ToString(),
                                         (int)row[3]));
                    else
                        DSusers.Add(new user((int)row[0],
                                         row[1].ToString(),
                                         row[2].ToString(),
                                         (int)row[3],
                                         row[4].ToString(),
                                         row[5].ToString(),
                                         (int)row[6]));
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
                                                        stroka[4].ToString(),
                                                        (int)stroka[5]);

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

        public static void addSubscription(Subscription subscription)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString)) {


                conn.Open();
                string command = "INSERT INTO Subscriptions (sub_people_id, sub_sbj_id, sub_start, sub_finish, sub_active) " +
                                 $"VALUES((SELECT people_id FROM Peoples WHERE people_user_id = {subscription.userId}), " +
                                        $"{subscription.subjectId}, " +
                                        $"'{subscription.startDate}', " +
                                        $"'{subscription.finishDate}', " +
                                        $"'Y')";

                ExecuteSQL(command, conn);
            }

        }

        public static void updateSubscription(Subscription subscription) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {


                conn.Open();
                string command = "UPDATE Subscriptions (sub_people_id, sub_sbj_id, sub_start, sub_finish, sub_active) " +
                                 $"VALUES((SELECT people_id FROM Peoples WHERE people_user_id = {subscription}), " +
                                        $"{subscription.subjectId}, " +
                                        $"{subscription.startDate}," +
                                        $"{subscription.finishDate}," +
                                        $"'Y')";

                ExecuteSQL(command, conn);
            }

        }



        /// <summary>
        /// Обновляет информация пользователя
        /// </summary>
        /// <param name="updPerson">Информация конкретного человека</param>
        /// <param name="updUser">Общая информация пользователя</param>
        public static void updateUser(Person updPerson, user updUser) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                conn.Open();
                string command_user = $"UPDATE Users " +
                                      $"SET user_login = '{updUser.login}', " +
                                      $"user_pass = '{updUser.pass}', " +
                                      $"user_phone = '{updUser.phone}', " +
                                      $"user_email = '{updUser.email}'," +
                                      $"user_lib_id = {updUser.libraryID} " +
                                      $"WHERE user_id = {updUser.id}";
                ExecuteSQL(command_user, conn);


                if (updUser.type == 0) {



                }
                else if (updUser.type == 1) {


                    if (updPerson.GetType().Name == "SchoolBoy") {
                        SchoolBoy schoolBoy = updPerson as SchoolBoy;

                        // Обновляем читателя
                        string command_people = $"UPDATE Peoples " +
                                                $"SET people_first_name = '{schoolBoy.firstName}', " +
                                                $"people_last_name = '{schoolBoy.lastName}', " +
                                                $"people_middle_name = '{schoolBoy.middleName}', " +
                                                $"`people_type` = {SchoolBoy.personType} " +
                                                $"WHERE people_user_id = {updUser.id}";
                        ExecuteSQL(command_people, conn);


                        // Берем id из редактируемой строки в таблице Peoples
                        string commandPeople = $"SELECT * FROM Peoples where people_user_id = {updUser.id}";
                        int peopleID = GetNewRowID(commandPeople, conn);


                        // Создаем строчку в строки в таблице PeopleAttributer
                        string command_attr = $"UPDATE PeopleAttributes " +
                                              $"SET pa_institution = '{schoolBoy.institution}', " +
                                              $"pa_group = '{schoolBoy.group}', " +
                                              $"pa_subject = NULL, " +
                                              $"pa_faculty = NULL, " +
                                              $"pa_orgname = NULL, " +
                                              $"pa_direction = NULL, " +
                                              $"pa_post = NULL, " +
                                              $"pa_workname = NULL " +
                                              $"WHERE pa_people_id = {peopleID}";
                        ExecuteSQL(command_attr, conn);
                    }


                    else if (updPerson.GetType().Name == "Student") {
                        Student student = updPerson as Student;

                        // Обновляем читателя
                        string command_people = $"UPDATE Peoples " +
                                                $"SET people_first_name = '{student.firstName}', " +
                                                $"people_last_name = '{student.lastName}', " +
                                                $"people_middle_name = '{student.middleName}', " +
                                                $"`people_type` = {Student.personType} " +
                                                $"WHERE people_user_id = {updUser.id}";
                        ExecuteSQL(command_people, conn);


                        // Берем id из редактируемой строки в таблице Peoples
                        string commandPeople = $"SELECT * FROM Peoples where people_user_id = {updUser.id}";
                        int peopleID = GetNewRowID(commandPeople, conn);


                        // Создаем строчку в строки в таблице PeopleAttributer
                        string command_attr = $"UPDATE PeopleAttributes " +
                                              $"SET pa_institution = '{student.institution}', " +
                                              $"pa_group = '{student.group}', " +
                                              $"pa_subject = NULL, " +
                                              $"pa_faculty = '{student.faculty}', " +
                                              $"pa_orgname = NULL, " +
                                              $"pa_direction = NULL, " +
                                              $"pa_post = NULL, " +
                                              $"pa_workname = NULL " +
                                              $"WHERE pa_people_id = {peopleID}";
                        ExecuteSQL(command_attr, conn);
                    }


                    else if (updPerson.GetType().Name == "Teacher") {
                        Teacher teacher = updPerson as Teacher;

                        // Обновляем читателя
                        string command_people = $"UPDATE Peoples " +
                                                $"SET people_first_name = '{teacher.firstName}', " +
                                                $"people_last_name = '{teacher.lastName}', " +
                                                $"people_middle_name = '{teacher.middleName}', " +
                                                $"`people_type` = {Teacher.personType} " +
                                                $"WHERE people_user_id = {updUser.id}";
                        ExecuteSQL(command_people, conn);


                        // Берем id из редактируемой строки в таблице Peoples
                        string commandPeople = $"SELECT * FROM Peoples where people_user_id = {updUser.id}";
                        int peopleID = GetNewRowID(commandPeople, conn);


                        // Создаем строчку в строки в таблице PeopleAttributer
                        string command_attr = $"UPDATE PeopleAttributes " +
                                              $"SET pa_institution = '{teacher.orgName}', " +
                                              $"pa_group = NULL, " +
                                              $"pa_subject = '{teacher.subject}', " +
                                              $"pa_faculty = NULL, " +
                                              $"pa_orgname = NULL, " +
                                              $"pa_direction = NULL, " +
                                              $"pa_post = NULL, " +
                                              $"pa_workname = NULL " +
                                              $"WHERE pa_people_id = {peopleID}";
                        ExecuteSQL(command_attr, conn);
                    }


                    else if (updPerson.GetType().Name == "Scientist") {
                        Scientist scientist = updPerson as Scientist;

                        // Обновляем читателя
                        string command_people = $"UPDATE Peoples " +
                                                $"SET people_first_name = '{scientist.firstName}', " +
                                                $"people_last_name = '{scientist.lastName}', " +
                                                $"people_middle_name = '{scientist.middleName}', " +
                                                $"`people_type` = {Scientist.personType} " +
                                                $"WHERE people_user_id = {updUser.id}";
                        ExecuteSQL(command_people, conn);


                        // Берем id из редактируемой строки в таблице Peoples
                        string commandPeople = $"SELECT * FROM Peoples where people_user_id = {updUser.id}";
                        int peopleID = GetNewRowID(commandPeople, conn);


                        // Создаем строчку в строки в таблице PeopleAttributer
                        string command_attr = $"UPDATE PeopleAttributes " +
                                              $"SET pa_institution = NULL, " +
                                              $"pa_group = NULL, " +
                                              $"pa_subject = NULL, " +
                                              $"pa_faculty = NULL, " +
                                              $"pa_orgname = '{scientist.orgName}', " +
                                              $"pa_direction = '{scientist.direction}', " +
                                              $"pa_post = NULL, " +
                                              $"pa_workname = NULL " +
                                              $"WHERE pa_people_id = {peopleID}";
                        ExecuteSQL(command_attr, conn);
                    }


                    else if (updPerson.GetType().Name == "Worker") {
                        Worker worker = updPerson as Worker;

                        // Обновляем читателя
                        string command_people = $"UPDATE Peoples " +
                                                $"SET people_first_name = '{worker.firstName}', " +
                                                $"people_last_name = '{worker.lastName}', " +
                                                $"people_middle_name = '{worker.middleName}', " +
                                                $"`people_type` = {Worker.personType} " +
                                                $"WHERE people_user_id = {updUser.id}";
                        ExecuteSQL(command_people, conn);


                        // Берем id из редактируемой строки в таблице Peoples
                        string commandPeople = $"SELECT * FROM Peoples where people_user_id = {updUser.id}";
                        int peopleID = GetNewRowID(commandPeople, conn);


                        // Создаем строчку в строки в таблице PeopleAttributer
                        string command_attr = $"UPDATE PeopleAttributes " +
                                              $"SET pa_institution = NULL, " +
                                              $"pa_group = NULL, " +
                                              $"pa_subject = NULL, " +
                                              $"pa_faculty = NULL, " +
                                              $"pa_orgname = '{worker.orgName}', " +
                                              $"pa_direction = NULL, " +
                                              $"pa_post = '{worker.post}', " +
                                              $"pa_workname = NULL " +
                                              $"WHERE pa_people_id = {peopleID}";
                        ExecuteSQL(command_attr, conn);
                    }


                    else if (updPerson.GetType().Name == "Other") {
                        Other other = updPerson as Other;

                        // Обновляем читателя
                        string command_people = $"UPDATE Peoples " +
                                                $"SET people_first_name = '{other.firstName}', " +
                                                $"people_last_name = '{other.lastName}', " +
                                                $"people_middle_name = '{other.middleName}', " +
                                                $"`people_type` = {Other.personType} " +
                                                $"WHERE people_user_id = {updUser.id}";
                        ExecuteSQL(command_people, conn);


                        // Берем id из редактируемой строки в таблице Peoples
                        string commandPeople = $"SELECT * FROM Peoples where people_user_id = {updUser.id}";
                        int peopleID = GetNewRowID(commandPeople, conn);


                        // Создаем строчку в строки в таблице PeopleAttributer
                        string command_attr = $"UPDATE PeopleAttributes " +
                                              $"SET pa_institution = NULL, " +
                                              $"pa_group = NULL, " +
                                              $"pa_subject = NULL, " +
                                              $"pa_faculty = NULL, " +
                                              $"pa_orgname = NULL, " +
                                              $"pa_direction = NULL, " +
                                              $"pa_post = NULL, " +
                                              $"pa_workname = '{other.typeWork}' " +
                                              $"WHERE pa_people_id = {peopleID}";
                        ExecuteSQL(command_attr, conn);
                    }
                }
            }
        }



        public static void addSubject(Subject subject) {


            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string readOnly = "N";
                if (subject.isReadOnly)
                    readOnly = "Y";

                conn.Open();

                
                string command_sbj_lastid = "SELECT MAX(sbj_id) FROM Subject";
                MySqlCommand sqlcom = new MySqlCommand(command_sbj_lastid, conn);
                int sbj_id = (int)sqlcom.ExecuteScalar() + 1;

                string command_sbj = "INSERT INTO Subject (sbj_id, " +
                                                          "sbj_shelv_id, " +
                                                          "sbj_pub_id, " +
                                                          "sbj_name, " +
                                                          "sbj_date, " +
                                                          "sbj_isReadOnly, " +
                                                          "sbj_quantity, " +
                                                          "sbj_type, " +
                                                          "sbj_wo, " +
                                                          "sbj_wo_date)" +
                                      $"VALUES({sbj_id}, " +
                                             $"{subject.shelf_id}, " +
                                             $"{subject.publisher_id}, " +
                                             $"'{subject.name}', " +
                                             $"{subject.year}, " +
                                             $"'{readOnly}', " +
                                             $"{subject.quantity}, " +
                                             $"{subject.type}, " +
                                             $"'N', " +
                                             $"'{subject.yearWriteOff}')";

                if (subject.publisher_id == -1) {

                    if (subject.shelf_id == -1) {
                        command_sbj = "INSERT INTO Subject (sbj_id, " +
                                                          "sbj_shelv_id, " +
                                                          "sbj_pub_id, " +
                                                          "sbj_name, " +
                                                          "sbj_date, " +
                                                          "sbj_isReadOnly, " +
                                                          "sbj_quantity, " +
                                                          "sbj_type, " +
                                                          "sbj_wo, " +
                                                          "sbj_wo_date)" +
                                      $"VALUES({sbj_id}, " +
                                             $"NULL, " +
                                             $"NULL, " +
                                             $"'{subject.name}', " +
                                             $"{subject.year}, " +
                                             $"'{readOnly}', " +
                                             $"{subject.quantity}, " +
                                             $"{subject.type}, " +
                                             $"'N', " +
                                             $"'{subject.yearWriteOff}')";
                    }
                       
                    else {
                        command_sbj = "INSERT INTO Subject (sbj_id, " +
                                                          "sbj_shelv_id, " +
                                                          "sbj_pub_id, " +
                                                          "sbj_name, " +
                                                          "sbj_date, " +
                                                          "sbj_isReadOnly, " +
                                                          "sbj_quantity, " +
                                                          "sbj_type, " +
                                                          "sbj_wo, " +
                                                          "sbj_wo_date)" +
                                      $"VALUES({sbj_id}, " +
                                             $"{subject.shelf_id}, " +
                                             $"NULL, " +
                                             $"'{subject.name}', " +
                                             $"{subject.year}, " +
                                             $"'{readOnly}', " +
                                             $"{subject.quantity}, " +
                                             $"{subject.type}, " +
                                             $"'N', " +
                                             $"'{subject.yearWriteOff}')";
                    }     
                }

                
                ExecuteSQL(command_sbj, conn);



                if (subject.type == 0) {

                    string command_sa_lastid = "SELECT MAX(sa_id) FROM SubjectAttributes";
                    MySqlCommand sqlcom1 = new MySqlCommand(command_sa_lastid, conn);
                    int sa_id = (int)sqlcom1.ExecuteScalar() + 1;

                    string command_sa = $"INSERT INTO SubjectAttributes (sa_id, sa_sbj_id) VALUES({sa_id}, {sbj_id})";
                    ExecuteSQL(command_sa, conn);


                    foreach (var item in subject.attributes.author_id) {

                        string command_m2m_auth = $"INSERT INTO m2m_sbjattr_authors (sa_id, a_id) VALUES({sa_id}, {item})";
                        ExecuteSQL(command_m2m_auth, conn);

                    }

                    foreach (var item in subject.attributes.genre_id) {

                        string command_m2m_auth = $"INSERT INTO m2m_sbjattr_bookgenres (sa_id, bg_id) VALUES({sa_id}, {item})";
                        ExecuteSQL(command_m2m_auth, conn);

                    }


                }


                else if (subject.type == 1) {


                    string command_sa_lastid = "SELECT MAX(sa_id) FROM SubjectAttributes";
                    MySqlCommand sqlcom1 = new MySqlCommand(command_sa_lastid, conn);
                    int sa_id = (int)sqlcom1.ExecuteScalar() + 1;


                    string command_sa = $"INSERT INTO SubjectAttributes (sa_id, sa_sbj_id) VALUES({sa_id}, {sbj_id})";
                    ExecuteSQL(command_sa, conn);


                    foreach (var item in subject.attributes.author_id) {

                        string command_m2m_auth = $"INSERT INTO m2m_sbjattr_authors (sa_id, a_id) VALUES({sa_id}, {item})";
                        ExecuteSQL(command_m2m_auth, conn);

                    }

                    foreach (var item in subject.attributes.genre_id) {

                        string command_m2m_auth = $"INSERT INTO m2m_sbjattr_poemgenres (sa_id, pg_id) VALUES({sa_id}, {item})";
                        ExecuteSQL(command_m2m_auth, conn);

                    }

                }


                else if (subject.type == 2 || subject.type == 3) {

                    string command_sa_lastid = "SELECT MAX(sa_id) FROM SubjectAttributes";
                    MySqlCommand sqlcom1 = new MySqlCommand(command_sa_lastid, conn);
                    int sa_id = (int)sqlcom1.ExecuteScalar() + 1;

                    string command_sa = $"INSERT INTO SubjectAttributes (sa_id, sa_sbj_id, sa_mnt_id) VALUES({sa_id}, {sbj_id}, {subject.attributes.type_id})";
                    if (subject.attributes.type_id == -1)
                        command_sa = $"INSERT INTO SubjectAttributes (sa_id, sa_sbj_id, sa_mnt_id) VALUES({sa_id}, {sbj_id}, NULL)";

                    ExecuteSQL(command_sa, conn);

                }


                else if (subject.type == 4 || subject.type == 5 || subject.type == 6) {

                    string command_sa_lastid = "SELECT MAX(sa_id) FROM SubjectAttributes";
                    MySqlCommand sqlcom1 = new MySqlCommand(command_sa_lastid, conn);
                    int sa_id = (int)sqlcom1.ExecuteScalar() + 1;

                    string command_sa = $"INSERT INTO SubjectAttributes (sa_id, sa_sbj_id, sa_d_id) VALUES({sa_id}, {sbj_id}, {subject.attributes.discipline_id})";

                    if (subject.attributes.discipline_id == -1)
                        command_sa = $"INSERT INTO SubjectAttributes (sa_id, sa_sbj_id, sa_d_id) VALUES({sa_id}, {sbj_id}, NULL)";
                    ExecuteSQL(command_sa, conn);

                }


                else if (subject.type == 7) {

                    string command_sa_lastid = "SELECT MAX(sa_id) FROM SubjectAttributes";
                    MySqlCommand sqlcom1 = new MySqlCommand(command_sa_lastid, conn);
                    int sa_id = (int)sqlcom1.ExecuteScalar() + 1;

                    string command_sa = $"INSERT INTO SubjectAttributes (sa_id, sa_sbj_id, sa_art_id) VALUES({sa_id}, {sbj_id}, {subject.attributes.type_id})";
                    if (subject.attributes.type_id == -1)
                        command_sa = $"INSERT INTO SubjectAttributes (sa_id, sa_sbj_id, sa_art_id) VALUES({sa_id}, {sbj_id}, NULL)";

                    ExecuteSQL(command_sa, conn);

                }


                else if (subject.type == 8) {

                    string command_sa_lastid = "SELECT MAX(sa_id) FROM SubjectAttributes";
                    MySqlCommand sqlcom1 = new MySqlCommand(command_sa_lastid, conn);
                    int sa_id = (int)sqlcom1.ExecuteScalar() + 1;

                    string command_sa = $"INSERT INTO SubjectAttributes (sa_id, sa_sbj_id, sa_d_id, sa_dt_id) VALUES({sa_id}, {sbj_id}, {subject.attributes.discipline_id}, {subject.attributes.type_id})";

                    if (subject.attributes.discipline_id == -1) {
                        if (subject.attributes.type_id == -1) {
                            command_sa = $"INSERT INTO SubjectAttributes (sa_id, sa_sbj_id, sa_d_id, sa_dt_id) VALUES({sa_id}, {sbj_id}, NULL, NULL)";
                        }
                        else {
                            command_sa = $"INSERT INTO SubjectAttributes (sa_id, sa_sbj_id, sa_d_id, sa_dt_id) VALUES({sa_id}, {sbj_id}, {subject.attributes.discipline_id}, NULL)";
                        }
                    }

                    
                    ExecuteSQL(command_sa, conn);

                }


                else if (subject.type == 9) {

                    string command_sa_lastid = "SELECT MAX(sa_id) FROM SubjectAttributes";
                    MySqlCommand sqlcom1 = new MySqlCommand(command_sa_lastid, conn);
                    int sa_id = (int)sqlcom1.ExecuteScalar() + 1;


                    string command_sa = $"INSERT INTO SubjectAttributes (sa_id, sa_sbj_id, sa_d_id) VALUES({sa_id}, {sbj_id}, {subject.attributes.discipline_id})";
                    if (subject.attributes.discipline_id == -1)
                        command_sa = $"INSERT INTO SubjectAttributes (sa_id, sa_sbj_id, sa_d_id) VALUES({sa_id}, {sbj_id}, NULL)";

                    ExecuteSQL(command_sa, conn);


                    foreach (var item in subject.attributes.author_id) {

                        string command_m2m_auth = $"INSERT INTO m2m_sbjattr_authors (sa_id, a_id) VALUES({sa_id}, {item})";
                        ExecuteSQL(command_m2m_auth, conn);

                    }
                }


                conn.Close();

            }
        }


        public static void updateSubject(Subject subject) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {


                string readOnly = "N";
                if (subject.isReadOnly)
                    readOnly = "Y";

                string writeOff = "N";
                if (subject.isWriteOff)
                    writeOff = "Y";


                conn.Open();


                string command_sbj = "UPDATE Subject " +
                                     $"SET sbj_shelv_id = {subject.shelf_id}, " +
                                     $"sbj_pub_id = {subject.publisher_id}, " +
                                     $"sbj_name = '{subject.name}', " +
                                     $"sbj_date = {subject.year}, " +
                                     $"sbj_isReadOnly = '{readOnly}'," +
                                     $"sbj_quantity = {subject.quantity}, " +
                                     $"sbj_type = {subject.type}, " +
                                     $"sbj_wo = '{writeOff}', " +
                                     $"sbj_wo_date = '{subject.yearWriteOff}' " +
                                     $"WHERE sbj_id = {subject.id}";

                if(subject.publisher_id == -1 || subject.shelf_id == -1) {
                    if(subject.shelf_id == -1) {
                        command_sbj = "UPDATE Subject " +
                                     $"SET sbj_shelv_id = NULL, " +
                                     $"sbj_pub_id = NULL, " +
                                     $"sbj_name = '{subject.name}', " +
                                     $"sbj_date = {subject.year}, " +
                                     $"sbj_isReadOnly = '{readOnly}'," +
                                     $"sbj_quantity = {subject.quantity}, " +
                                     $"sbj_type = {subject.type}, " +
                                     $"sbj_wo = '{writeOff}', " +
                                     $"sbj_wo_date = '{subject.yearWriteOff}' " +
                                     $"WHERE sbj_id = {subject.id}";
                    }
                    else {
                        command_sbj = "UPDATE Subject " +
                                     $"SET sbj_shelv_id = {subject.shelf_id}, " +
                                     $"sbj_pub_id = NULL, " +
                                     $"sbj_name = '{subject.name}', " +
                                     $"sbj_date = {subject.year}, " +
                                     $"sbj_isReadOnly = '{readOnly}'," +
                                     $"sbj_quantity = {subject.quantity}, " +
                                     $"sbj_type = {subject.type}, " +
                                     $"sbj_wo = '{writeOff}', " +
                                     $"sbj_wo_date = '{subject.yearWriteOff}' " +
                                     $"WHERE sbj_id = {subject.id}";
                    }
                }

                ExecuteSQL(command_sbj, conn);


                if (subject.type == 0) {

                    string command_sa_lastid = $"SELECT sa_id FROM SubjectAttributes WHERE sa_sbj_id = {subject.id}";
                    MySqlCommand sqlcom = new MySqlCommand(command_sa_lastid, conn);
                    int sa_id = (int)sqlcom.ExecuteScalar();

                    // Удаление старых связок с авторами
                    string command_del1 = $"DELETE FROM m2m_sbjattr_authors WHERE sa_id = {sa_id}";
                    ExecuteSQL(command_del1, conn);

                    // Удаление старых связок с жанрами книг
                    string command_del2 = $"DELETE FROM m2m_sbjattr_bookgenres WHERE sa_id = {sa_id}";
                    ExecuteSQL(command_del2, conn);


                    foreach (var item in subject.attributes.author_id) {

                        string command_m2m_auth = $"INSERT INTO m2m_sbjattr_authors (sa_id, a_id) VALUES({sa_id}, {item})";
                        ExecuteSQL(command_m2m_auth, conn);

                    }

                    foreach (var item in subject.attributes.genre_id) {

                        string command_m2m_auth = $"INSERT INTO m2m_sbjattr_bookgenres (sa_id, bg_id) VALUES({sa_id}, {item})";
                        ExecuteSQL(command_m2m_auth, conn);

                    }

                }


                else if (subject.type == 1) {

                    string command_sa_lastid = $"SELECT sa_id FROM SubjectAttributes WHERE sa_sbj_id = {subject.id}";
                    MySqlCommand sqlcom = new MySqlCommand(command_sa_lastid, conn);
                    int sa_id = (int)sqlcom.ExecuteScalar();


                    // Удаление старых связок m2m
                    string command_del = $"DELETE FROM m2m_sbjattr_authors WHERE sa_id = {sa_id}";
                    ExecuteSQL(command_del, conn);

                    // Удаление старых связок с жанрами книг
                    string command_del2 = $"DELETE FROM m2m_sbjattr_poemgenres WHERE sa_id = {sa_id}";
                    ExecuteSQL(command_del2, conn);


                    foreach (var item in subject.attributes.author_id) {

                        string command_m2m_auth = $"INSERT INTO m2m_sbjattr_authors (sa_id, a_id) VALUES({sa_id}, {item})";
                        ExecuteSQL(command_m2m_auth, conn);

                    }

                    foreach (var item in subject.attributes.genre_id) {

                        string command_m2m_auth = $"INSERT INTO m2m_sbjattr_poemgenres (sa_id, pg_id) VALUES({sa_id}, {item})";
                        ExecuteSQL(command_m2m_auth, conn);

                    }

                }


                else if (subject.type == 2 || subject.type == 3) {

                    string command_sa = $"UPDATE SubjectAttributes " +
                                        $"SET sa_mnt_id = {subject.attributes.type_id}, " +
                                        $"sa_d_id = NULL, " +
                                        $"sa_art_id = NULL, " +
                                        $"sa_dt_id = NULL " +
                                        $"WHERE sa_sbj_id = {subject.id}";

                    if (subject.attributes.type_id == -1)
                        command_sa = $"UPDATE SubjectAttributes " +
                                     $"SET sa_mnt_id = NULL, " +
                                     $"sa_d_id = NULL, " +
                                     $"sa_art_id = NULL, " +
                                     $"ss_dt_id = NULL " +
                                     $"WHERE sa_sbj_id = {subject.id}";

                    ExecuteSQL(command_sa, conn);

                    
                }


                else if (subject.type == 4 || subject.type == 5 || subject.type == 6) {

                    string command_sa = $"UPDATE SubjectAttributes " +
                                        $"SET sa_mnt_id = NULL, " +
                                        $"sa_d_id = {subject.attributes.type_id}, " +
                                        $"sa_art_id = NULL, " +
                                        $"sa_dt_id = NULL " +
                                        $"WHERE sa_sbj_id = {subject.id}";

                    if (subject.attributes.type_id == -1)
                        command_sa = $"UPDATE SubjectAttributes " +
                                     $"SET sa_mnt_id = NULL, " +
                                     $"sa_d_id = NULL, " +
                                     $"sa_art_id = NULL, " +
                                     $"sa_dt_id = NULL " +
                                     $"WHERE sa_sbj_id = {subject.id}";

                    ExecuteSQL(command_sa, conn);

                }


                else if (subject.type == 7) {

                    string command_sa = $"UPDATE SubjectAttributes " +
                                        $"SET sa_mnt_id = NULL, " +
                                        $"sa_d_id = NULL, " +
                                        $"sa_art_id = {subject.attributes.type_id}, " +
                                        $"sa_dt_id = NULL " +
                                        $"WHERE sa_sbj_id = {subject.id}";

                    if (subject.attributes.type_id == -1)
                        command_sa = $"UPDATE SubjectAttributes " +
                                     $"SET sa_mnt_id = NULL, " +
                                     $"sa_d_id = NULL, " +
                                     $"sa_art_id = NULL, " +
                                     $"sa_dt_id = NULL " +
                                     $"WHERE sa_sbj_id = {subject.id}";

                    ExecuteSQL(command_sa, conn);

                }


                else if (subject.type == 8) {

                    string command_sa = $"UPDATE SubjectAttributes " +
                                        $"SET sa_mnt_id = NULL, " +
                                        $"sa_art_id = NULL, " +
                                        $"sa_dt_id = {subject.attributes.type_id}, " +
                                        $"sa_d_id = {subject.attributes.discipline_id} " +
                                        $"WHERE sa_sbj_id = {subject.id}";


                    

                    if (subject.attributes.type_id == -1 || subject.attributes.discipline_id == -1) {
                        if (subject.attributes.discipline_id == -1) {
                            command_sa = $"UPDATE SubjectAttributes " +
                                        $"SET sa_dt_id = NULL, " +
                                        $"sa_d_id = NULL, " +
                                        $"sa_mnt_id = NULL, " +
                                        $"sa_art_id = NULL " +
                                        $"WHERE sa_sbj_id = {subject.id}";
                        }
                        else {
                            command_sa = $"UPDATE SubjectAttributes " +
                                        $"SET sa_dt_id = NULL, " +
                                        $"sa_d_id = {subject.attributes.discipline_id}, " +
                                        $"sa_mnt_id = NULL, " +
                                        $"sa_art_id = NULL " +
                                        $"WHERE sa_sbj_id = {subject.id}";
                        }
                    }

                    ExecuteSQL(command_sa, conn);

                }


                else if (subject.type == 9) {
                    string command_sa_lastid = $"SELECT sa_id FROM SubjectAttributes WHERE sa_sbj_id = {subject.id}";
                    MySqlCommand sqlcom = new MySqlCommand(command_sa_lastid, conn);
                    int sa_id = (int)sqlcom.ExecuteScalar();

                    string command_sa = $"UPDATE SubjectAttributes " +
                                        $"SET sa_d_id = {subject.attributes.discipline_id}, " +
                                        $"sa_mnt_id = NULL, " +
                                        $"sa_art_id = NULL, " +
                                        $"sa_dt_id = NULL " +
                                        $"WHERE sa_sbj_id = {subject.id}";

                    if (subject.attributes.discipline_id == -1) {
                        command_sa = $"UPDATE SubjectAttributes " +
                                     $"SET sa_d_id = {subject.attributes.discipline_id}, " +
                                     $"sa_mnt_id = NULL, " +
                                     $"sa_art_id = NULL, " +
                                     $"sa_dt_id = NULL " +
                                     $"WHERE sa_sbj_id = {subject.id}";
                    }

                    ExecuteSQL(command_sa, conn);


                    // Удаление старых связок m2m
                    string command_del = $"DELETE FROM m2m_sbjattr_authors WHERE sa_id = {sa_id}";
                    ExecuteSQL(command_del, conn);


                    foreach (var item in subject.attributes.author_id) {

                        string command_m2m_auth = $"INSERT INTO m2m_sbjattr_authors (sa_id, a_id) VALUES({sa_id}, {item})";
                        ExecuteSQL(command_m2m_auth, conn);

                    }
                }


                conn.Close();

            }

        }


        public static void deleteSubject(int id) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                conn.Open();
                string command = $"DELETE FROM Subject WHERE sbj_id = {id} ";
                ExecuteSQL(command, conn);

                conn.Close();
            }

        }


        public static void writeoffSubject(int id, bool type) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string writeOff = "N";
                if (type)
                    writeOff = "Y";

                conn.Open();

                string command_sa = $"UPDATE Subject " +
                                    $"SET sbj_wo = {writeOff} " +
                                    $"WHERE sbj_id = {id}";


                ExecuteSQL(command_sa, conn);

                conn.Close();
            }
        }


        public static void deleteUser(int id) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                conn.Open();
                string command = $"DELETE FROM Users WHERE user_id = {id} ";
                ExecuteSQL(command, conn);

                conn.Close();
            }

        }



        public static void addAttribute(string table, string name) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                conn.Open();

                if (table == "Authors") {
                    string command = $"INSERT INTO Authors (a_name) Values('{name}')";
                    ExecuteSQL(command, conn);
                }
                else if (table == "Article") {
                    string command = $"INSERT INTO Article (art_name) Values('{name}')";
                    ExecuteSQL(command, conn);
                }
                else if (table == "BookGenres") {
                    string command = $"INSERT INTO BookGenres (bg_name) Values('{name}')";
                    ExecuteSQL(command, conn);
                }
                else if (table == "PoemGenres") {
                    string command = $"INSERT INTO PoemGenres (pg_name) Values('{name}')";
                    ExecuteSQL(command, conn);
                }
                else if (table == "Publishers") {
                    string command = $"INSERT INTO Publishers (pub_name) Values('{name}')";
                    ExecuteSQL(command, conn);
                }
                else if (table == "MagazineNews") {
                    string command = $"INSERT INTO MagazineNews (mnt_name) Values('{name}')";
                    ExecuteSQL(command, conn);
                }
                else if (table == "Disciplines") {
                    string command = $"INSERT INTO Disciplines (d_name) Values('{name}')";
                    ExecuteSQL(command, conn);
                }
                else if (table == "Dissertation") {
                    string command = $"INSERT INTO Dissertation (dt_name) Values('{name}')";
                    ExecuteSQL(command, conn);
                }
                conn.Close();
            }
        }


        public static void updateAttribute(string table, string name, int id) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                conn.Open();

                if (table == "Authors") {
                    string command = $"UPDATE Authors SET a_name = '{name}' WHERE a_id = {id}";
                    ExecuteSQL(command, conn);
                }
                else if (table == "Article") {
                    string command = $"UPDATE Article SET art_name = '{name}' WHERE art_id = {id})";
                    ExecuteSQL(command, conn);
                }
                else if (table == "BookGenres") {
                    string command = $"UPDATE BookGenres SET bg_name = '{name}' WHERE bg_id = {id})";
                    ExecuteSQL(command, conn);
                }
                else if (table == "PoemGenres") {
                    string command = $"UPDATE PoemGenres SET pg_name = '{name}' WHERE pg_id = {id})";
                    ExecuteSQL(command, conn);
                }
                else if (table == "Publishers") {
                    string command = $"UPDATE Publishers SET pub_name = '{name}' WHERE pub_id = {id})";
                    ExecuteSQL(command, conn);
                }
                else if (table == "MagazineNews") {
                    string command = $"UPDATE MagazineNews SET mnt_name = '{name}' WHERE mnt_id = {id})";
                    ExecuteSQL(command, conn);
                }
                else if (table == "Disciplines") {
                    string command = $"UPDATE Disciplines SET d_name = '{name}' WHERE d_id = {id})";
                    ExecuteSQL(command, conn);
                }
                else if (table == "Dissertation") {
                    string command = $"UPDATE Dissertation SET dt_name = '{name}' WHERE dt_id = {id})";
                    ExecuteSQL(command, conn);
                }
                conn.Close();
            }
        }



        public static Address getFullAddress(int shelvId) {
            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = "SELECT shelv_id, shelv_num, sh_id, sh_num, room_id, room_num, lib_id, lib_name, lib_address FROM LibShelves " +
                             "JOIN LibShevilings ON sh_id = shelv_sh_id " +
                             "JOIN LibRooms ON room_id = sh_room_id " +
                             "JOIN LibLibraries ON lib_id = room_lib_id " +
                             $"WHERE shelv_id = {shelvId}";

                var table = getTable(command, conn)[0];
                

                Shelves shelves = new Shelves((int)table[0], (int)table[2], (int)table[1]);
                Shevilings shevilings = new Shevilings((int)table[2], (int)table[4], (int)table[3]);
                Room room = new Room((int)table[4], (int)table[6], (int)table[5]);
                Library library = new Library((int)table[6], table[7].ToString(), table[8].ToString());
                return new Address(library, room, shevilings, shelves);
            }
        }



        public static void deleteAttribute(string table, int id) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                conn.Open();

                if (table == "Authors") {
                    string command = $"DELETE FROM Authors WHERE a_id = {id}";
                    ExecuteSQL(command, conn);
                }
                else if (table == "Article") {
                    string command = $"DELETE FROM Article WHERE art_id = {id})";
                    ExecuteSQL(command, conn);
                }
                else if (table == "BookGenres") {
                    string command = $"DELETE FROM BookGenres WHERE bg_id = {id})";
                    ExecuteSQL(command, conn);
                }
                else if (table == "PoemGenres") {
                    string command = $"DELETE FROM PoemGenres WHERE pg_id = {id})";
                    ExecuteSQL(command, conn);
                }
                else if (table == "Publishers") {
                    string command = $"DELETE FROM Publishers WHERE pub_id = {id})";
                    ExecuteSQL(command, conn);
                }
                else if (table == "MagazineNews") {
                    string command = $"DELETE FROM MagazineNews WHERE mnt_id = {id})";
                    ExecuteSQL(command, conn);
                }
                else if (table == "Disciplines") {
                    string command = $"DELETE FROM Disciplines WHERE d_id = {id})";
                    ExecuteSQL(command, conn);
                }
                else if (table == "Dissertation") {
                    string command = $"DELETE FROM Dissertation WHERE dt_id = {id})";
                    ExecuteSQL(command, conn);
                }
                conn.Close();
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


        public static List<Shevilings> getShevilingsList(int roomID) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = $"SELECT * FROM LibShevilings WHERE sh_room_id = {roomID}";
                var shilfTable = getTable(command, conn);
                List<Shevilings> shilfList = new List<Shevilings>();


                foreach (var item in shilfTable) {

                    Shevilings sheviling = new Shevilings((int)item[0],
                                         (int)item[1],
                                         (int)item[2]);

                    shilfList.Add(sheviling);

                }
                return shilfList;
            }
        }



        public static List<Shelves> getShelvesList(int shilfID) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = $"SELECT * FROM LibShelves WHERE shelv_sh_id = {shilfID}";
                var shelfTable = getTable(command, conn);
                List<Shelves> shelfList = new List<Shelves>();


                foreach (var item in shelfTable) {

                    Shelves shelve = new Shelves((int)item[0],
                                         (int)item[1],
                                         (int)item[2]);

                    shelfList.Add(shelve);

                }
                return shelfList;
            }
        }



        public static DataSet getSubjectAttributeDict(string nameTable) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = $"SELECT * FROM {nameTable}";

                DataSet dataSet = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                adapter.Fill(dataSet);

                if (nameTable != "BookGenres" && nameTable != "PoemGenres" && nameTable != "Authors") {
                    DataRow newrow = dataSet.Tables[0].NewRow();
                    newrow[0] = -1;
                    newrow[1] = "(Нет)";
                    dataSet.Tables[0].Rows.InsertAt(newrow, 0);
                }

                return dataSet;
            }
        }
        


        public static DataSet getPeopleList(int libId = -1) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = "SELECT user_id, people_first_name as `Имя`, people_last_name as `Фамилия`, people_middle_name as `Отчество`, PEOPLE_TYPE(people_type) as `Тип пользователя`, lib_name as `Библиотека`" +
                                 "FROM Users " +
                                    "JOIN Peoples ON people_user_id = user_id " +
                                    "JOIN LibLibraries ON lib_id = user_lib_id " +
                                 "WHERE user_type = 1";

                if (libId != -1) {
                    command += $" AND user_lib_id = {libId}";
                }
                var peoplesTable = getTable("SELECT * FROM LibLibraries", conn);

                DataSet dataSet = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                adapter.Fill(dataSet);

                return dataSet;

            }

        }


        public static DataSet getAllSubscribtionsList(int libID = -1) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = "SELECT sub_id, " +
                                 "CONCAT(people_first_name, ' ', people_last_name, ' ', people_middle_name) AS `ФИО`, " +
                                 "sbj_name AS `Название работы`, " +
                                 "sub_start AS `Начало выдачи`, " +
                                 "sub_finish AS `Конец выдачи`, " +
                                 "if (sub_active = 'Y', 'Активно', 'Не активно') AS `Статус`, " +
                                 "READ_ONLY_TEXT(sbj_wo) AS `Тип выдачи`, " +
                                 "lib_name AS 'Библиотека' " +
                                 "FROM Subscriptions " +
                                 "LEFT JOIN Peoples ON people_id = sub_people_id " +
                                 "LEFT JOIN Subject ON sbj_id = sub_sbj_id " +
                                 "LEFT JOIN Users ON user_id = people_user_id " +
                                 "LEFT JOIN LibLibraries ON lib_id = user_lib_id ";
                if (libID != -1)
                    command += $"WHERE user_lib_id = {libID}";

                DataSet dataSet = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                adapter.Fill(dataSet);

                return dataSet;
            }
        }


        public static DataSet getActiveSubscribtionsList(int libID = -1) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = "SELECT sub_id, " +
                                 "CONCAT(people_first_name, ' ', people_last_name, ' ', people_middle_name) AS `ФИО`, " +
                                 "sbj_name AS `Название работы`, " +
                                 "sub_start AS `Начало выдачи`, " +
                                 "sub_finish AS `Конец выдачи`, " +
                                 "if (sub_active = 'Y', 'Активно', 'Не активно') AS `Статус`, " +
                                 "READ_ONLY_TEXT(sbj_wo) AS `Тип выдачи`, " +
                                 "lib_name AS 'Библиотека' " +
                                 "FROM Subscriptions " +
                                 "LEFT JOIN Peoples ON people_id = sub_people_id " +
                                 "LEFT JOIN Subject ON sbj_id = sub_sbj_id " +
                                 "LEFT JOIN Users ON user_id = people_user_id " +
                                 "LEFT JOIN LibLibraries ON lib_id = user_lib_id " +
                                 "WHERE sub_";
                if (libID != -1)
                    command += $"WHERE user_lib_id = {libID}";

                DataSet dataSet = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                adapter.Fill(dataSet);

                return dataSet;
            }
        }


        public static DataSet getNonActiveSubscribtionsList(int libID = -1) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = "SELECT sub_id, " +
                                 "CONCAT(people_first_name, ' ', people_last_name, ' ', people_middle_name) AS `ФИО`, " +
                                 "sbj_name AS `Название работы`, " +
                                 "sub_start AS `Начало выдачи`, " +
                                 "sub_finish AS `Конец выдачи`, " +
                                 "if (sub_active = 'Y', 'Активно', 'Не активно') AS `Статус`, " +
                                 "READ_ONLY_TEXT(sbj_wo) AS `Тип выдачи`, " +
                                 "lib_name AS 'Библиотека' " +
                                 "FROM Subscriptions " +
                                 "LEFT JOIN Peoples ON people_id = sub_people_id " +
                                 "LEFT JOIN Subject ON sbj_id = sub_sbj_id " +
                                 "LEFT JOIN Users ON user_id = people_user_id " +
                                 "LEFT JOIN LibLibraries ON lib_id = user_lib_id ";
                if (libID != -1)
                    command += $"WHERE user_lib_id = {libID}";

                DataSet dataSet = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                adapter.Fill(dataSet);

                return dataSet;
            }
        }

        public static DataSet getTypePersonList(int type, int libID = -1) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = "";


                if (type == 0) {
                    command = "SELECT people_first_name AS 'Имя', " +
                              "people_last_name AS 'Фамилия', " +
                              "people_middle_name AS 'Отчетсво', " +
                              "pa_institution AS 'Школа', " +
                              "pa_group AS 'Класс', " +
                              "lib_name AS 'Библиотека' " +
                              "FROM Peoples " +
                              "JOIN Users ON user_id = people_user_id " +
                              "JOIN PeopleAttributes ON pa_people_id = people_id " +
                              "JOIN LibLibraries ON lib_id = user_lib_id " +
                              "WHERE `people_type` = 0 ";
                    if (libID != -1)
                        command += $"AND user_lib_id = {libID}";
                }


                else if (type == 1) {
                    command = "SELECT people_first_name AS 'Имя', " +
                              "people_last_name AS 'Фамилия', " +
                              "people_middle_name AS 'Отчетсво', " +
                              "pa_institution AS 'Университет', " +
                              "pa_faculty AS 'Факультет', " +
                              "pa_group AS 'Группа', " +
                              "lib_name AS 'Библиотека' " +
                              "FROM Peoples " +
                              "JOIN Users ON user_id = people_user_id " +
                              "JOIN PeopleAttributes ON pa_people_id = people_id " +
                              "JOIN LibLibraries ON lib_id = user_lib_id " +
                              "WHERE `people_type` = 1 ";
                    if (libID != -1)
                        command += $"AND user_lib_id = {libID}";
                }


                else if (type == 2) {
                    command = "SELECT people_first_name AS 'Имя', " +
                              "people_last_name AS 'Фамилия', " +
                              "people_middle_name AS 'Отчетсво', " +
                              "pa_institution AS 'Уч. Заведение', " +
                              "pa_subject AS 'Уч. Предмет', " +
                              "lib_name AS 'Библиотека' " +
                              "FROM Peoples " +
                              "JOIN Users ON user_id = people_user_id " +
                              "JOIN PeopleAttributes ON pa_people_id = people_id " +
                              "JOIN LibLibraries ON lib_id = user_lib_id " +
                              "WHERE `people_type` = 2 ";
                    if (libID != -1)
                        command += $"AND user_lib_id = {libID}";
                }


                else if (type == 3) {
                    command = "SELECT people_first_name AS 'Имя', " +
                              "people_last_name AS 'Фамилия', " +
                              "people_middle_name AS 'Отчетсво', " +
                              "pa_orgname AS 'Организация', " +
                              "pa_direction AS 'Ис. Область', " +
                              "lib_name AS 'Библиотека' " +
                              "FROM Peoples " +
                              "JOIN Users ON user_id = people_user_id " +
                              "JOIN PeopleAttributes ON pa_people_id = people_id " +
                              "JOIN LibLibraries ON lib_id = user_lib_id " +
                              "WHERE `people_type` = 3 ";
                    if (libID != -1)
                        command += $"AND user_lib_id = {libID}";
                }


                else if (type == 4) {
                    command = "SELECT people_first_name AS 'Имя', " +
                              "people_last_name AS 'Фамилия', " +
                              "people_middle_name AS 'Отчетсво', " +
                              "pa_orgname AS 'Организация', " +
                              "pa_post AS 'Должность', " +
                              "lib_name AS 'Библиотека' " +
                              "FROM Peoples " +
                              "JOIN Users ON user_id = people_user_id " +
                              "JOIN PeopleAttributes ON pa_people_id = people_id " +
                              "JOIN LibLibraries ON lib_id = user_lib_id " +
                              "WHERE `people_type` = 4 ";
                    if (libID != -1)
                        command += $"AND user_lib_id = {libID}";
                }


                else if (type == 5) {
                    command = "SELECT people_first_name AS 'Имя', " +
                              "people_last_name AS 'Фамилия', " +
                              "people_middle_name AS 'Отчетсво', " +
                              "pa_workname AS 'Род деятельности', " +
                              "lib_name AS 'Библиотека' " +
                              "FROM Peoples " +
                              "JOIN Users ON user_id = people_user_id " +
                              "JOIN PeopleAttributes ON pa_people_id = people_id " +
                              "JOIN LibLibraries ON lib_id = user_lib_id " +
                              "WHERE `people_type` = 5 ";
                    if (libID != -1)
                        command += $"AND user_lib_id = {libID}";
                }

                DataSet dataSet = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                adapter.Fill(dataSet);

                return dataSet;

            }

        }

        public static DataSet getTypeSubjectList(int type, int libID = -1) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = "";

                if (type == 0) {
                    command = "SELECT sbj_id, sbj_name AS `Название`, " +
                              "if (bg_name IS NULL, '(нет)', GROUP_CONCAT(DISTINCT bg_name ORDER BY bg_name SEPARATOR ', ')) AS `Жанр(ы)`, " +
                              "if (a_name IS NULL, '(нет)', GROUP_CONCAT(DISTINCT a_name ORDER BY a_name SEPARATOR ', ')) AS `Автор(ы)`, " +
                              "if (pub_name is NULL, '(нет)', pub_name) AS `Издатель`, " +
                              "sbj_date AS `Дата выпуска`, " +
                              "sbj_quantity AS `Кол - во экземпляров`, " +
                              "READ_ONLY_TEXT(sbj_isReadOnly) AS `Чтение` " +
                              "FROM Subject " +
                              "JOIN SubjectAttributes ON sa_sbj_id = sbj_id " +
                              "LEFT JOIN Publishers ON pub_id = sbj_pub_id " +
                              "LEFT JOIN m2m_sbjattr_authors USING(sa_id) " +
                              "LEFT JOIN Authors USING(a_id) " +
                              "LEFT JOIN m2m_sbjattr_bookgenres USING(sa_id) " +
                              "LEFT JOIN BookGenres USING(bg_id) " +
                              "LEFT JOIN LibShelves ON shelv_id = sbj_shelv_id " +
                              "LEFT JOIN LibShevilings ON sh_id = shelv_sh_id " +
                              "LEFT JOIN LibRooms ON room_id = sh_room_id " +
                              "LEFT JOIN LibLibraries ON lib_id = room_lib_id " +
                              "WHERE sbj_wo = 'N' " +
                              "AND sbj_type = 0 ";

                    if (libID != -1) {
                        command += $"AND lib_id = {libID} ";
                    }
                    command += "GROUP BY `sbj_id`";
                }


                else if (type == 1) {
                    command = "SELECT sbj_id, sbj_name AS `Название`, " +
                              "if (pg_name IS NULL, '(Нет)', GROUP_CONCAT(DISTINCT pg_name ORDER BY pg_name SEPARATOR ', ')) AS `Жанр(ы)`, " +
                              "if (a_name IS NULL, '(Нет)', GROUP_CONCAT(DISTINCT a_name ORDER BY a_name SEPARATOR ', ')) AS `Автор(ы)`, " +
                              "if (pub_name is NULL, '(Нет)', pub_name) AS `Издатель`, " +
                              "sbj_date AS `Дата выпуска`, " +
                              "sbj_quantity AS `Кол - во экземпляров`, " +
                              "READ_ONLY_TEXT(sbj_isReadOnly) AS `Чтение` " +
                              "FROM Subject " +
                              "JOIN SubjectAttributes ON sa_sbj_id = sbj_id " +
                              "LEFT JOIN Publishers ON pub_id = sbj_pub_id " +
                              "LEFT JOIN m2m_sbjattr_authors USING(sa_id) " +
                              "LEFT JOIN Authors USING(a_id) " +
                              "LEFT JOIN m2m_sbjattr_poemgenres USING(sa_id) " +
                              "LEFT JOIN PoemGenres USING(pg_id) " +
                              "LEFT JOIN LibShelves ON shelv_id = sbj_shelv_id " +
                              "LEFT JOIN LibShevilings ON sh_id = shelv_sh_id " +
                              "LEFT JOIN LibRooms ON room_id = sh_room_id " +
                              "LEFT JOIN LibLibraries ON lib_id = room_lib_id " +
                              "WHERE sbj_type = 1 " +
                              "AND sbj_wo = 'N' ";

                    if (libID != -1) {
                        command += $"AND lib_id = {libID} ";
                    }
                    command += "GROUP BY `sbj_id`";
                }


                else if (type == 2) {
                    command = "SELECT sbj_id, " +
                              "sbj_name AS `Название`, " +
                              "mnt_name AS `Тип`, " +
                              "if (pub_name is NULL, '(Нет)', pub_name) AS `Издатель`, " +
                              "sbj_date AS `Дата выпуска`, " +
                              "sbj_quantity AS `Кол - во экземпляров`, " +
                              "READ_ONLY_TEXT(sbj_isReadOnly) AS `Чтение` " +
                              "FROM Subject " +
                              "JOIN SubjectAttributes ON sa_sbj_id = sbj_id " +
                              "LEFT JOIN Publishers ON pub_id = sbj_pub_id " +
                              "LEFT JOIN MagazineNews ON mnt_id = sa_mnt_id " +
                              "LEFT JOIN LibShelves ON shelv_id = sbj_shelv_id " +
                              "LEFT JOIN LibShevilings ON sh_id = shelv_sh_id " +
                              "LEFT JOIN LibRooms ON room_id = sh_room_id " +
                              "LEFT JOIN LibLibraries ON lib_id = room_lib_id " +
                              "WHERE sbj_type = 2 " +
                              "AND sbj_wo = 'N' ";
                    if(libID != -1) {
                        command += $"AND lib_id = {libID} ";
                    }
                    command += "GROUP BY `sbj_id`";
                }


                else if (type == 3) {
                    command = "SELECT sbj_id, " +
                              "sbj_name AS `Название`, " +
                              "mnt_name AS `Тип`, " +
                              "if (pub_name is NULL, '(Нет)', pub_name) AS `Издатель`, " +
                              "sbj_date AS `Дата выпуска`, " +
                              "sbj_quantity AS `Кол - во экземпляров`, " +
                              "READ_ONLY_TEXT(sbj_isReadOnly) AS `Чтение` " +
                              "FROM Subject " +
                              "JOIN SubjectAttributes ON sa_sbj_id = sbj_id " +
                              "LEFT JOIN Publishers ON pub_id = sbj_pub_id " +
                              "LEFT JOIN MagazineNews ON mnt_id = sa_mnt_id " +
                              "LEFT JOIN LibShelves ON shelv_id = sbj_shelv_id " +
                              "LEFT JOIN LibShevilings ON sh_id = shelv_sh_id " +
                              "LEFT JOIN LibRooms ON room_id = sh_room_id " +
                              "LEFT JOIN LibLibraries ON lib_id = room_lib_id " +
                              "WHERE sbj_type = 3 " +
                              "AND sbj_wo = 'N' ";
                    if (libID != -1) {
                        command += $"AND lib_id = {libID} ";
                    }
                    command += "GROUP BY `sbj_id`";
                }


                else if (type == 4) {
                    command = "SELECT sbj_id, " +
                              "sbj_name AS `Название`, " +
                              "d_name AS `Дисциплина`, " +
                              "sbj_date AS `Дата выпуска`, " +
                              "sbj_quantity AS `Кол - во экземпляров`, " +
                              "READ_ONLY_TEXT(sbj_isReadOnly) AS `Чтение` " +
                              "FROM Subject " +
                              "JOIN SubjectAttributes ON sa_sbj_id = sbj_id " +
                              "LEFT JOIN Publishers ON pub_id = sbj_pub_id " +
                              "LEFT JOIN Disciplines ON d_id = sa_d_id LEFT JOIN LibShelves ON shelv_id = sbj_shelv_id " +
                              "LEFT JOIN LibShevilings ON sh_id = shelv_sh_id " +
                              "LEFT JOIN LibRooms ON room_id = sh_room_id " +
                              "LEFT JOIN LibLibraries ON lib_id = room_lib_id " +
                              "WHERE sbj_type = 4 " +
                              "AND sbj_wo = 'N' ";
                    if (libID != -1) {
                        command += $"AND lib_id = {libID} ";
                    }
                    command += "GROUP BY `sbj_id`";
                }


                else if (type == 5) {
                    command = "SELECT sbj_id, " +
                              "sbj_name AS `Название`, " +
                              "d_name AS `Дисциплина`, " +
                              "sbj_date AS `Дата выпуска`, " +
                              "sbj_quantity AS `Кол - во экземпляров`, " +
                              "READ_ONLY_TEXT(sbj_isReadOnly) AS `Чтение` " +
                              "FROM Subject " +
                              "JOIN SubjectAttributes ON sa_sbj_id = sbj_id " +
                              "LEFT JOIN Publishers ON pub_id = sbj_pub_id " +
                              "LEFT JOIN Disciplines ON d_id = sa_d_id " +
                              "LEFT JOIN LibShelves ON shelv_id = sbj_shelv_id " +
                              "LEFT JOIN LibShevilings ON sh_id = shelv_sh_id " +
                              "LEFT JOIN LibRooms ON room_id = sh_room_id " +
                              "LEFT JOIN LibLibraries ON lib_id = room_lib_id " +
                              "WHERE sbj_type = 5 " +
                              "AND sbj_wo = 'N' ";
                    if (libID != -1) {
                        command += $"AND lib_id = {libID} ";
                    }
                    command += "GROUP BY `sbj_id`";

                }


                else if (type == 6) {
                    command = "SELECT sbj_id, sbj_name AS `Название`, " +
                              "d_name AS `Дисциплина`, " +
                              "sbj_date AS `Дата выпуска`, " +
                              "sbj_quantity AS `Кол - во экземпляров`, " +
                              "READ_ONLY_TEXT(sbj_isReadOnly) AS `Чтение` " +
                              "FROM Subject " +
                              "JOIN SubjectAttributes ON sa_sbj_id = sbj_id " +
                              "LEFT JOIN Publishers ON pub_id = sbj_pub_id " +
                              "LEFT JOIN Disciplines ON d_id = sa_d_id " +
                              "LEFT JOIN LibShelves ON shelv_id = sbj_shelv_id " +
                              "LEFT JOIN LibShevilings ON sh_id = shelv_sh_id " +
                              "LEFT JOIN LibRooms ON room_id = sh_room_id " +
                              "LEFT JOIN LibLibraries ON lib_id = room_lib_id " +
                              "WHERE sbj_type = 6 " +
                              "AND sbj_wo = 'N' ";
                    if (libID != -1) {
                        command += $"AND lib_id = {libID} ";
                    }
                    command += "GROUP BY `sbj_id`";
                }


                else if (type == 7) {
                    command = "SELECT sbj_id, sbj_name AS `Название`, " +
                              "art_name AS `Тип`, " +
                              "sbj_date AS `Дата выпуска`, " +
                              "sbj_quantity AS `Кол - во экземпляров`, " +
                              "READ_ONLY_TEXT(sbj_isReadOnly) AS `Чтение` " +
                              "FROM Subject " +
                              "JOIN SubjectAttributes ON sa_sbj_id = sbj_id " +
                              "LEFT JOIN Publishers ON pub_id = sbj_pub_id " +
                              "LEFT JOIN Article ON art_id = sa_art_id " +
                              "LEFT JOIN LibShelves ON shelv_id = sbj_shelv_id " +
                              "LEFT JOIN LibShevilings ON sh_id = shelv_sh_id " +
                              "LEFT JOIN LibRooms ON room_id = sh_room_id " +
                              "LEFT JOIN LibLibraries ON lib_id = room_lib_id " +
                              "WHERE sbj_type = 7 " +
                              "AND sbj_wo = 'N' ";
                    if (libID != -1) {
                        command += $"AND lib_id = {libID} ";
                    }
                    command += "GROUP BY `sbj_id`";
                }


                else if (type == 8) {
                    command = "SELECT sbj_id, sbj_name AS `Название`," +
                              "dt_name AS `Тип`, " +
                              "sbj_date AS `Дата выпуска`, " +
                              "sbj_quantity AS `Кол - во экземпляров`, " +
                              "READ_ONLY_TEXT(sbj_isReadOnly) AS `Чтение` " +
                              "FROM Subject " +
                              "JOIN SubjectAttributes ON sa_sbj_id = sbj_id " +
                              "LEFT JOIN Publishers ON pub_id = sbj_pub_id " +
                              "LEFT JOIN Dissertation ON dt_id = sa_dt_id " +
                              "LEFT JOIN LibShelves ON shelv_id = sbj_shelv_id " +
                              "LEFT JOIN LibShevilings ON sh_id = shelv_sh_id " +
                              "LEFT JOIN LibRooms ON room_id = sh_room_id " +
                              "LEFT JOIN LibLibraries ON lib_id = room_lib_id " +
                              "WHERE sbj_type = 8 " +
                              "AND sbj_wo = 'N' ";
                    if (libID != -1) {
                        command += $"AND lib_id = {libID} ";
                    }
                    command += "GROUP BY `sbj_id`";
                }


                else if (type == 9) {
                    command = "SELECT sbj_id, " +
                              "sbj_name AS `Название`, " +
                              "d_name AS `Дисциплина`, " +
                              "if (a_name IS NULL, '(Нет)', GROUP_CONCAT(DISTINCT a_name ORDER BY a_name SEPARATOR ', ')) AS `Автор(ы)`, " +
                              "sbj_date AS `Дата выпуска`, " +
                              "sbj_quantity AS `Кол - во экземпляров`, " +
                              "READ_ONLY_TEXT(sbj_isReadOnly) AS `Чтение` " +
                              "FROM Subject " +
                              "JOIN SubjectAttributes ON sa_sbj_id = sbj_id " +
                              "LEFT JOIN Publishers ON pub_id = sbj_pub_id " +
                              "LEFT JOIN Disciplines ON d_id = sa_d_id " +
                              "LEFT JOIN m2m_sbjattr_authors USING(sa_id) " +
                              "LEFT JOIN Authors USING(a_id) " +
                              "LEFT JOIN LibShelves ON shelv_id = sbj_shelv_id " +
                              "LEFT JOIN LibShevilings ON sh_id = shelv_sh_id " +
                              "LEFT JOIN LibRooms ON room_id = sh_room_id " +
                              "LEFT JOIN LibLibraries ON lib_id = room_lib_id " +
                              "WHERE sbj_type = 9 " +
                              "AND sbj_wo = 'N' ";
                    if (libID != -1) {
                        command += $"AND lib_id = {libID} ";
                    }
                    command += "GROUP BY `sbj_id`";
                }


                DataSet dataSet = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                adapter.Fill(dataSet);

                return dataSet;

            }

        }


        public static DataSet getAllSubjectList(int libID = -1) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {


                
                string command = "SELECT sbj_id, " +
                                    "sbj_name AS `Название`, " +
                                    "SUBJECT_TYPE(sbj_type) AS `Тип`, " +
                                    "if (pub_name is NULL, '(Нет)', pub_name) AS `Издатель`, " +
                                    "sbj_date AS `Дата выпуска`, " +
                                    "sbj_quantity AS `Кол - во экземпляров`, " +
                                    "READ_ONLY_TEXT(sbj_isReadOnly) AS `Чтение`" +
                            "FROM Subject " +
                            "JOIN SubjectAttributes ON sa_sbj_id = sbj_id " +
                            "LEFT JOIN Publishers ON pub_id = sbj_pub_id " +
                            "LEFT JOIN LibShelves ON shelv_id = sbj_shelv_id " +
                            "LEFT JOIN LibShevilings ON sh_id = shelv_sh_id " +
                            "LEFT JOIN LibRooms ON room_id = sh_room_id " +
                            "LEFT JOIN LibLibraries ON lib_id = room_lib_id ";
                            //$"WHERE(lib_id = {} OR lib_id IS NULL)";

                if (libID != -1) {
                    command += $"WHERE lib_id = {libID}";
                }

                DataSet dataSet = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                adapter.Fill(dataSet);

                return dataSet;
            }
        }



        public static Tuple<user, Person> getPeopleData(int userID) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                DataSet dataSet = new DataSet();
                string command = "SELECT people_type, " +
                                        "user_login, " +
                                        "user_pass, " +
                                        "user_phone, " +
                                        "user_email, " +
                                        "people_first_name, " +
                                        "people_last_name, " +
                                        "people_middle_name, " +
                                        "pa_institution, " +
                                        "pa_group, " +
                                        "pa_subject, " +
                                        "pa_faculty, " +
                                        "pa_orgname, " +
                                        "pa_direction, " +
                                        "pa_post, " +
                                        "pa_workname, " +
                                        "user_lib_id " +
                                 "FROM Users " +
                                 "JOIN Peoples ON people_user_id = user_id " +
                                 "JOIN PeopleAttributes ON pa_people_id = people_id " +
                                 $"WHERE user_id = {userID}";

                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                adapter.Fill(dataSet);
                var pData = dataSet.Tables[0].Select()[0];


                user pUser = new user(userID, 
                                     pData[1].ToString(), 
                                     pData[2].ToString(), 
                                     1, 
                                     pData[3].ToString(), 
                                     pData[4].ToString(),
                                     (int)pData[16]);


                switch ((int)pData[0]) {

                    case 0:
                        SchoolBoy schoolBoy = new SchoolBoy(pData[5].ToString(),
                                                            pData[6].ToString(),
                                                            pData[7].ToString(),
                                                            pData[8].ToString(),
                                                            pData[9].ToString());

                        return new Tuple<user, Person>(pUser, schoolBoy);

                    case 1:
                        Student student = new Student(pData[5].ToString(),
                                                      pData[6].ToString(),
                                                      pData[7].ToString(),
                                                      pData[8].ToString(),
                                                      pData[11].ToString(),
                                                      pData[9].ToString());

                        return new Tuple<user, Person>(pUser, student);

                    case 2:
                        Teacher teacher = new Teacher(pData[5].ToString(),
                                                      pData[6].ToString(),
                                                      pData[7].ToString(),
                                                      pData[8].ToString(),
                                                      pData[10].ToString());

                        return new Tuple<user, Person>(pUser, teacher);

                    case 3:
                        Scientist scientist = new Scientist(pData[5].ToString(),
                                                            pData[6].ToString(),
                                                            pData[7].ToString(),
                                                            pData[12].ToString(),
                                                            pData[13].ToString());

                        return new Tuple<user, Person>(pUser, scientist);

                    case 4:
                        Worker worker = new Worker(pData[5].ToString(),
                                                   pData[6].ToString(),
                                                   pData[7].ToString(),
                                                   pData[12].ToString(),
                                                   pData[14].ToString());

                        return new Tuple<user, Person>(pUser, worker);

                    case 5:
                        Other other = new Other(pData[5].ToString(),
                                                pData[6].ToString(),
                                                pData[7].ToString(),
                                                pData[15].ToString());

                        return new Tuple<user, Person>(pUser, other);

                }

                Person person = new People(pData[5].ToString(),
                                           pData[6].ToString(),
                                           pData[7].ToString());

                return new Tuple<user, Person>(pUser, person);
            }
        }

        

        public static Subscription GetSubscriptionData(int subID) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = "SELECT * FROM Subscriptions";

                DataSet dataSet = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                adapter.Fill(dataSet);
                var subData = dataSet.Tables[0].Select()[0];

                bool isActive = false;
                if (subData[5].ToString() == "Y")
                    isActive = true;

                return new Subscription((int)subData[0],
                                        (int)subData[1],
                                        (int)subData[2],
                                        subData[3].ToString(),
                                        subData[4].ToString(),
                                        isActive);
            }


        }


        public static Subject getSubjectData(int sbjID) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = "SELECT sa_id, " +
                                        "sbj_type, " +
                                        "sa_mnt_id, " +
                                        "sa_d_id, " +
                                        "sa_art_id, " +
                                        "sa_dt_id, " +
                                        "GROUP_CONCAT(DISTINCT a_id ORDER BY a_id SEPARATOR ' '), " +
                                        "GROUP_CONCAT(DISTINCT bg_id ORDER BY bg_id SEPARATOR ' '), " +
                                        "GROUP_CONCAT(DISTINCT pg_id ORDER BY pg_id SEPARATOR ' ')" +
                                 "FROM SubjectAttributes " +
                                 "LEFT JOIN m2m_sbjattr_authors USING(sa_id) " +
                                 "LEFT JOIN m2m_sbjattr_bookgenres USING(sa_id) " +
                                 "LEFT JOIN m2m_sbjattr_poemgenres USING(sa_id) " +
                                 "LEFT JOIN Subject ON sbj_id = sa_sbj_id " +
                                $"WHERE sa_sbj_id = {sbjID} " +
                                 "GROUP BY sa_id";

                DataSet dataSet = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                adapter.Fill(dataSet);
                var attrData = dataSet.Tables[0].Select()[0];


                Subject.attributesClass attributes = new Subject.attributesClass();
                List<int> authors = new List<int>();
                List<int> genres = new List<int>();

                

                // книга/стих
                if ((int)attrData[1] == 0 || (int)attrData[1] == 1) {
                    attributes.type_id = -1;
                    attributes.discipline_id = -1;

                    foreach (var item in attrData[6].ToString().Split(' ')) {
                        if(Int32.TryParse(item, out int author_id))
                            authors.Add(author_id);
                    }

                    if ((int)attrData[1] == 0) {
                        foreach (var item in attrData[7].ToString().Split(' ')) {
                            if (Int32.TryParse(item, out int genre_id))
                                genres.Add(genre_id);
                        }
                    }
                    else if ((int)attrData[1] == 1) {
                        foreach (var item in attrData[8].ToString().Split(' ')) {
                            if (Int32.TryParse(item, out int genre_id))
                                genres.Add(genre_id);
                        }
                    }
                }
                // газеты/журналы
                else if ((int)attrData[1] == 2 || (int)attrData[1] == 3) {

                    attributes.discipline_id = -1;
                    if(attrData[2].ToString() == String.Empty) {
                        attributes.type_id = -1;
                    }
                    else {
                        attributes.type_id = (int)attrData[2];
                    }
                }
                // Рефераты/сборник докладов/сборник тезисов/книги
                else if ((int)attrData[1] == 4 || (int)attrData[1] == 5 || (int)attrData[1] == 6 || (int)attrData[1] == 9) {

                    attributes.type_id = -1;
                    if (attrData[3].ToString() == String.Empty) {
                        attributes.discipline_id = -1;
                    }
                    else {
                        attributes.discipline_id = (int)attrData[3];
                    }

                    if ((int)attrData[1] == 9) {
                        foreach (var item in attrData[6].ToString().Split(' ')) {
                            if (Int32.TryParse(item, out int author_id))
                                authors.Add(author_id);
                        }
                    }
                }
                // Статьи
                else if ((int)attrData[1] == 7) {

                    attributes.discipline_id = -1;
                    if (attrData[4].ToString() == String.Empty) {
                        attributes.type_id = -1;
                    }
                    else {
                        attributes.type_id = (int)attrData[4];
                    }
                }
                // 
                else if ((int)attrData[1] == 8) {

                    attributes.discipline_id = -1;

                    if (attrData[3].ToString() == String.Empty)
                        attributes.discipline_id = -1;
                    else {
                        attributes.discipline_id = (int)attrData[3];
                    }

                    if (attrData[5].ToString() == String.Empty) {
                        attributes.type_id = -1;
                    }
                    else {
                        attributes.type_id = (int)attrData[5];
                    }
                }

                attributes.author_id = authors;
                attributes.genre_id = genres;




                string command2 = $"SELECT * FROM Subject WHERE sbj_id = {sbjID}";
                DataSet dataSet1 = new DataSet();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter(command2, conn);
                adapter1.Fill(dataSet1);
                var sbjData = dataSet1.Tables[0].Select()[0];

                int pub = -1;
                if (sbjData[2].ToString() != String.Empty)
                    pub = (int)sbjData[2];

                int shelf = -1;
                if (sbjData[1].ToString() != String.Empty)
                    shelf = (int)sbjData[1];

                bool isReadOnly = false;
                if (sbjData[5].ToString() == "Y")
                    isReadOnly = true;

                bool writeOff = false;
                if (sbjData[8].ToString() == "Y")
                    writeOff = true;

                   
                return new Subject((int)sbjData[0],
                                   shelf,
                                   pub,
                                   sbjData[3].ToString(),
                                   (int)sbjData[4],
                                   isReadOnly,
                                   (int)sbjData[6],
                                   (int)sbjData[7],
                                   sbjData[9].ToString(),
                                   writeOff,
                                   attributes);
            }

        }



        public static bool findUser(int id) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                DataSet dataSet = new DataSet();
                string command = $"SELECT * FROM Users WHERE user_id = {id}";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
                adapter.Fill(dataSet);
                int countData = dataSet.Tables[0].Rows.Count;

                return countData > 0;

            }

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



        /// <summary>
        /// Функция, которая определяет оригинальность логина (логин не должен совпадать с другими логинами в БД)
        /// </summary>
        /// <param name="login">Логин нового аккаунта</param>
        /// <returns>true - совпадение найдено; false - совпадений нет</returns>
        public static bool Samelogin(string login, int id) {

            using (MySqlConnection conn = new MySqlConnection(connectionString)) {

                string command = $"SELECT user_login FROM Users WHERE user_id != {id}";
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
