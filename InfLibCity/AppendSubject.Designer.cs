
namespace InfLibCity
{
    partial class AppendSubject
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
            this.subjectTypeCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.subjectNameField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateWrittingField = new System.Windows.Forms.TextBox();
            this.onlyReadCB = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.quantityNUD = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.authorField = new System.Windows.Forms.TextBox();
            this.genreField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.authorB = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.genreB = new System.Windows.Forms.GroupBox();
            this.themeB = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.themeField = new System.Windows.Forms.TextBox();
            this.diciplinesB = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.diciplinesField = new System.Windows.Forms.TextBox();
            this.typeB = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.typeCB = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNUD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.authorB.SuspendLayout();
            this.genreB.SuspendLayout();
            this.themeB.SuspendLayout();
            this.diciplinesB.SuspendLayout();
            this.typeB.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // subjectTypeCB
            // 
            this.subjectTypeCB.FormattingEnabled = true;
            this.subjectTypeCB.Items.AddRange(new object[] {
            "Газета",
            "Диссертация",
            "Журнал",
            "Книга",
            "Реферат",
            "Сборник докладов",
            "Сборник статей",
            "Сборник стихов",
            "Сборник тезисов",
            "Учебник"});
            this.subjectTypeCB.Location = new System.Drawing.Point(9, 146);
            this.subjectTypeCB.Name = "subjectTypeCB";
            this.subjectTypeCB.Size = new System.Drawing.Size(260, 21);
            this.subjectTypeCB.TabIndex = 0;
            this.subjectTypeCB.Text = "Выберите тип литературы";
            this.subjectTypeCB.SelectedIndexChanged += new System.EventHandler(this.subjectTypeCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название литературы:";
            // 
            // subjectNameField
            // 
            this.subjectNameField.Location = new System.Drawing.Point(134, 19);
            this.subjectNameField.Name = "subjectNameField";
            this.subjectNameField.Size = new System.Drawing.Size(135, 20);
            this.subjectNameField.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Год написания:";
            // 
            // dateWrittingField
            // 
            this.dateWrittingField.Location = new System.Drawing.Point(134, 45);
            this.dateWrittingField.Name = "dateWrittingField";
            this.dateWrittingField.Size = new System.Drawing.Size(135, 20);
            this.dateWrittingField.TabIndex = 4;
            // 
            // onlyReadCB
            // 
            this.onlyReadCB.AutoSize = true;
            this.onlyReadCB.Location = new System.Drawing.Point(9, 97);
            this.onlyReadCB.Name = "onlyReadCB";
            this.onlyReadCB.Size = new System.Drawing.Size(192, 17);
            this.onlyReadCB.TabIndex = 6;
            this.onlyReadCB.Text = "Только для чтения в библиотеке";
            this.onlyReadCB.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Кол-во экземпляров:";
            // 
            // quantityNUD
            // 
            this.quantityNUD.Location = new System.Drawing.Point(134, 120);
            this.quantityNUD.Name = "quantityNUD";
            this.quantityNUD.Size = new System.Drawing.Size(135, 20);
            this.quantityNUD.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.subjectNameField);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.subjectTypeCB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.quantityNUD);
            this.groupBox1.Controls.Add(this.dateWrittingField);
            this.groupBox1.Controls.Add(this.onlyReadCB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 173);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Основные параметры";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Автор:";
            // 
            // authorField
            // 
            this.authorField.Location = new System.Drawing.Point(134, 7);
            this.authorField.Name = "authorField";
            this.authorField.Size = new System.Drawing.Size(135, 20);
            this.authorField.TabIndex = 13;
            // 
            // genreField
            // 
            this.genreField.Location = new System.Drawing.Point(134, 9);
            this.genreField.Name = "genreField";
            this.genreField.Size = new System.Drawing.Size(135, 20);
            this.genreField.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Жанр:";
            // 
            // authorB
            // 
            this.authorB.Controls.Add(this.groupBox3);
            this.authorB.Controls.Add(this.label4);
            this.authorB.Controls.Add(this.authorField);
            this.authorB.Location = new System.Drawing.Point(3, 182);
            this.authorB.Name = "authorB";
            this.authorB.Size = new System.Drawing.Size(275, 33);
            this.authorB.TabIndex = 12;
            this.authorB.TabStop = false;
            this.authorB.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(9, 121);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 269);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // genreB
            // 
            this.genreB.Controls.Add(this.label5);
            this.genreB.Controls.Add(this.genreField);
            this.genreB.Location = new System.Drawing.Point(3, 221);
            this.genreB.Name = "genreB";
            this.genreB.Size = new System.Drawing.Size(275, 33);
            this.genreB.TabIndex = 15;
            this.genreB.TabStop = false;
            this.genreB.Visible = false;
            // 
            // themeB
            // 
            this.themeB.Controls.Add(this.label6);
            this.themeB.Controls.Add(this.themeField);
            this.themeB.Location = new System.Drawing.Point(3, 260);
            this.themeB.Name = "themeB";
            this.themeB.Size = new System.Drawing.Size(275, 33);
            this.themeB.TabIndex = 16;
            this.themeB.TabStop = false;
            this.themeB.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Тема:";
            // 
            // themeField
            // 
            this.themeField.Location = new System.Drawing.Point(134, 9);
            this.themeField.Name = "themeField";
            this.themeField.Size = new System.Drawing.Size(135, 20);
            this.themeField.TabIndex = 15;
            // 
            // diciplinesB
            // 
            this.diciplinesB.Controls.Add(this.label7);
            this.diciplinesB.Controls.Add(this.diciplinesField);
            this.diciplinesB.Location = new System.Drawing.Point(3, 299);
            this.diciplinesB.Name = "diciplinesB";
            this.diciplinesB.Size = new System.Drawing.Size(275, 33);
            this.diciplinesB.TabIndex = 17;
            this.diciplinesB.TabStop = false;
            this.diciplinesB.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Дисциплина:";
            // 
            // diciplinesField
            // 
            this.diciplinesField.Location = new System.Drawing.Point(134, 10);
            this.diciplinesField.Name = "diciplinesField";
            this.diciplinesField.Size = new System.Drawing.Size(135, 20);
            this.diciplinesField.TabIndex = 15;
            // 
            // typeB
            // 
            this.typeB.Controls.Add(this.typeCB);
            this.typeB.Controls.Add(this.label8);
            this.typeB.Location = new System.Drawing.Point(3, 338);
            this.typeB.Name = "typeB";
            this.typeB.Size = new System.Drawing.Size(275, 33);
            this.typeB.TabIndex = 18;
            this.typeB.TabStop = false;
            this.typeB.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Тип:";
            // 
            // typeCB
            // 
            this.typeCB.FormattingEnabled = true;
            this.typeCB.Location = new System.Drawing.Point(134, 10);
            this.typeCB.Name = "typeCB";
            this.typeCB.Size = new System.Drawing.Size(135, 21);
            this.typeCB.TabIndex = 9;
            this.typeCB.Text = "Выберите тип";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Издатель:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 20);
            this.textBox1.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.authorB);
            this.flowLayoutPanel1.Controls.Add(this.genreB);
            this.flowLayoutPanel1.Controls.Add(this.themeB);
            this.flowLayoutPanel1.Controls.Add(this.diciplinesB);
            this.flowLayoutPanel1.Controls.Add(this.typeB);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(285, 408);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(144, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Создать";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AppendSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 431);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AppendSubject";
            this.Text = "Добавление литературы";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AppendSubject_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.quantityNUD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.authorB.ResumeLayout(false);
            this.authorB.PerformLayout();
            this.genreB.ResumeLayout(false);
            this.genreB.PerformLayout();
            this.themeB.ResumeLayout(false);
            this.themeB.PerformLayout();
            this.diciplinesB.ResumeLayout(false);
            this.diciplinesB.PerformLayout();
            this.typeB.ResumeLayout(false);
            this.typeB.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox subjectTypeCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox subjectNameField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dateWrittingField;
        private System.Windows.Forms.CheckBox onlyReadCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown quantityNUD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox authorField;
        private System.Windows.Forms.TextBox genreField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox authorB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox genreB;
        private System.Windows.Forms.GroupBox themeB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox themeField;
        private System.Windows.Forms.GroupBox diciplinesB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox diciplinesField;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox typeB;
        private System.Windows.Forms.ComboBox typeCB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}