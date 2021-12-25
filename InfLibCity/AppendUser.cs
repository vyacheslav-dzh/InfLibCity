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
    public partial class AppendUser : Form
    {
        Form1 mainForm;

        public AppendUser()
        {
            InitializeComponent();
        }

        public AppendUser(Form1 mf) {

            InitializeComponent();
            mainForm = mf;
        }

        private void cancel_btn_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void AppendUser_FormClosed(object sender, FormClosedEventArgs e) {
            mainForm.Enabled = true;
        }

        private void rb_librarian_CheckedChanged(object sender, EventArgs e) {
            label1.Visible = false;
        }

        private void rb_people_CheckedChanged(object sender, EventArgs e) {
            label1.Visible = true;
        }

        private void creation_btn_Click(object sender, EventArgs e) {

            // Проверка на заполненность полей
            if (CreationErrorSerach())
                return;

            string regLogin = regloginField.Text;
            string regPass = regpassField.Text;

            string regFirstName = firstnameField.Text;
            string regLastName = lastnameField.Text;
            string regMiddleName = middlenameField.Text;

            int regType = 1;
            if (rb_librarian.Checked)
                regType = 0;
          
            DBManipulator.addUser(regType,
                                  regLogin,
                                  regPass,
                                  regFirstName,
                                  regLastName,
                                  regMiddleName);

            this.Close();
        }


        /// <summary>
        /// Функция для порверки правильности заполнености формы регистрации
        /// </summary>
        /// <returns>true - обнаружена ошибка; false - ошибок не обнаружено!</returns>
        private bool CreationErrorSerach() {
            if (regloginField.Text == "" || regpassField.Text == "") {
                MessageBox.Show("Не введены поля логин/пароль", "Ошибка");
                return true;
            }
            else if (firstnameField.Text == "" || lastnameField.Text == "" || middlenameField.Text == "") {
                MessageBox.Show("Не введены поля ФИО", "Ошибка");
                return true;
            }
            return false;
        }

    }
}
