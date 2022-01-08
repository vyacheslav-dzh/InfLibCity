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
    public partial class AppendSubject : Form
    {

        Form1 mainForm;
        user currentUser;

        public AppendSubject(Form1 mf, user currentUser)
        {
            InitializeComponent();
            mainForm = mf;
            this.currentUser = currentUser;

            Dictionary<int, string> publishers = getDataDict("Publishers");

            publisherCB.DataSource = new BindingSource(publishers, null);
            publisherCB.DisplayMember = "Value";
            publisherCB.ValueMember = "Key";
        }

        private void AppendSubject_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }

        private void typeAddWorkCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            authorsLB.DataSource = null;
            genresLB.DataSource = null;
            
            diciplineCb.DataSource = null;
            typeCb.DataSource = null;

            switch (typeAddWorkCB.SelectedIndex)
            {
                case 0: // Книга
                    authorBox.Enabled = true;
                    genresBox.Enabled = true;
                    diciplineBox.Enabled = false;
                    typeBox.Enabled = false;
                    break;

                case 1: // Сборник стихов
                    goto case 0;

                case 2: // Газета
                    authorBox.Enabled = false;
                    genresBox.Enabled = false;
                    diciplineBox.Enabled = false;
                    typeBox.Enabled = true;

                    typeCb.DataSource = new BindingSource(getDataDict("MagazineNews"), null);
                    typeCb.DisplayMember = "Value";
                    typeCb.ValueMember = "Key";

                    break;

                case 3: // Журнал
                    goto case 2;

                case 4: // Реферат
                    authorBox.Enabled = false;
                    genresBox.Enabled = false;
                    diciplineBox.Enabled = true;
                    typeBox.Enabled = false;

                    diciplineCb.DataSource = new BindingSource(getDataDict("Disciplines"), null);
                    diciplineCb.DisplayMember = "Value";
                    diciplineCb.ValueMember = "Key";
                    break;
                    
                case 5: // Сборник докладов
                    goto case 4;

                case 6: // Сборник тезисов
                    goto case 4;

                case 7: // Статья
                    authorBox.Enabled = false;
                    genresBox.Enabled = false;
                    diciplineBox.Enabled = false;
                    typeBox.Enabled = true;

                    typeCb.DataSource = new BindingSource(getDataDict("Article"), null);
                    typeCb.DisplayMember = "Value";
                    typeCb.ValueMember = "Key";
                    break;                

                case 8: // Диссертация
                    authorBox.Enabled = false;
                    genresBox.Enabled = false;
                    diciplineBox.Enabled = true;
                    typeBox.Enabled = true;

                    diciplineCb.DataSource = new BindingSource(getDataDict("Disciplines"), null);
                    diciplineCb.DisplayMember = "Value";
                    diciplineCb.ValueMember = "Key";

                    typeCb.DataSource = new BindingSource(getDataDict("Dissertation"), null);
                    typeCb.DisplayMember = "Value";
                    typeCb.ValueMember = "Key";
                    break;

                case 9: // Учебник
                    authorBox.Enabled = true;
                    genresBox.Enabled = false;
                    diciplineBox.Enabled = true;
                    typeBox.Enabled = false;

                    diciplineCb.DataSource = new BindingSource(getDataDict("Disciplines"), null);
                    diciplineCb.DisplayMember = "Value";
                    diciplineCb.ValueMember = "Key";
                    break;
            }
        }

        private void addAuthorBtn_Click(object sender, EventArgs e)
        {
            addAuthorsGenres addAuthorsGenres = new addAuthorsGenres(this, authorsLB);
            addAuthorsGenres.Show();
            this.Enabled = false;
        }

        private void addGenreBtn_Click(object sender, EventArgs e)
        {
            addAuthorsGenres addAuthorsGenres = new addAuthorsGenres(this, genresLB, typeAddWorkCB.SelectedIndex == 1);
            addAuthorsGenres.Show();
            this.Enabled = false;
        }

        private Dictionary<int, string> getDataDict(string tableName)
        {
            DataSet ds = DBManipulator.getSubjectAttributeDict(tableName);

            Dictionary<int, string> dict = new Dictionary<int, string>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dict.Add((int)row.ItemArray[0], row.ItemArray[1].ToString());
            }

            return dict;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delAuthorBtn_Click(object sender, EventArgs e)
        {
            delGenreOrAuthor(sender);
        }

        private void delGenreBtn_Click(object sender, EventArgs e)
        {
            delGenreOrAuthor(sender);
        }

        private void delGenreOrAuthor(object sender)
        {
            ListBox listBox;
            string text;
            if ((sender as Button).Name == "delAuthorBtn")
            {
                listBox = authorsLB;
                text = "автора";
            }
            else if ((sender as Button).Name == "delGenreBtn")
            {
                listBox = genresLB;
                text = "жанра";
            }
            else throw new Exception("WTF");

            if (listBox.SelectedItems.Count > 0)
            {
                var newDataList = (listBox.DataSource as BindingSource).List;
                Dictionary<int, string> newData = new Dictionary<int, string>();
                foreach (KeyValuePair<int, string> item in listBox.Items)
                {
                    if(!listBox.SelectedItems.Contains(item))
                    {
                        newData.Add(item.Key, item.Value);
                    }
                }
                listBox.DataSource = new BindingSource(newData, null);
                listBox.DisplayMember = "Value";
                listBox.ValueMember = "Key";
            }
            else
            {
                MessageBox.Show(String.Format("Не выбрано ни одного {0}.", text), "Ошибка");
            }
        }

        private void apppendBtn_Click(object sender, EventArgs e)
        {
            if (!checkFields()) return;

            Subject.attributesClass attributes = new Subject.attributesClass();

            switch (typeAddWorkCB.SelectedIndex)
            {
                case 0: // Книга
                    attributes.author_id = new List<int>();
                    attributes.genre_id = new List<int>();
                    foreach (KeyValuePair<int,string> item in authorsLB.Items)
                    {
                        attributes.author_id.Add(item.Key);
                    }
                    foreach (KeyValuePair<int, string> item in genresLB.Items)
                    {
                        attributes.genre_id.Add(item.Key);
                    }
                    break;
                case 1: // Сборник стихов
                    goto case 0;

                case 2: // Газета
                    attributes.type_id = (int)typeCb.SelectedValue;
                    break;
                case 3: // Журнал
                    goto case 2;

                case 4: // Реферат
                    attributes.discipline_id = (int)diciplineCb.SelectedValue;
                    break;
                case 5: // Сборник докладов
                    goto case 4;
                case 6: // Сборник тезисов
                    goto case 4;

                case 7: // Статья
                    goto case 2;

                case 8: // Диссертация
                    attributes.discipline_id = (int)diciplineCb.SelectedValue;
                    attributes.type_id = (int)typeCb.SelectedValue;
                    break;

                case 9: // Учебник
                    foreach (KeyValuePair<int, string> item in authorsLB.Items)
                    {
                        attributes.author_id.Add(item.Key);
                    }
                    goto case 4;
            }

            int shelf_id;

            if (addressField.SelectedValue is null)
                shelf_id = -1;
            else
                shelf_id = (int)addressField.SelectedValue;

            Subject newSubject = new Subject(
                id: -1,
                shelf_id: shelf_id,
                publisher_id: (int)publisherCB.SelectedValue,
                name: nameField.Text,
                year: Int32.Parse(yearWrittingTB.Text),
                isReadOnly: isReadOnlyChB.Checked,
                quantity: (int)quantityNUD.Value,
                type: typeAddWorkCB.SelectedIndex,
                yearWriteOff: dateWrittigOffP.Value.ToString("yyyy-MM-dd"),
                isWriteOff: false,
                attributes: attributes
                ) ;
            DBManipulator.addSubject(newSubject);

            this.Close();
        }

        private bool checkFields()
        {
            string errors = String.Empty;
            if (nameField.Text == String.Empty)
                errors += String.Format("\nПоле \"{0}\" пустое", nameLabel.Text);
            if (yearWrittingTB.Text == String.Empty)
                errors += String.Format("\nПоле \"{0}\" пустое", yearWrittenfLabel.Text);
            else if (!int.TryParse(yearWrittingTB.Text, out int year))
            {
                errors += String.Format("\n{0} не является годом. Нужно вводить год только цифрами. Пример формата: YYYY", yearWrittingTB.Text);
                yearWrittingTB.Text = String.Empty;
            }
            if (quantityNUD.Value == 0)
                errors += "\nКол-во должно быть больше 0";
            if (typeAddWorkCB.SelectedIndex == -1)
                errors += String.Format("\nПоле \"{0}\" пустое", typeAddWorkLabel.Text);
            
            if (errors == String.Empty)
                return true;
            else
            {
                MessageBox.Show(String.Format("Не удалось добавить объект по следующим причинам:{0}", errors), "Ошибка");
                return false;
            }
        }

        private void addAddressBtn_Click(object sender, EventArgs e)
        {
            addAddressSubject addAddressSubject = new addAddressSubject(this, addressField, currentUser);
            addAddressSubject.Show();
            this.Enabled = false;
        }
    }
}