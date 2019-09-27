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
    [RoutePrefix("api/Prodcutinsite")]
    public class ProductInSiteController : ApiController
    {
        private ModelFactory modelFactory;
        private IProductInSiteService employeeService;

        public ProductInSiteController()
        {
            modelFactory = new ModelFactory();
            employeeService = new ProductInSiteService();
        }

        [HttpGet]
        [Route("prodcutinsites")]
        public IEnumerable<ProductInSiteModel> Get()
        {
            return employeeService.Get().ToList().Select(p => modelFactory.Create(p));
        }

        [HttpPost]
        [ResponseType(typeof(IEnumerable<ProductInSiteModel>))]
        public IHttpActionResult Post([FromBody] ProductInSite employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (employeeService.Add(employee) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
     
    }
}
