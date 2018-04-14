using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Assignment_2.Context
{
    class StudentCourse
    {
        [Key, Column(Order = 0)]
        public int CourseId { get; set; }

        [Key, Column(Order = 1)]
        public int StudentId { get; set; }

        public int Practical { get; set; }
        public int Middle { get; set; }
        public int Final { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}
