using RestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.Services
{
    public interface IAccountDBService
    {
        List<Account> GetAccounts();

        Account GetAccount(int id);

        int Add(Account account);

        int Put(Account _account);

        int Delete(int id);
    }
}