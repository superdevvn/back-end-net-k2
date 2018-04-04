using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Assigment
{
    public class Product
    {
        public string name { get; set; }
        public string code { get; set; }
        public int price { get; set; }

        public void showInfo()
        {
            Console.WriteLine("Name:"+name + " " 
                +"Code:"+ code + " "
                +"Price:"+ price);
        }
    }
}
