using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Guid? ModifiedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public User Creator { get; set; }

        [ForeignKey("ModifiedBy")]
        public User Modifier { get; set; }
    }
}
