using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    public class Order
    {
        public string Code { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
