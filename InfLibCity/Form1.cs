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
        DataSet ds;
        MySqlDataAdapter adapter;
        MySqlCommandBuilder commandBuilder;
        
        
        string sql = "SELECT * FROM Users";
        public List<user> users; 

        public Form1()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            users = DBManipulator.getUsers();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

        }

        public void Authorization(bool run, user user = null)
        {
            if (!(user is null))
            {
                if (user.type == 0)
                    this.Text += String.Format(" Редактор: {0}", user.id.ToString()); 
                else
                    this.Text += String.Format(" Пользователь: {0}", user.id.ToString());
                this.enterMenuBtn.Visible = false;
                this.exitMenuBtn.Visible = true;
                this.appendMenu.Visible = true;
            }
        }

        private void exitMenuBtn_Click(object sender, EventArgs e)
        {
            this.Text = "InfLibCity";
            this.enterMenuBtn.Visible = true;
            this.exitMenuBtn.Visible = false;
            this.appendMenu.Visible = false;
        }

        private void enterButtonClick(object sender, EventArgs e)
        {
            Auth auth = new Auth(this);
            auth.Show();
            this.Enabled = false;
        }

        private void addLibrarianClick(object sender, EventArgs e)
        {

        }
    }
}
