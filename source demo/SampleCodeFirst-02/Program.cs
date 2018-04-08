using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Context;

namespace SampleCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Q2();
        }

        // Read
        static void Q1()
        {
            var context = new SampleDbContext();
            var orders = context.Orders.Select(order => new
            {
                Id = order.Id,
                ProductId = order.ProductId,
                ProductName = order.Product.Name,
                ProductPrice = order.Product.Price,
                Quantity = order.Quantity,
                Total = order.Quantity * order.Product.Price,
                Type  = order.Quantity * order.Product.Price > 50000000? "Good": "Bad"
            });
            foreach(var order in orders)
            {
                Console.WriteLine(string.Format("Id: {0}, Product Name: {1}, Product Price: {2}, Quantity: {3}, Total: {4}",order.Id, order.ProductName, order.ProductPrice, order.Quantity, order.Total));
            }
        }
        // Create
        static void Q2()
        {
            var order = new Order();
            order.Product = new Product();
            Console.Write("Input code: ");
            order.Product.Code = Console.ReadLine();

            Console.Write("Input name: ");
            order.Product.Name = Console.ReadLine();

            Console.Write("Input price: ");
            order.Product.Price = double.Parse(Console.ReadLine());

            Console.Write("Input quantity: ");
            order.Quantity = int.Parse(Console.ReadLine());

            // Create Product to DB
            var context = new SampleDbContext();
            context.Orders.Add(order);
            context.SaveChanges();
        }

        // Update
        static void Q3()
        {
            using (var context = new SampleDbContext())
            {
                var product = context.Products
                    .Where(e => e.Code == "004")
                    .FirstOrDefault();
                if (product == null) Console.WriteLine("Không tìm thấy");
                else
                {
                    product.Name = product.Name + " Updated";
                    context.SaveChanges();
                }
            }
        }

        static void Q4()
        {
            using (var product = new Product())
            {
                Console.WriteLine("Tao vừa mới được tạo");
            }
        }

        static void Q5()
        {
            using (var context = new SampleDbContext())
            {
                var product = context.Products
                    .Where(e => e.Code == "004")
                    .FirstOrDefault();
                if (product == null) Console.WriteLine("Không tìm thấy");
                else
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
        }

        // Update multiple
        static void Q6()
        {
            using (var context = new SampleDbContext())
            {
                var products = context.Products.ToList();
                foreach(var product in products)
                {
                    product.Price = 10000000;
                }
                context.SaveChanges();
            }
        }

        static void Q7()
        {
            using (var context = new SampleDbContext())
            {
                try
                {
                    context.Database.ExecuteSqlCommand("UPDATE Products SET Price = 15000000");
                    Console.WriteLine("Done");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
