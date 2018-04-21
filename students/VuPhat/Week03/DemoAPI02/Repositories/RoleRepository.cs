using Model;
using Model.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoleRepository
    {
        public bool HashCode(string code)
        {
            using(var context = new ApiDbContext())
            {
                return context.Roles.Any(p => p.Code == code);
            }
        }

        public bool HashCode(string code, Guid id)
        {
            using (var context = new ApiDbContext())
            {
                return context.Roles.Any(p => p.Code == code && p.Id != id);
            }
        }

        public Role Create(Role role)
        {
            using(var context = new ApiDbContext())
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
                var entity = context.Roles.Where(p => p.Id == role.Id).FirstOrDefault();
                entity.Name = role.Name;
                entity.Code = role.Code;
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(Guid id)
        {
            using(var context = new ApiDbContext())
            {
                var role = context.Roles.Where(p => p.Id == id).FirstOrDefault();
                context.Roles.Remove(role);
                context.SaveChanges();
            }
        }

        public Role Get(Guid id)
        {
            using(var context = new ApiDbContext())
            {
                return context.Roles.Where(p => p.Id == id).FirstOrDefault();
            }
        }

        public IEnumerable GetList()
        {
            using(var context = new ApiDbContext())
            {
                return context.Roles.Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreatedDate = p.CreatedDate,
                    CreatedName = p.Creator.UserName,
                    ModifiedDate = p.ModifiedDate,
                    ModifierName = p.Modifier.UserName,
                }).ToList();
            }
        }
    }
}
