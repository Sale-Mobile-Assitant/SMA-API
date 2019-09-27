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
    [RoutePrefix("api/EpicorProduct")]
    public class EpicorProductController : ApiController
    {
        private IEpicorProductService epicorProduct;
        public EpicorProductController()
        {
            epicorProduct = new EpicorProductService();
        }

        [HttpGet]
        [Route("Products")]
        public IQueryable<EpicorProductModel> Get()
        {
            return epicorProduct.Get().AsQueryable();
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<EpicorProductModel>))]
        [Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            EpicorProductModel product = epicorProduct.Get().FirstOrDefault(e => e.PartNum == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPost]
        [ResponseType(typeof(IEnumerable<EpicorProductModel>))]
        public async Task<IHttpActionResult> Post(EpicorProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // For this sample, we aren't enforcing unique keys.
            if (await epicorProduct.Post(product) == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPatch]
        [ResponseType(typeof(IEnumerable<EpicorProductModel>))]
        [Route("{company},{id}")]
        public async Task<IHttpActionResult> Patch(EpicorProductModel product,string company,string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //string Compamy, string id,
            // For this sample, we aren't enforcing unique keys.
            if (await epicorProduct.Patch(company,id,product) == true)
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
        [ResponseType(typeof(IEnumerable<EpicorProductModel>))]
        public async Task<IHttpActionResult> Delete(string company,string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await epicorProduct.DeleteCustomers(company,id) == "true")
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
