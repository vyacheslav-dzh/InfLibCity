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

        public AppendSubject(Form1 mf, user currentUser)
        {
            InitializeComponent();
            mainForm = mf;


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
            authorsLB.Items.Clear();
            genresLB.Items.Clear();
            
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
            addAuthorsGenres addAuthorsGenres = new addAuthorsGenres(this, genresLB, typeAddWorkCB.SelectedIndex == 7);
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
                foreach (var item in listBox.SelectedItems)
                {
                    listBox.Items.Remove(item);
                }
            }
            else
            {
                MessageBox.Show(String.Format("Не выбрано ни одного {0}.", text), "Ошибка");
            }
        }

        private void apppendBtn_Click(object sender, EventArgs e)
        {
            Subject newSubject;
            Subject.attributesClass attributes = new Subject.attributesClass();

            switch (typeAddWorkCB.SelectedIndex)
            {
                case 0: // Книга
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
                    attributes.type_id = typeCb.SelectedIndex;
                    break;
                case 3: // Журнал
                    goto case 2;

                case 4: // Реферат
                    attributes.discipline_id = diciplineCb.SelectedIndex;
                    break;
                case 5: // Сборник докладов
                    break;
                case 6: // Сборник тезисов
                    break;
                case 7: // Статья
                    break;
                case 8: // Диссертация
                    break;
                case 9: // Учебник
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addAddressSubject addAddressSubject = new addAddressSubject(this, currentUser);
            addAddressSubject.Show();
            this.Enabled = false;
        }
    }
}