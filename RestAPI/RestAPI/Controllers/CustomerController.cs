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
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private ModelFactory modelFactory;
        private ICustomerService accountDBService;

        public CustomerController()
        {
            modelFactory = new ModelFactory();
            accountDBService = new CustomerService();
        }

        [HttpGet]
        [Route("customers")]
        public IEnumerable<CustomerModel> Get()
        {
            return accountDBService.GetCustomers().ToList().Select(p => modelFactory.Create(p));
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<CustomerModel>))]
        public IHttpActionResult Get(string id)
        {
            var _customer = accountDBService.GetCustomers().ToList().Select(p => modelFactory.Create(p)).Where(a => a.CustID == id);

            if (_customer.Count() < 1)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_customer);
        }

        [HttpPost]
        [ResponseType(typeof(IEnumerable<CustomerModel>))]
        public IHttpActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (accountDBService.Add(customer) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [ResponseType(typeof(IEnumerable<CustomerModel>))]
        public IHttpActionResult Put(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (accountDBService.Put(customer) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<CustomerModel>))]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (accountDBService.Delete(id) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
