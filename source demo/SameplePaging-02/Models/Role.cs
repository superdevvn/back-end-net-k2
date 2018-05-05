using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Role: BaseEntity
    {
        public Guid Id { get; set; }

        [StringLength(15)]
        [Index("IX_Code", IsUnique = true)]
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
