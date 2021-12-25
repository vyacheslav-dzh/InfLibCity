
namespace InfLibCity
{
    partial class Auth
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
            this.useridField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.auth_bth = new System.Windows.Forms.Button();
            this.userPassField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.registration_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // useridField
            // 
            this.useridField.Location = new System.Drawing.Point(67, 11);
            this.useridField.Name = "useridField";
            this.useridField.Size = new System.Drawing.Size(100, 20);
            this.useridField.TabIndex = 0;
            this.useridField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.useridField_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Логин:";
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(11, 63);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 21);
            this.cancel_btn.TabIndex = 2;
            this.cancel_btn.Text = "Отмена";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // auth_bth
            // 
            this.auth_bth.Location = new System.Drawing.Point(92, 63);
            this.auth_bth.Name = "auth_bth";
            this.auth_bth.Size = new System.Drawing.Size(75, 21);
            this.auth_bth.TabIndex = 3;
            this.auth_bth.Text = "Войти";
            this.auth_bth.UseVisualStyleBackColor = true;
            this.auth_bth.Click += new System.EventHandler(this.auth_bth_Click);
            // 
            // userPassField
            // 
            this.userPassField.Location = new System.Drawing.Point(67, 37);
            this.userPassField.Name = "userPassField";
            this.userPassField.PasswordChar = '*';
            this.userPassField.Size = new System.Drawing.Size(100, 20);
            this.userPassField.TabIndex = 1;
            this.userPassField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userPassField_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль:";
            // 
            // registration_btn
            // 
            this.registration_btn.FlatAppearance.BorderSize = 0;
            this.registration_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registration_btn.Location = new System.Drawing.Point(11, 90);
            this.registration_btn.Name = "registration_btn";
            this.registration_btn.Size = new System.Drawing.Size(156, 20);
            this.registration_btn.TabIndex = 6;
            this.registration_btn.Text = "Регистрация";
            this.registration_btn.UseVisualStyleBackColor = true;
            this.registration_btn.Click += new System.EventHandler(this.registration_btn_Click);
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(175, 118);
            this.Controls.Add(this.registration_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userPassField);
            this.Controls.Add(this.auth_bth);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.useridField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Auth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Auth_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox useridField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button auth_bth;
        private System.Windows.Forms.TextBox userPassField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button registration_btn;
    }
}