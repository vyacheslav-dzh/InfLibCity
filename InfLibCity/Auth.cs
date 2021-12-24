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
            // Проверка данных будет тут
            List<user> users = mainForm.users;

            int id = Int32.Parse(useridField.Text);
            string pass = userPassField.Text;
            user currentUser = new user(id, pass);

            int i = 0;
            while(users[i] != currentUser) i++;
            if (users[i] == currentUser)
            {
                mainForm.Authorization(true, users[i]);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин/пароль", "Ошибка");
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            mainForm.Authorization(false);
            this.Close();
        }
    }
}
