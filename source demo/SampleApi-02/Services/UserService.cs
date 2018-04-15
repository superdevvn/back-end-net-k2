using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Models;
using Repositories;

namespace Services
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        public string MD5Encrypt(string password)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            var encoder = new UTF8Encoding();
            var hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));
            return hashedBytes.Aggregate(String.Empty, (current, b) => current + b.ToString("x2"));
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
            var user = userRepository.Get(username);
            if (user == null) throw new Exception("USER_USERNAME_NOTFOUND");
            if (user.HashedPassword != MD5Encrypt(password)) throw new Exception("USER_INCORRECT_PASSWORD");
            var token = Encrypt(username + "~" + password);
            return token;
        }

        public User GetCurrrentUser()
        {
            var token = HttpContext.Current.Request.Headers.Get("Auth-SuperDev").ToString();
            var decrypt = Decrypt(token);
            var username = decrypt.Split('~')[0];
            var password = decrypt.Split('~')[1];
            var user = userRepository.Get(username);
            if (user != null && user.HashedPassword == MD5Encrypt(password)) return user;
            else throw new Exception();   
        }
    }
}
