using Motors_System.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Motors_System.Forms
{
    public partial class Returns : Form
    {
        private readonly string connectionString;

        public Returns()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            ApplyDynamicTextDirection(this);
        }

        private void Returns_Load(object sender, EventArgs e)
        {
            LoadSalesData();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadSalesData()
        {
            List<Sales> salesList = new List<Sales>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Sales WHERE Quantity > 0";
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Sales sales = new Sales
                            {
                                Sales_ID = Convert.ToInt32(dr["Sales_ID"]),
                                Sales_Date = Convert.ToDateTime(dr["Sales_Date"]),
                                User = dr["User"]?.ToString() ?? "",
                                Customer_Name = dr["Customer_Name"]?.ToString() ?? "",
                                Customer_Contact = dr["Customer_Contact"]?.ToString() ?? "",
                                Motor_ID = dr["Motor_ID"]?.ToString() ?? "",
                                Motor_Model = dr["Motor_Model"]?.ToString() ?? "",
                                Unit_Price = dr["Unit_Price"] != DBNull.Value ? Convert.ToDecimal(dr["Unit_Price"]) : 0m,
                                Quantity = dr["Quantity"] != DBNull.Value ? Convert.ToInt32(dr["Quantity"]) : 0,
                                Total_Amount = dr["Total_Amount"] != DBNull.Value ? Convert.ToDecimal(dr["Total_Amount"]) : 0m
                            };

                            salesList.Add(sales);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dgv_Return.DataSource = null;
            dgv_Return.DataSource = salesList;
        }

        private void dgv_Return_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgv_Return.CurrentRow != null)
            {
                TB_Order_Id.Text = dgv_Return.CurrentRow.Cells["Sales_ID"]?.Value?.ToString() ?? "";
                TB__order_Date.Text = dgv_Return.CurrentRow.Cells["Sales_Date"]?.Value?.ToString() ?? "";
                TB_Employee_Name.Text = dgv_Return.CurrentRow.Cells["User"]?.Value?.ToString() ?? "";
                TB_Custmor_name.Text = dgv_Return.CurrentRow.Cells["Customer_Name"]?.Value?.ToString() ?? "";
                Tb_Contact.Text = dgv_Return.CurrentRow.Cells["Customer_Contact"]?.Value?.ToString() ?? "";
                TB_Motor_Name.Text = dgv_Return.CurrentRow.Cells["Motor_Model"]?.Value?.ToString() ?? "";
              
                TB_Order_Quntity.Text = dgv_Return.CurrentRow.Cells["Quantity"]?.Value?.ToString() ?? "";
                Tb_price_Total.Text = dgv_Return.CurrentRow.Cells["Total_Amount"]?.Value?.ToString() ?? "";
            }
        }

        private void btn_to_return_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TB_Order_Id.Text))
                {
                    MessageBox.Show("من فضلك اختر فاتورة أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int salesId = int.Parse(TB_Order_Id.Text);
                int returnQuantity = int.Parse(TB_Order_Quntity.Text);
                string motorModel = TB_Motor_Name.Text;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // ✅ 1- نجيب الكمية الحالية والسعر و MotorId
                    string getQuantityQuery = @"
                SELECT Quantity, Unit_Price, Motor_ID 
                FROM Sales 
                WHERE Sales_ID = @Sales_ID";

                    int currentQuantity = 0;
                    decimal unitPrice = 0;
                    int motorId = 0;

                    using (SqlCommand cmd = new SqlCommand(getQuantityQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Sales_ID", salesId);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                currentQuantity = Convert.ToInt32(dr["Quantity"]);
                                unitPrice = Convert.ToDecimal(dr["Unit_Price"]);
                                motorId = Convert.ToInt32(dr["Motor_ID"]);
                            }
                        }
                    }

                    if (currentQuantity <= 0)
                    {
                        MessageBox.Show("لا يمكن عمل مرتجع، الكمية بالفعل صفر.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (returnQuantity > currentQuantity)
                    {
                        MessageBox.Show("الكمية المرتجعة أكبر من الكمية المتبقية.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SqlTransaction transaction = con.BeginTransaction();
                    try
                    {
                        // ✅ 2- إدخال المرتجع
                        string insertReturnQuery = @"
                    INSERT INTO Returns (Sales_ID, Return_Date, Customer_Name, Motor_Model, Returned_Quantity, Return_Amount)
                    VALUES (@Sales_ID, @Return_Date, @Customer_Name, @Motor_Model, @Returned_Quantity, @Return_Amount)";
                        using (SqlCommand cmd = new SqlCommand(insertReturnQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Sales_ID", salesId);
                            cmd.Parameters.AddWithValue("@Return_Date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Customer_Name", TB_Custmor_name.Text);
                            cmd.Parameters.AddWithValue("@Motor_Model", motorModel);
                            cmd.Parameters.AddWithValue("@Returned_Quantity", returnQuantity);
                            cmd.Parameters.AddWithValue("@Return_Amount", returnQuantity * unitPrice);
                            cmd.ExecuteNonQuery();
                        }

                        // ✅ 3- تحديث المبيعات
                        string updateSalesQuery = @"
                    UPDATE Sales 
                    SET Quantity = Quantity - @Returned_Quantity,
                        Total_Amount = (Quantity - @Returned_Quantity) * Unit_Price
                    WHERE Sales_ID = @Sales_ID";
                        using (SqlCommand cmd = new SqlCommand(updateSalesQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Returned_Quantity", returnQuantity);
                            cmd.Parameters.AddWithValue("@Sales_ID", salesId);
                            cmd.ExecuteNonQuery();
                        }

                        // ✅ 4- تحديث المخزن (Motors)
                        string updateMotorsQuery = @"
                    UPDATE Motors
                    SET StockQuantity = StockQuantity + @Returned_Quantity
                    WHERE MotorId = @MotorId";
                        using (SqlCommand cmd = new SqlCommand(updateMotorsQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Returned_Quantity", returnQuantity);
                            cmd.Parameters.AddWithValue("@MotorId", motorId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show("تم تسجيل المرتجع وإضافة الكمية للمخزن بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // ✅ تحديث الداتا جريد
                        LoadSalesData();

                        // ✅ تفريغ التيكست بوكسات
                        ClearSelectionFields();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("خطأ أثناء عملية المرتجع: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void ClearSelectionFields()
        {
            TB_Order_Id.Clear();
            TB__order_Date.Clear();
            TB_Employee_Name.Clear();
            TB_Custmor_name.Clear();
            Tb_Contact.Clear();
            TB_Motor_Name.Clear();
            TB_Order_Quntity.Clear();
            Tb_price_Total.Clear();
        }

        private void btn_ShowSalesFromDate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtp_FromDate.Value.Date; 

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT SUM(Total_Amount) 
                FROM Sales 
                WHERE Sales_Date >= @FromDate";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", fromDate);

                        con.Open();
                        object result = cmd.ExecuteScalar();

                        decimal totalSales = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;

                        MessageBox.Show(
                            $"إجمالي المبيعات من {fromDate.ToShortDateString()} لحد دلوقتي = {totalSales} جنيه",
                            "إجمالي المبيعات",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء حساب المبيعات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
