using RestAPI.Data;
using RestAPI.Models;
using RestAPI.Service.Services;
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
    [RoutePrefix("api/Company")]
    public class CompanyController : ApiController
    {
        private ModelFactory modelFactory;
        private ICompanyService companyService;

        public CompanyController()
        {
            modelFactory = new ModelFactory();
            companyService = new CompanyService();
        }
        [HttpGet]
        [Route("companies")]
        public IEnumerable<CompanyModel> Get()
        {
            return companyService.GetCompanies().ToList().Select(p => modelFactory.Create(p));
        }
        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<CompanyModel>))]
        public IHttpActionResult Get(string id)
        {
            var _company = companyService.GetCompany(id);

            if (_company == null)
            {
                return NotFound();
            }

            CompanyModel company = new CompanyModel()
            {
                CompID = _company.CompID,
                CompName = _company.CompName,
                Address1 = _company.Address1,
                Address2 = _company.Address2,
                Address3 = _company.Address3,
                City = _company.City,
                PhoneNum = _company.PhoneNum,
                Province = _company.Province,
                EmployeeType = _company.EmployeeTypes.Select(e => modelFactory.Create(e)),
                ProductGroup = _company.ProductGroups.Select(p => modelFactory.Create(p)),
                Site = _company.Sites.Select(s => modelFactory.Create(s))
            };
            return Ok(company);
        }

        [HttpGet]
        [Route("top/{index}")]
        public IEnumerable<CompanyModel> GetTop(int index)
        {
            return companyService.GetCompanies().ToList().OrderByDescending(u => u).Take(index).Select(p => modelFactory.Create(p));
        }
        [HttpGet]
        [Route("listcompanies")]
        [ResponseType(typeof(IEnumerable<CompanyModel>))]
        public IHttpActionResult GetCompanies()
        {
            var result = companyService.GetCompanies().Select(p => new { p.CompID,p.CompName,p.Address1,p.Address2,p.Address3,p.City,p.PhoneNum,p.Province}).ToList();
            return Ok(result);
        }

        [HttpPost]
        [ResponseType(typeof(IEnumerable<CompanyModel>))]
        public IHttpActionResult Post([FromBody] Company company)
        {
            if (company == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (companyService.Add(company) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [ResponseType(typeof(IEnumerable<CompanyModel>))]
        public IHttpActionResult Put(Company company)
        {
            if (company == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (companyService.Put(company) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<CompanyModel>))]
        public IHttpActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (companyService.Delete(id) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
