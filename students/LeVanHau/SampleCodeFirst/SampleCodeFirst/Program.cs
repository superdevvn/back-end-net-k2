using Models;
using Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Q3();
        }

        static void Q1()
        {
            var context = new SampleDbContext();
            var orders = context.Orders.Select(s => new
            {
                Id = s.Id,
                ProductId = s.ProductId,
                ProductName = s.Product.Name,
                ProductPrice = s.Product.Price,
                Quantity = s.Quantity,
                Total = s.Quantity * s.Product.Price
            });
            foreach (var order in orders)
            {
                Console.WriteLine(
                    string.Format(
                        "Id: {0}, " +
                        "Product Name: {1}, " +
                        "Product Price: {2}, " +
                        "Total: {3}", order.Id, order.ProductName, order.ProductPrice, order.Total));
            }
        }

        static void Q2()
        {
            var order = new Order();
            order.Product = new Product();
            Console.WriteLine("Input code: ");
            order.Product.Code = Console.ReadLine();

            Console.WriteLine("Input name: ");
            order.Product.Name = Console.ReadLine();

            Console.WriteLine("Input price: ");
            order.Product.Price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input quantity: ");
            order.Quantity = int.Parse(Console.ReadLine());
            //create product in db
            var context = new SampleDbContext();
            context.Orders.Add(order);
            context.SaveChanges();
        }

        static void Q3()
        {
            var orders = new List<Order>();
            using (var context = new SampleDbContext())
            {
                orders = context.Orders.ToList();
            }
            foreach (var order in orders)
            {
                Console.WriteLine(
                    string.Format(
                        "Id: {0}, " +
                        "Product Name: {1}, " +
                        "Product Price: {2}, " +
                        "Total: {3}", order.Id, order.Product.Name,
                        order.Product.Price, order.Product.Price * order.Quantity));
            }
        }
    }
}
