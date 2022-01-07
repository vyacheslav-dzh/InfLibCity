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
    public partial class addAuthorsGenres : Form
    {
        DataSet currentData;
        ListBox listBox;

        public addAuthorsGenres(ListBox formListBox)
        {
            InitializeComponent();
            listBox = formListBox;
            if (listBox.Name == "authorLb")
                this.Text = "Добавление авторов";
            else this.Text = "Добавление жанров";
            
        }

        private void searchField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                searchBtn.PerformClick();
            }
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
                            if (item.ToString().ToLower().IndexOf(word.ToLower()) != -1)
                                count++;
                        }
                    }
                    if (count > 0) dt.Rows.Add(row.ItemArray.Clone() as object[]);
                }
                newData.Tables.Add(dt);
                authorsGenresView.ClearSelection();
                authorsGenresView.DataSource = newData.Tables[0];
            }
            else
            {
                authorsGenresView.DataSource = currentData.Tables[0];
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (authorsGenresView.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in authorsGenresView.SelectedRows)
                {
                    string item = row.Cells[1].Value.ToString();
                    if (!(listBox.Items.Contains(item)))
                        listBox.Items.Add(item);
                }
            }
            string sbj;

            if (listBox.Name == "authorLb")
                sbj = "Автор(ы)";
            else sbj = "Жанр(ы)";

            var result = MessageBox.Show(String.Format("{0} успешно добавлены. Продолжить?", sbj), "Уведомление", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                this.Close();
        }
    }
}
