using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfLibCity
{
    public partial class AppendUser : Form
    {
        Form mainForm;

        public AppendUser()
        {
            InitializeComponent();
        }

        public AppendUser(Form mf, user currentUser = null) 
        {

            InitializeComponent();
            mainForm = mf;
            if (currentUser is null || currentUser.type < 2)
            {
                personTypeBox.Visible = false;
            }

            schoolBoyRB.Checked = false;
            rb_people.Checked = false;
            schoolBoyRB.Checked = true;
            rb_people.Checked = true;


            List<Library> libList = DBManipulator.getLibrariesNameList();


            // Проверка на наличие библиотек в бд
            if (libList.Count == 0) {

                MessageBox.Show("Библиотек нет в базе данных. Регистрация невозможна!", "Ошибка");
                this.Close();

            }

            cB_Libraries.DataSource = libList;
            cB_Libraries.DisplayMember = "libraryName";
            cB_Libraries.ValueMember = "id";

            if (libList.Count > 0) {
                List<Room> roomsList = DBManipulator.getRoomsList(libList[0].id);
                cB_Rooms.DataSource = roomsList;
                cB_Rooms.DisplayMember = "number";
                cB_Rooms.ValueMember = "id";
            }
            else {
                cB_Rooms.Enabled = false;
            }
               
        }

        private void cancel_btn_Click(object sender, EventArgs e) 
        {
            this.Close();
        }

        private void AppendUser_FormClosed(object sender, FormClosedEventArgs e) 
        {
            (mainForm as Form1).refreshTable();
            mainForm.Enabled = true;
        }

        private void rb_people_CheckedChanged(object sender, EventArgs e) 
        {
            if (rb_people.Checked)
            {
                peopleTypeBox.Visible = true;
                peopleDataLayoutPanel.Visible = true;
                label3.Visible = false;
                cB_Rooms.Visible = false;
                this.Width = 500;
            }
            else if (rb_librarian.Checked)
            {
                peopleTypeBox.Visible = false;
                peopleDataLayoutPanel.Visible = false;
                label3.Visible = true;
                cB_Rooms.Visible = true;
                this.Width = 218;
            }

        }

        private void creation_btn_Click(object sender, EventArgs e) 
        {
            
            // Проверка на заполненность полей
            if (CreationErrorSerach())
                return;

            string regLogin = regloginField.Text;
            string regPass = regpassField.Text;
            string regEmail = emailField.Text;
            string regPhone = phoneField.Text;

            string regFirstName = firstnameField.Text;
            string regLastName = lastnameField.Text;
            string regMiddleName = middlenameField.Text;

            int regType = 1;
            if (rb_librarian.Checked)
                regType = 0;

            int regLibraryID = (int)cB_Libraries.SelectedValue;
            //int regRoomID = (int)cB_Rooms.SelectedValue;




            user newUser = new user(regLogin, regPass, regType, regPhone, regEmail, regLibraryID);
            Person newPerson;

            if (regType == 0) {
                int regRoomID = (int)cB_Rooms.SelectedValue;
                newPerson = new Librarian(regFirstName, regLastName, regMiddleName, regRoomID);
                DBManipulator.addUser(newPerson, newUser);
            }
            else {
                //newPerson = new People(regFirstName, regLastName, regMiddleName);
                //DBManipulator.addUser(newPerson, newUser);

                if (schoolBoyRB.Checked) {

                    string regSchool = institutionField.Text;
                    string regClass = groupField.Text;

                    newPerson = new SchoolBoy(regFirstName,
                                              regLastName,
                                              regMiddleName,
                                              regSchool,
                                              regClass);

                    DBManipulator.addUser(newPerson, newUser);

                }
                else if (teacherRB.Checked){

                    string regInstitution = institutionField.Text;
                    string regSubject = subjectField.Text;

                    newPerson = new Teacher(regFirstName,
                                            regLastName,
                                            regMiddleName,
                                            regInstitution,
                                            regSubject);

                    DBManipulator.addUser(newPerson, newUser);

                }
                else if (studentRB.Checked) {

                    string regInstitution = institutionField.Text;
                    string regGroup = groupField.Text;
                    string regFaculty = facField.Text;

                    newPerson = new Student(regFirstName,
                                              regLastName,
                                              regMiddleName,
                                              regInstitution,
                                              regGroup,
                                              regFaculty);

                    DBManipulator.addUser(newPerson, newUser);

                }
                else if (scientistRB.Checked) {

                    string regOrganization = orgNameField.Text;
                    string regDirection = directionField.Text;

                    newPerson = new Scientist(regFirstName,
                                              regLastName,
                                              regMiddleName,
                                              regOrganization,
                                              regDirection);

                    DBManipulator.addUser(newPerson, newUser);

                }
                else if (workerRB.Checked) {

                    string regOrganization = orgNameField.Text;
                    string regPost = postField.Text;

                    newPerson = new Worker(regFirstName,
                                              regLastName,
                                              regMiddleName,
                                              regOrganization,
                                              regPost);

                    DBManipulator.addUser(newPerson, newUser);

                }
                else if (otherRB.Checked) {

                    string regWork = typeWorkField.Text;

                    newPerson = new Other(regFirstName,
                                              regLastName,
                                              regMiddleName,
                                              regWork);

                    DBManipulator.addUser(newPerson, newUser);

                }
            }


            this.Close();
        }


        /// <summary>
        /// Функция для порверки правильности заполнености формы регистрации
        /// </summary>
        /// <returns>true - обнаружена ошибка; false - ошибок не обнаружено!</returns>
        private bool CreationErrorSerach() 
        {
            if (regloginField.Text == "" || regpassField.Text == "") 
            {
                MessageBox.Show("Не введены поля логин/пароль", "Ошибка");
                return true;
            }

            else if (firstnameField.Text == "" || lastnameField.Text == "" || middlenameField.Text == "") {
                MessageBox.Show("Не введены поля ФИО", "Ошибка");
                return true;
            }
            else if (DBManipulator.Samelogin(regloginField.Text)) 
            {
                MessageBox.Show("Такой логин уже существует!", "Ошибка");
                return true;
            }

            else if (rb_people.Checked) {
                if (schoolBoyRB.Checked) {
                    if (institutionField.Text == "" || groupField.Text == "") {
                        MessageBox.Show("Введите атрибуты!", "Ошибка");
                        return true;
                    }
                }
                else if (teacherRB.Checked) {
                    if (institutionField.Text == "" || subjectField.Text == "") {
                        MessageBox.Show("Введите атрибуты!", "Ошибка");
                        return true;
                    }
                }
                else if (studentRB.Checked) {
                    if (institutionField.Text == "" || facField.Text == "" || groupField.Text == "") {
                        MessageBox.Show("Введите атрибуты!", "Ошибка");
                        return true;
                    }
                }
                else if (scientistRB.Checked) {
                    if (orgNameField.Text == "" || directionField.Text == "") {
                        MessageBox.Show("Введите атрибуты!", "Ошибка");
                        return true;
                    }
                }
                else if (workerRB.Checked) {
                    if (orgNameField.Text == "" || postField.Text == "") {
                        MessageBox.Show("Введите атрибуты!", "Ошибка");
                        return true;
                    }
                }
                else if (otherRB.Checked) {
                    if (typeWorkField.Text == "") {
                        MessageBox.Show("Введите атрибуты!", "Ошибка");
                        return true;
                    }
                }
            }

            return false;
        }

        private void schoolBoyRB_CheckedChanged(object sender, EventArgs e)
        {
            if (schoolBoyRB.Checked)
            {
                institutionPanel.Visible = true;
                groupPanel.Visible = true;

                subjectPanel.Visible = false;
                facPanel.Visible = false;
                directionPanel.Visible = false;
                orgNamePanel.Visible = false;
                postPanel.Visible = false;
                typeWorkPanel.Visible = false;

                institutionField.TabIndex = 7;
                subjectField.TabIndex = 8;
            }
        }

        private void teacherRB_CheckedChanged(object sender, EventArgs e)
        {
            if (teacherRB.Checked)
            {
                institutionPanel.Visible = true;

                groupPanel.Visible = false;

                subjectPanel.Visible = true;

                facPanel.Visible = false;
                directionPanel.Visible = false;
                orgNamePanel.Visible = false;
                postPanel.Visible = false;
                typeWorkPanel.Visible = false;

                institutionField.TabIndex = 7;
                subjectField.TabIndex = 8;
            }
        }

        private void studentRB_CheckedChanged(object sender, EventArgs e)
        {
            if (studentRB.Checked)
            {
                institutionPanel.Visible = true;
                groupPanel.Visible = true;

                subjectPanel.Visible = false;

                facPanel.Visible = true;

                directionPanel.Visible = false;
                orgNamePanel.Visible = false;
                postPanel.Visible = false;
                typeWorkPanel.Visible = false;

                institutionField.TabIndex = 7;
                facField.TabIndex = 8;
                groupField.TabIndex = 9;
            }
        }

        private void scientistRB_CheckedChanged(object sender, EventArgs e)
            {
            if (scientistRB.Checked)
            {
                institutionPanel.Visible = false;
                groupPanel.Visible = false;
                subjectPanel.Visible = false;
                facPanel.Visible = false;

                orgNamePanel.Visible = true;
                directionPanel.Visible = true;

                postPanel.Visible = false;
                typeWorkPanel.Visible = false;

                orgNameField.TabIndex = 7;
                directionField.TabIndex = 8;
            }
        }

        private void workerRB_CheckedChanged(object sender, EventArgs e)
        {
            if (workerRB.Checked)
            {
                institutionPanel.Visible = false;
                groupPanel.Visible = false;
                subjectPanel.Visible = false;
                facPanel.Visible = false;
                directionPanel.Visible = false;

                orgNamePanel.Visible = true;
                postPanel.Visible = true;

                typeWorkPanel.Visible = false;
                orgNameField.TabIndex = 7;
                postField.TabIndex = 8;
            }
        }

        private void otherRB_CheckedChanged(object sender, EventArgs e)
        {
            if (otherRB.Checked)
            {
                institutionPanel.Visible = false;
                groupPanel.Visible = false;
                subjectPanel.Visible = false;
                facPanel.Visible = false;
                directionPanel.Visible = false;
                orgNamePanel.Visible = false;
                postPanel.Visible = false;

                typeWorkPanel.Visible = true;
                typeWorkField.TabIndex = 7;
            }
        }

        private void cB_Libraries_SelectedIndexChanged(object sender, EventArgs e) {


            Console.WriteLine(cB_Libraries.SelectedValue.ToString());

            if (cB_Libraries.SelectedValue.ToString() != "InfLibCity.Library") {
                cB_Rooms.Enabled = true;
                //string id = cB_Libraries.SelectedValue.ToString();
                List<Room> roomsList = DBManipulator.getRoomsList((int)cB_Libraries.SelectedValue);
                cB_Rooms.DataSource = roomsList;
                cB_Rooms.DisplayMember = "number";
                cB_Rooms.ValueMember = "id";
            }
            
        }

        private void label_library_Click(object sender, EventArgs e)
        {

        }
    }
}
