
namespace InfLibCity
{
    partial class AppendUser
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
            this.cancel_btn = new System.Windows.Forms.Button();
            this.regloginField = new System.Windows.Forms.TextBox();
            this.regpassField = new System.Windows.Forms.TextBox();
            this.label_login = new System.Windows.Forms.Label();
            this.label_pass = new System.Windows.Forms.Label();
            this.rb_people = new System.Windows.Forms.RadioButton();
            this.rb_librarian = new System.Windows.Forms.RadioButton();
            this.creation_btn = new System.Windows.Forms.Button();
            this.firstnameField = new System.Windows.Forms.TextBox();
            this.lastnameField = new System.Windows.Forms.TextBox();
            this.middlenameField = new System.Windows.Forms.TextBox();
            this.label_first_name = new System.Windows.Forms.Label();
            this.label_last_name = new System.Windows.Forms.Label();
            this.label_middle_name = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(492, 305);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(127, 36);
            this.cancel_btn.TabIndex = 0;
            this.cancel_btn.Text = "Отмена";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // regloginField
            // 
            this.regloginField.Location = new System.Drawing.Point(74, 20);
            this.regloginField.Name = "regloginField";
            this.regloginField.Size = new System.Drawing.Size(100, 20);
            this.regloginField.TabIndex = 1;
            // 
            // regpassField
            // 
            this.regpassField.Location = new System.Drawing.Point(244, 20);
            this.regpassField.Name = "regpassField";
            this.regpassField.Size = new System.Drawing.Size(100, 20);
            this.regpassField.TabIndex = 2;
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Location = new System.Drawing.Point(27, 23);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(41, 13);
            this.label_login.TabIndex = 3;
            this.label_login.Text = "Логин:";
            // 
            // label_pass
            // 
            this.label_pass.AutoSize = true;
            this.label_pass.Location = new System.Drawing.Point(190, 23);
            this.label_pass.Name = "label_pass";
            this.label_pass.Size = new System.Drawing.Size(48, 13);
            this.label_pass.TabIndex = 4;
            this.label_pass.Text = "Пароль:";
            // 
            // rb_people
            // 
            this.rb_people.AutoSize = true;
            this.rb_people.Checked = true;
            this.rb_people.Location = new System.Drawing.Point(30, 68);
            this.rb_people.Name = "rb_people";
            this.rb_people.Size = new System.Drawing.Size(73, 17);
            this.rb_people.TabIndex = 5;
            this.rb_people.TabStop = true;
            this.rb_people.Text = "Читатель";
            this.rb_people.UseVisualStyleBackColor = true;
            this.rb_people.CheckedChanged += new System.EventHandler(this.rb_people_CheckedChanged);
            // 
            // rb_librarian
            // 
            this.rb_librarian.AutoSize = true;
            this.rb_librarian.Location = new System.Drawing.Point(141, 68);
            this.rb_librarian.Name = "rb_librarian";
            this.rb_librarian.Size = new System.Drawing.Size(97, 17);
            this.rb_librarian.TabIndex = 6;
            this.rb_librarian.Text = "Библиотекарь";
            this.rb_librarian.UseVisualStyleBackColor = true;
            this.rb_librarian.CheckedChanged += new System.EventHandler(this.rb_librarian_CheckedChanged);
            // 
            // creation_btn
            // 
            this.creation_btn.Location = new System.Drawing.Point(367, 305);
            this.creation_btn.Name = "creation_btn";
            this.creation_btn.Size = new System.Drawing.Size(119, 36);
            this.creation_btn.TabIndex = 7;
            this.creation_btn.Text = "Создать";
            this.creation_btn.UseVisualStyleBackColor = true;
            this.creation_btn.Click += new System.EventHandler(this.creation_btn_Click);
            // 
            // firstnameField
            // 
            this.firstnameField.Location = new System.Drawing.Point(89, 114);
            this.firstnameField.Name = "firstnameField";
            this.firstnameField.Size = new System.Drawing.Size(100, 20);
            this.firstnameField.TabIndex = 8;
            // 
            // lastnameField
            // 
            this.lastnameField.Location = new System.Drawing.Point(89, 141);
            this.lastnameField.Name = "lastnameField";
            this.lastnameField.Size = new System.Drawing.Size(100, 20);
            this.lastnameField.TabIndex = 9;
            // 
            // middlenameField
            // 
            this.middlenameField.Location = new System.Drawing.Point(89, 166);
            this.middlenameField.Name = "middlenameField";
            this.middlenameField.Size = new System.Drawing.Size(100, 20);
            this.middlenameField.TabIndex = 10;
            // 
            // label_first_name
            // 
            this.label_first_name.AutoSize = true;
            this.label_first_name.Location = new System.Drawing.Point(27, 117);
            this.label_first_name.Name = "label_first_name";
            this.label_first_name.Size = new System.Drawing.Size(59, 13);
            this.label_first_name.TabIndex = 11;
            this.label_first_name.Text = "Фамилия:";
            // 
            // label_last_name
            // 
            this.label_last_name.AutoSize = true;
            this.label_last_name.Location = new System.Drawing.Point(27, 144);
            this.label_last_name.Name = "label_last_name";
            this.label_last_name.Size = new System.Drawing.Size(32, 13);
            this.label_last_name.TabIndex = 12;
            this.label_last_name.Text = "Имя:";
            // 
            // label_middle_name
            // 
            this.label_middle_name.AutoSize = true;
            this.label_middle_name.Location = new System.Drawing.Point(27, 169);
            this.label_middle_name.Name = "label_middle_name";
            this.label_middle_name.Size = new System.Drawing.Size(57, 13);
            this.label_middle_name.TabIndex = 13;
            this.label_middle_name.Text = "Отчество:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(219, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 95);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // AppendUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 354);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_middle_name);
            this.Controls.Add(this.label_last_name);
            this.Controls.Add(this.label_first_name);
            this.Controls.Add(this.middlenameField);
            this.Controls.Add(this.lastnameField);
            this.Controls.Add(this.firstnameField);
            this.Controls.Add(this.creation_btn);
            this.Controls.Add(this.rb_librarian);
            this.Controls.Add(this.rb_people);
            this.Controls.Add(this.label_pass);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.regpassField);
            this.Controls.Add(this.regloginField);
            this.Controls.Add(this.cancel_btn);
            this.Name = "AppendUser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно регистрации";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AppendUser_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TextBox regloginField;
        private System.Windows.Forms.TextBox regpassField;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Label label_pass;
        private System.Windows.Forms.RadioButton rb_people;
        private System.Windows.Forms.RadioButton rb_librarian;
        private System.Windows.Forms.Button creation_btn;
        private System.Windows.Forms.TextBox firstnameField;
        private System.Windows.Forms.TextBox lastnameField;
        private System.Windows.Forms.TextBox middlenameField;
        private System.Windows.Forms.Label label_first_name;
        private System.Windows.Forms.Label label_last_name;
        private System.Windows.Forms.Label label_middle_name;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}