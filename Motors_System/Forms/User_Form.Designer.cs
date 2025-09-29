namespace Motors_System.Forms
{
    partial class User_Form
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
            this.User_DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Tb_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Tb_name = new System.Windows.Forms.TextBox();
            this.Tb_pass = new System.Windows.Forms.TextBox();
            this.Tb_Role = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.User_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // User_DGV
            // 
            this.User_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.User_DGV.Location = new System.Drawing.Point(207, 236);
            this.User_DGV.Name = "User_DGV";
            this.User_DGV.RowHeadersWidth = 51;
            this.User_DGV.RowTemplate.Height = 26;
            this.User_DGV.Size = new System.Drawing.Size(709, 150);
            this.User_DGV.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1100, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "الرقم التعريفي";
            // 
            // Tb_ID
            // 
            this.Tb_ID.Location = new System.Drawing.Point(983, 24);
            this.Tb_ID.Name = "Tb_ID";
            this.Tb_ID.Size = new System.Drawing.Size(100, 24);
            this.Tb_ID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1090, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "اسم المستخدم";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1105, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "كلمه المرور";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1126, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "السلطه";
            // 
            // Tb_name
            // 
            this.Tb_name.Location = new System.Drawing.Point(984, 54);
            this.Tb_name.Name = "Tb_name";
            this.Tb_name.Size = new System.Drawing.Size(100, 24);
            this.Tb_name.TabIndex = 6;
            // 
            // Tb_pass
            // 
            this.Tb_pass.Location = new System.Drawing.Point(983, 81);
            this.Tb_pass.Name = "Tb_pass";
            this.Tb_pass.Size = new System.Drawing.Size(100, 24);
            this.Tb_pass.TabIndex = 7;
            // 
            // Tb_Role
            // 
            this.Tb_Role.Location = new System.Drawing.Point(984, 111);
            this.Tb_Role.Name = "Tb_Role";
            this.Tb_Role.Size = new System.Drawing.Size(100, 24);
            this.Tb_Role.TabIndex = 8;
            // 
            // User_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 505);
            this.Controls.Add(this.Tb_Role);
            this.Controls.Add(this.Tb_pass);
            this.Controls.Add(this.Tb_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tb_ID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.User_DGV);
            this.Name = "User_Form";
            this.Text = "User_Form";
            this.Load += new System.EventHandler(this.User_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.User_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView User_DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tb_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Tb_name;
        private System.Windows.Forms.TextBox Tb_pass;
        private System.Windows.Forms.TextBox Tb_Role;
    }
}