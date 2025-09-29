using Motors_System.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Motors_System.Forms
{
    public partial class User_Form : Form
    {
        private readonly string connectionString;

        public User_Form()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }

        private void User_Form_Load(object sender, EventArgs e)
        {
            
            Cb_Role.Items.Clear();
            Cb_Role.Items.Add("Admin");
            Cb_Role.Items.Add("Employee");

            LoadUsers();
        }

        private void LoadUsers(string search = "")
        {
            try
            {
                List<User> usersList = new List<User>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT UserId, UserName, PasswordHash, Role FROM Users";

                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        query += " WHERE UserName LIKE @search";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (!string.IsNullOrWhiteSpace(search))
                        {
                            cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Role = reader.GetString(3)
                                };
                                usersList.Add(user);
                            }
                        }
                    }
                }

                // ربط البيانات بالـ DataGridView
                User_DGV.DataSource = usersList;

                // تعديل أسماء الأعمدة للعربي
                User_DGV.Columns["Id"].HeaderText = "رقم المستخدم";
                User_DGV.Columns["Name"].HeaderText = "اسم المستخدم";
                User_DGV.Columns["Password"].HeaderText = "كلمة المرور";
                User_DGV.Columns["Role"].HeaderText = "الدور";

                User_DGV.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل المستخدمين: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // دالة التحقق من صحة المدخلات
        private bool ValidateInput(string username, string password, string role)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;
            if (string.IsNullOrWhiteSpace(password)) return false;
            if (role != "Admin" && role != "Employee") return false;
            return true;
        }

        // إضافة مستخدم
        private void Btn_add_Click(object sender, EventArgs e)
        {
            string username = Tb_name.Text.Trim();
            string password = Tb_pass.Text.Trim();
            string role = Cb_Role.SelectedItem?.ToString();

            if (!ValidateInput(username, password, role))
            {
                MessageBox.Show("برجاء إدخال جميع البيانات بشكل صحيح.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Users (UserName, PasswordHash, Role) VALUES (@name, @pass, @role)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters.AddWithValue("@role", role);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("تمت الإضافة بنجاح ✅", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();
            ClearInputFields();
        }

        // تعديل مستخدم
        private void Btn_edit_Click(object sender, EventArgs e)
        {
            if (User_DGV.CurrentRow == null)
            {
                MessageBox.Show("برجاء اختيار مستخدم للتعديل.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)User_DGV.CurrentRow.Cells["Id"].Value;
            string username = Tb_name.Text.Trim();
            string password = Tb_pass.Text.Trim();
            string role = Cb_Role.SelectedItem?.ToString();

            if (!ValidateInput(username, password, role))
            {
                MessageBox.Show("برجاء إدخال جميع البيانات بشكل صحيح.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE Users SET UserName=@name, PasswordHash=@pass, Role=@role WHERE UserId=@id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters.AddWithValue("@role", role);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("تم التعديل بنجاح ✏️", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();
            ClearInputFields();
        }

        // حذف مستخدم
        private void Btn_delete_Click(object sender, EventArgs e)
        {
            if (User_DGV.CurrentRow == null)
            {
                MessageBox.Show("برجاء اختيار مستخدم للحذف.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)User_DGV.CurrentRow.Cells["Id"].Value;

            DialogResult result = MessageBox.Show("هل أنت متأكد من حذف هذا المستخدم؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Users WHERE UserId=@id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("تم الحذف بنجاح ❌", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();
            ClearInputFields();
        }

        private void ClearInputFields()
        {
            Tb_name.Clear();
            Tb_pass.Clear();
            Cb_Role.SelectedIndex = -1;
        }
    }
}
