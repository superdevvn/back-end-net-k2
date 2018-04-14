using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StudentAccount
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int AccountId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}
