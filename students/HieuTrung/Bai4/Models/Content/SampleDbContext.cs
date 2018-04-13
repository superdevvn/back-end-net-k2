using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Models.Content
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public SampleDbContext() : base(@"Data Source=RAINBOWPIG\HEOBAYMAU;Initial Catalog=StudentHomework;Integrated Security=True")
        {

        }
    }
}
