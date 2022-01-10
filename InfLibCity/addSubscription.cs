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
    public partial class addSubscription : Form
    {
        Form parentForm;
        user currentUser;
        int currentLibId;
        DataSet currentPeopleData;
        DataSet currentSubjectData;
        bool editMode;
        int subs_id;
        Subscription oldSubscription;

        public addSubscription(Form parentForm, user currentUser, bool editMode = false, int subs_id = -1)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.currentUser = currentUser; 
            this.editMode = editMode;
            this.subs_id = subs_id;
            currentLibId = currentUser.libraryID;
            if (editMode)
                oldSubscription = DBManipulator.GetSubscriptionData(subs_id);
            if (this.currentUser.type == 1)
            {
                peopleBox.Enabled = false;
            }
            else
            {
                peopleBox.Enabled = true;

                List<Library> libList = DBManipulator.getLibrariesNameList();
                libraryCB.DataSource = new BindingSource(libList, null);
                libraryCB.DisplayMember = "libraryName";
                libraryCB.ValueMember = "id";

                if (this.currentUser.type > 1)
                {
                    libraryLabel.Visible = true;
                    libraryCB.Visible = true;
                    currentLibId = libList[0].id;
                }

                libraryCB.SelectedValue = currentLibId;
                peopleTypeCB.SelectedIndex = 0;
            }

            subjectTypeCB.SelectedIndex = 0;
            if (editMode)
            {
                DateTime begin = Convert.ToDateTime(oldSubscription.startDate);
                DateTime end = Convert.ToDateTime(oldSubscription.finishDate);
                beginDate.MinDate = begin;
                beginDate.Value = begin;
                endDate.MinDate = end;
                endDate.Value = end;
                beginDate.MaxDate = DateTime.Now;
                appendBtn.Text = "Сохранить";
            }
            else
            {
                beginDate.MinDate = DateTime.Now.AddDays(-7);
                endDate.MinDate = beginDate.MinDate;
                appendBtn.Text = "Оформить";
            }
        }

        private void addSubscription_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (parentForm.Name == "Form1")
                (parentForm as Form1).refreshTable();
            parentForm.Enabled = true;
        }

        private DataSet loadData(DataGridView table, DataSet ds)
        {
            table.DataSource = ds.Tables[0];
            foreach(DataGridViewColumn collumn in table.Columns)
            {
                if (collumn.Name.Contains("id"))
                    collumn.Visible = false;
            }

            if (table.Rows.Count > 0)
            {
                table.Rows[0].Selected = true;
            }
            else
            {
                MessageBox.Show("Таблица пуста или не сущетсвет", "Ошибка");
            }
            return ds;
        }

        private void peopleTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (peopleTypeCB.SelectedIndex - 1)
            {
                case -1: // Все
                    currentPeopleData = loadData(peopleData, DBManipulator.getPeopleList(currentLibId));
                    break;

                default:
                    currentPeopleData = loadData(peopleData, DBManipulator.getTypePersonList(peopleTypeCB.SelectedIndex - 1, currentLibId));
                    break;
            }
        }

        private void subjectTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (subjectTypeCB.SelectedIndex - 1)
            {
                case -1: // Все
                    currentSubjectData = loadData(subjectData, DBManipulator.getAllSubjectList(currentLibId));
                    break;

                default:
                    currentSubjectData = loadData(subjectData, DBManipulator.getTypeSubjectList(subjectTypeCB.SelectedIndex - 1, currentLibId));
                    break;
            }
        }

        private void libraryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (libraryCB.SelectedValue.ToString() != "InfLibCity.Library")
                currentLibId = (int)libraryCB.SelectedValue;

        }

        private void appendBtn_Click(object sender, EventArgs e)
        {
            string beginDateString = beginDate.Value.ToString("yyyy-MM-dd");
            string endDateString = endDate.Value.ToString("yyyy-MM-dd");
            int person_id;
            if (currentUser.type == 1)
            {
                person_id = currentUser.id;
            }
            else
            {
                try
                {
                    int user_id = (int)peopleData.SelectedRows[0].Cells["user_id"].Value;
                    person_id = DBManipulator.getPerson(DBManipulator.getUser(user_id)).id;
                }
                catch
                {
                    MessageBox.Show("Не выбран ни один читатель.", "Ошибка");
                    return;
                }
            }
            int subject_id;
            try
            {
                subject_id = (int)subjectData.SelectedRows[0].Cells["sbj_id"].Value;
            }
            catch
            {
                MessageBox.Show("Не выбрана ни одина работа.", "Ошибка");
                return;
            }
            Subscription subscription;
            if (editMode)
                 subscription = new Subscription(subs_id, person_id, subject_id, beginDateString, endDateString, oldSubscription.isActive);
            else subscription = new Subscription(person_id, subject_id, beginDateString, endDateString);

            var result = MessageBox.Show(subscription.ToString(), "Внимание", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool isOk;
                    if (editMode)
                        isOk = DBManipulator.updateSubscription(subscription);
                    else isOk = DBManipulator.addSubscription(subscription);
                    if (!isOk) throw new Exception("Недостаточное кол-во книг");
                }
                catch (Exception error)
                {
                    if (editMode)
                        MessageBox.Show($"Не удалось изменить оформление литературы по след. причине:\n{error}", "Ошибка");
                    else
                    MessageBox.Show($"Не удалось добавить оформление литературы по след. причине:\n{error}", "Ошибка");
                    return;
                }

                if (editMode)
                    MessageBox.Show($"Оформление успешно изменено", "Уведомление");
                else MessageBox.Show($"Оформление успешно добавлено", "Уведомление");
                this.Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void endDate_Validating(object sender, CancelEventArgs e)
        {
            if (endDate.Value < beginDate.Value)
            {
                e.Cancel = true;
                MessageBox.Show("Дата сдачи не может быть меньше даты выдачи.", "Ошибка");
                endDate.Value = beginDate.Value;
            }
        }

        private void searchPeopleBtn_Click(object sender, EventArgs e)
        {
            searchFunc(currentPeopleData, searchPeopleField, peopleData);
        }

        private void searchSubjectBtn_Click(object sender, EventArgs e)
        {
            searchFunc(currentSubjectData, searchSubjectField, subjectData);
        }

        private void searchFunc(DataSet currentData, TextBox searchField, DataGridView table)
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
                    if (count == searchText.Length) dt.Rows.Add(row.ItemArray.Clone() as object[]);
                }
                newData.Tables.Add(dt);
                table.ClearSelection();
                table.DataSource = newData.Tables[0];
            }
            else
            {
                table.DataSource = currentData.Tables[0];
            }
        }

        private void searchPeopleField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                searchPeopleBtn.PerformClick();
            }
        }

        private void searchSubjectField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                searchSubjectBtn.PerformClick();
            }
        }

        private void addSubscription_Load(object sender, EventArgs e)
        {
            if (editMode)
            {
                int index_p = 0;
                int index_s = 0;
                int subject_id = oldSubscription.subjectId;
                int user_id = DBManipulator.getUserID(oldSubscription.peopleId);
                foreach (DataGridViewRow row in subjectData.Rows)
                {
                    if ((int)row.Cells["sbj_id"].Value == subject_id)
                        index_s = row.Index;
                }
                foreach (DataGridViewRow row in peopleData.Rows)
                {
                    if ((int)row.Cells["user_id"].Value == user_id)
                        index_p = row.Index;
                }

                peopleData.Rows[index_p].Selected = true;
                subjectData.Rows[index_s].Selected = true;
            }
        }
    }
}
