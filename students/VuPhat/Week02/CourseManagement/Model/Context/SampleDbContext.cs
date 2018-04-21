using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Context
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public SampleDbContext()
            : base(@"Data Source=DESKTOP-FFT65UO\SQLEXPRESS;Initial Catalog=CourseManagement;Integrated Security=True")
        {

        }
    }
}
