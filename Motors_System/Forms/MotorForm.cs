using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Motors_System.Forms
{
    public partial class MotorForm : Form
    {
        public MotorForm()
        {
            InitializeComponent();
        }

        private void Motor_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            using (var con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Motor"; // الكويري الصحيح

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    Motor_DGV.DataSource = dt; // ربط البيانات بالجريد
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في الاتصال: " + ex.Message);
                }
            }
        }
    }
}
