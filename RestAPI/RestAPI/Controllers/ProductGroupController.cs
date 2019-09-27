using RestAPI.Data;
using RestAPI.Models;
using RestAPI.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/Productgroup")]
    public class ProductGroupController : ApiController
    {
        private ModelFactory modelFactory;
        private IProductGroupService productService;

        public ProductGroupController()
        {
            modelFactory = new ModelFactory();
            productService = new ProductGroupService();
        }

        [HttpGet]
        [Route("productgroups")]
        public IEnumerable<ProductGroupModel> Get()
        {
            return productService.GetProducts().ToList().Select(p => modelFactory.Create(p));
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<ProductGroupModel>))]
        public IHttpActionResult Get(string id)
        {
            var _order = productService.GetProducts().ToList().Select(p => modelFactory.Create(p)).Where(a => a.PGroupID == id);

            if (_order.Count() < 1)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_order);
        }

        [HttpPost]
        [ResponseType(typeof(IEnumerable<ProductGroupModel>))]
        public IHttpActionResult Post([FromBody] ProductGroup product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (productService.Add(product) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [ResponseType(typeof(IEnumerable<ProductGroupModel>))]
        public IHttpActionResult Put(ProductGroup product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (productService.Put(product) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<ProductGroupModel>))]
        public IHttpActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (productService.Delete(id) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
