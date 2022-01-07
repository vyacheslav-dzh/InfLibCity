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
        AppendSubject parentForm;

        public addAuthorsGenres(AppendSubject parentForm, ListBox formListBox, bool poems = false)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            listBox = formListBox;
            if (listBox.Name == "authorsLB")
            {
                this.Text = "Добавление авторов";
                currentData = DBManipulator.getSubjectAttributeDict("Authors");
            }
            else if (listBox.Name == "genresLB")
            {
                this.Text = "Добавление жанров";
                
                if (poems) currentData = DBManipulator.getSubjectAttributeDict("PoemGenres");
                else currentData = DBManipulator.getSubjectAttributeDict("BookGenres");
            }
            else
            {
                MessageBox.Show("Таблица не найдена! Возможно проблема с соеденением.", "Ошибка");
            }

            authorsGenresView.DataSource = currentData.Tables[0];

            foreach (DataGridViewColumn column in authorsGenresView.Columns)
            {
                if (column.HeaderText.Contains("id"))
                    authorsGenresView.Columns[column.HeaderText].Visible = false;
            }
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
            Dictionary<int, string> data = new Dictionary<int, string>();
            if (authorsGenresView.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in authorsGenresView.SelectedRows)
                {
                    data.Add((int)row.Cells[0].Value, row.Cells[1].Value.ToString());
                }
                
                if (!(listBox.DataSource is null))
                {
                    Dictionary<int, string> newData = new Dictionary<int, string>();
                    var oldDataList = (listBox.DataSource as BindingSource).List;
                    foreach(KeyValuePair<int, string> item in oldDataList)
                    {
                        newData.Add(item.Key, item.Value);
                    }

                    data = data.Union(newData).ToDictionary(x => x.Key, x => x.Value);
                }

                listBox.DataSource = new BindingSource(data, null);
                listBox.DisplayMember = "Value";
                listBox.ValueMember = "Key";

                string sbj;
                if (listBox.Name == "authorsLB")
                    sbj = "Автор(ы)";
                else if (listBox.Name == "genresLB")
                    sbj = "Жанр(ы)";
                else throw new Exception("WTF");

                var result = MessageBox.Show(String.Format("{0} успешно добавлены. Продолжить?", sbj), "Уведомление", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    this.Close();
            }
            else
            {
                MessageBox.Show("Сначала выберите одно или несколько полей для добавления.", "Внимание");
            }
        }

        private void addAuthorsGenres_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Enabled = true;
            parentForm.Select();
        }
    }
}
