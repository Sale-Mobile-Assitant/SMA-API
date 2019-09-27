using RestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.Services
{
    public class AccountDBService : IAccountDBService
    {
        private SaleMobileAssistantEntities DB = new SaleMobileAssistantEntities();
        public List<Account> GetAccounts()
        {
            return DB.Accounts.ToList();
        }

        public Account GetAccount(int id)
        {
            return DB.Accounts.Where(p => p.ID == id).FirstOrDefault();
        }

        public int Add(Account account)
        {
            DB.Accounts.Add(account);
            return DB.SaveChanges();
        }

        public int Put(Account _account)
        {
            var exitingAccount = DB.Accounts.Where(p => p.ID == _account.ID).FirstOrDefault();
            if (exitingAccount != null)
            {
                exitingAccount.CompID = _account.CompID;
                exitingAccount.Username = _account.Username;
                exitingAccount.Password = _account.Password;
                exitingAccount.Type = _account.Type;
                exitingAccount.EmplID = _account.EmplID;
                exitingAccount.Note = _account.Note;

                return DB.SaveChanges();
            }
            return -1;
        }

        public int Delete(int id)
        {
            var result = DB.Accounts.Where(p => p.ID == id).FirstOrDefault();
            if (result == null)
            {
                return -1;
            }
            DB.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            return DB.SaveChanges();
        }
    }
}