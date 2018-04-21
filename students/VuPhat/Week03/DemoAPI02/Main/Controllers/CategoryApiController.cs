using Model;
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
    public class CategoryApiController : ApiController
    {
        CategoryService categoryservice = new CategoryService();

        [HttpPost]
        [Route("api/createCategory")]
        public IHttpActionResult Create(JObject obj)
        {
           try
           {
               var entity = new Category();
               entity.Code = obj["Code"].ToString();
               entity.Name = obj["Name"].ToString();
               return Ok(categoryservice.Save(entity));
           }
            catch(Exception ex)
           {
               return BadRequest(ex.Message);
           }
        }

        [HttpPost]
        [Route("api/updateCategory")]
        public IHttpActionResult Update(JObject obj)
        {
            try
            {
                var entity = new Category();
                entity.Id = new Guid(obj["Id"].ToString());
                entity.Code = obj["Code"].ToString();
                entity.Name = obj["Name"].ToString();
                return Ok(categoryservice.Save(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/deleteCategory")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                categoryservice.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/getCategory")]
        public IHttpActionResult GetCategory(Guid id)
        {
            try
            {
                return Ok(categoryservice.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/getCategories")]
        public IHttpActionResult GetCategories()
        {
            try
            {
                return Ok(categoryservice.GetList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}