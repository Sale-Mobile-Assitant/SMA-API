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
    [RoutePrefix("api/Orderdetail")]
    public class OrderDetailController : ApiController
    {

        private ModelFactory modelFactory;
        private IOrderDetailService orderDetailService;

        public OrderDetailController()
        {
            modelFactory = new ModelFactory();
            orderDetailService = new OrderDetailService();
        }

        [HttpGet]
        [Route("orderdetails")]
        public IEnumerable<OrderDetailModel> Get()
        {
            return orderDetailService.GetOrders().ToList().Select(p => modelFactory.Create(p));
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<OrderDetailModel>))]
        public IHttpActionResult Get(string id)
        {

            var _order = orderDetailService.GetOrders().ToList().Select(p => modelFactory.Create(p)).Where(a => a.MyOrderID == id);


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
        [ResponseType(typeof(IEnumerable<OrderDetailModel>))]
        public IHttpActionResult Post([FromBody] OrderDetail order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (orderDetailService.Add(order) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [ResponseType(typeof(IEnumerable<OrderDetailModel>))]
        public IHttpActionResult Put(OrderDetail order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (orderDetailService.Put(order) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<OrderDetailModel>))]
        public IHttpActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (orderDetailService.Delete(id) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
