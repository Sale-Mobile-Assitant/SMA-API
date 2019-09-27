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
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        private ModelFactory modelFactory;
        private IEmployeeService employeeService;

        public EmployeeController()
        {
            modelFactory = new ModelFactory();
            employeeService = new EmployeeService();
        }

        [HttpGet]
        [Route("employees")]
        public IEnumerable<EmployeeModel> Get()
        {
            return employeeService.GetEmployees().ToList().Select(p => modelFactory.Create(p));
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<EmployeeModel>))]
        public IHttpActionResult Get(string id)
        {
            var _employess = employeeService.GetEmployees().ToList().Select(p => modelFactory.Create(p)).Where(a => a.EmplID == id);

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
        [ResponseType(typeof(IEnumerable<EmployeeModel>))]
        public IHttpActionResult Post([FromBody] Employee employee)
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
        [ResponseType(typeof(IEnumerable<EmployeeModel>))]
        public IHttpActionResult Put(Employee employee)
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
        [ResponseType(typeof(IEnumerable<EmployeeModel>))]
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
