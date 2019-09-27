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

namespace RestAPI.Controllers
{
    [RoutePrefix("api/EpicorOrderDetail")]
    public class EpicorOrderDetailController : ApiController
    {
        private IEpicorOrderDetailService epicorOrder;
        public EpicorOrderDetailController()
        {
            epicorOrder = new EpicorOrderDetailService();
        }

        [HttpGet]
        [Route("Orders")]
        public IQueryable<EpicorOrderDetailModel> Get()
        {
            return epicorOrder.Get().AsQueryable();
        }

        [HttpPost]
        [ResponseType(typeof(IEnumerable<EpicorOrderDetailModel>))]
        public async Task<IHttpActionResult> Post(EpicorOrderDetailModel product)
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
    }
}
