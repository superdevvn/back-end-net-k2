using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Common;

namespace Repositories
{
    //Generic Template C#
    public abstract class BaseRepository<TEntity>
        where TEntity: class
    {
        public virtual TEntity Get(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }
    }
}
