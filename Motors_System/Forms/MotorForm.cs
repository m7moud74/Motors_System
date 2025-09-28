using Motors_System.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Motors_System.Forms
{
    public partial class MotorForm : Form
    {
        private readonly string connectionString;

        public MotorForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }

        private void MotorForm_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData(string search = "")
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Motors";

                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        query += " WHERE MotorName LIKE @search";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (!string.IsNullOrWhiteSpace(search))
                        {
                            cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                        }

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            List<Motor> motors = new List<Motor>();

                            while (dr.Read())
                            {
                                Motor motor = new Motor
                                {
                                    MotorId = Convert.ToInt32(dr["MotorId"]),
                                    MotorName = dr["MotorName"].ToString(),
                                    Description = dr["Description"].ToString(),
                                    Power = Convert.ToDecimal(dr["Power"]),
                                    Price = Convert.ToDecimal(dr["Price"]),
                                    StockQuantity = dr["StockQuantity"] != DBNull.Value ? Convert.ToInt32(dr["StockQuantity"]) : (int?)null,
                                    Category_id = Convert.ToInt32(dr["CategoryId"])
                                };
                                motors.Add(motor);
                            }
                            Motor_DGV.DataSource = motors;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في الاتصال: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Tb_Motor_search_TextChanged(object sender, EventArgs e)
        {
            FillData(Tb_Motor_search.Text);
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("برجاء ملء جميع البيانات المطلوبة بشكل صحيح", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO Motors (MotorName, Description, Power, Price, StockQuantity, CategoryId) VALUES (@name, @desc, @power, @price, @stock, @cat)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", Tb_Motor_Name.Text.Trim());
                        cmd.Parameters.AddWithValue("@desc", Tb_Motor_Decs.Text.Trim());
                        cmd.Parameters.AddWithValue("@power", decimal.Parse(Tb_Motor_Power.Text));
                        cmd.Parameters.AddWithValue("@price", decimal.Parse(Tb_Motor_Price.Text));
                        cmd.Parameters.AddWithValue("@stock", int.Parse(Tb_Motor_Quntity.Text));
                        cmd.Parameters.AddWithValue("@cat", int.Parse(Tb_Motor_Category_Id.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تمت الإضافة بنجاح ✅", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputFields();
                        FillData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في الإضافة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BTN_edit_Click(object sender, EventArgs e)
        {
            if (Motor_DGV.CurrentRow == null)
            {
                MessageBox.Show("برجاء اختيار محرك للتعديل", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
            {
                MessageBox.Show("برجاء ملء جميع البيانات المطلوبة بشكل صحيح", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    int id = (int)Motor_DGV.CurrentRow.Cells["MotorId"].Value;
                    con.Open();
                    string query = "UPDATE Motors SET MotorName=@name, Description=@desc, Power=@power, Price=@price, StockQuantity=@stock, CategoryId=@cat WHERE MotorId=@id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", Tb_Motor_Name.Text.Trim());
                        cmd.Parameters.AddWithValue("@desc", Tb_Motor_Decs.Text.Trim());
                        cmd.Parameters.AddWithValue("@power", decimal.Parse(Tb_Motor_Power.Text));
                        cmd.Parameters.AddWithValue("@price", decimal.Parse(Tb_Motor_Price.Text));
                        cmd.Parameters.AddWithValue("@stock", int.Parse(Tb_Motor_Quntity.Text));
                        cmd.Parameters.AddWithValue("@cat", int.Parse(Tb_Motor_Category_Id.Text));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("تم التعديل بنجاح ✏️", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputFields();
                            FillData();
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على المحرك المطلوب تعديله", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في التعديل: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            if (Motor_DGV.CurrentRow == null)
            {
                MessageBox.Show("برجاء اختيار محرك للحذف", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("هل أنت متأكد من حذف هذا المحرك؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    int id = (int)Motor_DGV.CurrentRow.Cells["MotorId"].Value;
                    con.Open();
                    string query = "DELETE FROM Motors WHERE MotorId=@id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("تم الحذف بنجاح ❌", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputFields();
                            FillData();
                        }
                        else
                        {
                            MessageBox.Show("لم يتم العثور على المحرك المطلوب حذفه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في الحذف: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(Tb_Motor_Name.Text))
                return false;

            if (!decimal.TryParse(Tb_Motor_Power.Text, out _))
                return false;

            if (!decimal.TryParse(Tb_Motor_Price.Text, out _))
                return false;

            if (!int.TryParse(Tb_Motor_Quntity.Text, out _))
                return false;

            if (!int.TryParse(Tb_Motor_Category_Id.Text, out _))
                return false;

            return true;
        }

        private void ClearInputFields()
        {
            Tb_Motor_Name.Clear();
            Tb_Motor_Decs.Clear();
            Tb_Motor_Power.Clear();
            Tb_Motor_Price.Clear();
            Tb_Motor_Quntity.Clear();
            Tb_Motor_Category_Id.Clear();
        }

        private void BTN_to_bk_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            var homeForm = new MainForm();
            homeForm.Show();
        }

        private void BTN_to_bk_Previous_Page_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Motor_DGV_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Motor_DGV.CurrentRow != null)
            {
                TB_Motor_Id.Text = Motor_DGV.CurrentRow.Cells["MotorId"].Value?.ToString() ?? "";
                Tb_Motor_Name.Text = Motor_DGV.CurrentRow.Cells["MotorName"].Value?.ToString() ?? "";
                Tb_Motor_Decs.Text = Motor_DGV.CurrentRow.Cells["Description"].Value?.ToString() ?? "";
                Tb_Motor_Power.Text = Motor_DGV.CurrentRow.Cells["Power"].Value?.ToString() ?? "";
                Tb_Motor_Price.Text = Motor_DGV.CurrentRow.Cells["Price"].Value?.ToString() ?? "";
                Tb_Motor_Quntity.Text = Motor_DGV.CurrentRow.Cells["StockQuantity"].Value?.ToString() ?? "";
                Tb_Motor_Category_Id.Text = Motor_DGV.CurrentRow.Cells["Category_id"].Value?.ToString() ?? "";
            }
        }

     
    }
}
