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
    [RoutePrefix("api/Epicoremployeetype")]
    public class EpicorEmployeeTypeController : ApiController
    {
        private IEpicorEmployeeTypeService epicorEmployeeType;
        public EpicorEmployeeTypeController()
        {
            epicorEmployeeType = new EpicorEmployeeTypeService();
        }

        [HttpGet]
        [Route("employeestypies")]
        public IQueryable<EpicorEmployeeTypeModel> Get()
        {
            return epicorEmployeeType.Get().AsQueryable();
        }
    }
}
