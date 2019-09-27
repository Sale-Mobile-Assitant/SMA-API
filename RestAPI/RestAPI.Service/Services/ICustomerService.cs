using RestAPI.Data;
using System.Collections.Generic;

namespace RestAPI.Service.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();

        Customer GetCustomer(int id);

        int Add(Customer _customer);

        int Put(Customer _customer);

        int Delete(int id);
    }
}