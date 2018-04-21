using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using PagedList;
using SuperDev.Models;

namespace SuperDev.Repositories
{
    public class RoleRepository : BaseRepository<Role>
    {
        public async Task<PagedListResult> GetList(string whereClause, string orderBy, string orderDirection, int pageNumber, int pageSize)
        {
            using (var context = new SuperDevDbContext())
            {
                var query = context.Roles.Select(e => new
                {
                    Id = e.Id,
                    Code = e.Code,
                    Name = e.Name,
                    CreatedDate = e.CreatedDate,
                    CreatorName = e.Creator.Username,
                    ModifiedDate = e.ModifiedDate,
                    ModifierName = e.Modifier.Username
                }).Where(whereClause);
                var entities = await query.OrderBy(string.Format("{0} {1}", orderBy.Trim(), orderDirection.Trim()))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
                return new PagedListResult(entities, query.Count());
            }
        }

        public bool HasCode(string code)
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Roles.Any(e => e.Code == code);
            }
        }

        public bool HasCode(Guid id, string code)
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Roles.Any(e => e.Id != id && e.Code == code);
            }
        }
    }
}
