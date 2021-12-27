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
        public AppendSubject()
        {
            InitializeComponent();
        }

        public AppendSubject(Form1 mf)
        {
            InitializeComponent();
            mainForm = mf;
        }

        private void AppendSubject_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Enabled = true;
        }

        private void subjectTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (subjectTypeCB.SelectedIndex)
            {
                case 0: // Газета
                    authorB.Visible = false;
                    genreB.Visible = false;
                    themeB.Visible = false;
                    diciplinesB.Visible = false;
                    typeB.Visible = true;

                    // typeCB.Items.AddRange(new List<string>());
                    break;
                case 1: // Диссертация
                    authorB.Visible = false;
                    genreB.Visible = false;
                    themeB.Visible = true;
                    diciplinesB.Visible = false;
                    typeB.Visible = true;

                    // typeCB.Items.AddRange(new List<string>());
                    break;
                case 2: //Журнал
                    authorB.Visible = false;
                    genreB.Visible = false;
                    themeB.Visible = true;
                    diciplinesB.Visible = false;
                    typeB.Visible = true;

                    object[] items =
                    {
                        "1 тип",
                        "2 тип",
                        "3 тип"
                    }; // Здесь запрос для соответствующего типа
                    typeCB.Items.AddRange(items);
                    break;
                case 3: //Книга
                    authorB.Visible = true;
                    genreB.Visible = true;
                    themeB.Visible = false;
                    diciplinesB.Visible = false;
                    typeB.Visible = false;

                    // typeCB.Items.AddRange(new List<string>());
                    break;
                case 4: //Реферат
                    authorB.Visible = true;
                    genreB.Visible = false;
                    themeB.Visible = true;
                    diciplinesB.Visible = true;
                    typeB.Visible = false;

                    // typeCB.Items.AddRange(new List<string>());
                    break;
                case 5: //Сборник докладов
                    authorB.Visible = false;
                    genreB.Visible = false;
                    themeB.Visible = true;
                    diciplinesB.Visible = true;
                    typeB.Visible = false;  //?

                    // typeCB.Items.AddRange(new List<string>());
                    break;
                case 6: //Сборник статей
                    authorB.Visible = false;
                    genreB.Visible = false;
                    themeB.Visible = true;
                    diciplinesB.Visible = false;
                    typeB.Visible = false;

                    // typeCB.Items.AddRange(new List<string>());
                    break; 
                case 7: //Сборник стихов
                    authorB.Visible = false;
                    genreB.Visible = true;
                    themeB.Visible = true;
                    diciplinesB.Visible = false;
                    typeB.Visible = false;

                    // typeCB.Items.AddRange(new List<string>());
                    break;
                case 8: //Сборник тезисов
                    authorB.Visible = false;
                    genreB.Visible = false;
                    themeB.Visible = true;
                    diciplinesB.Visible = false;
                    typeB.Visible = false;

                    // typeCB.Items.AddRange(new List<string>());
                    break;
                case 9: //Учебник
                    authorB.Visible = true;
                    genreB.Visible = false;
                    themeB.Visible = false;
                    diciplinesB.Visible = true;
                    typeB.Visible = false;

                    // typeCB.Items.AddRange(new List<string>());
                    break;

            }
        }
    }
}