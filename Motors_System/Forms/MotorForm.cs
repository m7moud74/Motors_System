using Motors_System.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
            Tb_Motor_Name.KeyDown += TextBox_KeyDown;
            Tb_Tybe.KeyDown += TextBox_KeyDown;
            Tb_Motor_Power.KeyDown += TextBox_KeyDown;
            Tb_Motor_Price.KeyDown += TextBox_KeyDown;
            Tb_Motor_Quntity.KeyDown += TextBox_KeyDown;
            Motor_DGV.TabStop = false;
            Tb_Motor_search.TabStop = false;

        }

        private void MotorForm_Load(object sender, EventArgs e)
        {
            TB_Motor_Id.Enabled = false;
            FillData();
            // تكبير خط العناوين
            Motor_DGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);

            // محاذاة العناوين في النص
            Motor_DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // تكبير خط الخلايا
            Motor_DGV.DefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Regular);

            // محاذاة الخلايا في النص
            Motor_DGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // تظليل الصفوف بالتبادل
            Motor_DGV.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // زيادة ارتفاع الصفوف
            Motor_DGV.RowTemplate.Height = 30;

            // حجم الأعمدة والصفوف تلقائيًا
            Motor_DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Motor_DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // ضبط ارتفاع العناوين تلقائيًا
            Motor_DGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
  
         
            ApplyTextBoxAlternateColors(this);
            TB_Motor_Id.BackColor = Color.LightGray;
            TB_Motor_Id.ForeColor = Color.Black;




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
                                    Type = dr["MotorType"] != DBNull.Value ? dr["MotorType"].ToString() : "",
                                    Power = Convert.ToDecimal(dr["Power"]),
                                    Price = Convert.ToDecimal(dr["Price"]),
                                    StockQuantity = dr["StockQuantity"] != DBNull.Value ? Convert.ToInt32(dr["StockQuantity"]) : (int?)null,
                                };
                                motors.Add(motor);
                            }
                            Motor_DGV.DataSource = motors;

                            Motor_DGV.Columns["MotorId"].HeaderText = "رقم المحرك";
                            Motor_DGV.Columns["MotorName"].HeaderText = "اسم المحرك";
                            Motor_DGV.Columns["Type"].HeaderText = "النوع";
                            Motor_DGV.Columns["Power"].HeaderText = "القوة";
                            Motor_DGV.Columns["Price"].HeaderText = "السعر";
                            Motor_DGV.Columns["StockQuantity"].HeaderText = "الكمية المتوفرة";

                            Motor_DGV.AutoResizeColumns();
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
            if (!ValidateInputForAdd())
            {
                MessageBox.Show("برجاء ملء جميع البيانات المطلوبة بشكل صحيح", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();


                    string checkQuery = "SELECT COUNT(*) FROM Motors WHERE MotorName = @name AND MotorType = @type";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@name", Tb_Motor_Name.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@type", Tb_Tybe.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("⚠️ هذا المحرك بنفس الاسم والنوع موجود بالفعل، من فضلك اختر بيانات مختلفة.",
                                "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query = "INSERT INTO Motors (MotorName, MotorType, Power, Price, StockQuantity) VALUES (@name,@type,@power,@price,@stock)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", Tb_Motor_Name.Text.Trim());
                        cmd.Parameters.AddWithValue("@type", Tb_Tybe.Text.Trim());
                        cmd.Parameters.AddWithValue("@power", decimal.Parse(Tb_Motor_Power.Text));
                        cmd.Parameters.AddWithValue("@price", decimal.Parse(Tb_Motor_Price.Text));
                        cmd.Parameters.AddWithValue("@stock", int.Parse(Tb_Motor_Quntity.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تمت الإضافة بنجاح ✅", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputFields();

                        Motor_DGV.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Regular);

                        // تكبير خط الهيدر (العناوين)
                        Motor_DGV.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);

                        // ممكن كمان تزود ارتفاع الصفوف علشان الكلام ياخد مساحة كفاية
                        Motor_DGV.RowTemplate.Height = 35;
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

            if (!ValidateInputForEdit())
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
                    string query = "UPDATE Motors SET MotorName=@name, MotorType=@type, Power=@power, Price=@price, StockQuantity=@stock WHERE MotorId=@id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", Tb_Motor_Name.Text.Trim());
                        cmd.Parameters.AddWithValue("@type", Tb_Tybe.Text.Trim());
                        cmd.Parameters.AddWithValue("@power", decimal.Parse(Tb_Motor_Power.Text));
                        cmd.Parameters.AddWithValue("@price", decimal.Parse(Tb_Motor_Price.Text));
                        cmd.Parameters.AddWithValue("@stock", int.Parse(Tb_Motor_Quntity.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم التعديل بنجاح ✅", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputFields();
                        FillData();

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

        private bool ValidateInputForAdd()
        {
            if (string.IsNullOrWhiteSpace(Tb_Motor_Name.Text))
                return false;
            if (string.IsNullOrWhiteSpace(Tb_Tybe.Text))
                return false;

            if (!decimal.TryParse(Tb_Motor_Power.Text, out _))
                return false;

            if (!decimal.TryParse(Tb_Motor_Price.Text, out _))
                return false;

            if (!int.TryParse(Tb_Motor_Quntity.Text, out int quantity))
                return false;

            if (quantity <= 0)
                return false;
            return true;
        }
        private bool ValidateInputForEdit()
        {
            if (string.IsNullOrWhiteSpace(Tb_Motor_Name.Text))
                return false;
            if (string.IsNullOrWhiteSpace(Tb_Tybe.Text))
                return false;

            if (!decimal.TryParse(Tb_Motor_Power.Text, out _))
                return false;

            if (!decimal.TryParse(Tb_Motor_Price.Text, out _))
                return false;

            if (!int.TryParse(Tb_Motor_Quntity.Text, out int quantity))
                return false;


            if (quantity < 0)
                return false;

            return true;
        }

        private void ClearInputFields()
        {
            Tb_Motor_Name.Clear();
            Tb_Tybe.Clear();
            Tb_Motor_Power.Clear();
            Tb_Motor_Price.Clear();
            Tb_Motor_Quntity.Clear();

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
                Tb_Tybe.Text = Motor_DGV.CurrentRow.Cells["Type"].Value?.ToString() ?? "";
                Tb_Motor_Power.Text = Motor_DGV.CurrentRow.Cells["Power"].Value?.ToString() ?? "";
                Tb_Motor_Price.Text = Motor_DGV.CurrentRow.Cells["Price"].Value?.ToString() ?? "";
                Tb_Motor_Quntity.Text = Motor_DGV.CurrentRow.Cells["StockQuantity"].Value?.ToString() ?? "";
            }
        }

        private void TB_Motor_Id_TextChanged(object sender, EventArgs e)
        {



        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                Control nextControl = GetNextControl((Control)sender, true);
                while (nextControl != null && !nextControl.TabStop)
                {
                    nextControl = GetNextControl(nextControl, true);
                }
                if (nextControl != null) nextControl.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                Control prevControl = GetNextControl((Control)sender, false);
                while (prevControl != null && !prevControl.TabStop)
                {
                    prevControl = GetNextControl(prevControl, false);
                }
                if (prevControl != null) prevControl.Focus();
            }
        }

        private void Motor_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Tb_Motor_Name_TextChanged(object sender, EventArgs e)
        {

        }
        private void ApplyTextBoxAlternateColors(Control parent)
        {

            // هنجمع كل التكست بوكس
            var textBoxes = new List<TextBox>();

            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox tb)
                    textBoxes.Add(tb);
            }

            // نرتبهم حسب موقعهم الرأسي (Top)
            textBoxes = textBoxes.OrderBy(tb => tb.Top).ToList();

            // نوزع الألوان بالتناوب
            for (int i = 0; i < textBoxes.Count; i++)
            {
                if (i % 2 == 0)
                    textBoxes[i].BackColor = Color.White;       // أبيض
                else
                    textBoxes[i].BackColor = Color.LightGray;  // رمادي
            }
        }

    }

}

