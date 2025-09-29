namespace Motors_System.Forms
{
    partial class Returns
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
            this.dgv_Return = new System.Windows.Forms.DataGridView();
            this.TB_Motor_Name = new System.Windows.Forms.TextBox();
            this.TB_Custmor_name = new System.Windows.Forms.TextBox();
            this.Tb_price_Total = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_Order_Quntity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Employee_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_Order_Id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB__order_Date = new System.Windows.Forms.TextBox();
            this.Tb_Contact = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_to_return = new System.Windows.Forms.Button();
            this.dtp_FromDate = new System.Windows.Forms.DateTimePicker();
            this.btn_ShowSalesFromDate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Return)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Return
            // 
            this.dgv_Return.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Return.Location = new System.Drawing.Point(54, 327);
            this.dgv_Return.Name = "dgv_Return";
            this.dgv_Return.RowHeadersWidth = 51;
            this.dgv_Return.RowTemplate.Height = 26;
            this.dgv_Return.Size = new System.Drawing.Size(1083, 207);
            this.dgv_Return.TabIndex = 0;
            this.dgv_Return.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Return_RowHeaderMouseDoubleClick);
            // 
            // TB_Motor_Name
            // 
            this.TB_Motor_Name.Location = new System.Drawing.Point(1037, 155);
            this.TB_Motor_Name.Name = "TB_Motor_Name";
            this.TB_Motor_Name.Size = new System.Drawing.Size(100, 24);
            this.TB_Motor_Name.TabIndex = 41;
            // 
            // TB_Custmor_name
            // 
            this.TB_Custmor_name.Location = new System.Drawing.Point(1037, 43);
            this.TB_Custmor_name.Name = "TB_Custmor_name";
            this.TB_Custmor_name.Size = new System.Drawing.Size(100, 24);
            this.TB_Custmor_name.TabIndex = 40;
            // 
            // Tb_price_Total
            // 
            this.Tb_price_Total.Location = new System.Drawing.Point(1037, 215);
            this.Tb_price_Total.Name = "Tb_price_Total";
            this.Tb_price_Total.Size = new System.Drawing.Size(100, 24);
            this.Tb_price_Total.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1143, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "السعر الكلي";
            // 
            // TB_Order_Quntity
            // 
            this.TB_Order_Quntity.Location = new System.Drawing.Point(1037, 185);
            this.TB_Order_Quntity.Name = "TB_Order_Quntity";
            this.TB_Order_Quntity.Size = new System.Drawing.Size(100, 24);
            this.TB_Order_Quntity.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1161, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "المحرك";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1149, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "تاريخ الطلب";
            // 
            // TB_Employee_Name
            // 
            this.TB_Employee_Name.Location = new System.Drawing.Point(1037, 95);
            this.TB_Employee_Name.Name = "TB_Employee_Name";
            this.TB_Employee_Name.Size = new System.Drawing.Size(100, 24);
            this.TB_Employee_Name.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1161, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "الموظف";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1154, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "العميل";
            // 
            // TB_Order_Id
            // 
            this.TB_Order_Id.Location = new System.Drawing.Point(1037, 12);
            this.TB_Order_Id.Name = "TB_Order_Id";
            this.TB_Order_Id.Size = new System.Drawing.Size(100, 24);
            this.TB_Order_Id.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1143, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "رقم الاوردر";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1162, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "الكميه";
            // 
            // TB__order_Date
            // 
            this.TB__order_Date.Location = new System.Drawing.Point(1037, 125);
            this.TB__order_Date.Name = "TB__order_Date";
            this.TB__order_Date.Size = new System.Drawing.Size(100, 24);
            this.TB__order_Date.TabIndex = 26;
            // 
            // Tb_Contact
            // 
            this.Tb_Contact.Location = new System.Drawing.Point(1037, 69);
            this.Tb_Contact.Name = "Tb_Contact";
            this.Tb_Contact.Size = new System.Drawing.Size(100, 24);
            this.Tb_Contact.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1154, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 43;
            this.label9.Text = "رقم الهاتف";
            // 
            // btn_to_return
            // 
            this.btn_to_return.Location = new System.Drawing.Point(340, 182);
            this.btn_to_return.Name = "btn_to_return";
            this.btn_to_return.Size = new System.Drawing.Size(75, 23);
            this.btn_to_return.TabIndex = 44;
            this.btn_to_return.Text = "مرتجع";
            this.btn_to_return.UseVisualStyleBackColor = true;
            this.btn_to_return.Click += new System.EventHandler(this.btn_to_return_Click);
            // 
            // dtp_FromDate
            // 
            this.dtp_FromDate.Location = new System.Drawing.Point(12, 12);
            this.dtp_FromDate.Name = "dtp_FromDate";
            this.dtp_FromDate.Size = new System.Drawing.Size(200, 24);
            this.dtp_FromDate.TabIndex = 45;
            // 
            // btn_ShowSalesFromDate
            // 
            this.btn_ShowSalesFromDate.Location = new System.Drawing.Point(409, 72);
            this.btn_ShowSalesFromDate.Name = "btn_ShowSalesFromDate";
            this.btn_ShowSalesFromDate.Size = new System.Drawing.Size(75, 23);
            this.btn_ShowSalesFromDate.TabIndex = 46;
            this.btn_ShowSalesFromDate.Text = "المبيعات";
            this.btn_ShowSalesFromDate.UseVisualStyleBackColor = true;
            this.btn_ShowSalesFromDate.Click += new System.EventHandler(this.btn_ShowSalesFromDate_Click);
            // 
            // Returns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 546);
            this.Controls.Add(this.btn_ShowSalesFromDate);
            this.Controls.Add(this.dtp_FromDate);
            this.Controls.Add(this.btn_to_return);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Tb_Contact);
            this.Controls.Add(this.TB_Motor_Name);
            this.Controls.Add(this.TB_Custmor_name);
            this.Controls.Add(this.Tb_price_Total);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TB_Order_Quntity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_Employee_Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Order_Id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB__order_Date);
            this.Controls.Add(this.dgv_Return);
            this.Name = "Returns";
            this.Text = "Returns";
            this.Load += new System.EventHandler(this.Returns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Return)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Return;
        private System.Windows.Forms.TextBox TB_Motor_Name;
        private System.Windows.Forms.TextBox TB_Custmor_name;
        private System.Windows.Forms.TextBox Tb_price_Total;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_Order_Quntity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_Employee_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_Order_Id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB__order_Date;
        private System.Windows.Forms.TextBox Tb_Contact;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_to_return;
        private System.Windows.Forms.DateTimePicker dtp_FromDate;
        private System.Windows.Forms.Button btn_ShowSalesFromDate;
    }
}