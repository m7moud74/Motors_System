using Motors_System.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Motors_System.Forms
{
    public partial class Sales_invoice_Form : Form
    {
        private readonly string connectionString;
        private decimal totalAmount = 0m;
        private List<Sales> salesItems = new List<Sales>();

        public Sales_invoice_Form()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }

        private void Sales_invoice_Form_Load(object sender, EventArgs e)
        {
            SetupDataGrid();
            SetupControls();
            SetupComboBoxes();
            LoadCustomersToComboBox();
            LoadMotorsToComboBox();
        }

        private void SetupControls()
        {
            if (TB_Order_Id != null)
            {
                TB_Order_Id.ReadOnly = true;
                TB_Order_Id.BackColor = System.Drawing.SystemColors.Control;
                TB_Order_Id.Text = "ORD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            }

            if (TB_Motor_Date != null)
            {
                TB_Motor_Date.ReadOnly = true;
                TB_Motor_Date.BackColor = System.Drawing.SystemColors.Control;
                TB_Motor_Date.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            }

            if (TB_Employee_Id != null)
            {
                TB_Employee_Id.ReadOnly = false;
                TB_Employee_Id.Clear();
            }

            if (Tb_Salary_1 != null)
            {
                Tb_Salary_1.ReadOnly = true;
                Tb_Salary_1.BackColor = System.Drawing.SystemColors.Control;
                Tb_Salary_1.Text = "0.00";
            }

            if (Tb_Salary_Total != null)
            {
                Tb_Salary_Total.ReadOnly = true;
                Tb_Salary_Total.BackColor = System.Drawing.SystemColors.Control;
                Tb_Salary_Total.Text = "0.00";
            }
        }

        private void SetupComboBoxes()
        {
            if (CB_Customer_Name != null)
            {
                CB_Customer_Name.DropDownStyle = ComboBoxStyle.DropDown;
                CB_Customer_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CB_Customer_Name.AutoCompleteSource = AutoCompleteSource.ListItems;
                CB_Customer_Name.TextChanged += CB_Customer_Name_TextChanged;
            }

            if (CB_Motor_Name != null)
            {
                CB_Motor_Name.DropDownStyle = ComboBoxStyle.DropDown;
                CB_Motor_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CB_Motor_Name.AutoCompleteSource = AutoCompleteSource.ListItems;
                CB_Motor_Name.SelectedIndexChanged += CB_Motor_Name_SelectedIndexChanged;
            }
        }

        private void SetupDataGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Sales_ID", "معرف المبيعة");
            dataGridView1.Columns["Sales_ID"].Visible = false;
            dataGridView1.Columns.Add("Sales_Date", "تاريخ البيع");
            dataGridView1.Columns.Add("Customer_Name", "اسم العميل");
            dataGridView1.Columns.Add("Customer_Contact", "معلومات العميل");
            dataGridView1.Columns.Add("Motor_ID", "معرف المحرك");
            dataGridView1.Columns.Add("Motor_Model", "موديل المحرك");
            dataGridView1.Columns.Add("Unit_Price", "السعر للوحدة");
            dataGridView1.Columns.Add("Quantity", "الكمية");
            dataGridView1.Columns.Add("Total_Amount", "المجموع الكلي");

            dataGridView1.Columns["Sales_Date"].Width = 120;
            dataGridView1.Columns["Customer_Name"].Width = 150;
            dataGridView1.Columns["Customer_Contact"].Width = 120;
            dataGridView1.Columns["Motor_ID"].Width = 80;
            dataGridView1.Columns["Motor_Model"].Width = 150;
            dataGridView1.Columns["Unit_Price"].Width = 100;
            dataGridView1.Columns["Quantity"].Width = 80;
            dataGridView1.Columns["Total_Amount"].Width = 120;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void LoadCustomersToComboBox()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT DISTINCT FullName FROM Customers ORDER BY FullName";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        CB_Customer_Name.Items.Clear();
                        while (dr.Read())
                        {
                            CB_Customer_Name.Items.Add(dr["FullName"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في تحميل العملاء: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadMotorsToComboBox()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT DISTINCT MotorName FROM Motors WHERE StockQuantity > 0 ORDER BY MotorName";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        CB_Motor_Name.Items.Clear();
                        while (dr.Read())
                        {
                            CB_Motor_Name.Items.Add(dr["MotorName"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في تحميل المحركات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CB_Motor_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CB_Motor_Name.Text))
            {
                var motor = GetMotorByName(CB_Motor_Name.Text);
                if (motor.MotorId != -1)
                {
                    if (Tb_Salary_1 != null)
                    {
                        Tb_Salary_1.Text = motor.Price.ToString("0.00");
                    }
                }
            }
        }

        private string GetCustomerContact(string customerName)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT Phone FROM Customers WHERE FullName=@name";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", customerName.Trim());
                        var result = cmd.ExecuteScalar();
                        return result?.ToString() ?? "غير محدد";
                    }
                }
                catch (Exception ex)
                {
                    return "غير محدد";
                }
            }
        }

        private int GetOrAddCustomer(string fullName)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT CustomerId FROM Customers WHERE FullName=@name";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", fullName.Trim());
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                            return Convert.ToInt32(result);
                    }

                    string insertQuery = "INSERT INTO Customers (FullName) VALUES (@name); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@name", fullName.Trim());
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في إدارة العميل: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        private (int MotorId, decimal Price, int StockQuantity) GetMotorByName(string motorName)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT MotorId, Price, ISNULL(StockQuantity, 0) as StockQuantity FROM Motors WHERE MotorName=@name";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", motorName.Trim());
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                                return (Convert.ToInt32(dr["MotorId"]),
                                       Convert.ToDecimal(dr["Price"]),
                                       Convert.ToInt32(dr["StockQuantity"]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في البحث عن المحرك: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return (-1, 0m, 0);
        }

        private void btn_add_Motor_To_sell_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CB_Customer_Name.Text))
            {
                MessageBox.Show("برجاء اختيار أو إدخال اسم العميل", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(CB_Motor_Name.Text))
            {
                MessageBox.Show("برجاء اختيار اسم المحرك", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TB_OrderDetails.Text))
            {
                MessageBox.Show("برجاء إدخال الكمية", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(TB_OrderDetails.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("الكمية يجب أن تكون رقم موجب", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var motor = GetMotorByName(CB_Motor_Name.Text);
            if (motor.MotorId == -1)
            {
                MessageBox.Show("المحرك غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (quantity > motor.StockQuantity)
            {
                MessageBox.Show($"الكمية المطلوبة ({quantity}) أكبر من المتاح في المخزن ({motor.StockQuantity})",
                               "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var item in salesItems)
            {
                if (item.Motor_ID == motor.MotorId.ToString())
                {
                    MessageBox.Show("هذا المحرك موجود بالفعل في الفاتورة. يمكنك تعديل الكمية بدلاً من إضافة جديد",
                                   "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Sales newSale = new Sales
            {
                Sales_ID = salesItems.Count + 1,
                Sales_Date = DateTime.Now,
                Customer_Name = CB_Customer_Name.Text.Trim(),
                Customer_Contact = GetCustomerContact(CB_Customer_Name.Text.Trim()),
                Motor_ID = motor.MotorId.ToString(),
                Motor_Model = CB_Motor_Name.Text.Trim(),
                Unit_Price = motor.Price,
                Quantity = quantity,
                Total_Amount = motor.Price * quantity
            };

            salesItems.Add(newSale);

            dataGridView1.Rows.Add(
                newSale.Sales_ID,
                newSale.Sales_Date.ToString("dd/MM/yyyy HH:mm"),
                newSale.Customer_Name,
                newSale.Customer_Contact,
                newSale.Motor_ID,
                newSale.Motor_Model,
                newSale.Unit_Price.ToString("0.00"),
                newSale.Quantity,
                newSale.Total_Amount.ToString("0.00")
            );

            UpdateTotalAmount();

            CB_Motor_Name.Text = "";
            TB_OrderDetails.Clear();

            MessageBox.Show("تمت إضافة المحرك بنجاح", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_delete_Motor_before_selll_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("برجاء اختيار عنصر للحذف", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("هل أنت متأكد من حذف هذا العنصر؟",
                                                 "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int rowIndex = dataGridView1.CurrentRow.Index;

                if (rowIndex < salesItems.Count)
                {
                    salesItems.RemoveAt(rowIndex);
                }

                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

                UpdateTotalAmount();

                MessageBox.Show("تم الحذف بنجاح", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_Update_Motor_To_sell_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("برجاء اختيار عنصر للتعديل", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TB_OrderDetails.Text))
            {
                MessageBox.Show("برجاء إدخال الكمية الجديدة", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(TB_OrderDetails.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("الكمية يجب أن تكون رقم موجب", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dataGridView1.CurrentRow.Index;
            if (rowIndex >= salesItems.Count) return;

            var motor = GetMotorByName(salesItems[rowIndex].Motor_Model);
            if (motor.StockQuantity < quantity)
            {
                MessageBox.Show($"الكمية المطلوبة ({quantity}) أكبر من المتاح في المخزن ({motor.StockQuantity})",
                               "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            salesItems[rowIndex].Quantity = quantity;
            salesItems[rowIndex].Total_Amount = salesItems[rowIndex].Unit_Price * quantity;

            dataGridView1.CurrentRow.Cells["Quantity"].Value = quantity;
            dataGridView1.CurrentRow.Cells["Total_Amount"].Value = salesItems[rowIndex].Total_Amount.ToString("0.00");

            UpdateTotalAmount();

            CB_Motor_Name.Text = "";
            TB_OrderDetails.Clear();

            MessageBox.Show("تم التعديل بنجاح", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateTotalAmount()
        {
            totalAmount = 0m;
            foreach (var sale in salesItems)
            {
                totalAmount += sale.Total_Amount;
            }
            Tb_Salary_Total.Text = totalAmount.ToString("0.00");
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index < salesItems.Count)
            {
                var selectedSale = salesItems[dataGridView1.CurrentRow.Index];
                CB_Customer_Name.Text = selectedSale.Customer_Name;
                CB_Motor_Name.Text = selectedSale.Motor_Model;
                TB_OrderDetails.Text = selectedSale.Quantity.ToString();
            }
        }

        private void Btn_Sell_Click(object sender, EventArgs e)
        {
            if (salesItems.Count == 0)
            {
                MessageBox.Show("برجاء إضافة عناصر للمبيعات", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TB_Employee_Id.Text))
            {
                MessageBox.Show("برجاء إدخال معرف الموظف", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userName = TB_Employee_Id.Text.Trim();
            string customerName = salesItems[0].Customer_Name;
            int customerId = GetOrAddCustomer(customerName);
            if (customerId == -1) return;

            DateTime saleDate = DateTime.Now;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                try
                {
                    
                    foreach (var sale in salesItems)
                    {
                        string insertSales = @"INSERT INTO Sales (Sales_Date, [User], Customer_Name, Customer_Contact, 
                                              Motor_ID, Motor_Model, Unit_Price, Quantity, Total_Amount) 
                                              VALUES (@date, @user, @custName, @contact, @motorId, @model, 
                                              @price, @qty, @total)";

                        using (SqlCommand cmd = new SqlCommand(insertSales, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@date", saleDate);
                            cmd.Parameters.AddWithValue("@user", userName);
                            cmd.Parameters.AddWithValue("@custName", sale.Customer_Name);
                            cmd.Parameters.AddWithValue("@contact", sale.Customer_Contact ?? "غير محدد");
                            cmd.Parameters.AddWithValue("@motorId", sale.Motor_ID);
                            cmd.Parameters.AddWithValue("@model", sale.Motor_Model);
                            cmd.Parameters.AddWithValue("@price", sale.Unit_Price);
                            cmd.Parameters.AddWithValue("@qty", sale.Quantity);
                            cmd.Parameters.AddWithValue("@total", sale.Total_Amount);
                            cmd.ExecuteNonQuery();
                        }

                        // تحديث المخزن
                        string updateStock = "UPDATE Motors SET StockQuantity = StockQuantity - @qty WHERE MotorId = @motorId";
                        using (SqlCommand cmd = new SqlCommand(updateStock, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@qty", sale.Quantity);
                            cmd.Parameters.AddWithValue("@motorId", int.Parse(sale.Motor_ID));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                    string orderNumber = TB_Order_Id.Text;
                    MessageBox.Show($"تمت عملية البيع بنجاح!\n\nرقم الطلب: {orderNumber}\nالموظف: {userName}\nالعميل: {customerName}\nعدد العناصر: {salesItems.Count}\nالمجموع الكلي: {totalAmount:0.00} جنيه\nالتاريخ: {saleDate:dd/MM/yyyy HH:mm}",
                                   "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("خطأ أثناء عملية البيع: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            salesItems.Clear();
            dataGridView1.Rows.Clear();
            CB_Customer_Name.Text = "";
            CB_Motor_Name.Text = "";
            TB_OrderDetails.Clear();
            TB_Employee_Id.Clear();
            if (Tb_Salary_1 != null) Tb_Salary_1.Text = "0.00";
            Tb_Salary_Total.Text = "0.00";
            totalAmount = 0m;

            if (TB_Order_Id != null) TB_Order_Id.Text = "ORD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (TB_Motor_Date != null) TB_Motor_Date.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            LoadMotorsToComboBox();
        }

        private void CB_Customer_Name_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null && cb.Text.Length >= 2)
            {
                SearchCustomers(cb.Text);
            }
        }

        private void SearchCustomers(string searchText)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT DISTINCT FullName FROM Customers WHERE FullName LIKE @search ORDER BY FullName";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            CB_Customer_Name.Items.Clear();
                            while (dr.Read())
                            {
                                CB_Customer_Name.Items.Add(dr["FullName"].ToString());
                            }
                        }
                    }
                }
                catch { }
            }
        }
    }
}