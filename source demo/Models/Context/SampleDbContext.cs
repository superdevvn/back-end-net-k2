using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Context
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public SampleDbContext()
            : base("Data Source=DESKTOP-15KKVN2\\SQLEXPRESS;Initial Catalog=SampleCF2;Integrated Security=True")
        {

        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    Console.WriteLine("CREATED");
                    foreach (var property in entry.CurrentValues.PropertyNames)
                    {
                        Console.WriteLine(property + ": " + entry.CurrentValues[property].ToString());
                    }
                } else if (entry.State == EntityState.Modified)
                {

                }
                else if (entry.State == EntityState.Deleted)
                {

                }
            }
            return base.SaveChanges();
        }
    }
}
