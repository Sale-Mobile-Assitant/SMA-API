using RestAPI.Data;
using RestAPI.Models;
using RestAPI.Service.EpicorService;
using RestAPI.Service.EpicorService.EpicorModel;
using RestAPI.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestAPI.Controllers
{
    [RoutePrefix("api/EpicorProductGroup")]
    public class EpicorProductGroupController : ApiController
    {
        private ModelFactory modelFactory;
        private IEpicorProductGroupService productService;

        public EpicorProductGroupController()
        {
            modelFactory = new ModelFactory();
            productService = new EpicorProductGroupService();
        }

        [HttpGet]
        [Route("productgroups")]
        public IQueryable<EpicorProductGroupModel> Get()
        {
            return productService.Get().AsQueryable();
        }
       
    }
}
