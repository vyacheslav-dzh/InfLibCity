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
    public partial class chooseDates : Form
    {
        Form parentForm;

        public DateTime returnBeginDate { get; set; }
        public DateTime returnEndDate { get; set; }
        public chooseDates(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chooseBtn_Click(object sender, EventArgs e)
        {
            this.returnBeginDate = beginDate.Value;
            this.returnEndDate = endDate.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
