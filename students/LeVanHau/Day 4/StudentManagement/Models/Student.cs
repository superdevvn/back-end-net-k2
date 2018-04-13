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
        public int Id { get; set; }

        [StringLength(15)]
        [Index("IX_Code", IsUnique = true)]
        public String Code { get; set; }

        [StringLength(50)]
        public String FirstName { get; set; }

        [StringLength(50)]
        public String LastName { get; set; }

        [StringLength(50)]
        public String Grade { get; set; }

        public GenderType Gender { get; set; }

        public DateTime Birthday { get; set; }

        public enum GenderType
        {
            Male,
            Female,
            Other
        }
    }
}
