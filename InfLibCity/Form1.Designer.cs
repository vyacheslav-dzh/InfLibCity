﻿
namespace InfLibCity
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.enterMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.dasdsadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выдачиКнигToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заДеньToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заНеделюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заМесяцToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заВсеВремяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.другоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.книгиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.всеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наРукахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.толькоВБиблиотекеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наСписаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.appendMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addSubjectBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.автораToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.жанрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.книгиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стиховToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выдачуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPersonBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.issueBookBtn = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(827, 473);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterMenuBtn,
            this.dasdsadToolStripMenuItem,
            this.exitMenuBtn,
            this.appendMenu,
            this.issueBookBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(851, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // enterMenuBtn
            // 
            this.enterMenuBtn.Name = "enterMenuBtn";
            this.enterMenuBtn.Size = new System.Drawing.Size(52, 20);
            this.enterMenuBtn.Text = "Войти";
            this.enterMenuBtn.Click += new System.EventHandler(this.enterButtonClick);
            // 
            // dasdsadToolStripMenuItem
            // 
            this.dasdsadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выдачиКнигToolStripMenuItem,
            this.книгиToolStripMenuItem1});
            this.dasdsadToolStripMenuItem.Name = "dasdsadToolStripMenuItem";
            this.dasdsadToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.dasdsadToolStripMenuItem.Text = "Показать";
            // 
            // выдачиКнигToolStripMenuItem
            // 
            this.выдачиКнигToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заДеньToolStripMenuItem,
            this.заНеделюToolStripMenuItem,
            this.заМесяцToolStripMenuItem,
            this.заВсеВремяToolStripMenuItem,
            this.другоеToolStripMenuItem});
            this.выдачиКнигToolStripMenuItem.Name = "выдачиКнигToolStripMenuItem";
            this.выдачиКнигToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.выдачиКнигToolStripMenuItem.Text = "Выдачи книг";
            // 
            // заДеньToolStripMenuItem
            // 
            this.заДеньToolStripMenuItem.Name = "заДеньToolStripMenuItem";
            this.заДеньToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.заДеньToolStripMenuItem.Text = "За день";
            // 
            // заНеделюToolStripMenuItem
            // 
            this.заНеделюToolStripMenuItem.Name = "заНеделюToolStripMenuItem";
            this.заНеделюToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.заНеделюToolStripMenuItem.Text = "За неделю";
            // 
            // заМесяцToolStripMenuItem
            // 
            this.заМесяцToolStripMenuItem.Name = "заМесяцToolStripMenuItem";
            this.заМесяцToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.заМесяцToolStripMenuItem.Text = "За месяц";
            // 
            // заВсеВремяToolStripMenuItem
            // 
            this.заВсеВремяToolStripMenuItem.Name = "заВсеВремяToolStripMenuItem";
            this.заВсеВремяToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.заВсеВремяToolStripMenuItem.Text = "За все время";
            // 
            // другоеToolStripMenuItem
            // 
            this.другоеToolStripMenuItem.Name = "другоеToolStripMenuItem";
            this.другоеToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.другоеToolStripMenuItem.Text = "Другое";
            // 
            // книгиToolStripMenuItem1
            // 
            this.книгиToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.всеToolStripMenuItem,
            this.наРукахToolStripMenuItem,
            this.толькоВБиблиотекеToolStripMenuItem,
            this.наСписаниеToolStripMenuItem});
            this.книгиToolStripMenuItem1.Name = "книгиToolStripMenuItem1";
            this.книгиToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.книгиToolStripMenuItem1.Text = "Книги";
            // 
            // всеToolStripMenuItem
            // 
            this.всеToolStripMenuItem.Name = "всеToolStripMenuItem";
            this.всеToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.всеToolStripMenuItem.Text = "Все";
            // 
            // наРукахToolStripMenuItem
            // 
            this.наРукахToolStripMenuItem.Name = "наРукахToolStripMenuItem";
            this.наРукахToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.наРукахToolStripMenuItem.Text = "\"На руках\"";
            // 
            // толькоВБиблиотекеToolStripMenuItem
            // 
            this.толькоВБиблиотекеToolStripMenuItem.Name = "толькоВБиблиотекеToolStripMenuItem";
            this.толькоВБиблиотекеToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.толькоВБиблиотекеToolStripMenuItem.Text = "Только в библиотеке";
            // 
            // наСписаниеToolStripMenuItem
            // 
            this.наСписаниеToolStripMenuItem.Name = "наСписаниеToolStripMenuItem";
            this.наСписаниеToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.наСписаниеToolStripMenuItem.Text = "На списание";
            // 
            // exitMenuBtn
            // 
            this.exitMenuBtn.Name = "exitMenuBtn";
            this.exitMenuBtn.Size = new System.Drawing.Size(54, 20);
            this.exitMenuBtn.Text = "Выйти";
            this.exitMenuBtn.Visible = false;
            this.exitMenuBtn.Click += new System.EventHandler(this.exitMenuBtn_Click);
            // 
            // appendMenu
            // 
            this.appendMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSubjectBtn,
            this.автораToolStripMenuItem,
            this.жанрToolStripMenuItem,
            this.выдачуToolStripMenuItem,
            this.addPersonBtn});
            this.appendMenu.Name = "appendMenu";
            this.appendMenu.Size = new System.Drawing.Size(71, 20);
            this.appendMenu.Text = "Добавить";
            this.appendMenu.Visible = false;
            // 
            // addSubjectBtn
            // 
            this.addSubjectBtn.Name = "addSubjectBtn";
            this.addSubjectBtn.Size = new System.Drawing.Size(180, 22);
            this.addSubjectBtn.Text = "Работу";
            this.addSubjectBtn.Click += new System.EventHandler(this.addSubjectBtn_Click);
            // 
            // автораToolStripMenuItem
            // 
            this.автораToolStripMenuItem.Name = "автораToolStripMenuItem";
            this.автораToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.автораToolStripMenuItem.Text = "Автора";
            // 
            // жанрToolStripMenuItem
            // 
            this.жанрToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.книгиToolStripMenuItem,
            this.стиховToolStripMenuItem});
            this.жанрToolStripMenuItem.Name = "жанрToolStripMenuItem";
            this.жанрToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.жанрToolStripMenuItem.Text = "Жанр";
            // 
            // книгиToolStripMenuItem
            // 
            this.книгиToolStripMenuItem.Name = "книгиToolStripMenuItem";
            this.книгиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.книгиToolStripMenuItem.Text = "Книги";
            // 
            // стиховToolStripMenuItem
            // 
            this.стиховToolStripMenuItem.Name = "стиховToolStripMenuItem";
            this.стиховToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.стиховToolStripMenuItem.Text = "Стихов";
            // 
            // выдачуToolStripMenuItem
            // 
            this.выдачуToolStripMenuItem.Name = "выдачуToolStripMenuItem";
            this.выдачуToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выдачуToolStripMenuItem.Text = "Выдачу";
            // 
            // addPersonBtn
            // 
            this.addPersonBtn.Name = "addPersonBtn";
            this.addPersonBtn.Size = new System.Drawing.Size(180, 22);
            this.addPersonBtn.Text = "Пользователя";
            this.addPersonBtn.Click += new System.EventHandler(this.addUserBtn);
            // 
            // issueBookBtn
            // 
            this.issueBookBtn.Name = "issueBookBtn";
            this.issueBookBtn.Size = new System.Drawing.Size(112, 20);
            this.issueBookBtn.Text = "Оформить книгу";
            this.issueBookBtn.Visible = false;
            this.issueBookBtn.Click += new System.EventHandler(this.issueBookBtnClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 512);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InfLibCity";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dasdsadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem appendMenu;
        private System.Windows.Forms.ToolStripMenuItem addSubjectBtn;
        private System.Windows.Forms.ToolStripMenuItem автораToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem жанрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выдачуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuBtn;
        private System.Windows.Forms.ToolStripMenuItem выдачиКнигToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заДеньToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заНеделюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заМесяцToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заВсеВремяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem другоеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem книгиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem всеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem наРукахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem толькоВБиблиотекеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem наСписаниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem книгиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стиховToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueBookBtn;
        private System.Windows.Forms.ToolStripMenuItem addPersonBtn;
    }
}

