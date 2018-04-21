using Model;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
    public class UserService
    {
        UserRepository userrepository = new UserRepository();
        
        public string MD5Encrypt(string password)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            var encoder = new UTF8Encoding();
            var hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));
            return hashedBytes.Aggregate(String.Empty, (current, b) => current + b.ToString("x2"));
        }

        public List<User> GetList()
        {
            return userrepository.GetList();
        }

        public User Save(User user)
        {
            if(string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.HashPassWord))
            {
                throw new Exception("USER_INPUT_INVALID");
            }
            if(user.Id == Guid.Empty)
            {
                user.Id = Guid.NewGuid();
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                userrepository.Create(user);
                return user;
            }
            else
            {
                var entity = userrepository.Get(user.UserName);
                if(entity == null)
                {
                    throw new Exception("USER_NOTFOUND");
                }
                else
                {
                    userrepository.Update(user);
                    return user;
                }
            }
        }

        public void Delete(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new Exception("ID_USER_INVALID");
            }
            
            var entity = userrepository.Get(id);
            if(entity == null)
            {
                throw new Exception("USER_NOTFOUND");
            }
            else
            {
                userrepository.Delete(id);
            }
           
        }

        public string Encrypt(string data)
        {
            return data;
        }

        public string Decrypt(string data)
        {
            return data;
        }

        public string Login(string username, string password)
        {
            var entity = userrepository.Get(username);
            if (entity == null)
            {
                throw new Exception("USER_NOTFOUND");
            }
            else if (entity.HashPassWord != password)
            {
                throw new Exception("USER_INCORRECT_PASSWORD");
            }

            var token = Encrypt(username + "~" + password);
            return token;
        }

        public User GetCurrrentUser()
        {
            var token = HttpContext.Current.Request.Headers.Get("Auth-SuperDev").ToString();
            var decrypt = Decrypt(token);
            var username = decrypt.Split('~')[0];
            var password = decrypt.Split('~')[1];
            var user = userrepository.Get(username);
            if (user != null && user.HashPassWord == password)
            {
                return user;
            }
            else
            {
                throw new Exception();
            }
        }

    }
}
