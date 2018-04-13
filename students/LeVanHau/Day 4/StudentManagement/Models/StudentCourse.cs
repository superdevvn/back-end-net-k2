using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StudentCourse
    {
        [Key, Column(Order = 0)]
        public int CourseId { get; set; }
        [Key, Column(Order = 1)]
        public int StudentId { get; set; }
        public int Practical { get; set; }
        public int Middle { get; set; }
        public int Final { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
