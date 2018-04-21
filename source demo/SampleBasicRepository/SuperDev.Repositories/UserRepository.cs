using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using SuperDev.Models;

namespace SuperDev.Repositories
{
    public class UserRepository:BaseRepository<User>
    {

        public async Task<PagedListResult> GetList(string whereClause, string orderBy, string orderDirection, int pageNumber, int pageSize)
        {
            using (var context = new SuperDevDbContext())
            {
                var query = context.Users.Select(e => new
                {
                    Id = e.Id,
                    RoleId = e.RoleId,
                    RoleName = e.Role.Name,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Username = e.Username,
                    CreatedDate = e.CreatedDate,
                    CreatedBy = e.CreatedBy,
                    CreatorName = e.Creator.Username
                }).Where(whereClause);
                var entities = await query.OrderBy(string.Format("{0} {1}", orderBy.Trim(), orderDirection.Trim()))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
                return new PagedListResult(entities, query.Count());
            }
        }

        public async Task<User> Get(string username)
        {
            using (var context = new SuperDevDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(e => e.Username == username);
            }
        }
    }
}
