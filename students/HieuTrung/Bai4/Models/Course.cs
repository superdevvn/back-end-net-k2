using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Course
    {
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public int TeacherID { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndedDate { get; set; }
        [ForeignKey("SubjectID")]
        public virtual Subject Subject { get; set; }
        [ForeignKey("TeacherID")]
        public virtual Teacher Teacher { get; set; }
    }
}
