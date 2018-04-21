using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SuperDev.Models
{
    public partial class SuperDevDbContext
    {
        public DbSet<User> Users { get; set; }
    }
    public class User
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [StringLength(15)]
        [Index("IX_Username", IsUnique = true)]
        public string Username { get; set; }

        public string HashedPassword { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("CreatedBy")]
        public User Creator { get; set; }
    }
}
