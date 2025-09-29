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
            User_Form returns = new User_Form();
            returns.Show();
            this.Hide();
        }
    }
}
