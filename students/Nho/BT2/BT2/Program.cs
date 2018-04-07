using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product
            { 
                productcode ="pd1",
                productname="Dienthoai",
                price=2000000
            });
            products.Add(new Product
            {
                productcode = "pd1",
                productname = "Dienthoai",
                price = 2000000
            });
            products.Add(new Product
            {
                productcode = "pd2",
                productname = "Tivi",
                price = 12000000
            });
            products.Add(new Product
            {
                productcode = "pd3",
                productname = "Laptop",
                price = 20000000
            });
            products.Add(new Product
            {
                productcode = "pd4",
                productname = "Maytinhbang",
                price = 5000000
            });
            List<Order> orders = new List<Order>();
            orders.Add(new Order
            {
                ordercode = "1",
                date = DateTime.Parse("01/01/2017"),
                productcode="pd1",
                quality=1
            });
            orders.Add(new Order
            {
                ordercode = "2",
                date = DateTime.Parse("10/08/2017"),
                productcode = "pd1",
                quality = 2
            });
            orders.Add(new Order
            {
                ordercode = "3",
                date = DateTime.Parse("01/02/2017"),
                productcode = "pd4",
                quality = 1
            });
            orders.Add(new Order
            {
                ordercode = "4",
                date = DateTime.Parse("06/01/2017"),
                productcode = "pd2",
                quality = 3
            });

            //var result = from p in products
            //             join od in orders on p.productcode equals od.productcode
            //             select new
            //             {
            //                 ordercode = od.ordercode,
            //                 productname = p.productname,
            //                 quality = od.quality,
            //                 date = od.date
            //             };
            //foreach (var item in result)
            //{
            //    Console.WriteLine("Ordercode: " +item.ordercode);
            //    Console.WriteLine("Productname: " + item.productname);
            //    Console.WriteLine("Quality: " + item.quality);
            //    Console.WriteLine("Date: " + item.date);

            //    Console.WriteLine("=====================================");
            //}

            
            float total;
            var result2= from p in products
                         join od in orders on p.productcode equals od.productcode
                         select new
                         {
                             ordercode = od.ordercode,
                             productname = p.productname,
                             quality = od.quality,
                             date = od.date,
                             total=od.quality*p.price
                         };
            foreach (var item in result2)
            {
                Console.WriteLine("Ordercode: " + item.ordercode);
                Console.WriteLine("Productname: " + item.productname);
                Console.WriteLine("Quality: " + item.quality);
                Console.WriteLine("Date: " + item.date);
                Console.WriteLine("Total: " + item.total);
                Console.WriteLine("=====================================");
                
            }
            Console.WriteLine("***********");
            //Console.ReadLine();
            float total1;
            var result3 = orders.Join(products,
                                     od => od.productcode,
                                     p => p.productcode,
                                     (order, product) => new
                                     {
                                         ordercode = order.ordercode,
                                         productname = product.productname,
                                         quality = order.quality,
                                         date = order.date,
                                         total1 = order.quality * product.price
                                     })
                               .Where(order => order.date > DateTime.Parse("01/02/2017") && order.date<DateTime.Parse("10/08/2017"));
            result3 = result3.Select(rs => rs)
                             .Where(rs => rs.total1 > 100000);


            foreach (var item in result2)
            {
                Console.WriteLine("Ordercode: " + item.ordercode);
                Console.WriteLine("Productname: " + item.productname);
                Console.WriteLine("Quality: " + item.quality);
                Console.WriteLine("Date: " + item.date);
                Console.WriteLine("Total: " + item.total);
                Console.WriteLine("=====================================");

            }
            Console.ReadLine();
        }

}
}
