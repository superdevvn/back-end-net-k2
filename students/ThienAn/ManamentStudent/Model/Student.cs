using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student
    {
        public int Id { get; set; }
        
        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Grade { get; set; }

        public string Gender { get; set; }

        public DateTime BrithDat { get; set; }
    }
}
