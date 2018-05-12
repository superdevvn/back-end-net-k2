using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Subject
    {
        public int Id { get; set; }

        [StringLength(15)]
        [Index("IX_Code", IsUnique = true)]
        public String Code { get; set; }

        [StringLength(50)]
        public String Name { get; set; }

        public int Credits { get; set; }

        public Double Tuition { get; set; }

        [StringLength(500)]
        public String Description { get; set; }
    }
}
