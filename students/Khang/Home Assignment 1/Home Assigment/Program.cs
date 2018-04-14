using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Nguyen Thinh Khang
 * Back-end C#.NET
 * Home work 1
 */

namespace Home_Assigment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> listProducts = new List<Product>();
            List<Order> listOrders = new List<Order>();

            initProducts(listProducts);
            initOrders(listOrders);

            showAllProducts(listProducts);
            showAllOrders(listOrders);

            Excercise1(listProducts, listOrders);
            Excercise2(listProducts, listOrders);

            Date start = new Date(1, 12, 2017);
            Date end = new Date(8, 1, 2018);
            int C = 5000000;
            Excercise3(listProducts, listOrders, start, end, C);
        }

        static void Excercise1(List<Product> products, List<Order> orders)
        {
            Console.WriteLine("Excercise 1: ");
            var result = orders.Join(products, o => o.productCode, p => p.code,
                (o, p) => new { OrderCode = o.code, Name = p.name, Number = o.number, DateOrder = o.dayOrder.ToString() });
            foreach (var res in result)
                Console.WriteLine("OrderCode:" + res.OrderCode + " "
                    + "Name:" + res.Name + " "
                    + "Number:" + res.Number + " "
                    + "Day Order:" + res.DateOrder);

            Console.WriteLine("****************************************************************");
        }

        static void Excercise2(List<Product> products, List<Order> orders)
        {
            Console.WriteLine("Excercise 2: ");
            var result = orders.Join(products, o => o.productCode, p => p.code,
                (o, p) => new { OrderCode = o.code, Name = p.name, Number = o.number, Total = o.number * p.price, DateOrder = o.dayOrder.ToString() });
            foreach (var res in result)
                Console.WriteLine("OrderCode:" + res.OrderCode + " "
                    + "Name:" + res.Name + " "
                    + "Number:" + res.Number + " "
                    + "Total:" + res.Total + " "
                    + "Day Order:" + res.DateOrder);

            Console.WriteLine("****************************************************************");
        }

        static void Excercise3(List<Product> products, List<Order> orders, Date startDay, Date endDate, int C)
        {
            Console.WriteLine("Excercise 3: ");
            Console.WriteLine("Start day: " + startDay.ToString()
                + " End day: " + endDate.ToString()
                + " C = " + C);
            var result = orders.Join(products, o => o.productCode, p => p.code,
                (o, p) => new { OrderCode = o.code, Name = p.name, Number = o.number, Total = o.number * p.price, DateOrder = o.dayOrder }).
                Where(res => res.DateOrder.CompareTo(startDay) >= 0 && res.DateOrder.CompareTo(endDate) <= 0 && res.Total > C);
            foreach (var res in result)
                Console.WriteLine("OrderCode:" + res.OrderCode + " "
                    + "Name:" + res.Name + " "
                    + "Number:" + res.Number + " "
                    + "Total:" + res.Total + " "
                    + "Day Order:" + res.DateOrder.ToString());

            Console.WriteLine("****************************************************************");
        }

        // Khoi tao cac san pham
        static void initProducts(List<Product> list)
        {
            list.Add(new Product() { name = "TV", code = "001", price = 7000000 });
            list.Add(new Product() { name = "Tu Lanh", code = "002", price = 4500000 });
            list.Add(new Product() { name = "May Giat", code = "003", price = 3500000 });
        }
        // In ra tat ca cac san pham
        static void showAllProducts(List<Product> list)
        {
            Console.WriteLine("All Products");
            foreach (var product in list)
                product.showInfo();
            Console.WriteLine("****************************************************************");
        }

        // Khoi tao cac don hang
        static void initOrders(List<Order> list)
        {
            list.Add(new Order() { code = "dh001", productCode = "001", number = 3, dayOrder = new Date(1, 12, 2017) });
            list.Add(new Order() { code = "dh001", productCode = "002", number = 2, dayOrder = new Date(1, 12, 2017) });

            list.Add(new Order() { code = "dh002", productCode = "002", number = 1, dayOrder = new Date(8, 1, 2018) });
            list.Add(new Order() { code = "dh003", productCode = "001", number = 2, dayOrder = new Date(31, 3, 2018) });
            list.Add(new Order() { code = "dh004", productCode = "003", number = 5, dayOrder = new Date(12, 11, 2017) });
        }
        // In ra tat cac cac don hang
        static void showAllOrders(List<Order> list)
        {
            Console.WriteLine("All Orders");
            foreach (var order in list)
                order.showInfo();
            Console.WriteLine("****************************************************************");
        }
    }
}
