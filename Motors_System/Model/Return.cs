using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors_System.Model
{
    internal class Return
    {
        public int Return_ID { get; set; }
        public int Sales_ID { get; set; }
        public DateTime Return_Date { get; set; }
        public string Customer_Name { get; set; }
        public string Motor_Model { get; set; }
        public int Returned_Quantity { get; set; }
        public decimal Return_Amount { get; set; }
    }
}
