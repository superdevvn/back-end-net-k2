﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
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

        public virtual TEntity Create(TEntity entity)
        {
            using (var context = new ApiDbContext())
            {
                context.Set<TEntity>.Add(entity);
                context.SaveChanges();
                Guid id = new Guid(entity.GetType().GetProperty("Id")
                    .GetValue(entity, null).ToString());
                return Get(id);
            }
        }

        public virtual TEntity Update(TEntity entity, Guid? userId = null)
        {
            using (var context = new ApiDbContext())
            {
                Guid id = new Guid(entity.GetType().GetProperty("Id")
                    .GetValue(entity, null).ToString());
                var entry = context.Set<TEntity>().Find(id);
                // Gán từng giá trị của các thuộc tính entity cho entry
                CloneObject(entry, entity);
                context.SaveChanges(userId);
                return Get(id);
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
