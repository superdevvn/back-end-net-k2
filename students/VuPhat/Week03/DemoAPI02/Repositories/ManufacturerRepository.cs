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
    public class ManufacturerRepository
    {
        public Manufacturer Create(Manufacturer manufacturer)
        {
            using (var context = new ApiDbContext())
            {
                context.Manufacturers.Add(manufacturer);
                context.SaveChanges();
                return manufacturer;
            }
        }

        public Manufacturer Update(Manufacturer manufacturer)
        {
            using (var context = new ApiDbContext())
            {
                context.SaveChanges();
                return manufacturer;
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                var entity = context.Manufacturers.Where(p => p.Id == id).FirstOrDefault();
                context.Manufacturers.Remove(entity);
                context.SaveChanges();
            }
        }

        public IEnumerable GetList()
        {
            using (var context = new ApiDbContext())
            {
                return context.Manufacturers.Select(p => new
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    Description = p.Description,
                    Creator = p.Creator.UserName,
                    Modifier = p.Modifier.UserName,
                }).ToList();
            }
        }

        public Manufacturer Get(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                return context.Manufacturers.Where(p => p.Id == id).FirstOrDefault();
            }
        }

        public bool HashCode(string code)
        {
            using (var context = new ApiDbContext())
            {
                return context.Manufacturers.Any(p => p.Code == code);
            }
        }

        public bool HashCode(string code, Guid id)
        {
            using (var context = new ApiDbContext())
            {
                return context.Manufacturers.Any(p => p.Code == code && p.Id != id);
            }
        }
    }
}
