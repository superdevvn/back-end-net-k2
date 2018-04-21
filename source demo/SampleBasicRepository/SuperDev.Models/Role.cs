using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SuperDev.Models
{
    public partial class SuperDevDbContext
    {
        public DbSet<Role> Roles { get; set; }
    }
    public class Role : BaseEntity
    {
        public Guid Id { get; set; }

        [StringLength(15)]
        [Index("IX_Code", IsUnique = true)]
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
