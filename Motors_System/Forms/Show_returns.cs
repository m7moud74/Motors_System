using Motors_System.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Motors_System.Forms
{
    public partial class Show_returns : Form
    {
        private readonly string connectionString;

        public Show_returns()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized;
            ApplyDynamicTextDirection(this);
        }

        private void Show_returns_Load(object sender, EventArgs e)
        {
            LoadReturns();
        }

        private void LoadReturns()
        {
            try
            {
                List<Return> returnsList = new List<Return>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"SELECT Return_ID, Sales_ID, Return_Date, Customer_Name, Motor_Model, Returned_Quantity, Return_Amount
                                     FROM Returns";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Return ret = new Return
                                {
                                    Return_ID = reader.GetInt32(0),
                                    Sales_ID = reader.GetInt32(1),
                                    Return_Date = reader.GetDateTime(2),
                                    Customer_Name = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                    Motor_Model = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                    Returned_Quantity = reader.GetInt32(5),
                                    Return_Amount = reader.GetDecimal(6)
                                };

                                returnsList.Add(ret);
                            }
                        }
                    }
                }

                // ربط القائمة بالـ DataGridView
                dataGridView1.DataSource = returnsList;

                // تحسين عرض الأعمدة
                dataGridView1.Columns["Return_ID"].HeaderText = "رقم المرتجع";
                dataGridView1.Columns["Sales_ID"].HeaderText = "رقم البيع";
                dataGridView1.Columns["Return_Date"].HeaderText = "تاريخ المرتجع";
                dataGridView1.Columns["Customer_Name"].HeaderText = "اسم العميل";
                dataGridView1.Columns["Motor_Model"].HeaderText = "موديل الموتور";
                dataGridView1.Columns["Returned_Quantity"].HeaderText = "الكمية المرتجعة";
                dataGridView1.Columns["Return_Amount"].HeaderText = "المبلغ المرتجع";

                dataGridView1.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل المرتجعات: " + ex.Message);
            }
        }

        private void BTN_to_bk_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            var homeForm = new MainForm();
            homeForm.Show();
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
