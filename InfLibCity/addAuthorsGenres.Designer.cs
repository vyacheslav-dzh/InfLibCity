
namespace InfLibCity
{
    partial class addAuthorsGenres
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
            this.authorsGenresView = new System.Windows.Forms.DataGridView();
            this.searchField = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.authorsGenresView)).BeginInit();
            this.SuspendLayout();
            // 
            // authorsGenresView
            // 
            this.authorsGenresView.AllowUserToAddRows = false;
            this.authorsGenresView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.authorsGenresView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.authorsGenresView.Location = new System.Drawing.Point(12, 38);
            this.authorsGenresView.Name = "authorsGenresView";
            this.authorsGenresView.ReadOnly = true;
            this.authorsGenresView.RowHeadersVisible = false;
            this.authorsGenresView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.authorsGenresView.Size = new System.Drawing.Size(244, 150);
            this.authorsGenresView.TabIndex = 0;
            // 
            // searchField
            // 
            this.searchField.Location = new System.Drawing.Point(12, 12);
            this.searchField.Name = "searchField";
            this.searchField.Size = new System.Drawing.Size(163, 20);
            this.searchField.TabIndex = 1;
            this.searchField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchField_KeyPress);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(181, 12);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 20);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "Поиск";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(93, 194);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(163, 23);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "Добавить выделенного(ых)";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(12, 194);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // addAuthorsGenres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 229);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchField);
            this.Controls.Add(this.authorsGenresView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "addAuthorsGenres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addAuthorsGenres";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.addAuthorsGenres_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.authorsGenresView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView authorsGenresView;
        private System.Windows.Forms.TextBox searchField;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}