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


        public SampleDbContext() : base("Data Source=DESKTOP-VHR2AHS\\HAULV;Initial Catalog=SampleCF1;Persist Security Info=True;User ID=sa;Password=121114")
        {

        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    Console.WriteLine("Created");
                    foreach (var property in entry.CurrentValues.PropertyNames)
                    {
                        Console.WriteLine(property+ ": " + entry.CurrentValues[property].ToString());
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
