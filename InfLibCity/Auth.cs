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
    public partial class Auth : Form
    {
        Form1 mainForm;

        public Auth()
        {
            InitializeComponent();
        }

        public Auth(Form1 mf)
        {
            InitializeComponent();
            mainForm = mf;
        }

        private void Auth_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }

        private void auth_bth_Click(object sender, EventArgs e)
        {
            enter();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            mainForm.Authorization(false);
            this.Close();
        }


        private void useridField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                enter();
            }
        }
        private void userPassField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                enter();
            }
        }

        private void enter()
        {
            List<user> users = DBManipulator.getUsers();
            if (useridField.Text != "" && userPassField.Text != "")
            {
                string login = useridField.Text;
                string pass = userPassField.Text;
                user newuser = new user(login, pass);
                int i = 0;
                while ((users[i].login != newuser.login || users[i].pass != newuser.pass) && i < users.Count - 1) i++;
                if (users[i].login == newuser.login && users[i].pass == newuser.pass)
                {
                    mainForm.currentUser = users[i];
                    mainForm.Authorization(true);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин/пароль", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Введите логин и/или пароль", "Ошибка");
            }
        }

        private void registration_btn_Click(object sender, EventArgs e) {

            AppendUser appendUser = new AppendUser(mainForm);
            appendUser.Show();
            this.Close();
            mainForm.Enabled = false;
        }
    }
}
