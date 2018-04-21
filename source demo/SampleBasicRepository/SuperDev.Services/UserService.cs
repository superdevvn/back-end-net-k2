using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SuperDev.Models;
using SuperDev.Repositories;
using Utilities;

namespace SuperDev.Services
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();

        public async Task<string> Login(string username, string password)
        {
            var user = await userRepository.Get(username);
            if (user == null) throw new Exception("USER_USERNAME_NOTFOUND");
            if (user.HashedPassword != Utility.MD5Encrypt(password)) throw new Exception("USER_INCORRECT_PASSWORD");
            var token = Utility.Encrypt(username + "~" + password);
            return token;
        }

        public async Task<User> GetCurrrentUser()
        {
            var token = HttpContext.Current.Request.Headers.Get("Auth-SuperDev").ToString();
            var decrypt = Utility.Decrypt(token);
            var username = decrypt.Split('~')[0];
            var password = decrypt.Split('~')[1];
            var user = await userRepository.Get(username);
            if (user != null && user.HashedPassword == Utility.MD5Encrypt(password)) return user;
            else throw new Exception("TOKEN_INVALID");
        }
    }
}
