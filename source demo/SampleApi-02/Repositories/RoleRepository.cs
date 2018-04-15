using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Models.Common;

namespace Repositories
{
    public class RoleRepository
    {
        public List<Role> GetList()
        {
            using (var context = new ApiDbContext())
            {
                return context.Roles.ToList();
            }
        }

        public Role Get(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                return context.Roles.Find(id);
            }
        }

        public Role Create(Role role)
        {
            using (var context = new ApiDbContext())
            {
                context.Roles.Add(role);
                context.SaveChanges();
                return context.Roles.Find(role.Id);
            }
        }

        public Role Update(Role role)
        {
            using (var context = new ApiDbContext())
            {
                var entity = context.Roles.Find(role.Id);
                entity.Code = role.Code;
                entity.Name = role.Name;
                entity.ModifiedDate = role.ModifiedDate;
                context.SaveChanges();
                context.Entry(entity).Reload();
                return entity;
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                var entity = context.Roles.Find(id);
                context.Roles.Remove(entity);
                context.SaveChanges();
            }
        }

        public bool HasCode(string code)
        {
            using (var context = new ApiDbContext())
            {
                return context.Roles.Any(e => e.Code == code);
            }
        }

        public bool HasCode(Guid id, string code)
        {
            using (var context = new ApiDbContext())
            {
                return context.Roles.Any(e => e.Id != id && e.Code == code);
            }
        }
    }
}
