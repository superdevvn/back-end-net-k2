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
    public class ProductApiController : ApiController
    {
        ProductService productservice = new ProductService();

        [HttpPost]
        [Route("api/createProduct")]
        public IHttpActionResult Create(JObject obj)
        {
            try
            {
                var entity = new Product();
                entity.Code = obj["Code"].ToString();
                entity.Name = obj["Name"].ToString();
                entity.Price = Int32.Parse(obj["Price"].ToString());
                entity.Description = obj["Description"].ToString();
                entity.CategoryId = new Guid(obj["CategoryId"].ToString());
                entity.ManufacturerId = new Guid(obj["ManufacturerId"].ToString());
                return Ok(productservice.Save(entity));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/updateProduct")]
        public IHttpActionResult Update(JObject obj)
        {
            try
            {
                var entity = new Product();
                entity.Id = new Guid(obj["Id"].ToString());
                entity.Code = obj["Code"].ToString();
                entity.Name = obj["Name"].ToString();
                entity.Price = Int32.Parse(obj["Price"].ToString());
                entity.Description = obj["Description"].ToString();
                entity.CategoryId = new Guid(obj["CategoryId"].ToString());
                entity.ManufacturerId = new Guid(obj["ManufacturerId"].ToString());
                return Ok(productservice.Save(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/deleteProduct")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                productservice.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/getProduct")]
        public IHttpActionResult GetProduct(Guid id)
        {
            try
            {
                return Ok(productservice.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/getProducts")]
        public IHttpActionResult GetProducts()
        {
            try
            {
                return Ok(productservice.GetList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}