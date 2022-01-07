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
        public addAddressSubject(AppendSubject parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
