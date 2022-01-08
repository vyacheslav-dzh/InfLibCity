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
        Form parentForm;
        ListBox addressField;
        public addAddressSubject(Form parentForm, ListBox addressField, user currentUser)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.addressField = addressField;
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
            shelvingNumberCB.DataSource = shevilingsList;
            shelvingNumberCB.DisplayMember = "number";
            shelvingNumberCB.ValueMember = "id";

            List<Shelves> shelvesList = DBManipulator.getShelvesList(shevilingsList[0].id);
            shelfNumberCB.DataSource = shelvesList;
            shelfNumberCB.DisplayMember = "number";
            shelfNumberCB.ValueMember = "id";

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
            Address address = new Address(
                lib: new Library((int)libNameCB.SelectedValue, libNameCB.Text),
                room: new Room((int)roomNumberCB.SelectedValue, (int)libNameCB.SelectedValue, Int32.Parse(roomNumberCB.Text)),
                shevling: new Shevilings((int)shelvingNumberCB.SelectedValue, (int)roomNumberCB.SelectedValue, Int32.Parse(shelvingNumberCB.Text)),
                shelf: new Shelves((int)shelfNumberCB.SelectedValue, (int)shelvingNumberCB.SelectedValue, Int32.Parse(shelfNumberCB.Text))
                );
            Tuple<int, string, Address> tuple = new Tuple<int, string, Address>(address.shelf_id, address.text, address);
            List<Tuple<int, string, Address>> tupleList = new List<Tuple<int, string, Address>>() { tuple };
            addressField.DataSource = tupleList;
            addressField.DisplayMember = "item2";
            addressField.ValueMember = "item1";

            this.Close();
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

            if (roomNumberCB.SelectedValue.ToString() != "InfLibCity.Room") {
                //cB_Rooms.Enabled = true;
                //string id = cB_Libraries.SelectedValue.ToString();
                List<Shelves> list = DBManipulator.getShelvesList((int)roomNumberCB.SelectedValue);
                shelvingNumberCB.DataSource = list;
                shelvingNumberCB.DisplayMember = "number";
                shelvingNumberCB.ValueMember = "id";
                
            }

        }

        private void shelvingNumberCB_SelectedIndexChanged(object sender, EventArgs e) {

            if (shelvingNumberCB.SelectedValue.ToString() != "InfLibCity.Shevilings") {
                //cB_Rooms.Enabled = true;
                //string id = cB_Libraries.SelectedValue.ToString();
                List<Shevilings> list = DBManipulator.getShevilingsList((int)shelvingNumberCB.SelectedValue);
                shelfNumberCB.DataSource = list;
                shelfNumberCB.DisplayMember = "number";
                shelfNumberCB.ValueMember = "id";
            }

        }
    }
}
