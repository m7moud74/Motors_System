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
            this.label6 = new System.Windows.Forms.Label();
            this.Tb_Tybe = new System.Windows.Forms.TextBox();
            this.DTB_Add = new System.Windows.Forms.DateTimePicker();
            this.Btn_Sjow_by_Time = new System.Windows.Forms.Button();
            this.btn_Show_all = new System.Windows.Forms.Button();
            this.Btn_Show_TotalPriceByDay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Motor_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Motor_DGV
            // 
            this.Motor_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Motor_DGV.Location = new System.Drawing.Point(488, 255);
            this.Motor_DGV.Name = "Motor_DGV";
            this.Motor_DGV.RowHeadersWidth = 51;
            this.Motor_DGV.RowTemplate.Height = 24;
            this.Motor_DGV.Size = new System.Drawing.Size(700, 531);
            this.Motor_DGV.TabIndex = 0;
            this.Motor_DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Motor_DGV_CellContentClick);
            this.Motor_DGV.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Motor_DGV_RowHeaderMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label1.Location = new System.Drawing.Point(1648, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "الاسم";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label2.Location = new System.Drawing.Point(1648, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "رقم المحرك";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label3.Location = new System.Drawing.Point(1648, 553);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 33);
            this.label3.TabIndex = 3;
            this.label3.Text = "الكميه";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label4.Location = new System.Drawing.Point(1648, 505);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 33);
            this.label4.TabIndex = 4;
            this.label4.Text = "السعر ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label5.Location = new System.Drawing.Point(1648, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 33);
            this.label5.TabIndex = 5;
            this.label5.Text = "القوه";
            // 
            // TB_Motor_Id
            // 
            this.TB_Motor_Id.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Motor_Id.Font = new System.Drawing.Font("Tahoma", 12F);
            this.TB_Motor_Id.Location = new System.Drawing.Point(1365, 303);
            this.TB_Motor_Id.Name = "TB_Motor_Id";
            this.TB_Motor_Id.Size = new System.Drawing.Size(250, 32);
            this.TB_Motor_Id.TabIndex = 0;
            this.TB_Motor_Id.TextChanged += new System.EventHandler(this.TB_Motor_Id_TextChanged);
            // 
            // Tb_Motor_Name
            // 
            this.Tb_Motor_Name.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Tb_Motor_Name.Location = new System.Drawing.Point(1365, 346);
            this.Tb_Motor_Name.Name = "Tb_Motor_Name";
            this.Tb_Motor_Name.Size = new System.Drawing.Size(250, 32);
            this.Tb_Motor_Name.TabIndex = 1;
            this.Tb_Motor_Name.TextChanged += new System.EventHandler(this.Tb_Motor_Name_TextChanged);
            // 
            // Tb_Motor_Quntity
            // 
            this.Tb_Motor_Quntity.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Tb_Motor_Quntity.Location = new System.Drawing.Point(1365, 553);
            this.Tb_Motor_Quntity.Name = "Tb_Motor_Quntity";
            this.Tb_Motor_Quntity.Size = new System.Drawing.Size(250, 32);
            this.Tb_Motor_Quntity.TabIndex = 5;
            // 
            // Tb_Motor_Price
            // 
            this.Tb_Motor_Price.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Tb_Motor_Price.Location = new System.Drawing.Point(1365, 505);
            this.Tb_Motor_Price.Name = "Tb_Motor_Price";
            this.Tb_Motor_Price.Size = new System.Drawing.Size(250, 32);
            this.Tb_Motor_Price.TabIndex = 4;
            // 
            // Tb_Motor_Power
            // 
            this.Tb_Motor_Power.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Tb_Motor_Power.Location = new System.Drawing.Point(1365, 451);
            this.Tb_Motor_Power.Name = "Tb_Motor_Power";
            this.Tb_Motor_Power.Size = new System.Drawing.Size(250, 32);
            this.Tb_Motor_Power.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label8.Location = new System.Drawing.Point(299, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 33);
            this.label8.TabIndex = 15;
            this.label8.Text = "ابحث";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Tb_Motor_search
            // 
            this.Tb_Motor_search.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Tb_Motor_search.Location = new System.Drawing.Point(35, 33);
            this.Tb_Motor_search.Name = "Tb_Motor_search";
            this.Tb_Motor_search.Size = new System.Drawing.Size(250, 32);
            this.Tb_Motor_search.TabIndex = 16;
            this.Tb_Motor_search.TextChanged += new System.EventHandler(this.Tb_Motor_search_TextChanged);
            // 
            // BTN_Add
            // 
            this.BTN_Add.Font = new System.Drawing.Font("Tahoma", 16F);
            this.BTN_Add.Location = new System.Drawing.Point(1365, 887);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(399, 73);
            this.BTN_Add.TabIndex = 17;
            this.BTN_Add.Text = "اضافه";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // BTN_edit
            // 
            this.BTN_edit.Font = new System.Drawing.Font("Tahoma", 16F);
            this.BTN_edit.Location = new System.Drawing.Point(923, 887);
            this.BTN_edit.Name = "BTN_edit";
            this.BTN_edit.Size = new System.Drawing.Size(399, 73);
            this.BTN_edit.TabIndex = 18;
            this.BTN_edit.Text = "تعديل";
            this.BTN_edit.UseVisualStyleBackColor = true;
            this.BTN_edit.Click += new System.EventHandler(this.BTN_edit_Click);
            // 
            // BTN_Delete
            // 
            this.BTN_Delete.Font = new System.Drawing.Font("Tahoma", 16F);
            this.BTN_Delete.Location = new System.Drawing.Point(488, 887);
            this.BTN_Delete.Name = "BTN_Delete";
            this.BTN_Delete.Size = new System.Drawing.Size(399, 73);
            this.BTN_Delete.TabIndex = 19;
            this.BTN_Delete.Text = "حذف";
            this.BTN_Delete.UseVisualStyleBackColor = true;
            this.BTN_Delete.Click += new System.EventHandler(this.BTN_Delete_Click);
            // 
            // BTN_to_bk_home
            // 
            this.BTN_to_bk_home.Font = new System.Drawing.Font("Tahoma", 16F);
            this.BTN_to_bk_home.Location = new System.Drawing.Point(35, 887);
            this.BTN_to_bk_home.Name = "BTN_to_bk_home";
            this.BTN_to_bk_home.Size = new System.Drawing.Size(399, 73);
            this.BTN_to_bk_home.TabIndex = 20;
            this.BTN_to_bk_home.Text = "الصفحه الرئيسيه";
            this.BTN_to_bk_home.UseVisualStyleBackColor = true;
            this.BTN_to_bk_home.Click += new System.EventHandler(this.BTN_to_bk_home_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label6.Location = new System.Drawing.Point(1648, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 33);
            this.label6.TabIndex = 21;
            this.label6.Text = "النوع";
            // 
            // Tb_Tybe
            // 
            this.Tb_Tybe.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Tb_Tybe.Location = new System.Drawing.Point(1365, 393);
            this.Tb_Tybe.Name = "Tb_Tybe";
            this.Tb_Tybe.Size = new System.Drawing.Size(250, 32);
            this.Tb_Tybe.TabIndex = 2;
            // 
            // DTB_Add
            // 
            this.DTB_Add.Font = new System.Drawing.Font("Tahoma", 11F);
            this.DTB_Add.Location = new System.Drawing.Point(570, 115);
            this.DTB_Add.Name = "DTB_Add";
            this.DTB_Add.Size = new System.Drawing.Size(299, 30);
            this.DTB_Add.TabIndex = 22;
            // 
            // Btn_Sjow_by_Time
            // 
            this.Btn_Sjow_by_Time.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Btn_Sjow_by_Time.Location = new System.Drawing.Point(923, 116);
            this.Btn_Sjow_by_Time.Name = "Btn_Sjow_by_Time";
            this.Btn_Sjow_by_Time.Size = new System.Drawing.Size(131, 33);
            this.Btn_Sjow_by_Time.TabIndex = 23;
            this.Btn_Sjow_by_Time.Text = "الاضافات يوم";
            this.Btn_Sjow_by_Time.UseVisualStyleBackColor = true;
            this.Btn_Sjow_by_Time.Click += new System.EventHandler(this.Btn_Sjow_by_Time_Click);
            // 
            // btn_Show_all
            // 
            this.btn_Show_all.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Show_all.Location = new System.Drawing.Point(739, 34);
            this.btn_Show_all.Name = "btn_Show_all";
            this.btn_Show_all.Size = new System.Drawing.Size(232, 34);
            this.btn_Show_all.TabIndex = 24;
            this.btn_Show_all.Text = "عرض الكل";
            this.btn_Show_all.UseVisualStyleBackColor = true;
            this.btn_Show_all.Click += new System.EventHandler(this.btn_Show_all_Click);
            // 
            // Btn_Show_TotalPriceByDay
            // 
            this.Btn_Show_TotalPriceByDay.Font = new System.Drawing.Font("Tahoma", 11F);
            this.Btn_Show_TotalPriceByDay.Location = new System.Drawing.Point(739, 174);
            this.Btn_Show_TotalPriceByDay.Name = "Btn_Show_TotalPriceByDay";
            this.Btn_Show_TotalPriceByDay.Size = new System.Drawing.Size(232, 46);
            this.Btn_Show_TotalPriceByDay.TabIndex = 25;
            this.Btn_Show_TotalPriceByDay.Text = "اجمالي سعر الاضافات يوم";
            this.Btn_Show_TotalPriceByDay.UseVisualStyleBackColor = true;
            this.Btn_Show_TotalPriceByDay.Click += new System.EventHandler(this.Btn_Show_TotalPriceByDay_Click);
            // 
            // MotorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1824, 1030);
            this.Controls.Add(this.Btn_Show_TotalPriceByDay);
            this.Controls.Add(this.btn_Show_all);
            this.Controls.Add(this.Btn_Sjow_by_Time);
            this.Controls.Add(this.DTB_Add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Tb_Motor_Quntity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Tb_Motor_Price);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Tb_Tybe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tb_Motor_Power);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_to_bk_home);
            this.Controls.Add(this.Tb_Motor_Name);
            this.Controls.Add(this.TB_Motor_Id);
            this.Controls.Add(this.BTN_Delete);
            this.Controls.Add(this.BTN_edit);
            this.Controls.Add(this.BTN_Add);
            this.Controls.Add(this.Tb_Motor_search);
            this.Controls.Add(this.label8);
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Tb_Tybe;
        private System.Windows.Forms.DateTimePicker DTB_Add;
        private System.Windows.Forms.Button Btn_Sjow_by_Time;
        private System.Windows.Forms.Button btn_Show_all;
        private System.Windows.Forms.Button Btn_Show_TotalPriceByDay;
    }
}