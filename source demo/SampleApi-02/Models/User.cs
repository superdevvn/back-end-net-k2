using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public string Username { get; set; }

        public string HashedPassword { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Guid? ModifiedBy { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("CreatedBy")]
        public User Creator { get; set; }
    }
}
