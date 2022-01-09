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
        int currentLibID;
        Tuple<user, Person> oldUser;
        DataGridViewRow selectedRow;
        Subject oldSubject;
        Dictionary<int, string> bookGenresDict;
        Dictionary<int, string> poemGenresDict;
        Dictionary<int, string> authorsDict;
        Dictionary<int, string> magazineNewsDict;
        Dictionary<int, string> dissertationDict;
        Dictionary<int, string> articleDict;
        bool editModeBool = false;


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

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

        }

        public void Authorization(bool run)
        {
            if (!(currentUser is null))
            {
                activeTable.Value = 0;
                var person = DBManipulator.getPerson(currentUser);
                currentLibID = currentUser.libraryID;
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
            else
            {
                currentLibID = -1;
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
            activeTable.Value = 0;
            userInfoPanel.Visible = false;
            subjectInfoPanel.Visible = false;

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
            addSubscription addSubscription = new addSubscription(this, currentUser);
            addSubscription.Show();
            this.Enabled = false;
        }

        private void addUserBtn(object sender, EventArgs e)
        {
            AppendUser appendUser = new AppendUser(this, (sender as ToolStripMenuItem).Name);
            appendUser.Show();
            this.Enabled = false;
        }

        private void addSubjectBtn_Click(object sender, EventArgs e)
        {
            AppendSubject appendSubject = new AppendSubject(this, currentUser);
            appendSubject.Show();
            this.Enabled = false;
        }


        private void addAuthorBtn_Click(object sender, EventArgs e) {

            addAttribute attribute = new addAttribute(this, "Authors");
            attribute.Show();
            this.Enabled = false;

        }


        private void addPublisherBtn_Click(object sender, EventArgs e) {
            addAttribute attribute = new addAttribute(this, "Publishers");
            attribute.Show();
            this.Enabled = false;
        }


        private void addBookGenresBtn_Click(object sender, EventArgs e) {
            addAttribute attribute = new addAttribute(this, "BookGenres");
            attribute.Show();
            this.Enabled = false;
        }


        private void addPoemGenresBtn_Click(object sender, EventArgs e) {
            addAttribute attribute = new addAttribute(this, "PoemGenres");
            attribute.Show();
            this.Enabled = false;
        }

        private void addMgzBtn_Click(object sender, EventArgs e) {
            addAttribute attribute = new addAttribute(this, "MagazineNews");
            attribute.Show();
            this.Enabled = false;
        }


        private void addDisciplBtn_Click(object sender, EventArgs e) {
            addAttribute attribute = new addAttribute(this, "Disciplines");
            attribute.Show();
            this.Enabled = false;
        }

        private void addArticleBtn_Click(object sender, EventArgs e) {
            addAttribute attribute = new addAttribute(this, "Article");
            attribute.Show();
            this.Enabled = false;
        }


        private void addDissBtn_Click(object sender, EventArgs e) {
            addAttribute attribute = new addAttribute(this, "Dissertation");
            attribute.Show();
            this.Enabled = false;
        }


        private void showPeoplesClick(object sender, EventArgs e)
        {
            activeTable.Value = 1;
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
            this.Enabled = false;
            if (e.RowIndex != -1) {
                int id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                if (DBManipulator.findUser(id) && activeTable.Value == 1)
                    showToInfBox(id);
                else if (activeTable.Value == 2)
                    showToInfBox(id);
                else {
                    MessageBox.Show("Этот пользователь не существует!", "Ошибка");
                    refreshTable();
                    return;
                }
            }
            selectedRow = dataGridView1.SelectedRows[0];
            this.Enabled = true;
        }

        private void showToInfBox(int id)
        {
            switch (activeTable.Value)
            {
                case 1:
                    Tuple<user, Person> clickedUser = DBManipulator.getPeopleData(id);
                    var userData = clickedUser.Item1;
                    var personData = clickedUser.Item2;
                    fillUserInfBox(userData, personData);
                    break;
                case 2:
                    Subject clickedSubject = DBManipulator.getSubjectData(id);
                    if (clickedSubject.isWriteOff)
                        writeOffBtn.Enabled = false;
                    else writeOffBtn.Enabled = true;
                    fillSubjectInfBox(clickedSubject);
                    break;
            }
        }


        private void rbPeopleEnabled(int num)
        {
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

            if (PeopleEditErrorSerach(savedUser.Item1.id))
                return;

            if (!DBManipulator.findUser(savedUser.Item1.id)) {
                MessageBox.Show("Этот пользователь не существует!", "Ошибка");
                refreshTable();
                editMode(false);
                return;
            }

            editMode(false);
            fillUserInfBox(savedUser.Item1, savedUser.Item2);
            DBManipulator.updateUser(savedUser.Item2, savedUser.Item1);

            refreshTable(savedUser.Item1.id);
        }

        private void editMode(bool start)
        {
            editModeBool = start;
            searchField.Enabled = !start;
            searchBtn.Enabled = !start;
            dataGridView1.Enabled = !start;
            switch (activeTable.Value)
            {
                case 1:
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
                    deleteUserBtn.Visible = !start;
                    break;

                case 2:
                    nameSubjectField.ReadOnly = !start;
                    yearWrittingField.ReadOnly = !start;
                    publisherCB.Enabled = start;
                    dateWrittigOffP.Enabled = start;
                    subjectTypeCB.Enabled = start;
                    typeCB.Enabled = start;
                    disciplineCB.Enabled = start;
                    quantityNUD.Enabled = start;
                    quantityNUD.Increment = start ? 1 : 0;
                    isReadOnlyChB.Enabled = start;

                    addAddressBtn.Enabled = start;
                    authorsBtnPanel.Visible = start;
                    genresBtnPanel.Visible = start;

                    editSubjectBtn.Visible = !start;
                    delSubjectBtn.Visible = !start;

                    saveSubjectBtn.Visible = start;
                    cancelSubjectBtn.Visible = start;
                    break;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var result = MessageBox.Show("Вы точно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int user_id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

                    if (!DBManipulator.findUser(user_id)) {
                        MessageBox.Show("Этот пользователь не существует!", "Ошибка");
                        refreshTable();
                        return;
                    }

                    DBManipulator.deleteUser(user_id);
                    refreshTable();
                }
            }
            else
            {
                MessageBox.Show("Не выбрана стркоа.", "Ошибка");
            }
        }

        public void refreshTable(int id = -1)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                switch (activeTable.Value)
                {
                    case 1:
                        currentData = DBManipulator.getPeopleList();
                        dataGridView1.DataSource = currentData.Tables[0];
                        dataGridView1.Columns["user_id"].Visible = false;
                        break;
                    case 2:
                        currentData = DBManipulator.getAllSubjectList(currentLibID);
                        dataGridView1.DataSource = currentData.Tables[0];
                        dataGridView1.Columns["sbj_id"].Visible = false;
                        break;
                }


                if (id == -1)
                {
                    dataGridView1.Rows[0].Selected = true;
                    showToInfBox((int)dataGridView1.Rows[0].Cells[0].Value);
                }
                else
                {
                    int index = 0;
                    while ((int)dataGridView1.Rows[index].Cells[0].Value != id && index <= dataGridView1.Rows.Count)
                    {
                        index++;
                    }
                    if (index == dataGridView1.Rows.Count && (int)dataGridView1.Rows[index].Cells[0].Value != id)
                    {
                        index = 0;
                    }

                    id = (int)dataGridView1.Rows[index].Cells[0].Value;
                    dataGridView1.Rows[index].Selected = true;
                    selectedRow = dataGridView1.SelectedRows[0];
                    showToInfBox(id);
                }
            }
        }

        private bool PeopleEditErrorSerach(int id) {


            if (loginField.Text == "" || passField.Text == "") {
                MessageBox.Show("Не введены поля логин/пароль", "Ошибка");
                return true;
            }
            else if (firstNameField.Text == "" || lastNameField.Text == "" || middleNameField.Text == "") {
                MessageBox.Show("Не введены поля ФИО", "Ошибка");
                return true;
            }
            else if (DBManipulator.Samelogin(loginField.Text, id)) {
                MessageBox.Show("Такой логин уже существует!", "Ошибка");
                return true;
            }
            else if (schoolBoyRB.Checked) {
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
            return false;
        }

        private void activeTable_ValueChanged(object sender, EventArgs e)
        {
            foreach (Panel panel in infBox.Controls["flowLayoutPanel1"].Controls.OfType<Panel>())
            {
                panel.Visible = false;
            }
            selectedRow = null;
            switch (activeTable.Value)
            {
                case 0: // Таблиц нет
                    searchField.Enabled = false;
                    searchBtn.Enabled = false;
                    welcomLabel.Visible = true;
                    dataGridView1.DataSource = null;

                    break;
                case 1: // Читатели
                    if (currentUser.type == 1)
                        peoplesBtnPanel.Visible = false;
                    welcomLabel.Visible = false;
                    searchField.Enabled = true;
                    searchBtn.Enabled = true;
                    userInfoPanel.Visible = true;

                    currentData = DBManipulator.getPeopleList();

                    dataGridView1.DataSource = currentData.Tables[0];
                    dataGridView1.Columns["user_id"].Visible = false;
                    if (dataGridView1.Rows.Count > 0)
                    {
                        int id = (int)dataGridView1.Rows[0].Cells[0].Value;
                        showToInfBox(id);
                    }
                    dataGridView1.Rows[0].Selected = true;
                    selectedRow = dataGridView1.SelectedRows[0];
                    break;

                case 2: // Вся литература
                    if (currentUser is null || currentUser.type == 1)
                        subjectBtnPanel.Visible = false;
                    else
                        subjectBtnPanel.Visible = true;
                    welcomLabel.Visible = false;
                    searchField.Enabled = true;
                    searchBtn.Enabled = true;
                    subjectInfoPanel.Visible = true;

                    currentData = DBManipulator.getAllSubjectList();
                    dataGridView1.DataSource = currentData.Tables[0];
                    dataGridView1.Columns["sbj_id"].Visible = false;

                    bookGenresDict = getDataDict("BookGenres");
                    poemGenresDict = getDataDict("PoemGenres");
                    authorsDict = getDataDict("Authors");
                    magazineNewsDict = getDataDict("MagazineNews");
                    dissertationDict = getDataDict("Dissertation");
                    articleDict = getDataDict("Article");

                    publisherCB.DataSource = new BindingSource(getDataDict("Publishers"), null);
                    publisherCB.DisplayMember = "Value";
                    publisherCB.ValueMember = "Key";
                    disciplineCB.DataSource = new BindingSource(getDataDict("Disciplines"), null);
                    disciplineCB.DisplayMember = "Value";
                    disciplineCB.ValueMember = "Key";


                    if (dataGridView1.Rows.Count > 0)
                    {
                        int id = (int)dataGridView1.Rows[0].Cells[0].Value;
                        showToInfBox(id);
                    }
                    dataGridView1.Rows[0].Selected = true;
                    selectedRow = dataGridView1.SelectedRows[0];
                    break;
            }
        }

        private void showAllSubjectsBtn_Click(object sender, EventArgs e)
        {
            activeTable.Value = 2;
        }

        private void editSubjectBtn_Click(object sender, EventArgs e)
        {
            editMode(true);
            oldSubject = getSubjectFromInfBox();
            switch (subjectTypeCB.SelectedIndex)
            {
                case 0: // Книга
                    authorsBtnPanel.Enabled = true;
                    genresLB.Enabled = true;
                    disciplineCB.Enabled = false;
                    typeCB.Enabled = false;
                    break;
                    
                case 1: // Сборник стихов
                    goto case 0;

                case 2: // Газета
                    authorsBtnPanel.Enabled = false;
                    genresBtnPanel.Enabled = false;
                    disciplineCB.Enabled = false;
                    typeCB.Enabled = true;
                    break;
                case 3: // Журнал
                    goto case 2;

                case 4: // Реферат
                    authorsBtnPanel.Enabled = false;
                    genresBtnPanel.Enabled = false;
                    disciplineCB.Enabled = true;
                    typeCB.Enabled = false;
                    break;
                case 5: // Сборник докладов
                    goto case 4;
                case 6: // Сборник тезисов
                    goto case 4;

                case 7: // Статья
                    goto case 2;

                case 8: // Диссертация
                    authorsBtnPanel.Enabled = false;
                    genresBtnPanel.Enabled = false;
                    disciplineCB.Enabled = true;
                    typeCB.Enabled = true;
                    break;

                case 9: // Учебник;
                    authorsBtnPanel.Enabled = true;
                    genresBtnPanel.Enabled = false;
                    disciplineCB.Enabled = true;
                    typeCB.Enabled = false;
                    goto case 4;
            }

        }

        private Subject getSubjectFromInfBox()
        {
            Subject.attributesClass attributes = new Subject.attributesClass();

            switch (subjectTypeCB.SelectedIndex)
            {
                case 0: // Книга
                    attributes.author_id = new List<int>();
                    attributes.genre_id = new List<int>();
                    foreach (KeyValuePair<int, string> item in authorsLB.Items)
                    {
                        attributes.author_id.Add(item.Key);
                    }
                    foreach (KeyValuePair<int, string> item in genresLB.Items)
                    {
                        attributes.genre_id.Add(item.Key);
                    }
                    break;
                case 1: // Сборник стихов
                    goto case 0;

                case 2: // Газета
                    attributes.type_id = (int)typeCB.SelectedValue;
                    break;
                case 3: // Журнал
                    goto case 2;

                case 4: // Реферат
                    attributes.discipline_id = (int)disciplineCB.SelectedValue;
                    break;
                case 5: // Сборник докладов
                    goto case 4;
                case 6: // Сборник тезисов
                    goto case 4;

                case 7: // Статья
                    goto case 2;

                case 8: // Диссертация
                    attributes.discipline_id = (int)disciplineCB.SelectedValue;
                    attributes.type_id = (int)typeCB.SelectedValue;
                    break;

                case 9: // Учебник
                    foreach (KeyValuePair<int, string> item in authorsLB.Items)
                    {
                        attributes.author_id.Add(item.Key);
                    }
                    goto case 4;
            }

            int shelf_id;

            if (addressLB.SelectedValue is null)
                shelf_id = -1;
            else
                shelf_id = (int)addressLB.SelectedValue;

            return new Subject(
                id: (int)dataGridView1.Rows[selectedRow.Index].Cells[0].Value,
                shelf_id: shelf_id,
                publisher_id: (int)publisherCB.SelectedValue,
                name: nameSubjectField.Text,
                year: Int32.Parse(yearWrittingField.Text),
                isReadOnly: isReadOnlyChB.Checked,
                quantity: (int)quantityNUD.Value,
                type: subjectTypeCB.SelectedIndex,
                yearWriteOff: dateWrittigOffP.Value.ToString("yyyy-MM-dd"),
                isWriteOff: false,
                attributes: attributes
                );
        }

        private void cancelSubjectBtn_Click(object sender, EventArgs e)
        {
            editMode(false);
            fillSubjectInfBox(oldSubject);
        }
        private void fillSubjectInfBox(Subject subject)
        {
            if (subject is null) return;

            publisherCB.SelectedIndex = 0;
            disciplineCB.SelectedIndex = 0;

            authorsLB.DataSource = null;
            genresLB.DataSource = null;
            typeCB.DataSource = null;
            addressLB.DataSource = null;

            nameSubjectField.Text = subject.name;
            yearWrittingField.Text = subject.year.ToString();
            publisherCB.SelectedValue = subject.publisher_id;
            dateWrittigOffP.Value = Convert.ToDateTime(subject.yearWriteOff);
            subjectTypeCB.SelectedIndex = subject.type;
            quantityNUD.Value = subject.quantity;
            isReadOnlyChB.Checked = subject.isReadOnly;

            Address address = DBManipulator.getFullAddress(subject.shelf_id);
            Tuple<int, string, Address> tuple = new Tuple<int, string, Address>(address.shelf_id, address.text, address);
            List<Tuple<int, string, Address>> tupleList = new List<Tuple<int, string, Address>>() { tuple };
            addressLB.DataSource = tupleList;
            addressLB.DisplayMember = "item2";
            addressLB.ValueMember = "item1";


            switch (subjectTypeCB.SelectedIndex)
            {
                case 0: // Книга
                    Dictionary<int, string> input = new Dictionary<int, string>();
                    foreach (KeyValuePair<int, string> author in authorsDict)
                    {
                        if (subject.attributes.author_id.Contains(author.Key))
                            input.Add(author.Key, author.Value);
                    }
                    authorsLB.DataSource = new BindingSource(input, null);
                    authorsLB.DisplayMember = "Value";
                    authorsLB.ValueMember = "Key";

                    input = new Dictionary<int, string>();
                    Dictionary<int, string> genres;
                    if (subjectTypeCB.SelectedIndex == 0)
                        genres = bookGenresDict;
                    else
                        genres = poemGenresDict;

                    foreach(KeyValuePair<int, string> genre in genres)
                    {
                        if (subject.attributes.genre_id.Contains(genre.Key))
                            input.Add(genre.Key, genre.Value);
                    }

                    genresLB.DataSource = new BindingSource(input, null);
                    genresLB.DisplayMember = "Value";
                    genresLB.ValueMember = "Key";
                    break;

                case 1: // Сборник стихов
                    goto case 0;

                case 2: // Газета
                    typeCB.DataSource = new BindingSource(magazineNewsDict, null);
                    typeCB.DisplayMember = "Value";
                    typeCB.ValueMember = "Key";
                    typeCB.SelectedValue = subject.attributes.type_id;
                    break;

                case 3: // Журнал
                    goto case 2;

                case 4: // Реферат
                    disciplineCB.SelectedValue = subject.attributes.discipline_id;
                    break;

                case 5: // Сборник докладов
                    goto case 4;

                case 6: // Сборник тезисов
                    goto case 4;

                case 7: // Статья
                    typeCB.DataSource = new BindingSource(articleDict, null);
                    typeCB.DisplayMember = "Value";
                    typeCB.ValueMember = "Key";
                    typeCB.SelectedValue = subject.attributes.type_id;
                    break;

                case 8: // Диссертация
                    disciplineCB.SelectedValue = subject.attributes.discipline_id;

                    typeCB.DataSource = new BindingSource(dissertationDict, null);
                    typeCB.DisplayMember = "Value";
                    typeCB.ValueMember = "Key";
                    typeCB.SelectedValue = subject.attributes.type_id;
                    break;

                case 9: // Учебник
                    disciplineCB.SelectedValue = subject.attributes.discipline_id;
                    break;
            }
        }

        private Dictionary<int, string> getDataDict(string tableName)
        {
            DataSet ds = DBManipulator.getSubjectAttributeDict(tableName);

            Dictionary<int, string> dict = new Dictionary<int, string>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dict.Add((int)row.ItemArray[0], row.ItemArray[1].ToString());
            }
            return dict;
        }

        private void subjectTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!editModeBool) return;

            authorsLB.DataSource = null;
            genresLB.DataSource = null;
            typeCB.DataSource = null;

            switch (subjectTypeCB.SelectedIndex)
            {
                case 0: // Книга
                    authorsBtnPanel.Enabled = true;
                    genresBtnPanel.Enabled = true;
                    disciplineCB.Enabled = false;
                    typeCB.Enabled = false;
                    break;

                case 1: // Сборник стихов
                    goto case 0;

                case 2: // Газета
                    authorsBtnPanel.Enabled = false;
                    genresBtnPanel.Enabled = false;
                    disciplineCB.Enabled = false;
                    typeCB.Enabled = true;

                    typeCB.DataSource = new BindingSource(magazineNewsDict, null);
                    typeCB.DisplayMember = "Value";
                    typeCB.ValueMember = "Key";

                    break;

                case 3: // Журнал
                    goto case 2;

                case 4: // Реферат
                    authorsBtnPanel.Enabled = false;
                    genresBtnPanel.Enabled = false;
                    disciplineCB.Enabled = true;
                    typeCB.Enabled = false;
                    break;

                case 5: // Сборник докладов
                    goto case 4;

                case 6: // Сборник тезисов
                    goto case 4;

                case 7: // Статья
                    authorsBtnPanel.Enabled = false;
                    genresBtnPanel.Enabled = false;
                    disciplineCB.Enabled = false;
                    typeCB.Enabled = true;

                    typeCB.DataSource = new BindingSource(articleDict, null);
                    typeCB.DisplayMember = "Value";
                    typeCB.ValueMember = "Key";
                    break;

                case 8: // Диссертация
                    authorsBtnPanel.Enabled = false;
                    genresBtnPanel.Enabled = false;
                    disciplineCB.Enabled = true;
                    typeCB.Enabled = true;

                    typeCB.DataSource = new BindingSource(dissertationDict, null);
                    typeCB.DisplayMember = "Value";
                    typeCB.ValueMember = "Key";
                    break;

                case 9: // Учебник
                    authorsBtnPanel.Enabled = true;
                    genresBtnPanel.Enabled = false;
                    disciplineCB.Enabled = true;
                    typeCB.Enabled = false;

                    disciplineCB.DataSource = new BindingSource(dissertationDict, null);
                    disciplineCB.DisplayMember = "Value";
                    disciplineCB.ValueMember = "Key";
                    break;
            }
        }

        private void saveSubjectBtn_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Subject newSubject = getSubjectFromInfBox();
            DBManipulator.updateSubject(newSubject);
            MessageBox.Show("Предмет успешно сохранен.", "Уведомление");
            refreshTable(newSubject.id);
            editMode(false);
            this.Enabled = true;
        }

        private void delSubjectBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                this.Enabled = false;
                var result = MessageBox.Show("Вы точно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    DBManipulator.deleteSubject(id);
                    refreshTable();
                }
            }
            else
            {
                MessageBox.Show("Не выбрана стркоа.", "Ошибка");
            }
            this.Enabled = true;
        }

        private void addAuthorsBtn_Click(object sender, EventArgs e)
        {
            addAuthorGenre(authorsLB);
        }

        private void delAuthorBtn_Click(object sender, EventArgs e)
        {
            delGenreOrAuthor(authorsLB);
        }

        private void addGenreBtn_Click(object sender, EventArgs e)
        {
            addAuthorGenre(genresLB, subjectTypeCB.SelectedIndex == 1);
        }

        private void delGenreBtn_Click(object sender, EventArgs e)
        {
            delGenreOrAuthor(genresLB);
        }

        private void addAddressBtn_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            addAddressSubject addAddressSubject = new addAddressSubject(this, addressLB, currentUser);
            addAddressSubject.Show();
        }

        private void addAuthorGenre(ListBox lb, bool poem = false)
        {
            this.Enabled = false;
            addAuthorsGenres addAuthorsGenres = new addAuthorsGenres(this, lb, poem);
            addAuthorsGenres.Show();
        }

        private void delGenreOrAuthor(ListBox listBox)
        {
            if (listBox.SelectedItems.Count > 0)
            {
                var newDataList = (listBox.DataSource as BindingSource).List;
                Dictionary<int, string> newData = new Dictionary<int, string>();
                foreach (KeyValuePair<int, string> item in newDataList)
                {
                    if (!listBox.SelectedItems.Contains(item))
                    {
                        newData.Add(item.Key, item.Value);
                    }
                }
                if (newData.Count == 0)
                    listBox.DataSource = null;
                else
                    listBox.DataSource = new BindingSource(newData, null);
                listBox.DisplayMember = "Value";
                listBox.ValueMember = "Key";
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной строки.", "Ошибка");
            }
        }

        private void writeOffBtn_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                Subject subject = getSubjectFromInfBox();
                subject.isWriteOff = true;
                DBManipulator.updateSubject(subject);
                MessageBox.Show(subjectTypeCB.Text + " успешно списан(а)", "Уведомление");
                writeOffBtn.Enabled = false;
            }
            catch (Exception error)
            {
                MessageBox.Show("Произошла непредвиденная ошибка: \n" + error, "Ошибка");
            }
            this.Enabled = true;
        }

        private void allSubjectsForPeople_Click(object sender, EventArgs e)
        {
            showAllSubjectsBtn.PerformClick();
        }
    }
}
