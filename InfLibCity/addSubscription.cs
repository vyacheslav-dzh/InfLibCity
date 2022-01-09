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

        public addSubscription(Form parentForm, user currentUser)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.currentUser = currentUser;

            loadData(peopleData, DBManipulator.getPeopleList());
            loadData(subjectData, DBManipulator.getAllSubjectList());
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
    }
}
