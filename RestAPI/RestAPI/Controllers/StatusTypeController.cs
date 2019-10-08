using RestAPI.Models;
using RestAPI.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/StatusType")]
    public class StatusTypeController : ApiController
    {
        private ModelFactory modelFactory;
        private IStatusTypeService statusType;

        public StatusTypeController()
        {
            modelFactory = new ModelFactory();
            statusType = new StatusTypeService();
        }
        [HttpGet]
        [Route("statusType")]
        public IEnumerable<StatusTypeModel> Get()
        {
            return statusType.GetStatusType().ToList().Select(p => modelFactory.Create(p));
        }
    }
}
