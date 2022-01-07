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
    public partial class addAddressSubject : Form
    {
        AppendSubject parentForm;
        public addAddressSubject(AppendSubject parentForm, user currentUser)
        {
            InitializeComponent();
            this.parentForm = parentForm;

            List<Library> libList = DBManipulator.getLibrariesNameList();
            if (libList.Count == 0) {
                MessageBox.Show("жопа 1!", "Ошибка");
                this.Close();
            }

            libNameCB.DataSource = libList;
            libNameCB.DisplayMember = "libraryName";
            libNameCB.ValueMember = "id";

            List<Room> roomsList = DBManipulator.getRoomsList(libList[0].id);
            roomNumberCB.DataSource = roomsList;
            roomNumberCB.DisplayMember = "number";
            roomNumberCB.ValueMember = "id";

            List<Shevilings> shevilingsList = DBManipulator.getShevilingsList(roomsList[0].id);
            shelfNumberCB.DataSource = shevilingsList;
            shelfNumberCB.DisplayMember = "number";
            shelfNumberCB.ValueMember = "id";

            List<Shelves> shelvesList = DBManipulator.getShelvesList(shevilingsList[0].id);
            shelvingNumberCB.DataSource = shelvesList;
            shelvingNumberCB.DisplayMember = "number";
            shelvingNumberCB.ValueMember = "id";

            //shelvingNumberCB

            // проверка прав для разблокирования полей
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addAddressSubject_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Address address;
        }

        private void libNameCB_SelectedIndexChanged(object sender, EventArgs e) {

            if (libNameCB.SelectedValue.ToString() != "InfLibCity.Library") {
                //cB_Rooms.Enabled = true;
                //string id = cB_Libraries.SelectedValue.ToString();
                List<Room> list = DBManipulator.getRoomsList((int)libNameCB.SelectedValue);
                roomNumberCB.DataSource = list;
                roomNumberCB.DisplayMember = "number";
                roomNumberCB.ValueMember = "id";
            }

        }

        private void roomNumberCB_SelectedIndexChanged(object sender, EventArgs e) {

            if (roomNumberCB.SelectedValue.ToString() != "InfLibCity.Library") {
                //cB_Rooms.Enabled = true;
                //string id = cB_Libraries.SelectedValue.ToString();
                List<Shevilings> list = DBManipulator.getShevilingsList((int)roomNumberCB.SelectedValue);
                shelfNumberCB.DataSource = list;
                shelfNumberCB.DisplayMember = "number";
                shelfNumberCB.ValueMember = "id";
            }

        }

        private void shelvingNumberCB_SelectedIndexChanged(object sender, EventArgs e) {

            if (shelfNumberCB.SelectedValue.ToString() != "InfLibCity.Library") {
                //cB_Rooms.Enabled = true;
                //string id = cB_Libraries.SelectedValue.ToString();
                List<Shelves> list = DBManipulator.getShelvesList((int)shelfNumberCB.SelectedValue);
                shelvingNumberCB.DataSource = list;
                shelvingNumberCB.DisplayMember = "number";
                shelvingNumberCB.ValueMember = "id";
            }

        }
    }
}
