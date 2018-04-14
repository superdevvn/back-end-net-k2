using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TeacherAccount
    {
            public int Id { get; set; }

            public int TeacherId { get; set; }

            public int AccountId { get; set; }

            [ForeignKey("TeacherId")]
            public virtual Teacher Teacher { get; set; }

            [ForeignKey("AccountId")]
            public virtual Account Account { get; set; }
    }
}
