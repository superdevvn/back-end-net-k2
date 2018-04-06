using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {

        static void Main(string[] args)
        {
            // Bai tap 1
            //Exercise1();

            //Bai tap 2
            //Exercise2();

            //Bai tap 3
            Exercise3();




        }


        /// <summary>
        /// Them du lieu vao List Product
        /// </summary>
        /// <param name="products">danh sach product</param>
        static void InitDataProduct(List<Product> products)
        {
            products.Add(new Product
            {
                ProductCode = "PD01",
                Name = "SanPham1",
                Price = 1
            });

            products.Add(new Product
            {
                ProductCode = "PD02",
                Name = "SanPham2",
                Price = 2
            });

            products.Add(new Product
            {
                ProductCode = "PD03",
                Name = "SanPham3",
                Price = 3
            });
        }

        /// <summary>
        /// Them du lieu vao List Order
        /// </summary>
        /// <param name="orders">danh sach order</param>
        static void InitDataOrder(List<Order> orders)
        {
            orders.Add(new Order
            {
                OrderCode = "OD01",
                ProductCode = "PD01",
                Quantity = 1,
                Date = DateTime.Parse("01/01/2017")
            });

            orders.Add(new Order
            {
                OrderCode = "OD02",
                ProductCode = "PD01",
                Quantity = 2,
                Date = DateTime.Parse("02/01/2017")
            });


            orders.Add(new Order
            {
                OrderCode = "OD03",
                ProductCode = "PD01",
                Quantity = 3,
                Date = DateTime.Parse("02/01/2017")
            });


            orders.Add(new Order
            {
                OrderCode = "OD04",
                ProductCode = "PD02",
                Quantity = 2,
                Date = DateTime.Parse("03/01/2017")
            });


            orders.Add(new Order
            {
                OrderCode = "OD05",
                ProductCode = "PD03",
                Quantity = 2,
                Date = DateTime.Parse("02/01/2017")
            });


            orders.Add(new Order
            {
                OrderCode = "OD06",
                ProductCode = "PD03",
                Quantity = 4,
                Date = DateTime.Parse("05/01/2017")
            });
        }


        /// <summary>
        /// Bai tap 1
        /// Xuat man hinh Odercode , ProductName, Quantity, Date
        /// </summary>
        static void Exercise1()
        {
            /// Khai bao danh sach product va order
            List<Product> products = new List<Product>();
            List<Order> orders = new List<Order>();

            /// Them du lieu vao danh sach
            InitDataProduct(products);
            InitDataOrder(orders);
            /*

            /// Su dung linq de inner hai list product and order
            var result = from p in products
                         join o in orders                          
                         on p.ProductCode equals o.ProductCode
                         select new
                         {
                             o.OrderCode,
                             p.Name,
                             o.Quantity,
                             o.Date
                         };
            */

            var result = orders.Join(products,
                order => order.ProductCode, 
                product => product.ProductCode,
                (order, product) => new
            {
                OrderCode = order.OrderCode,
                Name = product.Name,
                Quantity = order.Quantity,
                Date = order.Date
            });

            // Xuat mang hinh
            foreach (var l in result)
            {
                Console.WriteLine("OrderCode:\t" + l.OrderCode);
                Console.WriteLine("ProductName:\t" + l.Name);
                Console.WriteLine("Quantity:\t" + l.Quantity);
                Console.WriteLine("Date:\t\t" + l.Date.ToString());
                Console.WriteLine();
                Console.WriteLine("--------------------------------");

            }

        }

        /// <summary>
        /// Bai tap 2
        /// Xuat man hinh Odercode , ProductName, Quantity, Date va Tong gia tri moi don hang
        /// </summary>
        static void Exercise2()
        {
            /// Khai bao danh sach product va order
            List<Product> products = new List<Product>();
            List<Order> orders = new List<Order>();

            InitDataProduct(products);
            InitDataOrder(orders);

            var result = orders.Join(products,
            order => order.ProductCode,
            product => product.ProductCode,
            (order, product) => new
            {
                OrderCode = order.OrderCode,
                Name = product.Name,
                Quantity = order.Quantity,
                Date = order.Date,
                Gia = product.Price,
                Tong=order.Quantity*product.Price
            });

            foreach (var l in result)
            {
                Console.WriteLine("OrderCode:\t" + l.OrderCode);
                Console.WriteLine("ProductName:\t" + l.Name);
                Console.WriteLine("Quantity:\t" + l.Quantity);
                Console.WriteLine("Gia:\t" + l.Gia);
                Console.WriteLine("Tong:\t" + l.Tong);
                Console.WriteLine("Date:\t\t" + l.Date.ToString());
                Console.WriteLine();
                Console.WriteLine("--------------------------------");

            }


        }


        /// <summary>
        /// Bai tap 3
        /// </summary>
        static void Exercise3()
        {
            /// Khai bao danh sach product va order
            List<Product> products = new List<Product>();
            List<Order> orders = new List<Order>();

            InitDataProduct(products);
            InitDataOrder(orders);

            var result = orders.Join(products,
            order => order.ProductCode,
            product => product.ProductCode,
            (order, product) => new
            {
                OrderCode = order.OrderCode,
                Name = product.Name,
                Quantity = order.Quantity,
                Date = order.Date,
                Gia = product.Price,
                Tong = order.Quantity * product.Price
            })
            .Where(order => order.Date > DateTime.Parse("01/01/2017"));

            foreach (var l in result)
            {
                Console.WriteLine("OrderCode:\t" + l.OrderCode);
                Console.WriteLine("ProductName:\t" + l.Name);
                Console.WriteLine("Quantity:\t" + l.Quantity);
                Console.WriteLine("Gia:\t" + l.Gia);
                Console.WriteLine("Tong:\t" + l.Tong);
                Console.WriteLine("Date:\t\t" + l.Date.ToString());
                Console.WriteLine();
                Console.WriteLine("--------------------------------");

            }


        }
    }
}
