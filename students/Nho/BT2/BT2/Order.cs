using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2
{
    public class Order
    {
        public string ordercode{get;set;}
        public DateTime date { get; set; }
        public string productcode { get; set; }
        public int quality { get; set; }
    }
}
