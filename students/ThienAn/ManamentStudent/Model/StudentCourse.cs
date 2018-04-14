using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StudentCourse
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public double Practical { get; set; }

        public double Middle { get; set; }

        public double Final { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

    }
}
