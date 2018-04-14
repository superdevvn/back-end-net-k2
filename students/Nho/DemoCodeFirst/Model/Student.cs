using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public enum Gender
    {
        Female,
            Male,
            Bisexual
    }
    public class Student
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Index("IX_Code", IsUnique = true)]
        public string Code { get; set; }
         public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public virtual Account Account { get; set; }
    }
}
