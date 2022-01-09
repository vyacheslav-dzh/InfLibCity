
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
            this.subjectData = new System.Windows.Forms.DataGridView();
            this.peoplesData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.subjectData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peoplesData)).BeginInit();
            this.SuspendLayout();
            // 
            // subjectData
            // 
            this.subjectData.AllowUserToAddRows = false;
            this.subjectData.AllowUserToDeleteRows = false;
            this.subjectData.AllowUserToResizeColumns = false;
            this.subjectData.AllowUserToResizeRows = false;
            this.subjectData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subjectData.Location = new System.Drawing.Point(23, 197);
            this.subjectData.Name = "subjectData";
            this.subjectData.RowHeadersVisible = false;
            this.subjectData.Size = new System.Drawing.Size(240, 150);
            this.subjectData.TabIndex = 0;
            // 
            // peoplesData
            // 
            this.peoplesData.AllowUserToAddRows = false;
            this.peoplesData.AllowUserToDeleteRows = false;
            this.peoplesData.AllowUserToResizeColumns = false;
            this.peoplesData.AllowUserToResizeRows = false;
            this.peoplesData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.peoplesData.Location = new System.Drawing.Point(471, 197);
            this.peoplesData.Name = "peoplesData";
            this.peoplesData.RowHeadersVisible = false;
            this.peoplesData.Size = new System.Drawing.Size(240, 150);
            this.peoplesData.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Читатели";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Литература";
            // 
            // addSubscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.peoplesData);
            this.Controls.Add(this.subjectData);
            this.Name = "addSubscription";
            this.Text = "addSubscription";
            ((System.ComponentModel.ISupportInitialize)(this.subjectData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peoplesData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView subjectData;
        private System.Windows.Forms.DataGridView peoplesData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}