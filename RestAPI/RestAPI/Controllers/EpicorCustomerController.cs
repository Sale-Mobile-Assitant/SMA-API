using RestAPI.Models;
using RestAPI.Service.EpicorService;
using RestAPI.Service.EpicorService.EpicorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/EpicorCustomer")]
    public class EpicorCustomerController : ApiController
    {
        private IEpicorCustomerService epicorCustomer;
        public EpicorCustomerController()
        {
            epicorCustomer = new EpicorCustomerService();
        }

        [HttpGet]
        [Route("Customers")]
        public IQueryable<EpicorCustomerModel> Get()
        {
            return epicorCustomer.Get().AsQueryable();
        }
        [HttpGet]
        [ResponseType(typeof(IEnumerable<EpicorCustomerModel>))]
        [Route("{id}")]
        public IHttpActionResult Get([FromODataUri]int id)
        {
            EpicorCustomerModel customer = epicorCustomer.Get().FirstOrDefault(e => e.CustNum == id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
       
    }
}
