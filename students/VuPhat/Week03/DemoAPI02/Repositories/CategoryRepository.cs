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
    public class CategoryRepository
    {

        public Category Create(Category category)
        {
            using (var context = new ApiDbContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return category;
            }
        }

        public Category Update(Category category)
        {
            using (var context = new ApiDbContext())
            {
                context.SaveChanges();
                return category;
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                var entity = context.Categories.Where(p => p.Id == id).FirstOrDefault();
                context.Categories.Remove(entity);
                context.SaveChanges();
            }
        }

        public IEnumerable GetList()
        {
            using (var context = new ApiDbContext())
            {
                return context.Categories.Select(p => new
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    Creator = p.Creator.UserName,
                    Modifier = p.Modifier.UserName,
                }).ToList();
            }
        }

        public Category Get(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                return context.Categories.Where(p => p.Id == id).FirstOrDefault();
            }
        }

        public bool HashCode(string code)
        {
           using(var context = new ApiDbContext())
           {
               return context.Categories.Any(p => p.Code == code);
           }
        }

        public bool HashCode(string code, Guid id)
        {
            using (var context = new ApiDbContext())
            {
                return context.Categories.Any(p => p.Code == code && p.Id != id);
            }
        }
    }
}
