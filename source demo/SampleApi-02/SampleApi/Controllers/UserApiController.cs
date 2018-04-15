using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using Models;
using Models.Common;
using Newtonsoft.Json.Linq;

namespace SampleApi.Controllers
{
    public class UserApiController: ApiController
    {
        public string MD5Encrypt(string password)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            var encoder = new UTF8Encoding();
            var hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));
            return hashedBytes.Aggregate(String.Empty, (current, b) => current + b.ToString("x2"));
        }

        [HttpPost]
        [Route("api/createUser")]
        public IHttpActionResult Create(JObject obj)
        {
            using (var context = new ApiDbContext())
            {
                var user = new User();
                user.Username = obj["Username"].ToString();
                user.HashedPassword = MD5Encrypt(obj["Password"].ToString());
                user.RoleId = new Guid(obj["RoleId"].ToString());
                user.Id = Guid.NewGuid();
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                context.Users.Add(user);
                context.SaveChanges();
                return Ok(user);
            }
        }

        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login(JObject obj)
        {
            var username = obj["username"].ToString();
            var password = obj["password"].ToString();
            var hashPassword = MD5Encrypt(password);
            using (var context = new ApiDbContext())
            {
                var user = context.Users.FirstOrDefault(e => e.Username == username && e.HashedPassword == hashPassword);
                if (user == null) throw new Exception("Login sai rồi mầy");
                return Ok(user);
            }
        }
    }
}