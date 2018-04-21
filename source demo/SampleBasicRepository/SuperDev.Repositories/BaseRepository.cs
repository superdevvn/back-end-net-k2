using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperDev.Models;
using Utilities;

namespace SuperDev.Repositories
{
    public abstract class BaseRepository<TEntity> 
        where TEntity : class, new()
    {
        public async Task<List<TEntity>> GetList()
        {
            using (var context = new SuperDevDbContext())
            {
                return await context.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<TEntity> Get(Guid id)
        {
            using (var context = new SuperDevDbContext())
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            TEntity e = new TEntity();
            Guid id = Guid.NewGuid();
            entity.GetType().GetProperty("Id").SetValue(entity, id);
            using (var context = new SuperDevDbContext())
            {
                context.Set<TEntity>().Add(entity);
                await context.SaveChangesAsync();
                return context.Set<TEntity>().Find(id);
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            using (var context = new SuperDevDbContext())
            {
                Guid id = new Guid(entity.GetType().GetProperty("Id").GetValue(entity, null).ToString());
                TEntity origin = context.Set<TEntity>().Find(id);
                Utility.CloneObject(origin, entity);
                await context.SaveChangesAsync();
                await context.Entry(origin).ReloadAsync();
                return origin;
            }
        }

        public async Task Delete(Guid id)
        {
            using (var context = new SuperDevDbContext())
            {
                TEntity entity = context.Set<TEntity>().Find(id);
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
