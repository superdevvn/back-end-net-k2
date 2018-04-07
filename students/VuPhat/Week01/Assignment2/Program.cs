using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static List<Product> products;
        static List<Order> orders;

        public static void ShowInfoOrder(List<Order> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        public static void ShowInfoProduct(List<Product> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        public static void Question1()
        {
            /*var res = products.Join(orders,
                product => product.ProductCode,
                order => order.ProductCode,
                (product, order) => new
                {
                    OrderCode = order.OrderCode,
                    ProductName = product.ProductName,
                    Quantity = order.Quantity,
                    Date = order.OrderDate.ToString("dd/MM/yyyy"),
                }).ToList();*/

            var result = from product in products
                         join order in orders on product.ProductCode equals order.ProductCode
                         select new
                         {
                             OrderCode = order.OrderCode,
                             ProductName = product.ProductName,
                             Quantity = order.Quantity,
                             Date = order.OrderDate.ToString("dd/MM/yyyy"),
                         };

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void Question2()
        {
            /*var res = products.Join(orders,
                product => product.ProductCode,
                order => order.ProductCode,
                (product, order) => new
                {
                    OrderCode = order.OrderCode,
                    ProductName = product.ProductName,
                    Quantity = order.Quantity,
                    Price = product.ProductPrice,
                    Date = order.OrderDate.ToString("dd/MM/yyyy"),
                    Total = order.Quantity * product.ProductPrice,
                }).ToList();*/

            var result = from product in products
                         join order in orders on product.ProductCode equals order.ProductCode
                         select new
                         {
                             OrderCode = order.OrderCode,
                             ProductName = product.ProductName,
                             Quantity = order.Quantity,
                             Price = product.ProductPrice,
                             Date = order.OrderDate.ToString("dd/MM/yyyy"),
                             Total = order.Quantity * product.ProductPrice,
                         };

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void Question3(DateTime start, DateTime end, int toal)
        {
            /*var res = products.Join(orders,
                product => product.ProductCode,
                order => order.ProductCode,
                (product, order) => new
                {
                    OrderCode = order.OrderCode,
                    ProductName = product.ProductName,
                    Quantity = order.Quantity,
                    Price = product.ProductPrice,
                    Date = order.OrderDate.ToString("dd/MM/yyyy"),
                    Total = order.Quantity * product.ProductPrice,
                }).Where(p => p.Date.CompareTo(start) >= 0 && p.Date.CompareTo(end) <= 0 && p.Total < toal).ToList();*/

            var result = from product in products
                         join order in orders on product.ProductCode equals order.ProductCode
                         where order.OrderDate.CompareTo(start) >= 0 
                         && order.OrderDate.CompareTo(end) <= 0 
                         && order.Quantity * product.ProductPrice < toal
                         select new
                         {
                             OrderCode = order.OrderCode,
                             ProductName = product.ProductName,
                             Quantity = order.Quantity,
                             Price = product.ProductPrice,
                             Date = order.OrderDate.ToString("dd/MM/yyyy"),
                             Total = order.Quantity * product.ProductPrice,
                         };

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void InitProduct(List<Product> listProduct)
        {
            listProduct.Add(new Product
            {
                ProductCode = "SP01",
                ProductName = "Bia 333",
                ProductPrice = 9000,
            });

            listProduct.Add(new Product
            {
                ProductCode = "SP02",
                ProductName = "Number One",
                ProductPrice = 8000,
            });

            listProduct.Add(new Product
            {
                ProductCode = "SP03",
                ProductName = "Sua Chua",
                ProductPrice = 4000,
            });

            listProduct.Add(new Product
            {
                ProductCode = "SP04",
                ProductName = "Mi Goi",
                ProductPrice = 4000,
            });

            listProduct.Add(new Product
            {
                ProductCode = "SP05",
                ProductName = "Xa Phong",
                ProductPrice = 6000,
            });
        }

        public static void InitOder(List<Order> listOrder)
        {
            listOrder.Add(new Order
            {
                OrderCode = "OD01",
                ProductCode = "SP01",
                Quantity = 3,
                OrderDate = new DateTime(2018, 5, 3),
            });

            listOrder.Add(new Order
            {
                OrderCode = "OD02",
                ProductCode = "SP03",
                Quantity = 4,
                OrderDate = new DateTime(2018, 5, 6),
            });

            listOrder.Add(new Order
            {
                OrderCode = "OD03",
                ProductCode = "SP02",
                Quantity = 3,
                OrderDate = new DateTime(2018, 5, 10),
            });

            listOrder.Add(new Order
            {
                OrderCode = "OD04",
                ProductCode = "SP04",
                Quantity = 2,
                OrderDate = new DateTime(2018, 5, 9),
            });

            listOrder.Add(new Order
            {
                OrderCode = "OD05",
                ProductCode = "SP01",
                Quantity = 8,
                OrderDate = new DateTime(2018, 5, 7),
            });
        }

        static void Main(string[] args)
        {
            products = new List<Product>();
            orders = new List<Order>();
            InitProduct(products);
            InitOder(orders);
            Console.WriteLine("--------------- LIST PRODUCT ---------------");
            ShowInfoProduct(products);
            Console.WriteLine("--------------- LIST ORDER ---------------");
            ShowInfoOrder(orders); 
            Console.WriteLine("--------------- QUESTION 1---------------");
            Question1();
            Console.WriteLine("--------------- QUESTION 2---------------");
            Question2();
            Console.WriteLine("--------------- QUESTION 3---------------");
            DateTime start = new DateTime(2018, 5, 3);
            DateTime end = new DateTime(2018, 5, 10);
            Question3(start, end, 10000);
        }
    }
}
