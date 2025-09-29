namespace Motors_System.Forms
{
    partial class MotorForm
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
            this.Motor_DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Motor_Id = new System.Windows.Forms.TextBox();
            this.Tb_Motor_Name = new System.Windows.Forms.TextBox();
            this.Tb_Motor_Quntity = new System.Windows.Forms.TextBox();
            this.Tb_Motor_Price = new System.Windows.Forms.TextBox();
            this.Tb_Motor_Power = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Tb_Motor_search = new System.Windows.Forms.TextBox();
            this.BTN_Add = new System.Windows.Forms.Button();
            this.BTN_edit = new System.Windows.Forms.Button();
            this.BTN_Delete = new System.Windows.Forms.Button();
            this.BTN_to_bk_home = new System.Windows.Forms.Button();
            this.BTN_to_bk_Previous_Page = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Motor_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Motor_DGV
            // 
            this.Motor_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Motor_DGV.Location = new System.Drawing.Point(237, 123);
            this.Motor_DGV.Name = "Motor_DGV";
            this.Motor_DGV.RowHeadersWidth = 51;
            this.Motor_DGV.RowTemplate.Height = 24;
            this.Motor_DGV.Size = new System.Drawing.Size(880, 343);
            this.Motor_DGV.TabIndex = 0;
            this.Motor_DGV.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Motor_DGV_RowHeaderMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1313, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "الاسم";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1282, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "رقم التعريف";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1312, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "الكميه";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1316, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "السعر ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1321, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "القوه";
            // 
            // TB_Motor_Id
            // 
            this.TB_Motor_Id.Location = new System.Drawing.Point(1176, 6);
            this.TB_Motor_Id.Name = "TB_Motor_Id";
            this.TB_Motor_Id.Size = new System.Drawing.Size(100, 24);
            this.TB_Motor_Id.TabIndex = 7;
            this.TB_Motor_Id.TextChanged += new System.EventHandler(this.TB_Motor_Id_TextChanged);
            // 
            // Tb_Motor_Name
            // 
            this.Tb_Motor_Name.Location = new System.Drawing.Point(1176, 36);
            this.Tb_Motor_Name.Name = "Tb_Motor_Name";
            this.Tb_Motor_Name.Size = new System.Drawing.Size(100, 24);
            this.Tb_Motor_Name.TabIndex = 8;
            // 
            // Tb_Motor_Quntity
            // 
            this.Tb_Motor_Quntity.Location = new System.Drawing.Point(1176, 126);
            this.Tb_Motor_Quntity.Name = "Tb_Motor_Quntity";
            this.Tb_Motor_Quntity.Size = new System.Drawing.Size(100, 24);
            this.Tb_Motor_Quntity.TabIndex = 10;
            // 
            // Tb_Motor_Price
            // 
            this.Tb_Motor_Price.Location = new System.Drawing.Point(1176, 96);
            this.Tb_Motor_Price.Name = "Tb_Motor_Price";
            this.Tb_Motor_Price.Size = new System.Drawing.Size(100, 24);
            this.Tb_Motor_Price.TabIndex = 11;
            // 
            // Tb_Motor_Power
            // 
            this.Tb_Motor_Power.Location = new System.Drawing.Point(1176, 66);
            this.Tb_Motor_Power.Name = "Tb_Motor_Power";
            this.Tb_Motor_Power.Size = new System.Drawing.Size(100, 24);
            this.Tb_Motor_Power.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "ابحث";
            // 
            // Tb_Motor_search
            // 
            this.Tb_Motor_search.Location = new System.Drawing.Point(12, 13);
            this.Tb_Motor_search.Name = "Tb_Motor_search";
            this.Tb_Motor_search.Size = new System.Drawing.Size(155, 24);
            this.Tb_Motor_search.TabIndex = 16;
            this.Tb_Motor_search.TextChanged += new System.EventHandler(this.Tb_Motor_search_TextChanged);
            // 
            // BTN_Add
            // 
            this.BTN_Add.Location = new System.Drawing.Point(903, 495);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(190, 35);
            this.BTN_Add.TabIndex = 17;
            this.BTN_Add.Text = "اضافه";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // BTN_edit
            // 
            this.BTN_edit.Location = new System.Drawing.Point(605, 495);
            this.BTN_edit.Name = "BTN_edit";
            this.BTN_edit.Size = new System.Drawing.Size(190, 35);
            this.BTN_edit.TabIndex = 18;
            this.BTN_edit.Text = "تعديل";
            this.BTN_edit.UseVisualStyleBackColor = true;
            this.BTN_edit.Click += new System.EventHandler(this.BTN_edit_Click);
            // 
            // BTN_Delete
            // 
            this.BTN_Delete.Location = new System.Drawing.Point(290, 495);
            this.BTN_Delete.Name = "BTN_Delete";
            this.BTN_Delete.Size = new System.Drawing.Size(190, 35);
            this.BTN_Delete.TabIndex = 19;
            this.BTN_Delete.Text = "حذف";
            this.BTN_Delete.UseVisualStyleBackColor = true;
            this.BTN_Delete.Click += new System.EventHandler(this.BTN_Delete_Click);
            // 
            // BTN_to_bk_home
            // 
            this.BTN_to_bk_home.Location = new System.Drawing.Point(12, 495);
            this.BTN_to_bk_home.Name = "BTN_to_bk_home";
            this.BTN_to_bk_home.Size = new System.Drawing.Size(190, 35);
            this.BTN_to_bk_home.TabIndex = 20;
            this.BTN_to_bk_home.Text = "الصفحه الرئيسيه";
            this.BTN_to_bk_home.UseVisualStyleBackColor = true;
            this.BTN_to_bk_home.Click += new System.EventHandler(this.BTN_to_bk_home_Click);
            // 
            // BTN_to_bk_Previous_Page
            // 
            this.BTN_to_bk_Previous_Page.Location = new System.Drawing.Point(1176, 495);
            this.BTN_to_bk_Previous_Page.Name = "BTN_to_bk_Previous_Page";
            this.BTN_to_bk_Previous_Page.Size = new System.Drawing.Size(190, 35);
            this.BTN_to_bk_Previous_Page.TabIndex = 21;
            this.BTN_to_bk_Previous_Page.Text = "الصفحه السابقه";
            this.BTN_to_bk_Previous_Page.UseVisualStyleBackColor = true;
            this.BTN_to_bk_Previous_Page.Click += new System.EventHandler(this.BTN_to_bk_Previous_Page_Click);
            // 
            // MotorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 553);
            this.Controls.Add(this.BTN_to_bk_Previous_Page);
            this.Controls.Add(this.BTN_to_bk_home);
            this.Controls.Add(this.BTN_Delete);
            this.Controls.Add(this.BTN_edit);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.Tb_Motor_search);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Tb_Motor_Power);
            this.Controls.Add(this.Tb_Motor_Price);
            this.Controls.Add(this.Tb_Motor_Quntity);
            this.Controls.Add(this.Tb_Motor_Name);
            this.Controls.Add(this.TB_Motor_Id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Motor_DGV);
            this.Name = "MotorForm";
            this.Text = "MotorForm";
            this.Load += new System.EventHandler(this.MotorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Motor_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Motor_DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_Motor_Id;
        private System.Windows.Forms.TextBox Tb_Motor_Name;
        private System.Windows.Forms.TextBox Tb_Motor_Quntity;
        private System.Windows.Forms.TextBox Tb_Motor_Price;
        private System.Windows.Forms.TextBox Tb_Motor_Power;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Tb_Motor_search;
        private System.Windows.Forms.Button BTN_Add;
        private System.Windows.Forms.Button BTN_edit;
        private System.Windows.Forms.Button BTN_Delete;
        private System.Windows.Forms.Button BTN_to_bk_home;
        private System.Windows.Forms.Button BTN_to_bk_Previous_Page;
    }
}