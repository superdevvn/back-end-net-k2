using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Models.Common;
using Newtonsoft.Json.Linq;

namespace SampleApi.Controllers
{
    public class RoleApiController : ApiController
    {
        [HttpPost]
        [Route("api/createRole")]
        public IHttpActionResult Create(Role role)
        {
            using(var context = new ApiDbContext())
            {
                role.Id = Guid.NewGuid();
                role.CreatedDate = DateTime.Now;
                role.ModifiedDate = DateTime.Now;
                context.Roles.Add(role);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpPost]
        [Route("api/createRoleDynamic")]
        public IHttpActionResult Create(JObject obj)
        {
            using (var context = new ApiDbContext())
            {
                var role = new Role();
                role.Code = obj["Code"].ToString();
                role.Name = obj["Name"].ToString();
                role.Id = Guid.NewGuid();
                role.CreatedDate = DateTime.Now;
                role.ModifiedDate = DateTime.Now;
                context.Roles.Add(role);
                context.SaveChanges();
                return Ok(role);
            }
        }

        [HttpPost]
        [Route("api/getRoles")]
        public IHttpActionResult GetList(JObject obj)
        {
            using (var context = new ApiDbContext())
            {
                return Ok(context.Roles.ToList());
            }
        }

        [HttpGet]
        [Route("api/getRole")]
        public IHttpActionResult GetRole(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                var role = context.Roles.Where(e => e.Id == id).FirstOrDefault();
                return Ok(role);
            }
        }

        [HttpGet]
        [Route("api/getRoleOther/{id}")]
        public IHttpActionResult GetRoleOther(Guid id)
        {
            using (var context = new ApiDbContext())
            {
                var role = context.Roles.Where(e => e.Id == id).FirstOrDefault();
                return Ok(role);
            }
        }

        [HttpPost]
        [Route("api/updateRoleDynamic")]
        public IHttpActionResult Update(JObject obj)
        {
            using (var context = new ApiDbContext())
            {
                var id = new Guid(obj["Id"].ToString());
                var role = context.Roles.Where(e => e.Id == id).FirstOrDefault();
                role.Code = obj["Code"].ToString();
                role.Name = obj["Name"].ToString();
                role.ModifiedDate = DateTime.Now;
                context.SaveChanges();
                return Ok(role);
            }
        }
    }
}