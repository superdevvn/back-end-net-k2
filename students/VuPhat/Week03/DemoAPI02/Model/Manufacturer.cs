using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Manufacturer : BaseEntity
    {
        public Guid Id { get; set; }

        [StringLength(15)]
        [Index("IX_Code", IsUnique = true)]
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
