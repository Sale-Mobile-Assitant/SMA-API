using RestAPI.Data;
using RestAPI.Models;
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
    [RoutePrefix("api/Employeetype")]
    public class EmployeeTypeController : ApiController
    {
        private ModelFactory modelFactory;
        private IEmployeeTypeService employeeService;

        public EmployeeTypeController()
        {
            modelFactory = new ModelFactory();
            employeeService = new EmployeeTypeService();
        }

        [HttpGet]
        [Route("employeetypes")]
        public IEnumerable<EmployeeTypeModel> Get()
        {
            return employeeService.GetEmployees().ToList().Select(p => modelFactory.Create(p));
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<EmployeeTypeModel>))]
        public IHttpActionResult Get(string id)
        {
            var _employess = employeeService.GetEmployees().ToList().Select(p => modelFactory.Create(p)).Where(a => a.ETypeID == id);

            if (_employess.Count() < 1)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_employess);
        }

        [HttpPost]
        [ResponseType(typeof(IEnumerable<EmployeeTypeModel>))]
        public IHttpActionResult Post([FromBody] EmployeeType employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (employeeService.Add(employee) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [ResponseType(typeof(IEnumerable<EmployeeTypeModel>))]
        public IHttpActionResult Put(EmployeeType employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (employeeService.Put(employee) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<EmployeeTypeModel>))]
        public IHttpActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (employeeService.Delete(id) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
