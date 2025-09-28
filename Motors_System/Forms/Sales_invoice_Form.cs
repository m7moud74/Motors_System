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
        private List<Sales> salesItems = new List<Sales>(); // قائمة عناصر المبيعات

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
            // إعداد رقم الأوردر ليكون تلقائي وغير قابل للتعديل
            if (TB_Order_Id != null)
            {
                TB_Order_Id.ReadOnly = true;
                TB_Order_Id.BackColor = System.Drawing.SystemColors.Control;
                TB_Order_Id.Text = "ORD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            }

            // إعداد التاريخ ليكون تلقائي وغير قابل للتعديل
            if (TB_Motor_Date != null)
            {
                TB_Motor_Date.ReadOnly = true;
                TB_Motor_Date.BackColor = System.Drawing.SystemColors.Control;
                TB_Motor_Date.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            }

            // مسح نص اليوزر أي دي ليكون قابل للإدخال اليدوي
            if (TB_Employee_Id != null)
            {
                TB_Employee_Id.ReadOnly = false;
                TB_Employee_Id.Clear();
            }

            // إعداد السعر للوحدة
            if (Tb_Salary_1 != null)
            {
                Tb_Salary_1.ReadOnly = true;
                Tb_Salary_1.BackColor = System.Drawing.SystemColors.Control;
                Tb_Salary_1.Text = "0.00";
            }

            // إعداد السعر الإجمالي
            if (Tb_Salary_Total != null)
            {
                Tb_Salary_Total.ReadOnly = true;
                Tb_Salary_Total.BackColor = System.Drawing.SystemColors.Control;
                Tb_Salary_Total.Text = "0.00";
            }
        }

        private void SetupComboBoxes()
        {
            // إعداد كومبو بوكس العملاء مع البحث المحسن
            if (CB_Customer_Name != null)
            {
                CB_Customer_Name.DropDownStyle = ComboBoxStyle.DropDown;
                CB_Customer_Name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CB_Customer_Name.AutoCompleteSource = AutoCompleteSource.ListItems;
                CB_Customer_Name.TextChanged += CB_Customer_Name_TextChanged;
            }

            // إعداد كومبو بوكس المحركات مع البحث المحسن
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
            dataGridView1.Columns["Sales_ID"].Visible = false; // مخفي
            dataGridView1.Columns.Add("Sales_Date", "تاريخ البيع");
            dataGridView1.Columns.Add("Customer_Name", "اسم العميل");
            dataGridView1.Columns.Add("Customer_Contact", "معلومات العميل");
            dataGridView1.Columns.Add("Motor_ID", "معرف المحرك");
            dataGridView1.Columns.Add("Motor_Model", "موديل المحرك");
            dataGridView1.Columns.Add("Unit_Price", "السعر للوحدة");
            dataGridView1.Columns.Add("Quantity", "الكمية");
            dataGridView1.Columns.Add("Total_Amount", "المجموع الكلي");

            // تحسين عرض الأعمدة
            dataGridView1.Columns["Sales_Date"].Width = 120;
            dataGridView1.Columns["Customer_Name"].Width = 150;
            dataGridView1.Columns["Customer_Contact"].Width = 120;
            dataGridView1.Columns["Motor_ID"].Width = 80;
            dataGridView1.Columns["Motor_Model"].Width = 150;
            dataGridView1.Columns["Unit_Price"].Width = 100;
            dataGridView1.Columns["Quantity"].Width = 80;
            dataGridView1.Columns["Total_Amount"].Width = 120;

            // السماح بالتحديد الكامل للصف
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
            // عرض سعر المحرك المختار تلقائياً
            if (!string.IsNullOrEmpty(CB_Motor_Name.Text))
            {
                var motor = GetMotorByName(CB_Motor_Name.Text);
                if (motor.MotorId != -1)
                {
                    // عرض السعر في تيكست بوكس السعر
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
                    // البحث عن العميل أولاً
                    string query = "SELECT CustomerId FROM Customers WHERE FullName=@name";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", fullName.Trim());
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                            return Convert.ToInt32(result);
                    }

                    // إضافة عميل جديد إذا لم يكن موجود
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
            // التحقق من البيانات المدخلة
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

            // التحقق من الكمية المتاحة
            if (quantity > motor.StockQuantity)
            {
                MessageBox.Show($"الكمية المطلوبة ({quantity}) أكبر من المتاح في المخزن ({motor.StockQuantity})",
                               "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // التحقق من عدم تكرار المحرك في القائمة
            foreach (var item in salesItems)
            {
                if (item.Motor_ID == motor.MotorId.ToString())
                {
                    MessageBox.Show("هذا المحرك موجود بالفعل في الفاتورة. يمكنك تعديل الكمية بدلاً من إضافة جديد",
                                   "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // إنشاء عنصر مبيعة جديد
            Sales newSale = new Sales
            {
                Sales_ID = salesItems.Count + 1, // معرف تلقائي
                Sales_Date = DateTime.Now,
                Customer_Name = CB_Customer_Name.Text.Trim(),
                Customer_Contact = GetCustomerContact(CB_Customer_Name.Text.Trim()),
                Motor_ID = motor.MotorId.ToString(),
                Motor_Model = CB_Motor_Name.Text.Trim(),
                Unit_Price = motor.Price,
                Quantity = quantity,
                Total_Amount = motor.Price * quantity
            };

            // إضافة العنصر للقائمة
            salesItems.Add(newSale);

            // إضافة الصف للجدول
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

            // تحديث المجموع الكلي
            UpdateTotalAmount();

            // مسح الحقول بعد الإضافة (عدا اسم العميل)
            CB_Motor_Name.Text = "";
            TB_OrderDetails.Clear();

            MessageBox.Show("تمت إضافة المحرك بنجاح ✅", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_delete_Motor_before_selll_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("برجاء اختيار عنصر للحذف", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // تأكيد الحذف
            DialogResult result = MessageBox.Show("هل أنت متأكد من حذف هذا العنصر؟",
                                                 "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int rowIndex = dataGridView1.CurrentRow.Index;

                // حذف من القائمة
                if (rowIndex < salesItems.Count)
                {
                    salesItems.RemoveAt(rowIndex);
                }

                // حذف من الجدول
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

                // تحديث المجموع الكلي
                UpdateTotalAmount();

                MessageBox.Show("تم الحذف بنجاح ❌", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            // الحصول على بيانات المحرك
            var motor = GetMotorByName(salesItems[rowIndex].Motor_Model);
            if (motor.StockQuantity < quantity)
            {
                MessageBox.Show($"الكمية المطلوبة ({quantity}) أكبر من المتاح في المخزن ({motor.StockQuantity})",
                               "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // تحديث البيانات في القائمة
            salesItems[rowIndex].Quantity = quantity;
            salesItems[rowIndex].Total_Amount = salesItems[rowIndex].Unit_Price * quantity;

            // تحديث البيانات في الجدول
            dataGridView1.CurrentRow.Cells["Quantity"].Value = quantity;
            dataGridView1.CurrentRow.Cells["Total_Amount"].Value = salesItems[rowIndex].Total_Amount.ToString("0.00");

            // تحديث المجموع الكلي
            UpdateTotalAmount();

            // مسح الحقول
            CB_Motor_Name.Text = "";
            TB_OrderDetails.Clear();

            MessageBox.Show("تم التعديل بنجاح ✏️", "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // عند النقر المزدوج على صف في الجدول لملء البيانات للتعديل
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
            // التحقق من البيانات المطلوبة
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

            if (!int.TryParse(TB_Employee_Id.Text, out int userId))
            {
                MessageBox.Show("معرف الموظف يجب أن يكون رقم صحيح", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string customerName = salesItems[0].Customer_Name; // اسم العميل من أول عنصر
            int customerId = GetOrAddCustomer(customerName);
            if (customerId == -1) return;

            DateTime saleDate = DateTime.Now;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                try
                {
                    // إدراج الطلب الرئيسي
                    string insertOrder = "INSERT INTO Orders (CustomerId, UserId, OrderDate, TotalAmount) VALUES (@custId, @userId, @date, @total); SELECT SCOPE_IDENTITY();";
                    int orderId;
                    using (SqlCommand cmd = new SqlCommand(insertOrder, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@custId", customerId);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@date", saleDate);
                        cmd.Parameters.AddWithValue("@total", totalAmount);
                        orderId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // إدراج تفاصيل المبيعات وتحديث المخزن
                    foreach (var sale in salesItems)
                    {
                        // إدراج تفاصيل الطلب
                        string insertDetail = "INSERT INTO OrderDetails (OrderId, MotorId, Quantity, UnitPrice) VALUES (@orderId, @motorId, @qty, @price)";
                        using (SqlCommand cmd = new SqlCommand(insertDetail, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@orderId", orderId);
                            cmd.Parameters.AddWithValue("@motorId", int.Parse(sale.Motor_ID));
                            cmd.Parameters.AddWithValue("@qty", sale.Quantity);
                            cmd.Parameters.AddWithValue("@price", sale.Unit_Price);
                            cmd.ExecuteNonQuery();
                        }

                        // تحديث كمية المخزن
                        string updateStock = "UPDATE Motors SET StockQuantity = StockQuantity - @qty WHERE MotorId = @motorId";
                        using (SqlCommand cmd = new SqlCommand(updateStock, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@qty", sale.Quantity);
                            cmd.Parameters.AddWithValue("@motorId", int.Parse(sale.Motor_ID));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                    string orderNumber = "ORD" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    MessageBox.Show($"تمت عملية البيع بنجاح! ✅\nرقم الطلب: {orderNumber}\nالعميل: {customerName}\nعدد العناصر: {salesItems.Count}\nالمجموع الكلي: {totalAmount:0.00} جنيه\nالتاريخ: {saleDate:dd/MM/yyyy HH:mm}",
                                   "نجح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // مسح البيانات لطلب جديد
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

            // تحديث رقم الأوردر والتاريخ
            if (TB_Order_Id != null) TB_Order_Id.Text = "ORD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (TB_Motor_Date != null) TB_Motor_Date.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // تحديث قائمة المحركات لإظهار الكميات المحدثة
            LoadMotorsToComboBox();
        }

        // إضافة حدث البحث في كومبو بوكس العملاء
        private void CB_Customer_Name_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null && cb.Text.Length >= 2)
            {
                // البحث في قاعدة البيانات
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
                catch (Exception ex)
                {
                    // تجاهل أخطاء البحث لعدم إزعاج المستخدم
                }
            }
        }

        // إضافة عنصر
        private void btn_add_Motor_To_sell_Click1(object sender, EventArgs e)
        {
            // التحقق من البيانات
            if (string.IsNullOrWhiteSpace(CB_Motor_Name.Text) || string.IsNullOrWhiteSpace(TB_OrderDetails.Text))
            {
                MessageBox.Show("أدخل اسم المحرك والكمية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(TB_OrderDetails.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("الكمية غير صحيحة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var motor = GetMotorByName(CB_Motor_Name.Text);
            if (motor.MotorId == -1) return;

            Sales newSale = new Sales
            {
                Sales_ID = salesItems.Count + 1,
                Sales_Date = DateTime.Now,
                Customer_Name = CB_Customer_Name.Text,
                Customer_Contact = GetCustomerContact(CB_Customer_Name.Text),
                Motor_ID = motor.MotorId.ToString(),
                Motor_Model = CB_Motor_Name.Text,
                Unit_Price = motor.Price,
                Quantity = quantity,
                Total_Amount = motor.Price * quantity
            };

            salesItems.Add(newSale);
            dataGridView1.Rows.Add(newSale.Sales_ID, newSale.Sales_Date, newSale.Customer_Name,
                                   newSale.Customer_Contact, newSale.Motor_ID, newSale.Motor_Model,
                                   newSale.Unit_Price, newSale.Quantity, newSale.Total_Amount);

            UpdateTotalAmount();
            TB_OrderDetails.Clear();
            CB_Motor_Name.Text = "";
        }

        // دابل كليك على الصف
        private void dataGridView1_RowHeaderMouseDoubleClick1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index < salesItems.Count)
            {
                var selectedSale = salesItems[dataGridView1.CurrentRow.Index];
                CB_Customer_Name.Text = selectedSale.Customer_Name;
                CB_Motor_Name.Text = selectedSale.Motor_Model;
                TB_OrderDetails.Text = selectedSale.Quantity.ToString();
            }
        }

        // تعديل العنصر
        private void Btn_Update_Motor_To_sell_Click1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            if (!int.TryParse(TB_OrderDetails.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("الكمية غير صحيحة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dataGridView1.CurrentRow.Index;
            salesItems[rowIndex].Quantity = quantity;
            salesItems[rowIndex].Total_Amount = salesItems[rowIndex].Unit_Price * quantity;

            dataGridView1.Rows[rowIndex].Cells["Quantity"].Value = quantity;
            dataGridView1.Rows[rowIndex].Cells["Total_Amount"].Value = salesItems[rowIndex].Total_Amount;

            UpdateTotalAmount();
        }

        // حذف العنصر
        private void Btn_delete_Motor_before_selll_Click1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int rowIndex = dataGridView1.CurrentRow.Index;
            salesItems.RemoveAt(rowIndex);
            dataGridView1.Rows.RemoveAt(rowIndex);

            UpdateTotalAmount();
        }

    }

    public static class Session
    {
        public static int UserId { get; set; }
        public static string UserName { get; set; }
    }
}