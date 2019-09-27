using RestAPI.Service.EpicorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/EpicorOrder")]
    public class EpicorOrderController : ApiController
    {
        private IEpicorOrderService epicorOrder;
        public EpicorOrderController()
        {
            epicorOrder = new EpicorOrderService();
        }

        [HttpGet]
        [Route("Orders")]
        public IQueryable<EpicorOrderModel> Get()
        {
            return epicorOrder.Get().AsQueryable();
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<EpicorOrderModel>))]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            EpicorOrderModel product = epicorOrder.Get().FirstOrDefault(e => e.OrderNum == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPost]
        [ResponseType(typeof(IEnumerable<EpicorOrderModel>))]
        public async Task<IHttpActionResult> Post(EpicorOrderModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // For this sample, we aren't enforcing unique keys.
            if (await epicorOrder.Post(product) == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch]
        [ResponseType(typeof(IEnumerable<EpicorOrderModel>))]
        [Route("{company},{id}")]
        public async Task<IHttpActionResult> Patch(EpicorOrderModel product, string company, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //string Compamy, string id,
            // For this sample, we aren't enforcing unique keys.
            if (await epicorOrder.Patch(company, id, product) == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{company},{id}")]
        [ResponseType(typeof(IEnumerable<EpicorOrderModel>))]
        public async Task<IHttpActionResult> Delete(string company, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await epicorOrder.Deletes(company, id) == "true")
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
