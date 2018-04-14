using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Index("IX_Code",IsUnique=true)]
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public virtual Account Account { get; set; }
    }
}
