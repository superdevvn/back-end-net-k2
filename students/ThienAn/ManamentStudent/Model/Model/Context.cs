using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
   public class Context:DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<StudentAccount> StudentAccouts { get; set; }

        public DbSet<TeacherAccount> TeacherAccounts { get; set; }


        public Context():base(@"Data Source=DESKTOP-NIHK0KO\SQLEXPRESS;Initial Catalog=StudnetManament;Integrated Security=True")
        {

        }
    }
}
