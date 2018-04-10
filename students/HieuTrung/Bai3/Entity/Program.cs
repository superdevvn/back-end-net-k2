using Models;
using Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            Q8();
        }
        //Read
        static void Q1()
        {
            var context = new SampleDbContext();
            var products = context.Products.ToList();
            foreach(var item in products)
            {
                Console.WriteLine("Code: " + item.Code + " Name: " + item.Name + " Price: " + item.Price.ToString());
            }
        }
        //Create
        static void Q2()
        {
            var product = new Product();
            Console.Write("Input ID: "); product.ProductID = int.Parse(Console.ReadLine());
            Console.Write("Input code: "); product.Code = Console.ReadLine();
            Console.Write("Input name: "); product.Name = Console.ReadLine();
            Console.Write("Input price: "); product.Price = double.Parse(Console.ReadLine());

            //Create product to Db
            var context = new SampleDbContext();
            context.Products.Add(product);
            context.SaveChanges();
        }
        //Update
        static void Q3()
        {
            using (var context = new SampleDbContext())
            {
                var product = context.Products.Where(pro => pro.Code == "PD04")
                                              .FirstOrDefault();
                if(product == null)
                {
                    Console.WriteLine("Không tìm thấy");
                }
                else
                {
                    product.Name = product.Name + " Updated";
                    context.SaveChanges();
                }
            }
        }
        //Delete
        static void Q4()
        {
            using (var context = new SampleDbContext())
            {
                var product = context.Products.Where(pro => pro.Code == "PD04")
                                              .FirstOrDefault();
                if (product == null)
                {
                    Console.WriteLine("Không tìm thấy");
                }
                else
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
        }
        //Update Multiple
        static void Q5()
        {
            using (var context = new SampleDbContext())
            {
                var products = context.Products.ToList();
                foreach(var product in products)
                {
                    product.Price = 69000000;
                }
                context.SaveChanges();
            }
        }
        //Update Multiple
        static void Q6()
        {
            using (var context = new SampleDbContext())
            {
                context.Database.ExecuteSqlCommand("UPDATE Products SET Price = 96000");
                context.SaveChanges();
            }
        }
        static void Q7()
        {
            var context = new SampleDbContext();
            var orders = context.Orders.Select(order => new
            {
                ID = order.ID,
                ProductID = order.ProductID,
                ProductName = order.Product.Name,
                ProductPrice = order.Product.Price,
                Quantity = order.Quantity,
                Total = order.Quantity * order.Product.Price,
                Type = order.Quantity * order.Product.Price > 500000 ? "Good" : "Bad"
            });
            foreach(var order in orders)
            {
                Console.WriteLine(string.Format("ID: {0}, ProductName: {1}, ProductPrice: {2}, Quantity: {3}, Total: {4}, Type: {5}", order.ID, order.ProductName, order.ProductPrice, order.Quantity, order.Total, order.Type));
            }
        }
        static void Q8()
        {
            var order = new Order();
            order.Product = new Product();
            Console.Write("Input code: "); order.Product.Code = Console.ReadLine();

            Console.Write("Input name: "); order.Product.Name = Console.ReadLine();

            Console.Write("Input price: "); order.Product.Price = double.Parse(Console.ReadLine());

            //Create Product to DB
            var content = new SampleDbContext();
            content.Orders.Add(order);
            content.SaveChanges();
        }
        static void Q9()
        {
            using (var context = new SampleDbContext())
            {
                var orders = context.Orders.Select(order => new
                {
                    ID = order.ID,
                    ProductID = order.ProductID,
                    ProductName = order.Product.Name,
                    ProductPrice = order.Product.Price,
                    Quantity = order.Quantity,
                    Total = order.Quantity * order.Product.Price,
                    Type = order.Quantity * order.Product.Price > 500000 ? "Good" : "Bad"
                });
                foreach (var order in orders)
                {
                    Console.WriteLine(string.Format("ID: {0}, ProductName: {1}, ProductPrice: {2}, Quantity: {3}, Total: {4}, Type: {5}", order.ID, order.ProductName, order.ProductPrice, order.Quantity, order.Total, order.Type));
                }
            }
        }
        static void Q10()
        {
            var orders = new List<Order>();
            using (var context = new SampleDbContext())
            {
                //orders = context.Orders.Include("Product").ToList();
                orders = context.Orders.Include(p => p.Product).ToList();
            }
            foreach (var order in orders)
            {
                Console.WriteLine(string.Format("ID: {0}, ProductName: {1}, ProductPrice: {2}", order.ID, order.Product.Name, order.Product.Price));
            }
        }
        static void Q11()
        {
            using (var db = new SampleDbContext())
            {
                var product = db.Products.Select(pro => pro)
                                         .Where(pro => pro.Code == "PD99")
                                         .FirstOrDefault();
                product.Price = 55000;
                db.SaveChanges();
            }
        }
        static void Q12()
        {
            using (var db = new SampleDbContext())
            {
                var product = db.Products.Select(pro => pro)
                                         .Where(pro => pro.Code == "PD99")
                                         .FirstOrDefault();
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}
