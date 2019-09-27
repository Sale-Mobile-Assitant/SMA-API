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
    [RoutePrefix("api/AccountDB")]
    public class AccountDBController : ApiController
    {
        private ModelFactory modelFactory;
        private IAccountDBService accountDBService;

        public AccountDBController()
        {
            modelFactory = new ModelFactory();
            accountDBService = new AccountDBService();
        }

        [HttpGet]
        [Route("accountdb")]
        public IEnumerable<AccountModel> Get()
        {
            return accountDBService.GetAccounts().ToList().Select(p => modelFactory.Create(p));
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<AccountModel>))]
        public IHttpActionResult Get(int id)
        {
            var _account = accountDBService.GetAccounts().ToList().Select(p => modelFactory.Create(p)).Where(a => a.ID == id);

            if (_account.Count() < 1)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_account);
        }


        [HttpPost]
        [ResponseType(typeof(IEnumerable<AccountModel>))]
        public IHttpActionResult Post([FromBody] Account account)
        {
            // lỗi do acccount với pass word
            if (account == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (accountDBService.Add(account) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [ResponseType(typeof(IEnumerable<AccountModel>))]
        public IHttpActionResult Put([FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (accountDBService.Put(account) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(IEnumerable<AccountModel>))]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (accountDBService.Delete(id) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
