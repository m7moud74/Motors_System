namespace Motors_System.Forms
{
    partial class Show_returns
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BTN_to_bk_home = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(230, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.Size = new System.Drawing.Size(776, 352);
            this.dataGridView1.TabIndex = 0;
            // 
            // BTN_to_bk_home
            // 
            this.BTN_to_bk_home.Location = new System.Drawing.Point(509, 443);
            this.BTN_to_bk_home.Name = "BTN_to_bk_home";
            this.BTN_to_bk_home.Size = new System.Drawing.Size(190, 35);
            this.BTN_to_bk_home.TabIndex = 48;
            this.BTN_to_bk_home.Text = "الصفحه الرئيسيه";
            this.BTN_to_bk_home.UseVisualStyleBackColor = true;
            this.BTN_to_bk_home.Click += new System.EventHandler(this.BTN_to_bk_home_Click);
            // 
            // Show_returns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 552);
            this.Controls.Add(this.BTN_to_bk_home);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Show_returns";
            this.Text = "Show_returns";
            this.Load += new System.EventHandler(this.Show_returns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BTN_to_bk_home;
    }
}