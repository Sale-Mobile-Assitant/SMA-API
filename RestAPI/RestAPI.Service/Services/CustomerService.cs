using RestAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private SaleMobileAssistantEntities DB = new SaleMobileAssistantEntities();
        public List<Customer> GetCustomers()
        {
            return DB.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return DB.Customers.Where(p => p.CustID == id).FirstOrDefault();
        }

        public int Add(Customer _customer)
        {
            DB.Customers.Add(_customer);
            return DB.SaveChanges();
        }

        public int Put(Customer _customer)
        {
            var exitingCustomer = DB.Customers.Where(p => p.CustID == _customer.CustID).FirstOrDefault();
            if (exitingCustomer != null)
            {
                exitingCustomer.CompID = _customer.CompID;
                exitingCustomer.CustName = _customer.CustName;
                exitingCustomer.Address1 = _customer.Address1;
                exitingCustomer.Address2 = _customer.Address2;
                exitingCustomer.Address3 = _customer.Address3;
                exitingCustomer.City = _customer.City;
                exitingCustomer.Country = _customer.Country;
                exitingCustomer.PhoneNum = _customer.PhoneNum;
                exitingCustomer.Discount = _customer.Discount;

                return DB.SaveChanges();
            }
            return -1;
        }

        public int Delete(int id)
        {
            var result = DB.Customers.Where(p => p.CustID == id).FirstOrDefault();
            if (result == null)
            {
                return -1;
            }
            DB.Entry(result).State = System.Data.Entity.EntityState.Deleted;
            return DB.SaveChanges();
        }
    }
}