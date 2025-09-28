using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors_System.Model
{
    internal class Sales
    {
        public int Sales_ID { get; set; }
        public DateTime Sales_Date { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Contact { get; set; }
        public string Motor_ID { get; set; }
        public string Motor_Model { get; set; }
        public decimal Unit_Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total_Amount { get; set; }
    }
}
