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
    [RoutePrefix("api/RoutePlan")]
    public class RoutePlanController : ApiController
    {
        private ModelFactory modelFactory;
        private IRoutePlanService routePlanService;

        public RoutePlanController()
        {
            modelFactory = new ModelFactory();
            routePlanService = new RoutePlanService();
        }

        [HttpGet]
        [Route("routeplans")]
        public IEnumerable<RoutePlanModel> Get()
        {
            return routePlanService.GetRoutePlans().ToList().Select(p => modelFactory.Create(p));
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<RoutePlanModel>))]
        public IHttpActionResult Get(string id)
        {
            var _order = routePlanService.GetRoutePlans().ToList().Select(p => modelFactory.Create(p)).Where(a => a.EmplID == id);

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
        [ResponseType(typeof(IEnumerable<RoutePlanModel>))]
        public IHttpActionResult Post([FromBody] RoutePlan routePlan)
        {
            if (routePlan == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (routePlanService.Add(routePlan) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [ResponseType(typeof(IEnumerable<RoutePlanModel>))]
        public IHttpActionResult Put(RoutePlan routePlan)
        {
            if (routePlan == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (routePlanService.Put(routePlan) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<RoutePlanModel>))]
        public IHttpActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (routePlanService.Delete(id) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
