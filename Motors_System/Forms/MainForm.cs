using Motors_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motors_System.Forms
{
    public partial class MainForm : Form
    {
       
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MotorForm motor = new MotorForm();
            motor.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sales_invoice_Form sales_Invoice_Form = new Sales_invoice_Form();
            sales_Invoice_Form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Returns returns = new Returns();
            returns.Show();
            this.Hide();
        }

        private void Go_Users_btn_Click(object sender, EventArgs e)
        {
           
            if (CurrentUser.Role != "Admin")
            {
                MessageBox.Show("غير مسموح لك بالدخول إلى هذه الصفحة. فقط المسؤول (Admin) يمكنه الوصول.",
                                "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Show();
              
                return;
            }
            else {
                User_Form user_Form = new User_Form();
                user_Form.Show();
                this.Hide();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Show_returns show_Returns = new Show_returns();
            show_Returns.Show();
            this.Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
