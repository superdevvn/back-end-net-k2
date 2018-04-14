using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Models.DbContent
{
    public class SampleContext :DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public SampleContext() :base("Data Source=DESKTOP-KPALBO7\\NGUYENNHO;Initial Catalog=QLSV; Integrated Security=True")
            {

        }
    }
}
