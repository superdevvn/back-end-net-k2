using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Models.Common;
using Newtonsoft.Json.Linq;
using Services;

namespace SampleApi.Controllers
{
    [AuthorizeFilter]
    public class RoleApiController : ApiController
    {
        RoleService roleService = new RoleService();

        [HttpPost]
        [Route("api/createRole")]
        public IHttpActionResult Create(JObject obj)
        {
            try
            {
                var role = new Role();
                role.Code = obj["Code"].ToString();
                role.Name = obj["Name"].ToString();
                return Ok(roleService.Save(role));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/updateRole")]
        public IHttpActionResult Update(JObject obj)
        {
            try
            {
                var role = new Role();
                role.Id = new Guid(obj["Id"].ToString());
                role.Code = obj["Code"].ToString();
                role.Name = obj["Name"].ToString();
                return Ok(roleService.Save(role));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/getRoles")]
        public IHttpActionResult GetList(JObject obj)
        {
            try
            {
                return Ok(roleService.GetList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/getPagingRoles")]
        public IHttpActionResult GetEntities(JObject obj)
        {
            try
            {
                string orderBy = obj["orderBy"].ToString();
                string orderDirection = obj["orderDirection"].ToString();
                string code = obj["code"].ToString();
                string date = obj["date"].ToString();
                int page = int.Parse(obj["page"].ToString());
                int pageSize = int.Parse(obj["pageSize"].ToString());
                return Ok(roleService.GetList(orderBy, orderDirection, page, pageSize, code, date));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/getRole")]
        public IHttpActionResult GetRole(Guid id)
        {
            try
            {
                return Ok(roleService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/deleteRole")]
        public IHttpActionResult DeleteRole(Guid id)
        {
            try
            {
                roleService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}