using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Models;
using Models.Common;
using Repositories.Common;

namespace Repositories
{
    public class RoleRepository
    {
        public PagingResult GetList(string orderBy, string orderDirection, int page, int pageSize, string whereClause = "1>0")
        {
            using (var context = new ApiDbContext())
            {
                var result = new PagingResult();
                //var query = context.Roles.AsEnumerable().Where(e=>e.CreatedDate.Date == DateTime.Today);
                var query = context.Roles.Where(whereClause);
                // total
                result.Total = query.Count();
                // entities
                result.Entities = query
                    .OrderBy(string.Format("{0} {1}", orderBy.Trim(), orderDirection.Trim()))
                    .Skip((page-1)*pageSize)
                    .Take(pageSize)
                    .ToList();
                return result;
            }
        }
        public IEnumerable GetList()
        {
            using (var context = new ApiDbContext())
            {
                return context.Roles.Select(e => new
                {
                    Id = e.Id,
                    Code = e.Code,
                    Name = e.Name,
                    CreatedDate = e.CreatedDate,
                    CreatorName = e.Creator.Username,
                    ModifiedDate = e.ModifiedDate,
                    ModifierName = e.Modifier.Username
                }).ToList();
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
