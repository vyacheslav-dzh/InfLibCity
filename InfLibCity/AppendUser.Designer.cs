
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
            this.atrBox = new System.Windows.Forms.GroupBox();
            this.personTypeBox = new System.Windows.Forms.GroupBox();
            this.schoolBoyRB = new System.Windows.Forms.RadioButton();
            this.teacherRB = new System.Windows.Forms.RadioButton();
            this.studentRB = new System.Windows.Forms.RadioButton();
            this.scientistRB = new System.Windows.Forms.RadioButton();
            this.workerRB = new System.Windows.Forms.RadioButton();
            this.otherRB = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.atrBox.SuspendLayout();
            this.personTypeBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(130, 206);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(79, 36);
            this.cancel_btn.TabIndex = 0;
            this.cancel_btn.Text = "Отмена";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // regloginField
            // 
            this.regloginField.Location = new System.Drawing.Point(95, 20);
            this.regloginField.Name = "regloginField";
            this.regloginField.Size = new System.Drawing.Size(114, 20);
            this.regloginField.TabIndex = 1;
            // 
            // regpassField
            // 
            this.regpassField.Location = new System.Drawing.Point(95, 46);
            this.regpassField.Name = "regpassField";
            this.regpassField.Size = new System.Drawing.Size(114, 20);
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
            this.label_pass.Location = new System.Drawing.Point(27, 49);
            this.label_pass.Name = "label_pass";
            this.label_pass.Size = new System.Drawing.Size(48, 13);
            this.label_pass.TabIndex = 4;
            this.label_pass.Text = "Пароль:";
            // 
            // rb_people
            // 
            this.rb_people.AutoSize = true;
            this.rb_people.Checked = true;
            this.rb_people.Location = new System.Drawing.Point(6, 16);
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
            this.rb_librarian.Location = new System.Drawing.Point(82, 16);
            this.rb_librarian.Name = "rb_librarian";
            this.rb_librarian.Size = new System.Drawing.Size(97, 17);
            this.rb_librarian.TabIndex = 6;
            this.rb_librarian.Text = "Библиотекарь";
            this.rb_librarian.UseVisualStyleBackColor = true;
            // 
            // creation_btn
            // 
            this.creation_btn.Location = new System.Drawing.Point(30, 206);
            this.creation_btn.Name = "creation_btn";
            this.creation_btn.Size = new System.Drawing.Size(79, 36);
            this.creation_btn.TabIndex = 7;
            this.creation_btn.Text = "Создать";
            this.creation_btn.UseVisualStyleBackColor = true;
            this.creation_btn.Click += new System.EventHandler(this.creation_btn_Click);
            // 
            // firstnameField
            // 
            this.firstnameField.Location = new System.Drawing.Point(95, 72);
            this.firstnameField.Name = "firstnameField";
            this.firstnameField.Size = new System.Drawing.Size(114, 20);
            this.firstnameField.TabIndex = 8;
            // 
            // lastnameField
            // 
            this.lastnameField.Location = new System.Drawing.Point(95, 99);
            this.lastnameField.Name = "lastnameField";
            this.lastnameField.Size = new System.Drawing.Size(114, 20);
            this.lastnameField.TabIndex = 9;
            // 
            // middlenameField
            // 
            this.middlenameField.Location = new System.Drawing.Point(95, 124);
            this.middlenameField.Name = "middlenameField";
            this.middlenameField.Size = new System.Drawing.Size(114, 20);
            this.middlenameField.TabIndex = 10;
            // 
            // label_first_name
            // 
            this.label_first_name.AutoSize = true;
            this.label_first_name.Location = new System.Drawing.Point(27, 75);
            this.label_first_name.Name = "label_first_name";
            this.label_first_name.Size = new System.Drawing.Size(59, 13);
            this.label_first_name.TabIndex = 11;
            this.label_first_name.Text = "Фамилия:";
            // 
            // label_last_name
            // 
            this.label_last_name.AutoSize = true;
            this.label_last_name.Location = new System.Drawing.Point(27, 102);
            this.label_last_name.Name = "label_last_name";
            this.label_last_name.Size = new System.Drawing.Size(32, 13);
            this.label_last_name.TabIndex = 12;
            this.label_last_name.Text = "Имя:";
            // 
            // label_middle_name
            // 
            this.label_middle_name.AutoSize = true;
            this.label_middle_name.Location = new System.Drawing.Point(27, 127);
            this.label_middle_name.Name = "label_middle_name";
            this.label_middle_name.Size = new System.Drawing.Size(57, 13);
            this.label_middle_name.TabIndex = 13;
            this.label_middle_name.Text = "Отчество:";
            // 
            // atrBox
            // 
            this.atrBox.Controls.Add(this.groupBox2);
            this.atrBox.Controls.Add(this.groupBox1);
            this.atrBox.Location = new System.Drawing.Point(221, 14);
            this.atrBox.Name = "atrBox";
            this.atrBox.Size = new System.Drawing.Size(328, 228);
            this.atrBox.TabIndex = 14;
            this.atrBox.TabStop = false;
            this.atrBox.Text = "Атрибуты";
            // 
            // personTypeBox
            // 
            this.personTypeBox.Controls.Add(this.rb_people);
            this.personTypeBox.Controls.Add(this.rb_librarian);
            this.personTypeBox.Location = new System.Drawing.Point(30, 150);
            this.personTypeBox.Name = "personTypeBox";
            this.personTypeBox.Size = new System.Drawing.Size(185, 39);
            this.personTypeBox.TabIndex = 15;
            this.personTypeBox.TabStop = false;
            // 
            // schoolBoyRB
            // 
            this.schoolBoyRB.AutoSize = true;
            this.schoolBoyRB.Location = new System.Drawing.Point(11, 19);
            this.schoolBoyRB.Name = "schoolBoyRB";
            this.schoolBoyRB.Size = new System.Drawing.Size(76, 17);
            this.schoolBoyRB.TabIndex = 0;
            this.schoolBoyRB.TabStop = true;
            this.schoolBoyRB.Text = "Школьник";
            this.schoolBoyRB.UseVisualStyleBackColor = true;
            // 
            // teacherRB
            // 
            this.teacherRB.AutoSize = true;
            this.teacherRB.Location = new System.Drawing.Point(11, 42);
            this.teacherRB.Name = "teacherRB";
            this.teacherRB.Size = new System.Drawing.Size(67, 17);
            this.teacherRB.TabIndex = 1;
            this.teacherRB.TabStop = true;
            this.teacherRB.Text = "Учитель";
            this.teacherRB.UseVisualStyleBackColor = true;
            // 
            // studentRB
            // 
            this.studentRB.AutoSize = true;
            this.studentRB.Location = new System.Drawing.Point(11, 65);
            this.studentRB.Name = "studentRB";
            this.studentRB.Size = new System.Drawing.Size(65, 17);
            this.studentRB.TabIndex = 2;
            this.studentRB.TabStop = true;
            this.studentRB.Text = "Студент";
            this.studentRB.UseVisualStyleBackColor = true;
            // 
            // scientistRB
            // 
            this.scientistRB.AutoSize = true;
            this.scientistRB.Location = new System.Drawing.Point(128, 18);
            this.scientistRB.Name = "scientistRB";
            this.scientistRB.Size = new System.Drawing.Size(113, 17);
            this.scientistRB.TabIndex = 3;
            this.scientistRB.TabStop = true;
            this.scientistRB.Text = "Научный деятель";
            this.scientistRB.UseVisualStyleBackColor = true;
            // 
            // workerRB
            // 
            this.workerRB.AutoSize = true;
            this.workerRB.Location = new System.Drawing.Point(128, 42);
            this.workerRB.Name = "workerRB";
            this.workerRB.Size = new System.Drawing.Size(73, 17);
            this.workerRB.TabIndex = 4;
            this.workerRB.TabStop = true;
            this.workerRB.Text = "Работник";
            this.workerRB.UseVisualStyleBackColor = true;
            // 
            // otherRB
            // 
            this.otherRB.AutoSize = true;
            this.otherRB.Location = new System.Drawing.Point(128, 65);
            this.otherRB.Name = "otherRB";
            this.otherRB.Size = new System.Drawing.Size(62, 17);
            this.otherRB.TabIndex = 5;
            this.otherRB.TabStop = true;
            this.otherRB.Text = "Другой";
            this.otherRB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.schoolBoyRB);
            this.groupBox1.Controls.Add(this.otherRB);
            this.groupBox1.Controls.Add(this.teacherRB);
            this.groupBox1.Controls.Add(this.workerRB);
            this.groupBox1.Controls.Add(this.studentRB);
            this.groupBox1.Controls.Add(this.scientistRB);
            this.groupBox1.Location = new System.Drawing.Point(6, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 86);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 118);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // AppendUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 332);
            this.Controls.Add(this.personTypeBox);
            this.Controls.Add(this.atrBox);
            this.Controls.Add(this.label_middle_name);
            this.Controls.Add(this.label_last_name);
            this.Controls.Add(this.label_first_name);
            this.Controls.Add(this.middlenameField);
            this.Controls.Add(this.lastnameField);
            this.Controls.Add(this.firstnameField);
            this.Controls.Add(this.creation_btn);
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
            this.atrBox.ResumeLayout(false);
            this.personTypeBox.ResumeLayout(false);
            this.personTypeBox.PerformLayout();
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
        private System.Windows.Forms.GroupBox atrBox;
        private System.Windows.Forms.GroupBox personTypeBox;
        private System.Windows.Forms.RadioButton studentRB;
        private System.Windows.Forms.RadioButton teacherRB;
        private System.Windows.Forms.RadioButton schoolBoyRB;
        private System.Windows.Forms.RadioButton scientistRB;
        private System.Windows.Forms.RadioButton otherRB;
        private System.Windows.Forms.RadioButton workerRB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}