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
                            if (item.ToString().ToLower().IndexOf(word) != -1)
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
            int cellIndex = e.RowIndex;
            int user_id = (int)dataGridView1.Rows[cellIndex].Cells[0].Value;
            // Tuple<user, Person> clickedUser = function(user_id);
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
    }
}
