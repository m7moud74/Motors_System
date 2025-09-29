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
            this.Btn_add = new System.Windows.Forms.Button();
            this.Btn_edit = new System.Windows.Forms.Button();
            this.Btn_delete = new System.Windows.Forms.Button();
            this.Cb_Role = new System.Windows.Forms.ComboBox();
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
            // Btn_add
            // 
            this.Btn_add.Location = new System.Drawing.Point(841, 437);
            this.Btn_add.Name = "Btn_add";
            this.Btn_add.Size = new System.Drawing.Size(75, 23);
            this.Btn_add.TabIndex = 9;
            this.Btn_add.Text = "اضافه";
            this.Btn_add.UseVisualStyleBackColor = true;
            this.Btn_add.Click += new System.EventHandler(this.Btn_add_Click);
            // 
            // Btn_edit
            // 
            this.Btn_edit.Location = new System.Drawing.Point(710, 437);
            this.Btn_edit.Name = "Btn_edit";
            this.Btn_edit.Size = new System.Drawing.Size(75, 23);
            this.Btn_edit.TabIndex = 11;
            this.Btn_edit.Text = "تعديل";
            this.Btn_edit.UseVisualStyleBackColor = true;
            this.Btn_edit.Click += new System.EventHandler(this.Btn_edit_Click);
            // 
            // Btn_delete
            // 
            this.Btn_delete.Location = new System.Drawing.Point(568, 437);
            this.Btn_delete.Name = "Btn_delete";
            this.Btn_delete.Size = new System.Drawing.Size(75, 23);
            this.Btn_delete.TabIndex = 12;
            this.Btn_delete.Text = "حذف";
            this.Btn_delete.UseVisualStyleBackColor = true;
            this.Btn_delete.Click += new System.EventHandler(this.Btn_delete_Click);
            // 
            // Cb_Role
            // 
            this.Cb_Role.FormattingEnabled = true;
            this.Cb_Role.Location = new System.Drawing.Point(963, 111);
            this.Cb_Role.Name = "Cb_Role";
            this.Cb_Role.Size = new System.Drawing.Size(121, 24);
            this.Cb_Role.TabIndex = 13;
            // 
            // User_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 505);
            this.Controls.Add(this.Cb_Role);
            this.Controls.Add(this.Btn_delete);
            this.Controls.Add(this.Btn_edit);
            this.Controls.Add(this.Btn_add);
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
        private System.Windows.Forms.Button Btn_add;
        private System.Windows.Forms.Button Btn_edit;
        private System.Windows.Forms.Button Btn_delete;
        private System.Windows.Forms.ComboBox Cb_Role;
    }
}