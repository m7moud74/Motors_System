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
            ((System.ComponentModel.ISupportInitialize)(this.Motor_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Motor_DGV
            // 
            this.Motor_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Motor_DGV.Location = new System.Drawing.Point(12, 227);
            this.Motor_DGV.Name = "Motor_DGV";
            this.Motor_DGV.RowHeadersWidth = 51;
            this.Motor_DGV.RowTemplate.Height = 24;
            this.Motor_DGV.Size = new System.Drawing.Size(761, 156);
            this.Motor_DGV.TabIndex = 0;
            this.Motor_DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Motor_DGV_CellContentClick);
            // 
            // MotorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Motor_DGV);
            this.Name = "MotorForm";
            this.Text = "MotorForm";
            ((System.ComponentModel.ISupportInitialize)(this.Motor_DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Motor_DGV;
    }
}