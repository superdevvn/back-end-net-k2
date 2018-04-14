using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Assignment_2.Context
{
    class Course
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndedDate { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject{get;set;}
    }
}
