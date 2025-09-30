using Motors_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motors_System.Forms
{
    public partial class LoginForm : Form
    {
        public SqlCommand cmd;
        public SqlConnection con;
        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog; 
            this.MaximizeBox = false; 
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized;
            ApplyDynamicTextDirection(this);



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
                    // جلب بيانات المستخدم إذا كانت مطابقة
                    string query = "SELECT UserId, UserName, PasswordHash, Role FROM Users WHERE UserName=@uname AND PasswordHash=@pass";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@uname", username);
                        cmd.Parameters.AddWithValue("@pass", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // حفظ بيانات المستخدم في CurrentUser
                                CurrentUser.Id = reader.GetInt32(0);
                                CurrentUser.Name = reader.GetString(1);
                                CurrentUser.Role = reader.GetString(3);

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في الاتصال: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
        private void ApplyDynamicTextDirection(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox tb)
                {
                    tb.TextChanged += (s, e) =>
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(tb.Text, @"\p{IsArabic}"))
                        {
                            tb.RightToLeft = RightToLeft.Yes;  // عربي
                            tb.SelectionStart = tb.Text.Length; // المؤشر في الآخر
                        }
                        else
                        {
                            tb.RightToLeft = RightToLeft.No;   // انجليزي
                            tb.SelectionStart = tb.Text.Length; // المؤشر في الآخر
                        }
                    };
                }
                else if (ctrl.HasChildren)
                {
                    ApplyDynamicTextDirection(ctrl); // لو فيه Controls جوه Panel أو GroupBox
                }
            }
        }
    }
}
