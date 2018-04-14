using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class StudentCourse
    {
        [Key,Column(Order=0)]
        public int CourseId { get; set; }
        [Key,Column(Order=1)]
        public int StudentId { get; set; }
        public float Pratucal { get; set; }
        public float Middle { get; set; }
        public float Final { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; } 
    }
}
