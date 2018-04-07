using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayOrder();
            Console.ReadKey();
        }

        static void InitDataProduct(List<Product> pro)
        {
            pro.Add(new Product
            {
                Code = "P01",
                Name = "Iphong X",
                Price = 100.5
            });
            pro.Add(new Product
            {
                Code = "P02",
                Name = "Iphong 8",
                Price = 200.5
            });
            pro.Add(new Product
            {
                Code = "P03",
                Name = "Iphong 7",
                Price = 300.5
            });
            pro.Add(new Product
            {
                Code = "P04",
                Name = "Iphong 6",
                Price = 400.5
            });
            pro.Add(new Product
            {
                Code = "P05",
                Name = "Iphong 5",
                Price = 500.5
            });
        }

        static void InitDataOrder(List<Order> order)
        {
            order.Add(new Order
            {
                Code = "O01",
                Date = DateTime.Now.ToString(),
                ProductCode = "P01",
                Quantity = 1
            });
            order.Add(new Order
            {
                Code = "O02",
                Date = DateTime.Now.ToString(),
                ProductCode = "P02",
                Quantity = 2
            });
            order.Add(new Order
            {
                Code = "O03",
                Date = DateTime.Now.ToString(),
                ProductCode = "P03",
                Quantity = 3
            });
            order.Add(new Order
            {
                Code = "O04",
                Date = DateTime.Now.ToString(),
                ProductCode = "P04",
                Quantity = 4
            });
        }

        static void DisplayOrder()
        {
            List<Product> pros = new List<Product>();
            InitDataProduct(pros);
            List<Order> orders = new List<Order>();
            InitDataOrder(orders);
            var result = pros.Join(orders,
                pro => pro.Code,
                order => order.ProductCode,
                (pro, order) => new
                {
                    OrderCode = order.Code,
                    ProductName = pro.Name,
                    Quantity = order.Quantity,
                    Date = order.Date
                });
            foreach (var item in result)
            {
                Console.WriteLine("Code: " + item.Code);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Price: " + item.Price);
                Console.WriteLine();
            }
        }
    }
}
