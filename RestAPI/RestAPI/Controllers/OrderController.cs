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
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        private ModelFactory modelFactory;
        private IOrderService orderService;

        public OrderController()
        {
            modelFactory = new ModelFactory();
            orderService = new OrderService();
        }

        [HttpGet]
        [Route("orders")]
        public IEnumerable<OrderModel> Get()
        {
            return orderService.GetOrders().ToList().Select(p => modelFactory.Create(p));
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<OrderModel>))]
        public IHttpActionResult Get(string id)
        {
         
            var _order = orderService.GetOrders().ToList().Select(p => modelFactory.Create(p)).Where(a => a.MyOrderID == id);
      

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
        [ResponseType(typeof(IEnumerable<OrderModel>))]
        public IHttpActionResult Post([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (orderService.Add(order) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [ResponseType(typeof(IEnumerable<OrderModel>))]
        public IHttpActionResult Put(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (orderService.Put(order) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<OrderModel>))]
        public IHttpActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (orderService.Delete(id) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
