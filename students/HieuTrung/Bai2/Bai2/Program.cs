using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Homework1();
            Homework2();
            //Homework3();
        }
        static void InitProduct(List<Product> products)
        {
            products.Add(new Product
            {
                Code = "PD01",
                Name = "Xperia XA2",
                Price = 6590000
            });
            products.Add(new Product
            {
                Code = "PD02",
                Name = "Xperia XA2 Ultra",
                Price = 8990000
            });
            products.Add(new Product
            {
                Code = "PD03",
                Name = "Xperia L2",
                Price = 5490000
            });
            products.Add(new Product
            {
                Code = "PD04",
                Name = "Xperia XZ1",
                Price = 15990000
            });
            products.Add(new Product
            {
                Code = "PD05",
                Name = "Xperia XZ Premium",
                Price = 16990000
            });
            products.Add(new Product
            {
                Code = "PD06",
                Name = "Xperia Touch",
                Price = 38990000
            });
            products.Add(new Product
            {
                Code = "PD07",
                Name = "Playstation Pro 1TB",
                Price = 11990000
            });
        }
        static void InitOrder(List<Order> orders)
        {
            orders.Add(new Order
            {
                Code = "OD01",
                ProductCode = "PD01",
                Quantity = 1,
                Date = DateTime.Parse("02/02/2017")
            });
            orders.Add(new Order
            {
                Code = "OD02",
                ProductCode = "PD03",
                Quantity = 2,
                Date = DateTime.Parse("25/09/2017")
            });
            orders.Add(new Order
            {
                Code = "OD03",
                ProductCode = "PD02",
                Quantity = 1,
                Date = DateTime.Parse("16/03/2017")
            });
            orders.Add(new Order
            {
                Code = "OD04",
                ProductCode = "PD04",
                Quantity = 5,
                Date = DateTime.Parse("25/03/2017")
            });
            orders.Add(new Order
            {
                Code = "OD05",
                ProductCode = "PD07",
                Quantity = 1,
                Date = DateTime.Parse("19/11/2017")
            });
            orders.Add(new Order
            {
                Code = "OD06",
                ProductCode = "PD02",
                Quantity = 3,
                Date = DateTime.Parse("14/02/2017")
            });
            orders.Add(new Order
            {
                Code = "OD07",
                ProductCode = "PD07",
                Quantity = 4,
                Date = DateTime.Parse("06/06/2017")
            });
            orders.Add(new Order
            {
                Code = "OD08",
                ProductCode = "PD02",
                Quantity = 1,
                Date = DateTime.Parse("07/05/2017")
            });
        }
        static void Homework1()
        {
            /* Order Code
             * Product Name
             * Quantity
             * Date */

            //Declare
            List<Product> products = new List<Product>();
            List<Order> orders = new List<Order>();
            //Init
            InitProduct(products);
            InitOrder(orders);
            //
            var result = orders.Join(products, order => order.ProductCode, product => product.Code, (order, product) => new
            {
                OrderCode = order.Code,
                ProductName = product.Name,
                Quantity = order.Quantity,
                Date = order.Date
            });
            foreach(var order in result)
            {
                Console.WriteLine("OrderCode:\t" + order.OrderCode);
                Console.WriteLine("ProductName:\t" + order.ProductName);
                Console.WriteLine("Quantity:\t" + order.Quantity);
                Console.WriteLine("Date:\t\t" + order.Date.ToShortDateString());
                Console.WriteLine();
            }
        }
        static void Homework2()
        {
            /* .
             * .
             * .
             * Total: Quantity * Price (Total > 10,000,000) */

            //Declare
            List<Product> products = new List<Product>();
            List<Order> orders = new List<Order>();
            //Init
            InitProduct(products);
            InitOrder(orders);
            //
            var result = orders.Join(products, order => order.ProductCode, product => product.Code, (order, product) => new
            {
                OrderCode = order.Code,
                ProductName = product.Name,
                Quantity = order.Quantity,
                Date = order.Date,
                UnitPrice = product.Price/1.0,
                Total = order.Quantity * product.Price/1.0
            })
                               .Where(or => or.Total > 10000000);
            foreach (var order in result)
            {
                Console.WriteLine("OrderCode:\t" + order.OrderCode);
                Console.WriteLine("ProductName:\t" + order.ProductName);
                Console.WriteLine("Date:\t\t" + order.Date.ToShortDateString());
                Console.WriteLine("Quantity:\t" + order.Quantity);
                Console.WriteLine("UnitPrice:\t" + order.UnitPrice);
                Console.WriteLine("Total:\t\t" + order.Total);
                Console.WriteLine();
            }
        }
        static void Homework3()
        {
            /* OrderCode
             * Product Name
             * Quantity
             * Date (From Date to Date) */

            //Declare
            List<Product> products = new List<Product>();
            List<Order> orders = new List<Order>();
            //Init
            InitProduct(products);
            InitOrder(orders);
            //
            var result = orders.Join(products,
                                     order => order.ProductCode,
                                     product => product.Code,
                                     (order, product) => new
                                     {
                                         OrderCode = order.Code,
                                         ProductName = product.Name,
                                         Quantity = order.Quantity,
                                         Date = order.Date
                                     })
                               .Where(order => order.Date > DateTime.Parse("01/5/2017") && order.Date < DateTime.Parse("05/10/2017"));

            foreach (var order in result)
            {
                Console.WriteLine("OrderCode:\t" + order.OrderCode);
                Console.WriteLine("ProductName:\t" + order.ProductName);
                Console.WriteLine("Quantity:\t" + order.Quantity);
                Console.WriteLine("Date:\t\t" + order.Date.ToShortDateString());
                Console.WriteLine();
            }
        }
    }
}
