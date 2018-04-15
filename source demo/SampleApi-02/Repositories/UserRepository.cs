using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Common;

namespace Repositories
{
    public class UserRepository
    {
        public User Create(User user)
        {
            using (var context = new ApiDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                return context.Users.Find(user.Id);
            }
        }

        public User Get(string username)
        {
            using (var context = new ApiDbContext())
            {
                return context.Users.FirstOrDefault(e => e.Username == username);
            }
        }
    }
}
