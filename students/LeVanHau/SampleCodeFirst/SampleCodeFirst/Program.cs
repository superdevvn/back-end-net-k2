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
            Q2();
        }

        //read
        static void Q1()
        {
            var context = new SampleDbContext();
            var products = context.Products.ToList();
            foreach (var item in products)
            {
                Console.WriteLine("Code: " + item.Code + " Name: " + item.Name + " Price: " + item.Price);
            }
        }

        //create
        static void Q2()
        {
            var product = new Product();
            Console.Write("Input code: ");
            product.Code = Console.ReadLine();
            Console.Write("Input Name: ");
            product.Name = Console.ReadLine();
            Console.Write("Input Price: ");
            product.Price = Double.Parse(Console.ReadLine());

            var context = new SampleDbContext();
            context.Products.Add(product);
            context.SaveChanges();
            Console.WriteLine("Save completed!");
        }

        //update
        static void Q3()
        {
            using(var context = new SampleDbContext())
            {
                var product = context.Products.Where(s => s.Code == "004").FirstOrDefault();
                if (product == null) Console.WriteLine("Not found");
                else
                {
                    product.Name = product.Name + "Update";
                }
            }
        }

        //delete
        static void Q4()
        {
            using (var context = new SampleDbContext())
            {
                var product = context.Products.Where(s => s.Code == "004").FirstOrDefault();
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        //update vài thằng 1 lúc, multiple
        static void Q5()
        {
            using (var context = new SampleDbContext())
            {
                var products = context.Products.ToList();
                foreach (var pro in products)
                {
                    pro.Price = 10000000;
                }
                context.SaveChanges();
            }
        }

        //
        static void Q6()
        {
            using (var context = new SampleDbContext())
            {
                context.Database.ExecuteSqlCommand("UPDATE Products SET Price = 15000000");
            }
        }
    }
}
