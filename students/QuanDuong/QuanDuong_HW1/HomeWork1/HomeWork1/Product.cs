using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    public class Product
    {
        private int Code;
        private string Name;
        private float Price;

        public Product()
        {
            Code = 1;
            Name = "Xyz";
            Price = 200;
        }
        public Product(Product pro)
        {
            Code = pro.Code;
            Name = pro.Name;
            Price = pro.Price;
        }
        public Product(int code, string name, float price)
        {
            Code = code;
            Name = name;
            Price = price;
        }
        //lay du lieu va gan du lieu
        public int ProductCode
        {
            get { return Code; }
            set { Code = value; }
        }
        public string ProductName
        {
            get { return Name; }
            set { Name = value; }
        }
        public float ProductPrice
        {
            get { return Price; }
            set { Price = value; }
        }
        //show du lieu
        public void Show()
        {
            Console.WriteLine("Code:{0}", this.Code);
            Console.WriteLine("Name:{0}", this.Name);
            Console.WriteLine("Price:{0}", this.Price);
        }
    }
}
