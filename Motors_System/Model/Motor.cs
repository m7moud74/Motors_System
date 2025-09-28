using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors_System.Model
{
    public class Motor
    {
        
        public int MotorId { get; set; }

        public string MotorName { get; set; }
       
        public string Description { get; set; }

        public decimal Power { get; set; }

        public decimal Price { get; set; }

        public int? StockQuantity { get; set; }
        public int Category_id { get; set; }
    }
}
