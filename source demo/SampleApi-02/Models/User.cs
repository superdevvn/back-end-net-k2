using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User: BaseEntity
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public string Username { get; set; }

        public string HashedPassword { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
