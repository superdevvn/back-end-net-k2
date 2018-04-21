using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SuperDev.Models
{
    public partial class SuperDevDbContext
    {
        public DbSet<Finance> Finances { get; set; }
    }
    public class Finance
    {
        public Guid Id { get; set; }

        public Guid ApprovedBy { get; set; }

        [StringLength(15)]
        [Index("IX_Code", IsUnique = true)]
        public string Code { get; set; }

        public bool IsIncome { get; set; }

        public bool IsApproved { get; set; }

        public decimal Amount { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [ForeignKey("ApprovedBy")]
        public User Approver { get; set; }
    }
}
