﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class ApiDbContext: DbContext
    {
        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public ApiDbContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<ApiDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

<<<<<<< HEAD
        public override int SaveChanges()
        {
            Guid? userId = null; // Utility.CurrentUserId;
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity &&
                (x.State == EntityState.Added ||
=======
        public int SaveChanges(Guid? userId = null)
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && 
                (x.State == EntityState.Added || 
>>>>>>> 108f629bd185e29d1aacff436cfac1af6b8b34f2
                x.State == EntityState.Modified));
            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as BaseEntity;
                if (entity != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = userId;
                        entity.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.ModifiedBy = userId;
                    entity.ModifiedDate = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
<<<<<<< HEAD
=======

>>>>>>> 108f629bd185e29d1aacff436cfac1af6b8b34f2
    }
}
