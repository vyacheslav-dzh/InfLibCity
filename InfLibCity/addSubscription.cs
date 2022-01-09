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

        public addSubscription(Form parentForm, user currentUser)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.currentUser = currentUser;
            currentLibId = currentUser.libraryID;

            subjectTypeCB.SelectedIndex = 0;

            if (this.currentUser.type == 1)
            {
                peopleBox.Enabled = false;
            }
            else
            {
                peopleBox.Enabled = true;
                peopleTypeCB.SelectedIndex = 0;

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

                libraryCB.SelectedValue = currentLibId == -1 ? libList[0].id : currentLibId;
            }

            beginDate.MinDate = DateTime.Now.AddDays(-7);
            endDate.MinDate = beginDate.MinDate;
        }

        private void addSubscription_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Enabled = true;
        }

        private void loadData(DataGridView table, DataSet ds)
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
        }

        private void peopleTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (subjectTypeCB.SelectedIndex - 1)
            {
                case -1: // Все
                    loadData(peopleData, DBManipulator.getPeopleList());
                    break;

                case 0: // Школьник
                    loadData(peopleData, DBManipulator.getPeopleList());
                    break;

                case 1: // Студент
                    loadData(peopleData, DBManipulator.getPeopleList());
                    break;

                case 2: // Преподователь
                    loadData(peopleData, DBManipulator.getPeopleList());
                    break;

                case 3: // Науч. работник
                    loadData(peopleData, DBManipulator.getPeopleList());
                    break;

                case 4: // Рабочий
                    loadData(peopleData, DBManipulator.getPeopleList());
                    break;

                case 5: // Другой
                    loadData(peopleData, DBManipulator.getPeopleList());
                    break;
            }
        }

        private void subjectTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (subjectTypeCB.SelectedIndex - 1)
            {
                case -1: // Все
                    loadData(subjectData, DBManipulator.getAllSubjectList(currentLibId));
                    break;

                case 0: // Книга
                    loadData(subjectData, DBManipulator.getAllSubjectList());
                    break;

                case 1: // Сборник стихов
                    loadData(subjectData, DBManipulator.getAllSubjectList());
                    break;

                case 2: // Газета
                    loadData(subjectData, DBManipulator.getAllSubjectList());
                    break;

                case 3: // Журнал
                    loadData(subjectData, DBManipulator.getAllSubjectList());
                    break;

                case 4: // Реферат
                    loadData(subjectData, DBManipulator.getAllSubjectList());
                    break;

                case 5: // Сборник докладов
                    loadData(subjectData, DBManipulator.getAllSubjectList());
                    break;

                case 6: // Сборник тезисов
                    loadData(subjectData, DBManipulator.getAllSubjectList());
                    break;

                case 7: // Статья
                    loadData(subjectData, DBManipulator.getAllSubjectList());
                    break;

                case 8: // Диссертация
                    loadData(subjectData, DBManipulator.getAllSubjectList());
                    break;

                case 9: // Учебник;
                    loadData(subjectData, DBManipulator.getAllSubjectList());
                    break;
            }
        }

        private void libraryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (libraryCB.SelectedValue.ToString() != "InfLibCity.Library")
                currentLibId = (int)libraryCB.SelectedValue;
        }
    }
}
