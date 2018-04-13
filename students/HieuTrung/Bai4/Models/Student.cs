using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student
    {
        public int ID { get; set; }
        [StringLength(10)]
        [Index("Student_Code", IsUnique = true)]
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Username { get; set; }
        [ForeignKey("Username")]
        public virtual Account Account { get; set; }
    }
}
