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
    public class ManufacturerApiController : ApiController
    {
        ManufacturerService manufacturerservice = new ManufacturerService();

        [HttpPost]
        [Route("api/createManufacturer")]
        public IHttpActionResult Create(JObject obj)
        {
            try
            {
                var entity = new Manufacturer();
                entity.Code = obj["Code"].ToString();
                entity.Name = obj["Name"].ToString();
                entity.Description = obj["Description"].ToString();
                return Ok(manufacturerservice.Save(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/updateManufacturer")]
        public IHttpActionResult Update(JObject obj)
        {
            try
            {
                var entity = new Manufacturer();
                entity.Id = new Guid(obj["Id"].ToString());
                entity.Code = obj["Code"].ToString();
                entity.Name = obj["Name"].ToString();
                entity.Description = obj["Description"].ToString();
                return Ok(manufacturerservice.Save(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/deleteManufacturer")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                manufacturerservice.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/getManufacturer")]
        public IHttpActionResult GetCategory(Guid id)
        {
            try
            {
                return Ok(manufacturerservice.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/getManufacturers")]
        public IHttpActionResult GetCategories()
        {
            try
            {
                return Ok(manufacturerservice.GetList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}