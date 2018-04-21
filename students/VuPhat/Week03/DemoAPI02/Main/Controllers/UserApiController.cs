using Model;
using Model.Context;
using Newtonsoft.Json.Linq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace Main.Controllers
{
    public class UserApiController : ApiController
    {
        UserService userservice = new UserService();

        [HttpPost]
        [Route("api/createUser")]
        public IHttpActionResult Create(JObject obj)
        {
            var user = new User();
            user.RoleId = new Guid(obj["RoleId"].ToString());
            user.UserName = obj["UserName"].ToString();
            user.HashPassWord = userservice.MD5Encrypt(obj["PassWord"].ToString());
            return Ok(userservice.Save(user));
        }

        [HttpPost]
        [Route("api/updateUser")]
        public IHttpActionResult Update(JObject obj)
        {
            var user = new User();
            user.Id = new Guid(obj["Id"].ToString());
            user.RoleId = new Guid(obj["RoleId"].ToString());
            user.UserName = obj["UserName"].ToString();
            user.HashPassWord = userservice.MD5Encrypt(obj["PassWord"].ToString());
            return Ok(userservice.Save(user));
        }

        [HttpGet]
        [Route("api/deleteUser")]
        public void Delete(Guid id)
        {
            userservice.Delete(id);
        }

        [HttpGet]
        [Route("api/getUsers")]
        public IHttpActionResult GetList()
        {
            return Ok(userservice.GetList());
        }

        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login(JObject obj)
        {
            try
            {
                var username = obj["UserName"].ToString();
                var password = obj["PassWord"].ToString();
                var hashPassword = userservice.MD5Encrypt(password);
                return Ok(userservice.Login(username, hashPassword));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}