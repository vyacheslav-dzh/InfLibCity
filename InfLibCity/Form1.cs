using System;
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
                }
                else
                {
                    this.Text += String.Format(" Пользователь: {0} {1}. {2}.", person.lastName, person.firstName[0], person.middleName[0]);
                    issueBookBtn.Visible = true;
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
            currentUser = null;
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

            currentData = DBManipulator.getPeopleList();
            dataGridView1.DataSource = currentData.Tables[0];
            dataGridView1.Columns["user_id"].Visible = false;
            //cellClick(sender, e);
            //dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            //dataGridView1.Rows[1].Selected = true;
            if (dataGridView1.Rows.Count > 0) {
                int id = (int)dataGridView1.Rows[0].Cells[0].Value;
                showPeople(id);
            }
            
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
            
        }
        private void showPeople(int id)
        {
            Tuple<user, Person> clickedUser = DBManipulator.getPeopleData(id);
            personTypeBox.Visible = false;
            label19.Visible = false;
            cB_Rooms.Visible = false;
            var userData = clickedUser.Item1;
            var personData = clickedUser.Item2;

            lastNameField.Text = personData.lastName;
            firstNameField.Text = personData.firstName;
            middleNameField.Text = personData.middleName;
            emailField.Text = userData.email;
            cB_Libraries.SelectedValue = userData.libraryID;
            //libraryField.Text = cB_Libraries.Text.ToString();
            libraryField.Text = cB_Libraries.GetItemText(cB_Libraries.SelectedItem);
            libraryField.Visible = true;
            cB_Libraries.Visible = false;
            personTypeBox.Visible = false;
            
            switch (clickedUser.Item2.GetType().Name)
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
            userPanel.Visible = true;
        }


        private void rbPeopleEnabled(int num) {

            switch (num) {

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
            }
        }

        private void searchField_KeyPress(object sender, KeyPressEventArgs e) {
            
            if (e.KeyChar == (char)13) {
                searchBtn.PerformClick();
            }
        }
    }
}
