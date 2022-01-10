using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfLibCity {
    public partial class addAttribute : Form {
        

        Form1 mainForm;
        string tableName;

        public addAttribute() {
            InitializeComponent();
        }

        public addAttribute(Form1 mf, string nameTable) {

            InitializeComponent();

            mainForm = mf;

            typeLabel(nameTable);

            tableName = nameTable;

        }


        private void typeLabel (string table) {

            if (table == "Authors") {
                label1.Text = "ФИО:";
                this.Text = "Добавить нового автора (И.И. Иванов)";
            }
            else if (table == "Article") {
                label1.Text = "Название:";
                this.Text = "Добавить новый тип статьи";
            }
            else if (table == "BookGenres") {
                label1.Text = "Название:";
                this.Text = "Добавить новый жанр книг";
            }
            else if (table == "PoemGenres") {
                label1.Text = "Название:";
                this.Text = "Добавить новый жанр сборников стихотворений";
            }
            else if (table == "Publishers") {
                label1.Text = "Название:";
                this.Text = "Добавить нового издателя";
            }
            else if (table == "MagazineNews") {
                label1.Text = "Название:";
                this.Text = "Добавить новый вид журналов/газет";
            }
            else if (table == "Disciplines") {
                label1.Text = "Название:";
                this.Text = "Добавить новую дисциплину";
            }
            else if (table == "Dissertation") {
                label1.Text = "Название:";
                this.Text = "Добавить новый вид диссертации";
            }

        }


        private void appendButton_Click(object sender, EventArgs e) {

            if(nameField.Text == String.Empty) {
                MessageBox.Show("Поле ввода не заполнено!", "Ошибка");
                return;
            }

            DBManipulator.addAttribute(tableName, nameField.Text);
            this.Close();

        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Close();
            mainForm.Enabled = true;
        }

        private void addAttribute_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.refreshTable();
            mainForm.Enabled = true;
        }
    }
}
