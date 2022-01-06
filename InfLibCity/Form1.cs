using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InfLibCity
{
    public partial class Form1 : Form
    {
        DataSet currentData;
        public user currentUser = null;
        Tuple<user, Person> oldUser;
        public int activeTable = -1;
        DataGridViewSelectedRowCollection selectedRows;
        DataGridViewRow selectedRow;
        

        public Form1()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;

            List<Library> libList = DBManipulator.getLibrariesNameList();


            // Проверка на наличие библиотек в бд
            if (libList.Count == 0)
            {

                MessageBox.Show("Библиотек нет в базе данных. Регистрация невозможна!", "Ошибка");
                this.Close();

            }

            cB_Libraries.DataSource = libList;
            cB_Libraries.DisplayMember = "libraryName";
            cB_Libraries.ValueMember = "id";

            /*
            if (libList.Count > 0)
            {
                List<Room> roomsList = DBManipulator.getRoomsList(libList[0].id);
                cB_Rooms.DataSource = roomsList;
                cB_Rooms.DisplayMember = "number";
                cB_Rooms.ValueMember = "id";
            }
            else
            {
                cB_Rooms.Enabled = false;
            }
            */

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

        }

        public void Authorization(bool run)
        {
            if (!(currentUser is null))
            {
                var person = DBManipulator.getPerson(currentUser);
                if (currentUser.type == 0)
                {
                    this.Text += String.Format(" Редактор: {0} {1}. {2}.", person.lastName, person.firstName[0], person.middleName[0]);
                    appendMenu.Visible = true;
                    issueBookBtn.Visible = true;
                    editUserBtn.Enabled = true;
                    showTablesLib.Visible = true;
                    showTablesPeople.Visible = false;
                }
                else
                {
                    this.Text += String.Format(" Пользователь: {0} {1}. {2}.", person.lastName, person.firstName[0], person.middleName[0]);
                    issueBookBtn.Visible = true;
                    showTablesLib.Visible = false;
                    showTablesPeople.Visible = true;
                    abonemetHistoryMenu.Enabled = true;
                    abonemetHistoryMenu.ToolTipText = String.Empty;
                }
                this.enterMenuBtn.Visible = false;
                this.exitMenuBtn.Visible = true;
            }
        }

        private void exitMenuBtn_Click(object sender, EventArgs e)
        {
            this.Text = "InfLibCity";
            this.enterMenuBtn.Visible = true;
            this.exitMenuBtn.Visible = false;
            this.appendMenu.Visible = false;
            issueBookBtn.Visible = false;
            editUserBtn.Enabled = false;

            showTablesLib.Visible = false;
            showTablesPeople.Visible = true;
            abonemetHistoryMenu.Enabled = false;
            abonemetHistoryMenu.ToolTipText = "Для просмотра нужно авторизоваться.";
            dataGridView1.DataSource = new ArrayList();
            activeTable = -1;
            userInfoPanel.Visible = false;
            subjectInfoPanel.Visible = false;

            currentUser = null;

            welcomLabel.Visible = true;
        }

        private void enterButtonClick(object sender, EventArgs e)
        {
            Auth auth = new Auth(this);
            auth.Show();
            this.Enabled = false;
        }

        private void issueBookBtnClick(object sender, EventArgs e)
        {

        }

        private void addUserBtn(object sender, EventArgs e)
        {
            AppendUser appendUser = new AppendUser(this, (sender as ToolStripMenuItem).Name);
            appendUser.Show();
            this.Enabled = false;
        }

        private void addSubjectBtn_Click(object sender, EventArgs e)
        {
            AppendSubject appendSubject = new AppendSubject(this);
            appendSubject.Show();
            this.Enabled = false;
        }

        private void showPeoplesClick(object sender, EventArgs e)
        {
            activeTable = 0;
            currentData = DBManipulator.getPeopleList();
            dataGridView1.DataSource = currentData.Tables[0];
            dataGridView1.Columns["user_id"].Visible = false;
            if (dataGridView1.Rows.Count > 0) {
                int id = (int)dataGridView1.Rows[0].Cells[0].Value;
                showPeople(id);
            }

            welcomLabel.Visible = false;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {            
            if (currentData is null)
            {
                MessageBox.Show("Таблица пуста.", "Внимание!");
                
                return;
            }
            else if (searchField.Text != String.Empty)
            {
                string[] searchText = searchField.Text.Split();
                DataSet newData = new DataSet();
                DataTable dt = currentData.Tables[0].Clone();
                foreach (var row in currentData.Tables[0].Select())
                {
                    int count = 0;
                    foreach (var item in row.ItemArray)
                    {
                        foreach (var word in searchText)
                        {
                            if (item.ToString().ToLower().IndexOf(word.ToLower()) != -1)
                                count++;
                        }
                    }
                    if (count > 0) dt.Rows.Add(row.ItemArray.Clone() as object[]);
                }
                newData.Tables.Add(dt);
                dataGridView1.ClearSelection();
                dataGridView1.DataSource = newData.Tables[0];
            }
            else
            {
                dataGridView1.DataSource = currentData.Tables[0];
            }
        }

        private void cellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex != -1) {
                int id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                showPeople(id);
            }

            selectedRow = dataGridView1.SelectedRows[0];

        }
        private void showPeople(int id)
        {
            Tuple<user, Person> clickedUser = DBManipulator.getPeopleData(id);
            var userData = clickedUser.Item1;
            var personData = clickedUser.Item2;

            fillUserInfBox(userData, personData);
            
            userInfoPanel.Visible = true;
            searchField.Enabled = true;
        }


        private void rbPeopleEnabled(int num) {

            switch (num) {
                case -1:
                    schoolBoyRB.Enabled = true;
                    studentRB.Enabled = true;
                    teacherRB.Enabled = true;
                    scientistRB.Enabled = true;
                    workerRB.Enabled = true;
                    otherRB.Enabled = true;
                    break;
                case 0:
                    schoolBoyRB.Enabled = true;
                    studentRB.Enabled = false;
                    teacherRB.Enabled = false;
                    scientistRB.Enabled = false;
                    workerRB.Enabled = false;
                    otherRB.Enabled = false;
                    break;

                case 1:
                    schoolBoyRB.Enabled = false;
                    studentRB.Enabled = true;
                    teacherRB.Enabled = false;
                    scientistRB.Enabled = false;
                    workerRB.Enabled = false;
                    otherRB.Enabled = false;
                    break;

                case 2:
                    schoolBoyRB.Enabled = false;
                    studentRB.Enabled = false;
                    teacherRB.Enabled = true;
                    scientistRB.Enabled = false;
                    workerRB.Enabled = false;
                    otherRB.Enabled = false;
                    break;

                case 3:
                    schoolBoyRB.Enabled = false;
                    studentRB.Enabled = false;
                    teacherRB.Enabled = false;
                    scientistRB.Enabled = true;
                    workerRB.Enabled = false;
                    otherRB.Enabled = false;
                    break;

                case 4:
                    schoolBoyRB.Enabled = false;
                    studentRB.Enabled = false;
                    teacherRB.Enabled = false;
                    scientistRB.Enabled = false;
                    workerRB.Enabled = true;
                    otherRB.Enabled = false;
                    break;

                case 5:
                    schoolBoyRB.Enabled = false;
                    studentRB.Enabled = false;
                    teacherRB.Enabled = false;
                    scientistRB.Enabled = false;
                    workerRB.Enabled = false;
                    otherRB.Enabled = true;
                    break;

            }
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

                subjectField.Text = String.Empty;
                facField.Text = String.Empty;
                directionField.Text = String.Empty;
                orgNameField.Text = String.Empty;
                postField.Text = String.Empty;
                typeWorkField.Text = String.Empty;
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

                subjectField.Text = String.Empty;
                directionField.Text = String.Empty;
                orgNameField.Text = String.Empty;
                postField.Text = String.Empty;
                typeWorkField.Text = String.Empty;
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

                groupField.Text = String.Empty;
                facField.Text = String.Empty;
                directionField.Text = String.Empty;
                orgNameField.Text = String.Empty;
                postField.Text = String.Empty;
                typeWorkField.Text = String.Empty;
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

                institutionField.Text = String.Empty;
                groupField.Text = String.Empty;
                subjectField.Text = String.Empty;
                facField.Text = String.Empty;
                postField.Text = String.Empty;
                typeWorkField.Text = String.Empty;
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

                institutionField.Text = String.Empty;
                groupField.Text = String.Empty;
                subjectField.Text = String.Empty;
                facField.Text = String.Empty;
                directionField.Text = String.Empty;
                typeWorkField.Text = String.Empty;
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

                institutionField.Text = String.Empty;
                groupField.Text = String.Empty;
                subjectField.Text = String.Empty;
                facField.Text = String.Empty;
                directionField.Text = String.Empty;
                orgNameField.Text = String.Empty;
                postField.Text = String.Empty;
            }
        }

        private void searchField_KeyPress(object sender, KeyPressEventArgs e) {
            
            if (e.KeyChar == (char)13) {
                searchBtn.PerformClick();
            }
        }

        private void editUserBtn_Click(object sender, EventArgs e)
        {
            editMode(true);

            oldUser = getPersonFromInfBox();
        }

        private Tuple<user, Person> getPersonFromInfBox()
        {
            user userData = new user();

            userData.login = loginField.Text;
            userData.pass = passField.Text;
            userData.email = emailField.Text;
            userData.phone = phoneField.Text;
            userData.libraryID = (int)cB_Libraries.SelectedValue;
            userData.id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            userData.type = 1;
            
            if (schoolBoyRB.Checked)
            {
                SchoolBoy schoolBoy = new SchoolBoy(
                    firstNameField.Text,
                    lastNameField.Text,
                    middleNameField.Text,
                    institutionField.Text,
                    groupField.Text
                    );
                schoolBoy.userId = userData.id;
                return new Tuple<user, Person>(userData, schoolBoy);
            }
            else if (studentRB.Checked)
            {
                Student student = new Student(
                    firstNameField.Text,
                    lastNameField.Text,
                    middleNameField.Text,
                    institutionField.Text,
                    facField.Text,
                    groupField.Text
                    );
                student.userId = userData.id;
                return new Tuple<user, Person>(userData, student);
            }
            else if (teacherRB.Checked)
            {
                Teacher teacher = new Teacher(
                    firstNameField.Text,
                    lastNameField.Text,
                    middleNameField.Text,
                    institutionField.Text,
                    subjectField.Text
                    );
                teacher.userId = userData.id;
                return new Tuple<user, Person>(userData, teacher);
            }
            else if (scientistRB.Checked)
            {
                Scientist scientist = new Scientist(
                    firstNameField.Text,
                    lastNameField.Text,
                    middleNameField.Text,
                    orgNameField.Text,
                    directionField.Text
                    );
                scientist.userId = userData.id;
                return new Tuple<user, Person>(userData, scientist);
            }
            else if (workerRB.Checked)
            {
                Worker worker = new Worker(
                    firstNameField.Text,
                    lastNameField.Text,
                    middleNameField.Text,
                    orgNameField.Text,
                    postField.Text
                    );
                worker.userId = userData.id;
                return new Tuple<user, Person>(userData, worker);
            }
            else
            {
                Other other = new Other(
                    firstNameField.Text,
                    lastNameField.Text,
                    middleNameField.Text,
                    typeWorkField.Text
                    );
                other.userId = userData.id;
                return new Tuple<user, Person>(userData, other);
            }
        }

        private void fillUserInfBox(user userData, Person personData)
        {
            lastNameField.Text = personData.lastName;
            firstNameField.Text = personData.firstName;
            middleNameField.Text = personData.middleName;
            emailField.Text = userData.email;
            phoneField.Text = userData.phone;
            loginField.Text = userData.login;
            passField.Text = userData.pass;
            cB_Libraries.SelectedValue = userData.libraryID;
            libraryField.Text = cB_Libraries.GetItemText(cB_Libraries.SelectedItem);
            libraryField.Visible = true;
            cB_Libraries.Visible = false;

            if (currentUser is null)
            {
                loginPanel.Visible = false;
                passPanel.Visible = false;
            }
            else
            {
                loginPanel.Visible = currentUser.type == 0;
                passPanel.Visible = currentUser.type == 0;
            }

            switch (personData.GetType().Name)
            {
                case "SchoolBoy":
                    var personDataSB = personData as SchoolBoy;
                    schoolBoyRB.Checked = false;
                    schoolBoyRB.Checked = true;
                    rbPeopleEnabled(0);
                    institutionField.Text = personDataSB.institution;
                    groupField.Text = personDataSB.group;
                    break;
                case "Student":
                    var personDataS = personData as Student;
                    studentRB.Checked = false;
                    studentRB.Checked = true;
                    rbPeopleEnabled(1);
                    facField.Text = personDataS.faculty;
                    institutionField.Text = personDataS.institution;
                    groupField.Text = personDataS.group;
                    break;
                case "Teacher":
                    var personDataT = personData as Teacher;
                    teacherRB.Checked = false;
                    teacherRB.Checked = true;
                    rbPeopleEnabled(2);
                    institutionField.Text = personDataT.orgName;
                    subjectField.Text = personDataT.subject;
                    break;
                case "Scientist":
                    var personDataSC = personData as Scientist;
                    scientistRB.Checked = false;
                    scientistRB.Checked = true;
                    rbPeopleEnabled(3);
                    orgNameField.Text = personDataSC.orgName;
                    directionField.Text = personDataSC.direction;
                    break;
                case "Worker":
                    var personDataW = personData as Worker;
                    workerRB.Checked = false;
                    workerRB.Checked = true;
                    rbPeopleEnabled(4);
                    orgNameField.Text = personDataW.orgName;
                    postField.Text = personDataW.post;
                    break;
                case "Other":
                    var personDataO = personData as Other;
                    otherRB.Checked = false;
                    otherRB.Checked = true;
                    rbPeopleEnabled(5);
                    typeWorkField.Text = personDataO.typeWork;
                    break;
            };
        }

        private void cancelUserBtn_Click(object sender, EventArgs e)
        {
            fillUserInfBox(oldUser.Item1, oldUser.Item2);
            editMode(false);
        }

        private void saveUserBtn_Click(object sender, EventArgs e)
        {
            Tuple<user, Person> savedUser = getPersonFromInfBox();
            editMode(false);
            fillUserInfBox(savedUser.Item1, savedUser.Item2);
            DBManipulator.updateUser(savedUser.Item2, savedUser.Item1);

            refreshTablePeoples(savedUser.Item1.id);
        }

        private void editMode(bool start)
        {
            dataGridView1.Enabled = !start;

            lastNameField.ReadOnly = !start;
            firstNameField.ReadOnly = !start;
            middleNameField.ReadOnly = !start;
            emailField.ReadOnly = !start;
            libraryField.Visible = !start;
            cB_Libraries.Visible = start;
            phoneField.ReadOnly = !start;

            loginField.ReadOnly = !start;
            passField.ReadOnly = !start;

            int type;
            if (schoolBoyRB.Checked) type = 0;
            else if (studentRB.Checked) type = 1;
            else if (teacherRB.Checked) type = 2;
            else if (scientistRB.Checked) type = 3;
            else if (workerRB.Checked) type = 4;
            else type = 5;
            rbPeopleEnabled(start ? -1 : type);

            orgNameField.ReadOnly = !start;
            institutionField.ReadOnly = !start;
            groupField.ReadOnly = !start;
            typeWorkField.ReadOnly = !start;
            postField.ReadOnly = !start;
            directionField.ReadOnly = !start;
            subjectField.ReadOnly = !start;
            facField.ReadOnly = !start;

            editUserBtn.Visible = !start;
            saveUserBtn.Visible = start;
            cancelUserBtn.Visible = start;
            deleteBtn.Visible = !start;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var result = MessageBox.Show("Вы точно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int user_id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    DBManipulator.deleteUser(user_id);
                    refreshTablePeoples();
                }
            }
            else
            {
                MessageBox.Show("Не выбрана стркоа.", "Ошибка");
            }
        }

        public void refreshTablePeoples(int id = -1)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int index = 0;
                if (selectedRow != null && selectedRow.Index >= 0)
                {
                    if ((int)selectedRow.Cells[0].Value == id)
                    {
                        index = selectedRow.Index;
                    }
                    else
                    {
                        id = (int)dataGridView1.Rows[0].Cells[0].Value;
                    }
                }
                else
                {
                    id = (int)dataGridView1.Rows[0].Cells[0].Value;
                }

                currentData = DBManipulator.getPeopleList();
                dataGridView1.DataSource = currentData.Tables[0];
                dataGridView1.Columns["user_id"].Visible = false;

                showPeople(id);
                dataGridView1.Rows[index].Selected = true;
            }
        }
    }
}
