using Model;
using Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository
    {
        public User Create(User user)
        {
            using(var context = new ApiDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                return user;
            }
        }

        public User Get(string username)
        {
            using (var context = new ApiDbContext())
            {
                return context.Users.FirstOrDefault(e => e.UserName == username);
            }
        }

        public User Update(User user)
        {
            using (var context = new ApiDbContext())
            {
                var entity = context.Users.Where(p => p.Id == user.Id).FirstOrDefault();
                entity.Id = user.Id;
                entity.UserName = user.UserName;
                entity.HashPassWord = user.HashPassWord;
                user.ModifiedDate = DateTime.Now;
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(Guid id)
        {
            using(var context = new ApiDbContext())
            {
                var entity = context.Users.Where(p => p.Id == id).FirstOrDefault();
                if(entity != null)
                {
                    context.Users.Remove(entity);
                    context.SaveChanges();
                }
            }
        }

        public User Login(string username, string password)
        {
             using (var context = new ApiDbContext())
             {
                 return context.Users.Where(p => p.UserName == username && p.HashPassWord == password).FirstOrDefault();
             }
        }

        public User Get(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                return context.Users.FirstOrDefault(p => p.Id == id);
            }
        }

        public List<User> GetList()
        {
            using (var context = new ApiDbContext())
            {
                return context.Users.ToList();
            }
        }
    }
}
