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

        object[] authors;
        object[] genres;
        object[] diciplines;
        object[] types;

        public AppendSubject(Form1 mf)
        {
            InitializeComponent();
            mainForm = mf;
        }

        private void AppendSubject_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }

        private void typeAddWorkCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            authorLB.Items.Clear();
            genresLB.Items.Clear();

            diciplineCb.Items.Clear();
            typeCb.Items.Clear();

            switch (typeAddWorkCB.SelectedIndex)
            {
                case 0: // Газета
                    authorBox.Enabled = false;
                    genresBox.Enabled = false;
                    diciplineBox.Enabled = false;
                    typeBox.Enabled = true;

                    // typeCb.Items.AddRange(DBManipulator.function());

                    break;

                case 1: // Диссертация
                    authorBox.Enabled = false;
                    genresBox.Enabled = false;
                    diciplineBox.Enabled = true;
                    typeBox.Enabled = true;

                    // diciplineCb.Items.AddRange(DBManipulator.function());

                    break;

                case 2: // Журнал
                    goto case 0;

                case 3: // Книга
                    authorBox.Enabled = true;
                    genresBox.Enabled = true;
                    diciplineBox.Enabled = false;
                    typeBox.Enabled = false;

                    break;

                case 4: // Реферат
                    authorBox.Enabled = false;
                    genresBox.Enabled = false;
                    diciplineBox.Enabled = true;
                    typeBox.Enabled = false;

                    // diciplineCb.Items.AddRange(DBManipulator.function());

                    break;
                    
                case 5: // Сборник докладов
                    goto case 4;

                case 6: // Сборник статей
                    goto case 4;

                case 7: // Сборник стихов
                    goto case 3;
                     
                case 8: // Сборник тезисов
                    goto case 4;

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

        }
    }
}