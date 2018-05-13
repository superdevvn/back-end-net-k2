using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagement.Repositories;

namespace TravelManagement.Services
{
    public abstract class BaseService<TEntity,TRepository>
        where TEntity: class, new()
        where TRepository: BaseRepository<TEntity>, new()
    {
        TRepository repository = new TRepository();
        public virtual async Task<TEntity> Create(TEntity entity)
        {
            return await repository.Create(entity);
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            return await repository.Update(entity);
        }

        public virtual async Task<TEntity> Get(Guid id)
        {
            return await repository.Get(id);
        }

        public virtual async Task<IEnumerable> GetList()
        {
            return await repository.GetList();
        }

        public virtual async Task<PagingResult> GetList(string orderBy, string orderDirection, int page, int pageSize, string whereClause)
        {
            return await repository.GetList(orderBy, orderDirection, page, pageSize, whereClause);
        }
    }
}
