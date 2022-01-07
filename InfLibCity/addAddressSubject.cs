﻿using System;
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
    }
}
