using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Order
    {
        private string _orderCode;
        private string _productCode;
        private int _quantity;
        private DateTime _orderDate;

        public string OrderCode
        {
            get { return _orderCode; }
            set { _orderCode = value; }
        }

        public string ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }

        public override string ToString()
        {
            return "OrderCode: " + OrderCode + ", ProductCode: " + ProductCode + ", Quantity: " + Quantity + ", OrderDate: " + OrderDate.ToString("dd/MM/yyyy");
        }
    }
}
