namespace Motors_System.Forms
{
    partial class Sales_invoice_Form
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
            this.TB_Motor_Date = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Order_Id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Employee_Id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_OrderDetails = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Tb_Salary_Total = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Btn_Sell = new System.Windows.Forms.Button();
            this.btn_add_Motor_To_sell = new System.Windows.Forms.Button();
            this.Btn_Update_Motor_To_sell = new System.Windows.Forms.Button();
            this.Btn_delete_Motor_before_selll = new System.Windows.Forms.Button();
            this.TB_Custmor_name = new System.Windows.Forms.TextBox();
            this.TB_Motor_Name = new System.Windows.Forms.TextBox();
            this.BTN_to_bk_home = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TB_Motor_Date
            // 
            this.TB_Motor_Date.Location = new System.Drawing.Point(1108, 46);
            this.TB_Motor_Date.Name = "TB_Motor_Date";
            this.TB_Motor_Date.Size = new System.Drawing.Size(100, 24);
            this.TB_Motor_Date.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(818, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "الكميه";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1217, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "رقم الاوردر";
            // 
            // TB_Order_Id
            // 
            this.TB_Order_Id.Location = new System.Drawing.Point(1108, 12);
            this.TB_Order_Id.Name = "TB_Order_Id";
            this.TB_Order_Id.Size = new System.Drawing.Size(100, 24);
            this.TB_Order_Id.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(987, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "العميل";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(810, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "الموظف";
            // 
            // TB_Employee_Id
            // 
            this.TB_Employee_Id.Location = new System.Drawing.Point(704, 9);
            this.TB_Employee_Id.Name = "TB_Employee_Id";
            this.TB_Employee_Id.Size = new System.Drawing.Size(100, 24);
            this.TB_Employee_Id.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1217, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "تاريخ الطلب";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(987, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "المحرك";
            // 
            // TB_OrderDetails
            // 
            this.TB_OrderDetails.Location = new System.Drawing.Point(704, 49);
            this.TB_OrderDetails.Name = "TB_OrderDetails";
            this.TB_OrderDetails.Size = new System.Drawing.Size(100, 24);
            this.TB_OrderDetails.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(912, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "السعر الكلي";
            // 
            // Tb_Salary_Total
            // 
            this.Tb_Salary_Total.Location = new System.Drawing.Point(905, 129);
            this.Tb_Salary_Total.Name = "Tb_Salary_Total";
            this.Tb_Salary_Total.Size = new System.Drawing.Size(100, 24);
            this.Tb_Salary_Total.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(73, 264);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.Size = new System.Drawing.Size(1135, 150);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // Btn_Sell
            // 
            this.Btn_Sell.Location = new System.Drawing.Point(557, 425);
            this.Btn_Sell.Name = "Btn_Sell";
            this.Btn_Sell.Size = new System.Drawing.Size(224, 58);
            this.Btn_Sell.TabIndex = 19;
            this.Btn_Sell.Text = "بيع";
            this.Btn_Sell.UseVisualStyleBackColor = true;
            this.Btn_Sell.Click += new System.EventHandler(this.Btn_Sell_Click);
            // 
            // btn_add_Motor_To_sell
            // 
            this.btn_add_Motor_To_sell.Location = new System.Drawing.Point(1041, 434);
            this.btn_add_Motor_To_sell.Name = "btn_add_Motor_To_sell";
            this.btn_add_Motor_To_sell.Size = new System.Drawing.Size(177, 35);
            this.btn_add_Motor_To_sell.TabIndex = 21;
            this.btn_add_Motor_To_sell.Text = "اضافه";
            this.btn_add_Motor_To_sell.UseVisualStyleBackColor = true;
            this.btn_add_Motor_To_sell.Click += new System.EventHandler(this.btn_add_Motor_To_sell_Click);
            // 
            // Btn_Update_Motor_To_sell
            // 
            this.Btn_Update_Motor_To_sell.Location = new System.Drawing.Point(838, 437);
            this.Btn_Update_Motor_To_sell.Name = "Btn_Update_Motor_To_sell";
            this.Btn_Update_Motor_To_sell.Size = new System.Drawing.Size(177, 32);
            this.Btn_Update_Motor_To_sell.TabIndex = 22;
            this.Btn_Update_Motor_To_sell.Text = "تعديل";
            this.Btn_Update_Motor_To_sell.UseVisualStyleBackColor = true;
            this.Btn_Update_Motor_To_sell.Click += new System.EventHandler(this.Btn_Update_Motor_To_sell_Click);
            // 
            // Btn_delete_Motor_before_selll
            // 
            this.Btn_delete_Motor_before_selll.Location = new System.Drawing.Point(271, 437);
            this.Btn_delete_Motor_before_selll.Name = "Btn_delete_Motor_before_selll";
            this.Btn_delete_Motor_before_selll.Size = new System.Drawing.Size(202, 35);
            this.Btn_delete_Motor_before_selll.TabIndex = 23;
            this.Btn_delete_Motor_before_selll.Text = "حذف";
            this.Btn_delete_Motor_before_selll.UseVisualStyleBackColor = true;
            this.Btn_delete_Motor_before_selll.Click += new System.EventHandler(this.Btn_delete_Motor_before_selll_Click);
            // 
            // TB_Custmor_name
            // 
            this.TB_Custmor_name.Location = new System.Drawing.Point(881, 12);
            this.TB_Custmor_name.Name = "TB_Custmor_name";
            this.TB_Custmor_name.Size = new System.Drawing.Size(100, 24);
            this.TB_Custmor_name.TabIndex = 24;
            // 
            // TB_Motor_Name
            // 
            this.TB_Motor_Name.Location = new System.Drawing.Point(881, 46);
            this.TB_Motor_Name.Name = "TB_Motor_Name";
            this.TB_Motor_Name.Size = new System.Drawing.Size(100, 24);
            this.TB_Motor_Name.TabIndex = 25;
            // 
            // BTN_to_bk_home
            // 
            this.BTN_to_bk_home.Location = new System.Drawing.Point(57, 437);
            this.BTN_to_bk_home.Name = "BTN_to_bk_home";
            this.BTN_to_bk_home.Size = new System.Drawing.Size(199, 35);
            this.BTN_to_bk_home.TabIndex = 48;
            this.BTN_to_bk_home.Text = "الصفحه الرئيسيه";
            this.BTN_to_bk_home.UseVisualStyleBackColor = true;
            this.BTN_to_bk_home.Click += new System.EventHandler(this.BTN_to_bk_home_Click);
            // 
            // Sales_invoice_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 504);
            this.Controls.Add(this.BTN_to_bk_home);
            this.Controls.Add(this.TB_Motor_Name);
            this.Controls.Add(this.TB_Custmor_name);
            this.Controls.Add(this.Btn_delete_Motor_before_selll);
            this.Controls.Add(this.Btn_Update_Motor_To_sell);
            this.Controls.Add(this.btn_add_Motor_To_sell);
            this.Controls.Add(this.Btn_Sell);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Tb_Salary_Total);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TB_OrderDetails);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_Employee_Id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Order_Id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Motor_Date);
            this.Name = "Sales_invoice_Form";
            this.Text = "Sales_invoice_Form";
            this.Load += new System.EventHandler(this.Sales_invoice_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TB_Motor_Date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Order_Id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Employee_Id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_OrderDetails;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Tb_Salary_Total;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Btn_Sell;
        private System.Windows.Forms.Button btn_add_Motor_To_sell;
        private System.Windows.Forms.Button Btn_Update_Motor_To_sell;
        private System.Windows.Forms.Button Btn_delete_Motor_before_selll;
        private System.Windows.Forms.TextBox TB_Custmor_name;
        private System.Windows.Forms.TextBox TB_Motor_Name;
        private System.Windows.Forms.Button BTN_to_bk_home;
    }
}