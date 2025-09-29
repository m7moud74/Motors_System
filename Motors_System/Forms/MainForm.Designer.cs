namespace Motors_System.Forms
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Go_returns_btn = new System.Windows.Forms.Button();
            this.Go_Users_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(303, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "المواتير";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(215, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "فاتوره بيع";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Go_returns_btn
            // 
            this.Go_returns_btn.Location = new System.Drawing.Point(376, 136);
            this.Go_returns_btn.Name = "Go_returns_btn";
            this.Go_returns_btn.Size = new System.Drawing.Size(75, 23);
            this.Go_returns_btn.TabIndex = 2;
            this.Go_returns_btn.Text = "المرتجعات";
            this.Go_returns_btn.UseVisualStyleBackColor = true;
            this.Go_returns_btn.Click += new System.EventHandler(this.button3_Click);
            // 
            // Go_Users_btn
            // 
            this.Go_Users_btn.Location = new System.Drawing.Point(376, 193);
            this.Go_Users_btn.Name = "Go_Users_btn";
            this.Go_Users_btn.Size = new System.Drawing.Size(118, 32);
            this.Go_Users_btn.TabIndex = 3;
            this.Go_Users_btn.Text = "المستخدمين";
            this.Go_Users_btn.UseVisualStyleBackColor = true;
            this.Go_Users_btn.Click += new System.EventHandler(this.Go_Users_btn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.Go_Users_btn);
            this.Controls.Add(this.Go_returns_btn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Go_returns_btn;
        private System.Windows.Forms.Button Go_Users_btn;
    }
}