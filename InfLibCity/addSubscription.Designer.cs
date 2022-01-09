
namespace InfLibCity
{
    partial class addSubscription
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
            this.peopleData = new System.Windows.Forms.DataGridView();
            this.peopleTypeCB = new System.Windows.Forms.ComboBox();
            this.searchPeopleField = new System.Windows.Forms.TextBox();
            this.peopleBox = new System.Windows.Forms.GroupBox();
            this.searchPeopleBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchSubjectBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.subjectData = new System.Windows.Forms.DataGridView();
            this.searchSubjectField = new System.Windows.Forms.TextBox();
            this.subjectTypeCB = new System.Windows.Forms.ComboBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.appendBtn = new System.Windows.Forms.Button();
            this.libraryCB = new System.Windows.Forms.ComboBox();
            this.libraryLabel = new System.Windows.Forms.Label();
            this.beginDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.peopleData)).BeginInit();
            this.peopleBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectData)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // peopleData
            // 
            this.peopleData.AllowUserToAddRows = false;
            this.peopleData.AllowUserToDeleteRows = false;
            this.peopleData.AllowUserToResizeColumns = false;
            this.peopleData.AllowUserToResizeRows = false;
            this.peopleData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.peopleData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.peopleData.Location = new System.Drawing.Point(6, 72);
            this.peopleData.MultiSelect = false;
            this.peopleData.Name = "peopleData";
            this.peopleData.ReadOnly = true;
            this.peopleData.RowHeadersVisible = false;
            this.peopleData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.peopleData.Size = new System.Drawing.Size(396, 157);
            this.peopleData.TabIndex = 0;
            // 
            // peopleTypeCB
            // 
            this.peopleTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.peopleTypeCB.FormattingEnabled = true;
            this.peopleTypeCB.Items.AddRange(new object[] {
            "Все",
            "Школьник",
            "Студент",
            "Преподователь",
            "Науч. работник",
            "Рабочий",
            "Другое"});
            this.peopleTypeCB.Location = new System.Drawing.Point(48, 19);
            this.peopleTypeCB.Name = "peopleTypeCB";
            this.peopleTypeCB.Size = new System.Drawing.Size(138, 21);
            this.peopleTypeCB.TabIndex = 6;
            this.peopleTypeCB.SelectedIndexChanged += new System.EventHandler(this.peopleTypeCB_SelectedIndexChanged);
            // 
            // searchPeopleField
            // 
            this.searchPeopleField.Location = new System.Drawing.Point(10, 46);
            this.searchPeopleField.Name = "searchPeopleField";
            this.searchPeopleField.Size = new System.Drawing.Size(311, 20);
            this.searchPeopleField.TabIndex = 8;
            // 
            // peopleBox
            // 
            this.peopleBox.Controls.Add(this.searchPeopleBtn);
            this.peopleBox.Controls.Add(this.label1);
            this.peopleBox.Controls.Add(this.peopleData);
            this.peopleBox.Controls.Add(this.searchPeopleField);
            this.peopleBox.Controls.Add(this.peopleTypeCB);
            this.peopleBox.Location = new System.Drawing.Point(12, 12);
            this.peopleBox.Name = "peopleBox";
            this.peopleBox.Size = new System.Drawing.Size(411, 235);
            this.peopleBox.TabIndex = 9;
            this.peopleBox.TabStop = false;
            this.peopleBox.Text = "Читатель";
            // 
            // searchPeopleBtn
            // 
            this.searchPeopleBtn.Location = new System.Drawing.Point(327, 46);
            this.searchPeopleBtn.Name = "searchPeopleBtn";
            this.searchPeopleBtn.Size = new System.Drawing.Size(75, 20);
            this.searchPeopleBtn.TabIndex = 10;
            this.searchPeopleBtn.Text = "Поиск";
            this.searchPeopleBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Тип:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchSubjectBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.subjectData);
            this.groupBox1.Controls.Add(this.searchSubjectField);
            this.groupBox1.Controls.Add(this.subjectTypeCB);
            this.groupBox1.Location = new System.Drawing.Point(429, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 235);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Литература";
            // 
            // searchSubjectBtn
            // 
            this.searchSubjectBtn.Location = new System.Drawing.Point(327, 46);
            this.searchSubjectBtn.Name = "searchSubjectBtn";
            this.searchSubjectBtn.Size = new System.Drawing.Size(75, 20);
            this.searchSubjectBtn.TabIndex = 10;
            this.searchSubjectBtn.Text = "Поиск";
            this.searchSubjectBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Тип:";
            // 
            // subjectData
            // 
            this.subjectData.AllowUserToAddRows = false;
            this.subjectData.AllowUserToDeleteRows = false;
            this.subjectData.AllowUserToResizeColumns = false;
            this.subjectData.AllowUserToResizeRows = false;
            this.subjectData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.subjectData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectData.Location = new System.Drawing.Point(6, 72);
            this.subjectData.MultiSelect = false;
            this.subjectData.Name = "subjectData";
            this.subjectData.ReadOnly = true;
            this.subjectData.RowHeadersVisible = false;
            this.subjectData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.subjectData.Size = new System.Drawing.Size(396, 157);
            this.subjectData.TabIndex = 0;
            // 
            // searchSubjectField
            // 
            this.searchSubjectField.Location = new System.Drawing.Point(10, 46);
            this.searchSubjectField.Name = "searchSubjectField";
            this.searchSubjectField.Size = new System.Drawing.Size(311, 20);
            this.searchSubjectField.TabIndex = 8;
            // 
            // subjectTypeCB
            // 
            this.subjectTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subjectTypeCB.FormattingEnabled = true;
            this.subjectTypeCB.Items.AddRange(new object[] {
            "Все",
            "Книга",
            "Сборник стихов",
            "Газета",
            "Журнал",
            "Реферат",
            "Сборник докладов",
            "Сборник тезисов",
            "Статья",
            "Диссертация",
            "Учебник"});
            this.subjectTypeCB.Location = new System.Drawing.Point(48, 19);
            this.subjectTypeCB.Name = "subjectTypeCB";
            this.subjectTypeCB.Size = new System.Drawing.Size(138, 21);
            this.subjectTypeCB.TabIndex = 6;
            this.subjectTypeCB.SelectedIndexChanged += new System.EventHandler(this.subjectTypeCB_SelectedIndexChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(3, 150);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(160, 23);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // appendBtn
            // 
            this.appendBtn.Location = new System.Drawing.Point(3, 121);
            this.appendBtn.Name = "appendBtn";
            this.appendBtn.Size = new System.Drawing.Size(160, 23);
            this.appendBtn.TabIndex = 13;
            this.appendBtn.Text = "Оформить";
            this.appendBtn.UseVisualStyleBackColor = true;
            this.appendBtn.Click += new System.EventHandler(this.appendBtn_Click);
            // 
            // libraryCB
            // 
            this.libraryCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.libraryCB.FormattingEnabled = true;
            this.libraryCB.Location = new System.Drawing.Point(3, 16);
            this.libraryCB.Name = "libraryCB";
            this.libraryCB.Size = new System.Drawing.Size(160, 21);
            this.libraryCB.TabIndex = 14;
            this.libraryCB.Visible = false;
            this.libraryCB.SelectedIndexChanged += new System.EventHandler(this.libraryCB_SelectedIndexChanged);
            // 
            // libraryLabel
            // 
            this.libraryLabel.AutoSize = true;
            this.libraryLabel.Location = new System.Drawing.Point(3, 0);
            this.libraryLabel.Name = "libraryLabel";
            this.libraryLabel.Size = new System.Drawing.Size(38, 13);
            this.libraryLabel.TabIndex = 15;
            this.libraryLabel.Text = "Библ.:";
            this.libraryLabel.Visible = false;
            // 
            // beginDate
            // 
            this.beginDate.Location = new System.Drawing.Point(3, 56);
            this.beginDate.Name = "beginDate";
            this.beginDate.Size = new System.Drawing.Size(160, 20);
            this.beginDate.TabIndex = 16;
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(3, 95);
            this.endDate.MinDate = new System.DateTime(2022, 1, 9, 0, 0, 0, 0);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(160, 20);
            this.endDate.TabIndex = 17;
            this.endDate.Validating += new System.ComponentModel.CancelEventHandler(this.endDate_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Дата начала:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Дата конца:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.libraryLabel);
            this.flowLayoutPanel1.Controls.Add(this.libraryCB);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.beginDate);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.endDate);
            this.flowLayoutPanel1.Controls.Add(this.appendBtn);
            this.flowLayoutPanel1.Controls.Add(this.cancelBtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(846, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(173, 235);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // addSubscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 256);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.peopleBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "addSubscription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оформление";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.addSubscription_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.peopleData)).EndInit();
            this.peopleBox.ResumeLayout(false);
            this.peopleBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subjectData)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView peopleData;
        private System.Windows.Forms.ComboBox peopleTypeCB;
        private System.Windows.Forms.TextBox searchPeopleField;
        private System.Windows.Forms.GroupBox peopleBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchPeopleBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button searchSubjectBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView subjectData;
        private System.Windows.Forms.TextBox searchSubjectField;
        private System.Windows.Forms.ComboBox subjectTypeCB;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button appendBtn;
        private System.Windows.Forms.ComboBox libraryCB;
        private System.Windows.Forms.Label libraryLabel;
        private System.Windows.Forms.DateTimePicker beginDate;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}