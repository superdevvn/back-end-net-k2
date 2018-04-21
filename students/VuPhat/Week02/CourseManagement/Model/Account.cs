using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Account
    {
        public int Id { get; set; } 

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public int? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
    }
}
