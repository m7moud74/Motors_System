namespace Motors_System.Forms
{
    partial class LoginForm
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
            this.User_Name_TB = new System.Windows.Forms.TextBox();
            this.User_pass_Tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Login_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // User_Name_TB
            // 
            this.User_Name_TB.Font = new System.Drawing.Font("Tahoma", 16F);
            this.User_Name_TB.Location = new System.Drawing.Point(756, 365);
            this.User_Name_TB.Name = "User_Name_TB";
            this.User_Name_TB.Size = new System.Drawing.Size(250, 40);
            this.User_Name_TB.TabIndex = 0;
            this.User_Name_TB.TextChanged += new System.EventHandler(this.User_Name_TB_TextChanged);
            // 
            // User_pass_Tb
            // 
            this.User_pass_Tb.Font = new System.Drawing.Font("Tahoma", 16F);
            this.User_pass_Tb.Location = new System.Drawing.Point(756, 435);
            this.User_pass_Tb.Name = "User_pass_Tb";
            this.User_pass_Tb.Size = new System.Drawing.Size(250, 40);
            this.User_pass_Tb.TabIndex = 1;
            this.User_pass_Tb.TextChanged += new System.EventHandler(this.User_pass_Tb_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label1.Location = new System.Drawing.Point(1036, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "اسم المستخدم";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label2.Location = new System.Drawing.Point(1047, 435);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "كلمة المرور";
            // 
            // Login_Btn
            // 
            this.Login_Btn.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Login_Btn.Location = new System.Drawing.Point(800, 499);
            this.Login_Btn.Name = "Login_Btn";
            this.Login_Btn.Size = new System.Drawing.Size(150, 40);
            this.Login_Btn.TabIndex = 4;
            this.Login_Btn.Text = "تسجيل الدخول";
            this.Login_Btn.UseVisualStyleBackColor = true;
            this.Login_Btn.Click += new System.EventHandler(this.Login_Btn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Motors_System.Properties.Resources.شركه_المليجي;
            this.ClientSize = new System.Drawing.Size(1755, 885);
            this.Controls.Add(this.Login_Btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.User_pass_Tb);
            this.Controls.Add(this.User_Name_TB);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox User_Name_TB;
        private System.Windows.Forms.TextBox User_pass_Tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Login_Btn;
    }
}