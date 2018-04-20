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
    public class ProductRepository
    {
        public Product Create(Product product)
        {
            using (var context = new ApiDbContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
                return product;
            }
        }

        public Product Update(Product product)
        {
            using (var context = new ApiDbContext())
            {
                context.SaveChanges();
                return product;
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                var entity = context.Products.Where(p => p.Id == id).FirstOrDefault();
                context.Products.Remove(entity);
                context.SaveChanges();
            }
        }

        public IEnumerable GetList()
        {
            using (var context = new ApiDbContext())
            {
                return context.Products.Select(p => new
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    Category = p.Category.Name,
                    Manufacturer = p.Manufacturer.Name,
                    Creator = p.Creator.UserName,
                    Modifier = p.Modifier.UserName,
                }).ToList();
            }
        }

        public Product Get(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                return context.Products.Where(p => p.Id == id).FirstOrDefault();
            }
        }

        public bool HashCode(string code)
        {
            using (var context = new ApiDbContext())
            {
                return context.Products.Any(p => p.Code == code);
            }
        }

        public bool HashCode(string code, Guid id)
        {
            using (var context = new ApiDbContext())
            {
                return context.Products.Any(p => p.Code == code && p.Id != id);
            }
        }

        public bool HashId_Category(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                return context.Categories.Any(p => p.Id != id);
            }
        }

        public bool HashId_Manufacture(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                return context.Manufacturers.Any(p => p.Id != id);
            }
        }
    }
}
