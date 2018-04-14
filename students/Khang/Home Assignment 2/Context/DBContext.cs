using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Assignment_2.Context
{
    class DBContext: DbContext
    {
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DBContext() : base("Data Source=DESKTOP-45Q8J5A ;Initial Catalog=CourseManagement; User ID = khang; Password=sqlntk100397")
        {

        }
    }
}
