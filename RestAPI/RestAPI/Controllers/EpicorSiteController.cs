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
    [RoutePrefix("api/Epicorsite")]
    public class EpicorSiteController : ApiController
    {
        private IEpicorSiteService epicorSite;
        public EpicorSiteController()
        {
            epicorSite = new EpicorSiteService();
        }

        [HttpGet]
        [Route("sites")]
        public IQueryable<EpicorSiteModel> Get()
        {
            return epicorSite.Get().AsQueryable();
        }
    }
}
