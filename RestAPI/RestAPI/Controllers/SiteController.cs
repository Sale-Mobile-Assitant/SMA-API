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
    [RoutePrefix("api/Stie")]
    public class SiteController : ApiController
    {
        private ModelFactory modelFactory;
        private ISiteService employeeService;

        public SiteController()
        {
            modelFactory = new ModelFactory();
            employeeService = new SiteService();
        }

        [HttpGet]
        [Route("sites")]
        public IEnumerable<SiteModel> Get()
        {
            return employeeService.Get().ToList().Select(p => modelFactory.Create(p));
        }

        [HttpPost]
        [ResponseType(typeof(IEnumerable<SiteModel>))]
        public IHttpActionResult Post([FromBody] Site employee)
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
