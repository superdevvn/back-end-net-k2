using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Product 
    {
        private string _productCode;
        private string _productName;
        private int _productPrice;

        public string ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public int ProductPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; }
        }

        public override string ToString()
        {
            return "ProductCode: " + ProductCode + ", ProductName: " + ProductName + ", ProductPrice: " + ProductPrice; 
        }
    }
}
