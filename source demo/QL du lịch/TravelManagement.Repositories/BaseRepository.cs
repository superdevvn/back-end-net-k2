using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Models.Common;

namespace TravelManagement.Repositories
{
    public abstract class BaseRepository<TEntity>
        where TEntity: class, new()
    {
        public virtual async Task<TEntity> Create(TEntity entity)
        {
            using (var context = new TMDbContext())
            {
                Guid id = Guid.NewGuid();
                entity.GetType().GetProperty("Id").SetValue(entity, id);
                context.Set<TEntity>().Add(entity);
                await context.SaveChangesAsync();
                return await Get(id);
            }
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            using (var context = new TMDbContext())
            {
                Guid id = new Guid(entity.GetType().GetProperty("Id").GetValue(entity, null).ToString());
                var entry = await context.Set<TEntity>().FindAsync(id);
                CloneObject(entry, entity);
                await context.SaveChangesAsync();
                return await context.Set<TEntity>().FindAsync(id);
            }
        }

        public virtual async Task<TEntity> Get(Guid id)
        {
            using (var context = new TMDbContext())
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
        }

        public virtual async Task<IEnumerable> GetList()
        {
            using (var context = new TMDbContext())
            {
                return await context.Set<TEntity>().ToListAsync();
            }
        }

        public virtual async Task<PagingResult> GetList(string orderBy, string orderDirection, int page, int pageSize, string whereClause)
        {
            using (var context = new TMDbContext())
            {
                var result = new PagingResult();
                var query = context.Set<TEntity>().Where(whereClause);
                result.Total = await query.CountAsync();
                result.Entities = await query.OrderBy(string.Format("{0} {1}", orderBy, orderDirection))
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                return result;
            }
        }

        private void CloneObject(object des, object src)
        {
            foreach (PropertyInfo propertyInfo in des.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (src.GetType().GetProperty(propertyInfo.Name, BindingFlags.Public | BindingFlags.Instance) != null)
                {
                    var value = src.GetType().GetProperty(propertyInfo.Name).GetValue(src, null);
                    propertyInfo.SetValue(des, value, null);
                }
            }
        }
    }
}
