using RestAPI.Service.EpicorService;
using RestAPI.Service.EpicorService.EpicorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/Epicorcompany")]
    public class EpicorCompanyController : ApiController
    {
        private IEpicorCompanySeervice epicorCompany;
        public EpicorCompanyController()
        {
            epicorCompany = new EpicorCompanySeervice();
        }

        [HttpGet]
        [Route("{id}/companies")]
        [ResponseType(typeof(IEnumerable<EpicorCompanyModel>))]
        public IHttpActionResult Get(string id)
        {
            EpicorCompanyModel company = epicorCompany.Get(id);
            return Ok(company);
        }
    }
}
