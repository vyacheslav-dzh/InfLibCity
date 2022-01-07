
namespace InfLibCity
{
    partial class addAddressSubject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.libNameCB = new System.Windows.Forms.ComboBox();
            this.roomNumberCB = new System.Windows.Forms.ComboBox();
            this.shelvingNumberCB = new System.Windows.Forms.ComboBox();
            this.shelfNumberCB = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Библиотека:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Номер зала:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Номер стелажа:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Номер полки:";
            // 
            // libNameCB
            // 
            this.libNameCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.libNameCB.Enabled = false;
            this.libNameCB.FormattingEnabled = true;
            this.libNameCB.Location = new System.Drawing.Point(108, 6);
            this.libNameCB.Name = "libNameCB";
            this.libNameCB.Size = new System.Drawing.Size(163, 21);
            this.libNameCB.TabIndex = 8;
            // 
            // roomNumberCB
            // 
            this.roomNumberCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomNumberCB.Enabled = false;
            this.roomNumberCB.FormattingEnabled = true;
            this.roomNumberCB.Location = new System.Drawing.Point(108, 36);
            this.roomNumberCB.Name = "roomNumberCB";
            this.roomNumberCB.Size = new System.Drawing.Size(163, 21);
            this.roomNumberCB.TabIndex = 9;
            // 
            // shelvingNumberCB
            // 
            this.shelvingNumberCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shelvingNumberCB.FormattingEnabled = true;
            this.shelvingNumberCB.Location = new System.Drawing.Point(108, 66);
            this.shelvingNumberCB.Name = "shelvingNumberCB";
            this.shelvingNumberCB.Size = new System.Drawing.Size(163, 21);
            this.shelvingNumberCB.TabIndex = 10;
            // 
            // shelfNumberCB
            // 
            this.shelfNumberCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shelfNumberCB.FormattingEnabled = true;
            this.shelfNumberCB.Location = new System.Drawing.Point(108, 92);
            this.shelfNumberCB.Name = "shelfNumberCB";
            this.shelfNumberCB.Size = new System.Drawing.Size(163, 21);
            this.shelfNumberCB.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // addAddressSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 160);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.shelfNumberCB);
            this.Controls.Add(this.shelvingNumberCB);
            this.Controls.Add(this.roomNumberCB);
            this.Controls.Add(this.libNameCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "addAddressSubject";
            this.Text = "Добавление адреса";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.addAddressSubject_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox libNameCB;
        private System.Windows.Forms.ComboBox roomNumberCB;
        private System.Windows.Forms.ComboBox shelvingNumberCB;
        private System.Windows.Forms.ComboBox shelfNumberCB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}