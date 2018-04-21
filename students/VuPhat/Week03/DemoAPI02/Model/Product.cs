using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product : BaseEntity
    {
        public Guid Id { get; set; }

        [StringLength(15)]
        [Index("IX_Code", IsUnique = true)]
        public string Code { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public Guid ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer Manufacturer { get; set; }
    }
}
