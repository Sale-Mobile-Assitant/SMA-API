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
    [RoutePrefix("api/Epicoremployees")]
    public class EpicorEmployeeController : ApiController
    {
        private IEpicorEmployeeService epicorEmployee;
        public EpicorEmployeeController()
        {
            epicorEmployee = new EpicorEmployeeService();
        }

        [HttpGet]
        [Route("employeestypies")]
        public IQueryable<EpicorEmployeeModel> Get()
        {
            return epicorEmployee.Get().AsQueryable();
        }
    }
}
