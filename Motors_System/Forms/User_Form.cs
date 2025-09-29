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
            
            if (CurrentUser.Role != "Admin")
            {
                MessageBox.Show("غير مسموح لك بالدخول إلى هذه الصفحة. فقط المسؤول (Admin) يمكنه الوصول.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close(); 
                return;
            }

           
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

                // تعديل حجم الأعمدة تلقائيًا
                User_DGV.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل المستخدمين: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
