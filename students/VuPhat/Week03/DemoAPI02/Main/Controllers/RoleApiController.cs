using Model;
using Model.Context;
using Newtonsoft.Json.Linq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Main.Controllers
{
    [AuthorizeFilter]
    public class RoleApiController : ApiController
    {
        RoleService roleservice = new RoleService();

        [HttpPost]
        [Route("api/createRole")]
        public IHttpActionResult Create(Role role)
        {
            using (var context = new ApiDbContext())
            {
                role.Id = Guid.NewGuid();
                role.CreatedDate = DateTime.Now;
                role.ModifiedDate = DateTime.Now;
                context.Roles.Add(role);
                context.SaveChanges();
                return Ok(role);
            }
        }

        [HttpPost]
        [Route("api/createRoleDynamic")]
        public IHttpActionResult Create(JObject obj)
        {
            try {
                Role role = new Role();
                role.Code = obj["Code"].ToString();
                role.Name = obj["Name"].ToString();
                return Ok(roleservice.Save(role));   
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/getRoles")]
        public IHttpActionResult GetList()
        {
            try
            {
                return Ok(roleservice.GetList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/getRole")]
        public IHttpActionResult GetRole(Guid Id)
        {
            try
            {
                return Ok(roleservice.Get(Id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/updateRoleDynamic")]
        public IHttpActionResult Update(JObject obj)
        {
            try
            {
                var role = new Role();
                role.Id = new Guid(obj["Id"].ToString());
                role.Code = obj["Code"].ToString();
                role.Name = obj["Name"].ToString();
                return Ok(roleservice.Save(role));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/deleteRoleDynamic")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                roleservice.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Get(Guid id)
        {
           return Ok(roleservice.Get(id));
        }
    }
}