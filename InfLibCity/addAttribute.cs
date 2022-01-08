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
        public addAttribute() {
            InitializeComponent();
        }

        public addAttribute(string nameTable, Form1 mf) {

            InitializeComponent();

            mainForm = mf;

            


        }


        private void typeLabel (string table) {

            if (table == "Authors") {
                label1.Text = "ФИО (И. И. Иванов):";
                this.Text = "Добавить нового автора";
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

        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void addAttribute_FormClosed(object sender, FormClosedEventArgs e) {
            mainForm.Enabled = true;
        }
    }
}
