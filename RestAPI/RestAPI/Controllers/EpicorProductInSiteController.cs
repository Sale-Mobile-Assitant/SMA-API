using RestAPI.Service.EpicorService;
using RestAPI.Service.EpicorService.EpicorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/Epicorinsite")]
    public class EpicorProductInSiteController : ApiController
    {
        private IEpicorSiteInService epicorSite;
        public EpicorProductInSiteController()
        {
            epicorSite = new EpicorSiteInService();
        }

        [HttpGet]
        [Route("productinsites")]
        public IQueryable<EpicorInSiteModel> Get()
        {
            return epicorSite.Get().AsQueryable();
        }
    }
}
