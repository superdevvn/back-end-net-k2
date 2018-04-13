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
        public int CourseID { get; set; }
        [Key, Column(Order = 1)]
        public int StudentID { get; set; }
        public float Practical { get; set; }
        public float Middle { get; set; }
        public float Final { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }
}
