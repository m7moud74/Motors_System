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
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.button1.Location = new System.Drawing.Point(673, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(399, 73);
            this.button1.TabIndex = 0;
            this.button1.Text = "اضافه مواتير";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 16F);
            this.button2.Location = new System.Drawing.Point(988, 399);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(399, 73);
            this.button2.TabIndex = 1;
            this.button2.Text = "فاتوره بيع";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Go_returns_btn
            // 
            this.Go_returns_btn.Font = new System.Drawing.Font("Tahoma", 16F);
            this.Go_returns_btn.Location = new System.Drawing.Point(389, 399);
            this.Go_returns_btn.Name = "Go_returns_btn";
            this.Go_returns_btn.Size = new System.Drawing.Size(399, 73);
            this.Go_returns_btn.TabIndex = 2;
            this.Go_returns_btn.Text = "المبيعات و اضافه مرتجع";
            this.Go_returns_btn.UseVisualStyleBackColor = true;
            this.Go_returns_btn.Click += new System.EventHandler(this.button3_Click);
            // 
            // Go_Users_btn
            // 
            this.Go_Users_btn.Font = new System.Drawing.Font("Tahoma", 16F);
            this.Go_Users_btn.Location = new System.Drawing.Point(988, 637);
            this.Go_Users_btn.Name = "Go_Users_btn";
            this.Go_Users_btn.Size = new System.Drawing.Size(399, 73);
            this.Go_Users_btn.TabIndex = 3;
            this.Go_Users_btn.Text = "المستخدمين";
            this.Go_Users_btn.UseVisualStyleBackColor = true;
            this.Go_Users_btn.Click += new System.EventHandler(this.Go_Users_btn_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 16F);
            this.button3.Location = new System.Drawing.Point(389, 637);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(399, 73);
            this.button3.TabIndex = 4;
            this.button3.Text = "المرتجعات";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1836, 1055);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Go_Users_btn);
            this.Controls.Add(this.Go_returns_btn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Go_returns_btn;
        private System.Windows.Forms.Button Go_Users_btn;
        private System.Windows.Forms.Button button3;
    }
}