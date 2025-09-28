using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Motors_System.Forms
{
    public partial class LoginForm : Form
    {
        public SqlCommand cmd;
        public SqlConnection con;
        public LoginForm()
        {
            InitializeComponent();

        }

        private void User_Name_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void User_pass_Tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Btn_Click(object sender, EventArgs e)
        {
            string username = User_Name_TB.Text.Trim();
            string password = User_pass_Tb.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("من فضلك أدخل اسم المستخدم وكلمة المرور", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // جلب connection string من App.config
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE UserName=@uname AND PasswordHash=@pass";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@uname", username);
                        cmd.Parameters.AddWithValue("@pass", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("تم تسجيل الدخول بنجاح ✅", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // افتح الفورم الرئيسي
                            MainForm main = new MainForm();
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة ❌", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في الاتصال: " + ex.Message);
                }
            }
        }
    }
}
