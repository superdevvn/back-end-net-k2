using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Context
{
    public class SDbContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public SDbContext() : base("Data Source=DESKTOP-VHR2AHS\\HAULV;Initial Catalog=SMSuper;Persist Security Info=True;User ID=sa;Password=121114")
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
                        Console.WriteLine(property + ": " + entry.CurrentValues[property].ToString());
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
